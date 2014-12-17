ALTER TABLE [TPositionHistory] ADD [PositionDescription]	text			NOT NULL DEFAULT ('')
ALTER TABLE [TPositionHistory] ADD [Number]					nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [ReviewerID]				int				NULL
ALTER TABLE [TPositionHistory] ADD [ReviewerName]			nvarchar(50)	NULL
ALTER TABLE [TPositionHistory] ADD [PositionStatus]		   	int         	NOT NULL default -1
ALTER TABLE [TPositionHistory] ADD [Version]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Commencement]			DateTime		NULL
ALTER TABLE [TPositionHistory] ADD [Summary]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [MainDuties]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [ReportScope]			nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [ControlScope]			nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Coordination]			nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Authority]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Education]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [ProfessionalBackground]	nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [WorkExperience]			nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Qualification]			nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [Competence]				nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [OtherRequirements]		nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [KnowledgeAndSkills]		nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [RelatedProcesses]		nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [ManagementSkills]		nvarchar(255)	NULL
ALTER TABLE [TPositionHistory] ADD [AuxiliarySkills]		nvarchar(255)	NULL


IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionNatureHistory' AND type = 'U')
	DROP TABLE TPositionNatureHistory 	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionNatureRelationshipHistory' AND type = 'U')
	DROP TABLE TPositionNatureRelationshipHistory	
GO

CREATE TABLE TPositionNatureHistory (
    [PKID]			Int IDENTITY  NOT NULL,
    [Name]			Nvarchar(255) NOT NULL,
    [Description]   Nvarchar(255) NOT NULL	DEFAULT (''),
    CONSTRAINT PK_TPositionNatureHistory PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TPositionNatureHistory UNIQUE NONCLUSTERED (PKID)
) 
GO


CREATE TABLE TPositionNatureRelationshipHistory (
    [PKID]				Int IDENTITY	NOT NULL,
    [PositionID]		Int				NOT NULL,
    [PositionNatureID]  Int				NOT NULL,
    CONSTRAINT PK_TPositionNatureRelationshipHistory PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TPositionNatureRelationshipHistory UNIQUE NONCLUSTERED (PKID)
) 