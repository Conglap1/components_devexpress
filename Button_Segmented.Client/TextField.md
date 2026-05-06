# Text field

Text field is the primary single-line input for collecting short freeform text values. This spec follows the HQSOFT Design System Figma page for the web text field component and focuses on the `md` size first.

---

## Figma properties overview

Text field trong HQSOFT Design System được cấu trúc qua các properties chính trong Figma:

- **size** — Kích thước hiển thị: `md`
- **state** — Trạng thái tương tác: `enabled` | `focused` | `filled` | `error` | `disabled`
- **has-label** — Hiển thị label phía trên field
- **has-required** — Hiển thị dấu `*` bắt buộc
- **has-label-icon** — Hiển thị icon cạnh label
- **has-leading-icon** — Hiển thị icon bên trái trong field
- **swap-leading** — Thay icon leading bằng icon khác
- **has-trailing-icon** — Hiển thị icon bên phải trong field
- **swap-trailing** — Thay icon trailing bằng icon khác
- **has-supporting-text** — Hiển thị supporting text bên dưới field
- **has-prefix** — Hiển thị prefix trước value/placeholder
- **has-placeholder** — Hiển thị placeholder khi field rỗng

---

## Anatomy

| No. | Element | Display | Ghi chú |
|---|---|---|---|
| 1 | Label | Optional | Nằm phía trên field, dùng cho định danh ngữ nghĩa của input |
| 2 | Required asterisk | Optional | Hiển thị ngay sau label khi field bắt buộc |
| 3 | Label icon | Optional | Icon nhỏ đi cùng label, dùng cho thông tin bổ sung |
| 4 | Input container | Required | Khung bao quanh nội dung input |
| 5 | Leading icon | Optional | Icon bên trái value/placeholder, dùng khi cần nhấn mạnh ngữ cảnh |
| 6 | Prefix | Optional | Text hoặc icon đứng trước nội dung nhập, ví dụ unit/currency |
| 7 | Value / Placeholder | Required | Nội dung nhập hoặc placeholder khi rỗng |
| 8 | Trailing icon | Optional | Icon bên phải, thường dùng cho action phụ hoặc trạng thái |
| 9 | Supporting text | Optional | Dòng mô tả, helper text hoặc error message bên dưới field |

> **Lưu ý:** `has-label`, `has-leading-icon`, `has-trailing-icon`, `has-supporting-text`, `has-prefix`, `has-placeholder` là các toggle độc lập. Không giả định rằng có label thì phải có supporting text, hoặc có leading icon thì phải có trailing icon.

---

## Scope

### Phase 1

Bản đầu tiên chỉ triển khai size `md` theo ảnh Figma.

### Phạm vi content

Text field cần hỗ trợ đầy đủ các cấu hình sau:

- label + required
- supporting text
- placeholder
- leading icon
- trailing icon
- label icon
- prefix

---

## Properties

### Size

| Size | Height | Border radius | Icon size | Horizontal padding |
|---|---|---|---|---|
| `md` | 44px | 12px | 20px | 12px |

### Layout rules

- Field body cao cố định `44px`.
- Icon trong field dùng khung vuông `20x20px`.
- Label và supporting text nằm ngoài field body.
- Supporting text nằm bên dưới field với khoảng cách gọn, đúng nhịp layout của Figma.

### Content rules

- Placeholder chỉ hiển thị khi field rỗng.
- Khi có value, text nhập thay thế placeholder.
- `filled` là trạng thái có value, không phải một visual variant tách biệt hoàn toàn khỏi nội dung.
- Prefix nằm trước value nhưng sau leading icon nếu cả hai cùng bật.
- Trailing icon luôn nằm ở mép phải của field body.

---

## States & Statuses

### States

| State | Mô tả | Visual change |
|---|---|---|
| `enabled` | Trạng thái mặc định | Border neutral, nền trắng/surface, text màu chuẩn |
| `focused` | Field đang active | Border đổi sang màu focus blue |
| `filled` | Field có value | Hiển thị value rõ ràng, placeholder ẩn |
| `error` | Có lỗi validation | Border đỏ, supporting text đỏ |
| `disabled` | Không tương tác | Màu muted cho border, text, icon và background |

### State matrix

| | enabled | focused | filled | error | disabled |
|---|---|---|---|---|---|
| Background | `#FCFCFD` | `#FCFCFD` | `#FCFCFD` | `#FCFCFD` | Muted surface token |
| Border | `#D6D6D8` | `#2D2DFE` | `#D6D6D8` | `#D92332` | Muted border token |
| Value text | `#0F1014` | `#0F1014` | `#0F1014` | `#0F1014` | Muted text token |
| Placeholder | `#C3C3C5` | `#C3C3C5` | — | `#C3C3C5` | Muted placeholder token |
| Supporting text | `#6E6F71` | `#6E6F71` | `#6E6F71` | `#D92332` | Muted support token |
| Required asterisk | `#D92332` | `#D92332` | `#D92332` | `#D92332` | `#D92332` |

> **Note:** `focused` border color is the semantic useful blue shown in Figma. `error` uses the semantic stressful red shown in Figma.

---

## Specification

### Label

Label luôn đặt phía trên field body. Khi `has-required = true`, dấu `*` xuất hiện ngay sau label và dùng màu error red.

### Supporting text

Supporting text đặt bên dưới field body. Dùng cho helper text hoặc validation message. Khi ở state `error`, supporting text phải đổi sang màu đỏ và có thể thay nội dung thành message lỗi.

### Icons

- `label icon` là icon nhỏ đứng cạnh label.
- `leading icon` và `trailing icon` là icon nằm trong field body.
- `swap-leading` và `swap-trailing` là cơ chế thay icon slot theo context.
- Icon should stay visually centered inside the 20px icon slot.

### Prefix

Prefix là phần bổ sung đứng trước value/placeholder. Dùng cho các trường hợp như unit, code, hoặc currency. Prefix không thay thế leading icon; hai phần này có thể cùng tồn tại nếu design cần.

### Select

Figma page Text field có thêm component `Select` / `Select (Combobox)` trong cùng family. Đây là một control riêng dùng cho lựa chọn từ danh sách có sẵn, nhưng vẫn kế thừa label, supporting text và các quy tắc về layout của Text field.

### Width

Field co giãn theo container. Ở Figma, chiều rộng mẫu đang thể hiện một form width chuẩn, nhưng component không nên khóa cứng theo pixel ngoài constraint của parent.

---

## Usage guidelines

### Dùng label khi trường nhập cần ngữ nghĩa rõ ràng

Không nên chỉ dựa vào placeholder để mô tả ý nghĩa của field. Placeholder biến mất khi user bắt đầu nhập và không đủ rõ cho accessibility.

### Dùng supporting text cho helper hoặc lỗi

Nếu có ràng buộc dữ liệu, ưu tiên hiển thị helper/error text bên dưới field thay vì chỉ đổi màu field.

### Không lạm dụng icon

Leading/trailing icon chỉ nên dùng khi nó giúp nhận diện hoặc thao tác nhanh hơn. Nếu icon không thêm thông tin, bỏ nó ra để giữ form sạch.

### Giữ phase 1 gọn

Bản đầu tiên chỉ nên chốt `md` trước. Khi spec này ổn, có thể mở rộng thêm các size khác hoặc các pattern nâng cao như textarea và search field.
