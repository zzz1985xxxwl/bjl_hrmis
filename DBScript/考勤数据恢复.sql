SET IDENTITY_INSERT TEmployeeInAndOutRecord ON
INSERT INTO [dbo].[TEmployeeInAndOutRecord]
           ([PKID]
           ,[EmployeeID]
           ,[DoorCardNo]
           ,[IOTime]
           ,[IOStatus]
           ,[OperateStatus]
           ,[OperateTime])
select [PKID]
           ,[EmployeeID]
           ,[DoorCardNo]
           ,[IOTime]
           ,[IOStatus]
           ,[OperateStatus]
           ,[OperateTime] from TEmployeeInAndOutRecord2012 where EmployeeID=190
SET IDENTITY_INSERT TEmployeeInAndOutRecord OFF


SET IDENTITY_INSERT TInAndOutRecordLog ON
INSERT INTO [dbo].TInAndOutRecordLog
           ( [PKID]
      ,[EmployeeID]
      ,[OldIOTime]
      ,[OldIOStatus]
      ,[NewIOTime]
      ,[NewIOStatus]
      ,[OperateStatus]
      ,[Operator]
      ,[OperateTime]
      ,[OperateReason])
select  [PKID]
      ,[EmployeeID]
      ,[OldIOTime]
      ,[OldIOStatus]
      ,[NewIOTime]
      ,[NewIOStatus]
      ,[OperateStatus]
      ,[Operator]
      ,[OperateTime]
      ,[OperateReason] from TInAndOutRecordLog2012 where EmployeeID=190
SET IDENTITY_INSERT TInAndOutRecordLog OFF


SET IDENTITY_INSERT [TLeaveRequest] ON
INSERT INTO [dbo].[TLeaveRequest]
           (  [PKID]
      ,[AccountID]
      ,[LeaveRequestTypeID]
      ,[Reason]
      ,[SubmitDate]
      ,[AbsentFrom]
      ,[AbsentTo]
      ,[AbsentHours]
      ,[DiyProcess])
SELECT [PKID]
      ,[AccountID]
      ,[LeaveRequestTypeID]
      ,[Reason]
      ,[SubmitDate]
      ,[AbsentFrom]
      ,[AbsentTo]
      ,[AbsentHours]
      ,[DiyProcess]
  FROM [dbo].[TLeaveRequest2012] where [AccountID]=190
SET IDENTITY_INSERT [TLeaveRequest] OFF


SET IDENTITY_INSERT [TLeaveRequestFlow] ON
INSERT INTO [dbo].[TLeaveRequestFlow]
           (  [PKID]
      ,[LeaveRequestItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark])
SELECT [PKID]
      ,[LeaveRequestItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark]
FROM [dbo].[TLeaveRequestFlow2012] where [LeaveRequestItemID] in (select PKID from TLeaveRequestItem2012 where  LeaveRequestID in (select PKID from TLeaveRequest2012 where AccountID=190))
SET IDENTITY_INSERT [TLeaveRequestFlow] OFF


SET IDENTITY_INSERT [TLeaveRequestItem] ON
INSERT INTO [TLeaveRequestItem](
      [PKID]
      ,[LeaveRequestID]
      ,[Status]
      ,[AbsentFrom]
      ,[AbsentTo]
      ,[AbsentHours]
      ,[NextProcessID]
      ,[UseList]
)
SELECT [PKID]
      ,[LeaveRequestID]
      ,[Status]
      ,[AbsentFrom]
      ,[AbsentTo]
      ,[AbsentHours]
      ,[NextProcessID]
      ,[UseList]
  FROM [dbo].[TLeaveRequestItem2012] where LeaveRequestID in (select PKID from TLeaveRequest2012 where AccountID=190)
SET IDENTITY_INSERT [TLeaveRequestItem] OFF


SET IDENTITY_INSERT [TOutApplication] ON
INSERT INTO [TOutApplication](
 [PKID]
      ,[AccountID]
      ,[SubmitDate]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Reason]
      ,[OutLocation]
      ,[OutType]
      ,[DiyProcess]
)
SELECT [PKID]
      ,[AccountID]
      ,[SubmitDate]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Reason]
      ,[OutLocation]
      ,[OutType]
      ,[DiyProcess]
  FROM [dbo].[TOutApplication2012] where AccountID=190
SET IDENTITY_INSERT [TOutApplication] OFF



SET IDENTITY_INSERT [TOutApplicationItem] ON
INSERT INTO [TOutApplicationItem](
[PKID]
      ,[OutApplicationID]
      ,[Status]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Adjust]
      ,[AdjustHour]
)
SELECT [PKID]
      ,[OutApplicationID]
      ,[Status]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Adjust]
      ,[AdjustHour]
  FROM [dbo].[TOutApplicationItem2012] where OutApplicationID in (select PKID from [TOutApplication2012] where AccountID=190)
SET IDENTITY_INSERT [TOutApplicationItem] OFF

SET IDENTITY_INSERT [TOutApplicationFlow] ON
INSERT INTO [TOutApplicationFlow](
	   [PKID]
      ,[OutApplicationItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark]
      ,[Step]
)
SELECT [PKID]
      ,[OutApplicationItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark]
      ,[Step]
FROM [dbo].[TOutApplicationFlow2012] where OutApplicationItemID in (select PKID from [TOutApplicationItem2012]  where OutApplicationID in (select PKID from [TOutApplication2012] where AccountID=190))
SET IDENTITY_INSERT [TOutApplicationFlow] OFF


SET IDENTITY_INSERT [TOverWork] ON
INSERT INTO [TOverWork](
	   [PKID]
      ,[AccountID]
      ,[SubmitDate]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Reason]
      ,[ProjectName]
      ,[DiyProcess]
)
SELECT [PKID]
      ,[AccountID]
      ,[SubmitDate]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[Reason]
      ,[ProjectName]
      ,[DiyProcess]
FROM [dbo].[TOverWork2012] where AccountID=190
SET IDENTITY_INSERT [TOverWork] OFF


SET IDENTITY_INSERT [TOverWorkItem] ON
insert into [TOverWorkItem](
[PKID]
      ,[OverWorkID]
      ,[Status]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[OverWorkType]
      ,[Adjust]
      ,[AdjustHour]
)
SELECT [PKID]
      ,[OverWorkID]
      ,[Status]
      ,[From]
      ,[To]
      ,[CostTime]
      ,[OverWorkType]
      ,[Adjust]
      ,[AdjustHour]
  FROM [dbo].[TOverWorkItem2012] where OverWorkID in (select PKID  FROM [dbo].[TOverWork2012] where AccountID=190)
SET IDENTITY_INSERT [TOverWorkItem] OFF




SET IDENTITY_INSERT [TOverWorkFlow] ON
insert into [TOverWorkFlow]
(
[PKID]
      ,[OverWorkItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark]
      ,[Step]
)
SELECT [PKID]
      ,[OverWorkItemID]
      ,[OperatorID]
      ,[Operation]
      ,[OperationTime]
      ,[Remark]
      ,[Step]
  FROM [dbo].[TOverWorkFlow2012] where OverWorkItemID in (select PKID   FROM [dbo].[TOverWorkItem2012] where OverWorkID in (select PKID  FROM [dbo].[TOverWork2012] where AccountID=190) )
SET IDENTITY_INSERT [TOverWorkItem] OFF




















