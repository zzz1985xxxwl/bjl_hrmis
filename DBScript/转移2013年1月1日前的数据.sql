use hrmis
--������16��2013��1��1��ǰ����������T**2012��
--TLeaveRequest2012,TLeaveRequestItem2012,TLeaveRequestFlow2012
--TOutApplication2012,TOutApplicationItem2012,TOutApplicationFlow2012
--TOverWork2012,TOverWorkItem2012,TOverWorkFlow2012
--TPlanDutyTable2012,TPlanDuty2012,TPlanDutyDetail2012
--TReadDataHistory2012,TEmployeeInAndOutRecord2012,TEmployeeAttendance2012,InAndOutRecordLog2012

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequest2012' AND type = 'U')
	DROP TABLE TLeaveRequest2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestItem2012' AND type = 'U')
	DROP TABLE TLeaveRequestItem2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TLeaveRequestFlow2012' AND type = 'U')
	DROP TABLE TLeaveRequestFlow2012
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplication2012' AND type = 'U')
	DROP TABLE TOutApplication2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationItem2012' AND type = 'U')
	DROP TABLE TOutApplicationItem2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOutApplicationFlow2012' AND type = 'U')
	DROP TABLE TOutApplicationFlow2012
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWork2012' AND type = 'U')
	DROP TABLE TOverWork2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkItem2012' AND type = 'U')
	DROP TABLE TOverWorkItem2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TOverWorkFlow2012' AND type = 'U')
	DROP TABLE TOverWorkFlow2012
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyTable2012' AND type = 'U')
	DROP TABLE TPlanDutyTable2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDuty2012' AND type = 'U')
	DROP TABLE TPlanDuty2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPlanDutyDetail2012' AND type = 'U')
	DROP TABLE TPlanDutyDetail2012
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TReadDataHistory2012' AND type = 'U')
	DROP TABLE TReadDataHistory2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeInAndOutRecord2012' AND type = 'U')
	DROP TABLE TEmployeeInAndOutRecord2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TEmployeeAttendance2012' AND type = 'U')
	DROP TABLE TEmployeeAttendance2012
GO
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TInAndOutRecordLog2012' AND type = 'U')
	DROP TABLE TInAndOutRecordLog2012
GO


CREATE TABLE	TLeaveRequest2012	(
PKID	            INT	    NOT NULL,
AccountID	        INT	            NOT NULL,  --���Ա�����
LeaveRequestTypeID  INT	            NOT NULL,  --�������
Reason			    TEXT            NOT NULL,  --���ԭ��
SubmitDate          DATETIME        NOT NULL,  --�ݽ���ٵ�����
AbsentFrom          DATETIME        NOT NULL,  --��ٿ�ʼʱ��
AbsentTo            DATETIME        NOT NULL,  --��ٽ���ʱ��
AbsentHours         Decimal(25,2)   NOT NULL,  --���ʱ��Σ���Сʱ��
DiyProcess          Text			NOT NULL
)
GO

CREATE TABLE	TLeaveRequestItem2012	(
PKID	            INT	    NOT NULL,
LeaveRequestID      INT			    NOT NULL,
[Status]            INT             NOT NULL,  --��ٵ�״̬
AbsentFrom          DATETIME        NOT NULL,  --��ٿ�ʼʱ��
AbsentTo            DATETIME        NOT NULL,  --��ٽ���ʱ��
AbsentHours         Decimal(25,2)   NOT NULL,  --���ʱ��Σ���Сʱ��
--IfPass              INT             NOT NULL,  --�Ƿ�ͨ��
NextProcessID       INT             NOT NULL,  --��һ����
UseList             Nvarchar(200) 
)
GO

CREATE TABLE	TLeaveRequestFlow2012	(
PKID	            INT	    NOT NULL,
LeaveRequestItemID  INT             NOT NULL,  --��ٵ����
OperatorID	        INT	            NOT NULL,  --�����˱��
Operation           INT	            NOT NULL,  --��������
--0 ���� 1 ���ͨ�� 2 ��˲�ͨ�� 3 ����ȡ�� 4 ��׼ȡ������ 5 �ܾ�ȡ������
OperationTime       DATETIME        NOT NULL,  --����ʱ��
Remark              Text            NOT NULL
)
GO

