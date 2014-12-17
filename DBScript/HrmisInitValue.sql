delete from TLeaveRequestType
delete from TEmployee
DElete from TContractType
delete from TAttendanceReadTime
DELETE FROM TAUTH
DELETE FROM TAccountAuth
--------------------------------------------------
/*                 新增所有初始数据                  */
--------------------------------------------------

--Begin               员工、权限       -------------

SET IDENTITY_INSERT TAuth ON

--一位或者两位数字表示一级目录
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1,'参数设置',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (2,'用户管理',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (3,'组织架构管理',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (4,'员工管理',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (5,'考勤管理',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (6,'薪资管理',0,'',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (7,'绩效管理',0,'',0)--8
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (8,'培训管理',0,'',0)--9
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (9,'报销管理',0,'',0)--10
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (10,'数据同步',0,'',0)

--三位或者四位数字表示二级目录
--1 参数设置
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (101,'设置合同类型',1,'../ContractPages/ContractTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (102,'设置请假类型',1,'../LeaveRequestTypePages/LeaveRequestTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (103,'设置技能类型',1,'../SkillPages/SkillTypeList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (104,'设置技能',1,'../SkillPages/SkillList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (105,'设置自定义流程',1,'../DiyProcessPages/DiyProcessList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (106,'设置共享联系人',1,'../CompanyTeleBooksPages/CompanyTeleBook.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (107,'设置国籍',1,'../NationalityPages/NationalityList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (108,'设置调休规则',1,'../AdjustRulePages/AdjustRuleInfoPage.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (109,'设置客户信息',1,'../CustomerInfoPages/CustomerInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1010,'设置项目信息',1,'../ProjectInfoPages/ProjectInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1011,'设置汇率信息',1,'../ExchangeRatePages/ExchangeRate.aspx',0)

--2 用户管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (201,'分配权限',2,'../AuthPages/AssignAuth.aspx',0)

--3 组织结构管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (301,'查询部门历史',3,'../DepartmentPages/DepartmentHistoryList.aspx',0)

--4 员工管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (401,'查询员工',4,'../EmployeePages/EmployeeList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (402,'查询员工合同',4,'../ContractPages/EmployeeContractSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (403,'查询员工年假',4,'../EmployeePages/VacationList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (404,'查询员工调休',4,'../EmployeeAdjustRestPages/EmployeeAdjustRestlist.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (405,'员工统计',4,'../EmployeeStatisticsPages/EmployeeStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (406,'员工高级查询',4,'../AdvanceSearchPages/EmployeeAdvanceSearch.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (407,'员工合同高级查询',4,'../AdvanceSearchPages/ContractAdvanceSearch.aspx',0)

--5 考勤管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (501,'设置班别',5,'../AttendancePages/DutyClassList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (502,'设置排班表',5,'../AttendancePages/PlanDutyList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (503,'员工打卡信息',5,'../AttendancePages/InAndOutStatisticsRecord.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (504,'查询打卡记录',5,'../AttendancePages/SearchEmployeeInAndOutList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (505,'出勤管理',5,'../AttendancePages/EmployeeAttendanceSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (506,'日考勤明细',5,'../AttendancePages/DayAttendance.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (507,'考勤统计',5,'../AttendancePages/MonthAttendance.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (508,'打卡信息修改日志',5,'../AttendancePages/InAndOutLogList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (509,'查询申请记录',5,'../AttendancePages/ApplicationSearch.aspx',1)


--6 薪资管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (601,'设置帐套项参数',6,'../PayModulePages/AccountSetParaManagement.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (602,'设置帐套',6,'../PayModulePages/AccountSetList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (603,'设置税制',6,'../PayModulePages/IndividualIncomeTax.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (604,'设置员工帐套',6,'../PayModulePages/SetEmployeeAccountSetList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (605,'设置员工福利',6,'../PayModulePages/EmployeeWelfareList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (606,'发薪',6,'../PayModulePages/SetEmployeeSalaryCondition.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (607,'薪资统计',6,'../PayModulePages/EmployeeSalaryStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (608,'员工薪资统计',6,'../PayModulePages/EmployeeSalaryHistoryStatistics.aspx',0)


--7 绩效管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (701,'设置绩效考核项',7,'../AssessPages/TemplateItemList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (702,'设置绩效考核表',7,'../AssessPages/TemplatePaperList.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (703,'发起绩效考核',7,'../AssessPages/HRApplyEmployeeAssess.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (704,'确认绩效考核',7,'../AssessPages/GetConfirmAssesses.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (705,'查询绩效考核',7,'../AssessPages/AssessActivityList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (706,'查询合同绩效考核',7,'../AssessPages/ContractAssessActivityList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (707,'查询年终绩效考核',7,'../AssessPages/AnnualAssessActivityList.aspx',1)
--INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
--VALUES (706,'查询绩效考核',7,'../AssessPages/AssessActivityList.aspx',1)

--8 培训管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (801,'培训课程管理',8,'../TrainingPages/SearchTrainCourseBack.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (802,'培训反馈管理',8,'../TrainingPages/FeedBackSearch.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (803,'设置反馈问题类型',8,'../TrainingPages/FBQuesTypeInfo.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (804,'培训反馈问题管理',8,'../TrainingPages/TrainFBQuesList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (805,'设置反馈问卷',8,'../TrainingPages/FeedBackPaperList.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (806,'培训申请管理',8,'../TrianApplicationPages/TrainApplicationSearch.aspx',1)

--9 报销管理
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (901,'已收到报销单',9,'../ReimbursePages/SearchReimburse.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (902,'报销查询',9,'../ReimbursePages/SearchTravelReimburse.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (903,'报销统计',9,'../ReimbursePages/ReimburseStatistics.aspx',1)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (904,'报销单客户维护',9,'../ReimbursePages/ReimburseCustomerSearch.aspx',1)

--10 数据同步
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1001,'数据导出',10,'../DataTransferPages/BackUpData.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1002,'数据导入',10,'../DataTransferPages/RestoreData.aspx',0)

SET IDENTITY_INSERT TAuth OFF

INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,2,0)--用户管理
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,201,0)--分配权限

INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,10,0)--用户管理
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,1001,0)--分配权限
INSERT INTO TAccountAuth (AccountId,AuthId,DepartmentID)
VALUES (-9,1002,0)--分配权限


--Begin             假期类别       -------------

SET IDENTITY_INSERT TLeaveRequestType ON

INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (1,'年假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (2,'事假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (3,'病假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (4,'调休','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (5,'婚假','',1,1,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (6,'丧假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (7,'产前假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (8,'哺乳假','',0,0,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (9,'产假','',1,1,4)
INSERT INTO TLeaveRequestType (PKID,[Name],Description,IncludeNationalHolidays,IncludeRestDay,LeastHour)
VALUES (10,'护理假','',0,0,4)

SET IDENTITY_INSERT TLeaveRequestType OFF

--End               假期类别       -------------

--合同类型
SET IDENTITY_INSERT TContractType ON
INSERT INTO TContractType (PKID,[Name])
VALUES (1,'劳动合同')
INSERT INTO TContractType (PKID,[Name])
VALUES (2,'劳动合同续签页')
INSERT INTO TContractType (PKID,[Name])
VALUES (3,'变更劳动合同协议书')
INSERT INTO TContractType (PKID,[Name])
VALUES (4,'实习协议')
SET IDENTITY_INSERT TContractType OFF

--考勤数据读取时间
SET IDENTITY_INSERT TAttendanceReadTime ON
INSERT INTO TAttendanceReadTime (PKID,ReadDateTime,IsSendEmail,SendEmailRull)
VALUES (1,'2008-01-01 10:00:00',0,2)

SET IDENTITY_INSERT TAttendanceReadTime OFF

SET IDENTITY_INSERT TParameter ON
Insert into TParameter([PKID],[Name],[Type],[Description]) 
values(1,'中华人民共和国',7,'')
SET IDENTITY_INSERT TParameter OFF


