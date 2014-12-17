update TAuth set AuthName = '我的日程统计' where pkid = 204

SET IDENTITY_INSERT TAuth ON
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (205,'我的跟踪统计',2,'../AssistancePages/MyTrackAnalyst.aspx')
SET IDENTITY_INSERT TAuth OFF