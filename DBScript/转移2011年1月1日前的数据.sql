use hrmis
--将以下16表2011年1月1日前的数据移至T**2010中
--TLeaveRequest2010,TLeaveRequestItem2010,TLeaveRequestFlow2010
--TOutApplication2010,TOutApplicationItem2010,TOutApplicationFlow2010
--TOverWork2010,TOverWorkItem2010,TOverWorkFlow2010
--TPlanDutyTable2010,TPlanDuty2010,TPlanDutyDetail2010
--TReadDataHistory2010,TEmployeeInAndOutRecord2010,TEmployeeAttendance2010,InAndOutRecordLog2010

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequest2010' AND type = 'U')
	DROP TABLE TLeaveRequest2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestItem2010' AND type = 'U')
	DROP TABLE TLeaveRequestItem2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestFlow2010' AND type = 'U')
	DROP TABLE TLeaveRequestFlow2010
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplication2010' AND type = 'U')
	DROP TABLE TOutApplication2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationItem2010' AND type = 'U')
	DROP TABLE TOutApplicationItem2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationFlow2010' AND type = 'U')
	DROP TABLE TOutApplicationFlow2010
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWork2010' AND type = 'U')
	DROP TABLE TOverWork2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkItem2010' AND type = 'U')
	DROP TABLE TOverWorkItem2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkFlow2010' AND type = 'U')
	DROP TABLE TOverWorkFlow2010
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyTable2010' AND type = 'U')
	DROP TABLE TPlanDutyTable2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDuty2010' AND type = 'U')
	DROP TABLE TPlanDuty2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyDetail2010' AND type = 'U')
	DROP TABLE TPlanDutyDetail2010
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReadDataHistory2010' AND type = 'U')
	DROP TABLE TReadDataHistory2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeInAndOutRecord2010' AND type = 'U')
	DROP TABLE TEmployeeInAndOutRecord2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAttendance2010' AND type = 'U')
	DROP TABLE TEmployeeAttendance2010
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TInAndOutRecordLog2010' AND type = 'U')
	DROP TABLE TInAndOutRecordLog2010
GO


CREATE TABLE	TLeaveRequest2010	(
PKID	            INT	    NOT NULL,
AccountID	        INT	            NOT NULL,  --请假员工编号
LeaveRequestTypeID  INT	            NOT NULL,  --请假类型
Reason			    TEXT            NOT NULL,  --请假原因
SubmitDate          DATETIME        NOT NULL,  --递交请假单日期
AbsentFrom          DATETIME        NOT NULL,  --请假开始时间
AbsentTo            DATETIME        NOT NULL,  --请假结束时间
AbsentHours         Decimal(25,2)   NOT NULL,  --请假时间段，按小时计
DiyProcess          Text			NOT NULL
)
GO

CREATE TABLE	TLeaveRequestItem2010	(
PKID	            INT	    NOT NULL,
LeaveRequestID      INT			    NOT NULL,
[Status]            INT             NOT NULL,  --请假单状态
AbsentFrom          DATETIME        NOT NULL,  --请假开始时间
AbsentTo            DATETIME        NOT NULL,  --请假结束时间
AbsentHours         Decimal(25,2)   NOT NULL,  --请假时间段，按小时计
--IfPass              INT             NOT NULL,  --是否通过
NextProcessID       INT             NOT NULL,  --下一步骤
UseList             Nvarchar(200) 
)
GO

CREATE TABLE	TLeaveRequestFlow2010	(
PKID	            INT	    NOT NULL,
LeaveRequestItemID  INT             NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
--0 新增 1 审核通过 2 审核不通过 3 申请取消 4 批准取消假期 5 拒绝取消假期
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL
)
GO

CREATE TABLE [dbo].[TOutApplication2010](
	[PKID]        int            NOT NULL,
	[AccountID]   int            NOT NULL,
	[SubmitDate]  datetime       NOT NULL,
	[From]        datetime       NOT NULL,
	[To]          datetime       NOT NULL,
	[CostTime]    decimal(25, 2) NULL,
	[Reason]      text           NOT NULL,
	[OutLocation] nvarchar(50)   NULL,--外出地点
    OutType       int   NOT NULL,--外出类型
    [DiyProcess]          Text	  NOT NULL
)
GO

