delete from TLeaveRequestType
delete from TEmployee
DElete from TContractType
delete from TAttendanceReadTime
DELETE FROM TAUTH
DELETE FROM TAccountAuth
--------------------------------------------------
/*                 �������г�ʼ����                  */
--------------------------------------------------

--Begin               Ա����Ȩ��       -------------

SET IDENTITY_INSERT TAuth ON

--һλ������λ���ֱ�ʾһ��Ŀ¼
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1,'��������',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (2,'�û�����',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (3,'��֯�ܹ�����',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (4,'Ա������',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (5,'���ڹ���',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (6,'н�ʹ���',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (7,'��Ч����',0,'',0)--8
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (8,'��ѵ����',0,'',0)--9
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (9,'��������',0,'',0)--10
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (10,'����ͬ��',0,'',0)

--��λ������λ���ֱ�ʾ����Ŀ¼
--1 ��������
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (101,'���ú�ͬ����',1,'../ContractPages/ContractTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (102,'�����������',1,'../LeaveRequestTypePages/LeaveRequestTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (103,'���ü�������',1,'../SkillPages/SkillTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (104,'���ü���',1,'../SkillPages/SkillList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (105,'�����Զ�������',1,'../DiyProcessPages/DiyProcessList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (106,'���ù�����ϵ��',1,'../CompanyTeleBooksPages/CompanyTeleBook.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (107,'���ù���',1,'../NationalityPages/NationalityList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (108,'���õ��ݹ���',1,'../AdjustRulePages/AdjustRuleInfoPage.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (109,'���ÿͻ���Ϣ',1,'../CustomerInfoPages/CustomerInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1010,'������Ŀ��Ϣ',1,'../ProjectInfoPages/ProjectInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1011,'���û�����Ϣ',1,'../ExchangeRatePages/ExchangeRate.aspx',0)

--2 �û�����
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (201,'����Ȩ��',2,'../AuthPages/AssignAuth.aspx',0)

--3 ��֯�ṹ����
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (301,'��ѯ������ʷ',3,'../DepartmentPages/DepartmentHistoryList.aspx',0)

--4 Ա������
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (401,'��ѯԱ��',4,'../EmployeePages/EmployeeList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (402,'��ѯԱ����ͬ',4,'../ContractPages/EmployeeContractSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (403,'��ѯԱ�����',4,'../EmployeePages/VacationList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (404,'��ѯԱ������',4,'../EmployeeAdjustRestPages/EmployeeAdjustRestlist.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (405,'Ա��ͳ��',4,'../EmployeeStatisticsPages/EmployeeStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (406,'Ա���߼���ѯ',4,'../AdvanceSearchPages/EmployeeAdvanceSearch.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (407,'Ա����ͬ�߼���ѯ',4,'../AdvanceSearchPages/ContractAdvanceSearch.aspx',0)

--5 ���ڹ���
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (501,'���ð��',5,'../AttendancePages/DutyClassList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (502,'�����Ű��',5,'../AttendancePages/PlanDutyList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (503,'Ա������Ϣ',5,'../AttendancePages/InAndOutStatisticsRecord.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (504,'��ѯ�򿨼�¼',5,'../AttendancePages/SearchEmployeeInAndOutList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (505,'���ڹ���',5,'../AttendancePages/EmployeeAttendanceSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (506,'�տ�����ϸ',5,'../AttendancePages/DayAttendance.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (507,'����ͳ��',5,'../AttendancePages/MonthAttendance.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (508,'����Ϣ�޸���־',5,'../AttendancePages/InAndOutLogList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (509,'��ѯ�����¼',5,'../AttendancePages/ApplicationSearch.aspx',1)


--6 н�ʹ���
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (601,'�������������',6,'../PayModulePages/AccountSetParaManagement.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (602,'��������',6,'../PayModulePages/AccountSetList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (603,'����˰��',6,'../PayModulePages/IndividualIncomeTax.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (604,'����Ա������',6,'../PayModulePages/SetEmployeeAccountSetList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (605,'����Ա������',6,'../PayModulePages/EmployeeWelfareList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (606,'��н',6,'../PayModulePages/SetEmployeeSalaryCondition.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (607,'н��ͳ��',6,'../PayModulePages/EmployeeSalaryStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (608,'Ա��н��ͳ��',6,'../PayModulePages/EmployeeSalaryHistoryStatistics.aspx',0)


--7 ��Ч����
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (701,'���ü�Ч������',7,'../AssessPages/TemplateItemList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (702,'���ü�Ч���˱�',7,'../AssessPages/TemplatePaperList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (703,'����Ч����',7,'../AssessPages/HRApplyEmployeeAssess.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (704,'ȷ�ϼ�Ч����',7,'../AssessPages/GetConfirmAssesses.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (705,'��ѯ��Ч����',7,'../AssessPages/AssessActivityList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (706,'��ѯ��ͬ��Ч����',7,'../AssessPages/ContractAssessActivityList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (707,'��ѯ���ռ�Ч����',7,'../AssessPages/AnnualAssessActivityList.aspx',1)
--INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
--VALUES (706,'��ѯ��Ч����',7,'../AssessPages/AssessActivityList.aspx',1)

--8 ��ѵ����
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (801,'��ѵ�γ̹���',8,'../TrainingPages/SearchTrainCourseBack.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (802,'��ѵ��������',8,'../TrainingPages/FeedBackSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (803,'���÷�����������',8,'../TrainingPages/FBQuesTypeInfo.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (804,'��ѵ�����������',8,'../TrainingPages/TrainFBQuesList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (805,'���÷����ʾ�',8,'../TrainingPages/FeedBackPaperList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (806,'��ѵ�������',8,'../TrianApplicationPages/TrainApplicationSearch.aspx',1)

--9 ��������
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (901,'���յ�������',9,'../ReimbursePages/SearchReimburse.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (902,'������ѯ',9,'../ReimbursePages/SearchTravelReimburse.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (903,'����ͳ��',9,'../ReimbursePages/ReimburseStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (904,'�������ͻ�ά��',9,'../ReimbursePages/ReimburseCustomerSearch.aspx',1)

--10 ����ͬ��
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1001,'���ݵ���',10,'../DataTransferPages/BackUpData.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1002,'���ݵ���',10,'../DataTransferPages/RestoreData.aspx',0)

SET IDENTITY_INSERT TAuth OFF

INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,2,0)--�û�����
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,201,0)--����Ȩ��

INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,10,0)--�û�����
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,1001,0)--����Ȩ��
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,1002,0)--����Ȩ��


--Begin             �������       -------------

SET IDENTITY_INSERT TLeaveRequestType ON

INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (1,'���','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (2,'�¼�','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (3,'����','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (4,'����','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (5,'���','',1,1,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (6,'ɥ��','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (7,'��ǰ��','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (8,'�����','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (9,'����','',1,1,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (10,'�����','',0,0,4)

SET IDENTITY_INSERT TLeaveRequestType OFF

--End               �������       -------------

--��ͬ����
SET IDENTITY_INSERT TContractType ON
INSERT INTO TContractType (PKID,[Name])
VALUES (1,'�Ͷ���ͬ')
INSERT INTO TContractType (PKID,[Name])
VALUES (2,'�Ͷ���ͬ��ǩҳ')
INSERT INTO TContractType (PKID,[Name])
VALUES (3,'����Ͷ���ͬЭ����')
INSERT INTO TContractType (PKID,[Name])
VALUES (4,'ʵϰЭ��')
SET IDENTITY_INSERT TContractType OFF

--�������ݶ�ȡʱ��
SET IDENTITY_INSERT TAttendanceReadTime ON
INSERT INTO TAttendanceReadTime (PKID,ReadDateTime,IsSendEmail,SendEmailRull)
VALUES (1,'2008-01-01 10:00:00',0,2)

SET IDENTITY_INSERT TAttendanceReadTime OFF

SET IDENTITY_INSERT TParameter ON
Insert into TParameter([PKID],[Name],[Type],[Description]) 
values(1,'�л����񹲺͹�',7,'')
SET IDENTITY_INSERT TParameter OFF


