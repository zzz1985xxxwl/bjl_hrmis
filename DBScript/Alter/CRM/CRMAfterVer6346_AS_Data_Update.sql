update TAuth set AuthName = '�ҵ��ճ�ͳ��' where pkid = 204

SET IDENTITY_INSERT TAuth ON
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (205,'�ҵĸ���ͳ��',2,'../AssistancePages/MyTrackAnalyst.aspx')
SET IDENTITY_INSERT TAuth OFF