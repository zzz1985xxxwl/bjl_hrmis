IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TNotesShare]') AND type in (N'U'))
DROP TABLE [dbo].[TNotesShare]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TNotes]') AND type in (N'U'))
DROP TABLE [dbo].[TNotes]
GO

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

