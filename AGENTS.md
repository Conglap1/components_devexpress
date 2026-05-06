# AGENTS.md — HQSOFT Component Guideline (Button_Segmented)

> **Phạm vi:** File này áp dụng cho toàn bộ folder `Button_Segmented/`.
> **Đối tượng:** AI agent (Cursor / Codex / copilot) và dev tạo component UI cho HQSOFT Design System phiên bản Blazor WASM.
> **Nguyên tắc tối thượng:** Không bao giờ tự bịa design. Mọi component phải bám spec — ưu tiên Figma, fallback sang spec `.md` đi kèm. Nếu thiếu nguồn, **phải hỏi user**.

---

## 1. Mission

Mục tiêu của project này là xây dựng một **thư viện component HQSOFT** (prefix `Hq*`) chạy trên Blazor WebAssembly (.NET 8), bằng cách:

1. **Mượn phần logic/accessibility** của component có sẵn trong thư viện bên thứ ba (DevExpress, rồi MudBlazor) — KHÔNG viết lại JS/ARIA từ đầu.
2. **Đè CSS token của HQSOFT** lên lớp style mặc định của thư viện đó — biến nó thành "của mình" về mặt visual.
3. **Kiểm tra pixel-fidelity bằng Figma MCP** (khi user cung cấp link) hoặc bằng spec `.md` đi kèm component.

Stack cố định:

- `Microsoft.AspNetCore.Components.WebAssembly` 8.0.x
- `DevExpress.Blazor` 25.2.* (đã cài)
- `MudBlazor` (chưa cài — chỉ cài khi cần fallback, xem §3.2)

---

## 2. Library priority — Chọn base component theo thứ tự

Khi bắt đầu làm 1 component mới, luôn chọn base theo thứ tự sau:

| Ưu tiên | Thư viện | Khi nào dùng |
|---|---|---|
| 1 | **DevExpress.Blazor** (`DxButton`, `DxTextBox`, `DxMenu`, `DxComboBox`, `DxGrid`, …) | Luôn kiểm tra trước. Nếu DX có component tương đương (kể cả gần giống) → chọn DX. |
| 2 | **MudBlazor** (`MudButton`, `MudSelect`, `MudTabs`, `MudExpansionPanels`, `MudCarousel`, …) | Chỉ khi DX **không có** hoặc khiếm khuyết rõ rệt (ví dụ: không có Segmented, Stepper, Timeline, Carousel, Rating, Tree…). |
| 3 | **Raw HTML + CSS token** | Chỉ khi cả DX và MudBlazor đều không có; hoặc component quá đơn giản (Badge, Dot, Chip tĩnh) đến mức wrap thư viện gây overhead. |

### 2.1 Cách kiểm tra DevExpress có component hay không

- Search nhanh trong code: `rg "Dx[A-Z]" --type cshtml` để xem các component DX project đang dùng.
- Tra tài liệu: <https://docs.devexpress.com/Blazor/> (components list).
- Nếu không chắc, **hỏi user** trước khi quyết định dùng MudBlazor.

### 2.2 Khi phải thêm MudBlazor lần đầu

Nếu component mới cần MudBlazor mà project **chưa có** package:

1. **Dừng lại, báo user** trước khi thêm package — không tự ý commit `PackageReference`.
2. Sau khi user đồng ý, thêm vào `Button_Segmented.Client.csproj`:
   ```xml
   <PackageReference Include="MudBlazor" Version="*" />
   ```
3. Đăng ký services trong `Program.cs` (`AddMudServices()`).
4. Thêm `@using MudBlazor` vào `_Imports.razor`.
5. **Không** dùng style mặc định của MudBlazor làm source of truth — component Hq* phải override bằng token HQSOFT qua scoped CSS `::deep`.

### 2.3 Raw HTML fallback

Khi viết raw HTML (ví dụ `HqBadge`, `HqProgressCircle` hiện có), vẫn phải:

- Dùng biến CSS từ `Button_Segmented/wwwroot/css/tokens.css` — **tuyệt đối không hard-code hex color, px spacing, font-size**.
- Thêm attribute accessibility tối thiểu: `role`, `aria-*`, `tabindex` khi applicable.

---

## 3. Workflow bắt buộc — Mỗi lần tạo / sửa component

AI phải chạy theo đúng 7 bước sau. Bỏ bước là vi phạm rule.

### Bước 1 — Thu thập spec

Thứ tự tìm kiếm spec, dừng ở nguồn đầu tiên tìm được:

