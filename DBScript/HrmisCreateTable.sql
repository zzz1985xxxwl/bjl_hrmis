/***********************************************************************************
**                                                                                **
**                               删除表                                           **
**                                                                                **
***********************************************************************************/

--begin            权限			  -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAuth' AND type = 'U')
	DROP TABLE TAuth
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAccountAuth' AND type = 'U')
	DROP TABLE TAccountAuth
GO
--end            权限	          -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeSkill' AND type = 'U')
	DROP TABLE TEmployeeSkill
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TParameter' AND type = 'U')
	DROP TABLE TParameter
GO

--begin            历史信息        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeHistory' AND type = 'U')
    DROP TABLE TEmployeeHistory
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TDepartmentHistory' AND type = 'U')
	DROP TABLE TDepartmentHistory
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionHistory' AND type = 'U')
	DROP TABLE TPositionHistory	
GO

--end            历史信息        -------------

--begin    技能      -----------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSkill' AND type = 'U')
    DROP TABLE TSkill
GO
--end    技能      -----------

--begin    员工其他信息      -----------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeContract' AND type = 'U')
    DROP TABLE TEmployeeContract
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TApplyAssessCondition' AND type = 'U')
	DROP TABLE TApplyAssessCondition
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TVacation' AND type = 'U')
	DROP TABLE TVacation
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeWelfare' AND type = 'U')
    DROP TABLE TEmployeeWelfare
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeWelfareHistory' AND type = 'U')
    DROP TABLE TEmployeeWelfareHistory
GO
--End    员工其他信息      -----------

--Begin                 合同类型      -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TContractType' AND type = 'U')
	DROP TABLE TContractType
GO

--End                 合同类型      -------------

--Begin    记录合同模板的书签      ---------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TContractBookMark' AND type = 'U')
	DROP TABLE TContractBookMark
GO
--End    记录合同模板的书签      ---------------

--Begin    记录员工合同的书签和值      ---------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeContractBookMark' AND type = 'U')
	DROP TABLE TEmployeeContractBookMark
GO
--End    记录员工合同的书签和值      ---------------


--Begin          员工管理      -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployee' AND type = 'U')
	DROP TABLE TEmployee
GO
--End            员工管理      -------------

--Begin          考勤管理      -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequest' AND type = 'U')
	DROP TABLE TLeaveRequest
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestItem' AND type = 'U')
	DROP TABLE TLeaveRequestItem
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestFlow' AND type = 'U')
	DROP TABLE TLeaveRequestFlow
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationItem' AND type = 'U')
	DROP TABLE TOutApplicationItem
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplication' AND type = 'U')
	DROP TABLE TOutApplication
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationFlow' AND type = 'U')
	DROP TABLE TOutApplicationFlow
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkItem' AND type = 'U')
	DROP TABLE TOverWorkItem
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWork' AND type = 'U')
	DROP TABLE TOverWork
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkFlow' AND type = 'U')
	DROP TABLE TOverWorkFlow
GO


--End            考勤管理      -------------

--Begin               考勤       -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeInAndOutRecord' AND type = 'U')
	DROP TABLE TEmployeeInAndOutRecord
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReadDataHistory' AND type = 'U')
	DROP TABLE TReadDataHistory
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAttendanceReadTime' AND type = 'U')
	DROP TABLE TAttendanceReadTime
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TInAndOutRecordLog' AND type = 'U')
	DROP TABLE TInAndOutRecordLog	
GO

--End                考勤       -------------

--Begin             员工出勤         ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAttendance' AND type = 'U')
	DROP TABLE TEmployeeAttendance	
GO

--End                员工出勤       -------------


--Begin            请假类型          ------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLeaveRequestType]') AND type in (N'U'))
DROP TABLE [dbo].[TLeaveRequestType]
--End              请假类型         ------------


--Begin            税制          ------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TIndividualIncomeTax' AND type = 'U')
	DROP TABLE TIndividualIncomeTax
GO
	
--End               税制         ------------


--Begin             帐套         ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAccountSet' AND type = 'U')
	DROP TABLE TAccountSet
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAccountSetPara' AND type = 'U')
	DROP TABLE TAccountSetPara
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAccountSetItem' AND type = 'U')
	DROP TABLE TAccountSetItem
GO


--End               帐套         ------------


--Begin    员工薪资      ---------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAccountSet' AND type = 'U')
    DROP TABLE TEmployeeAccountSet 
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustSalaryHistory' AND type = 'U')
    DROP TABLE TAdjustSalaryHistory 
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeSalaryHistory' AND type = 'U')
    DROP TABLE TEmployeeSalaryHistory
GO

--End    员工薪资      ---------------
--Begin             调休         ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustRest' AND type = 'U')
	DROP TABLE TAdjustRest	
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustRestHistory' AND type = 'U')
	DROP TABLE TAdjustRestHistory
GO
--End                调休       -------------

--Begin             考评管理         ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplateItem' AND type = 'U')
	DROP TABLE TAssessTemplateItem
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplatePaper' AND type = 'U')
	DROP TABLE TAssessTemplatePaper
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplatePIShip' AND type = 'U')
	DROP TABLE TAssessTemplatePIShip
GO

--End               考评管理         ------------

--begin             考评活动         ------------

