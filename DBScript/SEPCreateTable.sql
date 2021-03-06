/***********************************************************************************
**                                                                                **
**                               删除表                                           **
**                                                                                **
***********************************************************************************/

/****** 对象:  Table [dbo].[TAccount]:账号    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAccount]') AND type in (N'U'))
DROP TABLE [dbo].[TAccount]
GO

/****** 对象:  Table [dbo].[TDepartment]：部门   脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TDepartment]') AND type in (N'U'))
DROP TABLE [dbo].[TDepartment]
GO

/****** 对象:  Table [dbo].[TPosition]：职位   脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPosition]') AND type in (N'U'))
DROP TABLE [dbo].[TPosition]
GO

/****** 对象:  Table [dbo].[TPositionGrade]：职位等级   脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPositionGrade]') AND type in (N'U'))
DROP TABLE [dbo].[TPositionGrade]
GO

/****** 对象:  Table [dbo].[TAuth]:权限    脚本日期: 02/02/2009 10:52:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAuth]') AND type in (N'U'))
DROP TABLE [dbo].[TAuth]
GO

/****** 对象:  Table [dbo].[TAccountAuth]:权限关系    脚本日期: 02/02/2009 10:52:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAccountAuth]') AND type in (N'U'))
DROP TABLE [dbo].[TAccountAuth]
GO

/***********************************************************************************/
/************         Begin   公告,目标,公司规章        ****************************/
/***********************************************************************************/
/****** 对象:  Table [dbo].[TBulletin]：公告内容   脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TBulletin]') AND type in (N'U'))
DROP TABLE [dbo].[TBulletin]
GO

/****** 对象:  Table [dbo].[TAppendix]：公告附件   脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAppendix]') AND type in (N'U'))
DROP TABLE [dbo].[TAppendix]
GO

/****** 对象:  Table [dbo].[TGoal]:目标    脚本日期: 02/18/2009 17:22:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TGoal]') AND type in (N'U'))
DROP TABLE [dbo].[TGoal]
GO

/****** 对象:  Table [dbo].[TCompanyRegulations]：规章内容    脚本日期: 01/04/2009 13:40:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCompanyRegulations]') AND type in (N'U'))
DROP TABLE [dbo].[TCompanyRegulations]
GO

/****** 对象:  Table [dbo].[TCompanyReguAppendix]：规章附件   脚本日期: 01/04/2009 13:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCompanyReguAppendix]') AND type in (N'U'))
DROP TABLE [dbo].[TCompanyReguAppendix]
GO
/***********************************************************************************/
/************         End     公告,目标,公司规章        ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   公告,目标,公司规章        ****************************/
/***********************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TSpecialDate]') AND type in (N'U'))
DROP TABLE [dbo].[TSpecialDate]
GO
/***********************************************************************************/
/************         End     公告,目标,公司规章        ****************************/
/***********************************************************************************/



/***********************************************************************************/
/************         Begin   记录欢迎信     			****************************/
/***********************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TWelcomeMail]') AND type in (N'U'))
DROP TABLE [dbo].[TWelcomeMail]
GO

/***********************************************************************************/
/************         End   记录欢迎信       			****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   电子签名     			****************************/
/***********************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TElectronIdiograph]') AND type in (N'U'))
DROP TABLE [dbo].[TElectronIdiograph]

/***********************************************************************************/
/************         End   电子签名       			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************        start   便签       			****************************/
/***********************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TNotesShare]') AND type in (N'U'))
DROP TABLE [dbo].[TNotesShare]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TNotes]') AND type in (N'U'))
DROP TABLE [dbo].[TNotes]
GO
/***********************************************************************************/
/************         End   便签       			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************        start   工作任务       			****************************/
/***********************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TWorkTask]') AND type in (N'U'))
DROP TABLE [dbo].[TWorkTask]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TWorkTaskResponsible]') AND type in (N'U'))
DROP TABLE [dbo].[TWorkTaskResponsible]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TWorkTaskQA]') AND type in (N'U'))
DROP TABLE [dbo].[TWorkTaskQA]
GO
/***********************************************************************************/
/************         End   工作任务       			****************************/
/***********************************************************************************/

