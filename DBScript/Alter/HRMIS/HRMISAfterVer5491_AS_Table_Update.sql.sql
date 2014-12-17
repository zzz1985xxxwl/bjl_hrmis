ALTER TABLE TEmployee  ADD CountryNationalityID int;--国籍编号

Alter table TDutyClass Add AbsentLateTime int 
Alter table TDutyClass Add AbsentEarlyLeaveTime int

Alter Table TCourse Add FeedBackPaperId    Int              NOT NUll

---培训反馈问卷---
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFeedBackPaper' AND type = 'U')
	DROP TABLE TFeedBackPaper
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFeedBackPIShip' AND type = 'U')
	DROP TABLE TFeedBackPIShip
GO

CREATE TABLE	TFeedBackPaper	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
PaperName	       NVarChar(50)    NOT NULL,   
    CONSTRAINT PK_TFeedBackPaper PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TFeedBackPaper UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE	TFeedBackPIShip	(	   
PKID	                   INT	IDENTITY   NOT NULL,	   
FeedBackPaperID	   INT   NOT NULL,	
QuetionItemID	   INT   NOT NULL,
    CONSTRAINT PK_TFeedBackPIShip PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TFeedBackPIShip UNIQUE NONCLUSTERED (PKID)
)			
GO	


--begin              员工档案       -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFileCargo' AND type = 'U')
	DROP TABLE TFileCargo
GO

CREATE TABLE	TFileCargo	(
	PKID	    INT IDENTITY	NOT NULL, 
    AccountID   Int NOT NULL, 
	FileCargoName NVarChar (50) NOT NULL,
    Remark NVarChar (2000) default '' NOT NULL , 
    [File] NVarChar (250) default '' NOT NULL , 
	CONSTRAINT PK_TFileCargo PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TFileCargo UNIQUE NONCLUSTERED (PKID)
)			
GO
--End               员工档案       -------------