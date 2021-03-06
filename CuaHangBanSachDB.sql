﻿CREATE DATABASE QuanLyCuaHangBanSach
GO

USE QuanLyCuaHangBanSach
GO

CREATE TABLE Sach
(
	MaSach CHAR(5) NOT NULL PRIMARY KEY,
	TenSach NVARCHAR(50) NOT NULL,
	TacGia NVARCHAR(100) NULL,
	NhaXuatBan NVARCHAR(100) NULL,
	SoLuong INT NOT NULL,
	GiaTienBan MONEY NOT NULL 
)
GO

CREATE TABLE KhachHang
(
	SDT_KH CHAR(10) NOT NULL PRIMARY KEY,
	TenKH NVARCHAR(50) NOT NULL,
	NgaySinh DATE NULL,
	Email CHAR(20) NULL,
	TongGiaoDich MONEY NOT NULL DEFAULT(0.0)
)
GO


CREATE TABLE HoaDon
(
	MaHD INT NOT NULL PRIMARY KEY,
	NgayLap DATETIME NOT NULL,
	KhachHang CHAR(10) NULL, -- SĐT
	HinhThucThanhToan BIT NOT NULL, -- 0: Tiền mặt, 1: Trả thẻ
	TongGiaTriHD MONEY NOT NULL,
	Tax money null,
)
GO

CREATE TABLE ChiTietHoaDon
(
	HoaDon INT NOT NULL,
	MaSachMua CHAR(5) NOT NULL,
	SoLuongMua INT NOT NULL,
	TongTien MONEY NOT NULL,

	PRIMARY KEY(HoaDon,MaSachMua)
)
GO

CREATE TABLE PhieuNhapSach
(
	MaPN INT NOT NULL PRIMARY KEY,
	NgayNhap DATETIME NOT NULL,
	TongGiaTriNhap MONEY NOT NULL
)
GO

CREATE TABLE ChiTietPhieuNhap
(
	PhieuNhap INT NOT NULL,
	MaSachNhap CHAR(5) NOT NULL,
	SoLuongNhap INT NOT NULL,
	GiaTienNhap SMALLMONEY NOT NULL,
	TongTien MONEY NOT NULL,

	PRIMARY KEY(PhieuNhap,MaSachNhap)
)
GO

CREATE TABLE QuanLyChiTieu
(
	Thang SMALLINT NOT NULL,
	Nam SMALLINT NOT NULL,
	TienDien MONEY NOT NULL,
	TienNuoc MONEY NOT NULL,
	TienLuongNhanVien MONEY NOT NULL,
	TienInternet MONEY NOT NULL,
	TienThueMatBang MONEY NOT NULL,
	ChiPhiKhac MONEY NULL,
	TongChiTieu MONEY NOT NULL,
	
	PRIMARY KEY(Thang,Nam)
)

CREATE TABLE ThongKeNgay
(
	NgayThongKe DATE NOT NULL PRIMARY KEY,
	TongTienNhapSach MONEY NOT NULL,
	DoanhThu MONEY NOT NULL,
	LoiNhuan MONEY NOT NULL
)
GO

CREATE TABLE ThongKeThang
(
	Thang SMALLINT NOT NULL,
	Nam SMALLINT NOT NULL,
	DoanhThu MONEY NOT NULL, -- Tổng doanh thu các ngày trong tháng
	TongChiTieu MONEY NOT NULL, -- Tổng phí chi tiêu
	LoiNhuan MONEY NOT NULL,

	PRIMARY KEY(Thang,Nam)
)
GO

CREATE TABLE ThongKeQuy
(
	Quy SMALLINT NOT NULL,
	Nam SMALLINT NOT NULL,
	DoanhThu MONEY NOT NULL,
	TongChiTieu MONEY NOT NULL,
	LoiNhuan MONEY NOT NULL,

	PRIMARY KEY(Quy,Nam)
)
GO

CREATE TABLE ThongKeNam
(
	Nam SMALLINT NOT NULL PRIMARY KEY,
	DoanhThu MONEY NOT NULL,
	TongChiTieu MONEY NOT NULL,
	LoiNhuan MONEY NOT NULL,
)
GO

CREATE TABLE Users
(
	UserName CHAR(20) NOT NULL PRIMARY KEY,
	Pass CHAR(20) NOT NULL,
	PhanQuyen BIT NOT NULL -- 0: Nhân viên, 1: Quản lý
)

INSERT INTO dbo.Users( UserName, Pass, PhanQuyen )
VALUES  ( 'nhanvien', 'nhanvien', 0 )
INSERT INTO dbo.Users( UserName, Pass, PhanQuyen )
VALUES  ( 'quanly', 'quanly', 1 )
GO