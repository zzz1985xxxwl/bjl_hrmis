IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TContact]') AND type in (N'U'))
DROP TABLE [dbo].[TContact]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomer]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomer]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TGuidParameter]') AND type in (N'U'))
DROP TABLE [dbo].[TGuidParameter]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TProduct]') AND type in (N'U'))
DROP TABLE [dbo].[TProduct]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TProductFirstType]') AND type in (N'U'))
DROP TABLE [dbo].[TProductFirstType]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TProductSecondType]') AND type in (N'U'))
DROP TABLE [dbo].[TProductSecondType]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomerOwnerHistory]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomerOwnerHistory]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomerTrackRecord]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomerTrackRecord]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TImportantTrackRecord]') AND type in (N'U'))
DROP TABLE [dbo].[TImportantTrackRecord]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TOpportunity]') AND type in (N'U'))
DROP TABLE [dbo].[TOpportunity]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TIntentProduct]') AND type in (N'U'))
DROP TABLE [dbo].[TIntentProduct]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TOrder]') AND type in (N'U'))
DROP TABLE [dbo].[TOrder]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TOrderProduct]') AND type in (N'U'))
DROP TABLE [dbo].[TOrderProduct]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TTrackCurveTemplate]') AND type in (N'U'))
DROP TABLE [dbo].[TTrackCurveTemplate]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRemind]') AND type in (N'U'))
DROP TABLE [dbo].[TRemind]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCalendarEvent]') AND type in (N'U'))
DROP TABLE [dbo].[TCalendarEvent]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomerTrackCurve]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomerTrackCurve]

