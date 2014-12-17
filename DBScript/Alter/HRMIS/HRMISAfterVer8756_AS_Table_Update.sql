ALTER TABLE dbo.TReimburse DROP constraint DF__TReimburs__OutCi__514B77A6--需要针对不同的数据库修改
ALTER TABLE dbo.TReimburse alter column OutCityDays decimal(25,2) not null 