ALTER TABLE TEmployeeHistory ADD SalaryCardBank nvarchar(255)	NULL
ALTER TABLE TEmployee ADD SalaryCardBank nvarchar(255)	NULL
ALTER TABLE TReimburseItem ADD CurrencyType int not null default 0
alter table TReimburse alter column TotalCost decimal(14,4) NOT NULL  
alter table TReimburse ADD ExchangeRateID int not null  default 0
alter table TReimburse ADD Discription nvarchar(500) not null default ''

CREATE TABLE	TProjectInfo	(
PKID	            INT	IDENTITY    NOT NULL,
ProjectName         Nvarchar(200)   NOT NULL,
CONSTRAINT PK_TProjectInfo PRIMARY KEY (PKID)
)

CREATE TABLE	TExchangeRate	(
PKID	    INT	IDENTITY    NOT NULL,
Name        Nvarchar(200)   NOT NULL,
Rate        decimal(12,4)   NOT NULL,
Symbol      nvarchar(5)     Null,
ActiveDate  smalldatetime   NOT NULL,
CONSTRAINT PK_TExchangeRate PRIMARY KEY (PKID)
)


alter table TReimburse ADD Discription nvarchar(500)  null 

