DELETE FROM TACCOUNT
DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH
--DELETE FROM TDepartment
--DELETE FROM TPosition

SET IDENTITY_INSERT TAccount ON
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],DepartmentId,PositionId)
values(-9,'admin','系统初始用户','Mc8L3BG3DPZwggWy8zuNSA==',31,1,1)
SET IDENTITY_INSERT TAccount OFF

--SET IDENTITY_INSERT TDepartment ON
--Insert into TDepartment(PKID,DepartmentName,LeaderId,ParentId)
--values(1,'集团',-9,0)
--SET IDENTITY_INSERT TDepartment OFF

--SET IDENTITY_INSERT TPosition ON
--Insert into TPosition(PKID,PositionName,PositionDescription)
--values(1,'CEO','')
--SET IDENTITY_INSERT TPosition OFF

--Begin               权限       -------------
SET IDENTITY_INSERT TAuth ON

--一位或者两位数字表示一级目录
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'用户管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'组织架构管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'公告管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'公司目标管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'企业文化',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'增值服务',0,'')

--1 用户管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'新增用户',1,'../EmployeePages/CreateEmployee.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'查询用户',1,'../EmployeePages/EmployeeManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (103,'分配权限',1,'../AuthPages/AssignAuth.aspx')

--2 组织结构管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'组织架构管理',2,'../DepartmentPages/DepartmentManagement.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'职位管理',2,'../PositionPages/PositionManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (203,'职位等级管理',2,'../PositionPages/PositionGradeManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (204,'岗位性质管理',2,'../PositionPages/PositionNatureManage.aspx')
--3 公告管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'新增公告',3,'../BulletinPages/BulletinAdd.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (302,'查询公告',3,'../BulletinPages/BulletinListBack.aspx')


--4 公司目标管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'新增公司目标',4,'../GoalPages/GoalCompanyAdd.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'查询公司目标',4,'../GoalPages/GoalCompanyList.aspx')

--5 企业文化
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'设置公司规章',5,'../CompanyRegulationsPages/EditCompanyRegulation.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (502,'设置自动发信内容',5,'../WelcomeMailPages/EditWelcomeMail.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (503,'设置特殊时间',5,'../SpecialDatePages/SetSpecialDate.aspx')

--6 增值服务
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'查看短信中心',6,'../ServicesPages/SmsCenter.aspx')

SET IDENTITY_INSERT TAuth OFF
--End                 权限       -------------

--begin 设置账号Admin的权限  -------------
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	1)--	用户管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	2)--	组织结构管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	3)--	公告管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	4)--	公司目标管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	5)--	企业文化
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	6)--	增值服务

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	101)--	新增用户
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	102)--	查询用户
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	103)--	分配权限

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	201)--	组织架构管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	202)--	职位管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	203)--	职位等级管理

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	301)--	新增公告
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	302)--	查询公告
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	401)--	新增公司目标
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	402)--	查询公司目标
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	501)--	设置公司规章
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	502)--	设置欢迎信
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	503)--	设置特殊时间
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	601)--	查看短信中心
--end   设置账号Admin的权限  -------------