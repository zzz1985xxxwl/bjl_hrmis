--������
SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (903,'����ͳ��',9,'../ReimbursePages/ReimburseStatistics.aspx',1)

Update TAuth set AuthName = '���յ�������',
		AuthParentId=9 ,
		NavigateUrl='../ReimbursePages/SearchReimburse.aspx' ,
		IfHasDepartment=1
	where	PKID='901'

Update TAuth set AuthName = '���ñ�����ѯ',
		AuthParentId=9 ,
		NavigateUrl='../ReimbursePages/SearchTravelReimburse.aspx' ,
		IfHasDepartment=1
	where	PKID='902'

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (108,'���õ��ݹ���',1,'../AdjustRulePages/AdjustRuleInfoPage.aspx',0)

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (109,'���ÿͻ���Ϣ',1,'../CustomerInfoPages/CustomerInfo.aspx',0)

SET IDENTITY_INSERT TAuth OFF

