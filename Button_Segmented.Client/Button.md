# Button

Buttons trigger actions or navigate users to a destination — they are the primary interactive element for user-initiated events.

---

## Figma properties overview

Button trong HQSOFT Design System được cấu trúc qua 5 properties chính trong Figma:

- **type** — Xác định visual hierarchy: `primary` | `secondary` | `outline` | `ghost`
- **size** — Kích thước hiển thị: `md` | `sm` | `xs`
- **state** — Trạng thái tương tác: `enabled` | `hover` | `pressed` | `disabled`
- **shape** — Hình dạng bo góc: `rounded-medium` | `rounded-full` | `none`
- **content-type** — Kiểu nội dung hiển thị: `text-and-icon` | `icon-only`

---

## Button variants

HQSOFT Design System có 4 Button variants:

- **Primary** — Dùng cho hành động chính, quan trọng nhất trên màn hình. Luôn nổi bật với nền màu `primary`.
- **Secondary** — Dùng cho hành động phụ, không cạnh tranh với Primary. Nền trắng, border nhạt.
- **Outline** — Dùng khi cần action rõ ràng nhưng ít visual weight hơn Secondary. Có border màu `primary`.
- **Ghost** — Dùng cho hành động thứ yếu hoặc trong context đã có visual nặng. Không có background, không có border.

Mỗi variant chia sẻ các properties:
- type, size, state, shape, content-type

---

## Anatomy

| No. | Element | Display | Ghi chú |
|---|---|---|---|
| 1 | Background | Required | Layer màu nằm dưới cùng, xác định visual style của từng variant |
| 2 | Leading Icon | Optional | Icon bên trái label, dùng font icon `Font Awesome 6 Pro / Light` |
| 3 | Label (Content) | Required | Text hiển thị, font `Roboto Regular 16px` (md), `14px` (sm), `12px` (xs) |
| 4 | Trailing Icon | Optional | Icon bên phải label, cùng style với Leading Icon |

> **Lưu ý:** Khi `content-type = icon-only`, chỉ có một icon duy nhất ở giữa, không có label.

---

## Properties

### Shape

Ba dạng bo góc áp dụng cho button:

| Shape | Giá trị | Mô tả |
|---|---|---|
| `rounded-medium` | Xem bảng Border radius theo Size | Dạng mặc định, dùng cho hầu hết context |
| `rounded-full` | `border-radius: 50%` | Chỉ áp dụng cho `icon-only`, tạo hình tròn hoàn toàn |
| `none` | `border-radius: 0` | Chỉ dùng cho `ghost` type |

### Size

Ba kích thước với chiều cao cố định:

| Size | Height | Icon size | Font size | Padding | Border Radius |
|---|---|---|---|---|---|
| `md` (Medium) | 44px | 20px | 16px | 12px (top/bottom) · 12px (left/right) | 12px (token: `--radius/theme/md`) |
| `sm` (Small) | 32px | 16px | 14px | 8px (top/bottom) · 10px (left/right) | 8px (token: `--radius/theme/sm`) |
| `xs` (Extra Small) | 24px | 12px | 12px | 4px (top/bottom) · 8px (left/right) | 8px (token: `--radius/theme/sm`) |

Khoảng cách giữa icon và label: `gap: 8px` (token: `--spacing/4x`).

### Type (Visual Variant)