1. User đính kèm link Figma (`https://figma.com/design/...`) → đi tiếp Bước 2.
2. File spec `.md` cùng folder component (ví dụ `Button_Segmented.Client/Button.md`, `TextField.md`) → đi thẳng Bước 3.
3. **Không có cả hai** → **DỪNG LẠI, hỏi user**: "Component X lấy spec từ đâu? Gửi Figma link hoặc file .md?". Không được đoán.

### Bước 2 — Dùng Figma MCP (chỉ khi có Figma link)

Nếu user đưa Figma link:

1. Parse `fileKey` + `node-id` từ URL (đổi `-` thành `:` trong nodeId).
2. Gọi MCP tool `plugin-figma-figma/get_design_context` với `fileKey` + `nodeId` để lấy:
   - Screenshot tham chiếu
   - Code hint (React+Tailwind) — chỉ để tham khảo layout, **không copy-paste**
   - Design tokens (map sang token HQSOFT trong §6)
3. Nếu có spec `.md` song song thì `.md` là ground truth về **nội dung**; Figma là ground truth về **pixel / layout**.
4. Sau khi code xong, gọi `get_screenshot` lần 2 và so với page demo để check visual drift (tùy chọn, không bắt buộc).

### Bước 3 — Đọc spec & xác định anatomy

- Đọc hết spec (`.md` hoặc output từ Figma MCP).
- Liệt kê rõ: **Properties / Variants / Sizes / States / Tokens** trước khi viết code.
- Nếu spec thiếu state nào (ví dụ chỉ có `enabled`, `disabled` mà không có `hover/pressed`) → **hỏi user**, đừng tự sinh.

### Bước 4 — Kiểm tra base library

Theo thứ tự §2: DevExpress → MudBlazor → Raw. Viết ra trong reply lý do chọn để user review.

### Bước 5 — Implement component

Theo đúng pattern ở §4, §5, §6.

### Bước 6 — Tạo demo page (BẮT BUỘC)

Mỗi component Hq* mới **phải** có 1 demo page kèm theo. Xem §7.

### Bước 7 — Self-check Definition of Done

Chạy checklist ở §9 trước khi báo "done".

---

## 4. Cấu trúc folder & naming

### 4.1 Layout folder

```
Button_Segmented.Client/
├── Components/
│   ├── <Feature>/                      # 1 folder / 1 component (hoặc nhóm component liên quan)
│   │   ├── Hq<Name>.razor
│   │   ├── Hq<Name>.razor.css         # scoped CSS, bắt buộc
│   │   └── Hq<Name>Types.cs           # enum / DTO phụ (optional)
│   └── HqButtonTypes.cs                # enum / model dùng chung — có thể gom ở gốc /Components
├── Pages/
│   └── <Name>Demo.razor                # demo page, có @page "/<name>-demo"
├── _Imports.razor                      # thêm @using Button_Segmented.Client.Components.<Feature>
└── ...
Button_Segmented/
└── wwwroot/css/tokens.css              # token HQSOFT — nguồn duy nhất
```

### 4.2 Naming convention

| Thứ | Quy tắc | Ví dụ |
|---|---|---|
| Component C# class | `Hq<Name>` PascalCase | `HqButton`, `HqTextField`, `HqSegmentedControl` |
| Enum | `Hq<Name><Kind>` | `HqButtonVariant`, `HqButtonSize`, `HqTextFieldState` |
| Model / DTO | `Hq<Name>Item`, `Hq<Name>Option` | `HqSegmentedItem` |
| Namespace | `Button_Segmented.Client.Components.<Feature>` | `Components.Buttons`, `Components.TextField` |
| Root CSS class | `hq-<name>` kebab-case | `hq-btn`, `hq-text-field`, `hq-segmented-control` |
| Modifier class | `hq-<name>--<modifier>` (BEM) | `hq-btn--primary`, `hq-btn--md` |
| State class | `is-<state>` | `is-enabled`, `is-focused`, `is-disabled` |
| Element class | `hq-<name>__<element>` | `hq-text-field__label`, `hq-btn__label` |
| Demo page route | `/<name>-demo` | `/buttons-demo`, `/segmented-demo` |
| Demo page file | `<Name>Demo.razor` | `ButtonsDemo.razor` |

### 4.3 File `.razor` — yêu cầu bắt buộc

- Dòng đầu: `@namespace Button_Segmented.Client.Components.<Feature>`.
- Parameter: dùng `[Parameter]`, nullable annotation đúng (`string?`, `int?`).
- Cho phép extension qua param `Class` / `Style` (string) — sẽ được merge vào root element.
- Event: đặt tên `<Verb>` + `EventCallback` (ví dụ `Click`, `ValueChanged`).
- Không nhúng logic business — component chỉ UI.

