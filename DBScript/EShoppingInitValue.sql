DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH


--Begin               Ȩ��       -------------
SET IDENTITY_INSERT TAuth ON

--һλ������λ���ֱ�ʾһ��Ŀ¼
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (1,'����ģ��',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (2,'���ģ��',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (3,'����ģ��',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (4,'��Ʒģ��',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (5,'Ȩ�޹���',0,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (6,'ϵͳ��Ϣ����',0,'',0)


--1 ����ģ��
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (101,'�ͻ��ʻ�����',1,'../CustomerAccount/CustomerAccountList.aspx',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (102,'�ͻ��˻��ȼ�����',1,'../CustomerAccountLevel/CustomerAccountLevelList.aspx',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (103,'���۶�������',1,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (104,'���׹���',1,'',0)

--2 ���ģ��
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (201,'�ֿ����',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (202,'��������',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (203,'�������',2,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (204,'��������',2,'',0)

--3 ����ģ��
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (301,'��Ӧ�̹���',3,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (302,'�ɹ���������',3,'',0)

--4 ��Ʒģ��
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (401,'�������',4,'',0)
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (402,'��Ʒ����',4,'',0)


--5 Ȩ�޹���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl,IfHasDepartment)
VALUES (501,'����Ȩ��',5,'../Auths/AssignEShoppingAuthPage.aspx',0)


--6 ϵͳ��Ϣ����


SET IDENTITY_INSERT TAuth OFF
--End                 Ȩ��       -------------

--begin �����˺�Admin������Ȩ��  -------------
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	1,0)--	����ģ��
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	2,0)--	���ģ��
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	3,0)--	����ģ��
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	4,0)--	��Ʒģ��
INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
VALUES (-9,	5,0)--	Ȩ�޹���
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	6,0)--	ϵͳ��Ϣ����

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	101,0)--	�ͻ��ʻ�����
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	102,0)--	�ͻ��˻��ȼ�����
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	103,0)--	���۶�������
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	104,0)--	���׹���

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	201,0)--	�ֿ����
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	202,0)--	��������
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	203,0)--	�������
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	204,0)--	��������

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	301,0)--	��Ӧ�̹���
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	302,0)--	�ɹ���������

--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	401,0)--	�������
--INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
--VALUES (-9,	402,0)--	��Ʒ����		


INSERT INTO TAccountAuth (AccountID,AuthID,DepartmentID)		
VALUES (-9,	501,0)--	����Ȩ��

--end   �����˺�Admin������Ȩ��  -------------