| Type | Background | Text color | Border |
|---|---|---|---|
| `primary` | `--color/primary/primary` (#21367B) | `--color/primary/on-primary` (#FCFCFD) | Không có |
| `secondary` | `--color/surface/surface` (#FCFCFD) | `--color/surface/on-surface` (#0F1014) | `1px solid --color/outline/outline` (#D6D6D8) |
| `outline` | Transparent | `--color/primary/primary` (#21367B) | `1px solid --color/primary/primary` |
| `ghost` | Transparent | `--color/primary/primary` (#21367B) | Không có |

### Content Type

| Content Type | Mô tả |
|---|---|
| `text-and-icon` | Hiển thị cả leading icon, label text, và trailing icon (icon là optional) |
| `icon-only` | Chỉ hiển thị 1 icon ở giữa, không có label |

---

## States & Statuses

### States

States được tạo ra bởi tương tác của người dùng, áp dụng cho tất cả 4 variants:

| State | Mô tả | Visual change |
|---|---|---|
| `enabled` | Trạng thái mặc định, sẵn sàng tương tác | Màu sắc theo spec của từng type |
| `hover` | Người dùng rê chuột lên button | Background tối hơn ~8% so với `enabled` |
| `pressed` | Người dùng đang nhấn giữ | Background tối hơn ~16% so với `enabled` |

### Statuses

Statuses được quyết định bởi hệ thống hoặc dữ liệu, không phải do tương tác:

| Status | Mô tả | Visual change |
|---|---|---|
| `disabled` | Button không thể tương tác | Dùng màu riêng từ disabled token system (không phải opacity), cursor: not-allowed |

> **Không có `loading` state riêng biệt trong component này.** Nếu cần loading, cân nhắc thay thế label bằng spinner icon thông qua slot swap.

### State matrix — Primary

| | enabled | hover | pressed | disabled |
|---|---|---|---|---|
| Background | `#21367B` | `#1A2B63` (tối hơn) | `#142050` (tối hơn nhiều) | `#DFDFE1` (`--color/surface/surface-2`) |
| Text / Icon | `#FCFCFD` | `#FCFCFD` | `#FCFCFD` | `#6E6F71` (`--color/surface/on-surface-1`) |
| Border | — | — | — | — |

### State matrix — Secondary

| | enabled | hover | pressed | disabled |
|---|---|---|---|---|
| Background | `#FCFCFD` | `#F0F0F2` (nhạt hơn) | `#E3E3E7` (đậm hơn) | `#DFDFE1` (`--color/surface/surface-2`) |
| Border | `#D6D6D8` | `#D6D6D8` | `#D6D6D8` | `#D6D6D8` |
| Text / Icon | `#0F1014` | `#0F1014` | `#0F1014` | `#6E6F71` (`--color/surface/on-surface-1`) |

### State matrix — Outline

| | enabled | hover | pressed | disabled |
|---|---|---|---|---|
| Background | Transparent | `rgba(33,54,123,0.06)` | `rgba(33,54,123,0.12)` | Transparent |
| Border | `#21367B` | `#21367B` | `#21367B` | `#C3C3C5` (`--color/surface/on-surface-3`) |
| Text / Icon | `#21367B` | `#21367B` | `#21367B` | `#9D9DA0` (`--color/surface/on-surface-2`) |

### State matrix — Ghost

| | enabled | hover | pressed | disabled |
|---|---|---|---|---|
| Background | Transparent | `rgba(33,54,123,0.06)` | `rgba(33,54,123,0.12)` | Transparent |
| Border | — | — | — | — |
| Text / Icon | `#21367B` | `#21367B` | `#21367B` | `#9D9DA0` (`--color/surface/on-surface-2`) |

---

## Specification

### Button height

Chiều cao của button là fixed theo từng size — không dùng `hug content`:

| Size | Height |
|---|---|
| md | 44px |
| sm | 32px |
| xs | 24px |

> **⚠️ Attention for designers**
> Trong Figma, height được set cố định (`fixed height`), KHÔNG dùng `hug content` dù có thể trông giống nhau. Việc này đảm bảo button không thay đổi chiều cao khi font thay đổi hoặc khi không có label.

### Minimum width

Button không có `min-width` cứng, nhưng khi `content-type = text-and-icon`:

- Width tự co dãn theo content (hug width)
- Không nên để label quá ngắn (dưới 2 ký tự) vì sẽ mất cân đối với padding

Khi `content-type = icon-only`:
- Width = Height (button là hình vuông hoặc tròn)
- `md`: 44×44px · `sm`: 32×32px · `xs`: 24×24px

### Spacing giữa icon và label

`gap: 8px` (token: `--spacing/4x`) — áp dụng đồng nhất ở tất cả size.

### Border radius

#### Theo Shape

| Shape | Border Radius |
|---|---|
| `rounded-medium` | Xem bảng theo Size bên dưới |
| `rounded-full` | 9999px hoặc `50%` |
| `none` | 0px |

#### Theo Size (áp dụng cho `rounded-medium`)

| Size | Border Radius | Token |
|---|---|---|
| `md` | 12px | `--radius/theme/md` |
| `sm` | 8px | `--radius/theme/sm` |
| `xs` | 8px | `--radius/theme/sm` |

> **Lưu ý:** `rounded-full` và `none` không phụ thuộc vào size. Chỉ shape `rounded-medium` có border radius khác nhau theo size.

---

## Button group

Button group là cách sắp xếp nhiều button trong cùng một hàng ngang. HQSOFT Design System hỗ trợ các cấu hình:

| Quantity | Mô tả |
|---|---|
| 1 | Single button |
| 2 | Hai button cạnh nhau |
| 3–10 | Group với số lượng button tùy biến |

> Button group sử dụng `auto layout` với `gap` đồng nhất. Không nên mix size trong cùng một group.

---

## Customization

### Label content

Label text có thể thay đổi nội dung tự do. Giữ nguyên font token `roboto/title/md/400` (Roboto Regular) — không thay đổi weight hay style của text.

### Icon swap

Cả leading và trailing icon đều là slot (`Icon swap`) có thể thay bằng bất kỳ icon nào từ thư viện Font Awesome 6 Pro. Quy tắc:

- Icon size phải khớp với size của button: `md` → 20px · `sm` → 16px · `xs` → 12px
- Không dùng icon filled/solid trong button — chỉ dùng style `Light` (weight 300)

### Button width

Mặc định button co theo content (`hug width`). Có thể kéo dài thành `full width` (100% container) khi cần — thường dùng cho CTA trong mobile layout.

---

## Usage guidelines

### Dùng Primary button cho hành động quan trọng nhất

Mỗi màn hình chỉ nên có **một** Primary button. Primary button thu hút sự chú ý cao nhất — nếu dùng nhiều hơn một, hierarchy bị phá vỡ và người dùng không biết nên làm gì trước.

✅ Dùng Primary cho "Submit", "Save", "Confirm" — hành động không thể đảo ngược hoặc quan trọng nhất.
❌ Không dùng hai Primary button cạnh nhau trong cùng một context.

### Kết hợp Primary và Secondary hoặc Ghost cho paired actions

Khi có hai hành động song song (ví dụ: "Cancel" và "Confirm"), dùng:
- Primary cho hành động chính
- Secondary hoặc Ghost cho hành động phụ/từ chối

✅ `[Ghost: Cancel]` + `[Primary: Confirm]`
❌ `[Primary: Cancel]` + `[Primary: Confirm]`

### Chọn shape phù hợp với ngữ cảnh

- Dùng `rounded-medium` trong hầu hết interface — form, toolbar, modal, card actions
- Dùng `rounded-full` cho FAB (Floating Action Button) hoặc icon button standalone
- Dùng `none` (ghost) trong navigation, inline action trong text, breadcrumb

### Dùng icon để tăng khả năng nhận dạng, không phải để trang trí

Icon nên bổ nghĩa cho label — người dùng nhận ra hành động nhanh hơn khi có icon phù hợp. Không dùng icon chỉ để button trông đẹp hơn.

✅ `[download-icon] Export` — icon bổ nghĩa cho hành động
❌ `[star-icon] Submit` — icon không liên quan đến hành động

### Không disable button nếu có cách báo lỗi inline

`disabled` state nên dùng khi button thực sự không khả dụng về mặt business logic (ví dụ: chưa đủ quyền). Nếu form chưa điền đủ, hãy để button active và hiện validation error khi submit — điều này giúp người dùng biết tại sao không thể tiếp tục.

✅ Disable khi: chưa chọn item, chưa đăng nhập, đang loading
❌ Disable khi: form validation chưa pass (hãy để user submit rồi show error)

---

## Design tokens tham chiếu

| Token | Giá trị | Dùng cho |
|---|---|---|
| `--color/primary/primary` | #21367B | Primary background |
| `--color/primary/on-primary` | #FCFCFD | Text/icon trên Primary |
| `--color/surface/surface` | #FCFCFD | Secondary background |
| `--color/surface/on-surface` | #0F1014 | Text/icon trên Secondary |
| `--color/outline/outline` | #D6D6D8 | Secondary border |
| `--color/surface/surface-2` | #DFDFE1 | **Disabled background** (Primary, Secondary) |
| `--color/surface/on-surface-1` | #6E6F71 | **Disabled text/icon** (Primary, Secondary) |
| `--color/surface/on-surface-2` | #9D9DA0 | **Disabled text/icon** (Outline, Ghost) |
| `--color/surface/on-surface-3` | #C3C3C5 | **Disabled border** (Outline) |
| `--radius/theme/md` | 12px | Border radius — `rounded-medium` shape, size `md` |
| `--radius/theme/sm` | 8px | Border radius — `rounded-medium` shape, size `sm` và `xs` |
| `--spacing/4x` | 8px | Gap giữa icon và label |
| `--spacing/6x` | 12px | Padding inside button (md) |

---

*Tài liệu này thuộc HQSOFT Design System — Xspire. Cập nhật theo Figma file: `5wO57mOv5R62xRh618Soly`, node: `937-3229`.*
