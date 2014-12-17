ALTER TABLE dbo.TOverWorkItem add AdjustHour Decimal(25,2) not null default 0
ALTER TABLE dbo.TOutApplicationItem add AdjustHour Decimal(25,2) not null default 0
ALTER TABLE dbo.TOutApplicationItem add Adjust int not null default 0