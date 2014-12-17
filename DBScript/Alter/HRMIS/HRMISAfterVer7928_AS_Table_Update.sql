
alter table dbo.TAdjustRest add AdjustYear DateTime Not Null default '2009-1-1'


/*客户名*/
alter table TReimburseItem add CustomerID int Not null  default 0

alter table TReimburse drop Column CustomerName





ALTER TABLE dbo.TAdjustRestHistory DROP constraint DF__TAdjustRe__Resul__3430160B--需要针对不同的数据库修改
alter table dbo.TAdjustRestHistory drop column  ResultAdjustRestHours

--顺序执行 start
update TAdjustRestHistory 
set AdjustRestID=(select AccountId from TAdjustRest b where b.PKID=TAdjustRestHistory.AdjustRestID)
 
exec sp_rename 'TAdjustRestHistory.AdjustRestID','AccountID','column'
--顺序执行 end

