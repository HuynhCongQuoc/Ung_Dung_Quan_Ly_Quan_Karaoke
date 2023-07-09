 create database QL_KARAOKE
 go
 use QL_KARAOKE 
 go


create table CHITIETHD (
   MAHD                 char(10)             not null,
   MAMH                 char(10)             not null,
   SL                   int                  null,
   DONGIA               money                null,
   constraint PK_CHITIETHD primary key (MAHD, MAMH)
)


create table CHITIETPN (
   MAHANG               char(10)             not null,
   MAPN                 char(10)             not null,
   SL                   int                  null,
   DONGIA               money                null,
   constraint PK_CHITIETPN primary key (MAHANG, MAPN)
)
go

create table HANGHOA (
   MAHANG               char(10)             not null,
   MANCC                char(10)             not null,
   TENHH                nvarchar(30)             null,
   DVT                   nvarchar(10)             null,
   DONGIA               money                null,
   constraint PK_HANGHOA primary key nonclustered (MAHANG)
)
create table HOADON (
   MAHD                 char(10)             not null,
   MAKH                 char(10)             not null,
   MAPHIEU              char(10)             ,
   MANV                 char(10)             not null,
   NGAYTT               datetime             null,
   TONGTG               int                  null,
   TIENPHONG            money                null,
   TIENDV               money                null,
   TONGTIEN             money                null,
   constraint PK_HOADON primary key nonclustered (MAHD)
)

create table KHACHHANG (
   MAKH                 char(10)             not null,
   TEN                  nvarchar(30)             null,
   SDT                  char(10)             null,
   DIACHI                nvarchar(100)             null,
   TONGTIEN             money                null,
   constraint PK_KHACHHANG primary key nonclustered (MAKH)
)
create table LOAIPHONG (
   MALOAI               char(10)             not null,
   TENLOAIPH             nvarchar(10)             null,
   GIATHUE              money                null,
   constraint PK_LOAIPHONG primary key nonclustered (MALOAI)
)

create table MATHANG (
   MAMH                 char(10)             not null,
   TENMH                 nvarchar(30)             null,
   DVT                   nvarchar(10)             null,
   SLTON                int               null,
   GIABAN               money                null,
   constraint PK_MATHANG primary key nonclustered (MAMH)
)

create table NHACC (
   MANCC                char(10)             not null,
   TENNCC                nvarchar(50)             null,
   DIACHI                nvarchar(50)             null,
   SDT                  char(10)             null,
   constraint PK_NHACC primary key nonclustered (MANCC)
)

create table NHANVIEN (
   MANV                 char(10)             not null,
   TENDN                char(20)            unique,
   MATKHAU              char(20)             null,
   TENNV                 nvarchar(30)             null,
   DIACHI                nvarchar(50)             null,
   SDT                  char(10)             null,
   CMT                  char(10)             null,
   GIOITINH             char(10)             null,
   NGAYSINH             datetime             null,
   NGAYVL               datetime             null,
   CHUCVU                nvarchar(20) CHECK (CHUCVU IN (N'Nhân viên', N'Admin')),
   constraint PK_NHANVIEN primary key nonclustered (MANV)
)
create table PHIEUNHAP (
   MAPN                 char(10)             not null,
   MANV                 char(10)             null,
   NGAYNHAP             datetime             null,
   TONGTIEN             money                null,
   constraint PK_PHIEUNHAP primary key nonclustered (MAPN)
)

create table PHIEUTHUE (
   MAPHIEU              char(10)             not null,
   MAPHONG              char(10)             not null,
   NGAYDAT              datetime             null,
   GIODEN               time,
   GIODI                time,
   constraint PK_PHIEUTHUE primary key nonclustered (MAPHIEU)
)

create table PHONG (
   MAPHONG              char(10)             not null,
   MALOAI               char(10)             not null,
   TINHTRANG            nvarchar(10)             null,
   TENPH                nvarchar(20)             null,
   constraint PK_PHONG primary key nonclustered (MAPHONG)
)
alter table HANGHOA
   add constraint FK_HANGHOA_RELATIONS_NHACC foreign key (MANCC)
      references NHACC (MANCC)
go
alter table CHITIETHD
   add constraint FK_CHITIETH_CHITIETHD_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table CHITIETHD
   add constraint FK_CHITIETH_CHITIETHD_MATHANG foreign key (MAMH)
      references MATHANG (MAMH)
