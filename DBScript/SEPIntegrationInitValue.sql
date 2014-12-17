DELETE FROM TACCOUNT
DELETE FROM TAUTH
DELETE FROM TACCOUNTAUTH
DELETE FROM dbo.TDepartment
DELETE FROM dbo.TPosition
DELETE FROM dbo.TPositionGrade

SET IDENTITY_INSERT TAccount ON
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType])
values(1,'admin','����Ա','Mc8L3BG3DPZwggWy8zuNSA==',15)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(2,'chencheng','�³�','Mc8L3BG3DPZwggWy8zuNSA==',15,'chencheng@shixintech.com','','13902453659',1,1)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(3,'yangliqun','����Ⱥ','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangliqun@shixintech.com','','13902453658',2,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(4,'wanglei','����','Mc8L3BG3DPZwggWy8zuNSA==',15,'wanglei@shixintech.com','','13902453650',3,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(5,'��kun','����','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangkun@shixintech.com','','13902453651',4,2)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(6,'yuyang','����','Mc8L3BG3DPZwggWy8zuNSA==',15,'yuyang@shixintech.com','','13902453656',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(7,'liqi','����','Mc8L3BG3DPZwggWy8zuNSA==',15,'liqi@shixintech.com','','13902453653',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(8,'jinfan','��','Mc8L3BG3DPZwggWy8zuNSA==',15,'jinfan@shixintech.com','','13902453657',4,4)
Insert into TAccount(PKID,LoginName,EmployeeName,[Password],[AccountType],Email1,Email2,[MobileNum],DepartmentID,PositionID)
values(9,'yangyubin','�����','Mc8L3BG3DPZwggWy8zuNSA==',15,'yangyubing@shixintech.com','','13902453650',3,3)
SET IDENTITY_INSERT TAccount OFF

--Begin               Ȩ��       -------------
SET IDENTITY_INSERT TAuth ON

--һλ������λ���ֱ�ʾһ��Ŀ¼
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (1,'�û�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (2,'Ա������',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (3,'���Ź���',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (4,'ְλ����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (5,'�������',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (6,'Ŀ�����',0,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (7,'��ҵ�Ļ�',0,'')

--1 �û�����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (101,'�ʺ�ά��',1,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (102,'����Ȩ��',1,'')

--2 Ա������
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (201,'Ա��ά��',2,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (202,'��ѯԱ��',2,'')

--3 ���Ź���
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (301,'����ά��',3,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (302,'��ѯ����',3,'')

--4 ְλ����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (401,'ְλά��',4,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (402,'��ѯְλ',4,'')

--5 �������
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (501,'����ά��',5,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (502,'��ѯ����',5,'')

--6 ��˾Ŀ�����
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (601,'��˾Ŀ��ά��',6,'')
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (602,'��ѯ��˾Ŀ��',6,'')

--7 ��ҵ�Ļ�
INSERT INTO TAuth (PKID,[AuthName],[AuthParentID],NavigateUrl)
VALUES (701,'��˾����ά��',7,'')

SET IDENTITY_INSERT TAuth OFF
--End                 Ȩ��       -------------

--begin �����˺�Admin������Ȩ��  -------------
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	1)--	�û�����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	2)--	Ա������
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	3)--	���Ź���
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	4)--	ְλ����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	5)--	�������
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	6)--	Ŀ�����
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	7)--	��ҵ�Ļ�

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	101)--	�ʺ�ά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	102)--	����Ȩ��

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	201)--	Ա��ά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	202)--	��ѯԱ��

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	301)--	����ά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	302)--	��ѯ����

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	401)--	ְλά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	402)--	��ѯְλ

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	501)--	����ά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	502)--	��ѯ����

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	601)--	��˾Ŀ��ά��
INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	602)--	��ѯ��˾Ŀ��

INSERT INTO TAccountAuth (AccountID,AuthID)		
VALUES (1,	701)--	��˾����ά��
--end   �����˺�Admin������Ȩ��  -------------

SET IDENTITY_INSERT TDepartment ON
--һλ���ֱ�ʾһ������
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)--�˲�����TDepartment���Ǹ����
VALUES (1,'�Ϻ�ʵ����ҵ�����˾',2,0)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (2,'������Դ��',3,1)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (3,'������',4,1)
INSERT INTO TDepartment (PKID,[DepartmentName],LeaderID,ParentID)
VALUES (4,'���۲�',5,1)


SET IDENTITY_INSERT TDepartment OFF



SET IDENTITY_INSERT TPositionGrade ON
--TypeΪ1����ʾְλ��PKID��100��ʼ
INSERT INTO TPositionGrade(PKID,[PositionGradeName],[PositionGradeDescription],[Sequence])
VALUES (1,'A','A',0)
SET IDENTITY_INSERT TPositionGrade OFF



SET IDENTITY_INSERT TPosition ON
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (1,'CEO',1,'CEO')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (2,'����',1,'��������')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (3,'����Ա',1,'��������Ա')
INSERT INTO TPosition (PKID,[PositionName],[LevelId],[PositionDescription])
VALUES (4,'����',1,'������Ա')
SET IDENTITY_INSERT TPosition OFF