/****** 对象:  Table [dbo].[TAuth]:权限    脚本日期: 02/02/2009 10:52:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAuth]') AND type in (N'U'))
DROP TABLE [dbo].[TAuth]
GO

/****** 对象:  Table [dbo].[TAccountAuth]:权限关系    脚本日期: 02/02/2009 10:52:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAccountAuth]') AND type in (N'U'))
DROP TABLE [dbo].[TAccountAuth]
GO

/****** 对象:  Table [dbo].[TComplain]:客户投诉    脚本日期: 02/02/2009 10:52:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TComplain]') AND type in (N'U'))
DROP TABLE [dbo].[TComplain]
GO

/****** 对象:  Table [dbo].[TFeedback]:客户反馈    脚本日期: 02/02/2009 10:52:20 ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TFeedback]') AND type in (N'U'))
--DROP TABLE [dbo].[TFeedback]
--GO




CREATE TABLE TContact (
    ID					UNIQUEIDENTIFIER	NOT NULL,
    FirstName			NVARCHAR(50)		NOT NULL,
	LastName			NVARCHAR(50)		NOT NULL,
	FullName			NVARCHAR(50)		NOT NULL,
	MainContactPhone    NVARCHAR(50)		NOT NULL,
	BirthDay			DATETIME			NULL,
	Qq					NVARCHAR(50)		NOT NULL,
	Msn					NVARCHAR(50)		NOT NULL,
	[Like]				NVARCHAR(2000)		NOT NULL,
	Email				NVARCHAR(50)		NOT NULL,
	HomePage			NVARCHAR(200)		NOT NULL,
	Duty				NVARCHAR(50)		NOT NULL,
	CompanyName			NVARCHAR(200)		NOT NULL,
	Department			NVARCHAR(50)		NOT NULL,
	OfficeLocation		NVARCHAR(200)		NOT NULL,
	WorkPhone			NVARCHAR(50)		NOT NULL,
	WorkFax				NVARCHAR(50)		NOT NULL,
	HomePhone			NVARCHAR(50)		NOT NULL,
	MobilePhone			NVARCHAR(50)		NOT NULL,
	HomeFax				NVARCHAR(50)		NOT NULL,
	Remark				NVARCHAR(2000)		NOT NULL,
	AreaId				INT					NOT NULL,
	ProvinceId			INT					NOT NULL,
	CityId				INT					NOT NULL,
	Postalcode			NVARCHAR(50)		NOT NULL,
	Address				NVARCHAR(200)		NOT NULL,	
	CustomerId			UNIQUEIDENTIFIER	NOT NULL,
	CreaterId			INT					NOT NULL,
	CreateTime			DATETIME			NOT NULL,
	TimeStamper			DATETIME			NOT NULL	

    CONSTRAINT PK_TContact PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TContact UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TCustomer (
    ID						UNIQUEIDENTIFIER	NOT NULL,
    FullName				NVARCHAR(50)		NOT NULL,
	ShortName				NVARCHAR(50)		NOT NULL,
	IndustryId				INT					NOT NULL,
	OrginId					UNIQUEIDENTIFIER	NOT NULL,
	SizeId					INT					NOT NULL,
	OwnedTypeId				INT					NOT NULL,
	Phone					NVARCHAR(50)		NOT NULL,
	Fax						NVARCHAR(50)		NOT NULL,
	Email					NVARCHAR(50)		NOT NULL,
	InternetAddress			NVARCHAR(200)		NOT NULL,
	CustomerPrincipal		NVARCHAR(50)		NOT NULL,
	Remark					NVARCHAR(2000)		NOT NULL,
	OwnerStatusId			INT					NOT NULL,
	PrincipalId				INT					NOT NULL,
	SharesId				NVARCHAR(50)		NOT NULL,
	CustomerRelationLevelId	UNIQUEIDENTIFIER	NOT NULL,
	AreaId					INT					NOT NULL,
	ProvinceId				INT					NOT NULL,
	CityId					INT					NOT NULL,
	Postalcode				NVARCHAR(50)		NOT NULL,
	Address					NVARCHAR(200)		NOT NULL,
	CreaterId				INT					NOT NULL,
	CreateTime				DATETIME			NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TCustomer PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TCustomer UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TGuidParameter (
    ID						UNIQUEIDENTIFIER	NOT NULL,
    [Name]					NVARCHAR(50)		NOT NULL,
	Description				NVARCHAR(200)		NOT NULL,
	TypeId					INT					NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TGuidParameter PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TGuidParameter UNIQUE NONCLUSTERED (ID)
) 
GO


CREATE TABLE TProduct (
    ID						UNIQUEIDENTIFIER	NOT NULL,
    [Name]					NVARCHAR(50)		NOT NULL,
	Description				NVARCHAR(200)	    NOT NULL,
	Price 				    Decimal(25,2)		NOT NULL default 0,
	FirstTypeId			    UNIQUEIDENTIFIER	NOT NULL,
    SecondTypeId	        UNIQUEIDENTIFIER	NOT NULL,
    Picture	                Image			    NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TProduct PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TProduct UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TProductFirstType (
    ID						UNIQUEIDENTIFIER	NOT NULL,
    [Name]					NVARCHAR(50)		NOT NULL,
	Description				NVARCHAR(200)		NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TProductFirstType PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TProductFirstType UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TProductSecondType (
    ID						UNIQUEIDENTIFIER	NOT NULL,
    [Name]					NVARCHAR(50)		NOT NULL,
	Description				NVARCHAR(200)		NOT NULL,
	FirstTypeId				UNIQUEIDENTIFIER	NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TProductSecondType PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TProductSecondType UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TCustomerOwnerHistory (
    ID						UNIQUEIDENTIFIER	NOT NULL,
	CustomerId				UNIQUEIDENTIFIER	NOT NULL,
    OperateTime				DATETIME			NOT NULL,
	OperaterName			NVARCHAR(50)		NOT NULL,
	OperateContent			NVARCHAR(200)		NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TCustomerOwnerHistory PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TCustomerOwnerHistory UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TCustomerTrackRecord (
    ID						UNIQUEIDENTIFIER	NOT NULL,
	CustomerId				UNIQUEIDENTIFIER	NOT NULL,
    TrackTime				DATETIME			NOT NULL,
	ContactName				NVARCHAR(50)		NOT NULL,
	[Content]				NVARCHAR(2000)		NOT NULL,
	TrackModeId				UNIQUEIDENTIFIER	NOT NULL,
	ShareNames				NVARCHAR(50)		NOT NULL,
	CreaterId				INT					NOT NULL,
	CreateTime				DATETIME			NOT NULL,
	TimeStamper				DATETIME			NOT NULL

    CONSTRAINT PK_TCustomerTrackRecord PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TCustomerTrackRecord UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TImportantTrackRecord (
    ID							UNIQUEIDENTIFIER	NOT NULL,
	CustomerId					UNIQUEIDENTIFIER	NOT NULL,
    TrackTime					DATETIME			NOT NULL,
	Principal					NVARCHAR(50)		NOT NULL,
	[Content]					NVARCHAR(2000)		NOT NULL,
	ImportantTrackRecordTypeId	INT					NOT NULL,
	TimeStamper					DATETIME			NOT NULL

    CONSTRAINT PK_TImportantTrackRecord PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TImportantTrackRecord UNIQUE NONCLUSTERED (ID)
) 

CREATE TABLE TOpportunity (
	ID							UNIQUEIDENTIFIER	NOT NULL,
	[Name]						NVARCHAR(50)		NOT NULL,
	SalesStageID				UNIQUEIDENTIFIER	NOT NULL,
	ContactName					NVARCHAR(50)		NOT NULL,
	ExpectedCloseDate			DATETIME			NOT NULL,
	CustomerBudget				DECIMAL(25,2)		NOT NULL,
	Description					NVARCHAR(2000)		NOT NULL,
	Probability					INT					NOT NULL,
	Types						INT					NOT NULL,
	FailedTypesID				INT					NULL,
	Remark						NVARCHAR(2000)		NULL,
	OrderID						UNIQUEIDENTIFIER	NULL,
	CustomerId					UNIQUEIDENTIFIER	NOT NULL,
	CreaterId					INT					NOT NULL,
	CreateTime					DATETIME			NOT NULL,
	TimeStamper					DATETIME			NOT NULL	

    CONSTRAINT PK_TOpportunity PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TOpportunity UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TIntentProduct (
    ID							UNIQUEIDENTIFIER	NOT NULL,
    OpportunityId				UNIQUEIDENTIFIER	NOT NULL,
	ProductId					UNIQUEIDENTIFIER	NOT NULL,
	ProductName					NVARCHAR(50)		NOT NULL,
	ProductMarketPrice			DECIMAL(25,2)		NOT NULL,
	ProductDescription			NVARCHAR(2000)		NOT NULL,
	ProductFirstTypeID			UNIQUEIDENTIFIER	NOT NULL,
	ProductFirstTypeName		NVARCHAR(50)		NOT NULL,
	ProductSecondTypeID			UNIQUEIDENTIFIER	NOT NULL,
	ProductSecondTypeName		NVARCHAR(50)		NOT NULL,
	Amount						DECIMAL(25,2)		NOT NULL,
	Price						DECIMAL(25,2)		NOT NULL,
	TimeStamper					DATETIME			NOT NULL	

    CONSTRAINT PK_TIntentProduct PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TIntentProduct UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TOrder (
	ID						UNIQUEIDENTIFIER	NOT NULL,
	OrderNumber				NVARCHAR(50)		NOT NULL,
	ContactName				NVARCHAR(50)		NOT NULL,
	OrderStatusId			INT					NOT NULL,
	OrderTime				DATETIME			NOT NULL,
	Description				NVARCHAR(2000)		NOT NULL,
	[Sum]					DECIMAL(25,2)		NOT NULL,
	CustomerId				UNIQUEIDENTIFIER	NOT NULL,
	CreaterId				INT					NOT NULL,
	CreateTime				DATETIME			NOT NULL,
	TimeStamper				DATETIME			NOT NULL	

    CONSTRAINT PK_TOrder PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TOrder UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TOrderProduct (
	ID								UNIQUEIDENTIFIER	NOT NULL,
	OrderId							UNIQUEIDENTIFIER	NOT NULL,
	ProductId						UNIQUEIDENTIFIER	NOT NULL,
	ProductName						NVARCHAR(50)		NOT NULL,
	ProductMarketPrice				DECIMAL(25,2)		NOT NULL,
	ProductDescription				NVARCHAR(2000)		NOT NULL,
	ProductFirstTypeID				UNIQUEIDENTIFIER	NOT NULL,
	ProductFirstTypeName			NVARCHAR(50)		NOT NULL,
	ProductSecondTypeID				UNIQUEIDENTIFIER	NOT NULL,
	ProductSecondTypeName			NVARCHAR(50)		NOT NULL,
	Amount							DECIMAL(25,2)		NOT NULL,
	Price							DECIMAL(25,2)		NOT NULL,
	TimeStamper						DATETIME			NOT NULL	

    CONSTRAINT PK_TOrderProduct PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TOrderProduct UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TTrackCurveTemplate (
	ID						UNIQUEIDENTIFIER	NOT NULL,
	Title				    NVARCHAR(50)		NOT NULL,
	SecondTouchDays			INT		            NOT NULL,
	ThirdTouchDays			INT					NOT NULL,
	FourthTouchDays			INT			        NOT NULL,
	FifthTouchDays			INT		            NOT NULL,
	LoopDays				INT		            NOT NULL,
	UpToDays				INT	                NOT NULL,
	RelatedAccountID		INT					NOT NULL,
	TimeStamper				DATETIME			NOT NULL			

    CONSTRAINT PK_TTrackCurveTemplate PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TTrackCurveTemplate UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TRemind (
    ID					    UNIQUEIDENTIFIER	NOT NULL,
    [Content]               NVARCHAR(255)       NOT NULL,
    RemindTime				DATETIME 		    NOT NULL,
	CalendarEventId			UNIQUEIDENTIFIER	NULL,
	ReadStatusId			INT					NOT NULL,
	RelatedAccountId		INT			        NOT NULL,
	TimeStamper				DATETIME			NOT NULL	

    CONSTRAINT PK_TRemind PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TRemind UNIQUE NONCLUSTERED (ID)
) 
GO

CREATE TABLE TCalendarEvent (
    ID							UNIQUEIDENTIFIER	NOT NULL,
    Title						NVARCHAR(200)       NOT NULL,
	StartDateTime				DATETIME			NOT NULL,
    [Content]					NVARCHAR(2000) 		NOT NULL,
	ImportantDegreeId			INT					NOT NULL,
	EventStatusId				INT					NOT NULL,
	RelatedAccountId			INT					NOT NULL,
	Reason						NVARCHAR(200)		NULL,
	GiveUpTime					DATETIME			NULL,
	CompleteTime				DATETIME			NULL,
	CustomerId					UNIQUEIDENTIFIER    NULL,
	RelatedCustomerTrackCurveId	UNIQUEIDENTIFIER	NULL,
	TimeStamper					DATETIME			NOT NULL	

    CONSTRAINT PK_TCalendarEvent PRIMARY KEY NONCLUSTERED (ID),
    CONSTRAINT TC_TCalendarEvent UNIQUE NONCLUSTERED (ID)
)
GO

CREATE TABLE TCustomerTrackCurve (
		ID						UNIQUEIDENTIFIER	NOT NULL,
        CustomerId				UNIQUEIDENTIFIER	NOT NULL,
		Title				    NVARCHAR(50)		NOT NULL,			
		TimeStamper				DATETIME			NOT NULL
	
    CONSTRAINT PK_TCustomerTrackCurveTemplate PRIMARY KEY NONCLUSTERED (CustomerId),
    CONSTRAINT TC_TCustomerTrackCurveTemplate UNIQUE NONCLUSTERED (CustomerId)
) 
GO

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
 CONSTRAINT [PK_TAccountAuth] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAccountAuth] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


/*投诉*/
CREATE TABLE TComplain (
	/*PKID*/
	PKID				INT IDENTITY		NOT NULL,
	/*客户ID*/
	CustomerID UNIQUEIDENTIFIER	NOT NULL,
	/*投诉类别*/
	ComplainType			INT			NOT NULL,
	/*涉及订单ID*/
	OrderID				INT			NOT NULL,
	/*投诉主题*/
	ComplainSubject			NVARCHAR(50)		NOT NULL,
	/*投诉内容*/
	ComplainContents		NVARCHAR(255)		NOT NULL,
	/*提交时间*/
	SubmitDateTime			DATETIME		NOT NULL,
	/*反馈内容*/
  FeedbackContents			NVARCHAR(255),
  /*反馈时间*/
  FeedbackDateTime			DATETIME

    CONSTRAINT PK_TComplain PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TComplain UNIQUE NONCLUSTERED (PKID)
) 
GO

/*反馈*/
--CREATE TABLE TFeedback (
--/*PKID*/
--PKID				INT IDENTITY		NOT NULL,
--/*投诉ID*/
--ComplainID			INT			NOT NULL,
--/*客户ID*/
--CustomerID			UNIQUEIDENTIFIER	NOT NULL,
--/*反馈内容*/
--Contents			NVARCHAR(255)		NOT NULL,
--/*提交时间*/
--SubmitDateTime			DATETIME		NOT NULL

  --CONSTRAINT PK_TFeedback PRIMARY KEY NONCLUSTERED (PKID),
  --CONSTRAINT TC_TFeedback UNIQUE NONCLUSTERED (PKID)
--) 
--GO
