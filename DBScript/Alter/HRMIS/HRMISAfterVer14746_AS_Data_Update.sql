SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1010,'设置项目信息',1,'../ProjectInfoPages/ProjectInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1011,'设置汇率信息',1,'../ExchangeRatePages/ExchangeRate.aspx',0)

SET IDENTITY_INSERT TAuth Off

insert into TExchangeRate(Name,ActiveDate,Rate,Symbol) values('人民币','2013-1-1',1,'￥')


update TReimburse set ExchangeRateID=b.PKID
from(
select top 1 pkid from 
TExchangeRate 
where Name='人民币') as b where TReimburse.ExchangeRateID=0