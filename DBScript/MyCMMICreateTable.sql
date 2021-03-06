/***********************************************************************************
**                                                                                **
**                               删除表                                           **
**                                                                                **
***********************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TKey]') AND type in (N'U'))
DROP TABLE [dbo].[TKey]

--Begin          卡片      -------------

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCardPropertyPara]') AND type in (N'U'))
DROP TABLE [dbo].[TCardPropertyPara]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCardPropertyEnumValue]') AND type in (N'U'))
DROP TABLE [dbo].[TCardPropertyEnumValue]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCardType]') AND type in (N'U'))
DROP TABLE [dbo].[TCardType]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCardField]') AND type in (N'U'))
DROP TABLE [dbo].[TCardField]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCard]') AND type in (N'U'))
DROP TABLE [dbo].[TCard]

--End            卡片      -------------

/***********************************************************************************
**                                                                                **
**                               创建表                                           **
**                                                                                **
***********************************************************************************/

CREATE TABLE TKey (
    PKID      Int IDENTITY  NOT NULL,
    TableName Nvarchar(255)	NOT NULL,
    RowID     Int	        NOT NULL,
    CONSTRAINT PK_TKey PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TKey UNIQUE NONCLUSTERED (PKID)
) 
GO

--Begin          卡片      -------------

CREATE TABLE TCardPropertyPara (
    PKID        Int IDENTITY  NOT NULL,
    [Name]      Nvarchar(255) NOT NULL,
	Description Text          NOT NULL,
    EnumCardPropertyDataType       Int	          NOT NULL,
    CONSTRAINT PK_TCardPropertyPara PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCardPropertyPara UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TCardPropertyEnumValue (
    PKID        Int IDENTITY  NOT NULL,
    [Name]      Nvarchar(255) NOT NULL,
    [Order]     Int	          NOT NULL,
    Color       Nvarchar(50)  NOT NULL,
    CardPropertyParaID     Int	          NOT NULL,
    CONSTRAINT PK_TCardPropertyEnumValue PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCardPropertyEnumValue UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TCardType (
    PKID        Int IDENTITY  NOT NULL,
    [Name]      Nvarchar(255) NOT NULL,
    Color       Nvarchar(50)  NOT NULL,
	Description Text          NOT NULL,
    CONSTRAINT PK_TCardType PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCardType UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TCardField (
    PKID          Int IDENTITY  NOT NULL,
	CardPropertyParaID INT      NOT NULL,
    CardTypeID    INT			NOT NULL,
    FieldFormula  Nvarchar(255) NOT NULL DEFAULT '',
	[Order]       INT           NOT NULL,
    CONSTRAINT PK_TCardField PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCardField UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TCard (
    PKID          Int IDENTITY  NOT NULL,
	ProjectID	  INT		    NOT NULL,
	CardTypeID	  INT		    NOT NULL,
    CardTypeWhole IMAGE			NOT NULL,
    Title         Nvarchar(255) NOT NULL,
	[Content]     TEXT         NOT NULL,
	ParentID	  INT		    NOT NULL,
    CONSTRAINT PK_TCard PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCard UNIQUE NONCLUSTERED (PKID)
) 
GO

--End            卡片      -------------
