CREATE DATABASE DBStudent;
GO

-- Sử dụng cơ sở dữ liệu
USE DBStudent;
GO

-- Tạo bảng SinhVien với các thuộc tính MSSV, HoTen, Khoa, Diem
CREATE TABLE SinhVien (
    MSSV CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50),
    Khoa NVARCHAR(50),
    Diem FLOAT
);
GO

-- Thêm 5 dòng dữ liệu sẵn vào bảng SinhVien
INSERT INTO SinhVien (MSSV, HoTen, Khoa, Diem)
VALUES 
('SV001', N'Nguyễn Văn A', N'Công Nghệ Thông Tin', 8.5),
('SV002', N'Trần Thị B', N'Kinh Tế', 7.2),
('SV003', N'Lê Văn C', N'Ô Tô', 6.8),
('SV004', N'Phạm Thị D', N'Ngoại Ngữ', 9.0),
('SV005', N'Vũ Văn E', N'Quản Trị Kinh Doanh', 8.0);
GO

-- Kiểm tra dữ liệu đã được thêm
SELECT * FROM SinhVien;