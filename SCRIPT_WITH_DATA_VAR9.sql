/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2017 (14.0.1000)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Express Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2017
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Standard Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [master]
GO
/****** Object:  Database [DEMO_2022_VAR9]    Script Date: 20.12.2022 16:37:20 ******/
CREATE DATABASE [DEMO_2022_VAR9]
GO
USE [DEMO_2022_VAR9]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 20.12.2022 16:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatusID] [int] NOT NULL,
	[PickupPointID] [int] NOT NULL,
	[OrderCreateDate] [datetime] NOT NULL,
	[OrderDeliveryDate] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[OrderGetCode] [int] NOT NULL,
 CONSTRAINT [PK__Order__C3905BAFAD93ECDB] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 20.12.2022 16:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[OrderProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[OrderProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 20.12.2022 16:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusID] [int] NOT NULL,
	[OrderStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PickupPoint]    Script Date: 20.12.2022 16:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PickupPoint](
	[PickupPointID] [int] NOT NULL,
	[Address] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PickUpPoint] PRIMARY KEY CLUSTERED 
(
	[PickupPointID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20.12.2022 16:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductArticleNumber] [nvarchar](100) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[UnitTypeID] [int] NOT NULL,
	[ProductCost] [decimal](19, 4) NOT NULL,
	[ProductMaxDiscountAmount] [tinyint] NULL,
	[ProductManufacturerID] [int] NOT NULL,
	[ProductSupplierID] [int] NOT NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductDiscountAmount] [tinyint] NULL,
	[ProductQuantityInStock] [int] NOT NULL,
	[ProductDescription] [nvarchar](max) NOT NULL,
	[ProductPhoto] [nvarchar](100) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [int] NOT NULL,
	[ProductCategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductManufacturer]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductManufacturer](
	[ProductManufacturerID] [int] NOT NULL,
	[ProductManufacturerName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ProductManufacturer] PRIMARY KEY CLUSTERED 
(
	[ProductManufacturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSupplier]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSupplier](
	[ProductSupplierID] [int] NOT NULL,
	[ProductSupplierName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ProductSupplier] PRIMARY KEY CLUSTERED 
(
	[ProductSupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnitType]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitType](
	[UnitTypeID] [int] NOT NULL,
	[UnitTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UnitType] PRIMARY KEY CLUSTERED 
(
	[UnitTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.12.2022 16:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserLogin] [nvarchar](max) NOT NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[UserSurname] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserPatronymic] [nvarchar](100) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (1, 1, 18, CAST(N'2022-05-19T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), NULL, 501)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (2, 1, 20, CAST(N'2022-05-19T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), NULL, 502)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (3, 2, 22, CAST(N'2022-05-21T00:00:00.000' AS DateTime), CAST(N'2022-05-27T00:00:00.000' AS DateTime), 51, 503)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (4, 1, 24, CAST(N'2022-05-22T00:00:00.000' AS DateTime), CAST(N'2022-05-28T00:00:00.000' AS DateTime), 52, 504)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (5, 1, 26, CAST(N'2022-05-23T00:00:00.000' AS DateTime), CAST(N'2022-05-29T00:00:00.000' AS DateTime), NULL, 505)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (6, 1, 28, CAST(N'2022-05-24T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), 53, 506)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (7, 1, 30, CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), NULL, 507)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (8, 1, 32, CAST(N'2022-05-26T00:00:00.000' AS DateTime), CAST(N'2022-06-01T00:00:00.000' AS DateTime), NULL, 508)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (9, 1, 34, CAST(N'2022-05-27T00:00:00.000' AS DateTime), CAST(N'2022-06-02T00:00:00.000' AS DateTime), 54, 509)
INSERT [dbo].[Order] ([OrderID], [OrderStatusID], [PickupPointID], [OrderCreateDate], [OrderDeliveryDate], [UserID], [OrderGetCode]) VALUES (10, 2, 36, CAST(N'2022-05-28T00:00:00.000' AS DateTime), CAST(N'2022-06-03T00:00:00.000' AS DateTime), NULL, 510)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderProduct] ON 

INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (1, 1, 1, 10)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (2, 2, 1, 10)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (3, 4, 2, 5)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (4, 5, 2, 5)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (5, 7, 3, 2)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (6, 8, 3, 2)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (7, 12, 4, 1)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (8, 13, 4, 2)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (9, 14, 5, 3)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (10, 15, 5, 3)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (11, 17, 6, 2)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (12, 18, 6, 2)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (13, 19, 7, 1)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (14, 20, 7, 1)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (15, 21, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (16, 22, 8, 10)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (17, 23, 9, 5)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (18, 24, 9, 5)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (19, 28, 10, 5)
INSERT [dbo].[OrderProduct] ([OrderProductID], [ProductID], [OrderID], [Count]) VALUES (20, 29, 10, 5)
SET IDENTITY_INSERT [dbo].[OrderProduct] OFF
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (1, N'Новый ')
INSERT [dbo].[OrderStatus] ([OrderStatusID], [OrderStatusName]) VALUES (2, N'Завершен')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (1, N'344288, г. Абакан, ул. Чехова, 1')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (2, N'614164, г.Абакан,  ул. Степная, 30')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (3, N'394242, г. Абакан, ул. Коммунистическая, 43')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (4, N'660540, г. Абакан, ул. Солнечная, 25')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (5, N'125837, г. Абакан, ул. Шоссейная, 40')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (6, N'125703, г. Абакан, ул. Партизанская, 49')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (7, N'625283, г. Абакан, ул. Победы, 46')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (8, N'614611, г. Абакан, ул. Молодежная, 50')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (9, N'454311, г.Абакан, ул. Новая, 19')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (10, N'660007, г.Абакан, ул. Октябрьская, 19')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (11, N'603036, г. Абакан, ул. Садовая, 4')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (12, N'450983, г.Абакан, ул. Комсомольская, 26')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (13, N'394782, г. Абакан, ул. Чехова, 3')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (14, N'603002, г. Абакан, ул. Дзержинского, 28')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (15, N'450558, г. Абакан, ул. Набережная, 30')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (16, N'394060, г.Абакан, ул. Фрунзе, 43')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (17, N'410661, г. Абакан, ул. Школьная, 50')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (18, N'625590, г. Абакан, ул. Коммунистическая, 20')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (19, N'625683, г. Абакан, ул. 8 Марта')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (20, N'400562, г. Абакан, ул. Зеленая, 32')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (21, N'614510, г. Абакан, ул. Маяковского, 47')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (22, N'410542, г. Абакан, ул. Светлая, 46')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (23, N'620839, г. Абакан, ул. Цветочная, 8')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (24, N'443890, г. Абакан, ул. Коммунистическая, 1')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (25, N'603379, г. Абакан, ул. Спортивная, 46')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (26, N'603721, г. Абакан, ул. Гоголя, 41')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (27, N'410172, г. Абакан, ул. Северная, 13')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (28, N'420151, г. Абакан, ул. Вишневая, 32')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (29, N'125061, г. Абакан, ул. Подгорная, 8')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (30, N'630370, г. Абакан, ул. Шоссейная, 24')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (31, N'614753, г. Абакан, ул. Полевая, 35')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (32, N'426030, г. Абакан, ул. Маяковского, 44')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (33, N'450375, г. Абакан ул. Клубная, 44')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (34, N'625560, г. Абакан, ул. Некрасова, 12')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (35, N'630201, г. Абакан, ул. Комсомольская, 17')
INSERT [dbo].[PickupPoint] ([PickupPointID], [Address]) VALUES (36, N'190949, г. Абакан, ул. Мичурина, 26')
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (1, N'M37WHA', N'Катушка', 1, CAST(1750.0000 AS Decimal(19, 4)), 10, 1, 1, 1, 3, 20, N'Катушка Stinger Arctic Char Trigger 105L', N'M37WHA.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (2, N'EJ9GSG', N'Катушка', 1, CAST(520.0000 AS Decimal(19, 4)), 5, 1, 1, 1, 2, 13, N'Катушка Stinger Arctic Char', N'EJ9GSG.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (3, N'SOIPEQ', N'Катушка', 1, CAST(600.0000 AS Decimal(19, 4)), 5, 1, 1, 1, 5, 22, N'Катушка Stinger Arctic Char XP', N'SOIPEQ.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (4, N'M3UEHS', N'Катушка', 1, CAST(810.0000 AS Decimal(19, 4)), 10, 1, 1, 1, 2, 27, N'Катушка Stinger Arctic Char Pro', N'M3UEHS.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (5, N'PILLFW', N'Блесна', 1, CAST(300.0000 AS Decimal(19, 4)), 11, 1, 1, 2, 10, 8, N'Блесна Stinger 305-080', N'PILLFW.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (6, N'PCIS4E', N'Блесна', 1, CAST(440.0000 AS Decimal(19, 4)), 4, 2, 2, 2, 15, 30, N'Kuusamo Professor 4 50/8', N'PCIS4E.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (7, N'M6XARO', N'Воблер', 1, CAST(200.0000 AS Decimal(19, 4)), 3, 3, 3, 2, 6, 16, N'Воблеры Usami Wasabi Vib', N'M6XARO.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (8, N'L4Y4MS', N'Мормышка', 1, CAST(360.0000 AS Decimal(19, 4)), 6, 4, 4, 2, 2, 25, N'Мормышка LumiCom Дробина с отверстием', N'L4Y4MS.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (9, N'6Z2TGT', N'Балансир', 1, CAST(500.0000 AS Decimal(19, 4)), 9, 2, 2, 2, 2, 7, N'Kuusamo Tasapaino X-PRO', N'6Z2TGT.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (10, N'MGIP6R', N'Балансир', 1, CAST(120.0000 AS Decimal(19, 4)), 5, 3, 3, 2, 12, 12, N'Балансир Usami Dansa Pike Special', N'MGIP6R.jpg')
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (11, N'LXB2A9', N'Мормышка', 1, CAST(900.0000 AS Decimal(19, 4)), 4, 4, 4, 2, 5, 8, N'Мормышка W LumiCom Капля с ушком ', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (12, N'Q50897', N'Ящик зимний', 1, CAST(1350.0000 AS Decimal(19, 4)), 10, 5, 5, 3, 9, 19, N'Ящик зимний Aquatech', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (13, N'105BV8', N'Палатка зимняя', 1, CAST(600.0000 AS Decimal(19, 4)), 3, 6, 6, 3, 8, 25, N'Палатка зимняя SevereLand IT210', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (14, N'A0ZBSB', N'Штаны', 1, CAST(7450.0000 AS Decimal(19, 4)), 6, 7, 7, 3, 3, 31, N'Штаны утепленные Westin W4 2-Layer Bibs', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (15, N'JE6VN0', N'Рукавицы', 1, CAST(600.0000 AS Decimal(19, 4)), 9, 6, 6, 3, 4, 1, N'Рукавицы SevereLand Snow Visor', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (16, N'BJJ2XD', N'Черпак', 1, CAST(410.0000 AS Decimal(19, 4)), 5, 2, 2, 3, 1, 28, N'Черпак Kuusamo 90мм', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (17, N'OACIX8', N'Шапка-маска ', 1, CAST(950.0000 AS Decimal(19, 4)), 9, 6, 6, 3, 12, 19, N'Шапка-маска SevereLand Sub Zero', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (18, N'V5KORQ', N'Термобелье', 1, CAST(1000.0000 AS Decimal(19, 4)), 4, 6, 6, 3, 13, 16, N'Термобелье SevereLand DryShield', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (19, N'MVIR2L', N'Леска Ultron Elite ', 1, CAST(100.0000 AS Decimal(19, 4)), 10, 8, 8, 4, 14, 13, N'Леска Ultron Elite Platinum Winter 30m', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (20, N'OU1EGM', N'Леска  Balsax Ice', 1, CAST(70.0000 AS Decimal(19, 4)), 5, 9, 9, 4, 1, 28, N'Леска Balsax Ice King', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (21, N'R25FXL', N'Леска Momoi Hi-Max ', 1, CAST(80.0000 AS Decimal(19, 4)), 5, 10, 10, 4, 6, 10, N'Леска Momoi Hi-Max Sky Blue', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (22, N'R7N43T', N'Леска Balsax Ice ', 1, CAST(30.0000 AS Decimal(19, 4)), 10, 9, 9, 4, 9, 3, N'Леска Balsax Ice Power', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (23, N'8JICK8', N'Леска Gamma Ice ', 1, CAST(280.0000 AS Decimal(19, 4)), 11, 11, 11, 4, 10, 4, N'Леска Gamma Ice Fluorocarbon', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (24, N'PDLQ16', N'Кивок рессорный', 1, CAST(1200.0000 AS Decimal(19, 4)), 4, 1, 1, 5, 12, 25, N'Кивки рессорные Stinger Баланс-R', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (25, N'E6IZV3', N'Кивок лавсановый', 1, CAST(500.0000 AS Decimal(19, 4)), 3, 1, 1, 5, 8, 15, N'Кивок лавсановый спортивный Stinger', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (26, N'OQIXDR', N'Кивок силиконовый', 1, CAST(350.0000 AS Decimal(19, 4)), 6, 1, 1, 5, 4, 12, N'Кивок силиконовый Stinger', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (27, N'CZ96A8', N'Кормушка', 1, CAST(130.0000 AS Decimal(19, 4)), 9, 5, 5, 5, 13, 27, N'Кормушка Aquatech большая', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (28, N'B4DS9I', N'Кормушка', 1, CAST(65.0000 AS Decimal(19, 4)), 5, 5, 5, 5, 9, 6, N'Кормушка Aquatech малая', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (29, N'UEOGV3', N'Наконечник', 1, CAST(400.0000 AS Decimal(19, 4)), 4, 2, 2, 5, 4, 15, N'Kuusamo Tele Kirppu Mormy', NULL)
INSERT [dbo].[Product] ([ProductID], [ProductArticleNumber], [ProductName], [UnitTypeID], [ProductCost], [ProductMaxDiscountAmount], [ProductManufacturerID], [ProductSupplierID], [ProductCategoryID], [ProductDiscountAmount], [ProductQuantityInStock], [ProductDescription], [ProductPhoto]) VALUES (30, N'504KAE', N'Наконечник', 1, CAST(400.0000 AS Decimal(19, 4)), 10, 2, 2, 5, 10, 14, N'Kuusamo Tele Kirppu 5-10g', NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryName]) VALUES (1, N'Катушки')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryName]) VALUES (2, N'Приманки')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryName]) VALUES (3, N'Амуниция и снаряжение')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryName]) VALUES (4, N'Леска')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [ProductCategoryName]) VALUES (5, N'Оснастка')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (1, N'Stinger')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (2, N'Kuusamo')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (3, N'Usami')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (4, N'LumiCom')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (5, N'Aquatech')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (6, N'SevereLand')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (7, N'Westin')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (8, N'Ultron')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (9, N'Balsax')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (10, N'Momoi')
INSERT [dbo].[ProductManufacturer] ([ProductManufacturerID], [ProductManufacturerName]) VALUES (11, N'Gamma')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (1, N'Stinger')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (2, N'Kuusamo')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (3, N'Usami')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (4, N'LumiCom')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (5, N'Aquatech')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (6, N'SevereLand')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (7, N'Westin')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (8, N'Ultron')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (9, N'Balsax')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (10, N'Momoi')
INSERT [dbo].[ProductSupplier] ([ProductSupplierID], [ProductSupplierName]) VALUES (11, N'Gamma')
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Менеджер')
SET IDENTITY_INSERT [dbo].[Role] OFF
INSERT [dbo].[UnitType] ([UnitTypeID], [UnitTypeName]) VALUES (1, N'шт.')
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (1, N'loginDEsgg2018', N'qhgYnW', N'Константинова ', N'Вероника', N'Агафоновна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (2, N'loginDEdcd2018', N'LxR6YI', N'Меркушев ', N'Мартын', N'Федотович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (3, N'loginDEisg2018', N'Cp8ddU', N'Казаков ', N'Федот', N'Кондратович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (4, N'loginDEcph2018', N'7YpE0p', N'Карпов ', N'Улеб', N'Леонидович', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (5, N'loginDEgco2018', N'nMr|ss', N'Королёв ', N'Матвей', N'Вадимович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (6, N'loginDEwjg2018', N'9UfqWQ', N'Юдин ', N'Герман', N'Кондратович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (7, N'loginDEjbz2018', N'xIAWNI', N'Беляева ', N'Анна', N'Вячеславовна', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (8, N'loginDEmgu2018', N'0gC3bk', N'Беляев ', N'Валентин', N'Артёмович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (9, N'loginDErdg2018', N'ni0ue0', N'Семёнов ', N'Герман', N'Дмитрьевич', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (10, N'loginDEjtv2018', N'f2ZaN6', N'Шестаков ', N'Илья', N'Антонинович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (11, N'loginDEtfj2018', N'{{ksPn', N'Власов ', N'Вадим', N'Васильевич', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (12, N'loginDEpnb2018', N'{ADBdc', N'Савельев ', N'Арсений', N'Авксентьевич', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (13, N'loginDEzer2018', N'5&R+zs', N'Ефимов ', N'Руслан', N'Якунович', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (14, N'loginDEiin2018', N'y9l*b}', N'Бурова ', N'Марфа', N'Федотовна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (15, N'loginDEqda2018', N'|h+r}I', N'Селезнёв ', N'Александр', N'Никитевич', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (16, N'loginDEbnj2018', N'#ИМЯ?', N'Кулакова ', N'Виктория', N'Георгьевна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (17, N'loginDEqte2018', N'dC8bDI', N'Дорофеева ', N'Кира', N'Демьяновна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (18, N'loginDEfeo2018', N'8cI7vq', N'Сафонова ', N'Нинель', N'Якововна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (19, N'loginDEvni2018', N'e4pVIv', N'Ситникова ', N'София', N'Лукьевна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (20, N'loginDEjis2018', N'A9K++2', N'Медведев ', N'Ириней', N'Геннадьевич', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (21, N'loginDExvv2018', N'R1zh}|', N'Суханова ', N'Евгения', N'Улебовна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (22, N'loginDEadl2018', N'F&IWf4', N'Игнатьев ', N'Владлен', N'Дамирович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (23, N'loginDEyzn2018', N'P1v24R', N'Ефремов ', N'Христофор', N'Владиславович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (24, N'loginDEphn2018', N'F}jGsJ', N'Кошелев ', N'Ростислав', N'Куприянович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (25, N'loginDEdvk2018', N'NKNkup', N'Галкина ', N'Тамара', N'Авксентьевна', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (26, N'loginDEtld2018', N'c+CECK', N'Журавлёва ', N'Вера', N'Арсеньевна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (27, N'loginDEima2018', N'XK3sOA', N'Савина ', N'Таисия', N'Глебовна', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (28, N'loginDEyfe2018', N'4Bbzpa', N'Иванов ', N'Яков', N'Мэлорович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (29, N'loginDEwqc2018', N'vRtAP*', N'Лыткин ', N'Ким', N'Алексеевич', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (30, N'loginDEgtt2018', N'7YD|BR', N'Логинов ', N'Федот', N'Святославович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (31, N'loginDEiwl2018', N'LhlmIl', N'Русакова ', N'Марина', N'Юлиановна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (32, N'loginDEyvi2018', N'22beR}', N'Константинов ', N'Пётр', N'Кондратович', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (33, N'loginDEtfz2018', N'uQY0ZQ', N'Поляков ', N'Анатолий', N'Игоревич', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (34, N'loginDEikb2018', N'*QkUxc', N'Панфилова ', N'Василиса', N'Григорьевна', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (35, N'loginDEdmi2018', N'HOGFbU', N'Воробьёв ', N'Герман', N'Романович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (36, N'loginDEtlo2018', N'58Jxrg', N'Андреев ', N'Ростислав', N'Федосеевич', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (37, N'loginDEsnd2018', N'lLHqZf', N'Бобров ', N'Агафон', N'Владимирович', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (38, N'loginDEgno2018', N'4fqLiO', N'Лапин ', N'Алексей', N'Витальевич', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (39, N'loginDEgnl2018', N'wdio{u', N'Шестаков ', N'Авдей', N'Иванович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (40, N'loginDEzna2018', N'yz1iMB', N'Гаврилова ', N'Алина', N'Эдуардовна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (41, N'loginDEsyh2018', N'&4jYGs', N'Жуков ', N'Юлиан', N'Валерьянович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (42, N'loginDExex2018', N'rnh36{', N'Пономарёв ', N'Максим', N'Альвианович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (43, N'loginDEdjm2018', N'KjI1JR', N'Зиновьева ', N'Мария', N'Лаврентьевна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (44, N'loginDEgup2018', N'36|KhF', N'Осипов ', N'Артём', N'Мэлорович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (45, N'loginDEdat2018', N'ussd8Q', N'Лапин ', N'Вячеслав', N'Геласьевич', 2)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (46, N'loginDEffj2018', N'cJP+HC', N'Зуев ', N'Ириней', N'Вадимович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (47, N'loginDEisp2018', N'dfz5Ii', N'Коновалова ', N'Агафья', N'Митрофановна', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (48, N'loginDEfrp2018', N'6dcR|9', N'Исаев ', N'Дмитрий', N'Аристархович', 3)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (49, N'loginDEaee2018', N'5&qONH', N'Белозёрова ', N'Алевтина', N'Лаврентьевна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (50, N'loginDEthu2018', N'|0xWzV', N'Самсонов ', N'Агафон', N'Максимович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (51, N'user51', N'abc1', N'Куликов', N'Владислав', N'Даниилович', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (52, N'user52', N'abc2', N'Коротков', N'Олег', N'Матвеевич', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (53, N'user53', N'abc3', N'Климова', N'Алиса', N'Александровна', 1)
INSERT [dbo].[User] ([UserID], [UserLogin], [UserPassword], [UserSurname], [UserName], [UserPatronymic], [RoleID]) VALUES (54, N'user54', N'abc4', N'Евдокимова', N'Ариана', N'Михайловна', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[OrderStatus] ([OrderStatusID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_OrderStatus]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PickupPoint] FOREIGN KEY([PickupPointID])
REFERENCES [dbo].[PickupPoint] ([PickupPointID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PickupPoint]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[ProductCategory] ([ProductCategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductManufacturer] FOREIGN KEY([ProductManufacturerID])
REFERENCES [dbo].[ProductManufacturer] ([ProductManufacturerID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductManufacturer]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductSupplier] FOREIGN KEY([ProductSupplierID])
REFERENCES [dbo].[ProductSupplier] ([ProductSupplierID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductSupplier]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_UnitType] FOREIGN KEY([UnitTypeID])
REFERENCES [dbo].[UnitType] ([UnitTypeID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_UnitType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [DEMO_2022_VAR9] SET  READ_WRITE 
GO
