insert into ChucVuNhanViens(machucvunv, tenchucvu,HSPC) values
('tp',N'Trưởng phòng, Trưởng khoa',0.45),
('pp',N'Phó phòng, Phó khoa',0.35),
('tbm',N'Trưởng bộ môn',0.25),
('nv',N'Nhân viên',0.0);

insert into ChuyenNganhs(MaChuyenNganh,TenChuyenNganh) values
('cntt',N'Công nghệ thông tin'),
('toan',N'Toán'),
('hoahoc',N'Hóa học'),
('tth',N'Chính trị học'),
('kt',N'Kế toán'),
('ck',N'Cơ khí'),
('dientu',N'Điện tử'),
('sinhhoc',N'Sinh học'),
('nl',N'Nhiệt lạnh');

insert into PhongBans(MaPhongBan,TenPhongBan,DiaChi,sdt_PhongBan) values
('daotao',N'Đào tạo',N'Lầu 2 nhà A','029348472'),
('ketoan',N'Kế toán',N'Lầu 3 nhà D','089372732'),
('cntt',N'Công nghệ thông tin',N'Lầu 1 nhà H','083283223'),
('xaydung',N'Xây dựng',N'phòng A1.1 nhà A','08329834');

insert into TrinhDoHocVans(MaTrinhDoHocVan,TenTrinhDo,HeSoBac) values
('gs',N'Giáo sư',6.2),
('pgs',N'Phó giáo sư',4.4),
('ts',N'Tiến sỹ',3.0),
('ths',N'Thạc sỹ',2.67),
('ks',N'Kỹ sư',2.34);

insert into LuongA1GV values
('2.34'),
('2.67'),
('3'),
('3.33'),
('3.66'),
('3.99'),
('4.32'),
('4.65'),
('4.98');

insert into LuongA31GS values
('6.2'),
('6.56'),
('6.92'),
('7.28'),
('7.64'),
('8');
insert into LuongA21PGS values
('4.4'),
('4.74'),
('5.08'),
('5.42'),
('5.76'),
('6.1'),
('6.44'),
('6.78');
insert into NhanViens(MaNhanVien,MatKhau,TrangThai)values(
'admin','21232F297A57A5A743894A0E4A801FC3',1
);