CREATE TABLE	TOutApplicationItem2010	(
PKID	            INT	    NOT NULL,
OutApplicationID      INT			    NOT NULL,
[Status]            INT             NOT NULL,
[From]          DATETIME        NOT NULL,  
[To]            DATETIME        NOT NULL, 
[CostTime]         Decimal(25,2)   NOT NULL, 
Adjust              INT            NOT NULL,
AdjustHour      Decimal(25,2)      NOT NULL
)
GO


CREATE TABLE	TOutApplicationFlow2010	(
PKID	            INT	    NOT NULL,
OutApplicationItemID  INT           NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL,  --备注
Step                int  NOT NULL
)
GO

CREATE TABLE [dbo].[TOverWork2010](
	[PKID]       int      NOT NULL,
	[AccountID]  int              NOT NULL,
	[SubmitDate] datetime         NOT NULL,
	[From]       datetime         NOT NULL,
	[To]         datetime         NOT NULL,
	[CostTime]   decimal(25, 2)   NULL,
	[Reason]     text             NOT NULL,
	[ProjectName] nvarchar(50)    NULL,--加班项目,
    DiyProcess          Text			NOT NULL
)
GO

CREATE TABLE	TOverWorkItem2010	(
PKID	        INT	    NOT NULL,
OverWorkID      INT	            NOT NULL,
[Status]        INT             NOT NULL,
[From]          DATETIME        NOT NULL,  
[To]            DATETIME        NOT NULL, 
[CostTime]      Decimal(25,2)   NOT NULL,
[OverWorkType]  INT             NOT NULL,
[Adjust]        INT             NOT NULL,
AdjustHour      Decimal(25,2)      NOT NULL
)
GO


CREATE TABLE	TOverWorkFlow2010	(
PKID	            INT	    NOT NULL,
OverWorkItemID      INT             NOT NULL,  --请假单编号
OperatorID	        INT	            NOT NULL,  --操作人编号
Operation           INT	            NOT NULL,  --操作类型
OperationTime       DATETIME        NOT NULL,  --操作时间
Remark              Text            NOT NULL,  --备注
Step                int  NOT NULL
)
GO

CREATE TABLE TPlanDutyTable2010 (
    PKID	            INT        NOT NULL,--排班详情PKID
    PlanDutyTableName            Nvarchar(50)       NOT NULL,--排班表名称
    Period    int         ,--排班表周期
    FromTime      DateTime           NOT NULL,--开始时间
    ToTime  DateTime	       NOT NULL
) 
GO

CREATE TABLE TPlanDutyDetail2010 (
    PKID	            INT        NOT NULL,--每条记录的标识
    PlanDutyTableID            INT       NOT NULL,--排班详情PKID
    Date    DateTime       NOT NULL,--排班详情中的日期
    DutyClassID      INT           NOT NULL
) 
GO

CREATE TABLE TPlanDuty2010 (
    PKID	            INT        NOT NULL,--每条记录的标识
    PlanDutyTableID            INT       NOT NULL,--排班详情PKID
    AccountID      INT           NOT NULL
) 
GO

CREATE TABLE TEmployeeInAndOutRecord2010 (
    PKID	  INT        NOT NULL,--每条记录的标识
    EmployeeID   INT             NOT NULL,--员工ID
    DoorCardNo  Nvarchar(50)     NOT NULL,--员工门禁卡卡号
    IOTime    DateTime	         NOT NULL,--刷卡时间
    IOStatus  INT	             NOT NULL,--刷卡状态，0：进，1：出
    OperateStatus  INT           NOT NULL,--0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
    OperateTime DateTime         NOT NULL
) 
GO

CREATE TABLE TReadDataHistory2010 (
    PKID	   INT        NOT NULL,--每条记录的标识
    ReadTime   DateTime           NOT NULL,--读取数据库的时间
    ReadResult INT                NOT NULL,--读取的结果，0：读取中，1：读取成功，2：读取失败
    FailReason text

) 
GO

CREATE TABLE	TInAndOutRecordLog2010	(	  
PKID	            INT	    NOT NULL  ,	
EmployeeID          INT	            NOT NULL  ,
OldIOTime		    DateTime		NULL  ,
OldIOStatus		    INT	            NULL  ,
NewIOTime	        DateTime        NULL  ,	
NewIOStatus         INT	            NULL  ,
OperateStatus	    Int			    Not NULL  ,
Operator	        NVarChar(50)    NOT NULL  ,	
OperateTime         DateTime        NOT NULL  ,
OperateReason	    text			Not NULL  
)	
GO

