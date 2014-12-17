--首先从界面上录入以下客户来源：陌生开发、营销活动、网上注册、朋友介绍、广告宣传、已有客户

sp_rename   'TCustomer.OrginId','OrginId2','COLUMN'
Alter table TCustomer Add OrginId	UNIQUEIDENTIFIER

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 1 and TGuidParameter.Name = '陌生开发'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 2 and TGuidParameter.Name = '营销活动'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 3 and TGuidParameter.Name = '网上注册'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 4 and TGuidParameter.Name = '朋友介绍'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 5 and TGuidParameter.Name = '广告宣传'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId2 = 6 and TGuidParameter.Name = '已有客户'

update TCustomer set OrginId = TGuidParameter.ID from TGuidParameter
where OrginId is null and TGuidParameter.Name = '陌生开发'

Alter table TCustomer drop column  OrginId2

--首先从界面上录入以下跟踪方式：新进待跟、电话联系、登门拜访、邮递产品、产品演示
sp_rename   'TCustomerTrackRecord.TrackModeId','TrackModeId2','COLUMN'
Alter table TCustomerTrackRecord Add TrackModeId	UNIQUEIDENTIFIER

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 1 and TGuidParameter.Name = '新进待跟'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 2 and TGuidParameter.Name = '电话联系'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 3 and TGuidParameter.Name = '登门拜访'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 4 and TGuidParameter.Name = '邮递产品'

update TCustomerTrackRecord set TrackModeId = TGuidParameter.ID from TGuidParameter
where TrackModeId2 = 5 and TGuidParameter.Name = '产品演示'

Alter table TCustomerTrackRecord drop column  TrackModeId2

/*投诉*/
CREATE TABLE TComplain (
	/*PKID*/
	PKID				INT IDENTITY		NOT NULL,
	/*客户ID*/
	CustomerID UNIQUEIDENTIFIER	NOT NULL,
	/*投诉类别*/
	ComplainType			INT			NOT NULL,
	/*涉及订单ID*/
	OrderID				INT			NOT NULL,
	/*投诉主题*/
	ComplainSubject			NVARCHAR(50)		NOT NULL,
	/*投诉内容*/
	ComplainContents		NVARCHAR(255)		NOT NULL,
	/*提交时间*/
	SubmitDateTime			DATETIME		NOT NULL,
	/*反馈内容*/
  FeedbackContents			NVARCHAR(255),
  /*反馈时间*/
  FeedbackDateTime			DATETIME

    CONSTRAINT PK_TComplain PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TComplain UNIQUE NONCLUSTERED (PKID)
) 
GO