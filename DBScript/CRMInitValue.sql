DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH


--Begin               权限       -------------
SET IDENTITY_INSERT TAuth ON

--一位或者两位数字表示一级目录
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'销售管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'我的助理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'售后管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'团队管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'产品管理',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'系统信息设置',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (7,'权限管理',0,'')

--1 销售管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'我的商机',1,'../OpportunityPages/SearchMyOpportunity.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'我的客户',1,'../CustomerPages/MyCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (103,'我的订单',1,'../OrderPages/SearchMyOrder.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (104,'我的联系人',1,'../ContactPages/ContactList.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (105,'客户池',1,'../TeamPages/CustomerPool.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (106,'客户库',1,'../CustomerPages/CustomerForAll.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (107,'产品库',1,'../ProductPages/ProductForAll.aspx')

--2 日程安排
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'我的日程',2,'../AssistancePages/CalendarEventList.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'我的提醒',2,'../AssistancePages/MyRemind.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (203,'记忆曲线',2,'../AssistancePages/TrackCurve.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (204,'我的日程统计',2,'../AssistancePages/CalendarAnalyst.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (205,'我的跟踪统计',2,'../AssistancePages/MyTrackAnalyst.aspx')

--3 售后管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'投诉反馈',3,'../AfterServicePages/ComplainList.aspx')
--INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
--VALUES (302,'查询公告',3,'../BulletinPages/BulletinListBack.aspx')

--4 团队管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'分配客户资源',4,'../TeamPages/AssignCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'导出客户',4,'../TeamPages/ExportCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (403,'人员日程详情',4,'../TeamPages/SingleEmployeeTeamStat.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (404,'人员日程对比',4,'../TeamPages/EmployeesStatsInfo.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (405,'部门日程对比',4,'../TeamPages/DepartmentStatisticsIndex.aspx')


--5 产品管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'设置产品',5,'../ProductPages/ProductSearch.aspx')


--6 系统信息设置
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'设置客户状态',6,'../ParameterPages/CustomerLevel.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (602,'设置销售阶段',6,'../ParameterPages/SalesStage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (603,'设置产品分类',6,'../ParameterPages/ProductFirstType.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (604,'设置客户来源',6,'../ParameterPages/Orgin.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (605,'设置联系方式',6,'../ParameterPages/Orgin.aspx')

--7 权限管理
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (701,'分配权限',7,'../ParameterPages/AssignCrmAuthPage.aspx')


SET IDENTITY_INSERT TAuth OFF
--End                 权限       -------------

--begin 设置账号Admin的所有权限  -------------
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	1)--	销售管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	2)--	日程安排
----INSERT INTO TAccountAuth (AccountID,AuthID)		
----VALUES (-9,	3)--	售后管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	4)--	团队管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	5)--	产品管理
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	6)--	系统信息设置
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	7)--	权限管理

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	101)--	我的商机
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	102)--	我的客户
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	103)--	我的订单
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	104)--	我的联系人
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	105)--	客户池
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	106)--	客户库
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	107)--	产品库
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	201)--	我的日程
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	202)--	我的提醒
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	203)--	记忆曲线
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	204)--	日程分析

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	301)--	新增公告
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	302)--	查询公告

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	401)--	分配客户资源
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	402)--	导出客户
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	403)--	人员日程详情
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	404)--	人员日程对比
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	405)--	部门日程对比
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	501)--	设置产品
--
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	601)--	设置客户状态
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	602)--	设置商机阶段
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	603)--	设置产品分类

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	701)--	分配权限
--end   设置账号Admin的所有权限  -------------