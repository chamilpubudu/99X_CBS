USE [99X_CBS]
GO
/****** Object:  Table [dbo].[CBS_Attendances]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Attendances](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Average InTime] [varchar](50) NULL,
	[Average OutTime] [varchar](50) NULL,
	[Weekends Worked] [varchar](50) NULL,
	[Medical Leaves Taken] [varchar](50) NULL,
	[Casual Leaves Taken] [varchar](50) NULL,
	[Annual Leaves Taken] [varchar](50) NULL,
	[Lieu Leaves Taken] [varchar](50) NULL,
	[Number of Days Reported to Work] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Awards]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Awards](
	[Employee Name] [varchar](50) NULL,
	[Award Date] [date] NULL,
	[Award] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Bonuses]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Bonuses](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Bonus Type] [varchar](50) NULL,
	[Bonus Amount] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_CustomerFeedbackScore]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_CustomerFeedbackScore](
	[Employee Name] [varchar](50) NULL,
	[Feedback Date] [date] NULL,
	[Score] [varchar](50) NULL,
	[Comments] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_EmployeeBillingUtilization]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_EmployeeBillingUtilization](
	[Employee Name] [varchar](50) NULL,
	[From Date] [date] NULL,
	[To Date] [date] NULL,
	[Project] [varchar](50) NULL,
	[Billing Utilization] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Employees]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Employees](
	[Employee Name] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[Date Joined] [date] NULL,
	[Career Started On] [varchar](50) NULL,
	[Appraisal Score] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Engagement]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Engagement](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Event] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_FuelAllowances]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_FuelAllowances](
	[Employee Name] [varchar](50) NULL,
	[Fueling Date] [date] NULL,
	[Number Of Liters] [varchar](50) NULL,
	[Amount] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Increments]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Increments](
	[Employee Name] [varchar](50) NULL,
	[Effective Date] [date] NULL,
	[Increment Amount] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_MentorBuddy]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_MentorBuddy](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Mentor or Buddy Type] [varchar](50) NULL,
	[Mentor or Buddy] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Promotions]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Promotions](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Promoted To] [varchar](50) NULL,
	[Previous Designation] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_PublicAppearences]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_PublicAppearences](
	[Employee Name] [varchar](50) NULL,
	[Appearance Date] [date] NULL,
	[Location] [varchar](50) NULL,
	[Event Name] [varchar](50) NULL,
	[Session Topic] [varchar](50) NULL,
	[Number Of Participants] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_ReportFormat]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CBS_ReportFormat](
	[ID] [int] NOT NULL,
	[Section] [nvarchar](50) NULL,
	[Enabled] [bit] NOT NULL,
	[SectionCode] [nvarchar](50) NULL,
	[PriviledgeLevel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CBS_TechnologyExposure]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_TechnologyExposure](
	[Employee Name] [varchar](50) NULL,
	[Date] [date] NULL,
	[Engagement] [varchar](50) NULL,
	[Technologies] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Trainings]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Trainings](
	[Employee Name] [varchar](50) NULL,
	[Year] [varchar](20) NULL,
	[Course Name] [varchar](50) NULL,
	[Training Provider] [varchar](50) NULL,
	[External] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Training Month] [varchar](50) NULL,
	[Time Duration] [varchar](50) NULL,
	[Cost Money] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_Travels]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_Travels](
	[Employee Name] [varchar](50) NULL,
	[Started Date] [date] NULL,
	[Number Of Days] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Allowance In SLR] [varchar](50) NULL,
	[Purpose] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_UniversitySessions]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_UniversitySessions](
	[Employee Name] [varchar](50) NULL,
	[Session Date] [date] NULL,
	[Initiated By] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Number Of Participants] [varchar](50) NULL,
	[Participants] [varchar](50) NULL,
	[Session Type] [varchar](50) NULL,
	[Time Duration] [varchar](50) NULL,
	[Topic] [varchar](50) NULL,
	[To the University] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CBS_ValueInnovations]    Script Date: 10/7/2014 12:46:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CBS_ValueInnovations](
	[Employee Name] [varchar](50) NULL,
	[Innovation Date] [date] NULL,
	[Value Innovation] [varchar](50) NULL,
	[EmpID] [varchar](30) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
