
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2017 17:03:50
-- Generated from EDMX file: G:\HOC TAP\DO AN 3\CODE\QuanLyNhanSu\QuanLyNhanSu\Models\QuanLyNhanSuModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLyNhanSu];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__LuanChuyen__MaNhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LuanChuyenNhanVien] DROP CONSTRAINT [FK__LuanChuyen__MaNhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK__NhanVien__MaChuyenNganh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK__NhanVien__MaChuyenNganh];
GO
IF OBJECT_ID(N'[dbo].[FK__NhanVien__MaHopDong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK__NhanVien__MaHopDong];
GO
IF OBJECT_ID(N'[dbo].[FK__NhanVien__MaPhongBan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK__NhanVien__MaPhongBan];
GO
IF OBJECT_ID(N'[dbo].[FK__ThoiViec__MaNhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ThoiViec] DROP CONSTRAINT [FK__ThoiViec__MaNhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK__Thuong__MaNhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KhenThuong] DROP CONSTRAINT [FK__Thuong__MaNhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_CapNhatLuong_Luong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CapNhatLuong] DROP CONSTRAINT [FK_CapNhatLuong_Luong];
GO
IF OBJECT_ID(N'[dbo].[FK_CapNhatTrinhDoHocVan_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CapNhatTrinhDoHocVan] DROP CONSTRAINT [FK_CapNhatTrinhDoHocVan_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_ChiTietLuong_Luong]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietLuong] DROP CONSTRAINT [FK_ChiTietLuong_Luong];
GO
IF OBJECT_ID(N'[dbo].[FK_KyLuat_KyLuat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KyLuat] DROP CONSTRAINT [FK_KyLuat_KyLuat];
GO
IF OBJECT_ID(N'[dbo].[FK_Luong_NhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Luong] DROP CONSTRAINT [FK_Luong_NhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_NhanVien_ChucVuNhanVien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK_NhanVien_ChucVuNhanVien];
GO
IF OBJECT_ID(N'[dbo].[FK_NhanVien_TrinhDoHocVan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanVien] DROP CONSTRAINT [FK_NhanVien_TrinhDoHocVan];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CapNhatLuong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CapNhatLuong];
GO
IF OBJECT_ID(N'[dbo].[CapNhatTrinhDoHocVan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CapNhatTrinhDoHocVan];
GO
IF OBJECT_ID(N'[dbo].[ChiTietLuong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietLuong];
GO
IF OBJECT_ID(N'[dbo].[ChucVuNhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChucVuNhanVien];
GO
IF OBJECT_ID(N'[dbo].[ChuyenNganh]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChuyenNganh];
GO
IF OBJECT_ID(N'[dbo].[HopDong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HopDong];
GO
IF OBJECT_ID(N'[dbo].[KhenThuong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhenThuong];
GO
IF OBJECT_ID(N'[dbo].[KyLuat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KyLuat];
GO
IF OBJECT_ID(N'[dbo].[LuanChuyenNhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LuanChuyenNhanVien];
GO
IF OBJECT_ID(N'[dbo].[Luong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Luong];
GO
IF OBJECT_ID(N'[dbo].[LuongA1GV]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LuongA1GV];
GO
IF OBJECT_ID(N'[dbo].[LuongA21PGS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LuongA21PGS];
GO
IF OBJECT_ID(N'[dbo].[LuongA31GS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LuongA31GS];
GO
IF OBJECT_ID(N'[dbo].[NhanVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhanVien];
GO
IF OBJECT_ID(N'[dbo].[PhongBan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhongBan];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[ThoiViec]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThoiViec];
GO
IF OBJECT_ID(N'[dbo].[TrinhDoHocVan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrinhDoHocVan];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CapNhatLuongs'
CREATE TABLE [dbo].[CapNhatLuongs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [MaNhanVien] varchar(30)  NOT NULL,
    [LuongHienTai] int  NOT NULL,
    [LuongSauCapNhat] int  NOT NULL,
    [BHXH] float  NULL,
    [BHYT] float  NULL,
    [BHTN] float  NULL,
    [PhuCap] float  NULL,
    [ThueThuNhap] float  NULL,
    [NgayCapNhat] datetime  NULL,
    [HeSoLuong] float  NULL
);
GO

-- Creating table 'CapNhatTrinhDoHocVans'
CREATE TABLE [dbo].[CapNhatTrinhDoHocVans] (
    [MaCapNhat] int IDENTITY(1,1) NOT NULL,
    [MaNhanVien] varchar(30)  NOT NULL,
    [NgayCapNhat] datetime  NOT NULL,
    [MaTrinhDoTruoc] varchar(30)  NOT NULL,
    [MaTrinhDoCapNhat] varchar(30)  NOT NULL
);
GO

-- Creating table 'ChiTietLuongs'
CREATE TABLE [dbo].[ChiTietLuongs] (
    [MaChiTietBangLuong] varchar(30)  NOT NULL,
    [MaNhanVien] varchar(30)  NOT NULL,
    [LuongCoBan] float  NOT NULL,
    [BHXH] float  NULL,
    [BHYT] float  NULL,
    [BHTN] float  NULL,
    [PhuCap] float  NULL,
    [ThueThuNhap] float  NULL,
    [TienThuong] int  NULL,
    [TienPhat] int  NULL,
    [NgayNhanLuong] datetime  NOT NULL,
    [TongTienLuong] varchar(30)  NULL
);
GO

-- Creating table 'ChucVuNhanViens'
CREATE TABLE [dbo].[ChucVuNhanViens] (
    [MaChucVuNV] varchar(30)  NOT NULL,
    [TenChucVu] nvarchar(50)  NOT NULL,
    [HSPC] float  NULL
);
GO

-- Creating table 'ChuyenNganhs'
CREATE TABLE [dbo].[ChuyenNganhs] (
    [MaChuyenNganh] varchar(30)  NOT NULL,
    [TenChuyenNganh] nvarchar(50)  NULL
);
GO

-- Creating table 'HopDongs'
CREATE TABLE [dbo].[HopDongs] (
    [MaHopDong] varchar(30)  NOT NULL,
    [LoaiHopDong] nvarchar(50)  NULL,
    [NgayBatDau] datetime  NULL,
    [NgayKetThuc] datetime  NULL,
    [GhiChu] nvarchar(max)  NULL
);
GO

-- Creating table 'KhenThuongs'
CREATE TABLE [dbo].[KhenThuongs] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [ThangThuong] datetime  NOT NULL,
    [LyDo] nvarchar(max)  NULL,
    [TienThuong] int  NULL
);
GO

-- Creating table 'KyLuats'
CREATE TABLE [dbo].[KyLuats] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [LyDo] nvarchar(max)  NULL,
    [ThangKiLuat] datetime  NOT NULL,
    [TienKyLuat] int  NULL
);
GO

-- Creating table 'LuanChuyenNhanViens'
CREATE TABLE [dbo].[LuanChuyenNhanViens] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [NgayChuyen] datetime  NOT NULL,
    [LyDoChuyen] nvarchar(max)  NULL,
    [PhongBanChuyen] varchar(30)  NULL,
    [PhongBanDen] varchar(30)  NULL
);
GO

-- Creating table 'Luongs'
CREATE TABLE [dbo].[Luongs] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [LuongToiThieu] int  NOT NULL,
    [HeSoLuong] float  NULL,
    [BHXH] float  NULL,
    [BHYT] float  NULL,
    [BHTN] float  NULL,
    [PhuCap] float  NULL,
    [ThueThuNhap] float  NULL
);
GO

-- Creating table 'NhanViens'
CREATE TABLE [dbo].[NhanViens] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [MatKhau] nvarchar(100)  NOT NULL,
    [HoTen] nvarchar(50)  NULL,
    [NgaySinh] datetime  NULL,
    [QueQuan] nvarchar(100)  NULL,
    [HinhAnh] nvarchar(max)  NULL,
    [GioiTinh] int  NULL,
    [DanToc] nvarchar(10)  NULL,
    [sdt_NhanVien] varchar(11)  NULL,
    [MaChucVuNV] varchar(30)  NULL,
    [TrangThai] bit  NOT NULL,
    [MaPhongBan] varchar(30)  NULL,
    [MaHopDong] varchar(30)  NULL,
    [MaChuyenNganh] varchar(30)  NULL,
    [MaTrinhDoHocVan] varchar(30)  NULL,
    [CMND] varchar(50)  NULL
);
GO

-- Creating table 'PhongBans'
CREATE TABLE [dbo].[PhongBans] (
    [MaPhongBan] varchar(30)  NOT NULL,
    [TenPhongBan] nvarchar(50)  NOT NULL,
    [DiaChi] nvarchar(50)  NULL,
    [sdt_PhongBan] varchar(11)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'ThoiViecs'
CREATE TABLE [dbo].[ThoiViecs] (
    [MaNhanVien] varchar(30)  NOT NULL,
    [Lydo] nvarchar(max)  NULL,
    [NgayThoiViec] datetime  NOT NULL
);
GO

-- Creating table 'TrinhDoHocVans'
CREATE TABLE [dbo].[TrinhDoHocVans] (
    [MaTrinhDoHocVan] varchar(30)  NOT NULL,
    [TenTrinhDo] nvarchar(max)  NOT NULL,
    [HeSoBac] float  NULL
);
GO

-- Creating table 'LuongA1GV'
CREATE TABLE [dbo].[LuongA1GV] (
    [BacLuong] int IDENTITY(1,1) NOT NULL,
    [HeSo] float  NULL
);
GO

-- Creating table 'LuongA21PGS'
CREATE TABLE [dbo].[LuongA21PGS] (
    [BacLuong] int IDENTITY(1,1) NOT NULL,
    [HeSo] float  NULL
);
GO

-- Creating table 'LuongA31GS'
CREATE TABLE [dbo].[LuongA31GS] (
    [BacLuong] int IDENTITY(1,1) NOT NULL,
    [HeSo] float  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'CapNhatLuongs'
ALTER TABLE [dbo].[CapNhatLuongs]
ADD CONSTRAINT [PK_CapNhatLuongs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [MaCapNhat] in table 'CapNhatTrinhDoHocVans'
ALTER TABLE [dbo].[CapNhatTrinhDoHocVans]
ADD CONSTRAINT [PK_CapNhatTrinhDoHocVans]
    PRIMARY KEY CLUSTERED ([MaCapNhat] ASC);
GO

-- Creating primary key on [MaChiTietBangLuong], [MaNhanVien] in table 'ChiTietLuongs'
ALTER TABLE [dbo].[ChiTietLuongs]
ADD CONSTRAINT [PK_ChiTietLuongs]
    PRIMARY KEY CLUSTERED ([MaChiTietBangLuong], [MaNhanVien] ASC);
GO

-- Creating primary key on [MaChucVuNV] in table 'ChucVuNhanViens'
ALTER TABLE [dbo].[ChucVuNhanViens]
ADD CONSTRAINT [PK_ChucVuNhanViens]
    PRIMARY KEY CLUSTERED ([MaChucVuNV] ASC);
GO

-- Creating primary key on [MaChuyenNganh] in table 'ChuyenNganhs'
ALTER TABLE [dbo].[ChuyenNganhs]
ADD CONSTRAINT [PK_ChuyenNganhs]
    PRIMARY KEY CLUSTERED ([MaChuyenNganh] ASC);
GO

-- Creating primary key on [MaHopDong] in table 'HopDongs'
ALTER TABLE [dbo].[HopDongs]
ADD CONSTRAINT [PK_HopDongs]
    PRIMARY KEY CLUSTERED ([MaHopDong] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'KhenThuongs'
ALTER TABLE [dbo].[KhenThuongs]
ADD CONSTRAINT [PK_KhenThuongs]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'KyLuats'
ALTER TABLE [dbo].[KyLuats]
ADD CONSTRAINT [PK_KyLuats]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [MaNhanVien], [id] in table 'LuanChuyenNhanViens'
ALTER TABLE [dbo].[LuanChuyenNhanViens]
ADD CONSTRAINT [PK_LuanChuyenNhanViens]
    PRIMARY KEY CLUSTERED ([MaNhanVien], [id] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'Luongs'
ALTER TABLE [dbo].[Luongs]
ADD CONSTRAINT [PK_Luongs]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [PK_NhanViens]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [MaPhongBan] in table 'PhongBans'
ALTER TABLE [dbo].[PhongBans]
ADD CONSTRAINT [PK_PhongBans]
    PRIMARY KEY CLUSTERED ([MaPhongBan] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [MaNhanVien] in table 'ThoiViecs'
ALTER TABLE [dbo].[ThoiViecs]
ADD CONSTRAINT [PK_ThoiViecs]
    PRIMARY KEY CLUSTERED ([MaNhanVien] ASC);
GO

-- Creating primary key on [MaTrinhDoHocVan] in table 'TrinhDoHocVans'
ALTER TABLE [dbo].[TrinhDoHocVans]
ADD CONSTRAINT [PK_TrinhDoHocVans]
    PRIMARY KEY CLUSTERED ([MaTrinhDoHocVan] ASC);
GO

-- Creating primary key on [BacLuong] in table 'LuongA1GV'
ALTER TABLE [dbo].[LuongA1GV]
ADD CONSTRAINT [PK_LuongA1GV]
    PRIMARY KEY CLUSTERED ([BacLuong] ASC);
GO

-- Creating primary key on [BacLuong] in table 'LuongA21PGS'
ALTER TABLE [dbo].[LuongA21PGS]
ADD CONSTRAINT [PK_LuongA21PGS]
    PRIMARY KEY CLUSTERED ([BacLuong] ASC);
GO

-- Creating primary key on [BacLuong] in table 'LuongA31GS'
ALTER TABLE [dbo].[LuongA31GS]
ADD CONSTRAINT [PK_LuongA31GS]
    PRIMARY KEY CLUSTERED ([BacLuong] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaNhanVien] in table 'CapNhatLuongs'
ALTER TABLE [dbo].[CapNhatLuongs]
ADD CONSTRAINT [FK_CapNhatLuong_Luong]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[Luongs]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CapNhatLuong_Luong'
CREATE INDEX [IX_FK_CapNhatLuong_Luong]
ON [dbo].[CapNhatLuongs]
    ([MaNhanVien]);
GO

-- Creating foreign key on [MaNhanVien] in table 'CapNhatTrinhDoHocVans'
ALTER TABLE [dbo].[CapNhatTrinhDoHocVans]
ADD CONSTRAINT [FK_CapNhatTrinhDoHocVan_NhanVien]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CapNhatTrinhDoHocVan_NhanVien'
CREATE INDEX [IX_FK_CapNhatTrinhDoHocVan_NhanVien]
ON [dbo].[CapNhatTrinhDoHocVans]
    ([MaNhanVien]);
GO

-- Creating foreign key on [MaNhanVien] in table 'ChiTietLuongs'
ALTER TABLE [dbo].[ChiTietLuongs]
ADD CONSTRAINT [FK_ChiTietLuong_Luong]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[Luongs]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChiTietLuong_Luong'
CREATE INDEX [IX_FK_ChiTietLuong_Luong]
ON [dbo].[ChiTietLuongs]
    ([MaNhanVien]);
GO

-- Creating foreign key on [MaChucVuNV] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK_NhanVien_ChucVuNhanVien]
    FOREIGN KEY ([MaChucVuNV])
    REFERENCES [dbo].[ChucVuNhanViens]
        ([MaChucVuNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhanVien_ChucVuNhanVien'
CREATE INDEX [IX_FK_NhanVien_ChucVuNhanVien]
ON [dbo].[NhanViens]
    ([MaChucVuNV]);
GO

-- Creating foreign key on [MaChuyenNganh] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK__NhanVien__MaChuyenNganh]
    FOREIGN KEY ([MaChuyenNganh])
    REFERENCES [dbo].[ChuyenNganhs]
        ([MaChuyenNganh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NhanVien__MaChuyenNganh'
CREATE INDEX [IX_FK__NhanVien__MaChuyenNganh]
ON [dbo].[NhanViens]
    ([MaChuyenNganh]);
GO

-- Creating foreign key on [MaHopDong] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK__NhanVien__MaHopDong]
    FOREIGN KEY ([MaHopDong])
    REFERENCES [dbo].[HopDongs]
        ([MaHopDong])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NhanVien__MaHopDong'
CREATE INDEX [IX_FK__NhanVien__MaHopDong]
ON [dbo].[NhanViens]
    ([MaHopDong]);
GO

-- Creating foreign key on [MaNhanVien] in table 'KhenThuongs'
ALTER TABLE [dbo].[KhenThuongs]
ADD CONSTRAINT [FK__Thuong__MaNhanVien]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaNhanVien] in table 'KyLuats'
ALTER TABLE [dbo].[KyLuats]
ADD CONSTRAINT [FK_KyLuat_KyLuat]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaNhanVien] in table 'LuanChuyenNhanViens'
ALTER TABLE [dbo].[LuanChuyenNhanViens]
ADD CONSTRAINT [FK__LuanChuyen__MaNhanVien]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaNhanVien] in table 'Luongs'
ALTER TABLE [dbo].[Luongs]
ADD CONSTRAINT [FK_Luong_NhanVien]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaPhongBan] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK__NhanVien__MaPhongBan]
    FOREIGN KEY ([MaPhongBan])
    REFERENCES [dbo].[PhongBans]
        ([MaPhongBan])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NhanVien__MaPhongBan'
CREATE INDEX [IX_FK__NhanVien__MaPhongBan]
ON [dbo].[NhanViens]
    ([MaPhongBan]);
GO

-- Creating foreign key on [MaNhanVien] in table 'ThoiViecs'
ALTER TABLE [dbo].[ThoiViecs]
ADD CONSTRAINT [FK__ThoiViec__MaNhanVien]
    FOREIGN KEY ([MaNhanVien])
    REFERENCES [dbo].[NhanViens]
        ([MaNhanVien])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaTrinhDoHocVan] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK_NhanVien_TrinhDoHocVan]
    FOREIGN KEY ([MaTrinhDoHocVan])
    REFERENCES [dbo].[TrinhDoHocVans]
        ([MaTrinhDoHocVan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NhanVien_TrinhDoHocVan'
CREATE INDEX [IX_FK_NhanVien_TrinhDoHocVan]
ON [dbo].[NhanViens]
    ([MaTrinhDoHocVan]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------