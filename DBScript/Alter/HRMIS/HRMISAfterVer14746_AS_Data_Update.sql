SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1010,'������Ŀ��Ϣ',1,'../ProjectInfoPages/ProjectInfo.aspx',0)
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (1011,'���û�����Ϣ',1,'../ExchangeRatePages/ExchangeRate.aspx',0)

SET IDENTITY_INSERT TAuth Off

insert into TExchangeRate(Name,ActiveDate,Rate,Symbol) values('�����','2013-1-1',1,'��')


update TReimburse set ExchangeRateID=b.PKID
from(
select top 1 pkid from 
TExchangeRate 
where Name='�����') as b where TReimburse.ExchangeRateID=0