
alter table dbo.TAdjustRest add AdjustYear DateTime Not Null default '2009-1-1'


/*�ͻ���*/
alter table TReimburseItem add CustomerID int Not null  default 0

alter table TReimburse drop Column CustomerName





ALTER TABLE dbo.TAdjustRestHistory DROP constraint DF__TAdjustRe__Resul__3430160B--��Ҫ��Բ�ͬ�����ݿ��޸�
alter table dbo.TAdjustRestHistory drop column  ResultAdjustRestHours

--˳��ִ�� start
update TAdjustRestHistory 
set AdjustRestID=(select AccountId from TAdjustRest b where b.PKID=TAdjustRestHistory.AdjustRestID)
 
exec sp_rename 'TAdjustRestHistory.AdjustRestID','AccountID','column'
--˳��ִ�� end

