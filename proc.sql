Use QuanLyCuaHangBanSach
go

create proc UpdateBook
@maSach char(5), @tenSach nvarchar(50), @tacGia nvarchar(100), @NXB nvarchar(100), @sl int, @giaTien money
as
begin
	update Sach
	set TenSach = @tenSach, TacGia = @tacGia, NhaXuatBan = @NXB, SoLuong = @sl, GiaTienBan = @giaTien
	where MaSach = @maSach
end
go

create proc DeleteBook
@maSach char(5)
as
begin
	delete from Sach
	where MaSach = @maSach
end
go

create proc SearchBook
@string nvarchar(100)
as
begin
	select*
	from Sach
	where TenSach like '%'+@string+'%' or
		  TacGia like '%'+@string+'%'
end
go

create proc ViewBooks
as
begin
	select*
	from Sach
end
go

create proc insertChiTieu
@thang int, @nam int, @tienDien money, @tienNuoc money, @tienLuong money, @tienInternet money,
@tienThueNha money, @khac money
as
begin
	declare @tong money
	set @tong = @tienDien+@tienNuoc+@tienLuong+@tienInternet+@tienThueNha+@khac

	insert into QuanLyChiTieu(Thang,Nam,TienDien,TienNuoc,TienLuongNhanVien,TienInternet,TienThueMatBang,ChiPhiKhac,TongChiTieu)
	values(@thang,@nam,@tienDien,@tienNuoc,@tienLuong,@tienInternet,@tienThueNha,@khac,@tong)
end
go

create proc ViewChiTieu
@thang int, @nam int
as
begin
select*
	from QuanLyChiTieu
	where Thang = @thang and @nam = Nam
end
go
