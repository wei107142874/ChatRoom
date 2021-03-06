USE [master]
GO
/****** Object:  Database [CR]    Script Date: 08/02/2017 16:11:41 ******/
CREATE DATABASE [CR] ON  PRIMARY 
( NAME = N'CR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CR.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CR_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CR] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CR].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [CR] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CR] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CR] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CR] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CR] SET ARITHABORT OFF
GO
ALTER DATABASE [CR] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CR] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CR] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CR] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CR] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CR] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CR] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CR] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CR] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CR] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CR] SET  DISABLE_BROKER
GO
ALTER DATABASE [CR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CR] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CR] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CR] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CR] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CR] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CR] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CR] SET  READ_WRITE
GO
ALTER DATABASE [CR] SET RECOVERY FULL
GO
ALTER DATABASE [CR] SET  MULTI_USER
GO
ALTER DATABASE [CR] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CR] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'CR', N'ON'
GO
USE [CR]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08/02/2017 16:11:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](80) NOT NULL,
	[NickName] [nvarchar](20) NOT NULL,
	[HeadUrl] [nvarchar](100) NOT NULL,
	[UserType] [char](1) NOT NULL,
	[LoginDate] [datetime] NULL,
	[RegisteredDate] [datetime] NOT NULL,
	[ZhuxiaoDate] [datetime] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：离线  1在线  2:进入房间 3：房主 4：备选房主' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserType'
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (12, N'140016539', N'E10ADC3949BA59ABBE56E057F20F883E', N'140016539', N'Images/Headportrait/Headportrait4.jpg', N'4', CAST(0x0000A7C200CE2AF5 AS DateTime), CAST(0x0000A57D00C657E5 AS DateTime), CAST(0x0000A57E00A53473 AS DateTime))
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (13, N'140016535', N'E10ADC3949BA59ABBE56E057F20F883E', N'140016535', N'Images/Headportrait/Headportrait1.jpg', N'3', CAST(0x0000A57E009A9AEC AS DateTime), CAST(0x0000A57D00C67F0B AS DateTime), CAST(0x0000A57E009A9899 AS DateTime))
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (14, N'140016537', N'E10ADC3949BA59ABBE56E057F20F883E', N'140016537', N'Images/Headportrait/Headportrait1.jpg', N'0', NULL, CAST(0x0000A57D00C68C1E AS DateTime), NULL)
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (15, N'140016549', N'E10ADC3949BA59ABBE56E057F20F883E', N'140016549', N'Images/Headportrait/Headportrait3.jpg', N'0', CAST(0x0000A57E008CDC11 AS DateTime), CAST(0x0000A57D00C6C25B AS DateTime), CAST(0x0000A57E008CE478 AS DateTime))
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (16, N'123345423', N'202CB962AC59075B964B07152D234B70', N'士大夫士大夫', N'Images/Headportrait/Headportrait3.jpg', N'0', NULL, CAST(0x0000A57D0113D015 AS DateTime), NULL)
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Password], [NickName], [HeadUrl], [UserType], [LoginDate], [RegisteredDate], [ZhuxiaoDate]) VALUES (17, N'dingyunchao', N'4297F44B13955235245B2497399D7A93', N'chao', N'Images/Headportrait/Headportrait4.jpg', N'0', CAST(0x0000A57E00A1B5B7 AS DateTime), CAST(0x0000A57E00A1A9FF AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser_ZhuxiaoDate]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateUser_ZhuxiaoDate]
	@UserID int,
	@ZhuxiaoDate datetime,
	@UserType char
AS
BEGIN
	UPDATE [dbo].[UserInfo]
   SET 
      ZhuxiaoDate = @ZhuxiaoDate,UserType=@UserType
      
 WHERE UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser_LoginDate]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateUser_LoginDate]
	@UserID int,
	@LoginDate datetime,
	@UserType char
AS
BEGIN
	UPDATE [dbo].[UserInfo]
   SET 
      LoginDate = @LoginDate,UserType=@UserType
      
 WHERE UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Registered]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE 	[dbo].[sp_Registered]
	@UserName   nvarchar(15),
	@Password nvarchar(80),
	@NickName nvarchar(20),
	@HeadUrl nvarchar(100),
	@RegisteredDate datetime
AS
BEGIN
	INSERT INTO [dbo].[UserInfo]
           ([UserName]
           ,[Password]
           ,[NickName]
           ,[HeadUrl]
           ,RegisteredDate)
     VALUES
           (@UserName,
		   @Password,
		   @NickName,
		   @HeadUrl,
		   @RegisteredDate)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Login]
	@UserName nvarchar(15),
	@Password nvarchar(80)
AS
BEGIN
	
	SET NOCOUNT ON;
	select * from UserInfo where UserName=@UserName and [Password]=@Password
