--������ start
alter table dbo.TOutApplication add OutType int not null default 0




--- start ���ݹ��� -------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustRule' AND type = 'U')
	DROP TABLE TAdjustRule
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAdjustRule' AND type = 'U')
	DROP TABLE TEmployeeAdjustRule
GO
--- end   ���ݹ��� -------

--- start ���ݹ��� -------
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

--- end   ���ݹ��� -------

--- start ��� -------
Alter table TDutyClass drop column FirstStartTime
Alter table TDutyClass Add  FirstStartFromTime    DateTime           NOT NULL default '2009-1-1 8:00:00'--�趨���ϰ������ʱ��
Alter table TDutyClass Add  FirstStartToTime      DateTime           NOT NULL default '2009-1-1 9:00:00'--�趨���°������ʱ��
Alter table TDutyClass Add  AllLimitTime  Decimal	             NOT NULL default 9--�趨��һ��������ϰ�ʱ�� 
--- end   ��� -------


alter table dbo.TEmployee add PositionGradeId int not null default -1
alter table dbo.TEmployeeHistory add PositionGradeId int not null default -1
alter table dbo.TEmployee add ProbationStartTime DateTime null
alter table dbo.TEmployeeHistory add ProbationStartTime DateTime null

update dbo.TEmployee set PositionGradeId=-1
update dbo.TEmployeeHistory set PositionGradeId=-1

--��ѵ
alter table TCourseTrainee add CertificationName	  Nvarchar(50)	NULL

/***********************************************************************************
**                                                                                **
**                               ɾ����                                           **
**                                                                                **
***********************************************************************************/

--Begin             ����������        ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburse' AND type = 'U')
	DROP TABLE TReimburse	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseItem' AND type = 'U')
	DROP TABLE TReimburseItem	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseFlow' AND type = 'U')
	DROP TABLE TReimburseFlow	
GO

--End                ����������       -------------



/***********************************************************************************
**                                                                                **
**                               ������                                           **
**                                                                                **
***********************************************************************************/

/***********************************************************************************
**                                                                                **
**                               ɾ����                                           **
**                                                                                **
***********************************************************************************/

--Begin             ����������        ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburse' AND type = 'U')
	DROP TABLE TReimburse	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseItem' AND type = 'U')
	DROP TABLE TReimburseItem	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReimburseFlow' AND type = 'U')
	DROP TABLE TReimburseFlow	
GO

--End                ����������       -------------



/***********************************************************************************
**                                                                                **
**                               ������                                           **
**                                                                                **
***********************************************************************************/

--Begin             ����������        ------------

CREATE TABLE	TReimburse	(
/*����ID*/
PKID			INT	IDENTITY	NOT NULL  ,	
/*Ա��ID*/
EmployeeId		INT			NOT NULL  ,
/*����ID*/
DepartmentID		Int			Not null  ,
/*����ʱ��*/
ApplyDate		DateTime		Not null  ,
/*��������*/
ReimburseCategoriesEnum	Int			Not null  ,
/*��������*/
PaperCount		Int			Not null  ,
/*����ʱ�俪ʼ*/
ConsumeDateFrom		DateTime		Not null  ,
/*����ʱ�����*/
ConsumeDateTo		DateTime		Not null  ,
/*Ŀ�ĵ�*/
Destinations		Nvarchar(50)		Not null  ,
/*�ͻ���*/
CustomerName		Nvarchar(50)		Not null  ,
/*��Ŀ*/
Project			Nvarchar(50)		Not null  ,
/*����״̬*/
ReimburseStatus		Int			Not null  ,
/*�����ܶ�*/
TotalCost		Decimal(14,2)		NOT NULL  ,
/*������*/
DepartmentName		Nvarchar(50)		NOT NULL  ,
/*�ύʱ��*/
CommitTime		DateTime			  ,
/*����ʱ��*/
BillingTime		DateTime			  ,
CONSTRAINT PK_TReimburse PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TReimburse UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TReimburseItem	(
/*����ID*/
PKID			INT	IDENTITY	NOT NULL  ,	
/*������ID*/
ReimburseID		INT			NOT NULL  ,
/*�������ID*/
ReimburseType		INT			NOT NULL  ,
/*���ѵص�*/
ConsumePlace		nvarchar(100)		NOT NULL  Default '',
/*������Ŀ*/
ProjectName		nvarchar(50)		NOT NULL  ,
/*���*/
TotalCost		Decimal(14,2)		NOT NULL  ,
/*����*/
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

--End                ����������       -------------


--������ʷdbo.TDepartmentHistory

Alter Table  dbo.TDepartmentHistory Add [Address] Nvarchar(200)
Alter Table  dbo.TDepartmentHistory Add Phone Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add Fax Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add Others Nvarchar(50)
Alter Table  dbo.TDepartmentHistory Add [Description] TEXT
Alter Table  dbo.TDepartmentHistory Add FoundationTime DateTime


--- start  ���ռ�Ч���˰�ְλ ------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplatePaperBindPostion' AND type = 'U')
	DROP TABLE TAssessTemplatePaperBindPostion
GO
--- end    ���ռ�Ч���˰�ְλ ------

--- start  ���ռ�Ч���˰�ְλ ------
CREATE TABLE	TAssessTemplatePaperBindPostion	(
PKID	        INT	IDENTITY    NOT NULL,
PaperID       INT  NOT NULL,
PositionID    INT  NOT NULL,
CONSTRAINT PK_TAssessTemplatePaperBindPostion PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TAssessTemplatePaperBindPostion UNIQUE NONCLUSTERED (PKID)
)
GO
--- end   ���ռ�Ч���˰�ְλ ------

--ְ���ֶ�
alter table dbo.TEmployee add PrincipalShipID int null
alter table dbo.TEmployeeHistory add PrincipalShipID int null

--- start  �ͻ���Ϣ ------

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
--- end  �ͻ���Ϣ ------

--������
