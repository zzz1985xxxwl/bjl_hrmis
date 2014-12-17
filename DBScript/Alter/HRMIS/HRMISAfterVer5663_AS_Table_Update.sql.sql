ALTER TABLE TEmployee  ADD WorkPlace Nvarchar(50);--�����ص�
---�������---

Alter table TLeaveRequestType Add IncludeRestDay int  not null default 0

---�������---

Alter table TDutyClass Alter column AbsentLateTime int not null 
Alter table TDutyClass Alter column AbsentEarlyLeaveTime int not null 

ALTER TABLE TAssessActivity  ADD [IfEmployeeVisible] int;--Ա���Ƿ�ɼ�

ALTER TABLE TCourse ADD HasCertification INT NOT NULL DEFAULT 0


--begin            ��ѵ����        -------------
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
CourseName	       Nvarchar(200) NOT NULL,--�γ�����
ApplicationId	   INT	           NOT NULL,--����renID��TEmployee��PKID
TrainType	       INT	           NOT NULL,--	��ѵ��Χ 1.	�ڲ���ѵ 2.	�ⲿ��ѵ
Trainer	           Nvarchar(50)  NOT NULL,--		��ѵʦ
Skills   	       Nvarchar(200) NOT NULL,--��ؼ���
StratTime	       DateTime	       NOT NULL,--		�ƻ���ʼʱ��
EndTime  	       DateTime	       NOT NULL,--		�ƻ�����ʱ��
TrianPlace         Nvarchar(200)    NOT NULL,
TrainOrgnatiaon	   Nvarchar(200)    NOT NULL, --��ѵ����
TrainHour	       Decimal (25,2)	NOT NULL,--		��ѵ��ʱ
TrainCost	       Decimal (25,2)	NOT NULL,--		��ѵ�ɱ�
HasCertification    Int              NOT NUll default 0,  --�Ƿ���֤��
NextStepIndex      INT              NOT NULL,
ApplicationStatus  INT              NOT NULL,
DiyProcess         Text             NOT NULL,
    CONSTRAINT PK_TTrainApplication PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainApplication UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TTrainAppTrainee	(	   
PKID	      INT	IDENTITY NOT NULL,--	����
TrainAppID	  INT	NOT NULL,--	��ѵ�γ�ID��TTrainApplication��PKID
TraineeID	  INT	NOT NULL,--		����ѵ��ԱID��TEmployee��PKID
    CONSTRAINT PK_TTrainAppTrainee PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainAppTrainee UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TTrainAppFlow	(
PKID	            INT	IDENTITY    NOT NULL,
TrainAppID      INT             NOT NULL,  --����γ�id
OperatorID	        INT	            NOT NULL,  --�����˱��
Operation           INT	            NOT NULL,  --��������
OperationTime       DATETIME        NOT NULL,  --����ʱ��
    CONSTRAINT PK_TTrainAppFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainAppFlow UNIQUE NONCLUSTERED (PKID)
)
GO

--end            ��ѵ����        -------------


Alter table TAssessActivityItem Add AssessTemplateItemType int  not null default 0--����
Alter table TAssessActivityItem Add Weight decimal(25,2) not null default 0--����
Alter table TAssessTemplatePIShip Add Weight decimal(25,2) not null default 0--����