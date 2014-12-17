Update TAdjustRest set AdjustYear='2009-1-1'

SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (904,'报销单客户维护',9,'../ReimbursePages/ReimburseCustomerSearch.aspx',1)

SET IDENTITY_INSERT TAuth Off

Update TAuth set AuthName='报销查询' where PKID=902
Update TAuth set AuthName='报销单管理' where PKID=901