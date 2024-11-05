Create Database Project_63134865
go
use Project_63134865
go

Create Table DanhMuc(
	MaDM int identity(1,1) primary key,
	TenDM Nvarchar(100),
	AnhDM Nvarchar(MAX)
)
go
Create Table LoaiSanPham(
	MaLSP int identity(1,1) primary key,
	MaDM int FOREIGN KEY REFERENCES DanhMuc(MaDM),
	TenLSP Nvarchar(100)
)
go
Create Table HangSanXuat(
	MaHSX int identity(1,1) primary key,
	TenHSX Nvarchar(100),
	SdtHSX varchar(20),
	EmailHSX varchar(50),
	DiaChiHSX Nvarchar(MAX),
	AnhHSX Nvarchar(MAX)
)
go
Create Table SanPham(
	MaSP varchar(50) primary key,
	MaHSX int FOREIGN KEY REFERENCES HangSanXuat(MaHSX),
	MaLSP int FOREIGN KEY REFERENCES LoaiSanPham(MaLSP),
	TenSP Nvarchar(200),
	SizeSP varchar(10),
	GiaSP varchar(10),
	GiamGiaSP int,
	AnhSP Nvarchar(MAX),
	CapNhatNgayThangSP varchar(50),
	MieuTaSP Nvarchar(MAX)
)
go
Create Table QuanLy(
	TkQL varchar(500) primary key,
	MkQL varchar(500),
	HoTenQL Nvarchar(200),
	SdtQL varchar(200),
)
go
Create Table KhachHang(
	SdtKH varchar(20) primary key,
	HoTenKH Nvarchar(200),
	EmailKH varchar(100),
	DiaChiKH Nvarchar(500),
	PassKH varchar(500) null
)
go
Create Table DonDatHang(
	MaDDH varchar(20) primary key,
	SdtKH varchar(20) FOREIGN KEY REFERENCES KhachHang(SdtKH),
	TinNhanDDH Nvarchar(MAX),
	NgayGioDDH varchar(50),
	TrangThaiDDH Nvarchar(50)
)
go
Create Table DonDatHangChiTiet(
    MaDDHCT int identity(1,1) primary key,
	MaDDH varchar(20) FOREIGN KEY REFERENCES DonDatHang(MaDDH),
	MaSP varchar(50) FOREIGN KEY REFERENCES SanPham(MaSP),
	SoLuongDDHCT int,
	ThanhTienDDHCT varchar(50)
)
go
Create Table TiLe(
	MaSP varchar(50) FOREIGN KEY REFERENCES SanPham(MaSP),
	TiLeSao int
	Constraint PK_Gia Primary key (MaSP)
)
go
Create Table BinhLuan(
	MaBinhLuan int identity(1,1) primary key,
	MaSP varchar(50) FOREIGN KEY REFERENCES SanPham(MaSP),
	TinNhanBinhLuan Nvarchar(MAX)
)
go
--Insert table QuanLy
Insert into QuanLy values('a@gmail.com','123',N'Nguyễn Văn A', '0999999999')
Insert into QuanLy values('b@gmail.com','345',N'Nguyễn Văn B', '0999999998')
Insert into QuanLy values('c@gmail.com','456',N'Nguyễn Văn C', '0999999997')
Insert into QuanLy values('d@gmail.com','789',N'Nguyễn Văn D', '0999999996')
--Insert table DanhMuc
Insert into DanhMuc values(N'Quần áo', N'/Image1.jpg')
Insert into DanhMuc values(N'Giày', N'/Image2.jpg')
Insert into DanhMuc values(N'Phụ kiện', N'/Image3.png')
--Insert table LoaiSanPham
Insert into LoaiSanPham values(1, N'Quần áo bóng đá')
Insert into LoaiSanPham values(1, N'Áo khoác')
Insert into LoaiSanPham values(1, N'Quần dài thun')
Insert into LoaiSanPham values(1, N'Quần áo tập thể thao')
Insert into LoaiSanPham values(2, N'Giày thể thao')
Insert into LoaiSanPham values(2, N'Giày đá bóng')
Insert into LoaiSanPham values(2, N'Dép thể thao')
Insert into LoaiSanPham values(3, N'Banh')
Insert into LoaiSanPham values(3, N'Dây nhảy thể lực')
Insert into LoaiSanPham values(3, N'Túi đựng dụng cụ thể thao')
Insert into LoaiSanPham values(3, N'Vợt cầu lông')
--Insert table HangSanXuat
Insert into HangSanXuat values(N'Adidas','01999999999','adidas@gmail.com',N'TpHCM',N'/Image/logoAdidas.jpg')
Insert into HangSanXuat values(N'Nike','01999999998','nike@gmail.com',N'TpHCM',N'/Image/logoNike.jpg')
Insert into HangSanXuat values(N'Puma','01999999997','puma@gmail.com',N'TpHCM',N'/Image/logoPuma.png')
--Insert table SanPham
Insert into SanPham values('BD1', 1, 1, N'Quần áo câu lạc bộ RealMadid', 'M,S,L,...', '90000', 0, N'/Image/kitRMA.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD2', 2, 1, N'Quần áo câu lạc bộ PSG', 'M,S,...', '115000', 0, N'/Image/kitPSG.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD3', 3, 1, N'Quần áo câu lạc bộ ManCity', 'XL,L,...', '129000', 0, N'/Image/kitMC.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD4', 1, 1, N'Quần áo câu lạc ManUnited', 'M,S,L,...', '100000', 0, N'/Image/kitMU.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD5', 2, 1, N'Quần áo câu lạc bộ Barcalona', 'M,S,...', '90000', 0, N'/Image/kitBAR.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD6', 2, 1, N'Quần áo câu lạc bộ Tottenham', 'XL,L,...', '95000', 0, N'/Image/kitTot.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD7', 2, 1, N'Quần áo câu lạc bộ Chealse', 'M,S,L,...', '96000', 6, N'/Image/kitChs.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD8', 2, 1, N'Quần áo câu lạc bộ Liverpool', 'M,S,...', '92000', 0, N'/Image/kitLiver.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD9', 1, 1, N'Quần áo câu lạc bộ Arsenal', 'XL,L,...', '100000', 0, N'/Image/kitArs.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD10', 1, 1, N'Quần áo câu lạc bộ Bayern Munich', 'M,S,L,...', '92000', 0, N'/Image/kitBayern.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD11', 3, 1, N'Quần áo câu lạc bộ AcMilan', 'M,S,...', '93000', 0, N'/Image/kitAc.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('BD12', 1, 1, N'Quần áo câu lạc bộ Borussia Dortmund', 'XL,L,...', '92000', 0, N'/Image/kitDM.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('K01', 1, 2, N'Áo khoác Adidas', 'S,M,...', '94000', 5, N'/Image/khoacAdidas.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('K02', 2, 2, N'Áo khoác Nike', 'S,M,...', '92000', 10, N'/Image/khoacNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('K03', 3, 2, N'Áo khoác Puma', 'S,M,...', '99000', 5, N'/Image/khoacPuma.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('G01', 1, 3, N'Quần dài thun Adidas', 'S,M,...', '55000', 0, N'/Image/quanAdidas.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('G02', 2, 3, N'Quần dài thun Nike', 'S,M,...', '62000', 0, N'/Image/quanNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('T01', 1, 4, N'Quần áo tập thể thao Adidas', 'S,M,...', '39000', 0, N'/Image/quanAoAdidas.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('T02', 2, 4, N'Quần áo tập thể thao Nike', 'S,M,...', '20000', 10, N'/Image/quanAoNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('B01', 1, 5, N'Giày thể thao chạy bộ Adidas', 'S,M,...', '90000', 0, N'/Image/giayAdidas.png', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('B02', 1, 5, N'Giày thể thao chạy bộ Nike', 'S,M,...', '70000', 0, N'/Image/giayNike.png', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('DB1', 1, 6, N'Giày đá banh sân nhân tạo Adidas', 'S,M,...', '45000', 0, N'/Image/giayNhanTaoAdidas.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('DB2', 1, 6, N'Giày đá banh sân nhân tạo Nike', 'S,M,...', '24000', 0, N'/Image/giayNhanTaoNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('D01', 2, 7, N'Dép thể thao cao cấp Nike', 'S,M,...', '60000', 5, N'/Image/depNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('Q01', 1, 8, N'Banh đá C1 ', '1,2,3,4,5', '270000', 0, N'/Image/c1.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('Q02', 1, 8, N'Banh đá Laliga', '1,2,3,4,5', '150000', 0, N'/Image/laliga.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('Q03', 1, 8, N'Banh đá Ngoại Hạng Anh', '1,2,3,4,5', '170000', 0, N'/Image/ngoaiHangAnh.png', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('N01', 2, 9, N'Dây nhảy thể lực cao cấp', 'S,M,...', '20000', 5, N'/Image/dayNhay.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('C01', 1, 10, N'Túi đựng dụng cụ thể thao cao cấp Adidas', 'S,M,...', '90000', 0, N'/Image/tuiAdidas.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('C02', 2, 10, N'Túi đựng dụng cụ thể thao cao cấp Nike', 'S,M,...', '95000', 0, N'/Image/tuiNike.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('V01', 1, 11, N'Vợt cầu lông', 'S,M,...', '92000', 0, N'/Image/votCauLong1.jpg', '01/01/2025 6:00:06 AM', N'Không có mô tả')
Insert into SanPham values('V02', 1, 11, N'Vợt cầu lông', 'S,M,...', '90000', 0, N'/Image/votCauLong2.png', '01/01/2025 6:00:06 AM', N'Không có mô tả')
--Insert table KhachHang
Insert into KhachHang values('01234567891', N'Nguyễn Văn A', 'a@gmail.com', N'Nhà A1','123')
Insert into KhachHang values('01234567892', N'Nguyễn Văn B', 'b@gmail.com', N'Nhà B2','124')
Insert into KhachHang values('01234567893', N'Nguyễn Văn C', 'c@gmail.com', N'Nhà C3','125')
Insert into KhachHang values('01234567894', N'Nguyễn Văn D', 'd@gmail.com', N'Nhà D4','126')
Insert into KhachHang values('01234567895', N'Nguyễn Văn E', 'e@gmail.com', N'Nhà E5','127')
Insert into KhachHang values('01234567896', N'Nguyễn Văn F', 'f@gmail.com', N'Nhà A6','128')
Insert into KhachHang values('01234567897', N'Nguyễn Văn G', 'g@gmail.com', N'Nhà B7','129')
Insert into KhachHang values('01234567898', N'Nguyễn Văn H', 'h@gmail.com', N'Nhà C8','130')
Insert into KhachHang values('01234567899', N'Nguyễn Văn K', 'k@gmail.com', N'Nhà D9','131')
Insert into KhachHang values('01234567810', N'Nguyễn Văn J', 'j@gmail.com', N'Nhà E10','132')
Insert into KhachHang values('01234567811', N'Nguyễn Văn Z', 'z@gmail.com', N'Nhà A11','133')
Insert into KhachHang values('01234567812', N'Nguyễn Văn X', 'x@gmail.com', N'Nhà B12','134')
Insert into KhachHang values('01234567813', N'Nguyễn Văn M', 'm@gmail.com', N'Nhà C13','135')
Insert into KhachHang values('01234567814', N'Nguyễn Văn N', 'n@gmail.com', N'Nhà D14','136')
Insert into KhachHang values('01234567815', N'Nguyễn Văn L', 'l@gmail.com', N'Nhà E15','137')
Insert into KhachHang values('01234567816', N'Nguyễn Văn I', 'i@gmail.com', N'Nhà A16','138')
Insert into KhachHang values('01234567817', N'Nguyễn Văn O', 'o@gmail.com', N'Nhà B17','139')
Insert into KhachHang values('01234567818', N'Nguyễn Văn W', 'w@gmail.com', N'Nhà C18','140')
Insert into KhachHang values('01234567819', N'Nguyễn Văn U', 'u@gmail.com', N'Nhà D19','141')
Insert into KhachHang values('01234567820', N'Nguyễn Văn Y', 'y@gmail.com', N'Nhà E20','142')
Insert into KhachHang values('01234567821', N'Nguyễn Văn T', 't@gmail.com', N'Nhà A21','143')
Insert into KhachHang values('01234567822', N'Nguyễn Văn R', 'r@gmail.com', N'Nhà B22','144')
Insert into KhachHang values('01234567823', N'Nguyễn Văn P', 'p@gmail.com', N'Nhà C23','145')
Insert into KhachHang values('01234567824', N'Nguyễn Văn Q', 'q@gmail.com', N'Nhà D24','146')
Insert into KhachHang values('01234567825', N'Nguyễn Văn E', 'e@gmail.com', N'Nhà E25','147')
Insert into KhachHang values('01234567826', N'Nguyễn A', 'na@gmail.com', N'Nhà A26','148')
Insert into KhachHang values('01234567827', N'Nguyễn B', 'nb@gmail.com', N'Nhà B27','149')
Insert into KhachHang values('01234567828', N'Nguyễn C', 'cn@gmail.com', N'Nhà C28','150')
Insert into KhachHang values('01234567829', N'Nguyễn D', 'nd@gmail.com', N'Nhà D29','151')
Insert into KhachHang values('01234567830', N'Nguyễn E', 'ne@gmail.com', N'Nhà E30','152')
--Insert table Gia
Insert into TiLe values('BD1', 1)
Insert into TiLe values('BD2', 2)
Insert into TiLe values('BD3', 3)
Insert into TiLe values('BD4', 4)
Insert into TiLe values('BD5', 5)
Insert into TiLe values('BD6', 1)
Insert into TiLe values('BD7', 2)
Insert into TiLe values('BD8', 3)
Insert into TiLe values('BD9', 4)
Insert into TiLe values('BD10', 5)
Insert into TiLe values('BD11', 1)
Insert into TiLe values('BD12', 2)
Insert into TiLe values('K01', 3)
Insert into TiLe values('K02', 4)
Insert into TiLe values('K03', 5)
Insert into TiLe values('G01', 1)
Insert into TiLe values('G02', 2)
Insert into TiLe values('T01', 3)
Insert into TiLe values('T02', 4)
Insert into TiLe values('B01', 5)
Insert into TiLe values('B02', 1)
Insert into TiLe values('DB1', 2)
Insert into TiLe values('DB2', 3)
Insert into TiLe values('D01', 4)
Insert into TiLe values('Q01', 5)
Insert into TiLe values('Q02', 1)
Insert into TiLe values('Q03', 2)
Insert into TiLe values('N01', 3)
Insert into TiLe values('C01', 4)
Insert into TiLe values('C02', 5)
Insert into TiLe values('V01', 1)
Insert into TiLe values('V02', 2)
--Insert table BinhLuan
Insert into BinhLuan values('BD1', N'đã đánh giá BD01')
Insert into BinhLuan values('BD2', N'đã đánh giá BD02')
Insert into BinhLuan values('BD3', N'đã đánh giá BD03')
Insert into BinhLuan values('BD4', N'đã đánh giá BD04')
Insert into BinhLuan values('BD5', N'đã đánh giá BD05')
Insert into BinhLuan values('BD6', N'đã đánh giá BD06')
Insert into BinhLuan values('BD7', N'đã đánh giá BD07')
Insert into BinhLuan values('BD8', N'đã đánh giá BD08')
Insert into BinhLuan values('BD9', N'đã đánh giá BD09')
Insert into BinhLuan values('BD10', N'đã đánh giá BD010')
Insert into BinhLuan values('BD11', N'đã đánh giá BD011')
Insert into BinhLuan values('BD12', N'đã đánh giá BD012')
Insert into BinhLuan values('K01', N'đã đánh giá K01')
Insert into BinhLuan values('K02', N'đã đánh giá K02')
Insert into BinhLuan values('K03', N'đã đánh giá K03')
Insert into BinhLuan values('G01', N'đã đánh giá G01')
Insert into BinhLuan values('G02', N'đã đánh giá G02')
Insert into BinhLuan values('T01', N'đã đánh giá T01')
Insert into BinhLuan values('T02', N'đã đánh giá T02')
Insert into BinhLuan values('B01', N'đã đánh giá B01')
Insert into BinhLuan values('B02', N'đã đánh giá B02')
Insert into BinhLuan values('DB1', N'đã đánh giá DB1')
Insert into BinhLuan values('DB2', N'đã đánh giá DB2')
Insert into BinhLuan values('D01', N'đã đánh giá D01')
Insert into BinhLuan values('Q01', N'đã đánh giá Q01')
Insert into BinhLuan values('Q02', N'đã đánh giá Q02')
Insert into BinhLuan values('Q03', N'đã đánh giá Q03')
Insert into BinhLuan values('N01', N'đã đánh giá N01')
Insert into BinhLuan values('C01', N'đã đánh giá C01')
Insert into BinhLuan values('C02', N'đã đánh giá C02')
Insert into BinhLuan values('V01', N'đã đánh giá V01')
Insert into BinhLuan values('V02', N'đã đánh giá V01')

--Insert table DonDatHang
Insert into DonDatHang values('HD1', '01234567891', 'Size: M', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD2', '01234567892', 'Size: M', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD3', '01234567893', 'Size: S', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD4', '01234567894', 'Size: L', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD5', '01234567895', 'Size: XL', '01/02/2025 05:30:10 AM', N'0')
Insert into DonDatHang values('HD6', '01234567896', 'Size: M', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD7', '01234567897', 'Size: XXL', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD8', '01234567898', 'Size: S', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD9', '01234567899', 'Size: M', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD10', '01234567810', 'Size: S', '01/02/2025 05:30:10 AM', N'0')
Insert into DonDatHang values('HD11', '01234567811', 'Size: S', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD12', '01234567812', 'Size: XL', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD13', '01234567813', 'Size: M', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD14', '01234567814', 'Size: M', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD15', '01234567815', 'Size: S', '01/02/2025 05:30:10 AM', N'0')
Insert into DonDatHang values('HD16', '01234567816', 'Size: XXL', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD17', '01234567817', 'Size: XL', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD18', '01234567818', 'Size: XL', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD19', '01234567819', 'Size: M', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD20', '01234567820', 'Size: S', '01/02/2025 05:30:10 AM', N'0')
Insert into DonDatHang values('HD21', '01234567821', 'Size: 5', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD22', '01234567822', 'Size: 4', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD23', '01234567823', 'Size: M', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD24', '01234567824', 'Size: S', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD25', '01234567825', 'Size: S', '01/02/2025 05:30:10 AM', N'0')
Insert into DonDatHang values('HD26', '01234567826', 'Size: XL', '01/02/2025 01:30:10 AM', N'0')
Insert into DonDatHang values('HD27', '01234567827', 'Size: XL', '01/02/2025 02:30:10 PM', N'0')
Insert into DonDatHang values('HD28', '01234567828', 'Size: M', '01/02/2025 09:30:10 AM', N'0')
Insert into DonDatHang values('HD29', '01234567829', 'Size: X', '01/02/2025 08:30:10 PM', N'0')
Insert into DonDatHang values('HD30', '01234567830', 'Size: M', '01/02/2025 05:30:10 AM', N'0')


--Insert table DonDatHangChiTiet
Insert into DonDatHangChiTiet values('HD1', 'BD1', 2, '180000')
Insert into DonDatHangChiTiet values('HD2', 'BD2', 1, '115000')
Insert into DonDatHangChiTiet values('HD3', 'BD3', 1, '129000')
Insert into DonDatHangChiTiet values('HD4', 'BD4', 2, '188000')
Insert into DonDatHangChiTiet values('HD5', 'BD5', 1, '39000')
Insert into DonDatHangChiTiet values('HD6', 'BD6', 2, '180000')
Insert into DonDatHangChiTiet values('HD7', 'BD7', 1, '115000')
Insert into DonDatHangChiTiet values('HD8', 'BD8', 1, '129000')
Insert into DonDatHangChiTiet values('HD9', 'BD9', 2, '188000')
Insert into DonDatHangChiTiet values('HD10', 'BD10', 1, '39000')
Insert into DonDatHangChiTiet values('HD11', 'BD11', 2, '180000')
Insert into DonDatHangChiTiet values('HD12', 'BD12', 1, '115000')
Insert into DonDatHangChiTiet values('HD13', 'BD3', 1, '129000')
Insert into DonDatHangChiTiet values('HD14', 'K01', 2, '188000')
Insert into DonDatHangChiTiet values('HD15', 'T01', 1, '39000')
Insert into DonDatHangChiTiet values('HD16', 'BD1', 2, '180000')
Insert into DonDatHangChiTiet values('HD17', 'G02', 1, '115000')
Insert into DonDatHangChiTiet values('HD18', 'K02', 1, '129000')
Insert into DonDatHangChiTiet values('HD19', 'K01', 2, '188000')
Insert into DonDatHangChiTiet values('HD20', 'T01', 1, '39000')
Insert into DonDatHangChiTiet values('HD21', 'Q01', 2, '180000')
Insert into DonDatHangChiTiet values('HD22', 'Q02', 1, '115000')
Insert into DonDatHangChiTiet values('HD23', 'BD3', 1, '129000')
Insert into DonDatHangChiTiet values('HD24', 'C01', 2, '188000')
Insert into DonDatHangChiTiet values('HD25', 'C02', 1, '39000')
Insert into DonDatHangChiTiet values('HD26', 'V01', 2, '180000')
Insert into DonDatHangChiTiet values('HD27', 'V02', 1, '115000')
Insert into DonDatHangChiTiet values('HD28', 'BD3', 1, '129000')
Insert into DonDatHangChiTiet values('HD29', 'K01', 2, '188000')
Insert into DonDatHangChiTiet values('HD30', 'T01', 1, '39000')