/****** 对象:  Table [dbo].[TAssessActivity]    脚本日期: 04/16/2009 12:53:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAssessActivity]') AND type in (N'U'))
DROP TABLE [dbo].[TAssessActivity]

/****** 对象:  Table [dbo].[TAssessActivityItem]    脚本日期: 04/16/2009 13:17:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAssessActivityItem]') AND type in (N'U'))
DROP TABLE [dbo].[TAssessActivityItem]

/****** 对象:  Table [dbo].[TAssessActivityPaper]   脚本日期: 04/16/2009 13:17:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAssessActivityPaper]') AND type in (N'U'))
DROP TABLE [dbo].[TAssessActivityPaper]

--end               考评活动         ------------


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


--Begin              自定义流程        ------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TDiyProcess' AND type = 'U')
	DROP TABLE TDiyProcess	
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TDiyStep' AND type = 'U')
	DROP TABLE TDiyStep	
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeDiyProcess' AND type = 'U')
	DROP TABLE TEmployeeDiyProcess	
GO
 
--End                 自定义流程       -------------
 

--Begin               班别       -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TDutyClass' AND type = 'U')
	DROP TABLE TDutyClass
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyTable' AND type = 'U')
	DROP TABLE TPlanDutyTable
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyDetail' AND type = 'U')
	DROP TABLE TPlanDutyDetail
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDuty' AND type = 'U')
	DROP TABLE TPlanDuty
GO

--End                班别       -------------

--begin                培训       -------------

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TTrainFBQues' AND type = 'U')
	DROP TABLE TTrainFBQues
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TTrainFBItem' AND type = 'U')
	DROP TABLE TTrainFBItem
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCourse' AND type = 'U')
	DROP TABLE TCourse
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCourseTrainee' AND type = 'U')
	DROP TABLE TCourseTrainee
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCourseSkill' AND type = 'U')
	DROP TABLE TCourseSkill
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCourseFBResult' AND type = 'U')
	DROP TABLE TCourseFBResult
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCourseFB' AND type = 'U')
	DROP TABLE TCourseFB
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFeedBackPaper' AND type = 'U')
	DROP TABLE TFeedBackPaper
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFeedBackPIShip' AND type = 'U')
	DROP TABLE TFeedBackPIShip
GO
--end                培训       -------------

--begin                短消息       -----------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPhoneMessage' AND type = 'U')
	DROP TABLE TPhoneMessage
GO
--end                短消息       -------------

--begin              员工档案       -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TFileCargo' AND type = 'U')
	DROP TABLE TFileCargo
GO
--end                员工档案       -------------

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

--end            培训申请        -------------



--- start 调休规则 -------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAdjustRule' AND type = 'U')
	DROP TABLE TAdjustRule
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAdjustRule' AND type = 'U')
	DROP TABLE TEmployeeAdjustRule
GO
--- end   调休规则 -------


--- start  年终绩效考核绑定职位 ------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAssessTemplatePaperBindPostion' AND type = 'U')
	DROP TABLE TAssessTemplatePaperBindPostion
GO
--- end    年终绩效考核绑定职位 ------


--- start  客户信息 ------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCustomerInfo' AND type = 'U')
	DROP TABLE TCustomerInfo	
GO
--- end  客户信息 ------

--begin            异常信息        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSystemError' AND type = 'U')
	DROP TABLE TSystemError	
GO
--end            异常信息        -------------

--begin            职位        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionNatureHistory' AND type = 'U')
	DROP TABLE TPositionNatureHistory 	
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionNatureRelationshipHistory' AND type = 'U')
	DROP TABLE TPositionNatureRelationshipHistory	
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPositionHistory' AND type = 'U')
	DROP TABLE TPositionHistory	
GO

--end            职位        -------------
/***********************************************************************************
**                                                                                **
**                               创建表                                           **
**                                                                                **
***********************************************************************************/


--Begin          考勤管理      -------------

