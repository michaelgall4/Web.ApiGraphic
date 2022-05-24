USE [WebApi]
GO

/****** Object:  Table [dbo].[Prodotto]    Script Date: 5/24/2022 5:34:50 PM ******/


CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [varchar](500) NULL);


