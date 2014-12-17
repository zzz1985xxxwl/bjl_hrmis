DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH


--Begin               权限       -------------
SET IDENTITY_INSERT TAuth ON

--一位或者两位数字表示一级目录
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (1,'销售模块',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (2,'库存模块',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (3,'进货模块',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (4,'商品模块',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (5,'权限管理',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (6,'系统信息设置',0,'',0)


--1 销售模块
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (101,'客户帐户管理',1,'../CustomerAccount/CustomerAccountList.aspx',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (102,'客户账户等级管理',1,'../CustomerAccountLevel/CustomerAccountLevelList.aspx',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (103,'销售订单管理',1,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (104,'价套管理',1,'',0)

--2 库存模块
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (201,'仓库管理',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (202,'出入库管理',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (203,'配货管理',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (204,'调拨管理',2,'',0)

--3 进货模块
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (301,'供应商管理',3,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (302,'采购订单管理',3,'',0)

--4 商品模块
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (401,'分类管理',4,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (402,'商品管理',4,'',0)


--5 权限管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (501,'分配权限',5,'../Auths/AssignEShoppingAuthPage.aspx',0)


--6 系统信息设置


SET IDENTITY_INSERT TAuth OFF
--End                 权限       -------------

--begin 设置账号Admin的所有权限  -------------
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	1,0)--	销售模块
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	2,0)--	库存模块
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	3,0)--	进货模块
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	4,0)--	商品模块
INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
VALUES (-9,	5,0)--	权限管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	6,0)--	系统信息设置

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	101,0)--	客户帐户管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	102,0)--	客户账户等级管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	103,0)--	销售订单管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	104,0)--	价套管理

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	201,0)--	仓库管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	202,0)--	出入库管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	203,0)--	配货管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	204,0)--	调拨管理

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	301,0)--	供应商管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	302,0)--	采购订单管理

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	401,0)--	分类管理
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	402,0)--	商品管理		


INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
VALUES (-9,	501,0)--	分配权限

--end   设置账号Admin的所有权限  -------------