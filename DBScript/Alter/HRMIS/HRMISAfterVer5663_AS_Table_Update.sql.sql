ALTER TABLE TEmployee  ADD WorkPlace Nvarchar(50);--工作地点
---请假类型---

Alter table TLeaveRequestType Add IncludeRestDay int  not null default 0

---请假类型---

Alter table TDutyClass Alter column AbsentLateTime int not null 
Alter table TDutyClass Alter column AbsentEarlyLeaveTime int not null 

ALTER TABLE TAssessActivity  ADD [IfEmployeeVisible] int;--员工是否可见

ALTER TABLE TCourse ADD HasCertification INT NOT NULL DEFAULT 0


--begin            培训申请        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TTrainApplication' AND type = 'U')
    DROP TABLE TTrainApplication
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TTrainAppTrainee' AND type = 'U')
	DROP TABLE TTrainAppTrainee
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TTrainAppFlow' AND type = 'U')
	DROP TABLE TTrainAppFlow	
GO

CREATE TABLE TTrainApplication 	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
CourseName	       Nvarchar(200) NOT NULL,--课程名称
ApplicationId	   INT	           NOT NULL,--申请renID，TEmployee的PKID
TrainType	       INT	           NOT NULL,--	培训范围 1.	内部培训 2.	外部培训
Trainer	           Nvarchar(50)  NOT NULL,--		培训师
Skills   	       Nvarchar(200) NOT NULL,--相关技能
StratTime	       DateTime	       NOT NULL,--		计划开始时间
EndTime  	       DateTime	       NOT NULL,--		计划结束时间
TrianPlace         Nvarchar(200)    NOT NULL,
TrainOrgnatiaon	   Nvarchar(200)    NOT NULL, --培训机构
TrainHour	       Decimal (25,2)	NOT NULL,--		培训课时
TrainCost	       Decimal (25,2)	NOT NULL,--		培训成本
HasCertification    Int              NOT NUll default 0,  --是否有证书
NextStepIndex      INT              NOT NULL,
ApplicationStatus  INT              NOT NULL,
DiyProcess         Text             NOT NULL,
    CONSTRAINT PK_TTrainApplication PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainApplication UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TTrainAppTrainee	(	   
PKID	      INT	IDENTITY NOT NULL,--	主键
TrainAppID	  INT	NOT NULL,--	培训课程ID，TTrainApplication的PKID
TraineeID	  INT	NOT NULL,--		被培训人员ID，TEmployee的PKID
    CONSTRAINT PK_TTrainAppTrainee PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainAppTrainee UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TTrainAppFlow	(
PKID	            INT	IDENTITY    NOT NULL,
TrainAppID      INT             NOT NULL,  --申请课程id
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
OperationTime       DATETIME        NOT NULL,  --操作时间
    CONSTRAINT PK_TTrainAppFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainAppFlow UNIQUE NONCLUSTERED (PKID)
)
GO

--end            培训申请        -------------


Alter table TAssessActivityItem Add AssessTemplateItemType int  not null default 0--考评
Alter table TAssessActivityItem Add Weight decimal(25,2) not null default 0--考评
Alter table TAssessTemplatePIShip Add Weight decimal(25,2) not null default 0--考评