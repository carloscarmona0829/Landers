Este proyecto tiene funcional

1. Agregar Productos
2. Listar Productos
3. Cargar combo desde la bd


Todo a 3 capas (DA, RN y presentación), 
adicionalemente una capa para los accesos sql 
y una mas para entidades.

Falta Pulir 

************* SCRIPTS BD ****************
CREATE DATABASE [Universal]

**********************************************
USE [Universal]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 8/05/2022 9:34:21 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Imagen] [varchar](50) NOT NULL,
	[Stock] [int] NOT NULL,
	[Precio] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


***********************************************
USE [Proyectos]
GO

/****** Object:  Table [dbo].[tblProyectos]    Script Date: 4/05/2022 5:39:30 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblProyectos](
	[Numero_Consecutivo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Objetivo] [varchar](200) NOT NULL,
	[Fecha_Inicio] [varchar](20) NOT NULL,
	[Duracion_Estimada] [int] NOT NULL,
	[Valor_estimado] [int] NOT NULL,
	[Id_Tipo_Proyecto] [int] NOT NULL,
	[Ciudad_Ejecucion] [varchar](30) NOT NULL,
	[Id_Usuario] [varchar](20) NOT NULL,
	[Id_Estado] [int] NOT NULL,
	[Fecha_Matricula] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblProyectos] PRIMARY KEY CLUSTERED 
(
	[Numero_Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblProyectos]  WITH CHECK ADD  CONSTRAINT [FK_tblProyectos_tblEstados] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[tblEstados] ([Id])
GO

ALTER TABLE [dbo].[tblProyectos] CHECK CONSTRAINT [FK_tblProyectos_tblEstados]
GO

ALTER TABLE [dbo].[tblProyectos]  WITH CHECK ADD  CONSTRAINT [FK_tblProyectos_tblTipos_Proyectos] FOREIGN KEY([Id_Tipo_Proyecto])
REFERENCES [dbo].[tblTipos_Proyectos] ([Id])
GO

ALTER TABLE [dbo].[tblProyectos] CHECK CONSTRAINT [FK_tblProyectos_tblTipos_Proyectos]
GO

ALTER TABLE [dbo].[tblProyectos]  WITH CHECK ADD  CONSTRAINT [FK_tblProyectos_tblUsuario] FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[tblUsuario] ([Id])
GO

ALTER TABLE [dbo].[tblProyectos] CHECK CONSTRAINT [FK_tblProyectos_tblUsuario]
GO

***********************************************
USE [Universal]
GO

/****** Object:  Table [dbo].[Categoria]    Script Date: 8/05/2022 9:35:48 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tipos_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
***********************************************

USE [Universal]
GO
/****** Object:  StoredProcedure [dbo].[sp_Productos_CRUD]    Script Date: 8/05/2022 9:36:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[sp_Proyectos_CRUD]    Script Date: 8/05/2022 6:16:04 a. m. ******/

--EXECUTE sp_Productos_CRUD 'INSERTAR','Producto10','Descripción Producto11',1,'Imagen Producto11',11,110
--EXECUTE sp_Productos_CRUD 'ACTUALIZAR','Producto12','Descripción Producto12',2,'Imagen Producto12',12,120
--EXECUTE sp_Productos_CRUD 'ELIMINAR','Producto10'
--EXECUTE sp_Productos_CRUD 'BUSCAR','','',3
--EXECUTE sp_Productos_CRUD 'LISTAR'

ALTER PROCEDURE [dbo].[sp_Productos_CRUD]	
@Accion VARCHAR(20),
@Nombre  VARCHAR(50)='',
@Descripcion  VARCHAR(500)='',
@Id_Categoria INT=0,
@Imagen VARCHAR(50)='',
@Stock  INT=0,
@Precio INT=0,
@Estado INT=1

AS
BEGIN		
	IF @Accion = 'INSERTAR'
	 BEGIN	

		IF NOT EXISTS(SELECT @Nombre FROM Productos WHERE Nombre = @Nombre)
		BEGIN
			INSERT INTO Productos(Nombre, Descripcion, Id_Categoria, Imagen, Stock, Precio, Estado)
			VALUES (@Nombre, @Descripcion, @Id_Categoria, @Imagen, @Stock, @Precio, @Estado)
					
			SELECT '0' AS SW, 'Producto Registrado Exitosamente' AS MENSAJE		
		END
		ELSE
		BEGIN
			EXECUTE sp_Productos_CRUD 'ACTUALIZAR',@Nombre, @Descripcion, @Id_Categoria, @Imagen, @Stock, @Precio, @Estado
	 END
	END
	
	IF @Accion = 'ACTUALIZAR'
	BEGIN		
			UPDATE Productos SET    Nombre=@Nombre,
									Descripcion=@Descripcion,
									Id_Categoria=@Id_Categoria,
									Imagen=@Imagen,
									Stock=@Stock,
									Precio=@Precio,
									Estado=@Estado
			WHERE Nombre=@Nombre
					
		SELECT '0' AS SW, 'Producto Actualizado Exitosamente' AS MENSAJE	
	END

	IF @Accion = 'ELIMINAR'
	BEGIN
		UPDATE Productos SET Estado = 0
		WHERE Nombre=@Nombre
		
	SELECT '0' AS SW, 'Producto Eliminado Exitosamente' AS MENSAJE		
	END

	IF @Accion = 'BUSCAR'
	BEGIN
		SELECT Nombre, Descripcion, Id_Categoria, Imagen, Stock, Precio       
		FROM Productos 
		WHERE Nombre=@Nombre OR Descripcion=@Descripcion OR Id_Categoria=@Id_Categoria AND Estado=1
	END

	IF @Accion = 'LISTAR'
	BEGIN
		SELECT Nombre, Descripcion, Id_Categoria, Imagen, Stock, Precio
	    FROM       Productos               
	    WHERE      Productos.Estado = 1	
	END

END

***********************************************
USE [Universal]
GO
/****** Object:  StoredProcedure [dbo].[sp_CargaDdl_Categoria]    Script Date: 8/05/2022 9:36:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE sp_CargaDdl_Categoria
ALTER PROCEDURE [dbo].[sp_CargaDdl_Categoria]

AS
BEGIN

	SELECT Id, Categoria AS Valor
	FROM Categoria
	WHERE Estado = 1 
	
END