END
GO
/****** Object:  Table [dbo].[RoomInfo]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomInfo](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](20) NOT NULL,
	[RommDesc] [nvarchar](200) NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_RoomInfo] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoomInfo] ON
INSERT [dbo].[RoomInfo] ([RoomID], [RoomName], [RommDesc], [UserID]) VALUES (3086, N'风花雪月', N'阿三打', 13)
SET IDENTITY_INSERT [dbo].[RoomInfo] OFF
/****** Object:  StoredProcedure [dbo].[sp_GetUserNameByUserInfo]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserNameByUserInfo]
	@UserName nvarchar(15)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * from UserInfo where UserName=@UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserNameByUserID]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserNameByUserID]
	@UserName nvarchar(15)
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT * from  UserInfo Where UserName=@UserName;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserIDByRoomInfo]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserIDByRoomInfo]
	@UserID int
AS
BEGIN
	
	SET NOCOUNT ON;

   select * from RoomInfo where UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoomIDUpdateRoomInfo]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetRoomIDUpdateRoomInfo]
	@RoomName nvarchar(20),
	@RommDesc nvarchar(200),
	@UserID int
AS
BEGIN
	UPDATE RoomInfo Set RoomName=@RoomName, RommDesc=@RommDesc Where UserID=@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateRoom]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CreateRoom] 
	@RoomName nvarchar(20),
	@RommDesc nvarchar(200),
	@UserID int
AS
BEGIN
	
	INSERT INTO [dbo].[RoomInfo]
           ([RoomName]
           ,[RommDesc]
           ,[UserID])
     VALUES
           (@RoomName,
		   @RommDesc,
		   @UserID
		   )
END
GO
/****** Object:  Table [dbo].[RoomUser]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomUser](
	[RoomUserID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[GOtoRoomDate] [datetime] NOT NULL,
	[leaveRoomDate] [datetime] NULL,
 CONSTRAINT [PK_RoomUser] PRIMARY KEY CLUSTERED 
(
	[RoomUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoomUser] ON
INSERT [dbo].[RoomUser] ([RoomUserID], [RoomID], [UserID], [GOtoRoomDate], [leaveRoomDate]) VALUES (3159, 3086, 13, CAST(0x0000A57E00A0CD03 AS DateTime), NULL)
INSERT [dbo].[RoomUser] ([RoomUserID], [RoomID], [UserID], [GOtoRoomDate], [leaveRoomDate]) VALUES (3165, 3086, 12, CAST(0x0000A7C200CE3025 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[RoomUser] OFF
/****** Object:  Table [dbo].[ChatContent]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatContent](
	[ChatContentID] [int] IDENTITY(1,1) NOT NULL,
	[SendUserName] [nvarchar](20) NOT NULL,
	[ReceiveUserName] [nvarchar](20) NULL,
	[SendDateTime] [datetime] NOT NULL,
	[MsgContent] [text] NOT NULL,
	[RoomID] [int] NOT NULL,
 CONSTRAINT [PK_ChatContent] PRIMARY KEY CLUSTERED 
(
	[ChatContentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChatContent] ON
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2307, N'140016535', N'', CAST(0x0000A57E013AE9FF AS DateTime), N'阿斯顿', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2308, N'140016535', N'', CAST(0x0000A57E013B105C AS DateTime), N'阿斯顿', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2309, N'140016539', N'', CAST(0x0000A7C200AD0939 AS DateTime), N'123', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2310, N'140016539', N'', CAST(0x0000A7C200AD0CDD AS DateTime), N'123', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2311, N'140016539', N'', CAST(0x0000A7C200AD66E9 AS DateTime), N'123', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2312, N'140016539', N'', CAST(0x0000A7C200AD7AAA AS DateTime), N'我是你爸爸
', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2313, N'140016539', N'', CAST(0x0000A7C200AD81F7 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2314, N'140016539', N'', CAST(0x0000A7C200AD8505 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2315, N'140016539', N'', CAST(0x0000A7C200AD8544 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2316, N'140016539', N'', CAST(0x0000A7C200AD8580 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2317, N'140016539', N'', CAST(0x0000A7C200AD85B9 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2318, N'140016539', N'', CAST(0x0000A7C200AD85F6 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2319, N'140016539', N'', CAST(0x0000A7C200AD862F AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2320, N'140016539', N'', CAST(0x0000A7C200AD8685 AS DateTime), N'1111', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2321, N'140016535', N'', CAST(0x0000A7C200ADBD3C AS DateTime), N'你说啥子嘛', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2322, N'140016535', N'', CAST(0x0000A7C200ADC2D2 AS DateTime), N'你说啥子嘛', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2323, N'140016535', N'', CAST(0x0000A7C200ADD358 AS DateTime), N'啊', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2324, N'140016535', N'', CAST(0x0000A7C200ADF476 AS DateTime), N'哦', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2325, N'140016535', N'', CAST(0x0000A7C200AED9EF AS DateTime), N'212212112', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2326, N'140016539', N'', CAST(0x0000A7C200CF037D AS DateTime), N'3223', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2327, N'140016539', N'', CAST(0x0000A7C200CF106B AS DateTime), N'2332322', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2328, N'140016539', N'', CAST(0x0000A7C200E1B1E0 AS DateTime), N'12', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2329, N'140016539', N'', CAST(0x0000A7C200E1B717 AS DateTime), N'12', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2330, N'140016539', N'', CAST(0x0000A7C200E1B7B1 AS DateTime), N'12', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2331, N'140016539', N'', CAST(0x0000A7C200E1B7ED AS DateTime), N'12', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2332, N'140016539', N'', CAST(0x0000A7C200E1B827 AS DateTime), N'12', 3086)
INSERT [dbo].[ChatContent] ([ChatContentID], [SendUserName], [ReceiveUserName], [SendDateTime], [MsgContent], [RoomID]) VALUES (2333, N'140016539', N'', CAST(0x0000A7C200E1B867 AS DateTime), N'12', 3086)
SET IDENTITY_INSERT [dbo].[ChatContent] OFF
/****** Object:  StoredProcedure [dbo].[sp_UserIDrepetition]    Script Date: 08/02/2017 16:11:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UserIDrepetition]
	@UserID int
AS
BEGIN
	
	SET NOCOUNT ON;
	select * from RoomInfo where UserID=@UserID
END
GO
/****** Object:  View [dbo].[VUUR]    Script Date: 08/02/2017 16:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VUUR]
AS
SELECT   dbo.RoomUser.*, dbo.UserInfo.UserName, dbo.UserInfo.UserType, dbo.UserInfo.NickName
FROM      dbo.RoomUser INNER JOIN
                dbo.UserInfo ON dbo.RoomUser.UserID = dbo.UserInfo.UserID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RoomUser"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 258
               Bottom = 146
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VUUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VUUR'
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertChat]    Script Date: 08/02/2017 16:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertChat]
	@SendUserName nvarchar(20),
	@ReceiveUserName nvarchar(20),
	@SendDateTime datetime,
	@MsgContent text,
	@RoomID int
AS
BEGIN
	INSERT INTO [dbo].[ChatContent]
           ([SendUserName]
           ,[ReceiveUserName]
           ,[SendDateTime]
           ,[MsgContent]
           ,[RoomID])
     VALUES
           (@SendUserName
           ,@ReceiveUserName
           ,@SendDateTime
           ,@MsgContent
           ,@RoomID)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_UserIDRoomID]    Script Date: 08/02/2017 16:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_UserIDRoomID]
	@RoomID int,
	@UserID int,
	@GOtoRoomDate datetime
AS
BEGIN
	INSERT INTO [dbo].[RoomUser]
           ([RoomID]
           ,[UserID]
		   ,GOtoRoomDate)
     VALUES
           (@RoomID,
           @UserID,
		   @GOtoRoomDate)
END
GO
/****** Object:  Default [DF_UserInfo_UserType]    Script Date: 08/02/2017 16:11:42 ******/
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UserType]  DEFAULT ((0)) FOR [UserType]
GO
/****** Object:  ForeignKey [FK_RoomInfo_UserInfo]    Script Date: 08/02/2017 16:11:43 ******/
ALTER TABLE [dbo].[RoomInfo]  WITH CHECK ADD  CONSTRAINT [FK_RoomInfo_UserInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([UserID])
GO
ALTER TABLE [dbo].[RoomInfo] CHECK CONSTRAINT [FK_RoomInfo_UserInfo]
GO
/****** Object:  ForeignKey [FK_RoomUser_RoomInfo]    Script Date: 08/02/2017 16:11:43 ******/
ALTER TABLE [dbo].[RoomUser]  WITH CHECK ADD  CONSTRAINT [FK_RoomUser_RoomInfo] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomInfo] ([RoomID])
GO
ALTER TABLE [dbo].[RoomUser] CHECK CONSTRAINT [FK_RoomUser_RoomInfo]
GO
/****** Object:  ForeignKey [FK_RoomUser_UserInfo]    Script Date: 08/02/2017 16:11:43 ******/
ALTER TABLE [dbo].[RoomUser]  WITH CHECK ADD  CONSTRAINT [FK_RoomUser_UserInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([UserID])
GO
ALTER TABLE [dbo].[RoomUser] CHECK CONSTRAINT [FK_RoomUser_UserInfo]
GO
/****** Object:  ForeignKey [FK_ChatContent_RoomInfo]    Script Date: 08/02/2017 16:11:43 ******/
ALTER TABLE [dbo].[ChatContent]  WITH CHECK ADD  CONSTRAINT [FK_ChatContent_RoomInfo] FOREIGN KEY([RoomID])
REFERENCES [dbo].[RoomInfo] ([RoomID])
GO
ALTER TABLE [dbo].[ChatContent] CHECK CONSTRAINT [FK_ChatContent_RoomInfo]
GO