-------------Begin            职位                        -------------------------------IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPosition]') AND type in (N'U'))DROP TABLE [dbo].[TPosition]GOIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPositionGrade]') AND type in (N'U'))DROP TABLE [dbo].[TPositionGrade]GOIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPositionNature]') AND type in (N'U'))DROP TABLE [dbo].[TPositionNature]GOIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPositionNatureRelationship]') AND type in (N'U'))DROP TABLE [dbo].[TPositionNatureRelationship]GOIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPositionDeptRelationShip]') AND type in (N'U'))DROP TABLE [dbo].[TPositionDeptRelationShip]GO-------------End            职位                        -------------------------------

/***********************************************************************************
**                                                                                **
**                               创建表                                           **
**                                                                                **
***********************************************************************************/

/****** 对象:  Table [dbo].[TAccount]:账号    脚本日期: 02/02/2009 16:43:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAccount](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](2000) NOT NULL,
	[UsbKey] [nvarchar](2000) NULL,
	[AccountType] [int] NOT NULL CONSTRAINT [DF_TAccount_AccountType]  DEFAULT ((1)),
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Email1] [nvarchar](255) NULL,
	[Email2] [nvarchar](255) NULL,
	[MobileNum] [nvarchar](50) NULL,
	[IsAcceptEmail] [int] NOT NULL DEFAULT ((1)),
	[IsAcceptSMS] [int] NOT NULL DEFAULT ((1)),
	[IsValidateUsbKey] [int] NOT NULL DEFAULT ((0)),
	[DepartmentId] [int] NULL,
	[PositionId] [int] NULL,
	[GradesID] [int] NULL,
 CONSTRAINT [PK_TAccount] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAccount] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** 对象:  Table [dbo].[TDepartment]：部门   脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDepartment](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[LeaderId] [int] NOT NULL,
	[ParentId] [int] NOT NULL CONSTRAINT [DF_TDepartment_ParentId]  DEFAULT ((0)),
    [Address] Nvarchar(200)
,Phone Nvarchar(50)
,Fax Nvarchar(50)
,Others Nvarchar(50)
,[Description] TEXT
,FoundationTime DateTime
 CONSTRAINT [PK_TDepartment] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TDepartment] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** 对象:  Table [dbo].[TPosition]：职位   脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPosition](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[LevelId] [int] NULL,
	[PositionDescription] [text] NOT NULL DEFAULT (''),
 CONSTRAINT [PK_TPosition] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TPosition] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** 对象:  Table [dbo].[TPositionGrade]：职位等级   脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPositionGrade](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[PositionGradeName] [nvarchar](50) NOT NULL,
	[PositionGradeDescription] text NOT NULL DEFAULT (''),
	[Sequence] [int] NOT NULL DEFAULT ((99999)),
 CONSTRAINT [PK_TPositionGrade] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TPositionGrade] UNIQUE NONCLUSTERED  
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** 对象:  Table [dbo].[TAuth]:权限    脚本日期: 02/02/2009 10:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAuth](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[AuthName] [nvarchar](50) NOT NULL,
	[AuthParentId] [int] NOT NULL,
	[NavigateUrl] [nvarchar](255) NOT NULL DEFAULT (''),
        IfHasDepartment int NOT NULL default 0,
 CONSTRAINT [PK_TAuth] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAuth] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** 对象:  Table [dbo].[TAccountAuth]：权限关系   脚本日期: 02/02/2009 10:51:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAccountAuth](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[AuthId] [int] NOT NULL,
        DepartMentID int not null default 0,
 CONSTRAINT [PK_TAccountAuth] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAccountAuth] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/***********************************************************************************/
/************         Begin   公告,目标,公司规章        ****************************/
/***********************************************************************************/
/****** 对象:  Table [dbo].[TBulletin]：公告内容   脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBulletin](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[PublishTime] [datetime] NOT NULL,
	[Content] [text] NULL,
        DepartmentID  INT NOT NULL default 1,
 CONSTRAINT [PK_TBulletin] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TBulletin] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


/****** 对象:  Table [dbo].[TAppendix]：公告附件   脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAppendix](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[BulletinId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Directory] [text] NOT NULL,
 CONSTRAINT [PK_TAppendix] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAppendix] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** 对象:  Table [dbo].[TGoal]：目标    脚本日期: 02/18/2009 17:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TGoal](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[SetHostId] [int] NULL,
	[SetHostName] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Content] [text] NULL,
	[SetTime] [datetime] NOT NULL,
	[GoalType] [int] NOT NULL,
 CONSTRAINT [PK_TGoal] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TGoal] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** 对象:  Table [dbo].[TCompanyRegulations]：规章内容    脚本日期: 01/04/2009 13:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCompanyRegulations](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyReguType] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [text] NULL,
 CONSTRAINT [PK_TCompanyRegulations] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TCompanyRegulations] UNIQUE NONCLUSTERED
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** 对象:  Table [dbo].[TCompanyReguAppendix]：规章附件   脚本日期: 01/04/2009 13:31:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TCompanyReguAppendix](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyReguId] [int] NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[Directory] [nvarchar](255) NOT NULL,
	[UpLoadDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TCompanyReguAppendix] PRIMARY KEY NONCLUSTERED
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TCompanyReguAppendix] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
/***********************************************************************************/
/************         End     公告,目标,公司规章        ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   特殊日期					****************************/
/***********************************************************************************/