---

## 5. Pattern override DevExpress / MudBlazor — BẮT BUỘC

### 5.1 Quy tắc chung

- **KHÔNG** dùng `!important` trừ khi bắt buộc để đè CSS built-in của DX/MudBlazor (chúng load sau và có specificity cao).
- Dùng `::deep` trong file `.razor.css` scoped để target vào class nội bộ của DX (`.dxbl-btn`, `.dxbl-text-edit`, …) hoặc MudBlazor (`.mud-button-root`, `.mud-input-root`, …).
- Khai báo **CSS variable cục bộ** (`--hq-*`) trên root element của component, sau đó dùng chúng trong rule thực — để dễ theme-swap và dễ override từ consumer qua `style="--hq-bg: red;"`.
- Không bao giờ hard-code giá trị mà token có sẵn. Dùng `var(--color-*)`, `var(--spacing-*)`, `var(--radius-*)`, `var(--text-*)`, `var(--button-*)`, `var(--segmented-*)`, `var(--badge-*)` …

### 5.2 Template `.razor` cho component wrap DevExpress

```razor
@namespace Button_Segmented.Client.Components.<Feature>

<span class="hq-<name>-host">
    <Dx<Control> CssClass="@RootCssClass"
                 style="@RootStyle"
                 Enabled="@IsEnabled"
                 ... >
        @ChildContent
    </Dx<Control>>
</span>

@code {
    [Parameter] public string? Class { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }
    // ... các Parameter khác

    private string RootCssClass => string.Join(" ",
        "hq-<name>",
        $"hq-<name>--{Variant.ToString().ToLowerInvariant()}",
        $"hq-<name>--{Size.ToString().ToLowerInvariant()}",
        $"is-{State.ToString().ToLowerInvariant()}",
        Class);

    private string? RootStyle { get; } // compose từ param override (BackgroundColor, TextColor…) nếu có
}
```

### 5.3 Template `.razor.css` — pattern override

Tham chiếu file mẫu đang hoạt động tốt:

```5:47:Button_Segmented/Button_Segmented.Client/Components/Buttons/HqButton.razor.css
::deep .hq-btn.dxbl-btn {
    --hq-bg: var(--color-navy-60);
    --hq-border: transparent;
    --hq-fg: var(--color-on-primary);
    ...
    align-items: center;
    background-color: var(--hq-bg) !important;
    border: 1px solid var(--hq-border) !important;
    border-radius: var(--hq-btn-radius);
    ...
}
```

Lưu ý:

- Ghép class `.hq-btn` + `.dxbl-btn` để tăng specificity so với CSS của DevExpress gốc.
- Gán biến cục bộ `--hq-bg`, `--hq-fg`, `--hq-border` ở block root, sau đó reference ở các rule. State (`:hover`, `.is-pressed`, `.dx-state-disabled`) chỉ cần đổi giá trị của các biến tương ứng (`--hq-bg-hover`, …) và apply.
- Disabled: set `pointer-events: none; cursor: not-allowed; opacity: 1;` (không dùng opacity để làm mờ — design token đã có màu riêng cho disabled).

### 5.4 Bắt buộc khi override

- Font: `font-family: var(--font-family-base);` — không kế thừa từ DX (DX dùng Segoe/Roboto mặc định khác).
- Letter-spacing: `var(--font-letter-spacing)` (= `-0.02em`).
- Line-height: dùng `var(--text-<scale>-lh)`.
- Border-radius: dùng token `var(--radius-*)` hoặc component-specific token.
- Transition: `.15s ease` cho color/border/background (đồng bộ với button hiện tại).

---

## 6. Design token — Source of truth

**Tuyệt đối không** hard-code giá trị. File token duy nhất:

```
Button_Segmented/wwwroot/css/tokens.css
```

### 6.1 Bảng token core (trích)

| Kind | Token | Giá trị | Dùng cho |
|---|---|---|---|
| Color primary | `--color-primary` / `--color-navy-60` | `#21367B` | Nền Primary button, accent |
| Color on-primary | `--color-on-primary` / `--color-white-100` | `#FCFCFD` | Text/icon trên Primary |
| Color surface | `--color-surface` | `#FCFCFD` | Nền card, secondary button |
| Color outline | `--color-outline` / `--color-white-60` | `#D6D6D8` | Border input, border secondary |
| Color stressful | `--color-stressful` / `--color-red-60` | `#D92332` | Error, required asterisk |
| Color useful | `--color-useful` / `--color-blue-60` | `#2D2DFE` | Focus ring input |
| Spacing | `--spacing-1x` … `--spacing-32x` | 2px … 64px | Padding, gap, margin |
| Radius | `--radius-1x` … `--radius-14x` | 2px … 28px | Border radius |
| Typography | `--text-<scale>-<size>-size` / `-lh` | — | font-size / line-height |
| Button | `--button-height-{md,sm,xs}` | 44/32/24 px | Height cố định |

