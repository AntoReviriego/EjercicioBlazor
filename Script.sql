CREATE DATABASE [EjercicioBlazor]

USE [EjercicioBlazor]
GO

CREATE TABLE [dbo].[Categoria](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[IdCategoriaPadre] [bigint] NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Marca](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](350) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Producto](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](max) NOT NULL,
	[Descripcion] [nvarchar](350) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Id_marca] [bigint] NOT NULL,
	[Id_categoria] [bigint] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([Id_categoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([Id_marca])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO

INSERT INTO [dbo].[Categoria] ([Descripcion] ,[IdCategoriaPadre] ,[InsertDate] ,[UpdateDate] ,[Enable])
     VALUES
           ('Indumentaria', NULL, GETDATE(), GETDATE(), 1 )
GO

INSERT INTO [dbo].[Marca] ([Descripcion] ,[InsertDate] ,[UpdateDate] ,[Enable])
     VALUES
           ('ADIDAS', GETDATE(), GETDATE(), 1)
GO