CREATE TABLE	TSpecialDate	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
SpecialDate		   DATETIME        NOT NULL, --特殊日期
IsWork             int             NOT NULL, --0 休息，1 工作，2 法定假日
SpecialHeader      NVarChar(50)    NOT NULL, --说明
SpecialDescription NVarChar(255)   NULL,     --详细说明
SpecialForeColor   NVarChar(50)    NOT NULL, --前景色
SpecialBackColor   NVarChar(50)    NOT NULL, --背景色
	CONSTRAINT PK_TSpecialDate PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TSpecialDate UNIQUE NONCLUSTERED (PKID)
)	
GO
/***********************************************************************************/
/************         End     特殊日期				    ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin   记录欢迎信     			****************************/
/***********************************************************************************/

CREATE TABLE	TWelcomeMail	
(
	PKID			INT IDENTITY		NOT NULL, 
	[Content]		TEXT				NOT NULL,
	EnableAutoSend	INT					NOT NULL,
	MailType        INT                 NOT NULL
	CONSTRAINT PK_T_SendMessages PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_T_SendMessages UNIQUE NONCLUSTERED (PKID)
)			
GO

/***********************************************************************************/
/************         End   记录欢迎信       			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin   记录电子签名     			****************************/
/***********************************************************************************/

CREATE TABLE TElectronIdiograph (
	[PKID]        int  IDENTITY          NOT NULL,
	[AccountID] [int] NULL,
  [Picture]	     [Image] NULL,

  CONSTRAINT PK_TElectronIdiograph PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TElectronIdiograph UNIQUE NONCLUSTERED (PKID)
) 
GO

/***********************************************************************************/
/************         End   记录电子签名       			****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         start   便签       			****************************/
/***********************************************************************************/


CREATE TABLE	[TNotes]	
(
	PKID		INT IDENTITY	NOT NULL, 
	[Content]   nvarchar(2000)	NOT NULL,
	AccountID	INT				NOT NULL,
	Start       DateTime         NOT NULL,
	[End]       DateTime         NOT NULL,
	[Type]      INT              NOT NULL,
	RangeStart  DateTime		  NULL,
	RangeEnd    DateTime		  NULL,
	TypeString  nvarchar(250)		  NULL,
	CONSTRAINT  PK_TNotes PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT  TC_TNotes UNIQUE NONCLUSTERED (PKID)
)			
GO



CREATE TABLE	[TNotesShare]	
(
	PKID		INT IDENTITY		NOT NULL, 
	NoteID		INT				NOT NULL,
	AccountID	INT					NOT NULL,
	CONSTRAINT PK_TNotesShare PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TNotesShare UNIQUE NONCLUSTERED (PKID)
)			
GO