go


alter table CHITIETPN
   add constraint FK_CHITIETP_CHITIETPN_HANGHOA foreign key (MAHANG)
      references HANGHOA (MAHANG)
go

alter table CHITIETPN
   add constraint FK_CHITIETP_CHITIETPN_PHIEUNHA foreign key (MAPN)
      references PHIEUNHAP (MAPN)
go



alter table HOADON
   add constraint FK_HOADON_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go
alter table HOADON
   add constraint FK_HOADON_RELATIONS_PHIEUTHUE foreign key (MAPHIEU)
      references PHIEUTHUE(MAPHIEU)
go


alter table HOADON
   add constraint FK_HOADON_RELATIONS_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table PHIEUNHAP
   add constraint FK_PHIEUNHA_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table PHIEUTHUE
   add constraint FK_PHIEUTHU_RELATIONS_PHONG foreign key (MAPHONG)
      references PHONG (MAPHONG)
go

alter table PHONG
   add constraint FK_PHONG_RELATIONS_LOAIPHON foreign key (MALOAI)
      references LOAIPHONG (MALOAI)
go






----LOẠI PHÒNG
INSERT INTO LOAIPHONG VALUES('PHVIP',N'VIP',500000),
('PHTH',N'THƯỜNG',250000)
---KHÁCH HÀNG
INSERT INTO KHACHHANG VALUES('KH01','Nguyễn Văn Lân','0398415284','Tân Phú-TP.HCM',500000)
--NHÂN VIÊN
SET DATEFORMAT DMY
INSERT INTO NHANVIEN VALUES('NV01','thao','123',N'Nguyễn Tấn Thạo','Bình Định','0935841254','2514521452','Nam','17-09-2002','20-07-2020',N'Nhân viên')
INSERT INTO NHANVIEN VALUES('NV02','son','123',N'Đặng Văn Hảo','Phú Yên','0775841254','2587413698','Nam','20-03-2002','20-08-2020',N'Nhân viên')
INSERT INTO NHANVIEN VALUES('NV03','hoa','123',N'Nguyễn Thị Hoa','TP.HCM','0897451258','2334521452',N'Nữ','20-08-2001','20-07-2020',N'Nhân viên')
INSERT INTO NHANVIEN VALUES('NV04','khoi','123',N'Trần Văn Khôi','Hà Nội','0225841254','2514578522','Nam','17-09-1998','20-06-2002',N'Admin')

---NHÀ CUNG CẤP
INSERT INTO NHACC VALUES ('NCC01',N'Công ty Cocacola',N'Quận 7,TP.HCM','0398745214'),
('NCC02',N'Công ty bia Sài Gòn',N' Quận 1, TP.HCM','0363945214'),
('NCC03',N'Bách hóa xanh',N'  Quận 1, TP.HCM','0897412548')
INSERT INTO HANGHOA VALUES('MH01','NCC03',N'Xoài','Kg',20000),
('MH02','NCC03',N'ổi','Kg',15000),
('MH03','NCC03',N'Mận','Kg',30000),
('MH04','NCC03',N'Lê','Kg',25000),
('MH05','NCC03',N'Mực khô','Kg',500000),
('MH06','NCC03',N'Nước lọc','thùng',120000),
('MH07','NCC01',N'CocaCola','thùng',140000),
('MH08','NCC03',N'Pepsi','thùng',140000),
('MH09','NCC02',N'Tiger','thùng',410000),
('MH10','NCC02',N'Sài Gòn Lager','thùng',255000),
('MH11','NCC02',N'Heineken','thùng',445000)

---PHIẾU NHẬP
INSERT INTO PHIEUNHAP VALUES('PN01','NV01','20-12-2022',700000)
---CHI TIẾT PHIẾU NHẬP
INSERT INTO CHITIETPN VALUES('MH010','PN01',1,255000),
('MH011','PN01',1,445000)
---MẶT HÀNG
INSERT INTO MATHANG VALUES ('MHH01',N'Bia Sài Gòn','Chai',600,15000),
('MHH02',N'Bia Tiger','Chai',500,20000),
('MHH03',N'Bia Henieken','Chai',600,25000),
('MHH04',N'Coca','Chai',500,15000),
('MHH05',N'Pepsi','Chai',400,15000),
('MHH06',N'Fanta','Chai',300,10000),
('MHH07',N'Redbull','lon',100,20000),
('MHH08',N'Aquafina','Chai',600,10000),
('MHH09',N'Mực nướng','Con',300,50000),
('MHH10',N'Mì xào',N'Đĩa',200,100000),
('MHH11',N'Trái cây','Đĩa',300,150000),
('MHH12',N'Bim Bim','Bịch',600,20000)

