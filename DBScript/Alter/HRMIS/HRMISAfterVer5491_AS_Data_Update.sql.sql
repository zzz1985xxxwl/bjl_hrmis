SET IDENTITY_INSERT TAuth ON
INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (107,'���ù���',1,'../NationalityPages/NationalityList.aspx',0)
SET IDENTITY_INSERT TAuth OFF

SET IDENTITY_INSERT TParameter ON
Insert into TParameter([PKID],[Name],[Type],[Description]) 
values(1,'�л����񹲺͹�',7,'')
SET IDENTITY_INSERT TParameter OFF

update TEmployee set CountryNationalityID = 1
SET IDENTITY_INSERT TAuth OFF

UPDATE  TDiyStep SET  Status = '������Դ����'  WHERE  Status = '��������'

update TDutyClass set AbsentLateTime=LateTime,
AbsentEarlyLeaveTime=EarlyLeaveTime,
LateTime=0,EarlyLeaveTime=0

SET IDENTITY_INSERT TAuth ON

INSERT INTO TAuth (PKID,AuthName,AuthParentId,NavigateUrl,IfHasDepartment)
VALUES (805,'���÷����ʾ�',8,'../TrainingPages/FeedBackPaperList.aspx',1)

SET IDENTITY_INSERT TAuth OFF
