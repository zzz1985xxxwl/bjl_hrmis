--���ȴӽ�����¼�����¿ͻ���Դ��İ��������Ӫ���������ע�ᡢ���ѽ��ܡ�������������пͻ�

sp_rename   'TCustomer.OrginId','OrginId2','COLUMN'
Alter table TCustomer Add OrginId	UNIQUEIDENTIFIER

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 1 and TGuidParameter.Name = 'İ������'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 2 and TGuidParameter.Name = 'Ӫ���'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 3 and TGuidParameter.Name = '����ע��'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 4 and TGuidParameter.Name = '���ѽ���'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 5 and TGuidParameter.Name = '�������'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 6 and TGuidParameter.Name = '���пͻ�'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId is null and TGuidParameter.Name = 'İ������'

Alter table TCustomer drop column  OrginId2

--���ȴӽ�����¼�����¸��ٷ�ʽ���½��������绰��ϵ�����Űݷá��ʵݲ�Ʒ����Ʒ��ʾ
sp_rename   'TCustomerTrackRecord.TrackModeId','TrackModeId2','COLUMN'
Alter table TCustomerTrackRecord Add TrackModeId	UNIQUEIDENTIFIER

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 1 and TGuidParameter.Name = '�½�����'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 2 and TGuidParameter.Name = '�绰��ϵ'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 3 and TGuidParameter.Name = '���Űݷ�'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 4 and TGuidParameter.Name = '�ʵݲ�Ʒ'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 5 and TGuidParameter.Name = '��Ʒ��ʾ'

Alter table TCustomerTrackRecord drop column  TrackModeId2

/*Ͷ��*/
CREATE TABLE TComplain (
	/*PKID*/
	PKID				INT IDENTITY		NOT NULL,
	/*�ͻ�ID*/
	CustomerID UNIQUEIDENTIFIER	NOT NULL,
	/*Ͷ�����*/
	ComplainType			INT			NOT NULL,
	/*�漰����ID*/
	OrderID				INT			NOT NULL,
	/*Ͷ������*/
	ComplainSubject			NVARCHAR(50)		NOT NULL,
	/*Ͷ������*/
	ComplainContents		NVARCHAR(255)		NOT NULL,
	/*�ύʱ��*/
	SubmitDateTime			DATETIME		NOT NULL,
	/*��������*/
  FeedbackContents			NVARCHAR(255),
  /*����ʱ��*/
  FeedbackDateTime			DATETIME

    CONSTRAINT PK_TComplain PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TComplain UNIQUE NONCLUSTERED (PKID)
) 
GO