SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblStudentMasterList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblStudentMasterList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[Firstname] [nvarchar](max) NULL,
	[MI] [nvarchar](max) NULL,
	[Birthdate] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Yearlevel] [nvarchar](max) NULL,
	[Guardian] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_tblStudentMasterList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCourse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCourse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblCourse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblYearLevel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblYearLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Yearlevel] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblYearLevel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAnnouncement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAnnouncement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Announcement] [nvarchar](max) NULL,
	[NoAnnouncement] [float] NULL,
 CONSTRAINT [PK_tblAnnouncement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblLogHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblLogHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LogId] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Usertype] [nvarchar](max) NULL,
	[Datein] [nvarchar](max) NULL,
	[Dateout] [nvarchar](max) NULL,
	[UserID] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblLogHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAdmin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAdmin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Lastname] [nvarchar](max) NULL,
	[Firstname] [nvarchar](max) NULL,
	[MI] [nvarchar](max) NULL,
	[Age] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
	[QiD] [nvarchar](max) NULL,
	[UserLevel] [nvarchar](max) NULL,
	[Photo] [image] NULL,
	[UserID] [int] NULL,
	[SumAdmin] [float] NULL,
	[SumStaff] [float] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSecurityQuestion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSecurityQuestion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SecurityQuestion] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblImportStudentMasterList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblImportStudentMasterList](
	[StudentID] [int] NULL,
	[Lastname] [nvarchar](max) NULL,
	[Firstname] [nvarchar](max) NULL,
	[MI] [nvarchar](max) NULL,
	[Birthdate] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Yearlevel] [nvarchar](max) NULL,
	[Guardian] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[NoStudent] [nvarchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblStudentMasterListCystalReport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblStudentMasterListCystalReport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[Firstname] [nvarchar](max) NULL,
	[MI] [nvarchar](max) NULL,
	[Birthdate] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Yearlevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblStudentMasterListCystalReport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSubEventRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSubEventRecord](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [nchar](10) NULL,
	[StudentID] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[Event] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSubEventRecord] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEventRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEventRecord](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [int] NULL,
	[StudentID] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[Event] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblEventRecord] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSystemPassword]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSystemPassword](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SystemPassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSystemPassword] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAttendance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAttendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [int] NULL,
	[StudentID] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblAttendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSubAttendance]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSubAttendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [int] NULL,
	[StudentID] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSubAttendance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAttendanceCrystalReport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblAttendanceCrystalReport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [int] NULL,
	[StudentID] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblAttendanceCrystalReport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEvent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](max) NULL,
	[FromDate] [nvarchar](max) NULL,
	[ToDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblEvent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEventRecordCrystalReport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEventRecordCrystalReport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubID] [int] NULL,
	[StudentID] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[YearLevel] [nvarchar](max) NULL,
	[Course] [nvarchar](max) NULL,
	[LogIN] [nvarchar](max) NULL,
	[LogOUT] [nvarchar](max) NULL,
	[Event] [nvarchar](max) NULL,
	[SMS] [nvarchar](max) NULL,
	[NoStudent] [float] NULL,
	[SMS1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblEventRecordCrystalReport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
