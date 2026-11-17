# Báo cáo Tuần 1 - Hệ thống thư viện đặt mượn sách phân tán

- **Sinh viên thực hiện:** Phạm Bảo Lâm
- **MSSV:** dtc245200287
- **Lớp:** CNTTK23E
- **Đề tài:** 20 – Hệ thống thư viện đặt mượn sách phân tán

## Nội dung hoàn thành Tuần 1:
1. **Khởi tạo kiến trúc giải pháp:** Xây dựng cấu trúc Solution gồm 4 project thành phần: `Library.Api`, `Library.Client`, `Library.Shared`, `Library.Worker`.
2. **Hạ tầng Docker:** Thiết lập `docker-compose.yml`, `Dockerfile.api`, `Dockerfile.worker` tích hợp PostgreSQL và RabbitMQ để xử lý bất đồng bộ.
3. **Cấu hình môi trường:** Thiết lập chuỗi kết nối cơ sở dữ liệu và biến môi trường giao tiếp giữa các dịch vụ.