### 6.2 Khi cần token mới

Nếu spec có giá trị mà `tokens.css` chưa có (ví dụ component mới cần `--stepper-*`):

1. **Thêm token vào `tokens.css`** ở section tương ứng (`/* ===== <Component> component tokens ===== */`).
2. Nếu là color mới không có trong palette → kiểm tra lại Figma: **99% là đã có** chỉ chưa biết tên. Hỏi user trước khi thêm palette mới.
3. Đặt tên theo convention: `--<component>-<slot>-<state?>` (ví dụ `--segmented-selected-bg`, `--segmented-hover-bg`).

### 6.3 Cấm kỵ

- ❌ `color: #21367B;` → ✅ `color: var(--color-primary);`
- ❌ `padding: 12px;` → ✅ `padding: var(--spacing-6x);`
- ❌ `border-radius: 8px;` → ✅ `border-radius: var(--radius-4x);`
- ❌ Dùng opacity để tạo disabled → ✅ Dùng `var(--color-surface-2)` / `var(--color-on-surface-1)` theo matrix trong spec.

---

## 7. Demo page — BẮT BUỘC

Mỗi component Hq* **mới** hoặc **sửa đáng kể** phải kèm demo page để user review visual.

### 7.1 Yêu cầu

- File: `Button_Segmented.Client/Pages/<Name>Demo.razor` + `.razor.css` scoped.
- Route: `@page "/<name>-demo"` (kebab-case).
- PageTitle: `<PageTitle>{Name} Demo</PageTitle>`.
- Cover **toàn bộ variants × sizes × states** theo matrix trong spec Figma / `.md`.
- Có section riêng cho mỗi use case chính: Interactive / Disabled / Error / Edge cases.
- Có **section đổi theme** nếu component thay đổi theo `[data-theme]` (dark/light) — không bắt buộc nhưng khuyến khích.

### 7.2 Đăng ký vào NavMenu

Thêm `DxMenuItem` vào `Button_Segmented.Client/Layout/NavMenu.razor`:

```razor
<DxMenuItem NavigateUrl="/<name>-demo"
            Text="<Name> Demo"
            CssClass="@MenuItemCssClass("/<name>-demo")"
            IconCssClass="icon icon-docs"></DxMenuItem>
```

### 7.3 Mẫu tham chiếu

Xem `ButtonsDemo.razor` (matrix biến × size × state), `SegmentedDemo.razor`, `BadgeDemo.razor`. Đừng tái phát minh — copy cấu trúc và điều chỉnh.

---

## 8. Những điều CẤM

1. ❌ **KHÔNG** hard-code màu hex, spacing px, radius px, font-size px trong CSS component. Luôn dùng token.
2. ❌ **KHÔNG** sửa `tokens.css` mà không báo user (trừ việc thêm component-specific token mới như §6.2).
3. ❌ **KHÔNG** thêm CSS global vào `site.css` cho component cụ thể — phải scoped (`.razor.css`).
4. ❌ **KHÔNG** tự ý thêm NuGet package (đặc biệt MudBlazor, Radzen…) mà không hỏi user.
5. ❌ **KHÔNG** copy code React/Tailwind từ Figma MCP output vào Blazor — dùng nó chỉ như "layout reference".
6. ❌ **KHÔNG** dùng inline style cho giá trị design (dùng class). Inline style chỉ cho API override qua `--hq-*` variable.
7. ❌ **KHÔNG** bỏ qua state nào trong spec (hover/pressed/focused/disabled/error). Nếu spec thiếu → hỏi.
8. ❌ **KHÔNG** tự chọn icon mới. Icon set HQSOFT dùng font-icon class `icon-*` (xem `wwwroot/css/icons.css`). Nếu cần icon chưa có → hỏi user.
9. ❌ **KHÔNG** dùng loading state trong button (theo Button.md §States: không có loading riêng). Nếu cần loading → hỏi user cách xử lý.
10. ❌ **KHÔNG** commit trước khi chạy `dotnet build` local và pass.

---

## 9. Definition of Done — Checklist

Trước khi coi component là "xong", agent phải tự trả lời ✅ toàn bộ:

