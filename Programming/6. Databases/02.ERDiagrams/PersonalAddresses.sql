USE [master]
GO
/****** Object:  Database [PersonalAddresses]    Script Date: 23.8.2014 21:10:49 ******/
CREATE DATABASE [PersonalAddresses]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonalAddresses', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PersonalAddresses.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonalAddresses_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PersonalAddresses_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonalAddresses] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonalAddresses].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonalAddresses] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonalAddresses] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonalAddresses] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonalAddresses] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonalAddresses] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonalAddresses] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonalAddresses] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonalAddresses] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonalAddresses] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonalAddresses] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonalAddresses] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonalAddresses] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonalAddresses] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonalAddresses] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonalAddresses] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonalAddresses] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonalAddresses] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonalAddresses] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonalAddresses] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonalAddresses] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonalAddresses] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonalAddresses] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonalAddresses] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PersonalAddresses] SET  MULTI_USER 
GO
ALTER DATABASE [PersonalAddresses] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonalAddresses] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonalAddresses] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonalAddresses] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonalAddresses] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PersonalAddresses]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 23.8.2014 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [ntext] NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 23.8.2014 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[ContinentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 23.8.2014 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 23.8.2014 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_Persons_PersonId]  DEFAULT (newid()),
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 23.8.2014 21:10:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[TownName] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (1, N'ul.Bacho Kiro 12', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'ul.Vladajska 9', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'bul.Balgaria 23', 1)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (4, N'bul.Vitosha 150', 1)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (1, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (2, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (3, N'South America')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (4, N'North America')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (5, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (6, N'Australia')
INSERT [dbo].[Continents] ([ContinentId], [ContinentName]) VALUES (7, N'Antarctica')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (1, N'Bulgaria', 2)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (2, N'Serbia', 2)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (3, N'France', 2)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (4, N'Germany', 2)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (5, N'USA', 4)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (6, N'Canada', 4)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (7, N'Mexico', 4)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (8, N'Brasil', 3)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (9, N'Argentina', 3)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (10, N'Chile', 3)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (11, N'Egypt', 5)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (12, N'Nigeria', 5)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (13, N'South Africa', 5)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (14, N'China', 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (15, N'Japan', 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (16, N'South Korea', 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (17, N'Vietnam', 1)
INSERT [dbo].[Countries] ([CountryId], [CountryName], [ContinentId]) VALUES (18, N'Australia', 6)
SET IDENTITY_INSERT [dbo].[Countries] OFF
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'b87bdae2-7b58-427d-9ea0-0f58a517b968', N'Hristo', N'Denchev', 1)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'd0005fa6-9b20-4152-9f38-329d1b72d34b', N'Silvia', N'Todorova', 2)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'bf5d0724-48e0-47ef-ab85-62b4334a3092', N'Maia', N'Marinova', 4)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'114e07e1-6fa8-47e2-a4de-a2b0bb9b7bef', N'Philip', N'Plachkov', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'72e15760-6bb2-4a97-9b81-b15eab6e6098', N'Blaga', N'Todorova', 2)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'c99e56d0-7d8d-43b6-ab46-e0e10e4159d0', N'Ivaylo', N'Todorov', 2)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (N'45a6f5a2-bf59-47bc-8260-f853e68280c1', N'Maria', N'Dencheva', 1)
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (2, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (3, N'Burgas', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (4, N'Varna', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (5, N'Ruse', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (6, N'Vidin', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (7, N'Veliko Tarnovo', 1)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (8, N'Pirot', 2)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (9, N'Nish', 2)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (10, N'Belgrade', 2)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (11, N'Paris', 3)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (12, N'Cannes', 3)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (13, N'Montpellier', 3)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (14, N'Munchen', 4)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (15, N'Berlin', 4)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (16, N'Dresden', 4)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (17, N'Frankfurt', 4)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (18, N'New York', 5)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (19, N'Chicago', 5)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (20, N'Miami', 5)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (21, N'Boston', 5)
INSERT [dbo].[Towns] ([TownId], [TownName], [CountryId]) VALUES (22, N'Montreal', 6)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [PersonalAddresses] SET  READ_WRITE 
GO
