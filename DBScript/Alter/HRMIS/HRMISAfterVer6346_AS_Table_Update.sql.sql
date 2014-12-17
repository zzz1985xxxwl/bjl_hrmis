--贝加莱 start
alter table dbo.TOutApplication add OutType int not null default 0




--- start 调休规则 -------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustRule' AND type = 'U')
	DROP TABLE TAdjustRule
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAdjustRule' AND type = 'U')
	DROP TABLE TEmployeeAdjustRule
GO
--- end   调休规则 -------

--- start 调休规则 -------
CREATE TABLE	TAdjustRule	(
PKID	            INT	IDENTITY    NOT NULL,
[Name]              Nvarchar(200)   NOT NULL,
OverWorkPuTongRate decimal(25,2) NOT NULL,
OverWorkJieRiRate decimal(25,2) NOT NULL,
OverWorkShuangXiuRate decimal(25,2) NOT NULL,
OutCityPuTongRate decimal(25,2) NOT NULL, 
OutCityJieRiRate decimal(25,2) NOT NULL,
OutCityShuangXiuRate decimal(25,2) NOT NULL,
CONSTRAINT PK_TAdjustRule PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TAdjustRule UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE	TEmployeeAdjustRule	(
PKID	        INT	IDENTITY    NOT NULL,
AccountID       INT  NOT NULL,
AdjustRuleID    INT  NOT NULL,
CONSTRAINT PK_TEmployeeAdjustRule PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TEmployeeAdjustRule UNIQUE NONCLUSTERED (PKID)
)
GO

--- end   调休规则 -------

--- start 班别 -------
Alter table TDutyClass drop column FirstStartTime
Alter table TDutyClass Add  FirstStartFromTime    DateTime           NOT NULL default '2009-1-1 8:00:00'--设定的上班的最晚时间
Alter table TDutyClass Add  FirstStartToTime      DateTime           NOT NULL default '2009-1-1 9:00:00'--设定的下班的最早时间
Alter table TDutyClass Add  AllLimitTime  Decimal	             NOT NULL default 9--设定的一天的最少上班时间 
--- end   班别 -------


alter table dbo.TEmployee add PositionGradeId int not null default -1
alter table dbo.TEmployeeHistory add PositionGradeId int not null default -1
alter table dbo.TEmployee add ProbationStartTime DateTime null
alter table dbo.TEmployeeHistory add ProbationStartTime DateTime null

update dbo.TEmployee set PositionGradeId=-1
update dbo.TEmployeeHistory set PositionGradeId=-1

--培训
alter table TCourseTrainee add CertificationName	  Nvarchar(50)	NULL

/***********************************************************************************
**                                                                                **
**                               删除表                                           **
**                                                                                **
***********************************************************************************/

--Begin             报销单管理        ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburse' AND type = 'U')
	DROP TABLE TReimburse	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseItem' AND type = 'U')
	DROP TABLE TReimburseItem	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseFlow' AND type = 'U')
	DROP TABLE TReimburseFlow	
GO

--End                报销单管理       -------------



/***********************************************************************************
**                                                                                **
**                               创建表                                           **
**                                                                                **
***********************************************************************************/

/***********************************************************************************
**                                                                                **
**                               删除表                                           **
**                                                                                **
***********************************************************************************/

--Begin             报销单管理        ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburse' AND type = 'U')
	DROP TABLE TReimburse	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseItem' AND type = 'U')
	DROP TABLE TReimburseItem	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseFlow' AND type = 'U')
	DROP TABLE TReimburseFlow	
GO

--End                报销单管理       -------------



/***********************************************************************************
**                                                                                **
**                               创建表                                           **
**                                                                                **
***********************************************************************************/

--Begin             报销单管理        ------------

CREATE TABLE	TReimburse	(
/*主键ID*/
PKID			INT	IDENTITY	NOT NULL  ,	
/*员工ID*/
EmployeeId		INT			NOT NULL  ,
/*部门ID*/
DepartmentID		Int			Not null  ,
/*申请时间*/
ApplyDate		DateTime		Not null  ,
/*报销分类*/
ReimburseCategoriesEnum	Int			Not null  ,
/*单据张数*/
PaperCount		Int			Not null  ,
/*消费时间开始*/
ConsumeDateFrom		DateTime		Not null  ,
/*消费时间结束*/
ConsumeDateTo		DateTime		Not null  ,
/*目的地*/
Destinations		Nvarchar(50)		Not null  ,
/*客户名*/
CustomerName		Nvarchar(50)		Not null  ,
/*项目*/
Project			Nvarchar(50)		Not null  ,
/*报销状态*/
ReimburseStatus		Int			Not null  ,
/*报销总额*/
TotalCost		Decimal(14,2)		NOT NULL  ,
/*部门名*/
DepartmentName		Nvarchar(50)		NOT NULL  ,
/*提交时间*/
CommitTime		DateTime			  ,
/*记账时间*/
BillingTime		DateTime			  ,
CONSTRAINT PK_TReimburse PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TReimburse UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TReimburseItem	(
/*主键ID*/
PKID			INT	IDENTITY	NOT NULL  ,	
/*报销单ID*/
ReimburseID		INT			NOT NULL  ,
/*费用类别ID*/
ReimburseType		INT			NOT NULL  ,
/*消费地点*/
ConsumePlace		nvarchar(100)		NOT NULL  Default '',
/*消费项目*/
ProjectName		nvarchar(50)		NOT NULL  ,
/*金额*/
TotalCost		Decimal(14,2)		NOT NULL  ,
/*事由*/
Reason			text			Not Null  ,
CONSTRAINT PK_TReimburseItem PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TReimburseItem UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TReimburseFlow	(	   
PKID			INT	IDENTITY	NOT NULL  ,	
ReimburseID		INT			NOT NULL  ,
OperatorID		Int			Not null  ,
ReimburseStatus		Int			Not null  ,
OperationTime		DateTime		Not null  ,
CONSTRAINT PK_TReimburseFlow PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TReimburseFlow UNIQUE NONCLUSTERED (PKID)
)	
GO

--End                报销单管理       -------------


--部门历史dbo.TDepartmentHistory

Alter Table  dbo.TDepartmentHistory Add [Address] Nvarchar(200)
Alter Table  dbo.TDepartmentHistory Add Phone Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add Fax Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add Others Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add [Description] TEXT
Alter Table  dbo.TDepartmentHistory Add FoundationTime DateTime


--- start  年终绩效考核绑定职位 ------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplatePaperBindPostion' AND type = 'U')
	DROP TABLE TAssessTemplatePaperBindPostion
GO
--- end    年终绩效考核绑定职位 ------

--- start  年终绩效考核绑定职位 ------
CREATE TABLE	TAssessTemplatePaperBindPostion	(
PKID	        INT	IDENTITY    NOT NULL,
PaperID       INT  NOT NULL,
PositionID    INT  NOT NULL,
CONSTRAINT PK_TAssessTemplatePaperBindPostion PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TAssessTemplatePaperBindPostion UNIQUE NONCLUSTERED (PKID)
)
GO
--- end   年终绩效考核绑定职位 ------

--职务字段
alter table dbo.TEmployee add PrincipalShipID int null
alter table dbo.TEmployeeHistory add PrincipalShipID int null

--- start  客户信息 ------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCustomerInfo' AND type = 'U')
	DROP TABLE TCustomerInfo	
GO

CREATE TABLE	TCustomerInfo	(
PKID	            INT	IDENTITY    NOT NULL,
CompanyName              Nvarchar(200)   NOT NULL,
CONSTRAINT PK_TCustomerInfo PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TCustomerInfo UNIQUE NONCLUSTERED (PKID)
)
GO
--- end  客户信息 ------

--贝加莱
