IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'WebApi')
BEGIN
	CREATE DATABASE [WebApi]

USE [WebApi]

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [varchar](500) NULL);


CREATE TABLE [dbo].[Cart](
	[IdCart] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL);