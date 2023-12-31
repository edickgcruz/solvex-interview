USE [master]
GO
/****** Object:  Database [SOLVEX_INTERVIEW]    Script Date: 8/23/2023 3:20:32 PM ******/
CREATE DATABASE [SOLVEX_INTERVIEW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SOLVEX_INTERVIEW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SOLVEX_INTERVIEW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SOLVEX_INTERVIEW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SOLVEX_INTERVIEW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SOLVEX_INTERVIEW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ARITHABORT OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET  MULTI_USER 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET QUERY_STORE = OFF
GO
USE [SOLVEX_INTERVIEW]
GO
/****** Object:  Table [dbo].[Precio]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Precio] [numeric](10, 2) NOT NULL,
	[Color] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Passwd] [nvarchar](100) NOT NULL,
	[Rol] [nvarchar](100) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Precio] ADD  DEFAULT ((0)) FOR [Precio]
GO
/****** Object:  StoredProcedure [dbo].[BuscarTodosProductos]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BuscarTodosProductos] 

AS 
SELECT * FROM Producto
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearUsuario]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CrearUsuario]
(
    @Username nvarchar(100),
    @Passwd nvarchar(100),
	@Rol nvarchar(100)
)

AS		
BEGIN

INSERT INTO Usuario(
	Username,
	Passwd,
	Rol
)

VALUES 
(
	@Username,
	@Passwd,
	@Rol
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarProducto]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarProducto]
	(
	   @Id INT,
	   @Nombre nvarchar(200)
	)
AS
BEGIN
	UPDATE Producto SET
	Nombre = @Nombre
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CrearProducto]    Script Date: 8/23/2023 3:20:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CrearProducto]
(
	@Nombre nvarchar(200)
)
	
AS
BEGIN
	INSERT INTO Producto (Nombre) VALUES (@Nombre)
END
GO
USE [master]
GO
ALTER DATABASE [SOLVEX_INTERVIEW] SET  READ_WRITE 
GO
