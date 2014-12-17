alter table TEmployeeWelfare add AccumulationFundSupplyBase Decimal(25,2)  NULL
alter table TEmployeeWelfareHistory add AccumulationFundSupplyBase Decimal(25,2)  NULL

ALTER TABLE TVacation alter column VacationDayNum decimal(6,3) not null 
ALTER TABLE TVacation alter column UsedDayNum decimal(6,3) not null 
ALTER TABLE TVacation alter column SurplusDayNum decimal(6,3) not null 


alter table dbo.TAssessActivityPaper add SalaryNow Decimal(25,2)  NULL
alter table dbo.TAssessActivityPaper add SalaryChange Decimal(25,2)  NULL