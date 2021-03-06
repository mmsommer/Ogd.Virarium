USE [master]
GO
/****** Object:  Database [VirariumData]    Script Date: 08/21/2012 09:38:33 ******/
CREATE DATABASE [VirariumData] ON  PRIMARY 
( NAME = N'VirariumData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\VirariumData.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VirariumData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\VirariumData_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VirariumData] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VirariumData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VirariumData] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [VirariumData] SET ANSI_NULLS OFF
GO
ALTER DATABASE [VirariumData] SET ANSI_PADDING OFF
GO
ALTER DATABASE [VirariumData] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [VirariumData] SET ARITHABORT OFF
GO
ALTER DATABASE [VirariumData] SET AUTO_CLOSE ON
GO
ALTER DATABASE [VirariumData] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [VirariumData] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [VirariumData] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [VirariumData] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [VirariumData] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [VirariumData] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [VirariumData] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [VirariumData] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [VirariumData] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [VirariumData] SET  ENABLE_BROKER
GO
ALTER DATABASE [VirariumData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [VirariumData] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [VirariumData] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [VirariumData] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [VirariumData] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [VirariumData] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [VirariumData] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [VirariumData] SET  READ_WRITE
GO
ALTER DATABASE [VirariumData] SET RECOVERY SIMPLE
GO
ALTER DATABASE [VirariumData] SET  MULTI_USER
GO
ALTER DATABASE [VirariumData] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [VirariumData] SET DB_CHAINING OFF
GO
USE [VirariumData]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[MachineType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Virusses]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Virusses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchemaInfo]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchemaInfo](
	[Version] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Version] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NICs]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NICs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineId] [int] NOT NULL,
	[IpAddress] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Infections]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MachineId] [int] NOT NULL,
	[VirusId] [int] NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connections]    Script Date: 08/21/2012 09:38:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NICAId] [int] NOT NULL,
	[NICBId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_NICs_MachineId_Machines_Id]    Script Date: 08/21/2012 09:38:35 ******/
ALTER TABLE [dbo].[NICs]  WITH CHECK ADD  CONSTRAINT [FK_NICs_MachineId_Machines_Id] FOREIGN KEY([MachineId])
REFERENCES [dbo].[Machines] ([Id])
GO
ALTER TABLE [dbo].[NICs] CHECK CONSTRAINT [FK_NICs_MachineId_Machines_Id]
GO
/****** Object:  ForeignKey [FK_Infections_MachineId_Machines_Id]    Script Date: 08/21/2012 09:38:35 ******/
ALTER TABLE [dbo].[Infections]  WITH CHECK ADD  CONSTRAINT [FK_Infections_MachineId_Machines_Id] FOREIGN KEY([MachineId])
REFERENCES [dbo].[Machines] ([Id])
GO
ALTER TABLE [dbo].[Infections] CHECK CONSTRAINT [FK_Infections_MachineId_Machines_Id]
GO
/****** Object:  ForeignKey [FK_Infections_VirusId_Virusses_Id]    Script Date: 08/21/2012 09:38:35 ******/
ALTER TABLE [dbo].[Infections]  WITH CHECK ADD  CONSTRAINT [FK_Infections_VirusId_Virusses_Id] FOREIGN KEY([VirusId])
REFERENCES [dbo].[Virusses] ([Id])
GO
ALTER TABLE [dbo].[Infections] CHECK CONSTRAINT [FK_Infections_VirusId_Virusses_Id]
GO
/****** Object:  ForeignKey [FK_Connections_NICAId_NICs_Id]    Script Date: 08/21/2012 09:38:35 ******/
ALTER TABLE [dbo].[Connections]  WITH CHECK ADD  CONSTRAINT [FK_Connections_NICAId_NICs_Id] FOREIGN KEY([NICAId])
REFERENCES [dbo].[NICs] ([Id])
GO
ALTER TABLE [dbo].[Connections] CHECK CONSTRAINT [FK_Connections_NICAId_NICs_Id]
GO
/****** Object:  ForeignKey [FK_Connections_NICBId_NICs_Id]    Script Date: 08/21/2012 09:38:35 ******/
ALTER TABLE [dbo].[Connections]  WITH CHECK ADD  CONSTRAINT [FK_Connections_NICBId_NICs_Id] FOREIGN KEY([NICBId])
REFERENCES [dbo].[NICs] ([Id])
GO
ALTER TABLE [dbo].[Connections] CHECK CONSTRAINT [FK_Connections_NICBId_NICs_Id]
GO
