alter table dbo.TReimburse add OutCityDays int not null default 0
alter table dbo.TReimburse add OutCityAllowance decimal(14,2) not null default 0
alter table dbo.TReimburse add Remark Nvarchar(500) not null default ''