--Phòng
INSERT INTO PHONG VALUES('PH01','PHTH',N'Trống','Thường 1.1'),
('PH02','PHTH',N'Trống','Thường 1.2'),
('PH03','PHTH',N'Trống','Thường 1.3'),
('PH04','PHTH',N'Trống','Thường 1.4'),
('PH05','PHTH',N'Trống','Thường 2.1'),
('PH06','PHTH',N'Trống','Thường 2.2'),
('PH07','PHTH',N'Trống','Thường 2.3'),
('PH08','PHTH',N'Trống','Thường 2.4'),
('PH09','PHTH',N'Trống','Thường 3.1'),
('PH010','PHTH',N'Trống','Thường 3.2'),
('PH011','PHTH',N'Trống','Thường 3.3'),
('PH012','PHTH',N'Trống','Thường 3.4'),
('PH013','PHVIP',N'Trống','Vip 1'),
('PH014','PHVIP',N'Trống','Vip 2'),
('PH015','PHVIP',N'Trống','Vip 3')
--Phiếu thuê

INSERT INTO PHIEUTHUE VALUES('SOPH01','PH01',GETDATE(),'6:30:00','8:00:00')
INSERT INTO HOADON VALUES('HD01','KH01','SOPH01','NV01','10-10-2022',0,0,0,0)

INSERT INTO CHITIETHD VALUES('HD01','MHH01',2,30000)
INSERT INTO CHITIETHD VALUES('HD01','MHH02',2,40000)
----trigger 
----khi khách gọi mọn cập nhật số lượng hàng tồn
create trigger SLMH on CHITIETHD FOR INSERT
AS
begin
UPDATE MATHANG
SET SLTON=SLTON-(select SL FROM inserted where MAMH=MATHANG.MAMH)
from MATHANG 
join inserted on MATHANG.MAMH=inserted.MAMH
end
---Khi nhập phiếu thuê cập nhật lại tình trạng phòng
create  trigger TingtrangPhong on PHIEUTHUE FOR INSERT
as
UPDATE PHONG
SET TINHTRANG=N'Đã thuê'
where MAPHONG=(select MAPHONG FROM inserted)
--Cập nhật lại tình trạng phòng khi khách đã thanh toán



--cập nhật tiền dịch vụ vào hóa đơn
create trigger TienDV ON CHITIETHD FOR INSERT
as
UPDATE HOADON
set TIENDV=TIENDV +(select SUM(SL*GIABAN) from MATHANG m,inserted k where m.MAMH=k.MAMH AND k.MAHD= HOADON.MAHD)
where MAHD=(select MAHD FROM inserted)

SELECT * FROM HOADON
SELECT * FROM NHANVIEN
SELECT * FROM MATHANG
SELECT * FROM CHITIETHD
SELECT * FROM PHONG
SELECT * FROM PHIEUTHUE
select * FROM KHACHHANG
select CHITIETHD.MAMH,MATHANG.TENMH as N'TENHANG',SL,CHITIETHD.DONGIA from CHITIETHD,MATHANG where CHITIETHD.MAMH=MATHANG.MAMH AND MAHD='HD01'

create function Phong_trong()
returns table
as
return(select MAPHONG,TENPH,TINHTRANG from PHONG where TINHTRANG=N'Trống')
select * from dbo.Phong_trong()


SELECT CONCAT('SOPH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAPHIEU),5,2),0) + 1),2)) from PHIEUTHUE where MAPHIEU like 'SOPH%'
SELECT CONCAT('HD', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAHD),3,2),0) + 1),2)) from HOADON where MAHD like 'HD%'
--Kiểm tra mật khẩu tên ĐN
create proc SP_AuthoLogin
@Username char(15),
@Password char(15)
as
begin
    if exists (select * from NHANVIEN where TENDN = @Username and MATKHAU = @Password and CHUCVU=N'Admin')
	 select 0 as code
	else if exists(select * from NHANVIEN where TENDN = @Username and MATKHAU = @Password and CHUCVU=N'Nhân viên')
        select 1 as code
    else if exists(select * from NhanVien where TENDN = @Username and MATKHAU != @Password) 
        select 2 as code
    else select 3 as code
