SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (106,'设置共享联系人',1,'../CompanyTeleBooksPages/CompanyTeleBook.aspx',0)

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (902,'报销统计',9,'../ReimbursePages/ReimburseStatistics.aspx',1)

SET IDENTITY_INSERT TAuth OFF

delete from TAuth where PKID=706
delete from TAccountAuth where AuthId=706
update TAuth set AuthName='查询绩效考核', NavigateUrl='../AssessPages/AssessActivityList.aspx' where PKID=705

INSERT INTO [hrmis].[dbo].[TEmployeeHistory] 
([AccountID] 
,[CompanyID] 
,[AccountType] 
,[MobileNum] 
,[IsAcceptEmail] 
,[IsAcceptSMS] 
,[IsValidateUsbKey] 
,[LeaveDate] 
,[Name]-- 
,[LoginName] 
,[Password] 
,[Email1] 
,[Email2] 
,[DepartmentID] 
,[PositionID] 
,[ComeDate] 
,[Birthday] 
,[ResidencePermit] 
,[EmployeeType] 
,[EnglishName] 
,[Gender] 
,[PoliticalAffiliation] 
,[MaritalStatus] 
,[EducationalBackground] 
,[WorkType] 
,[HasChild] 
,[EmployeeDetails] 
,[Certificates] 
,[PRPArea] 
,[ProbationTime] 
,[UsbKey] 
,[Photo] 
,[DoorCardNo] 
,[SocietyWorkAge] 
,[OperatorID]-- 
,[OperationTime]-- 
,[Remark]-- 
,[LeaderName]-- 
,[DepartmentName]-- 
,[PositionName]-- 
,[OperatorName]-- 
) 
SELECT [AccountID] 
,[CompanyID] 
,sep.dbo.taccount.[AccountType] 
,sep.dbo.taccount.[MobileNum] 
,sep.dbo.taccount.[IsAcceptEmail] 
,sep.dbo.taccount.[IsAcceptSMS] 
,sep.dbo.taccount.[IsValidateUsbKey] 
,[LeaveDate] 
,sep.dbo.taccount.[employeeName]-- 
,sep.dbo.taccount.[LoginName] 
,sep.dbo.taccount.[Password] 
,sep.dbo.taccount.[Email1] 
,sep.dbo.taccount.[Email2] 
,sep.dbo.taccount.[DepartmentID] 
,sep.dbo.taccount.[PositionID] 
,[ComeDate] 
,[Birthday] 
,[ResidencePermit] 
,[EmployeeType] 
,[EnglishName] 
,[Gender] 
,[PoliticalAffiliation] 
,[MaritalStatus] 
,[EducationalBackground] 
,[WorkType] 
,[HasChild] 
,[EmployeeDetails] 
,[Certificates] 
,[PRPArea] 
,[ProbationTime] 
,sep.dbo.taccount.[UsbKey] 
,null 
,[DoorCardNo] 
,[SocietyWorkAge] 
,-9-- 
,'2009-7-3'-- 
,'导数据修正'-- 
,taccountleader.employeename-- 
,sep.dbo.tdepartment.departmentname-- 
,sep.dbo.tposition.positionname-- 
,'admin'-- 
from sep.dbo.taccount,hrmis.dbo.temployee 
,sep.dbo.tdepartment,sep.dbo.tposition 
,sep.dbo.taccount as taccountleader 
where sep.dbo.taccount.pkid = hrmis.dbo.temployee.accountid 
and sep.dbo.tdepartment.pkid = sep.dbo.taccount.departmentid 
and sep.dbo.tposition.pkid = sep.dbo.taccount.positionid 
and sep.dbo.tdepartment.Leaderid = taccountleader.pkid