USE [master]
GO
/****** Object:  Database [DietSystem]    Script Date: 19/05/2022 03:47:15 ******/
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
/****** Object:  UserDefinedFunction [dbo].[Base64Encode]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Base64Encode]
(
    @bin VARBINARY(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN   
    return CAST(N'' AS XML).value('xs:base64Binary(xs:hexBinary(sql:variable("@bin")))', 'VARCHAR(MAX)')
END
GO
/****** Object:  UserDefinedFunction [dbo].[splitstring]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[splitstring] (@stringToSplit VARCHAR(MAX), @delimiter nvarchar(1)=',')
RETURNS
 @returnList TABLE ([Value] [nvarchar] (500))
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT

 WHILE CHARINDEX(@delimiter, @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(@delimiter, @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @name

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END

 INSERT INTO @returnList
 SELECT @stringToSplit

 RETURN
END
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 19/05/2022 03:47:15 ******/
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
	[CommentDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[DietitanID] [bigint] NOT NULL,
	[ContractPrice] [real] NOT NULL,
	[ContractStartDate] [datetime2](7) NOT NULL,
	[ContractEndDate] [datetime2](7) NOT NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[Weight] [real] NOT NULL,
	[Height] [real] NOT NULL,
	[BirthDay] [int] NOT NULL,
	[BirthMonth] [int] NULL,
	[BirthYear] [int] NULL,
	[AllergenicFood] [nvarchar](max) NULL,
	[Goal] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DietDetails]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietDetails](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[FoodID] [bigint] NOT NULL,
	[MeasureUnitID] [bigint] NOT NULL,
	[MealType] [nvarchar](max) NULL,
	[Quantity] [real] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[DietitianID] [bigint] NOT NULL,
	[ContractID] [bigint] NULL,
 CONSTRAINT [PK_DietDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dietitians]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dietitians](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[IsCertificate] [bit] NOT NULL,
	[IsCertificateVerDate] [datetime] NULL,
	[CityName] [nvarchar](max) NULL,
	[MonthlyPrice] [float] NULL,
	[CertificatePath] [nvarchar](max) NULL,
	[Bio] [nvarchar](max) NULL,
 CONSTRAINT [PK_Dietitians] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[FoodName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasureUnits]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasureUnits](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[MeasureUnitName] [nvarchar](max) NULL,
 CONSTRAINT [PK_MeasureUnits] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageDate] [datetime2](7) NOT NULL,
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
/****** Object:  Table [dbo].[Users]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[EPosta] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Password] [nvarchar](max) NULL,
	[VerifyToken] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts] ADD  CONSTRAINT [DF_Contracts_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Foods] ADD  CONSTRAINT [DF_Foods_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[MeasureUnits] ADD  CONSTRAINT [DF_MeasureUnits_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
/****** Object:  StoredProcedure [dbo].[spSelectDietitianViews]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSelectDietitianViews]
(
@CityList nvarchar(max) = null,
@MinPrice int = 0,
@MaxPrice int = null,
@StarList nvarchar(50) = null
)
AS
BEGIN

	set language turkish;

	select d.CityName as 'Sehir',isnull(cast(d.MonthlyPrice as nvarchar),0) + ' TL' as MonthlyPrice,
	d.ID as DietitianID,u.ID as UserID,
	u.EPosta,u.FullName,
	(select count(*) from dbo.Comments as c where c.DietitianID = d.ID) as CommentCount,
	(select cast(isnull(AVG(c.Score),0) as int) from dbo.Comments as c where c.DietitianID = d.ID) as ScoreAvg,
	(select count(*) from dbo.Contracts as co where co.DietitanID = d.ID and co.ContractEndDate > getdate()) as ActiveCustomer,
	SUBSTRING(isnull(d.Bio,''),1,151) + iif(LEN(d.Bio)>150,'...','') as ShortBio
	from dbo.Dietitians as d
	left outer join dbo.Users u on u.ID = d.UserID
	where d.IsCertificateVerDate is not null
	and (@StarList is null or (d.ID in (select ID from dbo.Comments co where co.DietitianID = d.ID and co.Score in (select * from dbo.splitstring(@StarList,',')))))
	and (@CityList is null or (d.CityName in (select * from dbo.splitstring(@CityList,','))))
	and (@MinPrice = 0 or (d.MonthlyPrice > @MinPrice))
	and (@MaxPrice is null or (d.MonthlyPrice < @MaxPrice))
END
GO
/****** Object:  StoredProcedure [dbo].[spSelectMessagesGrouping]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSelectMessagesGrouping]
(
@UserID bigint
)
AS
BEGIN
--declare @UserID bigint = 1


	select Result into #tmp from (
		select case when @UserID = SendedUserID then ReceiverUserID else SendedUserID end as Result from dbo.Messages
		where @UserID in (SendedUserID,ReceiverUserID)
	) as t
	group by t.Result

	select t.[ID]
      ,t.[MessageDate]
      ,t.[IsReaded]
      ,t.[MessageText]
      ,t.[SendedUserID]
      ,t.[ReceiverUserID]
	from (
		select m.*, row_number() over (partition by Result order by MessageDate desc) as seq
		from #tmp as tt
		left outer join dbo.Messages m on tt.Result in(m.ReceiverUserID,m.SendedUserID)
	) t
	where seq = 1;

	drop table #tmp

END
GO
/****** Object:  StoredProcedure [dbo].[spSelectTopDietitians]    Script Date: 19/05/2022 03:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spSelectTopDietitians]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select di.* from dbo.Dietitians di
	where di.ID in ((select top 10 c.DietitianID from dbo.Comments as c group by c.DietitianID having cast(isnull(AVG(c.Score),0) as int) > 3))
END
GO
USE [master]
GO
ALTER DATABASE [DietSystem] SET  READ_WRITE 
GO
