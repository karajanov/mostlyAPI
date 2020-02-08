USE [master]
GO
/****** Object:  Database [StudentsLoggerBase]    Script Date: 2/8/2020 2:43:51 AM ******/
CREATE DATABASE [StudentsLoggerBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentsLoggerBase', FILENAME = N'/var/opt/mssql/data/StudentsLoggerBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentsLoggerBase_log', FILENAME = N'/var/opt/mssql/data/StudentsLoggerBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentsLoggerBase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentsLoggerBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentsLoggerBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentsLoggerBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentsLoggerBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentsLoggerBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentsLoggerBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET RECOVERY FULL 
GO
ALTER DATABASE [StudentsLoggerBase] SET  MULTI_USER 
GO
ALTER DATABASE [StudentsLoggerBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentsLoggerBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentsLoggerBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentsLoggerBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentsLoggerBase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StudentsLoggerBase', N'ON'
GO
ALTER DATABASE [StudentsLoggerBase] SET QUERY_STORE = OFF
GO
USE [StudentsLoggerBase]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 2/8/2020 2:43:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NULL,
	[courseId] [int] NULL,
	[datePresented] [datetime] NULL,
	[activityType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2/8/2020 2:43:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseName] [nvarchar](50) NULL,
	[professor] [nvarchar](50) NULL,
	[semesterYear] [nvarchar](4) NULL,
	[StudentDescription] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnrolledIn]    Script Date: 2/8/2020 2:43:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrolledIn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NULL,
	[courseId] [int] NULL,
	[studentYear] [nvarchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentData]    Script Date: 2/8/2020 2:43:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentData](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](50) NULL,
	[StudentEmail] [nvarchar](50) NULL,
	[StudentEnrolledDate] [datetime] NULL,
	[StudentId] [nvarchar](8) NULL,
	[DateOfBirth] [datetime] NULL,
	[StudentDescription] [nvarchar](500) NULL,
	[isRegular] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activities] ON 
GO
INSERT [dbo].[Activities] ([id], [studentId], [courseId], [datePresented], [activityType]) VALUES (1, 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Activities] ([id], [studentId], [courseId], [datePresented], [activityType]) VALUES (2, 1, 2, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Activities] ([id], [studentId], [courseId], [datePresented], [activityType]) VALUES (3, 1, 3, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Activities] ([id], [studentId], [courseId], [datePresented], [activityType]) VALUES (4, 2, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Activities] ([id], [studentId], [courseId], [datePresented], [activityType]) VALUES (5, 2, 2, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[Activities] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([id], [courseName], [professor], [semesterYear], [StudentDescription]) VALUES (1, N'Adss', N'Bojan', N'2020', N'ok')
GO
INSERT [dbo].[Course] ([id], [courseName], [professor], [semesterYear], [StudentDescription]) VALUES (2, N'Internet Prog', N'Igor', N'2020', N'ok')
GO
INSERT [dbo].[Course] ([id], [courseName], [professor], [semesterYear], [StudentDescription]) VALUES (3, N'Databases', N'Bojan', N'2020', N'ok')
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[EnrolledIn] ON 
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (2, 1, 1, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (3, 1, 2, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (4, 2, 2, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (5, 3, 3, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (6, 3, 2, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (7, 3, 1, N'2020')
GO
INSERT [dbo].[EnrolledIn] ([id], [studentId], [courseId], [studentYear]) VALUES (8, 3, 1, N'2020')
GO
SET IDENTITY_INSERT [dbo].[EnrolledIn] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentData] ON 
GO
INSERT [dbo].[StudentData] ([id], [StudentName], [StudentEmail], [StudentEnrolledDate], [StudentId], [DateOfBirth], [StudentDescription], [isRegular]) VALUES (1, N'One', N'one@e.com', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'2942', CAST(N'2311-01-01T00:00:00.000' AS DateTime), N'desc One', 1)
GO
INSERT [dbo].[StudentData] ([id], [StudentName], [StudentEmail], [StudentEnrolledDate], [StudentId], [DateOfBirth], [StudentDescription], [isRegular]) VALUES (2, N'Two', N'two@e.com', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'2341', CAST(N'2222-01-01T00:00:00.000' AS DateTime), N'desc Two', 0)
GO
INSERT [dbo].[StudentData] ([id], [StudentName], [StudentEmail], [StudentEnrolledDate], [StudentId], [DateOfBirth], [StudentDescription], [isRegular]) VALUES (3, N'Three', N'three@e.com', CAST(N'2444-01-22T00:00:00.000' AS DateTime), N'2414', CAST(N'2333-01-02T00:00:00.000' AS DateTime), N'desc Three', 1)
GO
INSERT [dbo].[StudentData] ([id], [StudentName], [StudentEmail], [StudentEnrolledDate], [StudentId], [DateOfBirth], [StudentDescription], [isRegular]) VALUES (4, N'TestPostUpdated', N'abc@e.com', NULL, N'9000', NULL, N'test update', 1)
GO
SET IDENTITY_INSERT [dbo].[StudentData] OFF
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Course] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Course]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[StudentData] ([id])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Student]
GO
ALTER TABLE [dbo].[EnrolledIn]  WITH CHECK ADD  CONSTRAINT [FK_EnrolledIn_Course] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[EnrolledIn] CHECK CONSTRAINT [FK_EnrolledIn_Course]
GO
ALTER TABLE [dbo].[EnrolledIn]  WITH CHECK ADD  CONSTRAINT [FK_EnrolledIn_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[StudentData] ([id])
GO
ALTER TABLE [dbo].[EnrolledIn] CHECK CONSTRAINT [FK_EnrolledIn_Student]
GO
USE [master]
GO
ALTER DATABASE [StudentsLoggerBase] SET  READ_WRITE 
GO
