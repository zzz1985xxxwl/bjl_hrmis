
Alter Table  dbo.TDepartment Add [Address] Nvarchar(200)
Alter Table  dbo.TDepartment Add Phone Nvarchar(50)
Alter Table  dbo.TDepartment Add Fax Nvarchar(50)
Alter Table  dbo.TDepartment Add Others Nvarchar(50)
Alter Table  dbo.TDepartment Add [Description] TEXT
Alter Table  dbo.TDepartment Add FoundationTime DateTime


Alter Table TWelcomeMail Add MailType  INT   NOT NULL


Alter table TBulletin  Add DepartmentID  int  not null default 1
Alter table TAuth  Add  IfHasDepartment int  not null default 0
Alter table TAccountAuth  Add  DepartmentID int  not null default 0

