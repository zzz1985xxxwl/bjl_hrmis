delete from TAuth where pkid=605
delete from TAuth where pkid=606
delete from TAuth where pkid=607

SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (806,'��ѵ�������',8,'../TrianApplicationPages/TrainApplicationSearch.aspx',1)

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (605,'����Ա������',6,'../PayModulePages/EmployeeWelfareList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (606,'��н',6,'../PayModulePages/SetEmployeeSalaryCondition.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (607,'н��ͳ��',6,'../PayModulePages/EmployeeSalaryStatisticsBack.aspx',1)

SET IDENTITY_INSERT TAuth OFF


Update TAccountAuth set AuthId=607 where AuthID=606
Update TAccountAuth set AuthId=606 where AuthID=605

update tauth
set navigateurl='../PayModulePages/EmployeeSalaryStatistics.aspx'
where authname='н��ͳ��'

update tauth
set navigateurl='../AttendancePages/MonthAttendance.aspx'
where authname='����ͳ��'

update tauth
set navigateurl='../EmployeeStatisticsPages/EmployeeStatistics.aspx'
where authname='Ա��ͳ��'