USE [master]
GO
/****** Object:  Database [patikaFinalProject]    Script Date: 15/02/2023 22:12:39 ******/
CREATE DATABASE [patikaFinalProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'patikaFinalProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\patikaFinalProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'patikaFinalProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\patikaFinalProject_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [patikaFinalProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [patikaFinalProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [patikaFinalProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [patikaFinalProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [patikaFinalProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [patikaFinalProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [patikaFinalProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [patikaFinalProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [patikaFinalProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [patikaFinalProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [patikaFinalProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [patikaFinalProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [patikaFinalProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [patikaFinalProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [patikaFinalProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [patikaFinalProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [patikaFinalProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [patikaFinalProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [patikaFinalProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [patikaFinalProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [patikaFinalProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [patikaFinalProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [patikaFinalProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [patikaFinalProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [patikaFinalProject] SET RECOVERY FULL 
GO
ALTER DATABASE [patikaFinalProject] SET  MULTI_USER 
GO
ALTER DATABASE [patikaFinalProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [patikaFinalProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [patikaFinalProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [patikaFinalProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [patikaFinalProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [patikaFinalProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'patikaFinalProject', N'ON'
GO
ALTER DATABASE [patikaFinalProject] SET QUERY_STORE = OFF
GO
USE [patikaFinalProject]
GO
/****** Object:  User [newUser]    Script Date: 15/02/2023 22:12:39 ******/
CREATE USER [newUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [dbJava]    Script Date: 15/02/2023 22:12:39 ******/
CREATE USER [dbJava] FOR LOGIN [dbJava] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Oyuncu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorID] [int] NOT NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_Oyuncu_Film] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC,
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerFavType]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerFavType](
	[CustomerID] [int] NOT NULL,
	[FavMovieTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Customer_FavoriTür] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[FavMovieTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Yönetmen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MovieName] [nchar](10) NULL,
	[MovieYear] [date] NULL,
	[MovieTypeID] [int] NULL,
	[DirectorID] [int] NULL,
	[Price] [int] NULL,
	[isSold] [bit] NULL,
 CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieType]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_FilmTürleri] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15/02/2023 22:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[MovieID] [int] NULL,
	[Price] [int] NULL,
	[OrderDate] [datetime] NULL,
 CONSTRAINT [PK_Siparişler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 

INSERT [dbo].[Actor] ([ID], [Name], [Surname]) VALUES (1, N'Actor1', N'Actor1S')
INSERT [dbo].[Actor] ([ID], [Name], [Surname]) VALUES (2, N'Actor2', N'Actor2S')
INSERT [dbo].[Actor] ([ID], [Name], [Surname]) VALUES (3, N'Actor3', N'Actor3S')
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [Name], [Surname]) VALUES (3, N'Customer3', N'Customer3S')
INSERT [dbo].[Customer] ([ID], [Name], [Surname]) VALUES (4, N'Customer4', N'Customer4S')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[CustomerFavType] ([CustomerID], [FavMovieTypeID]) VALUES (3, 1)
INSERT [dbo].[CustomerFavType] ([CustomerID], [FavMovieTypeID]) VALUES (3, 2)
INSERT [dbo].[CustomerFavType] ([CustomerID], [FavMovieTypeID]) VALUES (4, 3)
GO
SET IDENTITY_INSERT [dbo].[Director] ON 

INSERT [dbo].[Director] ([ID], [Name], [Surname]) VALUES (1, N'Director1', N'Director1')
INSERT [dbo].[Director] ([ID], [Name], [Surname]) VALUES (2, N'Director2', N'Director2S')
SET IDENTITY_INSERT [dbo].[Director] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([ID], [MovieName], [MovieYear], [MovieTypeID], [DirectorID], [Price], [isSold]) VALUES (2, N'movie2    ', CAST(N'2023-02-10' AS Date), 2, 1, 110, 0)
INSERT [dbo].[Movie] ([ID], [MovieName], [MovieYear], [MovieTypeID], [DirectorID], [Price], [isSold]) VALUES (5, N'movie3    ', CAST(N'2022-01-01' AS Date), 3, 1, 100, 0)
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieType] ON 

INSERT [dbo].[MovieType] ([ID], [Type]) VALUES (1, N'Comedy')
INSERT [dbo].[MovieType] ([ID], [Type]) VALUES (2, N'Horror')
INSERT [dbo].[MovieType] ([ID], [Type]) VALUES (3, N'Action')
SET IDENTITY_INSERT [dbo].[MovieType] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [CustomerID], [MovieID], [Price], [OrderDate]) VALUES (2, 3, 2, 110, CAST(N'2023-02-10T20:33:21.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_Oyuncu_Film_Film] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movie] ([ID])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_Oyuncu_Film_Film]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_Oyuncu_Film_Oyuncu] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actor] ([ID])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_Oyuncu_Film_Oyuncu]
GO
ALTER TABLE [dbo].[CustomerFavType]  WITH CHECK ADD  CONSTRAINT [FK_Customer_FavoriTür_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[CustomerFavType] CHECK CONSTRAINT [FK_Customer_FavoriTür_Customer]
GO
ALTER TABLE [dbo].[CustomerFavType]  WITH CHECK ADD  CONSTRAINT [FK_Customer_FavoriTür_FilmTürleri] FOREIGN KEY([FavMovieTypeID])
REFERENCES [dbo].[MovieType] ([ID])
GO
ALTER TABLE [dbo].[CustomerFavType] CHECK CONSTRAINT [FK_Customer_FavoriTür_FilmTürleri]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Film_Yönetmen] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Director] ([ID])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Film_Yönetmen]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_MovieType] FOREIGN KEY([MovieTypeID])
REFERENCES [dbo].[MovieType] ([ID])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_MovieType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Siparişler_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Siparişler_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Siparişler_Film] FOREIGN KEY([ID])
REFERENCES [dbo].[Movie] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Siparişler_Film]
GO
USE [master]
GO
ALTER DATABASE [patikaFinalProject] SET  READ_WRITE 
GO
