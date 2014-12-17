DELETE FROM TACCOUNT
DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH
DELETE FROM dbo.TDepartment
DELETE FROM dbo.TPosition
DELETE FROM dbo.TPositionGrade

SET IDENTITY_INSERT TAccount ON
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType])
values(1,'admin','管理员','Mc8L3BG3DPZwggWy8zuNSA==',15)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(2,'chencheng','陈诚','Mc8L3BG3DPZwggWy8zuNSA==',15,'chencheng@shixintech.com','','13902453659',1,1)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(3,'yangliqun','杨立群','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangliqun@shixintech.com','','13902453658',2,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(4,'wanglei','王蕾','Mc8L3BG3DPZwggWy8zuNSA==',15,'wanglei@shixintech.com','','13902453650',3,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(5,'杨kun','杨坤','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangkun@shixintech.com','','13902453651',4,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(6,'yuyang','于洋','Mc8L3BG3DPZwggWy8zuNSA==',15,'yuyang@shixintech.com','','13902453656',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(7,'liqi','李琦','Mc8L3BG3DPZwggWy8zuNSA==',15,'liqi@shixintech.com','','13902453653',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(8,'jinfan','金帆','Mc8L3BG3DPZwggWy8zuNSA==',15,'jinfan@shixintech.com','','13902453657',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(9,'yangyubin','杨俞斌','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangyubing@shixintech.com','','13902453650',3,3)
SET IDENTITY_INSERT TAccount OFF

--Begin               权限       -------------
SET IDENTITY_INSERT TAuth ON

--一位或者两位数字表示一级目录
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'用户管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'员工管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'部门管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'职位管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'公告管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'目标管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (7,'企业文化',0,'')

--1 用户管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'帐号维护',1,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'分配权限',1,'')

--2 员工管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'员工维护',2,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'查询员工',2,'')

--3 部门管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'部门维护',3,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (302,'查询部门',3,'')

--4 职位管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'职位维护',4,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'查询职位',4,'')

--5 公告管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'公告维护',5,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (502,'查询公告',5,'')

--6 公司目标管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'公司目标维护',6,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (602,'查询公司目标',6,'')

--7 企业文化
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (701,'公司规章维护',7,'')

SET IDENTITY_INSERT TAuth OFF
--End                 权限       -------------

--begin 设置账号Admin的所有权限  -------------
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	1)--	用户管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	2)--	员工管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	3)--	部门管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	4)--	职位管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	5)--	公告管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	6)--	目标管理
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	7)--	企业文化

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	101)--	帐号维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	102)--	分配权限

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	201)--	员工维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	202)--	查询员工

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	301)--	部门维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	302)--	查询部门

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	401)--	职位维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	402)--	查询职位

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	501)--	公告维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	502)--	查询公告

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	601)--	公司目标维护
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	602)--	查询公司目标

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	701)--	公司规章维护
--end   设置账号Admin的所有权限  -------------

SET IDENTITY_INSERT TDepartment ON
--一位数字表示一级部门
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)--此部门在TDepartment中是根结点
VALUES (1,'上海实信商业软件公司',2,0)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (2,'人力资源部',3,1)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (3,'技术部',4,1)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (4,'销售部',5,1)


SET IDENTITY_INSERT TDepartment OFF



SET IDENTITY_INSERT TPositionGrade ON
--Type为1，表示职位，PKID从100开始
INSERT INTO TPositionGrade(PKID,[PositionGradeName],[PositionGradeDescription],[Sequence])
VALUES (1,'A','A',0)
SET IDENTITY_INSERT TPositionGrade OFF



SET IDENTITY_INSERT TPosition ON
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (1,'CEO',1,'CEO')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (2,'主管',1,'部门主管')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (3,'技术员',1,'技术部人员')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (4,'销售',1,'销售人员')
SET IDENTITY_INSERT TPosition OFF