CREATE TABLE [dbo].[TOutApplication2012](
	[PKID]        int            NOT NULL,
	[AccountID]   int            NOT NULL,
	[SubmitDate]  datetime       NOT NULL,
	[From]        datetime       NOT NULL,
	[To]          datetime       NOT NULL,
	[CostTime]    decimal(25, 2) NULL,
	[Reason]      text           NOT NULL,
	[OutLocation] nvarchar(50)   NULL,--����ص�
    OutType       int   NOT NULL,--�������
    [DiyProcess]          Text	  NOT NULL
)
GO

CREATE TABLE	TOutApplicationItem2012	(
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


CREATE TABLE	TOutApplicationFlow2012	(
PKID	            INT	    NOT NULL,
OutApplicationItemID  INT           NOT NULL,  --��ٵ����
OperatorID	        INT	            NOT NULL,  --�����˱��
Operation           INT	            NOT NULL,  --��������
OperationTime       DATETIME        NOT NULL,  --����ʱ��
Remark              Text            NOT NULL,  --��ע
Step                int  NOT NULL
)
GO

CREATE TABLE [dbo].[TOverWork2012](
	[PKID]       int      NOT NULL,
	[AccountID]  int              NOT NULL,
	[SubmitDate] datetime         NOT NULL,
	[From]       datetime         NOT NULL,
	[To]         datetime         NOT NULL,
	[CostTime]   decimal(25, 2)   NULL,
	[Reason]     text             NOT NULL,
	[ProjectName] nvarchar(50)    NULL,--�Ӱ���Ŀ,
    DiyProcess          Text			NOT NULL
)
GO

CREATE TABLE	TOverWorkItem2012	(
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


CREATE TABLE	TOverWorkFlow2012	(
PKID	            INT	    NOT NULL,
OverWorkItemID      INT             NOT NULL,  --��ٵ����
OperatorID	        INT	            NOT NULL,  --�����˱��
Operation           INT	            NOT NULL,  --��������
OperationTime       DATETIME        NOT NULL,  --����ʱ��
Remark              Text            NOT NULL,  --��ע
Step                int  NOT NULL
)
GO

CREATE TABLE TPlanDutyTable2012 (
    PKID	            INT        NOT NULL,--�Ű�����PKID
    PlanDutyTableName            Nvarchar(50)       NOT NULL,--�Ű������
    Period    int         ,--�Ű������
    FromTime      DateTime           NOT NULL,--��ʼʱ��
    ToTime  DateTime	       NOT NULL
) 
GO

CREATE TABLE TPlanDutyDetail2012 (
    PKID	            INT        NOT NULL,--ÿ����¼�ı�ʶ
    PlanDutyTableID            INT       NOT NULL,--�Ű�����PKID
    Date    DateTime       NOT NULL,--�Ű������е�����
    DutyClassID      INT           NOT NULL
) 
GO

CREATE TABLE TPlanDuty2012 (
    PKID	            INT        NOT NULL,--ÿ����¼�ı�ʶ
    PlanDutyTableID            INT       NOT NULL,--�Ű�����PKID
    AccountID      INT           NOT NULL
) 
GO

CREATE TABLE TEmployeeInAndOutRecord2012 (
    PKID	  INT        NOT NULL,--ÿ����¼�ı�ʶ
    EmployeeID   INT             NOT NULL,--Ա��ID
    DoorCardNo  Nvarchar(50)     NOT NULL,--Ա���Ž�������
    IOTime    DateTime	         NOT NULL,--ˢ��ʱ��
    IOStatus  INT	             NOT NULL,--ˢ��״̬��0������1����
    OperateStatus  INT           NOT NULL,--0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�
    OperateTime DateTime         NOT NULL
) 
GO

CREATE TABLE TReadDataHistory2012 (
    PKID	   INT        NOT NULL,--ÿ����¼�ı�ʶ
    ReadTime   DateTime           NOT NULL,--��ȡ���ݿ��ʱ��
    ReadResult INT                NOT NULL,--��ȡ�Ľ����0����ȡ�У�1����ȡ�ɹ���2����ȡʧ��
    FailReason text

) 
GO

CREATE TABLE	TInAndOutRecordLog2012	(	  
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

CREATE TABLE	TEmployeeAttendance2012	(	   
PKID	            INT	   NOT NULL,	
EmployeeId          INT	           NOT NULL  ,
[Name]	            NVarChar(50)   NOT NULL,  --��������,�����,���,����
Days                decimal(9,2)        NOT NULL DEFAULT 0,  --������ʱ��
AddDutyDays         decimal(9,2)	       NOT NULL DEFAULT 0, -- ���ӵĳ�������
EarlyAndLateMunite  int        NOT NULL DEFAULT 0,
TheDay            DATETIME         NOT NULL,  --ȱ������
AttendanceType        INT          NOT NULL 

)	
GO

--��������
insert TLeaveRequest2012 select * from dbo.TLeaveRequest where absentto<'2013-1-1'
insert TLeaveRequestItem2012 select * from dbo.TLeaveRequestItem where absentto<'2013-1-1'
insert TLeaveRequestFlow2012 select * from dbo.TLeaveRequestFlow where LeaveRequestItemid in (select pkid from dbo.TLeaveRequestItem where absentto<'2013-1-1')

insert TOutApplication2012 select * from dbo.TOutApplication where [to]<'2013-1-1'
insert TOutApplicationItem2012 select * from dbo.TOutApplicationItem where [to]<'2013-1-1'
insert TOutApplicationFlow2012 select * from dbo.TOutApplicationFlow where OutApplicationItemid in
(select pkid from dbo.TOutApplicationItem where [to]<'2013-1-1')

insert TOverWork2012 select * from dbo.TOverWork where [to]<'2013-1-1'
insert TOverWorkItem2012 select * from dbo.TOverWorkItem where [to]<'2013-1-1'
insert TOverWorkFlow2012 select * from dbo.TOverWorkFlow where OverWorkItemid in
(select pkid from dbo.TOverWorkItem where [to]<'2013-1-1')

insert TPlanDutyTable2012 select * from dbo.TPlanDutyTable where totime<'2013-1-1'
insert TPlanDuty2012 select * from dbo.TPlanDuty where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2013-1-1')
insert TPlanDutyDetail2012 select * from dbo.TPlanDutyDetail where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2013-1-1')

insert TReadDataHistory2012 select * from dbo.TReadDataHistory where readtime <'2013-1-1'
insert TEmployeeInAndOutRecord2012 select * from dbo.TEmployeeInAndOutRecord where iotime <'2013-1-1'
insert TEmployeeAttendance2012 select * from dbo.TEmployeeAttendance where TheDay<'2013-1-1'
insert TInAndOutRecordLog2012 select * from dbo.TInAndOutRecordLog where newiotime <'2013-1-1'



--ɾ������16��2013��1��1��ǰ������

delete from dbo.TLeaveRequestFlow where LeaveRequestItemid in (select pkid from dbo.TLeaveRequestItem where absentto<'2013-1-1')
delete from dbo.TLeaveRequest where absentto<'2013-1-1'
delete from dbo.TLeaveRequestItem where absentto<'2013-1-1'

delete from dbo.TOutApplicationFlow where OutApplicationItemid in
(select pkid from dbo.TOutApplicationItem where [to]<'2013-1-1')
delete from dbo.TOutApplication where [to]<'2013-1-1'
delete from dbo.TOutApplicationItem where [to]<'2013-1-1'

delete from dbo.TOverWorkFlow where OverWorkItemid in
(select pkid from dbo.TOverWorkItem where [to]<'2013-1-1')
delete from dbo.TOverWork where [to]<'2013-1-1'
delete from dbo.TOverWorkItem where [to]<'2013-1-1'

delete from dbo.TPlanDuty where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2013-1-1')
delete from dbo.TPlanDutyDetail where PlanDutyTableid in (select pkid from dbo.TPlanDutyTable where totime<'2013-1-1')
delete from dbo.TPlanDutyTable where totime<'2013-1-1'

delete from dbo.TReadDataHistory where readtime <'2013-1-1'
delete from dbo.TEmployeeInAndOutRecord where iotime <'2013-1-1'
delete from dbo.TEmployeeAttendance where TheDay<'2013-1-1'
delete from dbo.TInAndOutRecordLog where newiotime <'2013-1-1'