/***********************************************************************************/
/************         End   便签        			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************        start   工作任务       			****************************/
/***********************************************************************************/
CREATE TABLE	TWorkTask	
(
	PKID		INT IDENTITY	NOT NULL, 
	Account		INT				NOT NULL,
	Title		nvarchar(200)	NOT NULL,
	[Content]	nvarchar(2000)	NOT NULL,
	Priority	INT				NOT NULL,
	Status		INT				NOT NULL,
	StartDate	DateTime		NOT NULL,
	EndDate		DateTime		NOT NULL,
	Description	nvarchar(2000)	NOT NULL,
	Remark		nvarchar(2000)	NOT NULL,
	CONSTRAINT  PK_TWorkTask PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT  TC_TWorkTask UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TWorkTaskResponsible	
(
	PKID		INT IDENTITY	NOT NULL, 
	WorkTaskID	INT				NOT NULL,
	AccountID	INT				NOT NULL,
	CONSTRAINT  PK_TWorkTaskResponsible PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT  TC_TWorkTaskResponsible UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TWorkTaskQA
(
	PKID			INT IDENTITY	NOT NULL, 
	WorkTaskID		INT				NOT NULL,
	QAccount		INT				NOT NULL,
	Question		nvarchar(500)	NOT NULL,
	QuestionDate	DateTime		NOT NULL,
	AAccount		INT				NOT NULL,
	Answer			nvarchar(500)	NOT NULL,
	AnswerDate		DateTime		NOT NULL,
	CONSTRAINT  PK_TWorkTaskQA PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT  TC_TWorkTaskQA UNIQUE NONCLUSTERED (PKID)
)			
GO
/***********************************************************************************/
/************         End   工作任务       			****************************/
/***********************************************************************************/-------------Begin            职位                        -------------------------------SET ANSI_NULLS ONGOSET QUOTED_IDENTIFIER ONGOCREATE TABLE [dbo].[TPosition](    [PKID]						Int IDENTITY	NOT NULL,	[PositionName]				nvarchar(50)	NOT NULL,	[LevelId]					int				NULL,	[PositionDescription]		text			NOT NULL DEFAULT (''),	[Number]					nvarchar(255)	NULL,	[Reviewer]					int				NULL,	[PositionStatus]		    int         	not NULL default -1,	[Version]					nvarchar(255)	NULL,	[Commencement]				DateTime		NULL,	[Summary]					text	NULL,	[MainDuties]				text	NULL,	[ReportScope]				text	NULL,	[ControlScope]				text	NULL,	[Coordination]				text	NULL,	[Authority]					text	NULL,	[Education]					text	NULL,	[ProfessionalBackground]	text	NULL,	[WorkExperience]			text	NULL,	[Qualification]				text	NULL,	[Competence]				text	NULL,	[OtherRequirements]			text	NULL,	[KnowledgeAndSkills]		text	NULL,	[RelatedProcesses]			text	NULL,	[ManagementSkills]			text	NULL,	[AuxiliarySkills]			text	NULL,    CONSTRAINT PK_TPosition PRIMARY KEY NONCLUSTERED (PKID),    CONSTRAINT TC_TPosition UNIQUE NONCLUSTERED (PKID)) GOSET ANSI_NULLS ONGOSET QUOTED_IDENTIFIER ONGOCREATE TABLE [dbo].[TPositionGrade](	[PKID] [int] IDENTITY(1,1) NOT NULL,	[PositionGradeName] [nvarchar](50) NOT NULL,	[PositionGradeDescription] [nvarchar](255) NOT NULL DEFAULT (''),	[Sequence] [int] NOT NULL DEFAULT ((99999)), CONSTRAINT [PK_TPositionGrade] PRIMARY KEY NONCLUSTERED (	[PKID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY], CONSTRAINT [TC_TPositionGrade] UNIQUE NONCLUSTERED  (	[PKID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]CREATE TABLE TPositionNature (    [PKID]			Int IDENTITY  NOT NULL,    [Name]			Nvarchar(255) NOT NULL,    [Description]   Nvarchar(255) NOT NULL	DEFAULT (''),    CONSTRAINT PK_TPositionNature PRIMARY KEY NONCLUSTERED (PKID),    CONSTRAINT TC_TPositionNature UNIQUE NONCLUSTERED (PKID)) GOCREATE TABLE [TPositionNatureRelationship] (    [PKID]				Int IDENTITY	NOT NULL,    [PositionID]		Int				NOT NULL,    [PositionNatureID]  Int				NOT NULL,    CONSTRAINT PK_TPositionNatureRelationship PRIMARY KEY NONCLUSTERED (PKID),    CONSTRAINT TC_TPositionNatureRelationship UNIQUE NONCLUSTERED (PKID)) GOCreate table [TPositionDeptRelationShip] (    [PKID]				Int IDENTITY	NOT NULL,    [PositionID]		Int				NOT NULL,    [DeptID]  Int				NOT NULL,    CONSTRAINT PK_TPositionDeptRelationShip PRIMARY KEY NONCLUSTERED (PKID),    CONSTRAINT TC_TPositionDeptRelationShip UNIQUE NONCLUSTERED (PKID)) GO-------------End            职位                        -------------------------------