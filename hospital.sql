-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 08, 2025 lúc 03:22 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `hospital`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `baohiemyte`
--

CREATE TABLE `baohiemyte` (
  `SoBHYT` varchar(10) NOT NULL,
  `NgayCap` varchar(100) NOT NULL,
  `NgayHetHan` varchar(100) NOT NULL,
  `MucHuong` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `baohiemyte`
--

INSERT INTO `baohiemyte` (`SoBHYT`, `NgayCap`, `NgayHetHan`, `MucHuong`, `TrangThaiXoa`) VALUES
('SV40987987', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987101', '01-01-2025', '31-12-2026', '80%', '0'),
('HC10987102', '01-01-2025', '31-12-2026', '100%', '0'),
('DN20987103', '01-01-2025', '31-12-2026', '100%', '0'),
('NN20987104', '01-01-2025', '31-12-2026', '100%', '0'),
('SV40987105', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987106', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987107', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987108', '01-01-2025', '31-12-2026', '80%', '0'),
('GD40987109', '01-01-2025', '31-12-2026', '80%', '0'),
('HS40987110', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987111', '01-01-2025', '31-12-2026', '80%', '0'),
('HC20987112', '01-01-2025', '31-12-2026', '100%', '0'),
('DN30987113', '01-01-2025', '31-12-2026', '95%', '0'),
('NN40987114', '01-01-2025', '31-12-2026', '80%', '0'),
('HC10987115', '01-01-2025', '31-12-2026', '100%', '0'),
('GD20987116', '01-01-2025', '31-12-2026', '100%', '0'),
('DN30987117', '01-01-2025', '31-12-2026', '95%', '0'),
('HS40987118', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987119', '01-01-2025', '31-12-2026', '80%', '0'),
('GD20987120', '01-01-2025', '31-12-2026', '100%', '0'),
('SV10987221', '01-01-2025', '31-12-2026', '80%', '0'),
('SV20987222', '01-01-2025', '31-12-2026', '80%', '0'),
('SV30987223', '01-01-2025', '31-12-2026', '80%', '0'),
('SV40987224', '01-01-2025', '31-12-2026', '80%', '0'),
('SV10987225', '01-01-2025', '31-12-2026', '80%', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benh`
--

CREATE TABLE `benh` (
  `MaBenh` varchar(10) NOT NULL,
  `TenBenh` varchar(100) NOT NULL,
  `MoTaBenh` varchar(200) DEFAULT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `benh`
--

INSERT INTO `benh` (`MaBenh`, `TenBenh`, `MoTaBenh`, `TrangThaiXoa`) VALUES
('BENH0001', 'Thiếu máu thiếu sắt', 'Thiếu máu do thiếu sắt', '0'),
('BENH0002', 'Thiếu máu tan máu', 'Thiếu máu do tan máu', '0'),
('BENH0003', 'Thiếu máu thiếu vitamin B12', 'Thiếu máu do thiếu vitamin B12/folate', '0'),
('BENH0004', 'Ung thư máu - bạch cầu', 'Bệnh lý tủy xương - ung thư máu bạch cầu', '0'),
('BENH0005', 'Lymphoma', 'Bệnh lý tủy xương - lymphoma', '0'),
('BENH0006', 'Đa u tủy', 'Bệnh lý tủy xương - đa u tủy', '0'),
('BENH0007', 'Hemophilia', 'Rối loạn đông máu - Hemophilia', '0'),
('BENH0008', 'DIC', 'Rối loạn đông máu - DIC (đông máu rải rác trong lòng mạch)', '0'),
('BENH0009', 'Xuất huyết giảm tiểu cầu miễn dịch', 'Rối loạn đông máu - xuất huyết giảm tiểu cầu miễn dịch', '0'),
('BENH0010', 'Nhiễm trùng cấp tính', 'Nhiễm trùng cấp tính - tăng bạch cầu, CRP tăng', '0'),
('BENH0011', 'Nhiễm trùng mạn tính', 'Nhiễm trùng mạn tính - tăng bạch cầu, CRP tăng', '0'),
('BENH0012', 'Đái tháo đường', 'Đái tháo đường - Glucose máu, HbA1c', '0'),
('BENH0013', 'Suy thận', 'Suy thận - Creatinine, Ure, điện giải', '0'),
('BENH0014', 'Viêm cầu thận', 'Viêm cầu thận - Creatinine, Ure, điện giải', '0'),
('BENH0015', 'Sỏi thận', 'Sỏi thận - Creatinine, Ure, điện giải', '0'),
('BENH0016', 'Viêm gan', 'Bệnh gan - viêm gan: ALT, AST, Bilirubin', '0'),
('BENH0017', 'Xơ gan', 'Bệnh gan - xơ gan: ALT, AST, Bilirubin', '0'),
('BENH0018', 'Suy gan', 'Bệnh gan - suy gan: ALT, AST, Bilirubin', '0'),
('BENH0019', 'Rối loạn mỡ máu', 'Rối loạn mỡ máu - tăng Cholesterol, LDL, Triglycerid, nguy cơ tim mạch', '0'),
('BENH0020', 'Cường giáp', 'Rối loạn nội tiết - cường giáp', '0'),
('BENH0021', 'Suy giáp', 'Rối loạn nội tiết - suy giáp', '0'),
('BENH0022', 'Hội chứng Cushing', 'Rối loạn nội tiết - hội chứng Cushing', '0'),
('BENH0023', 'Viêm phổi', 'Nhiễm khuẩn - viêm phổi', '0'),
('BENH0024', 'Nhiễm trùng tiểu', 'Nhiễm khuẩn - nhiễm trùng tiểu', '0'),
('BENH0025', 'Viêm màng não', 'Nhiễm khuẩn - viêm màng não', '0'),
('BENH0026', 'Lao', 'Nhiễm khuẩn - lao', '0'),
('BENH0027', 'Nhiễm nấm Candida', 'Nhiễm nấm - Candida', '0'),
('BENH0028', 'Nhiễm nấm Aspergillus', 'Nhiễm nấm - Aspergillus', '0'),
('BENH0029', 'Nhiễm amip', 'Nhiễm ký sinh trùng - amip', '0'),
('BENH0030', 'Nhiễm giun', 'Nhiễm ký sinh trùng - giun', '0'),
('BENH0031', 'Sốt rét', 'Nhiễm ký sinh trùng - sốt rét', '0'),
('BENH0032', 'HIV/AIDS', 'Bệnh truyền nhiễm - HIV', '0'),
('BENH0033', 'Viêm gan B', 'Bệnh truyền nhiễm - viêm gan B', '0'),
('BENH0034', 'Viêm gan C', 'Bệnh truyền nhiễm - viêm gan C', '0'),
('BENH0035', 'Giang mai', 'Bệnh truyền nhiễm - giang mai', '0'),
('BENH0036', 'Sốt xuất huyết', 'Bệnh truyền nhiễm - sốt xuất huyết', '0'),
('BENH0037', 'COVID-19', 'Bệnh truyền nhiễm - Covid-19', '0'),
('BENH0038', 'Lupus ban đỏ', 'Bệnh tự miễn - Lupus ban đỏ hệ thống', '0'),
('BENH0039', 'Viêm khớp dạng thấp', 'Bệnh tự miễn - viêm khớp dạng thấp (RF, anti-CCP, ANA)', '0'),
('BENH0040', 'Ung thư gan', 'Ung thư - marker khối u AFP', '0'),
('BENH0041', 'Ung thư tuyến tiền liệt', 'Ung thư - marker khối u PSA', '0'),
('BENH0042', 'Ung thư buồng trứng', 'Ung thư - marker khối u CA-125', '0'),
('BENH0043', 'Suy thượng thận', 'Bệnh lý nội tiết - suy thượng thận', '0'),
('BENH0044', 'Tiểu đường type 1', 'Bệnh lý nội tiết - tiểu đường type 1', '0'),
('BENH0045', 'Viêm đường tiết niệu', 'Viêm đường tiết niệu - nhiều bạch cầu, vi khuẩn trong nước tiểu', '0'),
('BENH0046', 'Protein niệu', 'Bệnh thận - protein niệu', '0'),
('BENH0047', 'Hồng cầu niệu', 'Bệnh thận - hồng cầu niệu', '0'),
('BENH0048', 'Glucose niệu', 'Tiểu đường - glucose niệu', '0'),
('BENH0049', 'Ketone niệu', 'Tiểu đường - ketone niệu', '0'),
('BENH0050', 'Ngộ độc ma túy', 'Ngộ độc, nghiện ma túy - test morphin, methamphetamine, cần sa', '0'),
('BENH0051', 'Hội chứng Down', 'Bệnh di truyền bẩm sinh - hội chứng Down', '0'),
('BENH0052', 'Thalassemia', 'Bệnh di truyền bẩm sinh - Thalassemia', '0'),
('BENH0053', 'Bệnh chuyển hóa bẩm sinh', 'Bệnh di truyền bẩm sinh - bệnh chuyển hóa', '0'),
('BENH0054', 'Đột biến gen BRCA1', 'Đột biến gen ung thư - BRCA1', '0'),
('BENH0055', 'Đột biến gen BRCA2', 'Đột biến gen ung thư - BRCA2', '0'),
('BENH0056', 'Đột biến gen KRAS', 'Đột biến gen ung thư - KRAS', '0'),
('BENH0057', 'HIV PCR', 'Bệnh truyền nhiễm bằng PCR - HIV', '0'),
('BENH0058', 'HBV PCR', 'Bệnh truyền nhiễm bằng PCR - HBV', '0'),
('BENH0059', 'SARS-CoV-2 PCR', 'Bệnh truyền nhiễm bằng PCR - SARS-CoV-2', '0'),
('BENH0060', 'Lao kháng thuốc PCR', 'Bệnh truyền nhiễm bằng PCR - lao kháng thuốc', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benhan`
--

CREATE TABLE `benhan` (
  `MaBA` varchar(10) NOT NULL,
  `SoCCCD` varchar(12) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `NgayTao` varchar(256) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benhnhan`
--

CREATE TABLE `benhnhan` (
  `SoCCCD` varchar(12) NOT NULL,
  `TenBN` varchar(100) NOT NULL,
  `SoBHYT` varchar(10) NOT NULL,
  `NgaySinh` varchar(256) NOT NULL,
  `GioiTinh` varchar(5) NOT NULL,
  `SdtBN` varchar(10) NOT NULL,
  `DiaChi` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `benhnhan`
--

INSERT INTO `benhnhan` (`SoCCCD`, `TenBN`, `SoBHYT`, `NgaySinh`, `GioiTinh`, `SdtBN`, `DiaChi`, `TrangThaiXoa`) VALUES
('079205000001', 'Phạm Đình Duy Thái', 'SV40987101', '22-04-2005', 'Nam', '0368035171', 'Hóc Môn, TP.HCM', '0'),
('079205001750', 'Lê Văn Nhật', 'SV40987987', '18-01-2005', 'Nam', '0368035171', 'Hóc Môn, TP.HCM', '0'),
('079203000001', 'Phan Thanh Bách', '', '01-01-2003', 'Nam', '0368035171', 'Quận 1, TP.HCM', '0'),
('079101000032', 'Trần Thị Ngọc', 'SV40987105', '11-11-2001', 'Nữ', '0979248703', 'Quận 5, Tp.HCM', '0'),
('079205010001', 'Nguyễn Văn An', 'SV40987106', '15-03-2005', 'Nam', '0901000001', 'Quận 1, TP.HCM', '0'),
('079205010002', 'Trần Thị Bích', 'SV40987107', '20-04-2005', 'Nữ', '0901000002', 'Quận 2, TP.HCM', '0'),
('079205010003', 'Lê Văn Cảnh', '', '10-05-2005', 'Nam', '0901000003', 'Quận 3, TP.HCM', '0'),
('079205010004', 'Phạm Thị Duyên', 'SV40987108', '25-06-2005', 'Nữ', '0901000004', 'Quận 4, TP.HCM', '0'),
('079205010005', 'Hoàng Văn Em', '', '30-07-2005', 'Nam', '0901000005', 'Quận 5, TP.HCM', '0'),
('079203010006', 'Vũ Thị Phương', 'SV40987119', '12-01-2003', 'Nữ', '0901000006', 'Quận 6, TP.HCM', '0'),
('079203010007', 'Đặng Văn Giang', 'SV40987111', '18-02-2003', 'Nam', '0901000007', 'Quận 7, TP.HCM', '0'),
('079203010008', 'Bùi Thị Hạnh', '', '22-03-2003', 'Nữ', '0901000008', 'Quận 8, TP.HCM', '0'),
('079203010009', 'Mai Văn Hùng', 'SV10987221', '28-04-2003', 'Nam', '0901000009', 'Quận 9, TP.HCM', '0'),
('079203010010', 'Trịnh Thị Kim', '', '03-05-2003', 'Nữ', '0901000010', 'Quận 10, TP.HCM', '0'),
('079195010011', 'Ngô Văn Long', 'GD40987109', '05-06-1995', 'Nam', '0901000011', 'Quận 11, TP.HCM', '0'),
('079195010012', 'Đinh Thị Lan', 'DN20987103', '15-07-1995', 'Nữ', '0901000012', 'Quận 12, TP.HCM', '0'),
('079059010013', 'Lý Văn Minh', 'HC10987102', '25-08-1959', 'Nam', '0901000013', 'Quận Gò Vấp, TP.HCM', '0'),
('079195010014', 'Vương Thị Nga', '', '08-09-1995', 'Nữ', '0901000014', 'Quận Tân Bình, TP.HCM', '0'),
('079085010015', 'Trương Văn Phúc', 'NN20987104', '18-10-1985', 'Nam', '0901000015', 'Quận Tân Phú, TP.HCM', '0'),
('079216010016', 'Hà Thị Quyên', 'HS40987110', '10-11-2016', 'Nữ', '0901000016', 'Quận Bình Thạnh, TP.HCM', '0'),
('079200010017', 'Phan Văn Sang', 'GD20987116', '20-12-2000', 'Nam', '0901000017', 'Quận Phú Nhuận, TP.HCM', '0'),
('079300010018', 'Chu Thị Thảo', '', '30-01-2000', 'Nữ', '0901000018', 'Quận Thủ Đức, TP.HCM', '0'),
('079099010019', 'Lâm Văn Thắng', 'DN30987113', '12-02-1999', 'Nam', '0901000019', 'Quận Bình Tân, TP.HCM', '0'),
('079216010020', 'Đỗ Thị Uyên', 'HS40987118', '22-03-2016', 'Nữ', '0901000020', 'Quận Củ Chi, TP.HCM', '0'),
('079202010021', 'Lưu Văn Vinh', 'DN30987117', '14-04-2002', 'Nam', '0901000021', 'Huyện Hóc Môn, TP.HCM', '0'),
('079202010022', 'Hồ Thị Xuân', '', '24-05-2002', 'Nữ', '0901000022', 'Huyện Bình Chánh, TP.HCM', '0'),
('079050010023', 'Tô Văn Yến', 'HC20987112', '04-06-1950', 'Nam', '0901000023', 'Huyện Nhà Bè, TP.HCM', '0'),
('079202010024', 'Đoàn Thị Ánh', 'SV10987224', '14-07-2002', 'Nữ', '0901000024', 'Huyện Cần Giờ, TP.HCM', '0'),
('079202010025', 'Võ Văn Bảo', 'SV10987223', '24-08-2002', 'Nam', '0901000025', 'Quận 1, TP.HCM', '0'),
('079204010026', 'Cao Thị Chi', 'SV10987222', '06-09-2004', 'Nữ', '0901000026', 'Quận 2, TP.HCM', '0'),
('079088010027', 'Kiều Văn Dũng', 'GD20987120', '16-10-1988', 'Nam', '0901000027', 'Quận 3, TP.HCM', '0'),
('079204010028', 'Lữ Thị Em', 'SV10987225', '26-11-2004', 'Nữ', '0901000028', 'Quận 4, TP.HCM', '0'),
('079204010029', 'Mã Văn Giang', 'NN40987114', '06-12-2004', 'Nam', '0901000029', 'Quận 5, TP.HCM', '0'),
('079154010030', 'Ninh Thị Hoa', 'HC10987115', '16-01-1954', 'Nữ', '0901000030', 'Quận 6, TP.HCM', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chandoan`
--

CREATE TABLE `chandoan` (
  `MaBA` varchar(10) NOT NULL,
  `MaBenh` varchar(10) NOT NULL,
  `NgayChanDoan` varchar(100) NOT NULL,
  `KetQuaDieuTri` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietdangky`
--

CREATE TABLE `chitietdangky` (
  `MaDKDV` varchar(10) NOT NULL,
  `MaDV` varchar(10) NOT NULL,
  `TienDV` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chitietdangky`
--

INSERT INTO `chitietdangky` (`MaDKDV`, `MaDV`, `TienDV`) VALUES
('DKDV000001', 'DV000002', '50000'),
('DKDV000001', 'DV000007', '30000');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietdichvu`
--

CREATE TABLE `chitietdichvu` (
  `MaDV` varchar(10) NOT NULL,
  `MaBA` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietquyen`
--

CREATE TABLE `chitietquyen` (
  `MaQuyen` varchar(10) NOT NULL,
  `MaHD` varchar(10) NOT NULL,
  `MaCN` varchar(10) NOT NULL,
  `TrangThaiKichHoat` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chitietquyen`
--

INSERT INTO `chitietquyen` (`MaQuyen`, `MaHD`, `MaCN`, `TrangThaiKichHoat`) VALUES
('QUYEN0001', 'add', 'CN0001', '1'),
('QUYEN0001', 'add', 'CN0002', '1'),
('QUYEN0001', 'add', 'CN0003', '1'),
('QUYEN0001', 'add', 'CN0004', '1'),
('QUYEN0001', 'add', 'CN0005', '1'),
('QUYEN0001', 'add', 'CN0006', '1'),
('QUYEN0001', 'delete', 'CN0001', '1'),
('QUYEN0001', 'delete', 'CN0002', '1'),
('QUYEN0001', 'delete', 'CN0003', '1'),
('QUYEN0001', 'delete', 'CN0004', '1'),
('QUYEN0001', 'delete', 'CN0005', '1'),
('QUYEN0001', 'delete', 'CN0006', '1'),
('QUYEN0001', 'edit', 'CN0001', '1'),
('QUYEN0001', 'edit', 'CN0002', '1'),
('QUYEN0001', 'edit', 'CN0003', '1'),
('QUYEN0001', 'edit', 'CN0004', '1'),
('QUYEN0001', 'edit', 'CN0005', '1'),
('QUYEN0001', 'edit', 'CN0006', '1'),
('QUYEN0001', 'view', 'CN0001', '1'),
('QUYEN0001', 'view', 'CN0002', '1'),
('QUYEN0001', 'view', 'CN0003', '1'),
('QUYEN0001', 'view', 'CN0004', '1'),
('QUYEN0001', 'view', 'CN0005', '1'),
('QUYEN0001', 'view', 'CN0006', '1');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chucnang`
--

CREATE TABLE `chucnang` (
  `MaCN` varchar(10) NOT NULL,
  `TenCN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chucnang`
--

INSERT INTO `chucnang` (`MaCN`, `TenCN`) VALUES
('CN0001', 'Thống kê'),
('CN0002', 'Quản lý bệnh nhân'),
('CN0003', 'Quản lý hồ sơ bệnh án'),
('CN0004', 'Quản lý dịch vụ'),
('CN0005', 'Quản lý nhân viên'),
('CN0006', 'Quản lý phân quyền');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dangkydichvu`
--

CREATE TABLE `dangkydichvu` (
  `MaDKDV` varchar(10) NOT NULL,
  `SoCCCD` varchar(12) NOT NULL,
  `NgayGioTaoPhieu` varchar(100) NOT NULL,
  `TrangThaiDangKy` varchar(100) NOT NULL,
  `TongChiPhi` varchar(100) NOT NULL,
  `HinhThucThanhToan` varchar(100) DEFAULT NULL,
  `MaNV` varchar(10) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `dangkydichvu`
--

INSERT INTO `dangkydichvu` (`MaDKDV`, `SoCCCD`, `NgayGioTaoPhieu`, `TrangThaiDangKy`, `TongChiPhi`, `HinhThucThanhToan`, `MaNV`, `TrangThaiXoa`) VALUES
('DKDV000001', '079205001750', '05-12-2025 13:51:20', 'Chưa hoàn thành', '80000', 'Tiền mặt', 'NV000001', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dichvu`
--

CREATE TABLE `dichvu` (
  `MaDV` varchar(10) NOT NULL,
  `TenDV` varchar(100) NOT NULL,
  `GiaDV` varchar(100) NOT NULL,
  `DuocBHYTChiTra` varchar(1) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `dichvu`
--

INSERT INTO `dichvu` (`MaDV`, `TenDV`, `GiaDV`, `DuocBHYTChiTra`, `TrangThaiXoa`) VALUES
('DV000001', 'Khám bệnh', '200000', '1', '0'),
('DV000002', 'Chụp X-Quang', '250000', '1', '0'),
('DV000003', 'Chụp CT Scan', '1150000', '0', '0'),
('DV000004', 'Chụp MRI 1 bộ phận không thuốc tương phản', '3000000', '0', '0'),
('DV000005', 'Chụp MRI 1 bộ phận có thuốc tương phản', '4700000', '0', '0'),
('DV000006', 'Chụp MRI toàn thân', '10000000', '0', '0'),
('DV000007', 'Siêu âm', '150000', '1', '0'),
('DV000008', 'Xét nghiệm huyết học', '70000', '1', '0'),
('DV000009', 'Xét nghiệm HbA1c', '130000', '0', '0'),
('DV000010', 'Xét nghiệm đường huyết', '60000', '1', '0'),
('DV000011', 'Xét nghiệm sinh hóa', '150000', '1', '0'),
('DV000012', 'Xét nghiệm vi sinh', '900000', '0', '0'),
('DV000013', 'Xét nghiệm ký sinh trùng', '120000', '1', '0'),
('DV000014', 'Xét nghiệm nước tiểu', '80000', '1', '0'),
('DV000015', 'Xét nghiệm di truyền', '1200000', '0', '0'),
('DV000016', 'Điện tâm đồ (ECG)', '120000', '1', '0'),
('DV000017', 'Điện não đồ (EEG)', '400000', '1', '0'),
('DV000018', 'Nội soi dạ dày', '800000', '1', '0'),
('DV000019', 'Nội soi tai mũi họng', '300000', '1', '0'),
('DV000020', 'Đo loãng xương', '300000', '1', '0'),
('DV000021', 'Test dị ứng', '350000', '0', '0'),
('DV000022', 'Đo thính lực', '150000', '1', '0'),
('DV000023', 'Đo nhãn áp', '100000', '1', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `donthuoc`
--

CREATE TABLE `donthuoc` (
  `MaBA` varchar(10) NOT NULL,
  `MaDP` varchar(10) NOT NULL,
  `SoLuongDP` varchar(10) NOT NULL,
  `DonViDP` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `duocpham`
--

CREATE TABLE `duocpham` (
  `MaDP` varchar(10) NOT NULL,
  `TenDP` varchar(100) NOT NULL,
  `LoaiDP` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `duocpham`
--

INSERT INTO `duocpham` (`MaDP`, `TenDP`, `LoaiDP`, `TrangThaiXoa`) VALUES
('DP000001', 'Paracetamol', 'Thuốc giảm đau - hạ sốt - kháng viêm', '0'),
('DP000002', 'Ibuprofen', 'Thuốc giảm đau - hạ sốt - kháng viêm', '0'),
('DP000003', 'Diclofenac', 'Thuốc giảm đau - hạ sốt - kháng viêm', '0'),
('DP000004', 'Naproxen', 'Thuốc giảm đau - hạ sốt - kháng viêm', '0'),
('DP000005', 'Aspirin', 'Thuốc giảm đau - hạ sốt - kháng viêm', '0'),
('DP000006', 'Penicillin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000007', 'Amoxicillin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000008', 'Ampicillin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000009', 'Ceftriaxone', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000010', 'Cefotaxime', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000011', 'Azithromycin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000012', 'Clarithromycin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000013', 'Ciprofloxacin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000014', 'Levofloxacin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000015', 'Gentamicin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000016', 'Amikacin', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000017', 'Metronidazole', 'Thuốc kháng sinh - chống nhiễm khuẩn', '0'),
('DP000018', 'Captopril', 'Thuốc tim mạch', '0'),
('DP000019', 'Enalapril', 'Thuốc tim mạch', '0'),
('DP000020', 'Lisinopril', 'Thuốc tim mạch', '0'),
('DP000021', 'Amlodipine', 'Thuốc tim mạch', '0'),
('DP000022', 'Nifedipine', 'Thuốc tim mạch', '0'),
('DP000023', 'Atenolol', 'Thuốc tim mạch', '0'),
('DP000024', 'Metoprolol', 'Thuốc tim mạch', '0'),
('DP000025', 'Propranolol', 'Thuốc tim mạch', '0'),
('DP000026', 'Furosemide', 'Thuốc tim mạch', '0'),
('DP000027', 'Spironolactone', 'Thuốc tim mạch', '0'),
('DP000028', 'Atorvastatin', 'Thuốc tim mạch', '0'),
('DP000029', 'Simvastatin', 'Thuốc tim mạch', '0'),
('DP000030', 'Clopidogrel', 'Thuốc tim mạch', '0'),
('DP000031', 'Salbutamol', 'Thuốc hô hấp', '0'),
('DP000032', 'Budesonide', 'Thuốc hô hấp', '0'),
('DP000033', 'Fluticasone', 'Thuốc hô hấp', '0'),
('DP000034', 'Acetylcysteine', 'Thuốc hô hấp', '0'),
('DP000035', 'Ambroxol', 'Thuốc hô hấp', '0'),
('DP000036', 'Omeprazole', 'Thuốc tiêu hóa', '0'),
('DP000037', 'Esomeprazole', 'Thuốc tiêu hóa', '0'),
('DP000038', 'Pantoprazole', 'Thuốc tiêu hóa', '0'),
('DP000039', 'Ranitidine', 'Thuốc tiêu hóa', '0'),
('DP000040', 'Famotidine', 'Thuốc tiêu hóa', '0'),
('DP000041', 'Domperidone', 'Thuốc tiêu hóa', '0'),
('DP000042', 'Metoclopramide', 'Thuốc tiêu hóa', '0'),
('DP000043', 'Loperamide', 'Thuốc tiêu hóa', '0'),
('DP000044', 'ORS (Oresol)', 'Thuốc tiêu hóa', '0'),
('DP000045', 'Diazepam', 'Thuốc thần kinh - tâm thần', '0'),
('DP000046', 'Lorazepam', 'Thuốc thần kinh - tâm thần', '0'),
('DP000047', 'Haloperidol', 'Thuốc thần kinh - tâm thần', '0'),
('DP000048', 'Risperidone', 'Thuốc thần kinh - tâm thần', '0'),
('DP000049', 'Amitriptyline', 'Thuốc thần kinh - tâm thần', '0'),
('DP000050', 'Fluoxetine', 'Thuốc thần kinh - tâm thần', '0'),
('DP000051', 'Sertraline', 'Thuốc thần kinh - tâm thần', '0'),
('DP000052', 'Carbamazepine', 'Thuốc thần kinh - tâm thần', '0'),
('DP000053', 'Valproate', 'Thuốc thần kinh - tâm thần', '0'),
('DP000054', 'Phenytoin', 'Thuốc thần kinh - tâm thần', '0'),
('DP000055', 'Insulin', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000056', 'Metformin', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000057', 'Gliclazide', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000058', 'Levothyroxine', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000059', 'Prednisolone', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000060', 'Dexamethasone', 'Thuốc nội tiết - chuyển hóa', '0'),
('DP000061', 'Vitamin A', 'Vitamin', '0'),
('DP000062', 'Vitamin B', 'Vitamin', '0'),
('DP000063', 'Vitamin C', 'Vitamin', '0'),
('DP000064', 'Vitamin D', 'Vitamin', '0'),
('DP000065', 'Vitamin E', 'Vitamin', '0'),
('DP000066', 'Vitamin K', 'Vitamin', '0'),
('DP000067', 'Ethinylestradiol', 'Thuốc tránh thai', '0'),
('DP000068', 'Levonorgestrel', 'Thuốc tránh thai', '0'),
('DP000069', 'Oseltamivir', 'Thuốc kháng virus', '0'),
('DP000070', 'Tenofovir', 'Thuốc kháng virus', '0'),
('DP000071', 'Lamivudine', 'Thuốc kháng virus', '0'),
('DP000072', 'Cisplatin', 'Thuốc chống ung thư', '0'),
('DP000073', 'Doxorubicin', 'Thuốc chống ung thư', '0'),
('DP000074', 'Methotrexate', 'Thuốc chống ung thư', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hanhdong`
--

CREATE TABLE `hanhdong` (
  `MaHD` varchar(10) NOT NULL,
  `TenHD` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `hanhdong`
--

INSERT INTO `hanhdong` (`MaHD`, `TenHD`) VALUES
('add', 'Thêm'),
('delete', 'Xóa'),
('edit', 'Sửa'),
('view', 'Xem');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khoa`
--

CREATE TABLE `khoa` (
  `MaKhoa` varchar(10) NOT NULL,
  `TenKhoa` varchar(100) NOT NULL,
  `SoLuong` varchar(10) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `khoa`
--

INSERT INTO `khoa` (`MaKhoa`, `TenKhoa`, `SoLuong`, `TrangThaiXoa`) VALUES
('KHOA0001', 'Khoa hành chính', '5', '0'),
('KHOA0002', 'Khoa khám bệnh', '2', '0'),
('KHOA0003', 'Khoa nội', '2', '0'),
('KHOA0004', 'Khoa ngoại', '2', '0'),
('KHOA0005', 'Khoa nhi', '4', '0'),
('KHOA0006', 'Khoa sản', '4', '0'),
('KHOA0007', 'Khoa truyền nhiễm', '3', '0'),
('KHOA0008', 'Khoa cận lâm sàng', '3', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhanvien`
--

CREATE TABLE `nhanvien` (
  `MaNV` varchar(10) NOT NULL,
  `TenNV` varchar(100) NOT NULL,
  `SdtNV` varchar(10) NOT NULL,
  `ChucVu` varchar(100) NOT NULL,
  `VaiTro` varchar(10) NOT NULL,
  `MaKhoa` varchar(10) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhanvien`
--

INSERT INTO `nhanvien` (`MaNV`, `TenNV`, `SdtNV`, `ChucVu`, `VaiTro`, `MaKhoa`, `TrangThaiXoa`) VALUES
('NV000001', 'Nguyễn Thanh Sang', '0912345678', 'Trưởng khoa', 'VT000001', 'KHOA0001', '0'),
('NV000002', 'Nguyễn Toàn Thắng', '0912345677', 'Phó khoa', 'VT000002', 'KHOA0001', '0'),
('NV000003', 'Tăng Huỳnh Quốc Khánh', '0912345676', 'Phó khoa', 'VT000003', 'KHOA0001', '0'),
('NV000004', 'Hồ Minh Tiến', '0912345675', 'Nội trú', 'VT000004', 'KHOA0001', '0'),
('NV000005', 'Phạm Đình Duy Thái', '0912345674', 'Trưởng khoa', 'VT000005', 'KHOA0002', '0'),
('NV000006', 'Lê Văn Nhất', '0912345673', 'Phó khoa', 'VT000005', 'KHOA0002', '0'),
('NV000007', 'Nguyễn Thanh Sáng', '0912345672', 'Trưởng khoa', 'VT000005', 'KHOA0003', '0'),
('NV000008', 'Nguyễn Hoàng Thanh', '0912345671', 'Phó khoa', 'VT000005', 'KHOA0003', '0'),
('NV000009', 'Cao Thành Phát', '0912345670', 'Trưởng khoa', 'VT000005', 'KHOA0004', '0'),
('NV000010', 'Nguyễn Văn Tài', '0912345601', 'Phó khoa', 'VT000005', 'KHOA0004', '0'),
('NV000011', 'Nguyễn Phát Tín', '0912345602', 'Trưởng khoa', 'VT000005', 'KHOA0005', '0'),
('NV000012', 'Mai Thành Trung', '0912345603', 'Phó khoa', 'VT000005', 'KHOA0005', '0'),
('NV000013', 'Dương Tùng Thiện', '0912345604', 'Trưởng khoa', 'VT000005', 'KHOA0006', '0'),
('NV000014', 'Nguyễn Hoàng', '0912345605', 'Phó khoa', 'VT000005', 'KHOA0006', '0'),
('NV000015', 'Quyền Chí Long', '0912345606', 'Trưởng khoa', 'VT000005', 'KHOA0007', '0'),
('NV000016', 'Nguyễn Thị Ngọc', '0912345605', 'Phó khoa', 'VT000005', 'KHOA0007', '0'),
('NV000017', 'Lê Thanh Minh', '0912345606', 'Trưởng khoa', 'VT000005', 'KHOA0008', '0'),
('NV000018', 'Nguyễn Thành Luân', '0912345605', 'Phó khoa', 'VT000005', 'KHOA0008', '0'),
('NV000019', 'Hồ Gia Bảo', '0912345606', 'Nội trú', 'VT000004', 'KHOA0001', '0'),
('NV000020', 'Lê Văn Nhật', '0912345607', 'Điều trị', 'VT000006', 'KHOA0005', '0'),
('NV000021', 'Lê Nguyễn Ngọc', '0912345608', 'Điều trị', 'VT000006', 'KHOA0005', '0'),
('NV000022', 'Nguyễn Thành', '0912345609', 'Điều trị', 'VT000006', 'KHOA0006', '0'),
('NV000023', 'Đặng Thái Tú', '0912345610', 'Điều trị', 'VT000006', 'KHOA0006', '0'),
('NV000024', 'Nguyễn Thiện Hòa', '0912345611', 'Điều trị', 'VT000006', 'KHOA0007', '0'),
('NV000025', 'Nguyễn Thiên Phú', '0912345612', 'Điều trị', 'VT000006', 'KHOA0008', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieuchidinh`
--

CREATE TABLE `phieuchidinh` (
  `MaPCD` varchar(10) NOT NULL,
  `SoCCCD` varchar(12) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `MaDV` varchar(10) NOT NULL,
  `NgayGioTaoPhieu` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `quyen`
--

CREATE TABLE `quyen` (
  `MaQuyen` varchar(10) NOT NULL,
  `TenQuyen` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `quyen`
--

INSERT INTO `quyen` (`MaQuyen`, `TenQuyen`, `TrangThaiXoa`) VALUES
('QUYEN0001', 'Quyền quản trị viên', '0'),
('QUYEN0002', 'Quyền quản lý', '0'),
('QUYEN0003', 'Quyền bác sĩ', '0'),
('QUYEN0004', 'Quyền nhân viên quầy', '0'),
('QUYEN0005', 'Quyền kế toán', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE `taikhoan` (
  `TenDangNhap` varchar(100) NOT NULL,
  `MatKhau` varchar(100) NOT NULL,
  `MaQuyen` varchar(10) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO `taikhoan` (`TenDangNhap`, `MatKhau`, `MaQuyen`, `MaNV`, `TrangThaiXoa`) VALUES
('admin', '123456', 'QUYEN0001', 'NV000001', '0'),
('quanly01', '123456', 'QUYEN0005', 'NV000002', '0'),
('quanly02', '123456', 'QUYEN0002', 'NV000003', '0'),
('nhanvienquay01', '123456', 'QUYEN0004', 'NV000004', '0'),
('bacsi01', '123456', 'QUYEN0003', 'NV000005', '0'),
('bacsi02', '123456', 'QUYEN0003', 'NV000006', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `vaitro`
--

CREATE TABLE `vaitro` (
  `MaVT` varchar(10) NOT NULL,
  `TenVT` varchar(100) NOT NULL,
  `TrangThaiXoa` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `vaitro`
--

INSERT INTO `vaitro` (`MaVT`, `TenVT`, `TrangThaiXoa`) VALUES
('VT000001', 'Quản trị viên', '0'),
('VT000002', 'Kế toán', '0'),
('VT000003', 'Quản lý', '0'),
('VT000004', 'Nhân viên quầy', '0'),
('VT000005', 'Bác sĩ', '0'),
('VT000006', 'Điều dưỡng', '0'),
('VT000007', 'Bảo vệ', '0');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
