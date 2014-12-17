DELETE FROM TACCOUNT
DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH
--DELETE FROM TDepartment
--DELETE FROM TPosition

SET IDENTITY_INSERT TAccount ON
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],DepartmentId,PositionId)
values(-9,'admin','ϵͳ��ʼ�û�','Mc8L3BG3DPZwggWy8zuNSA==',31,1,1)
SET IDENTITY_INSERT TAccount OFF

--SET IDENTITY_INSERT TDepartment ON
--Insert into TDepartment(PKID,DepartmentName,LeaderId,ParentId)
--values(1,'����',-9,0)
--SET IDENTITY_INSERT TDepartment OFF

--SET IDENTITY_INSERT TPosition ON
--Insert into TPosition(PKID,PositionName,PositionDescription)
--values(1,'CEO','')
--SET IDENTITY_INSERT TPosition OFF

--Begin               Ȩ��       -------------
SET IDENTITY_INSERT TAuth ON

--һλ������λ���ֱ�ʾһ��Ŀ¼
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'�û�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'��֯�ܹ�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'�������',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'��˾Ŀ�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'��ҵ�Ļ�',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'��ֵ����',0,'')

--1 �û�����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'�����û�',1,'../EmployeePages/CreateEmployee.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'��ѯ�û�',1,'../EmployeePages/EmployeeManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (103,'����Ȩ��',1,'../AuthPages/AssignAuth.aspx')

--2 ��֯�ṹ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'��֯�ܹ�����',2,'../DepartmentPages/DepartmentManagement.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'ְλ����',2,'../PositionPages/PositionManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (203,'ְλ�ȼ�����',2,'../PositionPages/PositionGradeManage.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (204,'��λ���ʹ���',2,'../PositionPages/PositionNatureManage.aspx')
--3 �������
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'��������',3,'../BulletinPages/BulletinAdd.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (302,'��ѯ����',3,'../BulletinPages/BulletinListBack.aspx')


--4 ��˾Ŀ�����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'������˾Ŀ��',4,'../GoalPages/GoalCompanyAdd.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'��ѯ��˾Ŀ��',4,'../GoalPages/GoalCompanyList.aspx')

--5 ��ҵ�Ļ�
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'���ù�˾����',5,'../CompanyRegulationsPages/EditCompanyRegulation.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (502,'�����Զ���������',5,'../WelcomeMailPages/EditWelcomeMail.aspx')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (503,'��������ʱ��',5,'../SpecialDatePages/SetSpecialDate.aspx')

--6 ��ֵ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'�鿴��������',6,'../ServicesPages/SmsCenter.aspx')

SET IDENTITY_INSERT TAuth OFF
--End                 Ȩ��       -------------

--begin �����˺�Admin��Ȩ��  -------------
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	1)--	�û�����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	2)--	��֯�ṹ����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	3)--	�������
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	4)--	��˾Ŀ�����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	5)--	��ҵ�Ļ�
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	6)--	��ֵ����

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	101)--	�����û�
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	102)--	��ѯ�û�
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	103)--	����Ȩ��

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	201)--	��֯�ܹ�����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	202)--	ְλ����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (-9,	203)--	ְλ�ȼ�����

--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	301)--	��������
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	302)--	��ѯ����
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	401)--	������˾Ŀ��
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	402)--	��ѯ��˾Ŀ��
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	501)--	���ù�˾����
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	502)--	���û�ӭ��
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	503)--	��������ʱ��
--
--INSERT INTO TAccountAuth (AccountID,AuthID)		
--VALUES (-9,	601)--	�鿴��������
--end   �����˺�Admin��Ȩ��  -------------