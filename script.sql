
USE [CariHesap]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 9/18/2019 14:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[categoryId] [int] NOT NULL,
	[categoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/18/2019 14:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [int] NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[customerSurname] [nvarchar](50) NOT NULL,
	[customerPhone] [nvarchar](50) NOT NULL,
	[customerAddress] [nvarchar](50) NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/18/2019 14:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productId] [int] NOT NULL,
	[productName] [nvarchar](50) NOT NULL,
	[categoryId] [int] NOT NULL,
	[buyPrice] [int] NOT NULL,
	[sellPrice] [int] NOT NULL,
	[stockCount] [int] NOT NULL,
	[description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleDapertment]    Script Date: 9/18/2019 14:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDapertment](
	[salesId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[sellDate] [datetime] NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_SaleDapertment] PRIMARY KEY CLUSTERED 
(
	[salesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/18/2019 14:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[userPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([categoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[SaleDapertment]  WITH CHECK ADD  CONSTRAINT [FK_SaleDapertment_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([customerId])
GO
ALTER TABLE [dbo].[SaleDapertment] CHECK CONSTRAINT [FK_SaleDapertment_Customers]
GO
ALTER TABLE [dbo].[SaleDapertment]  WITH CHECK ADD  CONSTRAINT [FK_SaleDapertment_Products] FOREIGN KEY([productId])
REFERENCES [dbo].[Products] ([productId])
GO
ALTER TABLE [dbo].[SaleDapertment] CHECK CONSTRAINT [FK_SaleDapertment_Products]
GO
