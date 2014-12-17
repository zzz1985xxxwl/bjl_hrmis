if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContactInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ContactInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContactUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ContactUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContactsByContactId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetContactsByContactId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CustomerInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CustomerUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GuidParameterInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GuidParameterInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetProductByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetProductById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductFirstTypeInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductFirstTypeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductFirstTypeUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductFirstTypeUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductFirstTypeDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductFirstTypeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductSecondTypeDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductSecondTypeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductSecondTypeInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ProductSecondTypeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllFirstType]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetAllFirstType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFirstTypeById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetFirstTypeById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSencondTypeByFirstTypeId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetSencondTypeByFirstTypeId]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GuidParameterUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GuidParameterUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContactsByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetContactsByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContactByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetContactByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerByFullName]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerByFullName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImportantTrackRecordInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[ImportantTrackRecordInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteImportantTrackRecordsByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteImportantTrackRecordsByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerTrackRecordInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CustomerTrackRecordInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerTrackRecordsByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteCustomerTrackRecordsByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerOwnerHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CustomerOwnerHistoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerOwnerHistorysByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteCustomerOwnerHistorysByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetGuidParameterById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetGuidParameterById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetGuidParameterByTypeId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetGuidParameterByTypeId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetImportantTrackRecordsByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetImportantTrackRecordsByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerTrackRecordsByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerTrackRecordsByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerOwnerHistorysByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerOwnerHistorysByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteGuidParameterById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteGuidParameterById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteContactById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteContactById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteCustomerById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OpportunityInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[OpportunityInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IntentProductListInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[IntentProductListInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OpportunityUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[OpportunityUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOpportunitysByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOpportunitysByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOpportunitysById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOpportunitysById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOpportunityByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOpportunityByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteProductForByOpportunityId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteProductForByOpportunityId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetInsertProductByOpportunityId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetInsertProductByOpportunityId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].DeleteOpportunityById') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].DeleteOpportunityById
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OrderInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[OrderInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OrderUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[OrderUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOrderById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrdersByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOrdersByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOrderByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OrderProductInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[OrderProductInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderProductByOrderId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOrderProductByOrderId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOrderProductByOrderId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteOrderProductByOrderId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOrderById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteOrderById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOrderByOrderNubmer]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetOrderByOrderNubmer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrackCurveTemplateInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[TrackCurveTemplateInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrackCurveTemplateUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[TrackCurveTemplateUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrackCurveTemplateDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[TrackCurveTemplateDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrackCurveTemplateById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetTrackCurveTemplateById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetMyTrackCurveTemplate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetMyTrackCurveTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CalendarEventInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CalendarEventInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CalendarEventUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CalendarEventUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CalendarEventDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CalendarEventDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCalendarEventById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCalendarEventById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCalendarEventByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCalendarEventByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCalendarEventByTrackCurveId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCalendarEventByTrackCurveId]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemindInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[RemindInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemindUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[RemindUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemindDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[RemindDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetRemindById]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetRemindById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetRemindsByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetRemindsByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerTrackCurveInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CustomerTrackCurveInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerTrackCurveByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteCustomerTrackCurveByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerTrackCurveByCustomerId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerTrackCurveByCustomerId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetRemindByCalendarEventId]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetRemindByCalendarEventId]
GO
/****** 对象:  StoredProcedure [dbo].[GetAllAuth]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllAuth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllAuth]
GO

/****** 对象:  StoredProcedure [dbo].[GetAccountAuth]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccountAuth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAccountAuth]
GO

/****** 对象:  StoredProcedure [dbo].[SetAccountAuth]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SetAccountAuth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SetAccountAuth]
GO

/****** 对象:  StoredProcedure [dbo].[CancelAccountAllAuth]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CancelAccountAllAuth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CancelAccountAllAuth]
GO

--Begin              投诉        ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertComplain]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[InsertComplain]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateComplain]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[UpdateComplain]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteComplainByID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteComplainByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetComplainByPKID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetComplainByPKID]
GO

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteFeedbackByComplainID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
--drop procedure [dbo].[DeleteFeedbackByComplainID]
--GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetComplainListByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetComplainListByCustomerID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNoFeedbackComplainList]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetNoFeedbackComplainList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllFeedbackComplainByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetAllFeedbackComplainByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIsFeedbackComplainByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetIsFeedbackComplainByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNoFeedbackComplainByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetNoFeedbackComplainByCondition]
GO

--End		     投诉        ------------

--Begin              反馈        ------------

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertFeedback]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
--drop procedure [dbo].[InsertFeedback]
--GO

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateFeedback]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
--drop procedure [dbo].[UpdateFeedback]
--GO

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteFeedbackByPkid]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
--drop procedure [dbo].[DeleteFeedbackByPkid]
--GO

--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFeedbackByComplainID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
--drop procedure [dbo].[GetFeedbackByComplainID]
--GO

--End		     反馈        ------------

/***********************************************************************************
**                                                                                **
**                               创建存储过程                                     **
**                                                                                **
***********************************************************************************/

/***********************************************************************************/
/************         Begin   联系人       ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ContactInsert
(
	@ID					UNIQUEIDENTIFIER	,
    @FirstName			NVARCHAR(50)		,
	@LastName			NVARCHAR(50)		,
	@FullName			NVARCHAR(50)		,
	@MainContactPhone   NVARCHAR(50)		,
	@BirthDay			DATETIME			,
	@Qq					NVARCHAR(50)		,
	@Msn				NVARCHAR(50)		,
	@Like				NVARCHAR(2000)		,
	@Email				NVARCHAR(50)		,
	@HomePage			NVARCHAR(200)		,
	@Duty				NVARCHAR(50)		,
	@CompanyName		NVARCHAR(200)		,
	@Department			NVARCHAR(50)		,
	@OfficeLocation		NVARCHAR(200)		,
	@WorkPhone			NVARCHAR(50)		,
	@WorkFax			NVARCHAR(50)		,
	@HomePhone			NVARCHAR(50)		,
	@MobilePhone		NVARCHAR(50)		,
	@HomeFax			NVARCHAR(50)		,
	@Remark				NVARCHAR(2000)		,
	@AreaId				INT					,
	@ProvinceId			INT					,
	@CityId				INT					,
	@Postalcode			NVARCHAR(50)		,
	@Address			NVARCHAR(200)		,	
	@CustomerId			UNIQUEIDENTIFIER	,
	@CreaterId			INT					,
	@CreateTime			DATETIME				
)
AS
BEGIN
    INSERT INTO TContact(
	ID							,
    FirstName					,
	LastName					,
	FullName					,
	MainContactPhone   			,
	BirthDay					,
	Qq							,
	Msn							,
	[Like]						,
	Email						,
	HomePage					,
	Duty						,
	CompanyName					,
	Department					,
	OfficeLocation				,
	WorkPhone					,
	WorkFax						,
	HomePhone					,
	MobilePhone					,
	HomeFax						,
	Remark						,
	AreaId						,
	ProvinceId					,
	CityId						,
	Postalcode					,
	Address						,	
	CustomerId					,
	CreaterId					,
	CreateTime					,
	TimeStamper					
	)
    VALUES (
	@ID							,
    @FirstName					,
	@LastName					,
	@FullName					,
	@MainContactPhone   		,
	@BirthDay					,
	@Qq							,
	@Msn						,
	@Like						,
	@Email						,
	@HomePage					,
	@Duty						,
	@CompanyName				,
	@Department					,
	@OfficeLocation				,
	@WorkPhone					,
	@WorkFax					,
	@HomePhone					,
	@MobilePhone				,
	@HomeFax					,
	@Remark						,
	@AreaId						,
	@ProvinceId					,
	@CityId						,
	@Postalcode					,
	@Address					,	
	@CustomerId					,
	@CreaterId					,
	@CreateTime					,
	GETDATE()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ContactUpdate
(
	@ID					UNIQUEIDENTIFIER	,
    @FirstName			NVARCHAR(50)		,
	@LastName			NVARCHAR(50)		,
	@FullName			NVARCHAR(50)		,
	@MainContactPhone   NVARCHAR(50)		,
	@BirthDay			DATETIME			,
	@Qq					NVARCHAR(50)		,
	@Msn				NVARCHAR(50)		,
	@Like				NVARCHAR(2000)		,
	@Email				NVARCHAR(50)		,
	@HomePage			NVARCHAR(200)		,
	@Duty				NVARCHAR(50)		,
	@CompanyName		NVARCHAR(200)		,
	@Department			NVARCHAR(50)		,
	@OfficeLocation		NVARCHAR(200)		,
	@WorkPhone			NVARCHAR(50)		,
	@WorkFax			NVARCHAR(50)		,
	@HomePhone			NVARCHAR(50)		,
	@MobilePhone		NVARCHAR(50)		,
	@HomeFax			NVARCHAR(50)		,
	@Remark				NVARCHAR(2000)		,
	@AreaId				INT					,
	@ProvinceId			INT					,
	@CityId				INT					,
	@Postalcode			NVARCHAR(50)		,
	@Address			NVARCHAR(200)		,	
	@CustomerId			UNIQUEIDENTIFIER	,
	@CreaterId			INT					,
	@CreateTime			DATETIME				
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TContact SET
	ID=@ID,
    FirstName=@FirstName				,
	LastName=@LastName					,
	FullName=@FullName					,
	MainContactPhone=@MainContactPhone	,
	BirthDay=@BirthDay					,
	Qq=@Qq								,
	Msn=@Msn							,
	[Like]=@Like						,
	Email=@Email						,
	HomePage=@HomePage					,
	Duty=@Duty							,
	CompanyName=@CompanyName			,
	Department=@Department				,
	OfficeLocation=@OfficeLocation		,
	WorkPhone=@WorkPhone				,
	WorkFax=@WorkFax					,
	HomePhone=@HomePhone				,
	MobilePhone=@MobilePhone			,
	HomeFax=@HomeFax					,
	Remark=@Remark						,
	AreaId=@AreaId						,
	ProvinceId=@ProvinceId				,
	CityId=@CityId						,
	Postalcode=@Postalcode				,
	Address=@Address					,	
	CustomerId=@CustomerId				,
	CreaterId=@CreaterId				,
	CreateTime=@CreateTime				
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteContactById
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE FROM TContact			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetContactsByContactId
(
	     @ID		UNIQUEIDENTIFIER 
)
AS
BEGIN
        SELECT 
		--TContact
		TContact.ID							as Contact_ID							,
		TContact.FirstName					as Contact_FirstName					,
		TContact.LastName					as Contact_LastName						,
		TContact.FullName					as Contact_FullName						,
		TContact.MainContactPhone			as Contact_MainContactPhone  			,
		TContact.BirthDay					as Contact_BirthDay						,
		TContact.Qq							as Contact_Qq							,
		TContact.Msn						as Contact_Msn							,
		TContact.[Like]						as Contact_Like							,
		TContact.Email						as Contact_Email						,
		TContact.HomePage					as Contact_HomePage						,
		TContact.Duty						as Contact_Duty							,
		TContact.CompanyName				as Contact_CompanyName					,
		TContact.Department					as Contact_Department					,
		TContact.OfficeLocation				as Contact_OfficeLocation				,
		TContact.WorkPhone					as Contact_WorkPhone					,
		TContact.WorkFax					as Contact_WorkFax						,
		TContact.HomePhone					as Contact_HomePhone					,
		TContact.MobilePhone				as Contact_MobilePhone					,
		TContact.HomeFax					as Contact_HomeFax						,
		TContact.Remark						as Contact_Remark						,
		TContact.AreaId						as Contact_AreaId						,
		TContact.ProvinceId					as Contact_ProvinceId					,
		TContact.CityId						as Contact_CityId						,
		TContact.Postalcode					as Contact_Postalcode					,
		TContact.Address					as Contact_Address						,	
		TContact.CustomerId					as Contact_CustomerId					,
		TContact.CreaterId					as Contact_CreaterId					,
		TContact.CreateTime					as Contact_CreateTime					,				
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime				
	
		FROM  TContact,TCustomer
		WHERE TContact.CustomerId = TCustomer.ID
		  and TContact.ID = @ID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetContactsByCustomerId
(
	     @CustomerId		UNIQUEIDENTIFIER 
)
AS
BEGIN
        SELECT 
		--TContact
		TContact.ID							as Contact_ID							,
		TContact.FirstName					as Contact_FirstName					,
		TContact.LastName					as Contact_LastName						,
		TContact.FullName					as Contact_FullName						,
		TContact.MainContactPhone			as Contact_MainContactPhone  			,
		TContact.BirthDay					as Contact_BirthDay						,
		TContact.Qq							as Contact_Qq							,
		TContact.Msn						as Contact_Msn							,
		TContact.[Like]						as Contact_Like							,
		TContact.Email						as Contact_Email						,
		TContact.HomePage					as Contact_HomePage						,
		TContact.Duty						as Contact_Duty							,
		TContact.CompanyName				as Contact_CompanyName					,
		TContact.Department					as Contact_Department					,
		TContact.OfficeLocation				as Contact_OfficeLocation				,
		TContact.WorkPhone					as Contact_WorkPhone					,
		TContact.WorkFax					as Contact_WorkFax						,
		TContact.HomePhone					as Contact_HomePhone					,
		TContact.MobilePhone				as Contact_MobilePhone					,
		TContact.HomeFax					as Contact_HomeFax						,
		TContact.Remark						as Contact_Remark						,
		TContact.AreaId						as Contact_AreaId						,
		TContact.ProvinceId					as Contact_ProvinceId					,
		TContact.CityId						as Contact_CityId						,
		TContact.Postalcode					as Contact_Postalcode					,
		TContact.Address					as Contact_Address						,	
		TContact.CustomerId					as Contact_CustomerId					,
		TContact.CreaterId					as Contact_CreaterId					,
		TContact.CreateTime					as Contact_CreateTime					,				
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					
		FROM  TContact,TCustomer
		WHERE TContact.CustomerId = TCustomer.ID
		  and TCustomer.ID = @CustomerID
		ORDER BY TContact.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetContactByCondition
(
		@FullName			NVARCHAR(50) = null,
		@CustomerFullName	NVARCHAR(50) = null,
		@MainContactPhone	NVARCHAR(50) = null,
		@MobilePhone		NVARCHAR(50) = null
)
AS
BEGIN
        SELECT 
		--TContact
		TContact.ID							as Contact_ID							,
		TContact.FirstName					as Contact_FirstName					,
		TContact.LastName					as Contact_LastName						,
		TContact.FullName					as Contact_FullName						,
		TContact.MainContactPhone			as Contact_MainContactPhone  			,
		TContact.BirthDay					as Contact_BirthDay						,
		TContact.Qq							as Contact_Qq							,
		TContact.Msn						as Contact_Msn							,
		TContact.[Like]						as Contact_Like							,
		TContact.Email						as Contact_Email						,
		TContact.HomePage					as Contact_HomePage						,
		TContact.Duty						as Contact_Duty							,
		TContact.CompanyName				as Contact_CompanyName					,
		TContact.Department					as Contact_Department					,
		TContact.OfficeLocation				as Contact_OfficeLocation				,
		TContact.WorkPhone					as Contact_WorkPhone					,
		TContact.WorkFax					as Contact_WorkFax						,
		TContact.HomePhone					as Contact_HomePhone					,
		TContact.MobilePhone				as Contact_MobilePhone					,
		TContact.HomeFax					as Contact_HomeFax						,
		TContact.Remark						as Contact_Remark						,
		TContact.AreaId						as Contact_AreaId						,
		TContact.ProvinceId					as Contact_ProvinceId					,
		TContact.CityId						as Contact_CityId						,
		TContact.Postalcode					as Contact_Postalcode					,
		TContact.Address					as Contact_Address						,	
		TContact.CustomerId					as Contact_CustomerId					,
		TContact.CreaterId					as Contact_CreaterId					,
		TContact.CreateTime					as Contact_CreateTime					,				
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime							
		FROM  TContact,TCustomer
		WHERE TContact.CustomerId = TCustomer.ID
			AND (@FullName IS NULL OR TContact.FullName LIKE '%'+@FullName+'%')
			AND (@CustomerFullName IS NULL OR TCustomer.FullName LIKE '%'+@CustomerFullName+'%')
			AND (@MainContactPhone IS NULL OR TContact.MainContactPhone LIKE '%'+@MainContactPhone + '%')
			AND (@MobilePhone IS NULL OR TContact.MobilePhone LIKE '%'+ @MobilePhone + '%')
		ORDER BY TContact.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End   联系人       ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   客户       ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerInsert
(
	@ID							UNIQUEIDENTIFIER	,
	@FullName					NVARCHAR(50)		,
	@ShortName					NVARCHAR(50)		,
	@IndustryId					INT					,
	@OrginId					UNIQUEIDENTIFIER	,
	@SizeId						INT					,
	@OwnedTypeId				INT					,
	@Phone						NVARCHAR(50)		,
	@Fax						NVARCHAR(50)		,
	@Email						NVARCHAR(50)		,
	@InternetAddress			NVARCHAR(200)		,
	@CustomerPrincipal			NVARCHAR(50)		,
	@Remark						NVARCHAR(2000)		,
	@OwnerStatusId				INT					,
	@PrincipalId				INT					,
	@SharesId					NVARCHAR(50)		,
	@CustomerRelationLevelId	UNIQUEIDENTIFIER	,
	@AreaId						INT					,
	@ProvinceId					INT					,
	@CityId						INT					,
	@Postalcode					NVARCHAR(50)		,
	@Address					NVARCHAR(200)		,
	@CreaterId					INT					,
	@CreateTime					DATETIME				
)
AS
BEGIN
    INSERT INTO TCustomer(
	ID									,
	FullName							,
	ShortName							,
	IndustryId							,
	OrginId								,
	SizeId								,
	OwnedTypeId							,
	Phone								,
	Fax									,
	Email								,
	InternetAddress						,
	CustomerPrincipal					,
	Remark								,
	OwnerStatusId						,
	PrincipalId							,
	SharesId							,
	CustomerRelationLevelId				,
	AreaId								,
	ProvinceId							,
	CityId								,
	Postalcode							,
	Address								,
	CreaterId							,
	CreateTime							,
	TimeStamper					
	)
    VALUES (
	@ID									,
	@FullName							,
	@ShortName							,
	@IndustryId							,
	@OrginId							,
	@SizeId								,
	@OwnedTypeId						,
	@Phone								,
	@Fax								,
	@Email								,
	@internetAddress					,
	@CustomerPrincipal					,
	@Remark								,
	@OwnerStatusId						,
	@PrincipalId						,
	@SharesId							,
	@CustomerRelationLevelId			,
	@AreaId								,
	@ProvinceId							,
	@CityId								,
	@Postalcode							,
	@Address							,
	@CreaterId							,
	@CreateTime							,
	GETDATE()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerUpdate
(
	@ID							UNIQUEIDENTIFIER	,
	@FullName					NVARCHAR(50)		,
	@ShortName					NVARCHAR(50)		,
	@IndustryId					INT					,
	@OrginId					UNIQUEIDENTIFIER	,
	@SizeId						INT					,
	@OwnedTypeId				INT					,
	@Phone						NVARCHAR(50)		,
	@Fax						NVARCHAR(50)		,
	@Email						NVARCHAR(50)		,
	@InternetAddress			NVARCHAR(200)		,
	@CustomerPrincipal			NVARCHAR(50)		,
	@Remark						NVARCHAR(2000)		,
	@OwnerStatusId				INT					,
	@PrincipalId				INT					,
	@SharesId					NVARCHAR(50)		,
	@CustomerRelationLevelId	UNIQUEIDENTIFIER	,
	@AreaId						INT					,
	@ProvinceId					INT					,
	@CityId						INT					,
	@Postalcode					NVARCHAR(50)		,
	@Address					NVARCHAR(200)		,
	@CreaterId					INT					,
	@CreateTime					DATETIME					
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TCustomer SET
	FullName=@FullName									,
	ShortName=@ShortName								,
	IndustryId=@IndustryId								,
	OrginId=@OrginId									,
	SizeId=@SizeId										,
	OwnedTypeId=@OwnedTypeId							,
	Phone=@Phone										,
	Fax=@Fax											,
	Email=@Email										,
	internetAddress=@internetAddress					,
	CustomerPrincipal=@CustomerPrincipal				,
	Remark=@Remark										,
	OwnerStatusId=@OwnerStatusId						,
	PrincipalId=@PrincipalId							,
	SharesId=@SharesId									,
	CustomerRelationLevelId=@CustomerRelationLevelId	,
	AreaId=@AreaId										,
	ProvinceId=@ProvinceId								,
	CityId=@CityId										,
	Postalcode=@Postalcode								,
	Address=@Address									,
	CreaterId=@CreaterId								,
	CreateTime=@CreateTime							
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerById
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE FROM TCustomer			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerById
(
	     @ID	UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
        SELECT 			
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					,
		--TGuidParameter CustomerRelationLevelId
		TGuidParameter.ID					as GuidParameter_ID						,
		TGuidParameter.[Name]				as GuidParameter_Name					,
		TGuidParameter.Description			as GuidParameter_Description			,
		TGuidParameter.TypeId				as GuidParameter_TypeId					
		FROM  TCustomer,TGuidParameter
		WHERE TCustomer.CustomerRelationLevelId = TGuidParameter.ID
		AND (@ID IS NULL OR TCustomer.ID = @ID)
		ORDER BY TCustomer.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerByFullName
(
	     @FullName	NVarchar(50)
)
AS
BEGIN
        SELECT 			
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime							
		FROM  TCustomer
		WHERE TCustomer.FullName = @FullName
		ORDER BY TCustomer.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerByCondition
(
		@FullName					NVARCHAR(50)		= NULL,
		@ShortName					NVARCHAR(50)		= NULL,
		@Phone						NVARCHAR(50)		= NULL,
		@IndustryId					INT					= NULL,
		@CustomerRelationLevelId	UNIQUEIDENTIFIER	= NULL,
	    @OrginId					UNIQUEIDENTIFIER	= NULL
)
AS
BEGIN
        SELECT 			
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					,
		--TGuidParameter
		TGuidParameter.ID					as GuidParameter_ID						,
		TGuidParameter.[Name]				as GuidParameter_Name					,
		TGuidParameter.Description			as GuidParameter_Description			,
		TGuidParameter.TypeId				as GuidParameter_TypeId					
		FROM  TCustomer,TGuidParameter
		WHERE TCustomer.CustomerRelationLevelId = TGuidParameter.ID
		AND (@FullName IS NULL OR TCustomer.FullName LIKE '%' +@FullName + '%')
		AND (@ShortName IS NULL OR TCustomer.ShortName LIKE '%'+@ShortName+'%')
		AND (@Phone IS NULL OR TCustomer.Phone LIKE '%'+@Phone+'%')
		AND (@IndustryId IS NULL OR TCustomer.IndustryId = @IndustryId)
		AND (@CustomerRelationLevelId IS NULL OR TCustomer.CustomerRelationLevelId = @CustomerRelationLevelId) 
		AND (@OrginId IS NULL OR TCustomer.OrginId = @OrginId)
		ORDER BY TCustomer.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ImportantTrackRecordInsert
(
	@ID							UNIQUEIDENTIFIER	,
	@CustomerId					UNIQUEIDENTIFIER	,
	@TrackTime					DATETIME			,
	@Principal					NVARCHAR(50)		,
	@Content					NVARCHAR(2000)		,
	@ImportantTrackRecordTypeId	INT							
)
AS
BEGIN
    INSERT INTO TImportantTrackRecord(
	ID								,
	CustomerId						,
	TrackTime						,
	Principal						,
	[Content]						,
	ImportantTrackRecordTypeId		,
	TimeStamper					
	)
    VALUES (
	@ID								,
	@CustomerId						,
	@TrackTime						,
	@Principal						,
	@Content						,
	@ImportantTrackRecordTypeId		,
	GETDATE()					
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteImportantTrackRecordsByCustomerId
(
	@CustomerId		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TImportantTrackRecord				
	WHERE CustomerId = @CustomerId
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetImportantTrackRecordsByCustomerId
(
	     @CustomerId	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			
		ID								as ImportantTrackRecord_ID								,
		CustomerId						as ImportantTrackRecord_CustomerId						,
		TrackTime						as ImportantTrackRecord_TrackTime						,
		Principal						as ImportantTrackRecord_Principal						,
		[Content]						as ImportantTrackRecord_Content							,
		ImportantTrackRecordTypeId		as ImportantTrackRecord_ImportantTrackRecordTypeId			

		FROM  TImportantTrackRecord
		WHERE CustomerId = @CustomerId
		ORDER BY TrackTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerTrackRecordInsert
(
	@ID						UNIQUEIDENTIFIER	,
	@CustomerId				UNIQUEIDENTIFIER	,
	@TrackTime				DATETIME			,
	@ContactName			NVARCHAR(50)		,
	@Content				NVARCHAR(2000)		,
	@TrackModeId			UNIQUEIDENTIFIER	,
	@ShareNames				NVARCHAR(50)		,
	@CreaterId				INT					,
	@CreateTime				DATETIME			
)
AS
BEGIN
    INSERT INTO TCustomerTrackRecord(
	ID							,
	CustomerId					,
	TrackTime					,
	ContactName					,
	[Content]					,
	TrackModeId					,
	ShareNames					,
	CreaterId					,
	CreateTime					,
	TimeStamper					
	)
    VALUES (
	@ID							,
	@CustomerId					,
	@TrackTime					,
	@ContactName				,
	@Content					,
	@TrackModeId				,
	@ShareNames					,
	@CreaterId					,
	@CreateTime					,
	GETDATE()
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerTrackRecordsByCustomerId
(
	@CustomerId		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TCustomerTrackRecord			
	WHERE CustomerId = @CustomerId
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerTrackRecordsByCustomerId
(
	     @CustomerId	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			
		
		ID							as CustomerTrackRecord_ID				,
		CustomerId					as CustomerTrackRecord_CustomerId		,
		TrackTime					as CustomerTrackRecord_TrackTime		,
		ContactName					as CustomerTrackRecord_ContactName		,
		[Content]					as CustomerTrackRecord_Content			,
		TrackModeId					as CustomerTrackRecord_TrackModeId		,
		ShareNames					as CustomerTrackRecord_ShareNames		,
		CreaterId					as CustomerTrackRecord_CreaterId		,
		CreateTime					as CustomerTrackRecord_CreateTime		

		FROM  TCustomerTrackRecord
		WHERE CustomerId = @CustomerId
		ORDER BY TrackTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerOwnerHistoryInsert
(
	@ID						UNIQUEIDENTIFIER	,
	@CustomerId				UNIQUEIDENTIFIER	,
	@OperateTime			DATETIME			,
	@OperaterName			NVARCHAR(50)		,
	@OperateContent			NVARCHAR(200)		
)
AS
BEGIN
    INSERT INTO TCustomerOwnerHistory(
	ID							,
	CustomerId					,
	OperateTime					,
	OperaterName				,
	OperateContent				,
	TimeStamper			
	)
    VALUES (
	@ID							,
	@CustomerId					,
	@OperateTime				,
	@OperaterName				,
	@OperateContent				,
	GETDATE()	
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerOwnerHistorysByCustomerId
(
	@CustomerId		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TCustomerOwnerHistory				
	WHERE CustomerId = @CustomerId
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerOwnerHistorysByCustomerId
(
	     @CustomerId	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			
		ID						as CustomerOwnerHistory_ID					,
		CustomerId				as CustomerOwnerHistory_CustomerId			,
		OperateTime				as CustomerOwnerHistory_OperateTime			,
		OperaterName			as CustomerOwnerHistory_OperaterName		,
		OperateContent			as CustomerOwnerHistory_OperateContent		
		FROM  TCustomerOwnerHistory
		WHERE CustomerId = @CustomerId
		ORDER BY OperateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End   客户       ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   商业机会       ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OpportunityInsert
(
	@ID								UNIQUEIDENTIFIER	,
	@OpportunityName				NVARCHAR(50)		,
	@SalesStageID					UNIQUEIDENTIFIER	,
	@ContactName					NVARCHAR(50)		,
	@ExpectedCloseDate   			DATETIME			,
	@CustomerBudget					DECIMAL(25,2)		,
	@Description					NVARCHAR(2000)		,
	@Probability					INT					,
	@Types							INT					,
	@FailedTypesID					INT					,
	@Remark							NVARCHAR(2000)		,
	@OrderID						UNIQUEIDENTIFIER	,
	@CustomerId						UNIQUEIDENTIFIER	,
	@CreaterId						INT					,
	@CreateTime						DATETIME	
)
AS
BEGIN
    INSERT INTO TOpportunity(
	ID							,
	[Name]						,
	SalesStageID				,
	ContactName					,
	ExpectedCloseDate   		,
	CustomerBudget				,
	Description					,
	Probability					,
	Types						,
	FailedTypesID				,
	Remark						,
	OrderID						,
	CustomerId					,
	CreaterId					,
	CreateTime					,
	TimeStamper							
	)
  VALUES (
	@ID,
	@OpportunityName			,
	@SalesStageID				,
	@ContactName				,
	@ExpectedCloseDate			,
	@CustomerBudget				,
	@Description				,
	@Probability				,
	@Types						,
	@FailedTypesID				,
	@Remark						,
	@OrderID					,
	@CustomerId					,
	@CreaterId					,
	@CreateTime					,
	GETDATE()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE IntentProductListInsert
(
	@ID							UNIQUEIDENTIFIER		,
	@OpportunityId				UNIQUEIDENTIFIER		,
	@ProductId					UNIQUEIDENTIFIER		,
	@ProductName				NVARCHAR(50)			,
	@ProductMarketPrice   		Decimal(25,2)			,
	@ProductDescription			NVARCHAR(2000)			,
	@ProductFirstTypeID			UNIQUEIDENTIFIER		,
	@ProductFirstTypeName		NVARCHAR(50)			,
	@ProductSecondTypeID		UNIQUEIDENTIFIER		,
	@ProductSecondTypeName		NVARCHAR(50)			,
	@Amount						Decimal(25,2)			,
	@Price						Decimal(25,2)
)
AS
BEGIN
    INSERT INTO TIntentProduct(
    ID						,
    OpportunityId			,
	ProductId				,
	ProductName				,
	ProductMarketPrice		,
	ProductDescription		,
	ProductFirstTypeID		,
	ProductFirstTypeName	,
	ProductSecondTypeID		,
	ProductSecondTypeName	,
	Amount					,
	Price					,
	TimeStamper					
	)
  VALUES (
	@ID						,
	@OpportunityId			,
	@ProductId				,
	@ProductName			,
	@ProductMarketPrice		,
	@ProductDescription		,
	@ProductFirstTypeID		,
	@ProductFirstTypeName	,
	@ProductSecondTypeID	,
	@ProductSecondTypeName	,
	@Amount					,
	@Price					,
	GETDATE()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OpportunityUpdate
(
	@ID							UNIQUEIDENTIFIER	,
	@OpportunityName			NVARCHAR(50)		,
	@SalesStageID				UNIQUEIDENTIFIER	,
	@ContactName				NVARCHAR(50)		,
	@ExpectedCloseDate   		DATETIME			,
	@CustomerBudget				DECIMAL(25,2)		,
	@Description				NVARCHAR(2000)		,
	@Probability				INT					,
	@Types						INT					,
	@FailedTypesID				INT					,
	@Remark						NVARCHAR(2000)		,
	@OrderID					UNIQUEIDENTIFIER	,
	@CustomerId					UNIQUEIDENTIFIER	,
	@CreaterId					INT					,
	@CreateTime					DATETIME		
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TOpportunity SET
	ID=@ID,
	[Name]=@OpportunityName						,
	SalesStageID=@SalesStageID					,
	ContactName=@ContactName					,
	ExpectedCloseDate=@ExpectedCloseDate 		,
	CustomerBudget=@CustomerBudget				,
	Description=@Description					,
	Probability=@Probability					,
	Types=@Types								,
	FailedTypesID=@FailedTypesID				,
	Remark=@Remark								,
	OrderID=@OrderID							,
	CustomerId=@CustomerId						,
	CreaterId=@CreaterId						,
	CreateTime=@CreateTime						
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteProductForByOpportunityId
(
	@OpportunityID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TIntentProduct 			
	WHERE OpportunityId=@OpportunityID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOpportunitysByCustomerId
(
	     @CustomerId		UNIQUEIDENTIFIER 
)
AS
BEGIN
        SELECT 
		--TOpportunity
		TOpportunity.ID						as Opportunity_ID						,
		TOpportunity.[Name]					as Opportunity_Name						,
		TOpportunity.SalesStageID			as Opportunity_SalesStageID				,
		TOpportunity.ContactName			as Opportunity_ContactName				,
		TOpportunity.ExpectedCloseDate		as Opportunity_ExpectedCloseDate		,
		TOpportunity.CustomerBudget			as Opportunity_CustomerBudget			,
		TOpportunity.Description			as Opportunity_Description				,
		TOpportunity.Probability			as Opportunity_Probability				,
		TOpportunity.Types					as Opportunity_Types					,
		TOpportunity.FailedTypesID			as Opportunity_FailedTypesID			,
		TOpportunity.Remark					as Opportunity_Remark					,
		TOpportunity.OrderID				as Opportunity_OrderID					,
		TOpportunity.CustomerId				as Opportunity_CustomerId				,
		TOpportunity.CreaterId				as Opportunity_CreaterId				,
		TOpportunity.CreateTime				as Opportunity_CreateTime				,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					,
		--TGuidParameter
		TGuidParameter.ID					as GuidParameter_ID						,
		TGuidParameter.[Name]				as GuidParameter_Name					,
		TGuidParameter.Description			as GuidParameter_Description			,
		TGuidParameter.TypeId				as GuidParameter_TypeId					
		FROM  TOpportunity,TCustomer,TGuidParameter
		WHERE TOpportunity.CustomerId = TCustomer.Id
		and	  TOpportunity.SalesStageId = TGuidParameter.Id
		and	  TOpportunity.CustomerId = @CustomerId
		ORDER BY TOpportunity.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetInsertProductByOpportunityId
(
	     @ID		UNIQUEIDENTIFIER 
)
AS
BEGIN
        SELECT 
		--TOpportunity
		TIntentProduct.ID												,
		TIntentProduct.OpportunityId									,
		TIntentProduct.ProductId										,
		TIntentProduct.ProductName										,
		TIntentProduct.ProductMarketPrice			  					,
		TIntentProduct.ProductDescription								,
		TIntentProduct.ProductFirstTypeID								,
		TIntentProduct.ProductFirstTypeName								,
		TIntentProduct.ProductSecondTypeID								,
		TIntentProduct.ProductSecondTypeName							,
		TIntentProduct.Amount											,
		TIntentProduct.Price															
		FROM  TIntentProduct
		WHERE TIntentProduct.OpportunityId = @ID
		ORDER BY TIntentProduct.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOpportunitysById
(
	     @ID		UNIQUEIDENTIFIER 
)
AS
BEGIN
        SELECT 
		--TOpportunity
		TOpportunity.ID						as Opportunity_ID						,
		TOpportunity.[Name]					as Opportunity_Name						,
		TOpportunity.SalesStageID			as Opportunity_SalesStageID				,
		TOpportunity.ContactName			as Opportunity_ContactName				,
		TOpportunity.ExpectedCloseDate		as Opportunity_ExpectedCloseDate		,
		TOpportunity.CustomerBudget			as Opportunity_CustomerBudget			,
		TOpportunity.Description			as Opportunity_Description				,
		TOpportunity.Probability			as Opportunity_Probability				,
		TOpportunity.Types					as Opportunity_Types					,
		TOpportunity.FailedTypesID			as Opportunity_FailedTypesID			,
		TOpportunity.Remark					as Opportunity_Remark					,
		TOpportunity.OrderID				as Opportunity_OrderID					,
		TOpportunity.CustomerId				as Opportunity_CustomerId				,
		TOpportunity.CreaterId				as Opportunity_CreaterId				,
		TOpportunity.CreateTime				as Opportunity_CreateTime				,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					,
		--TGuidParameter
		TGuidParameter.ID					as GuidParameter_ID						,
		TGuidParameter.[Name]				as GuidParameter_Name					,
		TGuidParameter.Description			as GuidParameter_Description			,
		TGuidParameter.TypeId				as GuidParameter_TypeId							
		FROM  TOpportunity,TCustomer,TGuidParameter
		WHERE TOpportunity.CustomerId = TCustomer.Id
		and	  TOpportunity.SalesStageId = TGuidParameter.Id
		and	  TOpportunity.ID = @ID
		ORDER BY TOpportunity.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOpportunityByCondition
(
		@OpportunityName			NVARCHAR(50)		= NULL		,
		@CustomerFullName			NVARCHAR(50)		= NULL		,
		@CreateFrom					DATETIME						,
		@CreateTo					DATETIME						,
		@Types						INT					= NULL		,
		@SalesStageID				UNIQUEIDENTIFIER	= NULL	
)
AS
BEGIN
        SELECT 
		--TOpportunity
		TOpportunity.ID						as Opportunity_ID						,
		TOpportunity.[Name]					as Opportunity_Name						,
		TOpportunity.SalesStageID			as Opportunity_SalesStageID				,
		TOpportunity.ContactName			as Opportunity_ContactName				,
		TOpportunity.ExpectedCloseDate		as Opportunity_ExpectedCloseDate		,
		TOpportunity.CustomerBudget			as Opportunity_CustomerBudget			,
		TOpportunity.Description			as Opportunity_Description				,
		TOpportunity.Probability			as Opportunity_Probability				,
		TOpportunity.Types					as Opportunity_Types					,
		TOpportunity.FailedTypesID			as Opportunity_FailedTypesID			,
		TOpportunity.Remark					as Opportunity_Remark					,
		TOpportunity.OrderID				as Opportunity_OrderID					,
		TOpportunity.CustomerId				as Opportunity_CustomerId				,
		TOpportunity.CreaterId				as Opportunity_CreaterId				,
		TOpportunity.CreateTime				as Opportunity_CreateTime				,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					,
		--TGuidParameter
		TGuidParameter.ID					as GuidParameter_ID						,
		TGuidParameter.[Name]				as GuidParameter_Name					,
		TGuidParameter.Description			as GuidParameter_Description			,
		TGuidParameter.TypeId				as GuidParameter_TypeId									
		FROM  TOpportunity, TCustomer,TGuidParameter
		WHERE TOpportunity.CustomerId = TCustomer.Id
		AND	  TOpportunity.SalesStageId = TGuidParameter.Id
		AND (@OpportunityName IS NULL OR TOpportunity.[Name] LIKE '%'+@OpportunityName+'%')
		AND (@CustomerFullName IS NULL OR TCustomer.FullName LIKE '%'+@CustomerFullName+'%')
		AND (DATEDIFF(dd,@CreateFrom,TOpportunity.CreateTime)>=0)
		AND (DATEDIFF(dd,TOpportunity.CreateTime,@CreateTo)>=0)
		AND (@Types IS NULL or TOpportunity.Types = @Types)
		AND (@SalesStageID IS NULL or TOpportunity.SalesStageID = @SalesStageID)
		ORDER BY TOpportunity.TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteOpportunityById
(
	@ID			UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE FROM TOpportunity 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End   商业机会       ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   订单       ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OrderInsert
(
		@ID						UNIQUEIDENTIFIER	,
		@OrderNumber			NVARCHAR(50)		,
		@ContactName			NVARCHAR(50)		,
		@OrderStatusId			INT					,
		@OrderTime				DATETIME			,
		@Description			NVARCHAR(2000)		,
		@Sum					DECIMAL(25,2)		,
		@CustomerId				UNIQUEIDENTIFIER	,
		@CreaterId				INT					,
		@CreateTime				DATETIME										
)
AS
BEGIN
    INSERT INTO TOrder(
		ID							,
		OrderNumber					,
		ContactName					,
		OrderStatusId				,
		OrderTime					,
		Description					,
		[Sum]						,
		CustomerId					,
		CreaterId					,
		CreateTime					,
		TimeStamper				
	)
    VALUES (
		@ID							,
		@OrderNumber				,
		@ContactName				,
		@OrderStatusId				,
		@OrderTime					,
		@Description				,
		@Sum						,
		@CustomerId					,
		@CreaterId					,
		@CreateTime					,
		GETDATE()									
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OrderUpdate
(
		@ID						UNIQUEIDENTIFIER	,
		@OrderNumber			NVARCHAR(50)		,
		@ContactName			NVARCHAR(50)		,
		@OrderStatusId			INT					,
		@OrderTime				DATETIME			,
		@Description			NVARCHAR(2000)		,
		@Sum					DECIMAL(25,2)		,
		@CustomerId				UNIQUEIDENTIFIER	,
		@CreaterId				INT					,
		@CreateTime				DATETIME					
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TOrder SET
		OrderNumber=@OrderNumber					,
		ContactName=@ContactName					,
		OrderStatusId=@OrderStatusId				,
		OrderTime=@OrderTime						,
		Description=@Description					,
		[Sum]=@Sum									,
		CustomerId=@CustomerId						,
		CreaterId=@CreaterId						,
		CreateTime=@CreateTime											
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteOrderById
(
	@Id		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TOrder				
	WHERE Id = @Id
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOrderById
(
	     @Id	UNIQUEIDENTIFIER = NULL
)
AS
BEGIN
        SELECT 			
		--TOrder
		TOrder.ID							as Order_ID								,
		TOrder.OrderNumber					as Order_OrderNumber					,
		TOrder.ContactName					as Order_ContactName					,
		TOrder.OrderStatusId				as Order_OrderStatusId					,
		TOrder.OrderTime					as Order_OrderTime						,
		TOrder.Description					as Order_Description					,
		TOrder.[Sum]						as Order_Sum							,
		TOrder.CustomerId					as Order_CustomerId						,
		TOrder.CreaterId					as Order_CreaterId						,
		TOrder.CreateTime					as Order_CreateTime						,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime						
		FROM  TOrder,TCustomer
		WHERE TOrder.CustomerId = TCustomer.ID
		AND   (@ID IS NULL OR TOrder.ID = @ID)
		ORDER BY TOrder.CreateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOrdersByCustomerId
(
	     @CustomerId	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			
		--TOrder
		TOrder.ID							as Order_ID								,
		TOrder.OrderNumber					as Order_OrderNumber					,
		TOrder.ContactName					as Order_ContactName					,
		TOrder.OrderStatusId				as Order_OrderStatusId					,
		TOrder.OrderTime					as Order_OrderTime						,
		TOrder.Description					as Order_Description					,
		TOrder.[Sum]						as Order_Sum							,
		TOrder.CustomerId					as Order_CustomerId						,
		TOrder.CreaterId					as Order_CreaterId						,
		TOrder.CreateTime					as Order_CreateTime						,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					
		FROM  TOrder,TCustomer
		WHERE TOrder.CustomerId = TCustomer.ID
		AND   TCustomer.ID = @CustomerId
		ORDER BY TOrder.CreateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOrderByOrderNubmer
(
	     @OrderNumber	NVARCHAR(50)
)
AS
BEGIN
        SELECT 			
		--TOrder
		TOrder.ID							as Order_ID								,
		TOrder.OrderNumber					as Order_OrderNumber					,
		TOrder.ContactName					as Order_ContactName					,
		TOrder.OrderStatusId				as Order_OrderStatusId					,
		TOrder.OrderTime					as Order_OrderTime						,
		TOrder.Description					as Order_Description					,
		TOrder.[Sum]						as Order_Sum							,
		TOrder.CustomerId					as Order_CustomerId						,
		TOrder.CreaterId					as Order_CreaterId						,
		TOrder.CreateTime					as Order_CreateTime						,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					
		FROM  TOrder,TCustomer
		WHERE TOrder.CustomerId = TCustomer.ID
		AND   TOrder.OrderNumber = @OrderNumber
		ORDER BY TOrder.CreateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOrderByCondition
(
		@OrderNumber			NVARCHAR(50) = NULL	,	
		@CustomerFullName		NVARCHAR(50) = NULL	,
		@OrderTimeFrom			DATETIME			,
		@OrderTimeTo			DATETIME			,
		@OrderStatusId			INT			 = NULL 	
)
AS
BEGIN
        SELECT 			
		--TOrder
		TOrder.ID							as Order_ID								,
		TOrder.OrderNumber					as Order_OrderNumber					,
		TOrder.ContactName					as Order_ContactName					,
		TOrder.OrderStatusId				as Order_OrderStatusId					,
		TOrder.OrderTime					as Order_OrderTime						,
		TOrder.Description					as Order_Description					,
		TOrder.[Sum]						as Order_Sum							,
		TOrder.CustomerId					as Order_CustomerId						,
		TOrder.CreaterId					as Order_CreaterId						,
		TOrder.CreateTime					as Order_CreateTime						,
		--TCustomer
		TCustomer.ID						as Customer_ID							,
		TCustomer.FullName					as Customer_FullName					,
		TCustomer.ShortName					as Customer_ShortName					,
		TCustomer.IndustryId				as Customer_IndustryId					,
		TCustomer.OrginId					as Customer_OrginId						,
		TCustomer.SizeId					as Customer_SizeId						,
		TCustomer.OwnedTypeId				as Customer_OwnedTypeId					,
		TCustomer.Phone						as Customer_Phone						,
		TCustomer.Fax						as Customer_Fax							,
		TCustomer.Email						as Customer_Email						,
		TCustomer.InternetAddress			as Customer_InternetAddress				,
		TCustomer.CustomerPrincipal			as Customer_CustomerPrincipal			,
		TCustomer.Remark					as Customer_Remark						,
		TCustomer.OwnerStatusId				as Customer_OwnerStatusId				,
		TCustomer.PrincipalId				as Customer_PrincipalId					,
		TCustomer.SharesId					as Customer_SharesId					,
		TCustomer.CustomerRelationLevelId	as Customer_CustomerRelationLevelId		,
		TCustomer.AreaId					as Customer_AreaId						,
		TCustomer.ProvinceId				as Customer_ProvinceId					,
		TCustomer.CityId					as Customer_CityId						,
		TCustomer.Postalcode				as Customer_Postalcode					,
		TCustomer.Address					as Customer_Address						,
		TCustomer.CreaterId					as Customer_CreaterId					,
		TCustomer.CreateTime				as Customer_CreateTime					
		FROM  TOrder,TCustomer
		WHERE TOrder.CustomerId = TCustomer.ID
		AND (@OrderNumber IS NULL OR TOrder.OrderNumber LIKE '%'+@OrderNumber+'%')
		AND (@CustomerFullName IS NULL OR TCustomer.FullName LIKE '%'+@CustomerFullName+'%')
		AND (@OrderStatusId IS NULL OR TOrder.OrderStatusId = @OrderStatusId)
		AND (DATEDIFF(dd,@OrderTimeFrom,TOrder.OrderTime)>=0)
		AND (DATEDIFF(dd,TOrder.OrderTime,@OrderTimeTo)>=0)
		ORDER BY TOrder.CreateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OrderProductInsert
(
	@ID								UNIQUEIDENTIFIER	,
	@OrderId						UNIQUEIDENTIFIER	,
	@ProductId						UNIQUEIDENTIFIER	,
	@ProductName					NVARCHAR(50)		,
	@ProductMarketPrice				DECIMAL(25,2)		,
	@ProductDescription				NVARCHAR(2000)		,
	@ProductFirstTypeID				UNIQUEIDENTIFIER	,
	@ProductFirstTypeName			NVARCHAR(50)		,
	@ProductSecondTypeID			UNIQUEIDENTIFIER	,
	@ProductSecondTypeName			NVARCHAR(50)		,
	@Amount							DECIMAL(25,2)		,
	@Price							DECIMAL(25,2)									
)
AS
BEGIN
    INSERT INTO TOrderProduct(
		ID									,
		OrderId								,
		ProductId							,
		ProductName							,
		ProductMarketPrice					,
		ProductDescription					,
		ProductFirstTypeID					,
		ProductFirstTypeName				,
		ProductSecondTypeID					,
		ProductSecondTypeName				,
		Amount								,
		Price								,
		TimeStamper				
	)
    VALUES (
		@ID									,
		@OrderId							,
		@ProductId							,
		@ProductName						,
		@ProductMarketPrice					,
		@ProductDescription					,
		@ProductFirstTypeID					,
		@ProductFirstTypeName				,
		@ProductSecondTypeID				,
		@ProductSecondTypeName				,
		@Amount								,
		@Price								,
		GETDATE()									
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetOrderProductByOrderId
(
	     @OrderId	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			

		ID									as OrderProduct_ID						,
		OrderId								as OrderProduct_OrderId					,
		ProductId							as OrderProduct_ProductId				,
		ProductName							as OrderProduct_ProductName				,
		ProductMarketPrice					as OrderProduct_ProductMarketPrice		,
		ProductDescription					as OrderProduct_ProductDescription		,
		ProductFirstTypeID					as OrderProduct_ProductFirstTypeID		,
		ProductFirstTypeName				as OrderProduct_ProductFirstTypeName	,
		ProductSecondTypeID					as OrderProduct_ProductSecondTypeID		,
		ProductSecondTypeName				as OrderProduct_ProductSecondTypeName	,
		Amount								as OrderProduct_Amount					,
		Price								as OrderProduct_Price					

		FROM  TOrderProduct
		WHERE OrderId = @OrderId
		ORDER BY TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteOrderProductByOrderId
(
	@OrderId		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TOrderProduct				
	WHERE OrderId = @OrderId
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End   订单       ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin   参数       ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GuidParameterInsert
(
	@ID						UNIQUEIDENTIFIER	,
    @Name					NVARCHAR(50)		,
	@Description			NVARCHAR(200)		,
	@TypeId					INT						
)
AS
BEGIN
    INSERT INTO TGuidParameter(
	ID								,
    [Name]							,
	Description						,
	TypeId							,
	TimeStamper						
	)
    VALUES (
	@ID								,
    @Name							,
	@Description					,
	@TypeId							,
	GETDATE()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GuidParameterUpdate
(
	@ID						UNIQUEIDENTIFIER	,
    @Name					NVARCHAR(50)		,
	@Description			NVARCHAR(200)		,
	@TypeId					INT						
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TGuidParameter SET
	[Name]=@Name								,
	Description=@Description					,
	TypeId=@TypeId								
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetGuidParameterById
(
	     @ID	UNIQUEIDENTIFIER
)
AS
BEGIN
        SELECT 			
		ID						as		GuidParameter_ID			,	
		[Name]					as 		GuidParameter_Name			,		
		Description				as 		GuidParameter_Description	,		
		TypeId					as 		GuidParameter_TypeId		
		FROM  TGuidParameter
		WHERE ID = @ID
		ORDER BY TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetGuidParameterByTypeId
(
	     @TypeId	INT
)
AS
BEGIN
        SELECT 		
		ID						as		GuidParameter_ID			,	
		[Name]					as 		GuidParameter_Name			,		
		Description				as 		GuidParameter_Description	,		
		TypeId					as 		GuidParameter_TypeId						
		FROM  TGuidParameter
		WHERE TypeId = @TypeId
		ORDER BY TimeStamper
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteGuidParameterById
(
	@Id		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	DELETE TGuidParameter				
	WHERE Id = @Id
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/***********************************************************************************/
/************         End   参数       ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin   产品       ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductInsert
(
	@ID							UNIQUEIDENTIFIER	,
	@Name					    NVARCHAR(50)		,
	@Description				NVARCHAR(200)		,
	@FirstTypeId				UNIQUEIDENTIFIER	,
	@SecondTypeId				UNIQUEIDENTIFIER	,
	@Price						Decimal(25,2)		,
	@Picture				    Image							
)
AS
BEGIN
    INSERT INTO TProduct(
	ID									,
	[Name]							    ,
	Description							,
	Price							    ,
	FirstTypeId							,
	SecondTypeId						,
	Picture							    ,
	TimeStamper					
	)
    VALUES (
	@ID									,
	@Name							    ,
	@Description						,
	@Price								,
	@FirstTypeId						,
	@SecondTypeId						,
	@Picture						    ,
	GETDATE()									
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductUpdate
(
	@ID							UNIQUEIDENTIFIER	,
	@Name					    NVARCHAR(50)		,
	@Description				NVARCHAR(50)		,
	@FirstTypeId				UNIQUEIDENTIFIER	,
	@SecondTypeId				UNIQUEIDENTIFIER	,
	@Price						Decimal(25,2)		,
	@Picture				    Image				

)
AS
BEGIN
	SET NOCOUNT OFF
	Update TProduct SET
	[Name]=	@Name						    ,
	Description=@Description				,
	Price=@Price							,
	FirstTypeId	=@FirstTypeId				,
	SecondTypeId=@SecondTypeId				,
	Picture=@Picture				
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductDelete
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TProduct 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetProductById
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select TProduct.ID,TProduct.[Name],TProduct.Description,Price,TProduct.FirstTypeId,TProductFirstType.[Name] as FirstTypeName,
           SecondTypeId,TProductSecondType.[Name] as SecondTypeName,Picture
    From TProduct,TProductFirstType,TProductSecondType 			
	WHERE TProduct.ID=@ID
    And TProduct.FirstTypeId=TProductFirstType.ID
    And TProduct.SecondTypeId=TProductSecondType.ID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetProductByCondition
(
	@Name					    NVARCHAR(50)		= NULL	,
	@FirstTypeId				UNIQUEIDENTIFIER	= NULL	,
	@SecondTypeId				UNIQUEIDENTIFIER	= NULL	,
	@PriceFrom					Decimal(25,2)				,	
	@PriceTo					Decimal(25,2)			
)
AS
BEGIN
	Select TProduct.ID,TProduct.[Name],TProduct.Description,Price,TProduct.FirstTypeId,TProductFirstType.[Name] as FirstTypeName,
           SecondTypeId,TProductSecondType.[Name] as SecondTypeName,Picture
    From TProduct,TProductFirstType,TProductSecondType 			
	WHERE (@Name='' OR @Name IS NULL OR TProduct.[Name] like '%' +@Name + '%' )
    AND (@FirstTypeId IS NULL OR TProduct.FirstTypeId = @FirstTypeId)
    AND (@SecondTypeId IS NULL OR TProduct.SecondTypeId = @SecondTypeId)
	And (@PriceFrom = -1 OR Price >= @PriceFrom)
	And (@PriceTo = -1 OR Price <= @PriceTo)
    And (TProduct.FirstTypeId=TProductFirstType.ID)
    And (TProduct.SecondTypeId=TProductSecondType.ID)
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductFirstTypeInsert
(
	@ID							UNIQUEIDENTIFIER	,
	@Name					    NVARCHAR(50)		,
	@Description				NVARCHAR(50)					
)
AS
BEGIN
    INSERT INTO TProductFirstType(
	ID									,
	[Name]							    ,
	Description							,
	TimeStamper					
	)
    VALUES (
	@ID									,
	@Name							    ,
	@Description			         	,
	GETDATE()							
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductFirstTypeUpdate
(
	@ID							UNIQUEIDENTIFIER	,
	@Name					    NVARCHAR(50)		,
	@Description				NVARCHAR(50)			

)
AS
BEGIN
	SET NOCOUNT OFF
	Update TProductFirstType SET
	[Name]=	@Name						    ,
	Description=@Description					
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductFirstTypeDelete
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TProductFirstType 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetFirstTypeById
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select ID,TProductFirstType.[Name],Description
    From TProductFirstType 			
	WHERE ID=@ID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAllFirstType
AS
BEGIN
	Select ID,TProductFirstType.[Name],Description
    From TProductFirstType 		
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductSecondTypeInsert
(
	@ID							UNIQUEIDENTIFIER	,
	@Name					    NVARCHAR(50)		,
	@Description				NVARCHAR(50)		,
    @FirstTypeId                UNIQUEIDENTIFIER    			
)
AS
BEGIN
    INSERT INTO TProductSecondType(
	ID									,
	[Name]							    ,
	Description							,
    FirstTypeId                         ,
	TimeStamper					
	)
    VALUES (
	@ID									,
	@Name							    ,
	@Description						,
    @FirstTypeId                        ,
	GETDATE()									
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetSencondTypeByFirstTypeId
(
	@FirstTypeID							UNIQUEIDENTIFIER			

)
AS
BEGIN
	Select ID,TProductSecondType.[Name],Description
    From  TProductSecondType 			
	WHERE FirstTypeId=@FirstTypeID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProductSecondTypeDelete
(
	@FirstTypeID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TProductSecondType 			
	WHERE FirstTypeId=@FirstTypeID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End   产品       ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin      权限                   ****************************/
/***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[GetAllAuth]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAuth]
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * 
	FROM TAuth 
	ORDER BY AuthParentId ASC
END
GO

/****** 对象:  StoredProcedure [dbo].[GetAccountAuth]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccountAuth]
(
	@AccountId INT
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT B.*
	FROM TAccountAuth A 
		LEFT JOIN TAuth B ON A.AuthID = B.PKID
	WHERE AccountId=@AccountId
	ORDER BY B.AuthParentId ASC
END
GO

/****** 对象:  StoredProcedure [dbo].[SetAccountAuth]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetAccountAuth]
(
	@AccountId INT,
	@AuthId INT
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO TAccountAuth
			   ([AccountId]
			   ,[AuthId]
				)
		 VALUES
			   (@AccountId
			   ,@AuthId
			   )
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[CancelAccountAllAuth]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CancelAccountAllAuth]
(
	@AccountId INT
)
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM TAccountAuth WHERE AccountId=@AccountId
    RETURN @@Rowcount
END
GO

/***********************************************************************************/
/************         End         权限                  ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin  跟踪曲线模板               ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrackCurveTemplateInsert
(
	@ID								UNIQUEIDENTIFIER	,
	@Title				            NVARCHAR(50)		,
	@SecondTouchDays			    INT		            ,
	@ThirdTouchDays					INT	         		,
	@FourthTouchDays   			    INT				    ,
	@FifthTouchDays					INT			        ,
	@LoopDays					    INT			        ,
	@UpToDays					    INT					,
	@RelatedAccountID				INT						
)
AS
BEGIN
    INSERT INTO TTrackCurveTemplate(
	ID							,
	Title					    ,
	SecondTouchDays				,
	ThirdTouchDays				,
	FourthTouchDays    		    ,
	FifthTouchDays				,
	LoopDays					,
	UpToDays					,
	RelatedAccountID			,
	TimeStamper								
	)
  VALUES (
	@ID,
	@Title			            ,
	@SecondTouchDays			,
	@ThirdTouchDays				,
	@FourthTouchDays			,
	@FifthTouchDays				,
	@LoopDays				    ,
	@UpToDays				    ,
	@RelatedAccountID			,
	GetDate()			
	)
    SELECT @@RowCount
END
GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrackCurveTemplateUpdate
(
	@ID								UNIQUEIDENTIFIER	,
	@Title				            NVARCHAR(50)		,
	@SecondTouchDays			    INT		            ,
	@ThirdTouchDays					INT	         		,
	@FourthTouchDays   			    INT				    ,
	@FifthTouchDays					INT			        ,
	@LoopDays					    INT			        ,
	@UpToDays					    INT					,
	@RelatedAccountID				INT						
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TTrackCurveTemplate SET
	Title=@Title						                ,
	SecondTouchDays=@SecondTouchDays				    ,
	ThirdTouchDays=@ThirdTouchDays						,
	FourthTouchDays	=@FourthTouchDays				    ,
	FifthTouchDays=@FifthTouchDays				        ,
	LoopDays=@LoopDays                                  ,
    UpToDays=@UpToDays				
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrackCurveTemplateDelete
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TTrackCurveTemplate 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetTrackCurveTemplateById
(
	@ID							UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select
    ID,
    Title,
    SecondTouchDays	,
	ThirdTouchDays	,
	FourthTouchDays	,
	FifthTouchDays	,
	LoopDays,
    UpToDays,
    RelatedAccountID	
    From TTrackCurveTemplate 			
	WHERE ID=@ID
    
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetMyTrackCurveTemplate
(
	@RelatedAccountID							INT			

)
AS
BEGIN
	Select
    ID,
    Title,
    SecondTouchDays	,
	ThirdTouchDays	,
	FourthTouchDays	,
	FifthTouchDays	,
	LoopDays,
    UpToDays,
    RelatedAccountID	
    From  TTrackCurveTemplate 			
	WHERE RelatedAccountID=@RelatedAccountID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/***********************************************************************************/
/************         End         跟踪曲线模板                  ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin  日程事件               ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CalendarEventInsert
(
	@ID								UNIQUEIDENTIFIER		,
	@StartDateTime					DATETIME				,
    @Title							NVARCHAR(255)			,
    @Content						NVARCHAR(2000) 			,
	@ImportantDegreeId				INT						,
	@EventStatusId					INT						,
	@RelatedAccountId				INT						,
	@RelatedCustomerTrackCurveId	UNIQUEIDENTIFIER		,
	@Reason							NVARCHAR(255)	 = NULL	,
	@GiveUpTime						DATETIME		 = NULL	,
	@CompleteTime					DATETIME		 = NULL	,
	@CustomerId						UNIQUEIDENTIFIER = NULL 
)
AS
BEGIN
    INSERT INTO TCalendarEvent(
	ID									,
	StartDateTime						,
    Title							    ,
    [Content]							,
	ImportantDegreeId					,
	EventStatusId						,
	RelatedAccountId					,
	Reason								,
	GiveUpTime							,
	CompleteTime						,
	CustomerId						    ,
	RelatedCustomerTrackCurveId			,
	TimeStamper
	)
  VALUES (
	@ID									,
	@StartDateTime						,
    @Title							    ,
    @Content							,
	@ImportantDegreeId					,
	@EventStatusId						,
	@RelatedAccountId					,
	@Reason								,
	@GiveUpTime							,
	@CompleteTime						,
	@CustomerId						    ,
	@RelatedCustomerTrackCurveId		,
	GetDate()					
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CalendarEventUpdate
(
	@ID								UNIQUEIDENTIFIER		,
	@StartDateTime					DATETIME				,
    @Title							NVARCHAR(255)			,
    @Content						NVARCHAR(2000) 			,
	@ImportantDegreeId				INT						,
	@EventStatusId					INT						,
	@RelatedAccountId				INT						,
	@RelatedCustomerTrackCurveId	UNIQUEIDENTIFIER		,
	@Reason							NVARCHAR(255)	 = NULL	,
	@GiveUpTime						DATETIME		 = NULL	,
	@CompleteTime					DATETIME		 = NULL	,
	@CustomerId						UNIQUEIDENTIFIER = NULL 
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TCalendarEvent SET
	ID=@ID														,
	StartDateTime=@StartDateTime								,
    Title=@Title					    						,
    [Content]=@Content											,
	ImportantDegreeId=@ImportantDegreeId						,
	EventStatusId=@EventStatusId								,
	RelatedAccountId=@RelatedAccountId							,
	Reason=@Reason												,
	GiveUpTime=@GiveUpTime										,
	CompleteTime=@CompleteTime									,
	CustomerId=@CustomerId						    			,
	RelatedCustomerTrackCurveId=@RelatedCustomerTrackCurveId			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CalendarEventDelete
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TCalendarEvent 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCalendarEventById
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select
		--TCalendarEvent
		ID									as CalendarEvent_ID								,
		Title							    as CalendarEvent_Title							,	
		StartDateTime						as CalendarEvent_StartDateTime					,
		[Content]							as CalendarEvent_Content						,
		ImportantDegreeId					as CalendarEvent_ImportantDegreeId				,
		EventStatusId						as CalendarEvent_EventStatusId					,
		RelatedAccountId					as CalendarEvent_RelatedAccountId				,
		Reason								as CalendarEvent_Reason							,
		GiveUpTime							as CalendarEvent_GiveUpTime						,
		CompleteTime						as CalendarEvent_CompleteTime					,
		CustomerId						    as CalendarEvent_CustomerId						,
		RelatedCustomerTrackCurveId			as CalendarEvent_RelatedCustomerTrackCurveId	
    From TCalendarEvent 			
	WHERE ID=@ID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCalendarEventByCondition
(
	@FromDay				DATETIME			,
	@ToDay					DATETIME			,	
	@EventStatusId			INT			= NULL	,
	@RelatedAccountId		INT			
)
AS
BEGIN
	Select
		--TCalendarEvent
		ID									as CalendarEvent_ID								,
		Title							    as CalendarEvent_Title							,
		StartDateTime						as CalendarEvent_StartDateTime					,		
		[Content]							as CalendarEvent_Content						,
		ImportantDegreeId					as CalendarEvent_ImportantDegreeId				,
		EventStatusId						as CalendarEvent_EventStatusId					,
		RelatedAccountId					as CalendarEvent_RelatedAccountId				,
		Reason								as CalendarEvent_Reason							,
		GiveUpTime							as CalendarEvent_GiveUpTime						,
		CompleteTime						as CalendarEvent_CompleteTime					,
		CustomerId						    as CalendarEvent_CustomerId						,
		RelatedCustomerTrackCurveId			as CalendarEvent_RelatedCustomerTrackCurveId	
    From  TCalendarEvent 			
	WHERE RelatedAccountId = @RelatedAccountId
		AND (@EventStatusId IS NULL OR EventStatusId = @EventStatusId)
		AND (DATEDIFF(dd,@FromDay,StartDateTime)>=0)
		AND (DATEDIFF(dd,StartDateTime,@ToDay)>=0)
	ORDER BY StartDateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCalendarEventByTrackCurveId
(
	@RelatedCustomerTrackCurveId			UNIQUEIDENTIFIER
)
AS
BEGIN
	Select
		--TCalendarEvent
		ID									as CalendarEvent_ID								,
		Title							    as CalendarEvent_Title							,	
		StartDateTime						as CalendarEvent_StartDateTime					,			
		[Content]							as CalendarEvent_Content						,
		ImportantDegreeId					as CalendarEvent_ImportantDegreeId				,
		EventStatusId						as CalendarEvent_EventStatusId					,
		RelatedAccountId					as CalendarEvent_RelatedAccountId				,
		Reason								as CalendarEvent_Reason							,
		GiveUpTime							as CalendarEvent_GiveUpTime						,
		CompleteTime						as CalendarEvent_CompleteTime					,
		CustomerId						    as CalendarEvent_CustomerId						,
		RelatedCustomerTrackCurveId			as CalendarEvent_RelatedCustomerTrackCurveId	
    From  TCalendarEvent 			
	WHERE RelatedCustomerTrackCurveId = RelatedCustomerTrackCurveId
	ORDER BY StartDateTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/***********************************************************************************/
/************         End         日程事件                  ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin  日程提醒             ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE RemindInsert
(
	@ID								UNIQUEIDENTIFIER		,
	@RemindTime				        DATETIME				,
	@Content			    		NVARCHAR(255)			,
	@CalendarEventId				UNIQUEIDENTIFIER = NULL	,
	@ReadStatusId   			    INT						,
	@RelatedAccountId				INT			        
)
AS
BEGIN
    INSERT INTO TRemind(
	ID							,
	RemindTime					,
	[Content]			        ,
	CalendarEventId				,
	ReadStatusId    		    ,
	RelatedAccountId		    ,
	TimeStamper										
	)
  VALUES (
	@ID,
	@RemindTime			            ,
	@Content			            ,
	@CalendarEventId				,
	@ReadStatusId			        ,
	@RelatedAccountId				,
	GetDate()					
	)
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE RemindUpdate
(
	@ID								UNIQUEIDENTIFIER		,
	@RemindTime				        DATETIME				,
	@Content			            NVARCHAR(255)			,
	@CalendarEventId				UNIQUEIDENTIFIER = NULL	,
	@ReadStatusId  			        INT						,
	@RelatedAccountId				INT			        					
)
AS
BEGIN
	SET NOCOUNT OFF
	Update TRemind SET
	RemindTime=@RemindTime						         ,
	[Content]=@Content				                     ,
	CalendarEventId=@CalendarEventId				     ,
	ReadStatusId=@ReadStatusId				             ,
	RelatedAccountId=@RelatedAccountId				     
	WHERE ID=@ID
   SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE RemindDelete
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TRemind 			
	WHERE ID=@ID
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetRemindById
(
	@ID		UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select
    ID,
    RemindTime,
    [Content],
	CalendarEventId,
	ReadStatusId,
	RelatedAccountId
    From TRemind 			
	WHERE ID=@ID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetRemindByCalendarEventId
(
	@CalendarEventId		UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select
    ID,
    RemindTime,
    [Content],
	CalendarEventId,
	ReadStatusId,
	RelatedAccountId
    From TRemind 			
	WHERE CalendarEventId=@CalendarEventId
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetRemindsByCondition
(
    @StartTime				DATETIME	,
    @EndTime				DATETIME	,
    @ReadStatusId			INT	= NULL	,
	@RelatedAccountID		INT			
)
AS
BEGIN
	Select
    ID,
    RemindTime,
    [Content],
	CalendarEventId,
	ReadStatusId,
    RelatedAccountID	
    From  TRemind 			
	WHERE((DATEDIFF(dd,@StartTime,RemindTime)>=0)
	AND (DATEDIFF(dd,RemindTime,@EndTime)>=0)
	AND (@ReadStatusId IS NULL OR ReadStatusId =@ReadStatusId)
	AND RelatedAccountID=@RelatedAccountID)
	ORDER BY RemindTime
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/***********************************************************************************/
/************         End  日程提醒             ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin  客户跟踪曲线             ****************************/
/***********************************************************************************/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerTrackCurveInsert
(
	@ID								UNIQUEIDENTIFIER	,
    @CustomerId				        UNIQUEIDENTIFIER	,
	@Title				            NVARCHAR(50)		
)
AS
BEGIN
    INSERT INTO TCustomerTrackCurve(
	ID							,
    CustomerId	                ,
	Title					    ,
	TimeStamper		
	)
  VALUES (
	@ID                         ,
    @CustomerId                 ,
	@Title			            ,
	GetDate()				
	)
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerTrackCurveByCustomerId
(
	@CustomerId						UNIQUEIDENTIFIER			
)
AS
BEGIN
	SET NOCOUNT OFF
	Delete From TCustomerTrackCurve 			
	WHERE CustomerId=@CustomerId
    SELECT @@RowCount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCustomerTrackCurveByCustomerId
(
	@CustomerId					UNIQUEIDENTIFIER			
)
AS
BEGIN
	Select
    ID                             as CustomerTrackCurve_ID,
    CustomerId                     as CustomerId,
    Title                          as Customer_Title   
    From TCustomerTrackCurve 			
	WHERE CustomerId=@CustomerId
    
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End      客户跟踪曲线             ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin  客户投诉                   ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertComplain
(
	@PKID				INT OUTPUT,
	@CustomerID			UNIQUEIDENTIFIER,
	@ComplainType			INT,
	@OrderID			INT,
	@ComplainSubject		NVARCHAR(50),
	@ComplainContents		NVARCHAR(255),
	@SubmitDateTime			DATETIME,
	@FeedbackContents		NVARCHAR(255),
	@FeedbackDateTime			DATETIME
)
AS
BEGIN
    INSERT INTO TComplain(
	[CustomerID],
	[ComplainType],
	[OrderID],
	[ComplainSubject],
	[ComplainContents],
	[SubmitDateTime],
	[FeedbackContents],
	[FeedbackDateTime]
	)
    VALUES (
	@CustomerID,
	@ComplainType,
	@OrderID,
	@ComplainSubject,
	@ComplainContents,
	@SubmitDateTime,
	@FeedbackContents,
	@FeedbackDateTime	
	)
    SELECT @PKID=SCOPE_IDENTITY()
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE [dbo].[UpdateComplain]
(
	@PKID				INT,
	@CustomerID			UNIQUEIDENTIFIER,
	@ComplainType			INT,
	@OrderID			INT,
	@ComplainSubject		NVARCHAR(50),
	@ComplainContents		NVARCHAR(255),
	@FeedbackContents		NVARCHAR(255),
	@FeedbackDateTime			DATETIME
)
AS
BEGIN
    UPDATE [TComplain]
    SET
	[CustomerID]=@CustomerID,
	[ComplainType]=@ComplainType,
	[OrderID]=@OrderID,
	[ComplainSubject]=@ComplainSubject,
	[ComplainContents]=@ComplainContents,
	[FeedbackContents]=@FeedbackContents,
	[FeedbackDateTime]=@FeedbackDateTime
    WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteComplainByID
(
    @PKID			 int
)
AS
Begin
    delete from TComplain
	where PKID = @PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS OFF 
--GO
--CREATE PROCEDURE DeleteFeedbackByComplainID
--(
    --@ComplainID			 int
--)
--AS
--Begin
    --delete from TFeedback
	--where ComplainID = @ComplainID
--End
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetComplainListByCustomerID
(
	    @CustomerID UNIQUEIDENTIFIER
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TComplain
		  where TComplain.CustomerID=@CustomerID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetComplainByPKID
(
	     @PKID	int
)
AS
BEGIN
        SELECT 	*		
		FROM  TComplain
		WHERE TComplain.PKID =@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetNoFeedbackComplainList
AS
BEGIN
          select *
		  from TComplain
		  where TComplain.FeedbackContents is null or TComplain.FeedbackContents = ''
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAllFeedbackComplainByCondition
(
		@FullName					NVARCHAR(50),
		@ComplainType			INT,
		@OrderID					INT
)
AS
BEGIN
        SELECT TComplain.PKID As PKID,	
        			 TComplain.CustomerID As CustomerID,	
        			 TComplain.ComplainType As ComplainType,	
        			 TComplain.OrderID As OrderID,	
        			 TComplain.ComplainSubject As ComplainSubject,	
        			 TComplain.ComplainContents As ComplainContents,	
        			 TComplain.SubmitDateTime As SubmitDateTime,	
        			 TComplain.FeedbackContents As FeedbackContents,	
        			 TComplain.FeedbackDateTime As FeedbackDateTime
				FROM  TComplain,TCustomer
		WHERE TCustomer.FullName LIKE '%' +@FullName + '%'
		AND (@ComplainType = 0 OR TComplain.ComplainType = @ComplainType)
		AND (@OrderID = 0 OR TComplain.OrderID = @OrderID)
		AND (TComplain.CustomerID = TCustomer.ID)
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetIsFeedbackComplainByCondition
(
		@FullName					NVARCHAR(50),
		@ComplainType			INT,
		@OrderID					INT
)
AS
BEGIN
        SELECT TComplain.PKID As PKID,	
        			 TComplain.CustomerID As CustomerID,	
        			 TComplain.ComplainType As ComplainType,	
        			 TComplain.OrderID As OrderID,	
        			 TComplain.ComplainSubject As ComplainSubject,	
        			 TComplain.ComplainContents As ComplainContents,	
        			 TComplain.SubmitDateTime As SubmitDateTime,	
        			 TComplain.FeedbackContents As FeedbackContents,	
        			 TComplain.FeedbackDateTime As FeedbackDateTime
				FROM  TComplain,TCustomer
		WHERE TCustomer.FullName LIKE '%' +@FullName + '%'
		AND (@ComplainType = 0 OR TComplain.ComplainType = @ComplainType)
		AND (@OrderID = 0 OR TComplain.OrderID = @OrderID)
		AND (TComplain.FeedbackContents != '')
		AND (TComplain.CustomerID = TCustomer.ID)
END
GO
SET QUOTED_IDENTIFIER OFF 

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetNoFeedbackComplainByCondition
(
		@FullName					NVARCHAR(50),
		@ComplainType			INT,
		@OrderID					INT
)
AS
BEGIN
        SELECT TComplain.PKID As PKID,	
        			 TComplain.CustomerID As CustomerID,	
        			 TComplain.ComplainType As ComplainType,	
        			 TComplain.OrderID As OrderID,	
        			 TComplain.ComplainSubject As ComplainSubject,	
        			 TComplain.ComplainContents As ComplainContents,	
        			 TComplain.SubmitDateTime As SubmitDateTime,	
        			 TComplain.FeedbackContents As FeedbackContents,	
        			 TComplain.FeedbackDateTime As FeedbackDateTime
				FROM  TComplain,TCustomer
		WHERE TCustomer.FullName LIKE '%' +@FullName + '%'
		AND (@ComplainType = 0 OR TComplain.ComplainType = @ComplainType)
		AND (@OrderID = 0 OR TComplain.OrderID = @OrderID)
		AND (TComplain.FeedbackContents = '')
		AND (TComplain.CustomerID = TCustomer.ID)
END
GO
SET QUOTED_IDENTIFIER OFF 

/***********************************************************************************/
/************         End  客户投诉                     ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin  客户反馈                   ****************************/
/***********************************************************************************/

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS OFF 
--GO
--CREATE PROCEDURE InsertFeedback
--(
	--@PKID				INT OUTPUT,
	--@ComplainID			INT,
	--@CustomerID			UNIQUEIDENTIFIER,
	--@Contents			NVARCHAR(255),
	--@SubmitDateTime			DateTime
--)
--AS
--BEGIN
    --INSERT INTO TFeedback(
	--[ComplainID],
	--[CustomerID],
	--[Contents],
	--[SubmitDateTime]
	--)
    --VALUES (
	--@ComplainID,
	--@CustomerID,
	--@Contents,
	--@SubmitDateTime
	--)
    --SELECT @PKID=SCOPE_IDENTITY()
--END
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS OFF 
--GO
--CREATE PROCEDURE [dbo].[UpdateFeedback]
--(
	--@PKID				INT,
	--@ComplainID			INT,
	--@CustomerID			UNIQUEIDENTIFIER,
	--@Contents			NVARCHAR(255),
	--@SubmitDateTime			DateTime
--)
--AS
--BEGIN
    --UPDATE [TFeedback]
    --SET
	--[ComplainID]=@ComplainID,
	--[CustomerID]=@CustomerID,
	--[Contents]=@Contents,
	--[SubmitDateTime]=@SubmitDateTime
    --WHERE PKID=@PKID
--END
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS OFF 
--GO
--CREATE PROCEDURE DeleteFeedbackByPkid
--(
    --@PKID			 int
--)
--AS
--Begin
    --delete from TFeedback
	--where PKID = @PKID
--End
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS OFF 
--GO
--CREATE PROCEDURE GetFeedbackByComplainID
--(
	    --@ComplainID INT
--)
--AS
--Begin
          --SET NOCOUNT OFF
          --select *
		  --from TFeedback
		  --where TFeedback.ComplainID=@ComplainID
--End
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

/***********************************************************************************/
/************         End  客户反馈                     ****************************/
/***********************************************************************************/