end
exec SP_AuthoLogin 'thao','123'
----Tinh gio
create function tinhtg(@maphieu char(10))
returns float
as
	begin
		declare @gio int, @phut float
		set @gio = (select DATEPART(hour,GIODI) - DATEPART(hour,GIODEN) from PHIEUTHUE where MAPHIEU = @maphieu)
		set @phut = (select((DATEPART(mi,GIODI) - DATEPART(mi,GIODEN))) from PHIEUTHUE where MAPHIEU = @maphieu)
		if @phut < 0
			set @gio = @gio - 1 
		set @phut = abs(@phut)*1.0/60
		return @gio + @phut
	end
	
--Tinh tien Phong
create function tinhtienphong(@maphieu char(10))
returns float
as
	begin
		declare @tienphong float
		select @tienphong = dbo.tinhtg(@maphieu) * GIATHUE FROM PHONG,PHIEUTHUE,LOAIPHONG where PHONG.MAPHONG = PHIEUTHUE.MAPHONG and PHONG.MALOAI=LOAIPHONG.MALOAI  and PHIEUTHUE.MAPHIEU = @maphieu
		return @tienphong
	end

	print(dbo.tinhtienphong('SOPH03'))
Insert into PHIEUTHUE values('SOPH03','PH01',GETDATE())
---update hóa đơn
create proc UpdateTien @ma char(10)
as
declare @maG char(10)
set @maG=(select HOADON.MAPHIEU from PHIEUTHUE,HOADON where HOADON.MAPHIEU=PHIEUTHUE.MAPHIEU AND MAHD=@ma)
update HOADON
set TIENPHONG=	dbo.tinhtienphong(@maG),TONGTIEN=TIENPHONG+TIENDV
 
 exec UpdateTien 'HD02'

--SELECT CONCAT('KH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAKH),3,2),0) + 1),2)) from KHACHHANG where MAKH like 'KH%'
--SELECT CONCAT('MMH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAMH),4,2),0) + 1),2)) from MATHANG where MAMH like 'MHH%'
--SELECT CONCAT('NV', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MANV),3,2),0) + 1),2)) from NHANVIEN where MANV like 'NV%'



--DELETE NHANVIEN WHERE MANV='NV01'
--INSERT INTO HOADON VALUES('HD02','KH02','SOPH03','NV02','12/02/2022',0,0,0,0)
--SELECT * FROM HOADON
--SELECT * FROM NHANVIEN
--SELECT * FROM MATHANG
--SELECT * FROM CHITIETHD
--SELECT * FROM PHONG
--SELECT * FROM PHIEUTHUE
--select * FROM KHACHHANG
--INSERT INTO HOADON VALUES('HD03','KH01','SOPH04','NV01','10/02/2022',0,0,0,0)
--select CHITIETHD.MAMH,MATHANG.TENMH as N'TENHANG',SL,(SL*MATHANG.GIABAN) as N'Giá' from CHITIETHD,MATHANG where CHITIETHD.MAMH=MATHANG.MAMH AND MAHD='HD03'
--select TIENDV from HOADON where  MAHD='HD03'
--UPDATE PHONG
--SET TINHTRANG=N'Trống'


--update PHIEUTHUE
--set GIODI=GETDATE()
--where MAPHIEU=(select HOADON.MAPHIEU from PHIEUTHUE,HOADON where HOADON.MAPHIEU=PHIEUTHUE.MAPHIEU AND MAHD='HD02')


-- select * from HOADON
-- update HOADON set TONGTIEN=TIENPHONG+TIENDV where MAHD='HD02'
 --select NHANVIEN.TENNV,KHACHHANG.TEN,MATHANG.TENMH,CHITIETHD.SL,(SL*MATHANG.GIABAN) AS N'GIÁ', HOADON.TIENPHONG,HOADON.TONGTIEN FROM CHITIETHD,NHANVIEN,KHACHHANG,MATHANG,HOADON WHERE CHITIETHD.MAHD=HOADON.MAHD AND
 --HOADON.MANV=NHANVIEN.MANV AND HOADON.MAKH=KHACHHANG.MAKH AND CHITIETHD.MAMH=MATHANG.MAMH AND HOADON.MAHD='HD01'

