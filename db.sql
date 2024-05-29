USE [SportLeague]
GO
/****** Object:  Table [dbo].[BangDau]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDau](
	[MaBangDau] [int] IDENTITY(1,1) NOT NULL,
	[TenBangDau] [nvarchar](100) NULL,
	[MaGiaiDau] [int] NULL,
 CONSTRAINT [PK_BangDau] PRIMARY KEY CLUSTERED 
(
	[MaBangDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangDauVaDoiBong]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDauVaDoiBong](
	[MaBangDauVaDoiBong] [int] IDENTITY(1,1) NOT NULL,
	[MaBangDau] [int] NULL,
	[MaDoiBong] [int] NULL,
 CONSTRAINT [PK_BangDauVaDoiBong] PRIMARY KEY CLUSTERED 
(
	[MaBangDauVaDoiBong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CauThu]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauThu](
	[MaCauThu] [int] IDENTITY(1,1) NOT NULL,
	[TenCauThu] [nvarchar](100) NOT NULL,
	[Avatar] [varchar](255) NULL,
	[NgaySinh] [date] NULL,
	[ChieuCao] [int] NULL,
	[QuocTich] [nvarchar](100) NULL,
	[ViTriThiDau] [nvarchar](50) NULL,
 CONSTRAINT [PK__CauThu__18362CB83B1C1500] PRIMARY KEY CLUSTERED 
(
	[MaCauThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhHieuCauThu]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhHieuCauThu](
	[MaDanhHieuCauThu] [int] IDENTITY(1,1) NOT NULL,
	[MaLichThiDau] [int] NULL,
	[MaCauThu] [int] NULL,
	[LoaiGiaiThuong] [nvarchar](100) NULL,
	[SoLuong] [int] NULL,
	[MaLoaiGiaiThuong] [int] NULL,
 CONSTRAINT [PK_DanhHieuCauThu] PRIMARY KEY CLUSTERED 
(
	[MaDanhHieuCauThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoiBong]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiBong](
	[MaDoiBong] [int] IDENTITY(1,1) NOT NULL,
	[TenDoiBong] [varchar](100) NOT NULL,
	[Logo] [varchar](255) NULL,
	[NguoiQuanLyCLB] [nvarchar](100) NULL,
	[DoiTruong] [nvarchar](50) NULL,
	[ViTri] [nvarchar](50) NULL,
 CONSTRAINT [PK__DoiBong__EC71A1D621A43AB6] PRIMARY KEY CLUSTERED 
(
	[MaDoiBong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichThiDau]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichThiDau](
	[MaLichThiDau] [int] IDENTITY(1,1) NOT NULL,
	[MaGiaiDau] [int] NULL,
	[NgayThiDau] [datetime] NULL,
	[VongThiDau] [varchar](50) NULL,
	[SanThiDau] [varchar](100) NULL,
	[MaCLBChuNha] [int] NULL,
	[MaCLBKhach] [int] NULL,
	[TiSoCLBChuNha] [int] NULL,
	[TiSoCLBKhach] [int] NULL,
	[SoCuSut] [int] NULL,
	[SutTrungDich] [int] NULL,
	[SoLuongPenalties] [int] NULL,
	[SoLuongDaPhat] [int] NULL,
	[SoLuongPhatGoc] [int] NULL,
	[SoLuongPhamLoi] [int] NULL,
	[SoLuongVietVi] [int] NULL,
	[SoTheVang] [int] NULL,
	[SoTheDo] [int] NULL,
	[BuGio] [varchar](10) NULL,
	[KetQuaLuanLuu] [varchar](255) NULL,
 CONSTRAINT [PK__LichThiD__50E22190144C83F3] PRIMARY KEY CLUSTERED 
(
	[MaLichThiDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiGiaiThuong]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiGiaiThuong](
	[MaLoaiGiaiThuong] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiGiaiThuong] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiGiaiThuong] PRIMARY KEY CLUSTERED 
(
	[MaLoaiGiaiThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](255) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[Email] [varchar](255) NULL,
	[SoDienThoai] [varchar](15) NULL,
	[Avatar] [nvarchar](100) NULL,
 CONSTRAINT [PK__NguoiDun__C539D7622BA9B7F2] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyenNguoiDung]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyenNguoiDung](
	[MaPhanQuyen] [int] IDENTITY(1,1) NOT NULL,
	[MaNguoiDung] [int] NULL,
	[MaVaiTro] [int] NULL,
	[MaDoiBong] [int] NULL,
 CONSTRAINT [PK__PhanQuye__529AB12B336FDE64] PRIMARY KEY CLUSTERED 
(
	[MaPhanQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyCLBVaGiaiDau]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyCLBVaGiaiDau](
	[MaGiaiDau] [int] NOT NULL,
	[MaCLB] [int] NOT NULL,
 CONSTRAINT [PK_QuanLyCLBVaGiaiDau] PRIMARY KEY CLUSTERED 
(
	[MaGiaiDau] ASC,
	[MaCLB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyDoiBongVaCauThu]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyDoiBongVaCauThu](
	[MaDoiBong] [int] NOT NULL,
	[MaCauThu] [int] NOT NULL,
	[SoAo] [int] NULL,
 CONSTRAINT [PK_QuanLyDoiBongVaCauThu] PRIMARY KEY CLUSTERED 
(
	[MaDoiBong] ASC,
	[MaCauThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyGiaiDau]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyGiaiDau](
	[MaGiaiDau] [int] IDENTITY(1,1) NOT NULL,
	[TenGiaiDau] [nvarchar](255) NOT NULL,
	[NamThucHien] [int] NULL,
	[DonViToChuc] [nvarchar](100) NULL,
	[SoLuongDoiThamGia] [int] NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
 CONSTRAINT [PK__QuanLyGi__0B811B64CA7CE45F] PRIMARY KEY CLUSTERED 
(
	[MaGiaiDau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLyGiaiThuong]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyGiaiThuong](
	[MaGiaiThuong] [int] IDENTITY(1,1) NOT NULL,
	[TenGiaiThuong] [nvarchar](255) NOT NULL,
	[MaGiaiDau] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK__QuanLyGi__19596CA46A9827DC] PRIMARY KEY CLUSTERED 
(
	[MaGiaiThuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 05/29/24 11:32:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[MaVaiTro] [int] IDENTITY(1,1) NOT NULL,
	[TenVaiTro] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__VaiTro__C24C41CF7FDFAA9A] PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CauThu] ON 

INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1032, N'Reece James', N'Content/upload/24203093424-reece-james-2709112013.jpg', CAST(N'1999-12-08' AS Date), 180, N'Anh', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1033, N'Erling Haaland', N'Content/upload/15819976249-erling-haaland-2709132755.jpg', CAST(N'2000-11-24' AS Date), 195, N'Na Uy', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1034, N'Kevin De Bruyne', N'Content/upload/101889783217-kevin-de-bruyne-2709132756.jpg', CAST(N'1991-06-28' AS Date), 181, N'Bỉ', N'Tiền Vệ Tấn Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1035, N'Rodri', N'Content/upload/72208732416-rodri-2709132756.jpg', CAST(N'1996-06-22' AS Date), 196, N'Tây Ban Nha', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1038, N'Robert Lewandowski', N'Content/upload/19749584719-robert-lewandowski-0410081449.jpg', CAST(N'1988-08-21' AS Date), 185, N'Ba Lan', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1039, N'Lamine Yamal', N'Content/upload/703853819lamine-yamal-0410082727.jpg', CAST(N'2007-07-13' AS Date), 180, N'Tây Ban Nha', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1040, N'Jude Bellingham', N'Content/upload/12248220425-bellingham-0410085953.jpg', CAST(N'2003-06-29' AS Date), 186, N'Anh', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1041, N'Luka Modric', N'Content/upload/137797027310-modric-0410085954.jpg', NULL, 172, N'Croatia', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1042, N'Vinícius Júnior', N'Content/upload/1535868207-vini-jr-0410085953.jpg', CAST(N'2000-07-12' AS Date), 176, N'Brasil', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (1045, N'phụng', N'Content/upload/2873329892019147183134_2019-05-27_Fussball_1.FC_Kaiserslautern_vs_FC_Bayern_München_-_Sven_-_1D_X_MK_II_-_0228_-_B70I8527_(cropped).jpg', NULL, 1, N'việt nam', N'tiền đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2046, N' Jérémy Doku', N'Content/upload/211218604411-jeremy-doku-2709132756.jpg', CAST(N'2002-05-27' AS Date), 173, N'Bỉ', N'Tiền vệ cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2047, N'Julián Álvarez', N'Content/upload/104936727119-julian-alvarez-2709132757.jpg', CAST(N'2000-01-31' AS Date), 170, N'Argentina', N'Tiền đạo, Tiền vệ tấn công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2048, N' Joško Gvardiol', N'Content/upload/143304066624-josko-gvardiol-2709132757.jpg', CAST(N'2002-01-23' AS Date), 185, N'Croatia', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2049, N'Bernardo Silva', N'Content/upload/174589087220-bernardo-silva-2709132757.jpg', CAST(N'1994-08-10' AS Date), 173, N'Bồ Đào Nha', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2050, N' Phil Foden', N'Content/upload/2514773547-phil-foden-2709132759.jpg', CAST(N'2000-02-28' AS Date), 171, N'Anh', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2051, N'Jack Grealish', N'Content/upload/144459947710-jack-grealish-2709132755.jpg', CAST(N'1998-09-10' AS Date), 180, N'Anh', N'Tiền Vệ Cánh,Tấn Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2052, N'Kyle Walker', N'Content/upload/14455607902-kyle-walker-2709132753.jpg', CAST(N'1990-05-28' AS Date), 183, N'Anh', N'Hậu Vệ Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2053, N'Rúben Dias', N'Content/upload/20810937283-ruben-dias-2709132754.jpg', CAST(N'1997-05-14' AS Date), 186, N'Bồ Đào Nha', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2054, N' Ederson Moraes', N'Content/upload/117027095631-ederson-2709132758.jpg', CAST(N'1993-08-17' AS Date), 188, N'Brasil', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2055, N'Alejandro Garnacho', N'Content/upload/14118031217-garnacho-2709134702.jpg', CAST(N'2004-07-01' AS Date), 180, N'Argentina', N'Tiền Vệ Cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2056, N'Rasmus Højlund', N'Content/upload/63222417011-rasmus-hojlund-2709134700.jpg', CAST(N'2003-02-04' AS Date), 191, N'Đan Mạch', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2057, N'Marcus Rashford', N'Content/upload/145022254810-marcus-rashford-2709134700.jpg', CAST(N'1997-10-31' AS Date), 186, N'Anh', N'Tiền Đạo Cắm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2058, N' André Onana', N'Content/upload/47883811024-andre-onana-2709134704.jpg', CAST(N'1996-04-02' AS Date), 190, N'Cameroon', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2059, N'Mohamed Salah', N'Content/upload/123515840511-mohamed-salah-2709131133.jpg', CAST(N'1992-06-15' AS Date), 175, N'Ai Cập', N'Tiền Đạo Cắm,Cánh Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2060, N'Darwin Núñez', N'Content/upload/13129933169-darwin-nunez-2709131133.jpg', CAST(N'1999-06-24' AS Date), 185, N'Uruguay', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2061, N' Alexis Mac Allister', N'Content/upload/140962338410-alexis-mac-allister-2709131133.jpg', CAST(N'1998-12-24' AS Date), 176, N'Argentina', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2062, N'Virgil van Dijk', N'Content/upload/8544334924-virgil-van-dijk-2709131131.jpg', CAST(N'1991-07-08' AS Date), 195, N'Hà Lan', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2063, N'Alisson', N'Content/upload/9578814021-alisson-becker-2709131131.jpg', CAST(N'1992-10-02' AS Date), 193, N'Brasil', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2064, N'Diogo Jota', N'Content/upload/150651267720-diogo-jota-2709131134.jpg', CAST(N'1996-12-04' AS Date), 178, N'Bồ Đào Nha', N'Tiền Đạo Cắm / Hộ Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2065, N'Trent Alexander-Arnold', N'Content/upload/208901663766-trent-alexander-arnold-2709131136.jpg', CAST(N'1998-10-07' AS Date), 175, N'Anh', N'Hậu Vệ Cánh Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2066, N' Oleksandr Zinchenko', N'Content/upload/17861134735-oleksandr-zinchenko-2709105614.jpg', CAST(N'1996-12-15' AS Date), 175, N'Ukraina', N'Hậu Vệ Trái,Tiền Vệ Tấn Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2067, N'Kai Havertz', N'Content/upload/108491445629-kai-havertz-2709105614.jpg', CAST(N'1999-06-11' AS Date), 193, N'Đức', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2068, N'Bukayo Saka', N'Content/upload/18988867117-bukayo-saka-2709105610.jpg', CAST(N'2001-09-05' AS Date), 178, N'Anh', N'Tiền Vệ,Tiền Đạo Cánh Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2069, N'Martin Ødegaard', N'Content/upload/10344179728-martin-odegaard-2709105610.jpg', CAST(N'1998-12-17' AS Date), 178, N'Na Uy', N'Tiền Vệ Tấn Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2070, N'Declan Rice', N'Content/upload/95112644441-declan-rice-2709105615.jpg', CAST(N'1999-01-14' AS Date), 185, N'Anh', N'Tiền Vệ Phòng Ngự')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2071, N' David Raya', N'Content/upload/113595626522-david-raya-2709105613.jpg', CAST(N'1995-09-15' AS Date), 186, N'Tây Ban Nha', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2072, N' Gabriel Jesus', N'Content/upload/18000490259-gabriel-jesus-2709105610.jpg', CAST(N'1997-04-03' AS Date), 175, N'Brasil', N'Tiền Đạo Cắm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2073, N'Gabriel Martinelli', N'Content/upload/54477718229-kai-havertz-2709105614.jpg', CAST(N'2001-06-18' AS Date), 180, N'Bra', N'Tiền Đạo Cánh Trái')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2074, N'Tomiyasu Takehiro', N'Content/upload/73412666618-takehiro-tomiyasu-2709105612.jpg', CAST(N'1998-11-05' AS Date), 188, N'Nhật Bản', N'Trung Vệ, Hậu Vệ Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2075, N'Robert Sanchez', N'Content/upload/7484560511-robert-sanchez-2709112008.jpg', CAST(N'1997-11-18' AS Date), 197, N'Tây Ban NHa', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2076, N'Marc Cucurella', N'Content/upload/2353074183-marc-cucurella-2709112009.jpg', CAST(N'1998-07-22' AS Date), 172, N'Tây Ban NHa', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2077, N'Thiago Silva', N'Content/upload/3028436896-thiago-silva-2709112009.jpg', CAST(N'1984-09-22' AS Date), 181, N'Brasil', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2078, N' Enzo Fernandez', N'Content/upload/10473312808-enzo-fernandez-2709112010.jpg', CAST(N'2001-01-17' AS Date), 178, N'Argentina', N'Tiền Vệ Trung Tâm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2079, N'Cole Palmer', N'Content/upload/60860296220-cole-palmer-2709112012.jpg', CAST(N'2002-05-06' AS Date), 189, N'Anh', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2080, N'Raheem Sterling', N'Content/upload/7535855827-raheem-sterling-2709112010.jpg', CAST(N'1993-12-17' AS Date), 172, N'Anh', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2081, N'Mykhailo Mudryk', N'Content/upload/46717869210-mykhailo-mudryk-2709112010.jpg', CAST(N'2001-01-05' AS Date), 175, N'Ukraina', N'Tiền Vệ Cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2082, N'Guglielmo Vicario', N'Content/upload/54229943613-guglielmo-vicario-2709141603.jpg', CAST(N'1996-10-07' AS Date), 197, N'Ý', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2083, N'Cristian Romero', N'Content/upload/214558091017-cristian-romero-2709141604.jpg', CAST(N'1998-04-27' AS Date), 185, N'Argentina', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2084, N'James Maddison', N'Content/upload/114727237410-james-maddison-2709141602.jpg', CAST(N'1996-11-23' AS Date), 175, N'Anh', N'Tiền Vệ Tấn Công')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2085, N'Giovani Lo Celso', N'Content/upload/197824564018-giovani-lo-celso-2709141604.jpg', CAST(N'1996-04-09' AS Date), 177, N'Argentina', N'Tiền Vệ Trung Tâm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2086, N'Richarlison', N'Content/upload/12642662649-richarlison-2709141602.jpg', CAST(N'1997-05-10' AS Date), 184, N'Brasil', N'Tiền Đạo Cắm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2087, N'Son Heung-min', N'Content/upload/2169936497-heung-min-son-2709141602.jpg', CAST(N'1992-07-08' AS Date), 184, N'Hàn Quốc', N'Tiền Đạo ,Tiền Vệ Cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2088, N'Dejan Kulusevski', N'Content/upload/202881967621-dejan-kulusevski-2709141605.jpg', CAST(N'2000-04-25' AS Date), 186, N'Thụy Điển', N'Tiền Vệ Cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2089, N'Thibaut Courtois', N'Content/upload/11722996131-courtois-0410085952.jpg', CAST(N'1992-05-11' AS Date), 200, N'Bỉ', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2090, N'David Alaba', N'Content/upload/11878404-alaba-0410085953.jpg', CAST(N'1992-06-24' AS Date), 180, N'Áo', N'Hậu Vệ Trái ,Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2091, N'Toni Kroos', N'Content/upload/1645357638-kroos-0410085954.jpg', CAST(N'1990-01-04' AS Date), 183, N'Đức', N'Tiền Vệ Trung Tâm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2092, N'Federico Valverde', N'Content/upload/181549457615-valverde-0410085955.jpg', CAST(N'1998-07-22' AS Date), 182, N'Uruguay', N'Tiền Vệ Trung Tâm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2093, N'Eduardo Camavinga', N'Content/upload/105147348012-camavinga-0410085954.jpg', CAST(N'2002-11-10' AS Date), 182, N'Pháp', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2094, N'Antonio Rudiger', N'Content/upload/138584436022-rudiger-0410085956.jpg', CAST(N'1993-03-03' AS Date), 190, N'Đức', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2095, N'Marc-Andre ter Stegen', N'Content/upload/10575643241-marc-andre-ter-stegen-0410081447.jpg', CAST(N'1992-04-30' AS Date), 187, N'Đức', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2096, N'Ronald Araujo', N'Content/upload/5014649044-ronald-araujo-0410081448.jpg', CAST(N'1999-03-07' AS Date), 188, N'Uruguay', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2097, N'Joao Cancelo', N'Content/upload/2226037112-joao-cancelo-0410081447.jpg', CAST(N'1994-02-27' AS Date), 182, N'Bồ Đào Nha', N'Hậu Vệ Cánh ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2098, N'Alejandro Balde', N'Content/upload/9461547293-alejandro-balde-0410081448.jpg', CAST(N'2003-10-18' AS Date), 175, N'Tây Ban NHa', N'Hậu Vệ Cánh Trái')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2099, N'Ilkay Gundogan', N'Content/upload/213828062722-ilkay-gundogan-0410081451.jpg', CAST(N'1990-10-24' AS Date), 180, N'Đức', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2100, N'Pedri', N'Content/upload/10700714398-pedri-0410081449.jpg', CAST(N'2002-11-25' AS Date), 175, N'Tây Ban Nha', N'Tiền Vệ Trung Tâm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2101, N'Gavi', N'Content/upload/14323017126-gavi-0410081449.jpg', CAST(N'2004-08-05' AS Date), 173, N'Tay Ban Nha', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2102, N'Frenkie de Jong', N'Content/upload/29763389421-frenkie-de-jong-0410081451.jpg', CAST(N'1997-05-12' AS Date), 181, N'Hà Lan', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2103, N'Joao Felix', N'Content/upload/39605559214-joao-felix-0410081450.jpg', CAST(N'1999-11-10' AS Date), 179, N'Bồ Đào Nha', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2104, N'Raphinha', N'Content/upload/129240984711-raphinha-0410081450.jpg', CAST(N'1996-02-14' AS Date), 176, N'Brasil', N'Tiền Vệ Cánh')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2105, N'Jan Oblak', N'Content/upload/90571041813-jan-oblak-0310225641.jpg', CAST(N'1993-01-07' AS Date), 188, N'Slovenia', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2106, N'Nahuel Molina', N'Content/upload/76681864216-nahuel-molina-lucero-0310225641.jpg', CAST(N'1998-04-06' AS Date), 175, N'Argentina', N'Hậu Vệ Cánh Phải')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2107, N'Rodrigo De Paul', N'Content/upload/14264823005-rodrigo-javier-de-paul-0310225639.jpg', CAST(N'1994-05-24' AS Date), 180, N'Argentina', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2108, N' Alvaro Morata', N'Content/upload/65342187819-alvaro-borja-morata-martin-0310225642.jpg', CAST(N'1992-10-23' AS Date), 190, N'Tây Ban Nha', N'Tiền Đạo Cắm')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2109, N'Antoine Griezmann', N'Content/upload/6245236207-antoine-griezmann-0310225640.jpg', CAST(N'1991-03-21' AS Date), 176, N'Pháp', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2110, N'Unai Simon', N'Content/upload/19435147101-unai-simon-0410082939.jpg', CAST(N'1997-06-11' AS Date), 190, N'Tây Ban Nha', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2111, N'Aitor Paredes', N'Content/upload/5150624184-aitor-paredes-0410082939.jpg', CAST(N'2000-04-29' AS Date), 178, N'Tây Ban Nha', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2112, N'Dani Garcia', N'Content/upload/18392446114-dani-garcia-0410082942.jpg', CAST(N'1990-05-24' AS Date), 180, N'Tây Ban NHa', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2113, N'Harry Maguire', N'Content/upload/15096032545-harry-maguire-2709134658.jpg', CAST(N'1993-03-05' AS Date), 186, N'Anh', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2114, N'Bruno Fernandes', N'Content/upload/3214516948-bruno-fernandes-2709134659.jpg', CAST(N'1994-09-08' AS Date), 176, N'Bồ Đào Nha', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2115, N'Scott Mc Tominay', N'Content/upload/114230799339-scott-mctominay-2709134707.jpg', CAST(N'1996-12-08' AS Date), 180, N'Anh', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2116, N'Casemiro', N'Content/upload/212274476618-casemiro-2709134702.jpg', CAST(N'1992-02-23' AS Date), 180, N'Brasil', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2117, N'Mason Mount', N'Content/upload/12247675457-mason-mount-2709134659.jpg', CAST(N'1999-01-10' AS Date), 180, N'Anh', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2118, N'Leandro Trossard', N'Content/upload/111298073819-leandro-trossard-2709105612.jpg', CAST(N'1994-12-04' AS Date), 175, N'Bỉ', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2119, N'Nguyễn Hữu Trí', N'Content/upload/1622386832nguyen_huu_tri.jpg', CAST(N'2003-05-18' AS Date), 171, N'Việt Nam', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2120, N'Hiền Triết', N'Content/upload/559645611hien_triet.jpg', CAST(N'2002-02-10' AS Date), 170, N'Việt Nam', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2121, N'Lưu Minh Nhật', N'Content/upload/1539914271luu_minh_nhat.jpg', CAST(N'2002-10-23' AS Date), 180, N'Việt Nam', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2122, N'Gia Luật', N'Content/upload/1735354599gia_luat.jpg', CAST(N'2004-11-15' AS Date), 175, N'Việt Nam', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2123, N'Nguyễn Phước Tài', N'Content/upload/97448226nguyen_phuoc_tai.jpg', CAST(N'2005-06-10' AS Date), 185, N'Việt Nam', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2124, N'Thành Thái', N'Content/upload/274355138thanh_thai.jpg', CAST(N'2003-12-11' AS Date), 172, N'Việt Nam', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2125, N'Thanh Hải', N'Content/upload/652547557thanh_hai.jpg', CAST(N'2002-04-07' AS Date), 165, N'Việt Nam', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2126, N'Thành Đạt', N'Content/upload/2011592737thanh-dat.jpg', CAST(N'2003-05-06' AS Date), 175, N'Việt Nam', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2127, N'Trần Minh Hiếu', N'Content/upload/312370274tran_minh_hieu.jpg', CAST(N'2005-07-11' AS Date), 180, N'Việt Nam', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2128, N'Trần Tấn', N'Content/upload/1620048218tran_tan.jpg', CAST(N'2004-05-05' AS Date), 168, N'Việt Nam', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2129, N'Trung Trực', N'Content/upload/2122079795trung_truc.jpg', CAST(N'2005-08-02' AS Date), 180, N'Việt Nam', N'Hậu Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2130, N'Nguyễn Thuận Thanh', N'Content/upload/123020790nguyen_thuan_thanh.jpg', CAST(N'2002-09-22' AS Date), 187, N'Việt Nam', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2131, N'Nguyễn Toàn', N'Content/upload/1948237693nguyen_toan.jpg', CAST(N'2003-12-11' AS Date), 178, N'Việt Nam', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2132, N'Đặng Vân', N'Content/upload/1162370496van_dang.jpg', CAST(N'2002-03-17' AS Date), 169, N'Việt Nam', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2133, N'Phú Quý', N'Content/upload/8546385phu_quy.jpg', CAST(N'2001-03-26' AS Date), 174, N'Việt Nam', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2134, N'Lê Minh', N'Content/upload/156971027le_minh.jpg', CAST(N'2005-08-02' AS Date), 178, N'Việt Nam', N'Hậu Vệ')
GO
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2135, N'Hoài Ân', N'Content/upload/1754991423hoai_an.jpg', CAST(N'2001-09-11' AS Date), 180, N'Việt Nam', N'Tiền Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2136, N'Trương Trọng Nhân', N'Content/upload/399881805truong_trong_nhan.jpg', CAST(N'2002-04-09' AS Date), 180, N'Việt Nam', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2137, N'Nguyễn Quy', N'Content/upload/1976797515nguyen_quy.jpg', CAST(N'2000-05-06' AS Date), 175, N'Việt Nam', N'Tiền Đạo')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2138, N'Xuân Bách', N'Content/upload/492874312xuan_bach.jpg', CAST(N'2001-11-12' AS Date), 187, N'Việt Nam', N'Thủ Môn')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2139, N'Trương Trần Việt Anh', N'Content/upload/1125835980tran_truong_viet_anh.jpg', CAST(N'2002-04-07' AS Date), 175, N'Việt Nam', N'Trung Vệ')
INSERT [dbo].[CauThu] ([MaCauThu], [TenCauThu], [Avatar], [NgaySinh], [ChieuCao], [QuocTich], [ViTriThiDau]) VALUES (2140, N'Phạm Khánh', N'Content/upload/166542669pham_khanh.jpg', CAST(N'2003-12-01' AS Date), 185, N'Việt Nam', N'Hậu Vệ')
SET IDENTITY_INSERT [dbo].[CauThu] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhHieuCauThu] ON 

INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (1007, 19, 1032, N'Số bàn thắng', 5, 1)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (1008, 22, 1033, N'Số bàn thắng', 10, 2)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (1010, 20, 1032, N'Số bàn thắng', 2, 2)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (2006, 25, 1042, N'Tệ nhất Trận', 1, 1)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (2007, 20, 1035, N'Số bàn thắng', 2, 3)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (2008, 19, 1035, N'Số bàn thắng', 7, 2)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (2009, 25, 1042, N'Số bàn thắng', 8, 3)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (2010, 19, 1033, N'Số bàn thắng', 2, 1)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (3011, 1037, 1038, NULL, 4, 1)
INSERT [dbo].[DanhHieuCauThu] ([MaDanhHieuCauThu], [MaLichThiDau], [MaCauThu], [LoaiGiaiThuong], [SoLuong], [MaLoaiGiaiThuong]) VALUES (3012, 1040, 1038, NULL, 4, 1)
SET IDENTITY_INSERT [dbo].[DanhHieuCauThu] OFF
GO
SET IDENTITY_INSERT [dbo].[DoiBong] ON 

INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1003, N'Man City', N'Content/upload/439300615man-city.png', N'Pep Guardiola', N'Rodri', N'Tiền Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1004, N'Man Utd', N'Content/upload/11940499801200px-Manchester_United_FC_crest.svg[1].png', N'Ten Hat', N'Harry Magai', N'Trung Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1005, N'Arsenal', N'Content/upload/1255389376Arsenal.png', N'Ateta', N'Martin Odegaard', N'Tiền Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1014, N'Real Madrid', N'Content/upload/1531056422RealMadrid.png', N'Carlo Ancelotti', N' Jude Bellingham', N'Tiền Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1015, N'Barcelona', N'Content/upload/1468078590Barcelona.png', N'Xavi', N'Sergi Roberto', N'Tiền Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1016, N'Atl. Madrid', N'Content/upload/597219347AleticoMadrid.png', N'Diego Simeone', N'Antoine Griezmann', N'Tiền Đạo')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1017, N'Ath Bilbao', N'Content/upload/1223258195athbilbao.png', N'Ernesto Valverde', N'Nico Williams', N'Tiền Đạo')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1018, N'Tottenham', N'Content/upload/1267157537Totenham.png', N'Ange Postecoglou', N'Son Heung-min', N'Tiền Đạo')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1019, N'Chelsea', N'Content/upload/838181732chel.png', N'Mauricio Pochettino', N'Reece James', N'Hậu Vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1021, N'20DTHA1', N'Content/upload/189048974820DTHA1.png', N'Nguyễn Tấn Đạt', N'Nguyen Huu Tri', N'Hậu vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1022, N'20DTHA2', N'Content/upload/84425599820DTHA2.png', N'Trương Lê Quốc Đạt', N'Thanh Thai', N'Hậu vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1023, N'20DTHA3', N'Content/upload/136453434020DTHA3.png', N'Huỳnh Minh Phụng', N'Trung Truc', N'Hậu vệ')
INSERT [dbo].[DoiBong] ([MaDoiBong], [TenDoiBong], [Logo], [NguoiQuanLyCLB], [DoiTruong], [ViTri]) VALUES (1024, N'20DTHA4', N'Content/upload/6742812720DTHA4.png', N'Tài Phạm', N'Lê Minh', N'Hậu vệ')
SET IDENTITY_INSERT [dbo].[DoiBong] OFF
GO
SET IDENTITY_INSERT [dbo].[LichThiDau] ON 

INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (19, 1002, CAST(N'2023-12-22T11:00:00.000' AS DateTime), N'1', N'CMD', 1003, 1004, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (20, 1002, CAST(N'2023-12-22T14:18:00.000' AS DateTime), N'2', N'CDD', 1003, 1005, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (21, 1002, CAST(N'2023-12-22T17:20:00.000' AS DateTime), N'3', N'FM', 1003, 1015, 4, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (22, 1002, CAST(N'2023-12-22T20:21:00.000' AS DateTime), N'4', N'RM', 1004, 1003, 0, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (23, 1002, CAST(N'2023-12-23T21:21:00.000' AS DateTime), N'5', N'DK', 1004, 1005, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (24, 1002, CAST(N'2023-12-23T18:21:00.000' AS DateTime), N'6', N'KR', 1004, 1015, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (25, 1002, CAST(N'2023-12-23T14:21:00.000' AS DateTime), N'7', N'RE', 1005, 1003, 7, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (26, 1002, CAST(N'2023-12-23T07:22:00.000' AS DateTime), N'8', N'EFV', 1005, 1004, 8, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (27, 1002, CAST(N'2023-11-24T04:22:00.000' AS DateTime), N'9', N'RRR', 1005, 1015, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (28, 1002, CAST(N'2023-12-24T05:22:00.000' AS DateTime), N'10', N'FRE', 1015, 1003, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (29, 1002, CAST(N'2023-12-24T09:22:00.000' AS DateTime), N'11', N'GRT', 1015, 1004, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (30, 1002, CAST(N'2023-12-24T13:00:00.000' AS DateTime), N'12', NULL, 1015, 1005, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1034, 1007, CAST(N'2023-12-22T07:13:00.000' AS DateTime), N'1', N'ABC', 1014, 1015, 2, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1035, 1007, CAST(N'2023-12-22T19:13:00.000' AS DateTime), N'2', N'BBB', 1014, 1016, 1, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1036, 1007, CAST(N'2023-12-22T16:14:00.000' AS DateTime), N'3', N'AFM', 1014, 1017, 5, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1037, 1007, CAST(N'2023-12-22T19:15:00.000' AS DateTime), N'4', N'ACM', 1015, 1014, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1038, 1007, CAST(N'2023-12-23T09:17:00.000' AS DateTime), N'5', N'GM', 1015, 1016, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1039, 1007, CAST(N'2023-12-23T13:17:00.000' AS DateTime), N'6', N'GMM', 1015, 1017, 1, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1040, 1007, CAST(N'2023-12-23T21:17:00.000' AS DateTime), N'7', N'DK', 1016, 1014, 2, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1041, 1007, CAST(N'2023-12-23T13:18:00.000' AS DateTime), N'8', N'AFC', 1016, 1015, 2, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1042, 1007, CAST(N'2023-12-24T13:18:00.000' AS DateTime), N'9', N'MIami', 1016, 1017, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1043, 1007, CAST(N'2023-12-24T13:19:00.000' AS DateTime), N'10', N'ALC', 1017, 1014, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1044, 1007, CAST(N'2023-12-24T13:19:00.000' AS DateTime), N'11', N'MKC', 1017, 1015, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (1045, 1007, CAST(N'2023-12-24T19:19:00.000' AS DateTime), N'12', N'AEM', 1017, 1016, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2058, 3008, CAST(N'2024-05-10T13:11:00.000' AS DateTime), N'1', N'Khu E ', 1021, 1022, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2059, 3008, CAST(N'2024-05-12T13:12:00.000' AS DateTime), N'2', N'Khu E', 1023, 1024, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2060, 3008, CAST(N'2024-05-14T13:16:00.000' AS DateTime), N'3', N'Khu E', 1021, 1023, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2061, 3008, CAST(N'2024-05-16T13:16:00.000' AS DateTime), N'4', N'Khu E', 1022, 1024, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2062, 3008, CAST(N'2024-05-18T13:17:00.000' AS DateTime), N'5', N'Khu E', 1024, 1021, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (2064, 3008, CAST(N'2024-05-20T13:18:00.000' AS DateTime), N'6', N'Khu E', 1023, 1022, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3046, 1007, NULL, N'1', NULL, 1014, 1015, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3047, 1007, NULL, N'2', NULL, 1014, 1016, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3048, 1007, NULL, N'3', NULL, 1014, 1017, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3049, 1007, NULL, N'4', NULL, 1015, 1014, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3050, 1007, NULL, N'5', NULL, 1015, 1016, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3051, 1007, NULL, N'6', NULL, 1015, 1017, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3052, 1007, NULL, N'7', NULL, 1016, 1014, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3053, 1007, NULL, N'8', NULL, 1016, 1015, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3054, 1007, NULL, N'9', NULL, 1016, 1017, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3055, 1007, NULL, N'10', NULL, 1017, 1014, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3056, 1007, NULL, N'11', NULL, 1017, 1015, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[LichThiDau] ([MaLichThiDau], [MaGiaiDau], [NgayThiDau], [VongThiDau], [SanThiDau], [MaCLBChuNha], [MaCLBKhach], [TiSoCLBChuNha], [TiSoCLBKhach], [SoCuSut], [SutTrungDich], [SoLuongPenalties], [SoLuongDaPhat], [SoLuongPhatGoc], [SoLuongPhamLoi], [SoLuongVietVi], [SoTheVang], [SoTheDo], [BuGio], [KetQuaLuanLuu]) VALUES (3057, 1007, NULL, N'12', NULL, 1017, 1016, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LichThiDau] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiGiaiThuong] ON 

INSERT [dbo].[LoaiGiaiThuong] ([MaLoaiGiaiThuong], [TenLoaiGiaiThuong]) VALUES (1, N'Số bàn thắng')
INSERT [dbo].[LoaiGiaiThuong] ([MaLoaiGiaiThuong], [TenLoaiGiaiThuong]) VALUES (2, N'Số lần chuyền bóng')
INSERT [dbo].[LoaiGiaiThuong] ([MaLoaiGiaiThuong], [TenLoaiGiaiThuong]) VALUES (3, N'Thẻ vàng')
INSERT [dbo].[LoaiGiaiThuong] ([MaLoaiGiaiThuong], [TenLoaiGiaiThuong]) VALUES (4, N'Thẻ đỏ')
INSERT [dbo].[LoaiGiaiThuong] ([MaLoaiGiaiThuong], [TenLoaiGiaiThuong]) VALUES (5, N'Tệ nhất Trận')
SET IDENTITY_INSERT [dbo].[LoaiGiaiThuong] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2005, N'phung111', N'$2a$11$H5JfukQzqNogF/sNtFwOHeXamr3woWs9IHSCdPZabqq1fuqkimKZ2', N'huỳnh', N'phụng', CAST(N'1999-12-30' AS Date), N'phung1@gmail.com', N'123456789', N'Content/upload/634190842Erling_Haaland_2023_(cropped).jpg')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2006, N'phung111', N'$2a$11$LjOWOuVU6lZpbQf.4oBSuOhnk3FgvbLKow/o2Ed6xu5BiTFkh/.d.', N'h', N'p', CAST(N'2023-11-24' AS Date), N'phung123@gmail.com', N'123456789', N'Content/upload/1848330954Erling_Haaland_2023_(cropped).jpg')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2008, N'phung123', N'$2a$11$CxVieleMVt6.1ptIlpJVzushhjpIUfOQaRg13NSNvu/9VYwaRYwGC', N'Huỳnh', N'Phụng', CAST(N'2023-11-23' AS Date), N'phung123@gmail.com', N'123456789', N'Content/upload/1610885431Harry_Maguire_2018-07-11_1.jpg')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2009, N'phunghuynh', N'$2a$11$3bWGbuXKWmr2HbJLvBHnZOr0AVEt/Q2e.GqCA3Ay2FqRPfY9xa.eS', N'Huỳnh Minh', N'Phụng', CAST(N'1998-05-12' AS Date), N'phung@gmail.com', N'012345', N'Content/upload/194345810719-leandro-trossard-2709105612.jpg')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2014, N'kkkk', N'222', N'g', N'g', CAST(N'2023-11-09' AS Date), N'pp@gmail.com', N'147258', N'Content/upload/1012843725Harry_Maguire_2018-07-11_1.jpg')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [TenDangNhap], [MatKhau], [Ho], [Ten], [NgaySinh], [Email], [SoDienThoai], [Avatar]) VALUES (2015, N'phung', N'$2a$11$n45j3JXiGmjgsMgqqzmgaewVaG/Co4mMp3IIYwq9aV2iSiIqck2Li', N'Huỳnh Minh', N'Phụng', CAST(N'1998-05-23' AS Date), N'phung@gmail.com', N'0379009860', N'Content/upload/4172781739-darwin-nunez-2709131133.jpg')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyenNguoiDung] ON 

INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (3, 2014, 1, NULL)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (6, 2014, 1, NULL)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (11, 2008, 1, NULL)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (15, 2009, 1, NULL)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (16, 2005, 2, 1003)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (17, 2015, 1, NULL)
INSERT [dbo].[PhanQuyenNguoiDung] ([MaPhanQuyen], [MaNguoiDung], [MaVaiTro], [MaDoiBong]) VALUES (18, 2008, 2, 1018)
SET IDENTITY_INSERT [dbo].[PhanQuyenNguoiDung] OFF
GO
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1002, 1003)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1002, 1004)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1002, 1005)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1002, 1015)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1007, 1014)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1007, 1015)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1007, 1016)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (1007, 1017)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (3008, 1021)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (3008, 1022)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (3008, 1023)
INSERT [dbo].[QuanLyCLBVaGiaiDau] ([MaGiaiDau], [MaCLB]) VALUES (3008, 1024)
GO
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1024, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1025, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1026, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1028, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1033, 9)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1034, 17)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1035, 16)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 1042, 11)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2046, 11)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2047, 19)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2048, 24)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2049, 20)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2050, 47)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2051, 10)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2052, 2)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2053, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1003, 2054, 31)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 1025, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 1027, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 1029, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 1036, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 1037, 0)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2055, 17)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2056, 11)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2057, 10)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2058, 24)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2113, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2114, 8)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2115, 39)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2116, 18)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1004, 2117, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2066, 35)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2067, 29)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2068, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2069, 8)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2070, 41)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2071, 22)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2072, 9)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2073, 11)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2074, 18)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1005, 2118, 19)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 1041, 10)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 1042, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 2089, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 2090, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 2091, 8)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 2092, 15)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1014, 2093, 12)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 1038, 9)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 1039, 27)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2095, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2096, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2097, 2)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2098, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2099, 22)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2100, 8)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2101, 6)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2102, 21)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2103, 17)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1015, 2104, 11)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1016, 2105, 13)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1016, 2106, 16)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1016, 2107, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1016, 2108, 19)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1016, 2109, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1017, 2110, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1017, 2111, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1017, 2112, 14)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2082, 13)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2083, 17)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2084, 10)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2085, 18)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2086, 9)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2087, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1018, 2088, 21)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 1032, 24)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2075, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2076, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2077, 6)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2078, 8)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2079, 20)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2080, 7)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1019, 2081, 10)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1021, 2119, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1021, 2120, 2)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1021, 2121, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1021, 2122, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1021, 2123, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1022, 2124, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1022, 2125, 2)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1022, 2126, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1022, 2127, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1022, 2128, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1023, 2129, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1023, 2130, 2)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1023, 2131, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1023, 2132, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1023, 2133, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2134, 1)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2135, 2)
GO
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2136, 3)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2137, 4)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2138, 5)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2139, 6)
INSERT [dbo].[QuanLyDoiBongVaCauThu] ([MaDoiBong], [MaCauThu], [SoAo]) VALUES (1024, 2140, 7)
GO
SET IDENTITY_INSERT [dbo].[QuanLyGiaiDau] ON 

INSERT [dbo].[QuanLyGiaiDau] ([MaGiaiDau], [TenGiaiDau], [NamThucHien], [DonViToChuc], [SoLuongDoiThamGia], [NgayBatDau], [NgayKetThuc]) VALUES (1002, N'Ngoại hạng anh', 2023, N'England', 4, CAST(N'2023-12-20T00:00:00.000' AS DateTime), CAST(N'2023-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[QuanLyGiaiDau] ([MaGiaiDau], [TenGiaiDau], [NamThucHien], [DonViToChuc], [SoLuongDoiThamGia], [NgayBatDau], [NgayKetThuc]) VALUES (1007, N'La Liga', 2023, N'LFP', 4, CAST(N'2023-12-20T00:00:00.000' AS DateTime), CAST(N'2023-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[QuanLyGiaiDau] ([MaGiaiDau], [TenGiaiDau], [NamThucHien], [DonViToChuc], [SoLuongDoiThamGia], [NgayBatDau], [NgayKetThuc]) VALUES (3008, N'Sinh Viên Khoa IT Hutech', 2024, N'Hutech', 4, CAST(N'2024-05-10T00:00:00.000' AS DateTime), CAST(N'2024-05-20T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[QuanLyGiaiDau] OFF
GO
SET IDENTITY_INSERT [dbo].[VaiTro] ON 

INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro]) VALUES (1, N'Admin')
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro]) VALUES (2, N'Team')
SET IDENTITY_INSERT [dbo].[VaiTro] OFF
GO
ALTER TABLE [dbo].[DanhHieuCauThu]  WITH CHECK ADD  CONSTRAINT [FK__DanhHieuC__MaCau__4AB81AF0] FOREIGN KEY([MaCauThu])
REFERENCES [dbo].[CauThu] ([MaCauThu])
GO
ALTER TABLE [dbo].[DanhHieuCauThu] CHECK CONSTRAINT [FK__DanhHieuC__MaCau__4AB81AF0]
GO
ALTER TABLE [dbo].[DanhHieuCauThu]  WITH CHECK ADD  CONSTRAINT [FK__DanhHieuC__MaLic__49C3F6B7] FOREIGN KEY([MaLichThiDau])
REFERENCES [dbo].[LichThiDau] ([MaLichThiDau])
GO
ALTER TABLE [dbo].[DanhHieuCauThu] CHECK CONSTRAINT [FK__DanhHieuC__MaLic__49C3F6B7]
GO
ALTER TABLE [dbo].[LichThiDau]  WITH CHECK ADD  CONSTRAINT [FK__LichThiDa__MaCLB__403A8C7D] FOREIGN KEY([MaCLBChuNha])
REFERENCES [dbo].[DoiBong] ([MaDoiBong])
GO
ALTER TABLE [dbo].[LichThiDau] CHECK CONSTRAINT [FK__LichThiDa__MaCLB__403A8C7D]
GO
ALTER TABLE [dbo].[LichThiDau]  WITH CHECK ADD  CONSTRAINT [FK__LichThiDa__MaCLB__412EB0B6] FOREIGN KEY([MaCLBKhach])
REFERENCES [dbo].[DoiBong] ([MaDoiBong])
GO
ALTER TABLE [dbo].[LichThiDau] CHECK CONSTRAINT [FK__LichThiDa__MaCLB__412EB0B6]
GO
ALTER TABLE [dbo].[LichThiDau]  WITH CHECK ADD  CONSTRAINT [FK__LichThiDa__MaGia__3F466844] FOREIGN KEY([MaGiaiDau])
REFERENCES [dbo].[QuanLyGiaiDau] ([MaGiaiDau])
GO
ALTER TABLE [dbo].[LichThiDau] CHECK CONSTRAINT [FK__LichThiDa__MaGia__3F466844]
GO
ALTER TABLE [dbo].[PhanQuyenNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK__PhanQuyen__MaNgu__2F10007B] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[PhanQuyenNguoiDung] CHECK CONSTRAINT [FK__PhanQuyen__MaNgu__2F10007B]
GO
ALTER TABLE [dbo].[PhanQuyenNguoiDung]  WITH CHECK ADD  CONSTRAINT [FK__PhanQuyen__MaVai__300424B4] FOREIGN KEY([MaVaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
GO
ALTER TABLE [dbo].[PhanQuyenNguoiDung] CHECK CONSTRAINT [FK__PhanQuyen__MaVai__300424B4]
GO
ALTER TABLE [dbo].[QuanLyCLBVaGiaiDau]  WITH CHECK ADD  CONSTRAINT [FK__QuanLyCLB__MaCLB__3C69FB99] FOREIGN KEY([MaCLB])
REFERENCES [dbo].[DoiBong] ([MaDoiBong])
GO
ALTER TABLE [dbo].[QuanLyCLBVaGiaiDau] CHECK CONSTRAINT [FK__QuanLyCLB__MaCLB__3C69FB99]
GO
ALTER TABLE [dbo].[QuanLyCLBVaGiaiDau]  WITH CHECK ADD  CONSTRAINT [FK__QuanLyCLB__MaGia__3B75D760] FOREIGN KEY([MaGiaiDau])
REFERENCES [dbo].[QuanLyGiaiDau] ([MaGiaiDau])
GO
ALTER TABLE [dbo].[QuanLyCLBVaGiaiDau] CHECK CONSTRAINT [FK__QuanLyCLB__MaGia__3B75D760]
GO
ALTER TABLE [dbo].[QuanLyGiaiThuong]  WITH CHECK ADD  CONSTRAINT [FK__QuanLyGia__MaGia__34C8D9D1] FOREIGN KEY([MaGiaiDau])
REFERENCES [dbo].[QuanLyGiaiDau] ([MaGiaiDau])
GO
ALTER TABLE [dbo].[QuanLyGiaiThuong] CHECK CONSTRAINT [FK__QuanLyGia__MaGia__34C8D9D1]
GO
