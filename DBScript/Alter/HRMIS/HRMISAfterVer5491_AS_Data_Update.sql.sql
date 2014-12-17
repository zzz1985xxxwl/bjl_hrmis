SET IDENTITY_INSERT TAuth ON
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (107,'设置国籍',1,'../NationalityPages/NationalityList.aspx',0)
SET IDENTITY_INSERT TAuth OFF

SET IDENTITY_INSERT TParameter ON
Insert into TParameter([PKID],[Name],[Type],[Description]) 
values(1,'中华人民共和国',7,'')
SET IDENTITY_INSERT TParameter OFF

update TEmployee set CountryNationalityID = 1
SET IDENTITY_INSERT TAuth OFF

UPDATE  TDiyStep SET  Status = '人力资源评定'  WHERE  Status = '人事评定'

update TDutyClass set AbsentLateTime=LateTime,
AbsentEarlyLeaveTime=EarlyLeaveTime,
LateTime=0,EarlyLeaveTime=0

SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (805,'设置反馈问卷',8,'../TrainingPages/FeedBackPaperList.aspx',1)

SET IDENTITY_INSERT TAuth OFF
