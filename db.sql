USE [master]
GO
/****** Object:  Database [WorkManagementStable]    Script Date: 11/11/2023 4:42:05 PM ******/
CREATE DATABASE [WorkManagementStable]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkManagementStable', FILENAME = N'D:\apps\MSSQL16.SQLEXPRESS\MSSQL\DATA\WorkManagementStable.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkManagementStable_log', FILENAME = N'D:\apps\MSSQL16.SQLEXPRESS\MSSQL\DATA\WorkManagementStable_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WorkManagementStable] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkManagementStable].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkManagementStable] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkManagementStable] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkManagementStable] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkManagementStable] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkManagementStable] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkManagementStable] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WorkManagementStable] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkManagementStable] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkManagementStable] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkManagementStable] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkManagementStable] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkManagementStable] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkManagementStable] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkManagementStable] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkManagementStable] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WorkManagementStable] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkManagementStable] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkManagementStable] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkManagementStable] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkManagementStable] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkManagementStable] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WorkManagementStable] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkManagementStable] SET RECOVERY FULL 
GO
ALTER DATABASE [WorkManagementStable] SET  MULTI_USER 
GO
ALTER DATABASE [WorkManagementStable] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkManagementStable] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkManagementStable] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkManagementStable] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkManagementStable] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkManagementStable] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WorkManagementStable] SET QUERY_STORE = OFF
GO
USE [WorkManagementStable]
GO
/****** Object:  User [sa2]    Script Date: 11/11/2023 4:42:05 PM ******/
CREATE USER [sa2] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/11/2023 4:42:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountKey] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[CompanyKey] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedAndCared]    Script Date: 11/11/2023 4:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedAndCared](
	[AACJKey] [int] IDENTITY(1,1) NOT NULL,
	[AccountKey] [int] NOT NULL,
	[PostKey] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AACJKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppliedUsers]    Script Date: 11/11/2023 4:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppliedUsers](
	[AUFJKey] [int] IDENTITY(1,1) NOT NULL,
	[AccountKey] [int] NOT NULL,
	[PostKey] [int] NOT NULL,
	[CvFileKey] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AUFJKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 11/11/2023 4:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyKey] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [text] NOT NULL,
	[ImageUrl] [text] NOT NULL,
	[LogoUrl] [text] NOT NULL,
	[Location] [varchar](500) NOT NULL,
	[WorkField] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CVFiles]    Script Date: 11/11/2023 4:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CVFiles](
	[CVFileKey] [int] IDENTITY(1,1) NOT NULL,
	[CVName] [nvarchar](255) NOT NULL,
	[AccountKey] [int] NOT NULL,
	[CVFileSource] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CVFileKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 11/11/2023 4:42:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostKey] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](500) NOT NULL,
	[CompanyKey] [int] NOT NULL,
	[ToTime] [datetime] NOT NULL,
	[SalaryType] [varchar](100) NOT NULL,
	[Salary] [int] NULL,
	[SalaryFrom] [int] NULL,
	[SalaryTo] [int] NULL,
	[WorkType] [varchar](50) NOT NULL,
	[Sex] [varchar](50) NOT NULL,
	[Candidates] [int] NOT NULL,
	[Level] [varchar](255) NOT NULL,
	[ExperienceType] [text] NULL,
	[Experience] [int] NULL,
	[ExperienceFrom] [int] NULL,
	[ExperienceTo] [int] NULL,
	[Description] [text] NOT NULL,
	[RequiredCandicate] [text] NOT NULL,
	[Benefits] [text] NOT NULL,
	[JobField] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PostKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (1, N'Dat', N'Lai', N'admin@gmail.com', N'BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413', N'ADMIN', NULL)
INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (2, N'string', N'string', N'string', N'2757CB3CAFC39AF451ABB2697BE79B4AB61D63D74D85B0418629DE8C26811B529F3F3780D0150063FF55A2BEEE74C4EC102A2A2731A1F1F7F10D473AD18A6A87', N'string', NULL)
INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (3, N'HE163971-', N'DŨNG', N'dacdung0984@gmail.com', N'BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413', N'USER', NULL)
INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (4, N'nguyen', N'long', N'thoiloan0984@gmail.com', N'BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413', N'USER', NULL)
INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (5, N'Nguyen', N'Dung', N'dacdung0985@gmail.com', N'BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413', N'USER', NULL)
INSERT [dbo].[Accounts] ([AccountKey], [FirstName], [LastName], [Email], [Password], [Role], [CompanyKey]) VALUES (6, N'Nguyen', N'Dung', N'testjavamail0986@gmail.com', N'BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413', N'USER', NULL)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[AppliedAndCared] ON 

INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1, 1, 1, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (2, 4, 1011, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1002, 4, 1, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1003, 1, 1015, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1004, 1, 1016, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1005, 1, 1011, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1006, 3, 1, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1007, 1, 1019, N'Applied')
INSERT [dbo].[AppliedAndCared] ([AACJKey], [AccountKey], [PostKey], [Status]) VALUES (1008, 4, 1024, N'Applied')
SET IDENTITY_INSERT [dbo].[AppliedAndCared] OFF
GO
SET IDENTITY_INSERT [dbo].[AppliedUsers] ON 

INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (6, 1, 1, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (7, 4, 1011, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1002, 4, 1, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1003, 1, 1015, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1004, 1, 1016, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1005, 1, 1011, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1006, 3, 1, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1007, 1, 1019, 1)
INSERT [dbo].[AppliedUsers] ([AUFJKey], [AccountKey], [PostKey], [CvFileKey]) VALUES (1008, 4, 1024, 1)
SET IDENTITY_INSERT [dbo].[AppliedUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([CompanyKey], [Name], [Description], [ImageUrl], [LogoUrl], [Location], [WorkField]) VALUES (1, N'Ziggo', N'Cong ty trach nhiem huu han', N'job-list1.png', N'job-list1.png', N'Ha Noi', N'IT')
INSERT [dbo].[Companies] ([CompanyKey], [Name], [Description], [ImageUrl], [LogoUrl], [Location], [WorkField]) VALUES (2, N'Elise', N'Cong ty trach nhiem huu han 2', N'job-list2.png', N'job-list2.png', N'Ho Chi Minh City', N'IT')
INSERT [dbo].[Companies] ([CompanyKey], [Name], [Description], [ImageUrl], [LogoUrl], [Location], [WorkField]) VALUES (1002, N'Rostelecom', N'This is description', N'job-list3.png', N'job-list3.png', N'Da Nang', N'IT')
INSERT [dbo].[Companies] ([CompanyKey], [Name], [Description], [ImageUrl], [LogoUrl], [Location], [WorkField]) VALUES (1003, N'Veolia', N'This is description', N'job-list4.png', N'job-list4.png', N'Ha Noi', N'IT')
INSERT [dbo].[Companies] ([CompanyKey], [Name], [Description], [ImageUrl], [LogoUrl], [Location], [WorkField]) VALUES (1004, N'Misa', N'This is description', N'job-list5.png', N'job-list5.png', N'Ho Chi Minh City', N'IT')
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[CVFiles] ON 

INSERT [dbo].[CVFiles] ([CVFileKey], [CVName], [AccountKey], [CVFileSource]) VALUES (1, N'Template', 1, N'NoSource')
SET IDENTITY_INSERT [dbo].[CVFiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1, N'Net developer', 1, CAST(N'2023-01-01T00:00:00.000' AS DateTime), N'Agreed-upon', 5000, 3000, 5000, N'Part-time', N'Male', 10, N'Intern', N'3 or more years of professional design experience; Direct response email experience; Ecommerce website design experience; Familiarity with mobile and web apps preferred; Experience using Invision a plus', 3, 3, 6, N'It is a long established fact that a reader will beff distracted by vbthe creadable content of a page when looking at its layout. The pointf of using Lorem Ipsum is that it has ahf mcore or-lgess normal distribution of letters, as opposed to using, Content here content here making it look like readable.', N'System Software Development; Mobile Applicationin iOS/Android/Tizen or other platform; Research and code , libraries, APIs and frameworks; Strong knowledge on software development life cycle; Strong problem solving and debugging skills', N'Competitive salary and performance-based incentives; Comprehensive health benefits; Training and professional development programs', N'IT')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1011, N'Frontend Developer', 2, CAST(N'2023-07-07T00:00:00.000' AS DateTime), N'Agreed-upon', 8000, 5000, 8000, N'Full-time', N'Male', 5, N'Junior', N'1 or more years of experience in frontend development; Proficiency in HTML, CSS, and JavaScript; Familiarity with modern frontend frameworks like React or Angular; Good understanding of responsive design principles', 1, 1, 2, N'As a Frontend Developer, you will be responsible for creating and implementing user interface components and ensuring a seamless user experience. You will work closely with the design and development teams to translate mockups and wireframes into functional web applications.', N'Bachelor’s degree in Computer Science or a related field is preferred; Strong problem-solving and debugging skills; Passion for frontend technologies and eagerness to learn; Team player and effective communicator', N'Flexible work schedule; Opportunity to work remotely; Creative and fun work environment', N'Graphic Design')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1013, N'Software Engineer', 1002, CAST(N'2023-02-15T00:00:00.000' AS DateTime), N'Monthly', 6000, 5000, 7000, N'Full-time', N'Male', 5, N'Experienced', N'5 or more years of software development experience; Proficiency in C# and .NET framework; Strong understanding of object-oriented programming; Familiarity with database design and SQL; Experience with web application development using ASP.NET MVC', 3, 3, 6, N'As a Software Engineer, you will be responsible for designing, developing, and maintaining software applications. You will work collaboratively with the development team to deliver high-quality code and meet project deadlines.', N'Bachelor’s degree in Computer Science or a related field; Strong problem-solving and analytical skills; Ability to work in an Agile development environment; Excellent communication and teamwork abilities', N'Health insurance; Flexible work hours; Paid time off; Professional development opportunities', N'IT')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1015, N'Data Analyst', 1004, CAST(N'2023-04-10T00:00:00.000' AS DateTime), N'Monthly', 5500, 5000, 6000, N'Full-time', N'Any', 4, N'Mid-level', N'2 or more years of experience in data analysis; Strong proficiency in SQL and data querying; Experience with data visualization tools such as Power BI or Tableau; Ability to interpret and analyze complex data sets', 2, 2, 3, N'As a Data Analyst, you will be responsible for collecting, analyzing, and interpreting data to help make data-driven decisions. You will work closely with the data science team to develop data models and reports for business stakeholders.', N'Bachelor’s degree in Computer Science, Statistics, or a related field; Proficiency in Excel and data visualization tools; Strong problem-solving skills; Knowledge of statistical analysis techniques is a plus', N'Competitive salary and bonus; Comprehensive health benefits; Professional development and training opportunities', N'Human Resources')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1016, N'Graphic Designer', 1, CAST(N'2023-05-15T00:00:00.000' AS DateTime), N'Hourly', 3000, 2000, 3000, N'Part-time', N'Female', 3, N'Junior', N'1 or more years of graphic design experience; Proficiency in Adobe Creative Suite (Photoshop, Illustrator, InDesign); Strong understanding of design principles; Ability to work on multiple design projects', 1, 1, 2, N'Join our creative team as a Graphic Designer and help in creating visual concepts for print and digital media. You will collaborate with the marketing and development teams to produce high-quality designs for various marketing materials.', N'Associate’s or Bachelor’s degree in Graphic Design or a related field; Attention to detail and strong time management skills; Ability to work under tight deadlines; Portfolio showcasing design work', N'Flexible work schedule; Opportunity to work remotely; Creative and fun work environment', N'Graphic Design')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1017, N'Sales Representative', 2, CAST(N'2023-06-20T00:00:00.000' AS DateTime), N'Commission-based', 4500, 3000, 4500, N'Full-time', N'Any', 5, N'Experienced', N'3 or more years of sales experience; Strong interpersonal and communication skills; Ability to build and maintain customer relationships; Goal-oriented and self-motivated', 3, 3, 6, N'As a Sales Representative, you will be responsible for generating leads, meeting sales targets, and providing excellent customer service. You will work closely with the sales team to develop strategies and drive revenue growth.', N'High school diploma or equivalent; Prior experience in sales or customer service; Knowledge of CRM software is a plus; Willingness to travel for client meetings', N'Competitive commission structure; Sales training and professional development programs; Opportunity for advancement in the company', N'Marketing')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1018, N'Human Resources Manager', 1002, CAST(N'2023-07-10T00:00:00.000' AS DateTime), N'Yearly', 2300, 1000, 2300, N'Full-time', N'Any', 7, N'Senior', N'5 or more years of experience in HR management; Knowledge of labor laws and regulations; Strong leadership and decision-making skills; Ability to handle employee relations issues', 3, 3, 6, N'Join our HR team as a Human Resources Manager and oversee all aspects of HR operations. You will be responsible for recruitment, employee training, performance management, and ensuring compliance with labor laws.', N'Bachelor’s degree in Human Resources or a related field; SHRM or HRCI certification is a plus; Proven experience in HR leadership roles; Excellent communication and negotiation skills', N'Competitive salary and bonus; Comprehensive benefits package; Professional development and training opportunities', N'IT')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1019, N'Project Manager', 1003, CAST(N'2023-08-15T00:00:00.000' AS DateTime), N'Monthly', 8000, 7000, 9000, N'Full-time', N'Any', 5, N'Mid-level', N'3 or more years of project management experience; Proficiency in project management tools and methodologies; Strong organizational and multitasking skills; Ability to lead cross-functional teams', 2, 2, 3, N'We are seeking a skilled Project Manager to oversee and coordinate project activities. You will be responsible for project planning, resource allocation, risk management, and ensuring project deliverables are met on time.', N'Bachelor’s degree in Project Management, Business, or a related field; PMP certification is a plus; Experience with Agile and Waterfall methodologies; Excellent leadership and communication skills', N'Competitive salary and performance bonuses; Comprehensive health benefits; Professional development and training programs', N'Human Resources')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1020, N'Customer Service Representative', 1004, CAST(N'2023-09-10T00:00:00.000' AS DateTime), N'Hourly', 5000, 3000, 5000, N'Part-time', N'Any', 3, N'Junior', N'1 or more years of customer service experience; Excellent communication and problem-solving skills; Ability to handle customer inquiries and complaints; Multilingual skills are a plus', 1, 1, 2, N'Join our customer service team and provide top-notch support to our clients. You will assist customers via phone, email, and chat, resolve issues, and ensure customer satisfaction.', N'High school diploma or equivalent; Prior experience in customer service or call center; Knowledge of CRM software is a plus; Friendly and positive attitude', N'Flexible work schedule; Paid training and ongoing support; Opportunity for career advancement within the company', N'Graphic Design')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1021, N'Operations Manager', 1, CAST(N'2023-10-15T00:00:00.000' AS DateTime), N'Yearly', 8500, 6000, 8500, N'Full-time', N'Any', 7, N'Senior', N'5 or more years of experience in operations management; Strong leadership and decision-making skills; Ability to streamline processes and improve efficiency; Excellent problem-solving abilities', 3, 3, 6, N'As an Operations Manager, you will oversee daily operations and ensure efficient business processes. You will work with department heads to develop strategies and optimize operations to meet organizational goals.', N'Bachelor’s degree in Business Administration, Operations Management, or a related field; Proven experience in operations leadership roles; Knowledge of Lean or Six Sigma methodologies is a plus', N'Competitive salary and performance bonuses; Comprehensive benefits package; Opportunities for career growth and professional development', N'Marketing')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1022, N'Software Quality Assurance Analyst', 2, CAST(N'2023-11-10T00:00:00.000' AS DateTime), N'Monthly', 6000, 5500, 6500, N'Full-time', N'Any', 4, N'Mid-level', N'2 or more years of experience in software testing and quality assurance; Proficiency in testing methodologies and tools; Ability to identify and report defects; Familiarity with automation testing is a plus', 2, 2, 3, N'Join our QA team and contribute to the quality assurance process of software products. You will perform test planning, execute test cases, and collaborate with the development team to ensure software quality.', N'Bachelor’s degree in Computer Science, Engineering, or a related field; ISTQB or CSTE certification is a plus; Experience with Agile testing practices; Analytical and detail-oriented mindset', N'Competitive salary and performance-based incentives; Comprehensive health benefits; Training and professional development programs', N'IT')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1023, N'tesster', 1004, CAST(N'2023-11-20T11:33:00.000' AS DateTime), N'string', 9999, 1111, 9999, N'Full-time', N'Male', 1, N'string', N'string', 1, 2, 3, N'easily', N'1', N'string', N'Marketing')
INSERT [dbo].[Posts] ([PostKey], [Title], [CompanyKey], [ToTime], [SalaryType], [Salary], [SalaryFrom], [SalaryTo], [WorkType], [Sex], [Candidates], [Level], [ExperienceType], [Experience], [ExperienceFrom], [ExperienceTo], [Description], [RequiredCandicate], [Benefits], [JobField]) VALUES (1024, N'new job', 1, CAST(N'2023-11-11T15:02:00.000' AS DateTime), N'string', 2000, 1000, 2000, N'Full-time', N'Male', 10, N'string', N'string', 1, 0, 1, N'details of job', N'html css', N'string', N'IT')
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([CompanyKey])
REFERENCES [dbo].[Companies] ([CompanyKey])
GO
ALTER TABLE [dbo].[AppliedAndCared]  WITH CHECK ADD FOREIGN KEY([AccountKey])
REFERENCES [dbo].[Accounts] ([AccountKey])
GO
ALTER TABLE [dbo].[AppliedAndCared]  WITH CHECK ADD FOREIGN KEY([PostKey])
REFERENCES [dbo].[Posts] ([PostKey])
GO
ALTER TABLE [dbo].[AppliedUsers]  WITH CHECK ADD FOREIGN KEY([AccountKey])
REFERENCES [dbo].[Accounts] ([AccountKey])
GO
ALTER TABLE [dbo].[AppliedUsers]  WITH CHECK ADD FOREIGN KEY([CvFileKey])
REFERENCES [dbo].[CVFiles] ([CVFileKey])
GO
ALTER TABLE [dbo].[AppliedUsers]  WITH CHECK ADD FOREIGN KEY([PostKey])
REFERENCES [dbo].[Posts] ([PostKey])
GO
ALTER TABLE [dbo].[CVFiles]  WITH CHECK ADD FOREIGN KEY([AccountKey])
REFERENCES [dbo].[Accounts] ([AccountKey])
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD FOREIGN KEY([CompanyKey])
REFERENCES [dbo].[Companies] ([CompanyKey])
GO
USE [master]
GO
ALTER DATABASE [WorkManagementStable] SET  READ_WRITE 
GO
