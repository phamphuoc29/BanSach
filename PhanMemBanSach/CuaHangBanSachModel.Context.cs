﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace PhanMemBanSach
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class QuanLyCuaHangBanSachEntities : DbContext
{
    public QuanLyCuaHangBanSachEntities()
        : base("name=QuanLyCuaHangBanSachEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<PhieuNhapSach> PhieuNhapSaches { get; set; }

    public virtual DbSet<QuanLyChiTieu> QuanLyChiTieux { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<ThongKeNam> ThongKeNams { get; set; }

    public virtual DbSet<ThongKeNgay> ThongKeNgays { get; set; }

    public virtual DbSet<ThongKeQuy> ThongKeQuys { get; set; }

    public virtual DbSet<ThongKeThang> ThongKeThangs { get; set; }

}

}