CREATE TABLE	TEmployeeAttendance2010	(	   
PKID	            INT	   NOT NULL,	
EmployeeId          INT	           NOT NULL  ,
[Name]	            NVarChar(50)   NOT NULL,  --考勤名字,如外出,请假,旷工
Days                decimal(9,2)        NOT NULL DEFAULT 0,  --持续的时间
AddDutyDays         decimal(9,2)	       NOT NULL DEFAULT 0, -- 增加的出勤天数
EarlyAndLateMunite  int        NOT NULL DEFAULT 0,
TheDay            DATETIME         NOT NULL,  --缺勤日期
AttendanceType        INT          NOT NULL 

)	
GO

--移入数据
insert TLeaveRequest2010 select * from dbo.TLeaveRequest where absentto<'2011-1-1'
insert TLeaveRequestItem2010 select * from dbo.TLeaveRequestItem where absentto<'2011-1-1'
insert TLeaveRequestFlow2010 select * from dbo.TLeaveRequestFlow where LeaveRequestItemid in (select pkid from dbo.TLeaveRequestItem where absentto<'2011-1-1')

insert TOutApplication2010 select * from dbo.TOutApplication where [to]<'2011-1-1'
insert TOutApplicationItem2010 select * from dbo.TOutApplicationItem where [to]<'2011-1-1'
insert TOutApplicationFlow2010 select * from dbo.TOutApplicationFlow where OutApplicationItemid in
(select pkid from dbo.TOutApplicationItem where [to]<'2011-1-1')

insert TOverWork2010 select * from dbo.TOverWork where [to]<'2011-1-1'
insert TOverWorkItem2010 select * from dbo.TOverWorkItem where [to]<'2011-1-1'
insert TOverWorkFlow2010 select * from dbo.TOverWorkFlow where OverWorkItemid in
(select pkid from dbo.TOverWorkItem where [to]<'2011-1-1')

insert TPlanDutyTable2010 select * from dbo.TPlanDutyTable where totime<'2011-1-1'
insert TPlanDuty2010 select * from dbo.TPlanDuty where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2011-1-1')
insert TPlanDutyDetail2010 select * from dbo.TPlanDutyDetail where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2011-1-1')

insert TReadDataHistory2010 select * from dbo.TReadDataHistory where readtime <'2011-1-1'
insert TEmployeeInAndOutRecord2010 select * from dbo.TEmployeeInAndOutRecord where iotime <'2011-1-1'
insert TEmployeeAttendance2010 select * from dbo.TEmployeeAttendance where TheDay<'2011-1-1'
insert TInAndOutRecordLog2010 select * from dbo.TInAndOutRecordLog where newiotime <'2011-1-1'



--删除以下16表2011年1月1日前的数据

delete from dbo.TLeaveRequestFlow where LeaveRequestItemid in (select pkid from dbo.TLeaveRequestItem where absentto<'2011-1-1')
delete from dbo.TLeaveRequest where absentto<'2011-1-1'
delete from dbo.TLeaveRequestItem where absentto<'2011-1-1'

delete from dbo.TOutApplicationFlow where OutApplicationItemid in
(select pkid from dbo.TOutApplicationItem where [to]<'2011-1-1')
delete from dbo.TOutApplication where [to]<'2011-1-1'
delete from dbo.TOutApplicationItem where [to]<'2011-1-1'

delete from dbo.TOverWorkFlow where OverWorkItemid in
(select pkid from dbo.TOverWorkItem where [to]<'2011-1-1')
delete from dbo.TOverWork where [to]<'2011-1-1'
delete from dbo.TOverWorkItem where [to]<'2011-1-1'

delete from dbo.TPlanDuty where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2011-1-1')
delete from dbo.TPlanDutyDetail where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2011-1-1')
delete from dbo.TPlanDutyTable where totime<'2011-1-1'

delete from dbo.TReadDataHistory where readtime <'2011-1-1'
delete from dbo.TEmployeeInAndOutRecord where iotime <'2011-1-1'
delete from dbo.TEmployeeAttendance where TheDay<'2011-1-1'
delete from dbo.TInAndOutRecordLog where newiotime <'2011-1-1'