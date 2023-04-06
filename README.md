# Project-DSiIS1

### Hướng dẫn chạy project:

#### B1 > Clone Project
- Trên Visual Studio -> Git -> Clone -> Paste đường dẫn Github -> Clone
#### B2> Kiểm tra các Package cần thiết
- Trên Visual Studio -> Project -> Manage NuGet Package -> Phần Browse -> Tìm kiếm: `Oracle.ManagedDataAccess.Core` nếu thấy chưa cài đặt -> Ấn Install
#### B3 Cài đặt CSDL và chạy trương chình
- Tạo Connection mới SQL Developer -> Chạy script SQL trong thư mục SQL.
Lưu ý 3 thông số: Username, Password, Service Name
- connectionString được lưu trong file Form1.cs, kiểm tra chính xác đúng các thông tin trước khi chạy chương trình
