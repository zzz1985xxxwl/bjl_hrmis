
delete from taccount where pkid = 1

SET IDENTITY_INSERT TAccount ON
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],DepartmentId,PositionId)
values(-9,'admin','系统初始用户','Mc8L3BG3DPZwggWy8zuNSA==',15,1,1)
SET IDENTITY_INSERT TAccount OFF

update taccountauth
set
accountid = -9 
where accountid = 1

update tdepartment
set leaderid = -9
where leaderid = 1

SET IDENTITY_INSERT TPosition ON
Insert into TPosition(PKID,PositionName,PositionDescription)
values(1,'CEO','')
SET IDENTITY_INSERT TPosition OFF

