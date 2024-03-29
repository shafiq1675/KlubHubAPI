USE [KlubHub]
GO
/****** Object:  Table [dbo].[OrgType]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrgType]') AND type in (N'U'))
DROP TABLE [dbo].[OrgType]
GO
/****** Object:  Table [dbo].[Org]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Org]') AND type in (N'U'))
DROP TABLE [dbo].[Org]
GO
/****** Object:  Table [dbo].[MemberRole]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberRole]') AND type in (N'U'))
DROP TABLE [dbo].[MemberRole]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Member]') AND type in (N'U'))
DROP TABLE [dbo].[Member]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
DROP TABLE [dbo].[Event]
GO
/****** Object:  Table [dbo].[ClubMember]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClubMember]') AND type in (N'U'))
DROP TABLE [dbo].[ClubMember]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 3/18/2024 11:34:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Club]') AND type in (N'U'))
DROP TABLE [dbo].[Club]
GO
--USE [master]
--GO
--/****** Object:  Database [KlubHub]    Script Date: 3/18/2024 11:34:36 PM ******/
--DROP DATABASE [KlubHub]
--GO
--/****** Object:  Database [KlubHub]    Script Date: 3/18/2024 11:34:36 PM ******/
--CREATE DATABASE [KlubHub]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'KlubHub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KlubHub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'KlubHub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KlubHub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
--GO
--ALTER DATABASE [KlubHub] SET COMPATIBILITY_LEVEL = 150
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [KlubHub].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [KlubHub] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [KlubHub] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [KlubHub] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [KlubHub] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [KlubHub] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [KlubHub] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [KlubHub] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [KlubHub] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [KlubHub] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [KlubHub] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [KlubHub] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [KlubHub] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [KlubHub] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [KlubHub] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [KlubHub] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [KlubHub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [KlubHub] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [KlubHub] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [KlubHub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [KlubHub] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [KlubHub] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [KlubHub] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [KlubHub] SET RECOVERY FULL 
--GO
--ALTER DATABASE [KlubHub] SET  MULTI_USER 
--GO
--ALTER DATABASE [KlubHub] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [KlubHub] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [KlubHub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [KlubHub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
--GO
--ALTER DATABASE [KlubHub] SET DELAYED_DURABILITY = DISABLED 
--GO
--ALTER DATABASE [KlubHub] SET ACCELERATED_DATABASE_RECOVERY = OFF  
--GO
--EXEC sys.sp_db_vardecimal_storage_format N'KlubHub', N'ON'
--GO
--ALTER DATABASE [KlubHub] SET QUERY_STORE = OFF
--GO
USE [KlubHub]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Club](
	[ClubId] [int] IDENTITY(1000,1) NOT NULL,
	[ClubName] [nvarchar](500) NULL,
	[OrgId] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[ContactNumber] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK__Club__D35058E7C69A5245] PRIMARY KEY CLUSTERED 
(
	[ClubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Club] ADD  CONSTRAINT [DF_Club_OrgId]  DEFAULT ((0)) FOR [OrgId]
GO
/****** Object:  Table [dbo].[ClubMember]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubMember](
	[ClubMemberId] [int] IDENTITY(1,1) NOT NULL,
	[ClubId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClubMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(10000,1) NOT NULL,
	[EventName] [varchar](1000) NOT NULL,
	[EventDescription] [varchar](1000) NULL,
	[EventPlace] [varchar](1000) NOT NULL,
	[ImageUrl] [varchar](1000) NULL,
	[From] [datetime] NOT NULL,
	[To] [datetime] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(100000,1) NOT NULL,
	[MemberFullName] [nvarchar](500) NOT NULL,
	[MemberUserName] [nvarchar](500) NULL,
	[MemberEmail] [nvarchar](100) NOT NULL,
	[MemberContactNumber] [nvarchar](50) NULL,
	[Password] [nvarchar](500) NOT NULL,
	[MemberRoleId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK__Member__3213E83F6E38D79B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberRole]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberRole](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_MemberRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Org]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Org](
	[OrgId] [int] IDENTITY(1,1) NOT NULL,
	[OrgName] [nvarchar](500) NULL,
	[OrgTypeId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Org] PRIMARY KEY CLUSTERED 
(
	[OrgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgType]    Script Date: 3/18/2024 11:34:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgType](
	[OrgTypeId] [int] IDENTITY(1,1) NOT NULL,
	[OrgTypeName] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_OrgType] PRIMARY KEY CLUSTERED 
(
	[OrgTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Club] ON 

INSERT [dbo].[Club] ([ClubId], [ClubName], [Description], [Address], [Email], [ImageUrl], [ContactNumber], [CreatedDate], [ModifiedDate], [IsDeleted], [IsActive], [CreatedBy]) VALUES (1000, N'Dhaka University', N'description', N'Dhakla', N'du@gmail.com', N'asdkf', N'0154555', CAST(N'2024-03-06T20:53:44.130' AS DateTime), CAST(N'2024-03-06T20:53:44.130' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Club] ([ClubId], [ClubName], [Description], [Address], [Email], [ImageUrl], [ContactNumber], [CreatedDate], [ModifiedDate], [IsDeleted], [IsActive], [CreatedBy]) VALUES (1001, N'JU Debate Club', N'JU Debate Club', N'Savar, Dhaka', N'islam.mdshafiq@gmail.com', N'ss', N'123', CAST(N'2024-03-06T23:12:04.780' AS DateTime), CAST(N'2024-03-06T23:12:04.780' AS DateTime), 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Club] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100000, N'Shafiqul Islam', N'shafiq_1675', N'shafiq@gmail.com', NULL, N'123', 1, CAST(N'2024-03-02T00:00:00.000' AS DateTime), CAST(N'2024-03-02T00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100001, N'Arif Matubbar', N'arif', N'arif@gmail.com', N'01738767493', N'123', 0, CAST(N'2024-03-05T11:56:35.023' AS DateTime), CAST(N'2024-03-05T11:56:35.023' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100002, N'Chastity Gregory', NULL, N'ac@gmail.com', N'979', N'0', 0, CAST(N'2024-03-05T20:28:39.390' AS DateTime), CAST(N'2024-03-05T20:28:39.893' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100003, N'Aiko Randall', N'qiwif', N'ar@gmail.com', N'675', N'123', 0, CAST(N'2024-03-05T20:42:13.240' AS DateTime), CAST(N'2024-03-05T20:42:13.240' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100004, N'Shohana Akter', N'sa_1999', N'sa@gmail.com', N'01738767495', N'123', 0, CAST(N'2024-03-05T23:27:38.053' AS DateTime), CAST(N'2024-03-05T23:27:38.053' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100005, N'Jabed', N'arif_matubbar', N'', N'4', N'123456', 0, CAST(N'2024-03-05T23:30:22.293' AS DateTime), CAST(N'2024-03-05T23:30:22.457' AS DateTime), 0, 0)
INSERT [dbo].[Member] ([Id], [MemberFullName], [MemberUserName], [MemberEmail], [MemberContactNumber], [Password], [MemberRoleId], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (100006, N'Oasim', N'j_123', N'j@gmail.com', N'8556', N'123', 0, CAST(N'2024-03-05T23:31:32.590' AS DateTime), CAST(N'2024-03-05T23:31:32.590' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberRole] ON 

INSERT [dbo].[MemberRole] ([RoleId], [RoleName], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (1, N'System Admin', CAST(N'2024-03-03T00:00:00.000' AS DateTime), CAST(N'2024-03-03T00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[MemberRole] ([RoleId], [RoleName], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (2, N'Admin', CAST(N'2024-03-03T00:00:00.000' AS DateTime), CAST(N'2024-03-03T00:00:00.000' AS DateTime), 0, 0)
INSERT [dbo].[MemberRole] ([RoleId], [RoleName], [CreatedDate], [ModifiedDate], [IsDeleted], [CreatedBy]) VALUES (3, N'Member', CAST(N'2024-03-03T00:00:00.000' AS DateTime), CAST(N'2024-03-03T00:00:00.000' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[MemberRole] OFF
GO
USE [master]
GO
ALTER DATABASE [KlubHub] SET  READ_WRITE 
GO
