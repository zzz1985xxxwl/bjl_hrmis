--报销树
SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (903,'报销统计',9,'../ReimbursePages/ReimburseStatistics.aspx',1)

Update TAuth set AuthName = '已收到报销单',
		AuthParentId=9 ,
		NavigateUrl='../ReimbursePages/SearchReimburse.aspx' ,
		IfHasDepartment=1
	where	PKID='901'

Update TAuth set AuthName = '差旅报销查询',
		AuthParentId=9 ,
		NavigateUrl='../ReimbursePages/SearchTravelReimburse.aspx' ,
		IfHasDepartment=1
	where	PKID='902'

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (108,'设置调休规则',1,'../AdjustRulePages/AdjustRuleInfoPage.aspx',0)

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (109,'设置客户信息',1,'../CustomerInfoPages/CustomerInfo.aspx',0)

SET IDENTITY_INSERT TAuth OFF