CREATE TABLE	TLeaveRequest	(
PKID	            INT	IDENTITY    NOT NULL,
AccountID	        INT	            NOT NULL,  --请假员工编号
LeaveRequestTypeID  INT	            NOT NULL,  --请假类型
Reason			    TEXT            NOT NULL,  --请假原因
SubmitDate          DATETIME        NOT NULL,  --递交请假单日期
AbsentFrom          DATETIME        NOT NULL,  --请假开始时间
AbsentTo            DATETIME        NOT NULL,  --请假结束时间
AbsentHours         Decimal(25,2)   NOT NULL,  --请假时间段，按小时计
DiyProcess          Text			NOT NULL,  --自定义流程
    CONSTRAINT PK_TLeaveRequest PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TLeaveRequest UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE	TLeaveRequestItem	(
PKID	            INT	IDENTITY    NOT NULL,
LeaveRequestID      INT			    NOT NULL,
[Status]            INT             NOT NULL,  --请假单状态
AbsentFrom          DATETIME        NOT NULL,  --请假开始时间
AbsentTo            DATETIME        NOT NULL,  --请假结束时间
AbsentHours         Decimal(25,2)   NOT NULL,  --请假时间段，按小时计
--IfPass              INT             NOT NULL,  --是否通过
NextProcessID       INT             NOT NULL,  --下一步骤
UseList             Nvarchar(200) ,
    CONSTRAINT PK_TLeaveRequestItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TLeaveRequestItem UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE	TLeaveRequestFlow	(
PKID	            INT	IDENTITY    NOT NULL,
LeaveRequestItemID  INT             NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
--0 新增 1 审核通过 2 审核不通过 3 申请取消 4 批准取消假期 5 拒绝取消假期
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL,  --备注
    CONSTRAINT PK_TLeaveRequestFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TLeaveRequestFlow UNIQUE NONCLUSTERED (PKID)
)
GO

--Begin             申请外出，加班         ------------
CREATE TABLE [dbo].[TOutApplication](
	[PKID]        int  IDENTITY          NOT NULL,
	[AccountID]   int            NOT NULL,
	[SubmitDate]  datetime       NOT NULL,
	[From]        datetime       NOT NULL,
	[To]          datetime       NOT NULL,
	[CostTime]    decimal(25, 2) NULL,
	[Reason]      text           NOT NULL,
	[OutLocation] nvarchar(50)   NULL,--外出地点
    OutType       int   NOT NULL,--外出类型
    [DiyProcess]          Text	  NOT NULL,  --自定义流程
    CONSTRAINT PK_TOutApplication PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOutApplication UNIQUE NONCLUSTERED (PKID)
)
GO


CREATE TABLE	TOutApplicationItem	(
PKID	            INT	IDENTITY    NOT NULL,
OutApplicationID      INT			    NOT NULL,
[Status]            INT             NOT NULL,
[From]          DATETIME        NOT NULL,  
[To]            DATETIME        NOT NULL, 
[CostTime]         Decimal(25,2)   NOT NULL, 
Adjust              INT            NOT NULL,
AdjustHour      Decimal(25,2)      NOT NULL,
    CONSTRAINT PK_TOutApplicationItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOutApplicationItem UNIQUE NONCLUSTERED (PKID)
)
GO


CREATE TABLE	TOutApplicationFlow	(
PKID	            INT	IDENTITY    NOT NULL,
OutApplicationItemID  INT           NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL,  --备注
Step                int  NOT NULL, --当前第几步
    CONSTRAINT PK_TOutApplicationFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOutApplicationFlow UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE [dbo].[TOverWork](
	[PKID]       int  IDENTITY    NOT NULL,
	[AccountID]  int              NOT NULL,
	[SubmitDate] datetime         NOT NULL,
	[From]       datetime         NOT NULL,
	[To]         datetime         NOT NULL,
	[CostTime]   decimal(25, 2)   NULL,
	[Reason]     text             NOT NULL,
	[ProjectName] nvarchar(50)    NULL,--加班项目,
    DiyProcess          Text			NOT NULL,  --自定义流程
	CONSTRAINT PK_TOverWork PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOverWork UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE	TOverWorkItem	(
PKID	        INT	IDENTITY    NOT NULL,
OverWorkID      INT	            NOT NULL,
[Status]        INT             NOT NULL,
[From]          DATETIME        NOT NULL,  
[To]            DATETIME        NOT NULL, 
[CostTime]      Decimal(25,2)   NOT NULL,
[OverWorkType]  INT             NOT NULL,
[Adjust]        INT             NOT NULL,
AdjustHour      Decimal(25,2)      NOT NULL,
    CONSTRAINT PK_TOverWorkItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOverWorkItem UNIQUE NONCLUSTERED (PKID)
)
GO


CREATE TABLE	TOverWorkFlow	(
PKID	            INT	IDENTITY    NOT NULL,
OverWorkItemID      INT             NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL,  --备注
Step                int  NOT NULL, --当前第几步
    CONSTRAINT PK_TOverWorkFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TOverWorkFlow UNIQUE NONCLUSTERED (PKID)
)
GO

--Begin                申请外出，加班       -------------

--Begin             调休         ------------

CREATE TABLE	TAdjustRest	(	   
PKID	            INT	IDENTITY   NOT NULL  ,	
AccountId          INT	           NOT NULL  ,
Hours Decimal(25,2) NOT NULL DEFAULT  0,
AdjustYear DateTime Not Null ,
CONSTRAINT PK_TAdjustRest PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TAdjustRest UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TAdjustRestHistory	(	   
PKID	            INT	IDENTITY   NOT NULL  ,	
AccountID		int Not null,
OccurTime			Datetime	   Not null,
OperatorId          INT	           NOT NULL  ,
ChangeHours Decimal(25,2) NOT NULL DEFAULT  0,--变动小时数，可能为正可能为负
AdjustRestHistoryType  INT	  NOT NULL DEFAULT  0,--区分此次历史生成的信息来源
RelevantID Int	  NOT NULL DEFAULT  0,
Remark Nvarchar(255) Not null default '',
CONSTRAINT PK_TAdjustRestHistory PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TAdjustRestHistory UNIQUE NONCLUSTERED (PKID)
)	
GO
--End                调休       -------------
--End            考勤管理      -------------

--Begin            请假类型          ------------
CREATE TABLE TLeaveRequestType	
(
	PKID		INT IDENTITY		NOT NULL, 
	[Name]	nvarchar (50) NOT NULL,
	Description text NULL,
    IncludeNationalHolidays int NOT NULL,
    IncludeRestDay int NOT NULL,
    LeastHour decimal (6,2)  NOT NULL,
	CONSTRAINT PK_TLeaveRequestType PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TLeaveRequestType UNIQUE NONCLUSTERED (PKID)
)			
GO
--End              请假类型         ------------

--Begin               考勤       -------------

--员工考勤记录
CREATE TABLE TEmployeeInAndOutRecord (
    PKID	  INT IDENTITY       NOT NULL,--每条记录的标识
    EmployeeID   INT             NOT NULL,--员工ID
    DoorCardNo  Nvarchar(50)     NOT NULL,--员工门禁卡卡号
    IOTime    DateTime	         NOT NULL,--刷卡时间
    IOStatus  INT	             NOT NULL,--刷卡状态，0：进，1：出
    OperateStatus  INT           NOT NULL,--0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
    OperateTime DateTime         NOT NULL,--每次操作的时间
	CONSTRAINT PK_TEmployeeInAndOutRecord PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeInAndOutRecord UNIQUE NONCLUSTERED (PKID)
) 
GO

--读取记录
CREATE TABLE TReadDataHistory (
    PKID	   INT IDENTITY       NOT NULL,--每条记录的标识
    ReadTime   DateTime           NOT NULL,--读取数据库的时间
    ReadResult INT                NOT NULL,--读取的结果，0：读取中，1：读取成功，2：读取失败
    FailReason text
	CONSTRAINT PK_TReadDataHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TReadDataHistory UNIQUE NONCLUSTERED (PKID)
) 
GO

--保存每天定时读取数据库的时间
CREATE TABLE TAttendanceReadTime (
    PKID	       INT IDENTITY       NOT NULL,--每条记录的标识
    ReadDateTime   DateTime           NOT NULL,--设置每天定时读取数据库的时间
    IsSendEmail    INT                NOT NULL,--设置是否发送email 0：不发送，1：发送
    SendEmailRull  INT                NOT NULL DEFAULT 0,--设定发送email的对象 0:发送给进入时间为空的员工  1：离开时间为空的员工  2：进入和离开时间都为空的员工
	CONSTRAINT PK_TAttendanceReadTime PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAttendanceReadTime UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE	TInAndOutRecordLog	(	  
PKID	            INT	IDENTITY    NOT NULL  ,	
EmployeeID          INT	            NOT NULL  ,
OldIOTime		    DateTime		NULL  ,
OldIOStatus		    INT	            NULL  ,
NewIOTime	        DateTime        NULL  ,	
NewIOStatus         INT	            NULL  ,
OperateStatus	    Int			    Not NULL  ,
Operator	        NVarChar(50)    NOT NULL  ,	
OperateTime         DateTime        NOT NULL  ,
OperateReason	    text			Not NULL  ,
CONSTRAINT PK_TInAndOutRecordLog PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TInAndOutRecordLog UNIQUE NONCLUSTERED (PKID)
)	
GO

--End               考勤       -------------
--Begin             员工出勤         ------------

CREATE TABLE	TEmployeeAttendance	(	   
PKID	            INT	IDENTITY   NOT NULL,	
EmployeeId          INT	           NOT NULL  ,
[Name]	            NVarChar(50)   NOT NULL,  --考勤名字,如外出,请假,旷工
Days                decimal(9,2)        NOT NULL DEFAULT 0,  --持续的时间
AddDutyDays         decimal(9,2)	       NOT NULL DEFAULT 0, -- 增加的出勤天数
EarlyAndLateMunite  int        NOT NULL DEFAULT 0,
TheDay            DATETIME         NOT NULL,  --缺勤日期
AttendanceType        INT          NOT NULL       --考勤类型
CONSTRAINT PK_TEmployeeAttendance PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TEmployeeAttendance UNIQUE NONCLUSTERED (PKID)

)	
GO
--End                员工出勤       -------------

--Begin          员工管理      -------------	
CREATE TABLE TEmployee(
	PKID            INT IDENTITY   NOT NULL,
    CompanyID      INT Not null,
	AccountID  Int NOT NULL,
    ComeDate        DateTime,
    LeaveDate        DateTime,
    Birthday        DateTime,
    ResidencePermit DateTime,
    EmployeeType    INT            NOT NULL,
    EnglishName Nvarchar(50),
	Gender	INT,
	PoliticalAffiliation	INT,
	MaritalStatus	INT,
	EducationalBackground	INT,
	WorkType	INT,
	HasChild	INT,
	EmployeeDetails IMAGE,
	Certificates	Nvarchar(2000),
	PRPArea	Nvarchar(255),
	ProbationTime DateTime,
    Photo  Image,
    DoorCardNo Nvarchar(50),--门禁卡卡号
    SocietyWorkAge int,--社会工龄
    CountryNationalityID int,--国籍编号
    WorkPlace Nvarchar(50),--工作地点
	SalaryCardNo Nvarchar(255),--工资卡号
	SalaryCardBank Nvarchar(255),--工资卡号银行
    PositionGradeId  int NOT NULL,
	ProbationStartTime DateTime,
    PrincipalShipID  int,
   CONSTRAINT PK_TEmployee PRIMARY KEY NONCLUSTERED (PKID),
   CONSTRAINT TC_TEmployee UNIQUE NONCLUSTERED (PKID)
   
)	
GO
--end          员工管理      -------------


--Begin                 合同类型      -------------
CREATE TABLE TContractType (
    PKID	  INT IDENTITY  NOT NULL,
    [Name]    Nvarchar(50)	NOT NULL,
    [Template] image,
	CONSTRAINT PK_TContractType PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TContractType UNIQUE NONCLUSTERED (PKID)
) 
GO
--End                 合同类型       -------------


--Begin    记录合同模板的书签      ---------------
CREATE TABLE TContractBookMark (
    PKID	  INT IDENTITY  NOT NULL,
    ContractTypeID    INT    NOT NULL,
    [BookMarkName]    Nvarchar(50)	NOT NULL,
    
	CONSTRAINT PK_TContractBookMark PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TContractBookMark UNIQUE NONCLUSTERED (PKID)
) 
GO

--End    记录合同模板的书签      -----------


--Begin    记录员工合同的书签和值      ---------------
CREATE TABLE TEmployeeContractBookMark (
    PKID	  INT IDENTITY  NOT NULL,
    EmployeeContractID  INT  NOT NULL,
    [BookMarkName]    Nvarchar(50)	NOT NULL,
    BookMarkValue     Text	,
	CONSTRAINT PK_TEmployeeContractBookMark PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeContractBookMark UNIQUE NONCLUSTERED (PKID)
) 
GO
--End    记录员工合同的书签和值      -----------
--begin    员工其他信息      -----------
CREATE TABLE TEmployeeContract(
   PKID           INT IDENTITY  NOT NULL,
   AccountID     INT           NOT NULL,
   ContractTypeID INT           NOT NULL,
   StartDate      DateTime      NOT NULL,
   EndDate        DateTime      NOT NULL,
   Remark         Text ,         
   Attachment     Text ,
   CONSTRAINT PK_TEmployeeContract PRIMARY KEY NONCLUSTERED (PKID),
   CONSTRAINT TC_TEmployeeContract UNIQUE NONCLUSTERED (PKID)
)
GO

CREATE TABLE	TApplyAssessCondition	 (  
PKID	      INT	IDENTITY  NOT NULL,
EmployeeContractID	  INT	  NOT NULL,
ApplyDate	  DateTime	      NOT NULL,	
AssessScopeFrom	  DateTime	      NOT NULL,	
AssessScopeTo	  DateTime	      NOT NULL,	
ApplyAssessCharacterType	  INT	  NOT NULL, 
    CONSTRAINT PK_TApplyAssessCondition PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TApplyAssessCondition UNIQUE NONCLUSTERED (PKID)
)			
GO	
 
CREATE TABLE	TVacation	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
AccountID	       INT	           NOT NULL,
EmployeeName	   NVarChar(50)    NOT NULL,   
VacationDayNum	   Decimal(6,3)	   NOT NULL,
VacationStartDate  DateTime	       NOT NULL,  
VacationEndDate    DateTime	       NOT NULL,   
UsedDayNum	       Decimal(6,3)    NOT NULL,
SurplusDayNum	   Decimal(6,3)	   NOT NULL,
Remark	       text	           NULL, 
    CONSTRAINT PK_TVacation PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TVacation UNIQUE NONCLUSTERED (PKID)
)			
GO	
CREATE TABLE	TEmployeeWelfare	
(
	PKID			INT IDENTITY		NOT NULL, 
	AccountID		int			NOT NULL,
	SocialSecurityType	int			 NULL,
	SocialSecurityBase	Decimal(25,2)		NULL,
    SocialSecurityEffectiveYearMonth DateTime NULL,
    AccumulationFundAccount Nvarchar(255) default '' Not NULL,
    AccumulationFundSupplyAccount Nvarchar(255) default '' Not NULL ,
    AccumulationFundSupplyBase Decimal(25,2)  NULL,
    AccumulationFundBase Decimal(25,2) NULL,
    AccumulationFundEffectiveMonthYear DateTime NULL,
	YangLaoBase	Decimal(25,2)		NULL,
	ShiYeBase	Decimal(25,2)		NULL,
	YiLiaoBase	Decimal(25,2)		NULL,	
	CONSTRAINT PK_TEmployeeWelfare PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeWelfare UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TEmployeeWelfareHistory	
(
	PKID			INT IDENTITY		NOT NULL, 
	AccountID		int			NOT NULL,
	SocialSecurityType	int			 NULL,
	SocialSecurityBase	Decimal(25,2)		NULL,
    SocialSecurityEffectiveYearMonth DateTime NULL,
    AccumulationFundAccount Nvarchar(255) default '' Not NULL,
    AccumulationFundSupplyAccount Nvarchar(255) default '' Not NULL,
    AccumulationFundSupplyBase Decimal(25,2)  NULL,
    AccumulationFundBase Decimal(25,2) NULL,
    AccumulationFundEffectiveMonthYear DateTime NULL,
    OperationTime DateTime  NOT NULL,
    AccountsBackName Nvarchar(255) NOT NULL,
	YangLaoBase	Decimal(25,2)		NULL,
	ShiYeBase	Decimal(25,2)		NULL,
	YiLiaoBase	Decimal(25,2)		NULL,	
	CONSTRAINT PK_TEmployeeWelfareHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeWelfareHistory UNIQUE NONCLUSTERED (PKID)
)			
GO
--End    员工其他信息      -----------
--begin    技能      -----------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSkill' AND type = 'U')
    DROP TABLE TSkill
GO

CREATE TABLE TSkill	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
[Name]	           NVarChar(100)   NOT NULL, --技能名称  
TypeID	           INT             NOT NULL,--技能类型ID，TParameter的PKID
    CONSTRAINT PK_TSkill PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TSkill UNIQUE NONCLUSTERED (PKID)
)			
GO	
--end    技能      -----------
--begin    历史信息      -----------

CREATE TABLE TEmployeeHistory(
	PKID            INT IDENTITY   NOT NULL,
    --EmployeeID  INT,--员工编号
	AccountID  Int NOT NULL,
	CompanyID INT NOT NULL,
	AccountType INT NOT NULL,
	MobileNum nvarchar(50),
   IsAcceptEmail INT NOT NULL,
   IsAcceptSMS INT NOT NULL,
   IsValidateUsbKey INT NOT NULL,
    LeaveDate        DateTime,
    [Name]          Nvarchar(50)   NOT NULL,
    LoginName       Nvarchar(50)   NOT NULL,
    [Password]        Nvarchar(2000) NOT NULL,
    Email1           Nvarchar(255)  NOT NUll,
    Email2          Nvarchar(255),
    DepartmentID    INT,
    PositionID      INT,
    ComeDate        DateTime,
    Birthday        DateTime,
    ResidencePermit DateTime,
    EmployeeType    INT            NOT NULL,
    EnglishName Nvarchar(50),
	Gender	INT,
	PoliticalAffiliation	INT,
	MaritalStatus	INT,
	EducationalBackground	INT,
	WorkType	INT,
	HasChild	INT,
	EmployeeDetails IMAGE,
	Certificates	Nvarchar(2000),
	PRPArea	Nvarchar(255),
	ProbationTime DateTime,
   	UsbKey Nvarchar(2000),
    Photo  Image,
    DoorCardNo Nvarchar(50),--门禁卡卡号
    SocietyWorkAge int,--社会工龄
	SalaryCardNo Nvarchar(255),--工资卡号
    SalaryCardBank Nvarchar(255),--工资卡号银行
    OperatorID  INT,--操作人员，后台帐号ID
    OperationTime  DATETIME,--操作时间
	Remark	Nvarchar(255),--修改备注

	LeaderName  Nvarchar(50)   NOT NULL default '',
	DepartmentName  Nvarchar(50)   NOT NULL default '',
	PositionName  Nvarchar(50)   NOT NULL default '',
    OperatorName Nvarchar(50)   NOT NULL default '',
    PositionGradeId  int NOT NULL,
	ProbationStartTime DateTime,
    PrincipalShipID  int,
   CONSTRAINT PK_TEmployeeHistory PRIMARY KEY NONCLUSTERED (PKID),
   CONSTRAINT TC_TEmployeeHistory UNIQUE NONCLUSTERED (PKID)
   
)	
GO

CREATE TABLE 	TDepartmentHistory	(	
    PKID	  INT IDENTITY	NOT NULL,
    DepartmentID  INT	        NOT NULL,
    DepartmentName    Nvarchar(50)	NOT NULL,
    LeaderID  INT	        NOT NULL,
    LeaderName  Nvarchar(50)	NOT NULL,
    ParentID  INT	        NOT NULL,
    [OperatorName]   Nvarchar(50)	 ,
    [OperationTime]  DateTime    NOT NULL,
    [Address] Nvarchar(200),
    Phone Nvarchar(50),
    Fax Nvarchar(50),
    Others Nvarchar(50),
    [Description] TEXT,
    FoundationTime DateTime,
	CONSTRAINT PK_TDepartmentHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TDepartmentHistory UNIQUE NONCLUSTERED (PKID)
)			
GO
CREATE TABLE TPositionHistory (
    PKID	  INT IDENTITY  NOT NULL,
    [PositionID]    INT 	NOT NULL,
    [PositionName]     Nvarchar(50)        NOT NULL,
    [PositionGradeName]    Nvarchar(50)	        NOT NULL DEFAULT '',
    [PositionGradeSequence]    int	        NOT NULL,
    [OperatorName]   Nvarchar(50)	 ,
    [OperationTime]  DateTime    NOT NULL,
	CONSTRAINT PK_TPositionHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPositionHistory UNIQUE NONCLUSTERED (PKID)
) 
GO
--end    历史信息      -----------

CREATE TABLE TParameter (
    PKID	  INT IDENTITY  NOT NULL,
    [Name]    Nvarchar(50)	NOT NULL,
    [Type]    INT	        NOT NULL,
    [Description]    text	        NOT NULL DEFAULT '',
	CONSTRAINT PK_TParameter PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TParameter UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TEmployeeSkill	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
AccountID	INT	            NOT NULL,--		被培训员工ID
SkillID	    INT	            NOT NULL,--		技能ID，TSkill表的PKID
SkillName	Nvarchar(100)	NOT NULL,--		技能名称
SkillRank	INT	            NOT NULL,--		技能等级ID
Score	decimal	default 0,--		分数
Remark	text	default '',--		备注
    CONSTRAINT PK_TEmployeeSkill PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeSkill UNIQUE NONCLUSTERED (PKID)
)			
GO	

--Begin          权限       -------------

CREATE TABLE TAuth	(	   
PKID			INT	IDENTITY    NOT NULL,	   
AuthName		Nvarchar(50)	NOT NULL,
AuthParentId	INT	            NOT NULL,
NavigateUrl		Nvarchar(255)	NOT NULL,
IfHasDepartment	INT	            NOT NULL,
    CONSTRAINT PK_TAuth PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAuth UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE TAccountAuth	(	   
PKID			INT	IDENTITY    NOT NULL,	   
AccountId		INT				NOT NULL,
AuthId			INT	            NOT NULL,
DepartmentID	INT	            NOT NULL,
    CONSTRAINT PK_TAccountAuth PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountAuth UNIQUE NONCLUSTERED (PKID)
)			
GO	

--End            权限       -------------


--Begin             帐套         ------------

CREATE TABLE	TAccountSet	
(
	PKID			INT IDENTITY		NOT NULL, 
	AccountSetName		Nvarchar(255)		NOT NULL,
	Description	Text				NULL
	
	CONSTRAINT PK_TAccountSet PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountSet UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE	TAccountSetPara	
(
	PKID			INT IDENTITY		NOT NULL, 
	AccountSetParaName	Nvarchar(255)		NOT NULL,
        Description	Text				NULL,
	FieldAttribute		INT      		NOT NULL, 
	BindItem	        INT      		NOT NULL,
	MantissaRound	        INT			Default 0,
	IsVisibleToEmployee	        INT			NOT NULL,
	IsVisibleWhenZero	        INT			NOT NULL 
	
	CONSTRAINT PK_TAccountSetPara PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountSetPara UNIQUE NONCLUSTERED (PKID)
)			
GO


CREATE TABLE	TAccountSetItem	
(
	PKID			INT IDENTITY		NOT NULL, 
	AccountSetID		int			NOT NULL,
	AccountSetParaID	int			NOT NULL,
	CalculateFormula	Nvarchar(255)		NULL,
	FieldAttribute		INT      		NOT NULL, 
	BindItem	        INT      		NOT NULL,
	MantissaRound	        INT			NOT NULL
	CONSTRAINT PK_TAccountSetItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountSetItem UNIQUE NONCLUSTERED (PKID)
)			
GO


--End               帐套         ------------

--Begin             员工薪资         ------------
CREATE TABLE TEmployeeAccountSet
(
	PKID					INT IDENTITY	NOT NULL, 
	AccountSetID			int				NOT NULL,
	AccountSetName			Nvarchar(255)	NOT NULL,
	EmployeeID				int				NOT NULL,
	EmployeeAccountSetItems	image			NOT NULL,
	Description				Nvarchar(255)	NULL,
	CONSTRAINT PK_TEmployeeAccountSet PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeAccountSet UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TAdjustSalaryHistory
(
	PKID					INT IDENTITY	NOT NULL,
	EmployeeID				int				NOT NULL,
	AccountSetName			Nvarchar(255)	NOT NULL,
	EmployeeAccountSetItems	image			NOT NULL,
	Description				Nvarchar(255)	NULL,
	ChangeDate				DateTime		NOT NULL,
	AccountsBackName		Nvarchar(255)	NOT NULL,
	CONSTRAINT PK_TAdjustSalaryHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAdjustSalaryHistory UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TEmployeeSalaryHistory
(
	PKID					INT IDENTITY	NOT NULL,
	EmployeeID				int				NOT NULL,
	AccountSetID			int				NOT NULL,
	AccountSetName			Nvarchar(255)	NOT NULL,
	EmployeeAccountSetItems	image			NULL,
	VersionNumber			int				NOT NULL,
	Status					int				NOT NULL,
	SalaryDateTime			DateTime		NOT NULL,
	AccountsBackName		Nvarchar(255)	NOT NULL,
    Descpriton		        Nvarchar(255)   NULL
	CONSTRAINT PK_TEmployeeSalaryHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TEmployeeSalaryHistory UNIQUE NONCLUSTERED (PKID)
)			
GO

--End               员工薪资         ------------

--Begin            税制          ------------
CREATE TABLE   TIndividualIncomeTax	
(
	PKID		INT IDENTITY		NOT NULL, 
	BandMin		Decimal(25,2)			NOT NULL,
	TaxRate	    Decimal(25,2)		 NOT NULL,
	[Type]	    Int		NOT NULL,     --0代表起征税，1代表税阶，代表起征点时，数字存BandMin
	CONSTRAINT PK_TIndividualIncomeTax PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TIndividualIncomeTax UNIQUE NONCLUSTERED (PKID)
)			
GO

--End              税制         ------------

--Begin               考评管理         ------------
CREATE TABLE	TAssessTemplateItem	(	   
PKID	               INT	IDENTITY   NOT NULL,	   
Question	           NVarChar(100)   NOT NULL,   
OperateType	           INT	           NOT NULL,
AssessTemplateItemType INT             NOT NULL,
ItemClassfication      INT             NOT NULL,
ItemOption             NVarChar(1000)   NOT NULL,
ItemDescription        Text,
    CONSTRAINT PK_TAssessTemplateItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAssessTemplateItem UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE	TAssessTemplatePaper	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
PaperName	       NVarChar(50)    NOT NULL,   
    CONSTRAINT PK_TAssessTemplatePaper PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAssessTemplatePaper UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE	TAssessTemplatePIShip	(	   
PKID	                   INT	IDENTITY   NOT NULL,	   
AssessTemplatePaperID	   INT   NOT NULL,	
AssessTemplateItemID	   INT   NOT NULL,
Weight	                   Decimal(25,2)   NOT NULL default 0,
    CONSTRAINT PK_TAssessTemplatePIShip PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAssessTemplatePIShip UNIQUE NONCLUSTERED (PKID)
)			
GO	

--End                考评管理         ------------

--begin             考评活动         ------------

/****** 对象:  Table [dbo].[TAssessActivity]    脚本日期: 04/16/2009 12:53:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAssessActivity](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[AssessEmployeeID] [int] NOT NULL,
	[AssessCharacter] [int] NOT NULL,
	[AssessStatus] [int] NOT NULL,
	[ScopeFrom] [datetime] NOT NULL,
	[ScopeTo] [datetime] NOT NULL,
	[PersonalGoal] [text] NOT NULL,
	[Reason] [text] NOT NULL,
	[AssessProposerName] [nvarchar](50) NOT NULL,
	[Intention] [nvarchar](50) NOT NULL,
	[HRConfirmerName] [nvarchar](50) NULL,
	[PersonalExpectedFinish] [datetime] NULL,
	[ManagerExpectedFinish] [datetime] NULL,
	[PaperName] [nvarchar](50) NULL,
	[Score] [decimal](25, 2) NULL,
	[EmployeeDept] [nvarchar](50) NOT NULL,
	[Responsibility] [nvarchar](255) NOT NULL,
	[DiyProcess] Text NOT NULL,  --自定义流程
	[NextStepIndex] int NOT NULL,
	[IfEmployeeVisible] int NOT NULL,
 CONSTRAINT [PK_TAssessActivity] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAssessActivity] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** 对象:  Table [dbo].[TAssessActivityItem]    脚本日期: 04/16/2009 13:17:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAssessActivityItem](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[AssessActivityPaperID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Question] [nvarchar](100) NOT NULL,
	[Grade] decimal(25,2) NOT NULL,
	[Note] [text] NOT NULL,
	[Option] [nvarchar](1000) NOT NULL,
	[Classfication] [int] NOT NULL,
	[Description] [text] NOT NULL,
    [AssessTemplateItemType] [int] NOT NULL default 0,
    [Weight] decimal(25,2) NOT NULL default 0,
 CONSTRAINT [PK_TAssessActivityItem] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAssessActivityItem] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** 对象:  Table [dbo].[TAssessActivityPaper]    脚本日期: 04/16/2009 13:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAssessActivityPaper](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[AssessActivityID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[FillPerson] [nvarchar](50) NOT NULL,
	[SubmitTime] [datetime] NOT NULL,
	[ChoseIntention] [nvarchar](50) NULL,
	[Content] [text] NULL,
	[StepIndex] [int] NULL,
    SalaryNow Decimal(25,2)  NULL,
    SalaryChange Decimal(25,2)  NULL,
 CONSTRAINT [PK_TAssessActivityPaper] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TAssessActivityPaper] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

--end               考评活动         ------------

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
/*项目*/
Project			Nvarchar(50)		Not null  ,
/*报销状态*/
ReimburseStatus		Int			Not null  ,
/*报销总额*/
TotalCost		Decimal(14,4)		NOT NULL  ,
/*部门名*/
DepartmentName		Nvarchar(50)		NOT NULL  ,
/*提交时间*/
CommitTime		DateTime			  ,
/*记账时间*/
BillingTime		DateTime			  ,
/*出差天数*/
OutCityDays decimal(25,2) not null default 0,
/*出差补贴*/
OutCityAllowance decimal(14,2) not null default 0,

/*备注*/
Remark Nvarchar(500) not null default '',

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
CurrencyType    int              not null default 1,
/*事由*/
Reason			text			Not Null  ,
/*客户名*/
CustomerID      int             Not null		 ,
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


--Begin              自定义流程        ------------	

CREATE TABLE	TDiyProcess	(	   
PKID	            INT	IDENTITY    NOT NULL  ,	
[Name]				Nvarchar(50)	NOT NULL  ,
[Type]				Int			    Not null  ,
Remark				Nvarchar(50)	Not null  ,
CONSTRAINT PK_TDiyProcess PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TDiyProcess UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TDiyStep	(	   
PKID	            INT	IDENTITY    NOT NULL  ,	
Status				Nvarchar(50)	NOT NULL  ,
OperatorType		Int			    Not null  ,
OperatorID			Int				Not null  ,
DiyProcessID		Int			    Not null  ,
MailAccount			Nvarchar(255)	Not null  ,
CONSTRAINT PK_TDiyStep PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TDiyStep UNIQUE NONCLUSTERED (PKID)
)	
GO

CREATE TABLE	TEmployeeDiyProcess	(	   
PKID	            INT	IDENTITY    NOT NULL  ,	
AccountID			Int			    Not null  ,
DiyProcessID		Int			    Not null  ,
CONSTRAINT PK_TEmployeeDiyProcess PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TEmployeeDiyProcess UNIQUE NONCLUSTERED (PKID)
)	
GO
 
--End                 自定义流程       -------------
--End                报销单管理       -------------

--班别
CREATE TABLE TDutyClass (
    PKID	            INT IDENTITY       NOT NULL,--每条记录的标识
    DutyClassName            Nvarchar(50)       NOT NULL,--班别名称
    FirstStartFromTime    DateTime           NOT NULL,--设定的上午上班时间点，日期表示的设置日期，无其他用处
    FirstStartToTime    DateTime           NOT NULL,--设定的上午上班时间点，日期表示的设置日期，无其他用处
    FirstEndTime      DateTime           NOT NULL,--设定的上午下班时间点，日期表示的设置日期，无其他用处
    SecondStartTime  DateTime	       NOT NULL,--设定的下午上班时间点，日期表示的设置日期，无其他用处
    SecondEndTime  DateTime             NOT NULL,--设定的下午上班时间点，日期表示的设置日期，无其他用处
    AllLimitTime  Decimal	               NOT NULL,--设定的一天的最少上班时间   
 
    LateTime            INT                NOT NULL,--设定员工在这个时间外为迟到时间
    EarlyLeaveTime      INT                NOT NULL,--设定员工在这个时间外为早退时间
    AbsentLateTime            INT                NOT NULL,--设定员工在这个时间内为迟到时间
    AbsentEarlyLeaveTime      INT                NOT NULL,--设定员工在这个时间内为早退时间
	CONSTRAINT PK_TDutyClass PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TDutyClass UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TPlanDutyTable (
    PKID	            INT IDENTITY       NOT NULL,--排班详情PKID
    PlanDutyTableName            Nvarchar(50)       NOT NULL,--排班表名称
    Period    int         ,--排班表周期
    FromTime      DateTime           NOT NULL,--开始时间
    ToTime  DateTime	       NOT NULL,--结束时间
	CONSTRAINT PK_TPlanDutyTable PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPlanDutyTable UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TPlanDutyDetail (
    PKID	            INT IDENTITY       NOT NULL,--每条记录的标识
    PlanDutyTableID            INT       NOT NULL,--排班详情PKID
    Date    DateTime       NOT NULL,--排班详情中的日期
    DutyClassID      INT           NOT NULL,--班别ID
	CONSTRAINT PK_TPlanDutyDetail PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPlanDutyDetail UNIQUE NONCLUSTERED (PKID)
) 
GO

CREATE TABLE TPlanDuty (
    PKID	            INT IDENTITY       NOT NULL,--每条记录的标识
    PlanDutyTableID            INT       NOT NULL,--排班详情PKID
    AccountID      INT           NOT NULL,--员工ID
	CONSTRAINT PK_TPlanDuty PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPlanDuty UNIQUE NONCLUSTERED (PKID)
) 
GO

--begin                培训       -------------

CREATE TABLE TTrainFBQues	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
[Name]	           NVarChar(200)   NOT NULL, --反馈问题描述  
TypeID	           INT             NOT NULL,--反馈问题类型ID，TParameter的PKID
    CONSTRAINT PK_TTrainFBQues PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainFBQues UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE TTrainFBItem	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
[Name]	           NVarChar(100)   NOT NULL,--反馈问题选项描述
Score              INT             NOT NULL,--选项对应的分值d
QuesID	           INT             NOT NULL,--对应的反馈问题ID，TParameter的PKID
    CONSTRAINT PK_TTrainFBItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainFBItem UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE TCourse	(	   
PKID	           INT	IDENTITY   NOT NULL,	   
CourseName	       Nvarchar(200) NOT NULL,--课程名称
CoordinatorID	   INT	           NOT NULL,--协调员ID，TEmployee的PKID
CoordinatorName	       Nvarchar(50)  NOT NULL,--协调员
Scope	           INT	           NOT NULL,--	培训范围 1.	内部培训 2.	外部培训
[Status]	       INT	           NOT NULL,--		课程状态 1.	开始2.	结束
Trainer	           Nvarchar(50)  NOT NULL,--		培训师
ExpectST	       DateTime	       NOT NULL,--		计划开始时间
ExpectET	       DateTime	       NOT NULL,--		计划结束时间
ActualST	       DateTime	       NOT NULL,--		实际开始时间
ActualET	       DateTime	       NOT NULL,--		实际结束时间
ExpectHour	       Decimal (25,2)	NOT NULL,--		计划课时
ActualHour	       Decimal (25,2)	NOT NULL,--		实际课时
ExpectCost	       Decimal (25,2)	NOT NULL,--		计划成本
ActualCost	       Decimal (25,2)	NOT NULL,--		实际成本
TrianPlace         Nvarchar(200)    NOT NULL,
FBCount	           Int	            NOT NULL default 0, --默认为0		课程的反馈人数
Score	           Decimal (25,2)	NOT NULL default 0,--默认为0		课程的反馈分数
FeedBackPaperId    Int              NOT NUll,
HasCertification    Int              NOT NUll default 0
    CONSTRAINT PK_TCourse PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TCourse UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TCourseTrainee	(	   
PKID	      INT	IDENTITY NOT NULL,--	主键
CourseID	  INT	NOT NULL,--	培训课程ID，TCourse的PKID
CourseName	  Nvarchar(200)	NOT NULL,--		课程名字
TraineeID	  INT	NOT NULL,--		被培训人员ID，TEmployee的PKID
TraineeName	  Nvarchar(50)	NOT NULL,--		被培训人员
FBTime	      DateTime	NULL,--		反馈时间
[Status]	  INT	NOT NULL,--		反馈状态
Score	      Decimal(25,2)	NOT NULL default 0,--		个人对课程反馈的平均分
Suggestion	  Nvarchar(200)	NULL,--		反馈的建议和意见
CertificationName	  Nvarchar(50)	NULL,
    CONSTRAINT PK_TCourseTrainee PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TCourseTrainee UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TCourseSkill	(	   
PKID	     INT	IDENTITY    NOT NULL,
CourseID	 INT	    NOT NULL,	--培训课程ID
CourseName	 Nvarchar(200)	NOT NULL,--	培训课程
SkillID	     INT	NOT NULL,--		技能ID，TSkill的PKID
SkillName	 Nvarchar(100)	NOT NULL,--		技能名称
    CONSTRAINT PK_TCourseSkill PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TCourseSkill UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TCourseFB	(	   
PKID	       INT IDENTITY	NOT NULL,
CourseID	   INT	NOT NULL,--		培训课程ID
FBQues	       Nvarchar(200)	NOT NULL,--		反馈问题描述
FBItems	       Nvarchar(2000)	NOT NULL,--		反馈问题选项
FBItemsScore   Nvarchar(50)	NOT NULL,--		反馈问题选项分值
    CONSTRAINT PK_TCourseFB PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TCourseFB UNIQUE NONCLUSTERED (PKID)
)			
GO

CREATE TABLE TCourseFBResult	(	   
PKID	    INT IDENTITY	NOT NULL,
CourseID	INT	NOT NULL,--		培训课程ID
CourseFBID	INT	NOT NULL,--		培训反馈ID，TTrainFB表的PKID
TraineeID	INT	NOT NULL,--		被培训人ID，TEmployee表PKID
TraineeName	Nvarchar(50)	NOT NULL,--		被培训人
Score	    Decimal	NOT NULL,--		每个反馈问题的得分
    CONSTRAINT PK_TCourseFBResult PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TCourseFBResult UNIQUE NONCLUSTERED (PKID)
)			
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

--end                培训       -------------


--begin                短消息       -------------
CREATE TABLE	TPhoneMessage	(
	PKID	    INT IDENTITY	NOT NULL, 
	RequesterID	INT NOT NULL,
	RequesterName NVarChar (50) NOT NULL,
    AssessorID INT NOT NULL,
	AssessorName NVarChar (50) NOT NULL,
    TypeID  INT NOT NULL,
    [Type]  INT NOT NULL,
    [Message]  NVarChar (1000) default '' NOT NULL , 
    Answer  NVarChar (1000) default '' NOT NULL,
    Status  INT NOT NULL,
    InsertTime  DateTime ,
    SendTime    DateTime , 
	CONSTRAINT PK_TPhoneMessage PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPhoneMessage UNIQUE NONCLUSTERED (PKID)
)			
GO
 
--End               短消息       -------------


--begin              员工档案       -------------
CREATE TABLE	TFileCargo	(
	PKID	    INT IDENTITY	NOT NULL, 
    AccountID   Int NOT NULL, 
	FileCargoName Int NOT NULL,
    Remark NVarChar (2000) default '' NOT NULL , 
    [File] NVarChar (250) default '' NOT NULL , 
	CONSTRAINT PK_TFileCargo PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TFileCargo UNIQUE NONCLUSTERED (PKID)
)			
GO
--End               员工档案       -------------

--begin 培训申请----------

CREATE TABLE TTrainApplication 	(	   
PKID	           INT	IDENTITY    NOT NULL,	   
CourseName	       Nvarchar(200)    NOT NULL,--课程名称
ApplicationId	   INT	            NOT NULL,--申请renID，TEmployee的PKID
TrainType	       INT	            NOT NULL,--	培训范围 1.	内部培训 2.	外部培训
Trainer	           Nvarchar(50)     NOT NULL,--		培训师
Skills   	       Nvarchar(200)    NOT NULL,--相关技能
StratTime	       DateTime	        NOT NULL,--		计划开始时间
EndTime  	       DateTime	        NOT NULL,--		计划结束时间
TrianPlace         Nvarchar(200)    NOT NULL,
TrainOrgnatiaon	   Nvarchar(200)    NOT NULL, --培训机构
TrainHour	       Decimal (25,2)	NOT NULL,--		培训课时
TrainCost	       Decimal (25,2)	NOT NULL,--		培训成本
EduSpuCost         Decimal(25,2)    NULL,    -- 教育补助金额
HasCertification   Int              NOT NUll default 0,  --是否有证书
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
Remark              Nvarchar(200)   NUll,
    CONSTRAINT PK_TTrainAppFlow PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TTrainAppFlow UNIQUE NONCLUSTERED (PKID)
)
GO

--end 培训申请----------

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

--- end   调休规则 -------

--- start 调休规则 -------
CREATE TABLE	TEmployeeAdjustRule	(
PKID	        INT	IDENTITY    NOT NULL,
AccountID       INT  NOT NULL,
AdjustRuleID    INT  NOT NULL,
CONSTRAINT PK_TEmployeeAdjustRule PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TEmployeeAdjustRule UNIQUE NONCLUSTERED (PKID)
)
GO

--- end   调休规则 -------

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


--- start  客户信息 ------

CREATE TABLE	TCustomerInfo	(
PKID	            INT	IDENTITY    NOT NULL,
CompanyName              Nvarchar(200)   NOT NULL,
CONSTRAINT PK_TCustomerInfo PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TCustomerInfo UNIQUE NONCLUSTERED (PKID))

--- end  客户信息 ------

CREATE TABLE	TProjectInfo	(
PKID	            INT	IDENTITY    NOT NULL,
ProjectName         Nvarchar(200)   NOT NULL,
CONSTRAINT PK_TProjectInfo PRIMARY KEY (PKID)
)


CREATE TABLE	TExchangeRate	(
PKID	    INT	IDENTITY    NOT NULL,
Name        Nvarchar(200)   NOT NULL,
Rate        decimal(12,4)   NOT NULL,
CONSTRAINT PK_TExchangeRate PRIMARY KEY (PKID)
)



--begin 异常信息----------
CREATE TABLE	TSystemError	(
PKID	         INT	IDENTITY   NOT NULL,
ErrorType	     INT	           NOT NULL,  --类型 1门禁卡号,2排班规则,3请假流程，4外出申请流程,5加班申请流程,6绩效考核流程,7人事负责人,8报销流程,9培训申请流程
MarkID           INT	           NOT NULL,  --标识ID
 CONSTRAINT PK_TSystemError PRIMARY KEY NONCLUSTERED (PKID),
 CONSTRAINT TC_TSystemError UNIQUE NONCLUSTERED (PKID)
)
GO
--end 异常信息----------


--begin            职位        -------------
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
GO

CREATE TABLE TPositionHistory (
    PKID						INT IDENTITY	NOT NULL,
    [PositionID]				INT 			NOT NULL,
    [PositionName]				Nvarchar(50)    NOT NULL,
    [PositionGradeName]			Nvarchar(50)	NOT NULL DEFAULT '',
    [PositionGradeSequence]		int				NOT NULL,

	[PositionDescription]		text			NOT NULL DEFAULT (''),
	[Number]					nvarchar(255)	NULL,
	[ReviewerID]				int				NULL,
	[ReviewerName]				nvarchar(50)	NULL,
	[PositionStatus]		    int         	NOT NULL default -1,
	[Version]					nvarchar(255)	NULL,
	[Commencement]				DateTime		NULL,
	[Summary]					text	NULL,
	[MainDuties]				text	NULL,
	[ReportScope]				text	NULL,
	[ControlScope]				text	NULL,
	[Coordination]				text	NULL,
	[Authority]					text	NULL,
	[Education]					text	NULL,
	[ProfessionalBackground]	text	NULL,
	[WorkExperience]			text	NULL,
	[Qualification]				text	NULL,
	[Competence]				text	NULL,
	[OtherRequirements]			text	NULL,
	[KnowledgeAndSkills]		text	NULL,
	[RelatedProcesses]			text	NULL,
	[ManagementSkills]			text	NULL,
	[AuxiliarySkills]			text	NULL,

    [OperatorName]				Nvarchar(50),
    [OperationTime]				DateTime    NOT NULL,
	CONSTRAINT PK_TPositionHistory PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPositionHistory UNIQUE NONCLUSTERED (PKID)
) 
GO
--end            职位        -------------