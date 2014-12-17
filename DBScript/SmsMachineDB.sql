IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'T_SendMessages' AND type = 'U')
    DROP TABLE T_SendMessages
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'T_ReceiveMessages' AND type = 'U')
    DROP TABLE T_ReceiveMessages
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'T_ClientInformation' AND type = 'U')
    DROP TABLE T_ClientInformation
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'T_ListenAddress' AND type = 'U')
    DROP TABLE T_ListenAddress
GO

CREATE TABLE	T_SendMessages	
(
	PKID			INT IDENTITY		NOT NULL, 
	SendStatusEnum	INT					NOT NULL,
	SystemSmsId		INT					NOT NULL,
    SendToNumber    NVarChar(50)		NOT NULL,
	SystemNumber	NVarChar(50)		NOT NULL,
	[Content]		NVarChar (2000)		NOT NULL,
	TriedCount		INT					NOT NULL,
	LastestSendTime	DateTime			Default(0),
	HrmisId			NVarChar(255)		NOT NULL
	
	CONSTRAINT PK_T_SendMessages PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_T_SendMessages UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE T_ReceiveMessages
(
	PKID			INT IDENTITY		NOT NULL, 
	BoradCasted		INT					NOT NULL,
	Id				INT					NOT NULL,
    TheNumber		NVarChar(50)		NOT NULL,
	[Content]		NVarChar (2000)		NOT NULL,
	ReceivedTime	DateTime			Default(0),
	IsCleanMessage	INT					NOT NULL
	
	CONSTRAINT PK_T_ReceiveMessages PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_T_ReceiveMessages UNIQUE NONCLUSTERED (PKID)
)

CREATE TABLE T_ClientInformation
(
	PKID				INT IDENTITY		NOT NULL, 
	HrmisId				NVarChar(255)		NOT NULL,
	CompanyDescription	NVarChar(255)		NOT NULL,
    IsPermitted			INT					NOT NULL,
	
	CONSTRAINT PK_T_ClientInformation PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_T_ClientInformation UNIQUE NONCLUSTERED (PKID)
)

CREATE TABLE T_ListenAddress
(
	PKID					INT IDENTITY		NOT NULL, 
	ClientInformationId		INT					NOT NULL,
	ListenAddress			NVarChar(255)		NOT NULL,
	IsPermitted				INT					NOT NULL,
    IsActived				INT					NOT NULL,
	LastTryActivitedTime	DateTime			NOT NULL,

	CONSTRAINT PK_T_ListenAddress PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_T_ListenAddress UNIQUE NONCLUSTERED (PKID)
)
