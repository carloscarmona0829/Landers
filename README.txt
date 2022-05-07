********************************************************************************
		CATÁLOGO DE PRODUCTOS UNIVERSAL - LANDERS
********************************************************************************

Aplicación CRUD de productos para un catálogo
					ReactJS, 
					APIRESTful, 
					NET6.0, 
					SQLServer2019.

--------------------------------------------------------------------------------


CREATE DATABASE [Universal]
********************************************************************************
USE [Universal]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Imagen] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [int] NOT NULL
) ON [PRIMARY]
GO
********************************************************************************