- [ ] Đã xác định được spec nguồn (Figma link HOẶC file `.md`) — không đoán.
- [ ] Đã chọn base library đúng priority (DX → MudBlazor → Raw) và ghi rõ lý do.
- [ ] Component ở đúng folder `Components/<Feature>/Hq<Name>.razor` + scoped `.razor.css`.
- [ ] Có file `.razor.css` scoped, **không** thêm rule vào `site.css`.
- [ ] Namespace `@namespace Button_Segmented.Client.Components.<Feature>`.
- [ ] Namespace đã add vào `_Imports.razor`.
- [ ] Enum / model phụ đặt tên `Hq*`, ở file riêng hoặc `HqButtonTypes.cs`.
- [ ] Tất cả value visual (color/spacing/radius/font) dùng `var(--*)` từ `tokens.css`. Không có hex / px rời rạc.
- [ ] Cover đủ matrix: tất cả variants × sizes × states theo spec.
- [ ] Có param `Class` / `Style` cho consumer extend.
- [ ] Accessibility: `role`, `aria-*`, keyboard support (Enter/Space cho click, arrow cho segmented / tab / menu…).
- [ ] Disabled: `cursor: not-allowed`, `pointer-events: none`, dùng token disabled color (không opacity).
- [ ] Có **DemoPage** ở `Pages/<Name>Demo.razor`, route `/<name>-demo`, đã add vào `NavMenu.razor`.
- [ ] Demo page cover đủ variant × size × state.
- [ ] `dotnet build Button_Segmented.Client` pass, **zero warning mới** liên quan tới file vừa sửa.
- [ ] (Nếu có Figma link) Đã self-check visual với screenshot từ `get_screenshot` MCP hoặc chụp demo page so với Figma.

---

## 10. Khi nào phải hỏi user (không được đoán)

- Spec thiếu thông tin: state, color token mới, icon mới, accessibility requirement.
- Không tìm được component tương đương ở DevExpress **và** MudBlazor → hỏi: "OK tự viết raw?".
- Phải thêm NuGet package mới.
- Phải sửa `tokens.css` hoặc `site.css`.
- Phải thay đổi layout chung (`MainLayout`, `NavMenu`).
- Spec trong `.md` mâu thuẫn với Figma MCP output.
- Component cần JS interop (ví dụ auto-resize, scroll sync) — hỏi xem có muốn ISolateJS module không.

---

## 11. Quick reference — Mapping DevExpress ↔ Figma (sẽ mở rộng dần)

> Khi gặp component mới, cập nhật bảng này để AI kế tiếp tra nhanh.

| Figma component | Base lib | Control | Ghi chú |
|---|---|---|---|
| Button | DevExpress | `DxButton` | ✅ Đã có `HqButton` |
| Text field | DevExpress | `DxTextBox` | ✅ Đã có `HqTextField` |
| Menu (sidebar) | DevExpress | `DxMenu` | Dùng trong `NavMenu.razor` |
| Segmented control | **Composed** | Dựng trên `HqButton` | ✅ Đã có `HqSegmentedControl` (không phải DX component) |
| Badge / Dot / Counter | **MudBlazor** | `MudBadge` | ✅ Đã có `HqBadge` (wrap MudBadge, CSS override HQSOFT tokens) |
| Progress circle | Raw SVG | — | ✅ Đã có `HqProgressCircle` |
| Combo box / Select | DevExpress | `DxComboBox` | Chưa làm |
| Date picker | DevExpress | `DxDateEdit` | Chưa làm |
| Tabs | MudBlazor (fallback) | `MudTabs` | DX có `DxTabs` nhưng style khó override — test trước |
| Tooltip | DevExpress | `DxTooltip` | Chưa làm |
| Modal / Dialog | DevExpress | `DxPopup` | Chưa làm |
| Stepper | MudBlazor (fallback) | `MudStepper` | DX không có |
| Carousel | MudBlazor (fallback) | `MudCarousel` | DX không có |

---

## 12. Ngôn ngữ giao tiếp

- **File spec & comment**: Tiếng Việt (đồng bộ với `Button.md`, `TextField.md` đã có).
- **Code** (identifier, enum): Tiếng Anh.
- **Commit message**: Tiếng Anh, conventional commits (`feat(hq-button): add xs size`, `fix(hq-text-field): focus ring color`).

---

*File này là contract giữa user và AI agent. Thay đổi cần user duyệt. Cập nhật gần nhất: khi thêm component mới → cập nhật §11; khi thêm token mới → cập nhật §6.1 nếu cần.*
