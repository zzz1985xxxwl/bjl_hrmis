DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH


--Begin               Ȩ��       -------------
SET IDENTITY_INSERT TAuth ON

--һλ������λ���ֱ�ʾһ��Ŀ¼
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'���۹���',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'�ҵ�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'�ۺ����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'�Ŷӹ���',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'��Ʒ����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'ϵͳ��Ϣ����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (7,'Ȩ�޹���',0,'')

--1 ���۹���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'�ҵ��̻�',1,'../OpportunityPages/SearchMyOpportunity.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'�ҵĿͻ�',1,'../CustomerPages/MyCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (103,'�ҵĶ���',1,'../OrderPages/SearchMyOrder.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (104,'�ҵ���ϵ��',1,'../ContactPages/ContactList.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (105,'�ͻ���',1,'../TeamPages/CustomerPool.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (106,'�ͻ���',1,'../CustomerPages/CustomerForAll.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (107,'��Ʒ��',1,'../ProductPages/ProductForAll.aspx')

--2 �ճ̰���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'�ҵ��ճ�',2,'../AssistancePages/CalendarEventList.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'�ҵ�����',2,'../AssistancePages/MyRemind.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (203,'��������',2,'../AssistancePages/TrackCurve.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (204,'�ҵ��ճ�ͳ��',2,'../AssistancePages/CalendarAnalyst.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (205,'�ҵĸ���ͳ��',2,'../AssistancePages/MyTrackAnalyst.aspx')

--3 �ۺ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'Ͷ�߷���',3,'../AfterServicePages/ComplainList.aspx')
--INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
--VALUES (302,'��ѯ����',3,'../BulletinPages/BulletinListBack.aspx')

--4 �Ŷӹ���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'����ͻ���Դ',4,'../TeamPages/AssignCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'�����ͻ�',4,'../TeamPages/ExportCustomer.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (403,'��Ա�ճ�����',4,'../TeamPages/SingleEmployeeTeamStat.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (404,'��Ա�ճ̶Ա�',4,'../TeamPages/EmployeesStatsInfo.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (405,'�����ճ̶Ա�',4,'../TeamPages/DepartmentStatisticsIndex.aspx')


--5 ��Ʒ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'���ò�Ʒ',5,'../ProductPages/ProductSearch.aspx')


--6 ϵͳ��Ϣ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'���ÿͻ�״̬',6,'../ParameterPages/CustomerLevel.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (602,'�������۽׶�',6,'../ParameterPages/SalesStage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (603,'���ò�Ʒ����',6,'../ParameterPages/ProductFirstType.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (604,'���ÿͻ���Դ',6,'../ParameterPages/Orgin.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (605,'������ϵ��ʽ',6,'../ParameterPages/Orgin.aspx')

--7 Ȩ�޹���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (701,'����Ȩ��',7,'../ParameterPages/AssignCrmAuthPage.aspx')


SET IDENTITY_INSERT TAuth OFF
--End                 Ȩ��       -------------

--begin �����˺�Admin������Ȩ��  -------------
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	1)--	���۹���
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	2)--	�ճ̰���
----INSERT INTO TAccountAuth (AccountID,AuthID)		
----VALUES (-9,	3)--	�ۺ����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	4)--	�Ŷӹ���
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	5)--	��Ʒ����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	6)--	ϵͳ��Ϣ����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	7)--	Ȩ�޹���

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	101)--	�ҵ��̻�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	102)--	�ҵĿͻ�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	103)--	�ҵĶ���
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	104)--	�ҵ���ϵ��
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	105)--	�ͻ���
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	106)--	�ͻ���
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	107)--	��Ʒ��
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	201)--	�ҵ��ճ�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	202)--	�ҵ�����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	203)--	��������
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	204)--	�ճ̷���

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	301)--	��������
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	302)--	��ѯ����

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	401)--	����ͻ���Դ
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	402)--	�����ͻ�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	403)--	��Ա�ճ�����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	404)--	��Ա�ճ̶Ա�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	405)--	�����ճ̶Ա�
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	501)--	���ò�Ʒ
--
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	601)--	���ÿͻ�״̬
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	602)--	�����̻��׶�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	603)--	���ò�Ʒ����

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	701)--	����Ȩ��
--end   �����˺�Admin������Ȩ��  -------------