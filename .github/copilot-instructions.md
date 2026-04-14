# Copilot Instructions

## Project Guidelines
- Luồng triển khai UI mong muốn: lấy chỉ số từ file guidelines + Figma, định nghĩa token trong CSS trước, rồi override DevExpress theo token để build component riêng; tránh override trùng nhiều lớp gây sai lệch.
- Ưu tiên bám sát Figma và file design guidelines khi chỉnh UI, đặc biệt spacing/padding/radius của button.
- Ưu tiên triển khai theo `Button-final.md` (generate từ Figma), dùng token mới theo đó và tuân thủ quy cách đặt tên trong guidelines; không dùng `Button.md` nữa.
- Khi UI ban đầu đã sạch, chỉ cập nhật các guidelines/tokens trước và tránh thay đổi hành vi component không cần thiết.