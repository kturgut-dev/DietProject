USE [master]
GO
/****** Object:  Database [DietSystem]    Script Date: 23/02/2022 21:46:14 ******/
CREATE DATABASE [DietSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DietSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DietSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DietSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DietSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DietSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DietSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DietSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DietSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DietSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DietSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DietSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [DietSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DietSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DietSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DietSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DietSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DietSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DietSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DietSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DietSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DietSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DietSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DietSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DietSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DietSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DietSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DietSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DietSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DietSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DietSystem] SET  MULTI_USER 
GO
ALTER DATABASE [DietSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DietSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DietSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DietSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DietSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DietSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DietSystem] SET QUERY_STORE = OFF
GO
USE [DietSystem]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DietitianID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[Score] [int] NOT NULL,
	[CommentText] [nvarchar](max) NULL,
	[CommentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[DietitanID] [bigint] NOT NULL,
	[ContractPrice] [float] NOT NULL,
	[ContractStartDate] [datetime] NOT NULL,
	[ContractEndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Weight] [float] NULL,
	[Height] [float] NULL,
	[BirthDate] [datetime] NULL,
	[AllergenicFood] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DietDetails]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[FoodID] [bigint] NOT NULL,
	[MeasureUnitID] [bigint] NULL,
	[MealType] [nvarchar](50) NULL,
	[Quantity] [float] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[DietitianID] [bigint] NOT NULL,
 CONSTRAINT [PK_DietDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dietitians]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dietitians](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[IsCertificate] [bit] NOT NULL,
	[IsCertificateVerDate] [datetime] NULL,
	[CityName] [nvarchar](50) NULL,
	[MonthlyPrice] [float] NULL,
 CONSTRAINT [PK_Dietitian] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[FoodName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageDate] [datetime] NOT NULL,
	[IsReaded] [bit] NOT NULL,
	[MessageText] [nvarchar](max) NULL,
	[SendedUserID] [bigint] NOT NULL,
	[ReceiverUserID] [bigint] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/02/2022 21:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[EPosta] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_Score]  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_CommentDate]  DEFAULT (getdate()) FOR [CommentDate]
GO
ALTER TABLE [dbo].[Contracts] ADD  CONSTRAINT [DF_Contracts_ContractStartDate]  DEFAULT (getdate()) FOR [ContractStartDate]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Weight]  DEFAULT ((0)) FOR [Weight]
GO
ALTER TABLE [dbo].[DietDetails] ADD  CONSTRAINT [DF_DietDetails_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[DietDetails] ADD  CONSTRAINT [DF_DietDetails_IsCompleted]  DEFAULT ((0)) FOR [IsCompleted]
GO
ALTER TABLE [dbo].[DietDetails] ADD  CONSTRAINT [DF_DietDetails_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Dietitians] ADD  CONSTRAINT [DF_Dietitian_IsCertificate]  DEFAULT ((0)) FOR [IsCertificate]
GO
ALTER TABLE [dbo].[Dietitians] ADD  CONSTRAINT [DF_Table_1_Price]  DEFAULT ((0)) FOR [MonthlyPrice]
GO
ALTER TABLE [dbo].[Foods] ADD  CONSTRAINT [DF_Foods_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_MessageDate]  DEFAULT (getdate()) FOR [MessageDate]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_IsReaded]  DEFAULT ((0)) FOR [IsReaded]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'öğün' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DietDetails', @level2type=N'COLUMN',@level2name=N'MealType'
GO
USE [master]
GO
ALTER DATABASE [DietSystem] SET  READ_WRITE 
GO
