Update TAdjustRest set AdjustYear='2009-1-1'

SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (904,'�������ͻ�ά��',9,'../ReimbursePages/ReimburseCustomerSearch.aspx',1)

SET IDENTITY_INSERT TAuth Off

Update TAuth set AuthName='������ѯ' where PKID=902
Update TAuth set AuthName='����������' where PKID=901