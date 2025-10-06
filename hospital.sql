-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 06, 2025 at 11:56 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `bao_hiem_y_te`
--

CREATE TABLE `bao_hiem_y_te` (
  `SoBHYT` varchar(15) NOT NULL,
  `NgayCap` varchar(256) NOT NULL,
  `NgayHetHan` varchar(256) NOT NULL,
  `MucHuong` varchar(100) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bao_hiem_y_te`
--

INSERT INTO `bao_hiem_y_te` (`SoBHYT`, `NgayCap`, `NgayHetHan`, `MucHuong`, `TrangThaiXoa`) VALUES
('DN19512345', '2023-01-01', '2028-01-01', '95%', 0),
('SV38098765', '2022-05-12', '2027-05-12', '80%', 0),
('HC11024680', '2021-09-10', '2026-09-10', '100%', 0),
('DN47567890', '2020-03-20', '2025-03-20', '100%', 0),
('SV39524681', '2024-07-15', '2029-07-15', '95%', 0);

-- --------------------------------------------------------

--
-- Table structure for table `benh`
--

CREATE TABLE `benh` (
  `MaBenh` varchar(10) NOT NULL,
  `TenBanh` varchar(100) NOT NULL,
  `MTaBenh` varchar(256) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `benh`
--

INSERT INTO `benh` (`MaBenh`, `TenBanh`, `MTaBenh`, `TrangThaiXoa`) VALUES
('BENH0001', 'Thiếu máu', 'Thiếu sắt, tan máu, thiếu vitamin B12/folate', 0),
('BENH0002', 'Đái tháo đường', 'Glucose máu, HbA1c cao', 0),
('BENH0003', 'Suy thận', 'Viêm cầu thận, sỏi thận', 0),
('BENH0004', 'Viêm gan', 'Viêm gan virus, xơ gan', 0),
('BENH0005', 'Viêm phổi', 'Nhiễm khuẩn phổi cấp tính', 0);

-- --------------------------------------------------------

--
-- Table structure for table `benh_an`
--

CREATE TABLE `benh_an` (
  `MaBA` varchar(10) NOT NULL,
  `SoCCCD` varchar(12) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `NgayTao` varchar(256) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `benh_an`
--

INSERT INTO `benh_an` (`MaBA`, `SoCCCD`, `MaNV`, `NgayTao`, `TrangThaiXoa`) VALUES
('BA0001', '001234567890', 'NV0001', '2023-09-10', 0),
('BA0002', '002345678901', 'NV0001', '2023-09-12', 0),
('BA0003', '003456789012', 'NV0001', '2023-09-15', 0),
('BA0004', '004567890123', 'NV0001', '2023-09-20', 0),
('BA0005', '005678901234', 'NV0001', '2023-09-25', 0);

-- --------------------------------------------------------

--
-- Table structure for table `benh_nhan`
--

CREATE TABLE `benh_nhan` (
  `SoCCCD` varchar(12) NOT NULL,
  `TenBN` varchar(100) NOT NULL,
  `SoBHYT` varchar(15) NOT NULL,
  `NgaySinh` varchar(256) NOT NULL,
  `GioiTinh` varchar(5) NOT NULL,
  `SdtBN` varchar(10) NOT NULL,
  `DiaChi` varchar(100) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `benh_nhan`
--

INSERT INTO `benh_nhan` (`SoCCCD`, `TenBN`, `SoBHYT`, `NgaySinh`, `GioiTinh`, `SdtBN`, `DiaChi`, `TrangThaiXoa`) VALUES
('001234567890', 'Nguyen Van A', 'DN19512345', '1990-05-10', 'Nam', '0912345678', 'Ha Noi', 0),
('002345678901', 'Tran Thi B', 'SV38098765', '1995-11-20', 'Nu', '0909876543', 'Hai Phong', 0),
('003456789012', 'Le Van C', 'HC11024680', '1980-02-15', 'Nam', '0934567890', 'Da Nang', 0),
('004567890123', 'Pham Thi D', 'DN47567890', '2000-07-25', 'Nu', '0961234567', 'HCM', 0),
('005678901234', 'Hoang Van E', 'SV39524681', '1988-09-30', 'Nam', '0987654321', 'Hue', 0);

-- --------------------------------------------------------

--
-- Table structure for table `chan_doan`
--

CREATE TABLE `chan_doan` (
  `MaBA` varchar(10) NOT NULL,
  `MaBenh` varchar(10) NOT NULL,
  `NgayChuanDoan` varchar(256) NOT NULL,
  `KQuaDieuTri` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chan_doan`
--

INSERT INTO `chan_doan` (`MaBA`, `MaBenh`, `NgayChuanDoan`, `KQuaDieuTri`) VALUES
('BA0001', 'BENH0001', '2023-09-11', 'Đang điều trị'),
('BA0002', 'BENH0002', '2023-09-13', 'Ổn định'),
('BA0003', 'BENH0003', '2023-09-16', 'Cần theo dõi'),
('BA0004', 'BENH0004', '2023-09-21', 'Khỏi'),
('BA0005', 'BENH0005', '2023-09-26', 'Đang điều trị');

-- --------------------------------------------------------

--
-- Table structure for table `chi_tiet_dang_ky`
--

CREATE TABLE `chi_tiet_dang_ky` (
  `MaDKDV` varchar(10) NOT NULL,
  `MaDV` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chi_tiet_dang_ky`
--

INSERT INTO `chi_tiet_dang_ky` (`MaDKDV`, `MaDV`) VALUES
('DK0001', 'DV000001'),
('DK0002', 'DV000001'),
('DK0003', 'DV000001'),
('DK0004', 'DV000001'),
('DK0005', 'DV000001'),
('DK0001', 'DV000002'),
('DK0002', 'DV000002'),
('DK0003', 'DV000002'),
('DK0004', 'DV000002'),
('DK0005', 'DV000002');

-- --------------------------------------------------------

--
-- Table structure for table `chi_tiet_dich_vu`
--

CREATE TABLE `chi_tiet_dich_vu` (
  `MaDV` varchar(10) NOT NULL,
  `MaBA` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chi_tiet_dich_vu`
--

INSERT INTO `chi_tiet_dich_vu` (`MaDV`, `MaBA`) VALUES
('DV000001', 'BA0001'),
('DV000001', 'BA0002'),
('DV000001', 'BA0003'),
('DV000001', 'BA0004'),
('DV000001', 'BA0005'),
('DV000002', 'BA0001'),
('DV000002', 'BA0002'),
('DV000002', 'BA0003'),
('DV000002', 'BA0004'),
('DV000002', 'BA0005');

-- --------------------------------------------------------

--
-- Table structure for table `chi_tiet_quyen`
--

CREATE TABLE `chi_tiet_quyen` (
  `MaQuyen` varchar(10) NOT NULL,
  `MaHD` varchar(10) NOT NULL,
  `MaCN` varchar(10) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chi_tiet_quyen`
--

INSERT INTO `chi_tiet_quyen` (`MaQuyen`, `MaHD`, `MaCN`, `TrangThaiXoa`) VALUES
('QUYEN0001', 'HD01', 'CN0001', 1),
('QUYEN0001', 'HD04', 'CN0002', 1),
('QUYEN0002', 'HD04', 'CN0002', 1),
('QUYEN0004', 'HD04', 'CN0003', 1),
('QUYEN0005', 'HD01', 'CN0005', 1);

-- --------------------------------------------------------

--
-- Table structure for table `chuc_nang`
--

CREATE TABLE `chuc_nang` (
  `MaCN` varchar(10) NOT NULL,
  `TenCN` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chuc_nang`
--

INSERT INTO `chuc_nang` (`MaCN`, `TenCN`) VALUES
('CN0001', 'Quan ly benh nhan'),
('CN0002', 'Quan ly benh an'),
('CN0003', 'Quan ly hoa don'),
('CN0004', 'Thong ke'),
('CN0005', 'Quan ly nhan vien');

-- --------------------------------------------------------

--
-- Table structure for table `dich_vu`
--

CREATE TABLE `dich_vu` (
  `MaDV` varchar(10) NOT NULL,
  `TenDV` varchar(100) NOT NULL,
  `GiaDV` varchar(100) NOT NULL,
  `BHYTtra` varchar(1) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dich_vu`
--

INSERT INTO `dich_vu` (`MaDV`, `TenDV`, `GiaDV`, `BHYTtra`, `TrangThaiXoa`) VALUES
('DV000001', 'Chụp X-Quang', '250000', '0', 0),
('DV000002', 'Chụp CT Scan', '1150000', '0', 0),
('DV000003', 'Chụp MRI toàn thân', '10000000', '0', 0),
('DV000004', 'Siêu âm', '150000', '0', 0),
('DV000005', 'Xét nghiệm HbA1c', '130000', '0', 0);

-- --------------------------------------------------------

--
-- Table structure for table `don_thuoc`
--

CREATE TABLE `don_thuoc` (
  `MaBA` varchar(10) NOT NULL,
  `MaDP` varchar(100) NOT NULL,
  `SLuongDP` varchar(100) NOT NULL,
  `DviDP` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `don_thuoc`
--

INSERT INTO `don_thuoc` (`MaBA`, `MaDP`, `SLuongDP`, `DviDP`) VALUES
('BA0001', 'DP000001', '10', 'vien'),
('BA0002', 'DP000005', '20', 'vien'),
('BA0003', 'DP000003', '15', 'vien'),
('BA0004', 'DP000002', '30', 'vien'),
('BA0005', 'DP000004', '5', 'vien');

-- --------------------------------------------------------

--
-- Table structure for table `hanh_dong`
--

CREATE TABLE `hanh_dong` (
  `MaHD` varchar(10) NOT NULL,
  `TenHD` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hanh_dong`
--

INSERT INTO `hanh_dong` (`MaHD`, `TenHD`) VALUES
('HD01', 'them'),
('HD02', 'xoa'),
('HD03', 'sua'),
('HD04', 'xem'),
('HD05', 'in');

-- --------------------------------------------------------

--
-- Table structure for table `khoa`
--

CREATE TABLE `khoa` (
  `MaKhoa` varchar(10) NOT NULL,
  `TenKhoa` varchar(100) NOT NULL,
  `SoLuong` varchar(10) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `khoa`
--

INSERT INTO `khoa` (`MaKhoa`, `TenKhoa`, `SoLuong`, `TrangThaiXoa`) VALUES
('KHOA0001', 'Hanh chinh', '0', 0),
('KHOA0002', 'Kham benh', '0', 0),
('KHOA0003', 'Noi', '0', 0),
('KHOA0004', 'Ngoai', '0', 0),
('KHOA0005', 'Nhi', '0', 0);

-- --------------------------------------------------------

--
-- Table structure for table `nhan_vien`
--

CREATE TABLE `nhan_vien` (
  `MaNV` varchar(10) NOT NULL,
  `TenNV` varchar(100) NOT NULL,
  `SdtNV` varchar(10) NOT NULL,
  `ChucVu` varchar(100) NOT NULL,
  `VaiTro` varchar(100) NOT NULL,
  `MaKhoa` varchar(10) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nhan_vien`
--

INSERT INTO `nhan_vien` (`MaNV`, `TenNV`, `SdtNV`, `ChucVu`, `VaiTro`, `MaKhoa`, `TrangThaiXoa`) VALUES
('NV0001', 'Nguyen Van Bac', '0911122233', 'Bac si', 'Bac si', 'KHOA0002', 0),
('NV0002', 'Tran Thi Lan', '0922233344', 'Dieu duong', 'Dieu duong', 'KHOA0003', 0),
('NV0003', 'Le Van Hung', '0933344455', 'Truong khoa', 'Quan tri vien', 'KHOA0001', 0),
('NV0004', 'Pham Thi Hoa', '0944455566', 'Noi tru', 'Nhan vien quay', 'KHOA0005', 0),
('NV0005', 'Hoang Van Nam', '0955566677', 'Ke toan', 'Ke toan', 'KHOA0001', 0);

-- --------------------------------------------------------

--
-- Table structure for table `phieu_dang_ky_dich_vu`
--

CREATE TABLE `phieu_dang_ky_dich_vu` (
  `MaDKDV` varchar(10) NOT NULL,
  `SoCCCD` varchar(12) NOT NULL,
  `NgayTao` varchar(256) NOT NULL,
  `TTDangKy` varchar(100) NOT NULL,
  `TongChiPhi` varchar(100) NOT NULL,
  `HinhThucThanhToan` varchar(100) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `phieu_dang_ky_dich_vu`
--

INSERT INTO `phieu_dang_ky_dich_vu` (`MaDKDV`, `SoCCCD`, `NgayTao`, `TTDangKy`, `TongChiPhi`, `HinhThucThanhToan`, `MaNV`, `TrangThaiXoa`) VALUES
('DK0001', '001234567890', '2023-09-11', 'Hoàn thành', '500000', 'Tien mat', 'NV0005', 0),
('DK0002', '002345678901', '2023-09-13', 'Hoàn thành', '2000000', 'Chuyen khoan', 'NV0005', 0),
('DK0003', '003456789012', '2023-09-16', 'Hoàn thành', '1000000', 'Tien mat', 'NV0005', 0),
('DK0004', '004567890123', '2023-09-21', 'Hoàn thành', '3000000', 'The', 'NV0005', 0),
('DK0005', '005678901234', '2023-09-26', 'Hoàn thành', '700000', 'Tien mat', 'NV0005', 0);

-- --------------------------------------------------------

--
-- Table structure for table `quyen`
--

CREATE TABLE `quyen` (
  `MaQuyen` varchar(10) NOT NULL,
  `TenQuyen` varchar(100) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `quyen`
--

INSERT INTO `quyen` (`MaQuyen`, `TenQuyen`, `TrangThaiXoa`) VALUES
('QUYEN0001', 'Admin', 0),
('QUYEN0002', 'Bac si', 0),
('QUYEN0003', 'Dieu duong', 0),
('QUYEN0004', 'Ke toan', 0),
('QUYEN0005', 'Nhan vien quay', 0);

-- --------------------------------------------------------

--
-- Table structure for table `tai_khoan`
--

CREATE TABLE `tai_khoan` (
  `TenDangNhap` varchar(100) NOT NULL,
  `MatKhau` varchar(100) NOT NULL,
  `MaQuyen` varchar(10) NOT NULL,
  `MaNV` varchar(10) NOT NULL,
  `TrangThaiXoa` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tai_khoan`
--

INSERT INTO `tai_khoan` (`TenDangNhap`, `MatKhau`, `MaQuyen`, `MaNV`, `TrangThaiXoa`) VALUES
('admin', '123456', 'QUYEN0001', 'NV0003', 0),
('bs1', '123456', 'QUYEN0002', 'NV0001', 0),
('dd1', '123456', 'QUYEN0003', 'NV0002', 0),
('kt1', '123456', 'QUYEN0004', 'NV0005', 0),
('nvq1', '123456', 'QUYEN0005', 'NV0004', 0);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
