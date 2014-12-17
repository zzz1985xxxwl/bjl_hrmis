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


ALTER TABLE [TPosition] ADD		[Number]					nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Reviewer]					int				NULL
ALTER TABLE [TPosition] ADD 	[PositionStatus]			int         	not NULL default -1
ALTER TABLE [TPosition] ADD 	[Version]					nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Commencement]				DateTime		NULL
ALTER TABLE [TPosition] ADD 	[Summary]					nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[MainDuties]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[ReportScope]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[ControlScope]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Coordination]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Authority]					nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Education]					nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[ProfessionalBackground]	nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[WorkExperience]			nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Qualification]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[Competence]				nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[OtherRequirements]			nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[KnowledgeAndSkills]		nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[RelatedProcesses]			nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[ManagementSkills]			nvarchar(255)	NULL
ALTER TABLE [TPosition] ADD 	[AuxiliarySkills]			nvarchar(255)	NULL

CREATE TABLE TPositionNature (
    [PKID]			Int IDENTITY  NOT NULL,
    [Name]			Nvarchar(255) NOT NULL,
    [Description]   Nvarchar(255) NOT NULL	DEFAULT (''),
    CONSTRAINT PK_TPositionNature PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TPositionNature UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE [TPositionNatureRelationship] (
    [PKID]				Int IDENTITY	NOT NULL,
    [PositionID]		Int				NOT NULL,
    [PositionNatureID]  Int				NOT NULL,
    CONSTRAINT PK_TPositionNatureRelationship PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TPositionNatureRelationship UNIQUE NONCLUSTERED (PKID)
) 
GO

Create table [TPositionDeptRelationShip] (
    [PKID]				Int IDENTITY	NOT NULL,
    [PositionID]		Int				NOT NULL,
    [DeptID]  Int				NOT NULL,
    CONSTRAINT PK_TPositionDeptRelationShip PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TPositionDeptRelationShip UNIQUE NONCLUSTERED (PKID)
) 
GO
