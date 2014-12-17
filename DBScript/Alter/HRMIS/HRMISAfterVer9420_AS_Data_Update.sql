update taccountsetitem
set FieldAttribute = taccountsetpara.FieldAttribute
,BindItem = taccountsetpara.BindItem
,MantissaRound =taccountsetpara.MantissaRound
from taccountsetpara
where taccountsetpara.pkid = accountsetparaID

ALTER TABLE dbo.TAccountSetItem alter column  FieldAttribute	INT   not null
ALTER TABLE dbo.TAccountSetItem alter column  BindItem	    INT   not null
ALTER TABLE dbo.TAccountSetItem alter column  MantissaRound	INT  not null
