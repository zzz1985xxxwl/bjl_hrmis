/***********************************************************************************
**                                                                                **
**                               删除存储过程                                     **
**                                                                                **
***********************************************************************************/
--Begin              权限        ------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetAccountAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetAccountAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CancelAccountAllAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CancelAccountAllAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentByBackAccontsIDAndAuthID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentByBackAccontsIDAndAuthID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountsByAuthIdAndDeptId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountsByAuthIdAndDeptId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllAuth]
GO
--End              权限        ------------

--Begin              客户账户        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllCustomerAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllCustomerAccount]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountByEmailAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountByEmailAddress]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCustomerAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCustomerAccount]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCustomerAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCustomerAccount]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountListByLevelID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountListByLevelID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerAccountByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCustomerAccountByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetCustomerAccountValid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetCustomerAccountValid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetDefaultCustomerInvoiceConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetDefaultCustomerInvoiceConfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetDefaultCustomerShippingAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetDefaultCustomerShippingAddress]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BindCustomerToAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[BindCustomerToAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCustomerAccountByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountByPkid]
GO

--End                客户账户        ------------

--Begin              账户等级        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerAccountLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCustomerAccountLevel]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerLevelByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerLevelByID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCustomerAccountLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCustomerAccountLevel]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCustomerAccountLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCustomerAccountLevel]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountLevelByFinalFee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountLevelByFinalFee]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllCustomerAccountLevel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllCustomerAccountLevel]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountLevelByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountLevelByAccountID]
GO

--End                账户等级        ------------

--Begin              发票配置        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerInvoiceConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCustomerInvoiceConfig]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerInvoiceConfigListByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerInvoiceConfigListByAccountID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCustomerInvoiceConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCustomerInvoiceConfig]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCustomerInvoiceConfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCustomerInvoiceConfig]
GO

--End                发票配置        ------------

--Begin              送货地址        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCustomerShippingAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCustomerShippingAddress]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerShippingAddressListByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerShippingAddressListByAccountID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCustomerShippingAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCustomerShippingAddress]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCustomerShippingAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCustomerShippingAddress]
GO

--End                送货地址        ------------


----BEGIN             商品          ---------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CategoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CategoryUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CategoryDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCategoryByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCategoryByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCategoryByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCategoryByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategoryByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategoryByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSubCategoryByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSubCategoryByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProductInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProductUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProductDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountProductByFullName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountProductByFullName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountProductByFullNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountProductByFullNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetProductCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetProductCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteProductCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteProductCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetProductPicture]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetProductPicture]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteProductPicture]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteProductPicture]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductCategorysByProductId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductCategorysByProductId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPictureByProductId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPictureByProductId]
GO
----END               商品          ---------------

----begin              供应商          -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProviderInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProviderInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProviderUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProviderUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProviderDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProviderDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountProviderByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountProviderByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountProviderByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountProviderByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetProviderProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetProviderProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProviderByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProviderByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProviderProductsByProviderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProviderProductsByProviderId]
GO
----end                供应商          -------------

--Begin              销售订单        -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalesOrderInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SalesOrderInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalesOrderUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SalesOrderUpdate]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalesOrderItemInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SalesOrderItemInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalesOrderDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SalesOrderDelete]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteSalesOrderNotesBySalesOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteSalesOrderNotesBySalesOrderId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteSalesOrderItemsBySalesOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteSalesOrderItemsBySalesOrderId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSalesOrderById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSalesOrderById]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSalesOrdersByCustomerAccountId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSalesOrdersByCustomerAccountId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSalesOrderByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSalesOrderByCondition]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSalesOrderNotesBySalesOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSalesOrderNotesBySalesOrderId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSalesOrderItemsBySalesOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSalesOrderItemsBySalesOrderId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalesOrderNoteInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SalesOrderNoteInsert]
GO
----End              销售订单        -------------

--Begin              价套        -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceCodeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PriceCodeInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PriceCodeUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PriceCodeUpdate]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePriceCodeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePriceCodeById]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllPriceCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllPriceCode]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPriceCodeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPriceCodeById]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductPriceInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ProductPriceInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteProductPricesByPriceCodeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteProductPricesByPriceCodeId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPriceCodeByTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPriceCodeByTime]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductPriceByProductId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductPriceByProductId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerAccountMappingPriceCodeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CustomerAccountMappingPriceCodeInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerAccountPriceCodeDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CustomerAccountPriceCodeDelete]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPriceCodeIdsByCustomerAccountId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPriceCodeIdsByCustomerAccountId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetProductPricesByPriceCodeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetProductPricesByPriceCodeId]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerAccountIdsByPriceCodeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerAccountIdsByPriceCodeId]
GO
----End              价套        -------------
/***********************************************************************************/
/************              Begin     库存模块           ****************************/
/***********************************************************************************/
/****** 对象:  StoredProcedure [InsertWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertWarehouse]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertWarehouse]
GO
/****** 对象:  StoredProcedure [UpdateWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateWarehouse]') AND type in (N'P', N'PC'))
DROP PROCEDURE [UpdateWarehouse]
GO
/****** 对象:  StoredProcedure [DeleteWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteWarehouse]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DeleteWarehouse]
GO
/****** 对象:  StoredProcedure [SetValidWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SetValidWarehouse]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SetValidWarehouse]
GO
/****** 对象:  StoredProcedure [GetWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetWarehouse]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetWarehouse]
GO
/****** 对象:  StoredProcedure [GetWarehouseList]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetWarehouseList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetWarehouseList]
GO
/****** 对象:  StoredProcedure [InsertDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertDistribution]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertDistribution]
GO
/****** 对象:  StoredProcedure [UpdateDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDistribution]') AND type in (N'P', N'PC'))
DROP PROCEDURE [UpdateDistribution]
GO
/****** 对象:  StoredProcedure [SetDistributionValidityType]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SetDistributionValidityType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SetDistributionValidityType]
GO
/****** 对象:  StoredProcedure [SetDistributionOutStockStatus]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SetDistributionOutStockStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [SetDistributionOutStockStatus]
GO
/****** 对象:  StoredProcedure [GetDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDistribution]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetDistribution]
GO
/****** 对象:  StoredProcedure [InsertDistributionItem]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertDistributionItem]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertDistributionItem]
GO
/****** 对象:  StoredProcedure [DeleteDistributionItems]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDistributionItems]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DeleteDistributionItems]
GO
/****** 对象:  StoredProcedure [InsertStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertStockTrans]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertStockTrans]
GO
/****** 对象:  StoredProcedure [UpdateStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateStockTrans]') AND type in (N'P', N'PC'))
DROP PROCEDURE [UpdateStockTrans]
GO
/****** 对象:  StoredProcedure [GetStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetStockTrans]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetStockTrans]
GO
/****** 对象:  StoredProcedure [InsertProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertProductStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertProductStock]
GO
/****** 对象:  StoredProcedure [UpdateProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateProductStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [UpdateProductStock]
GO
/****** 对象:  StoredProcedure [ModifyReserve]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ModifyReserve]') AND type in (N'P', N'PC'))
DROP PROCEDURE [ModifyReserve]
GO
/****** 对象:  StoredProcedure [GetProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetProductStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetProductStock]
GO
/****** 对象:  StoredProcedure [InsertBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InsertBatchStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [InsertBatchStock]
GO
/****** 对象:  StoredProcedure [UpdateBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateBatchStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [UpdateBatchStock]
GO
/****** 对象:  StoredProcedure [GetBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetBatchStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetBatchStock]
GO
/****** 对象:  StoredProcedure [GetBatchStockList]    脚本日期: 14/07/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetBatchStockList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetBatchStockList]
GO
/***********************************************************************************/
/************              End       库存模块           ****************************/
/***********************************************************************************/

----BEGIN              采购订单         --------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PurchaseOrderInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PurchaseOrderInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PurchaseOrderUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PurchaseOrderUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PurchaseOrderItemInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PurchaseOrderItemInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PurchaseOrderDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PurchaseOrderDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePurchaseOrderItemsByPurchaseOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePurchaseOrderItemsByPurchaseOrderId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPurchaseOrderById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPurchaseOrderById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPurchaseOrdeByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPurchaseOrdeByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPurchaseOrderItemsByPurchaseOrderId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPurchaseOrderItemsByPurchaseOrderId]
GO
----END                采购订单         --------------
/***********************************************************************************
**                                                                                **
**                               创建存储过程                                     **
**                                                                                **
***********************************************************************************/

--Begin               客户账户         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAllCustomerAccount
(
	    @valid INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccount
		  where TCustomerAccount.valid=@valid
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
CREATE PROCEDURE GetCustomerAccountByEmailAddress
(
	    @Email NVARCHAR(50)
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccount
		  where TCustomerAccount.Email=@Email
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
CREATE PROCEDURE InsertCustomerAccount
(
	@PKID				INT OUTPUT,
	@Email				NVARCHAR(50),
	@Password			NVARCHAR(2000),
	@CustomerLevelID		INT,
	@RegistrationDate		DateTime,
	@FavorShippingAddressID		INT,
	@FavorInvoiceConfigID		INT,
	@IsDisplayPrice			INT,
	@Valid				INT,
	@TotalPrice				Decimal
)
AS
BEGIN
    INSERT INTO TCustomerAccount(
	[Email],
	[Password],
	[CustomerLevelID],
	[RegistrationDate],
	[FavorShippingAddressID],
	[FavorInvoiceConfigID],
	[IsDisplayPrice],
	[Valid],
	[TotalPrice]
	)
    VALUES (
	@Email,
	@Password,
	@CustomerLevelID,
	@RegistrationDate,
	@FavorShippingAddressID,
	@FavorInvoiceConfigID,
	@IsDisplayPrice,
	@Valid,
	@TotalPrice
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
CREATE PROCEDURE [dbo].[UpdateCustomerAccount]
(
	@PKID				INT,
	@Email				NVARCHAR(50),
	@Password			NVARCHAR(2000),
	@CustomerLevelID		INT,
	@RegistrationDate		DateTime,
	@FavorShippingAddressID		INT,
	@FavorInvoiceConfigID		INT,
	@IsDisplayPrice			INT,
	@Valid				INT,
	@TotalPrice				Decimal
)
AS
BEGIN
    UPDATE [TCustomerAccount]
    SET
	[Email]=@Email,
	[Password]=@Password,
	[CustomerLevelID]=@CustomerLevelID,
	[RegistrationDate]=@RegistrationDate,
	[FavorShippingAddressID]=@FavorShippingAddressID,
	[FavorInvoiceConfigID]=@FavorInvoiceConfigID,
	[IsDisplayPrice]=@IsDisplayPrice,
	[Valid]=@Valid,
	[TotalPrice]=@TotalPrice
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
CREATE PROCEDURE GetCustomerAccountListByLevelID
(
	    @CustomerLevelID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccount
		  where TCustomerAccount.CustomerLevelID=@CustomerLevelID
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
CREATE PROCEDURE DeleteCustomerAccountByID
(
    @PKID			 int
)
AS
Begin
    delete from TCustomerAccount
	where PKID = @PKID
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
CREATE PROCEDURE GetCustomerAccountById
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccount
		  where TCustomerAccount.PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE [dbo].[SetCustomerAccountValid]
(
	@PKID				INT,
	@Valid				INT
)
AS
BEGIN
    UPDATE [TCustomerAccount]
    SET
	[Valid]=@Valid
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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE [dbo].[SetDefaultCustomerInvoiceConfig]
(
	@PKID				INT,
	@FavorInvoiceConfigID		INT
)
AS
BEGIN
    UPDATE [TCustomerAccount]
    SET
	[FavorInvoiceConfigID]=@FavorInvoiceConfigID
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
CREATE PROCEDURE [dbo].[SetDefaultCustomerShippingAddress]
(
	@PKID				INT,
	@FavorShippingAddressID		INT
)
AS
BEGIN
    UPDATE [TCustomerAccount]
    SET
	[FavorShippingAddressID]=@FavorShippingAddressID
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
CREATE PROCEDURE [dbo].[BindCustomerToAccount]
(
	@PKID				INT,
	@CustomerID			UNIQUEIDENTIFIER
)
AS
BEGIN
    UPDATE [TCustomerAccount]
    SET
	[CustomerID]=@CustomerID
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
CREATE PROCEDURE GetCustomerAccountByCondition
(
		@Email			NVARCHAR(50) = null,
		@CustomerLevelID	INT = null
)
AS
BEGIN
        SELECT	TCustomerAccount.PKID AS PKID,
		TCustomerAccount.Email AS Email,
		TCustomerAccount.Password AS Password,
		TCustomerAccount.CustomerLevelID AS CustomerLevelID,
		TCustomerAccount.RegistrationDate AS RegistrationDate,
		TCustomerAccount.FavorShippingAddressID AS FavorShippingAddressID,
		TCustomerAccount.FavorInvoiceConfigID AS FavorInvoiceConfigID,
		TCustomerAccount.IsDisplayPrice AS IsDisplayPrice,
		TCustomerAccount.valid AS valid,
		TCustomerAccount.CustomerID AS CustomerID,
		TCustomerAccount.TotalPrice AS TotalPrice,
		TCustomerAccountLevel.CustomerAccountLevelName AS CustomerAccountLevelName,
		TCustomerAccountLevel.MinimumAmount AS MinimumAmount
		FROM  TCustomerAccount left join TCustomerAccountLevel on TCustomerAccount.CustomerLevelID=TCustomerAccountLevel.PKID
		WHERE (@Email IS NULL OR TCustomerAccount.Email = @Email) AND
		      (@CustomerLevelID IS NULL OR TCustomerAccount.CustomerLevelID = @CustomerLevelID)
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
CREATE PROCEDURE GetCustomerAccountByPkid
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccount
		  where TCustomerAccount.PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              客户账户        -------------

--Begin               账户等级         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerAccountLevel
(
    @PKID			 int
)
AS
Begin
    delete from TCustomerAccountLevel
	where PKID = @PKID
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
CREATE PROCEDURE GetCustomerLevelByID
(
    @PKID			 int
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerAccountLevel
		  where PKID=@PKID
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
CREATE PROCEDURE InsertCustomerAccountLevel
(
	@PKID				INT OUTPUT,
	@CustomerAccountLevelName	NVARCHAR(50),
	@MinimumAmount			Decimal
)
AS
BEGIN
    INSERT INTO TCustomerAccountLevel(
	[CustomerAccountLevelName],
	[MinimumAmount]
	)
    VALUES (
	@CustomerAccountLevelName,
	@MinimumAmount
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
CREATE PROCEDURE [dbo].[UpdateCustomerAccountLevel]
(
	@PKID				INT,
	@CustomerAccountLevelName	NVARCHAR(50),
	@MinimumAmount			Decimal
)
AS
BEGIN
    UPDATE [TCustomerAccountLevel]
    SET
	[CustomerAccountLevelName]=@CustomerAccountLevelName,
	[MinimumAmount]=@MinimumAmount
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
CREATE PROCEDURE GetCustomerAccountLevelByFinalFee
(
    @MinimumAmount			 decimal
)
AS
Begin
          SET NOCOUNT OFF
          select top 1 *
		  		from TCustomerAccountLevel
		  		where @MinimumAmount >= MinimumAmount
		  		order by MinimumAmount desc
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
CREATE PROCEDURE GetAllCustomerAccountLevel
AS
Begin
          SELECT *
          from TCustomerAccountLevel
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
CREATE PROCEDURE GetCustomerAccountLevelByAccountID
(
    @PKID			 int
)
AS
Begin
          SET NOCOUNT OFF
          select TCustomerAccountLevel.PKID as PKID,
		 TCustomerAccountLevel.CustomerAccountLevelName as CustomerAccountLevelName,
		 TCustomerAccountLevel.MinimumAmount as MinimumAmount
		  from TCustomerAccountLevel,TCustomerAccount
		  where TCustomerAccount.PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              账户等级        -------------

--Begin               发票配置         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerInvoiceConfig
(
    @PKID			 int
)
AS
Begin
    delete from TCustomerInvoiceConfig
	where PKID = @PKID
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
CREATE PROCEDURE GetCustomerInvoiceConfigListByAccountID
(
	    @CustomerAccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerInvoiceConfig
		  where TCustomerInvoiceConfig.CustomerAccountID=@CustomerAccountID
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
CREATE PROCEDURE InsertCustomerInvoiceConfig
(
	@PKID				INT OUTPUT,
	@CustomerAccountID		INT,
	@NeedInvoice			INT,
	@InvoiceTitle			Nvarchar(255),
	@VATCode			Nvarchar(50)
)
AS
BEGIN
    INSERT INTO TCustomerInvoiceConfig(
	[CustomerAccountID],
	[NeedInvoice],
	[InvoiceTitle],
	[VATCode]
	)
    VALUES (
	@CustomerAccountID,
	@NeedInvoice,
	@InvoiceTitle,
	@VATCode
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
CREATE PROCEDURE [dbo].[UpdateCustomerInvoiceConfig]
(
	@PKID				INT,
	@CustomerAccountID		INT,
	@NeedInvoice			INT,
	@InvoiceTitle			NVARCHAR(255),
	@VATCode			Nvarchar(50)
)
AS
BEGIN
    UPDATE [TCustomerInvoiceConfig]
    SET
	[CustomerAccountID]=@CustomerAccountID,
	[NeedInvoice]=@NeedInvoice,
	[InvoiceTitle]=@InvoiceTitle,
	[VATCode]=@VATCode
    WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              发票配置        -------------

--Begin               送货地址         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteCustomerShippingAddress
(
    @PKID			 int
)
AS
Begin
    delete from TCustomerShippingAddress
	where PKID = @PKID
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
CREATE PROCEDURE GetCustomerShippingAddressListByAccountID
(
	    @CustomerAccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TCustomerShippingAddress
		  where TCustomerShippingAddress.CustomerAccountID=@CustomerAccountID
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
CREATE PROCEDURE InsertCustomerShippingAddress
(
	@PKID				INT OUTPUT,
	@CustomerAccountID		INT,
	@ContactName			Nvarchar(50),
	@ContactPhone			Nvarchar(50),
	@ShippingAddress		Nvarchar(255)
)
AS
BEGIN
    INSERT INTO TCustomerShippingAddress(
	[CustomerAccountID],
	[ContactName],
	[ContactPhone],
	[ShippingAddress]
	)
    VALUES (
	@CustomerAccountID,
	@ContactName,
	@ContactPhone,
	@ShippingAddress
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
CREATE PROCEDURE [dbo].[UpdateCustomerShippingAddress]
(
	@PKID				INT,
	@CustomerAccountID		INT,
	@ContactName			NVARCHAR(50),
	@ContactPhone			NVARCHAR(50),
	@ShippingAddress		NVARCHAR(255)
)
AS
BEGIN
    UPDATE [TCustomerShippingAddress]
    SET
	[CustomerAccountID]=@CustomerAccountID,
	[ContactName]=@ContactName,
	[ContactPhone]=@ContactPhone,
	[ShippingAddress]=@ShippingAddress
    WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              送货地址        -------------

--Begin              权限        -------------
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE GetAccountAuth
(
	@AccountId INT
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT DISTINCT B.PKID,B.AuthName,B.AuthParentId,B.NavigateUrl,B.IfHasDepartment,A.DepartmentID
	FROM TAccountAuth A 
		LEFT JOIN TAuth B ON A.AuthID = B.PKID
	WHERE AccountId=@AccountId
	ORDER BY B.AuthParentId ASC
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE SetAccountAuth
(
	@AccountId INT,
	@AuthId INT,
	@DepartmentID INT
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO TAccountAuth
			   ([AccountId]
			   ,[AuthId]
			   ,[DepartmentID]
				)
		 VALUES
			   (@AccountId
			   ,@AuthId
			   ,@DepartmentID
			   )
	RETURN @@Rowcount
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE CancelAccountAllAuth
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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetDepartmentByBackAccontsIDAndAuthID
(
	    @AccountId INT,
	    @AuthID INT
)
AS
Begin
         SELECT DepartmentID
	     FROM TAccountAuth
         WHERE TAccountAuth.AccountID = @AccountId
		   AND TAccountAuth.AuthID = @AuthID
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
CREATE PROCEDURE GetAccountsByAuthIdAndDeptId
(
	@AuthId int,
	@DepartmentID int=null
)
AS
Begin
    SELECT DISTINCT AccountId FROM TAccountAuth
	WHERE authid=@AuthId 
		AND (@DepartmentID IS NULL OR DepartmentID=0 OR DepartmentID=@DepartmentID)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetAllAuth
AS
BEGIN
    SET NOCOUNT ON;
	SELECT *
	FROM TAuth
	ORDER BY AuthParentId ASC, PKID ASC
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              权限        -------------


--BEGIN             商品        -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CategoryInsert
(
    @PKID              INT out,
	@CategoryName      Nvarchar(100)  ,
	@Description       Nvarchar(200)  ,	
	@ParentId          INT  ,	
	@IsPublished        int  ,	
	@CreatedOn          datetime  ,	
	@UpdatedOn          datetime    
)
AS
Begin
  INSERT INTO TCategory
(	
	[Name]				        ,
	[Description]				,
	ParentCategoryID 			,
	Published		            ,
	CreatedOn                   ,
    UpdatedOn    					
	)
    VALUES (	
	@CategoryName  				,
	@Description   				,
	@ParentId					,
	@IsPublished				,
	@CreatedOn	                ,
	@UpdatedOn	)
     select @PKID=SCOPE_IDENTITY()    
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
CREATE PROCEDURE CategoryUpdate
(
    @PKID              INT ,
	@CategoryName      Nvarchar(100)  ,
	@Description       Nvarchar(200)  ,	
	@ParentId          INT  ,	
	@IsPublished        int  ,	
	@CreatedOn          datetime  ,	
	@UpdatedOn          datetime    
)
AS
Begin
  UPDATE TCategory
        SET
			[Name]=@CategoryName
			,[Description]=@Description 
			,ParentCategoryID=@ParentId
            ,Published=@IsPublished
            ,CreatedOn=@CreatedOn
            ,UpdatedOn=@UpdatedOn
		WHERE PKID=@PKID     
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
CREATE PROCEDURE CategoryDelete
(
	    @PKID    INT     
)
AS
BEGIN
         DELETE FROM TCategory  WHERE PKID=@PKID
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
CREATE PROCEDURE CountCategoryByName
(
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCategory
	      WHERE [Name] = @Name
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
CREATE PROCEDURE CountCategoryByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCategory
	      WHERE [Name] = @Name and PKID <> @PKID
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
CREATE PROCEDURE GetCategoryByID
(
        @PKID      int
)
As
BEGIN 
     SELECT PKID,[Name],[Description],ParentCategoryID,Published ,CreatedOn,UpdatedOn FROM TCategory
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
CREATE PROCEDURE GetSubCategoryByID
(
        @ParentId      int
)
As
BEGIN 
     SELECT PKID,[Name],[Description],ParentCategoryID,Published ,CreatedOn,UpdatedOn FROM TCategory
     WHERE ParentCategoryID=@ParentId 
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
CREATE PROCEDURE GetAllCategory
As
BEGIN 
     SELECT PKID,[Name],[Description],ParentCategoryID,Published ,CreatedOn,UpdatedOn FROM TCategory
     order By PKID
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
CREATE PROCEDURE ProductInsert
(
        @PKID	                INT	  out ,
        @BarCode                 Nvarchar(50) ,           
        @ManufacturerPartNumber  Nvarchar(50) ,			
		@FullName                Nvarchar(100) ,            
        @FullNameE               NVARCHAR ( 100 ) ,			
		@ShortDescription        Nvarchar(200) , 			
		@FullDescription         TEXT   ,			
		@Published               int   ,			
		@ShowOnHomePage          int ,			
        @AccountCode            NVARCHAR ( 50 ) ,			
        @StockUnit             NVARCHAR ( 50 ) ,			
		@PurchaseUnit          NVARCHAR ( 50 ),			
		@SaleUnit              NVARCHAR ( 50 ) ,  			
		@AverageLandedCost     MONEY  ,			
		@AveragePurchasePrice   MONEY ,   			
		@MarketPrice            MONEY ,			
		@SalePrice             MONEY  ,         
		@Weight                decimal(18, 4)  ,	           
        @Size                 NVARCHAR ( 50 ) ,            
        @Color                 NVARCHAR ( 50 )  ,           
        @SortFlag              INT    ,			
		@CreatedOn               datetime       ,			
		@UpdatedOn               datetime       
)
As
BEGIN 
      INSERT INTO TProduct
   (	
	    BarCode                   ,           
        ManufacturerPartNumber    ,			
		FullName                  ,            
        FullNameE                 ,			
		ShortDescription          , 			
		FullDescription           ,			
		Published                 ,			
		ShowOnHomePage            ,			
        AccountCode               ,			
        StockUnit                 ,			
	    PurchaseUnit              ,			
		SaleUnit                  ,  			
		AverageLandedCost         ,			
		AveragePurchasePrice      ,   			
		MarketPrice               ,			
		SalePrice                 ,         
		Weight                    ,	           
        [Size]                    ,            
        Color                     ,           
        SortFlag                  ,			
		CreatedOn                 ,			
		UpdatedOn                     					
	)
    VALUES (	
	    @BarCode                  ,           
        @ManufacturerPartNumber   ,			
		@FullName                 ,            
        @FullNameE                ,			
		@ShortDescription         , 			
		@FullDescription          ,			
		@Published                ,			
		@ShowOnHomePage           ,			
        @AccountCode              ,			
        @StockUnit                ,			
		@PurchaseUnit             ,			
		@SaleUnit                 ,  			
		@AverageLandedCost        ,			
		@AveragePurchasePrice     ,   			
		@MarketPrice              ,			
		@SalePrice                ,         
		@Weight                   ,	           
        @Size                     ,            
        @Color                    ,           
        @SortFlag                 ,			
		@CreatedOn                ,			
		@UpdatedOn                     	  			
	)
     select @PKID=SCOPE_IDENTITY()  
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
        @PKID	                INT	   ,
        @BarCode                 Nvarchar(50) ,           
        @ManufacturerPartNumber  Nvarchar(50) ,			
		@FullName                Nvarchar(100) ,            
        @FullNameE               NVARCHAR ( 100 ) ,			
		@ShortDescription        Nvarchar(200) , 			
		@FullDescription         TEXT   ,			
		@Published               int   ,			
		@ShowOnHomePage          int ,			
        @AccountCode            NVARCHAR ( 50 ) ,			
        @StockUnit             NVARCHAR ( 50 ) ,			
		@PurchaseUnit          NVARCHAR ( 50 ),			
		@SaleUnit              NVARCHAR ( 50 ) ,  			
		@AverageLandedCost     MONEY  ,			
		@AveragePurchasePrice   MONEY ,   			
		@MarketPrice            MONEY  ,			
		@SalePrice             MONEY ,         
		@Weight                decimal(18, 4)   ,	           
        @Size                 NVARCHAR ( 50 ) ,            
        @Color                 NVARCHAR ( 50 )  ,           
        @SortFlag              INT    ,			
		@CreatedOn               datetime       ,			
		@UpdatedOn               datetime       
)
As
BEGIN    
        SET NOCOUNT OFF
        Update TProduct 
        Set
		BarCode=@BarCode,           
        ManufacturerPartNumber=@ManufacturerPartNumber,			
		FullName=@FullName,            
        FullNameE=@FullNameE,			
		ShortDescription=@ShortDescription , 			
		FullDescription=@FullDescription,			
		Published=@Published ,			
		ShowOnHomePage=@ShowOnHomePage  ,			
        AccountCode=@AccountCode,			
        StockUnit=@StockUnit ,			
		PurchaseUnit=@PurchaseUnit,			
		SaleUnit=@SaleUnit  ,  			
		AverageLandedCost=@AverageLandedCost ,			
		AveragePurchasePrice=@AveragePurchasePrice,   			
		MarketPrice=@MarketPrice,			
		SalePrice=@SalePrice,         
		Weight=@Weight,	           
        [Size]= @Size ,            
        Color= @Color,           
        SortFlag=@SortFlag,			
		CreatedOn=@CreatedOn,			
		UpdatedOn=@UpdatedOn   
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
CREATE PROCEDURE ProductDelete
(
	    @PKID    INT     
)
AS
BEGIN
         DELETE FROM TProduct  WHERE PKID=@PKID
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
CREATE PROCEDURE CountProductByFullName
(
	    @FullName Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TProduct
	      WHERE [FullName] = @FullName
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
CREATE PROCEDURE CountProductByFullNameDiffPKID
(
	    @PKID INT,
	    @FullName Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TProduct
	      WHERE [FullName] = @FullName and PKID <> @PKID
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
CREATE PROCEDURE GetProductByID
(
	    @PKID    INT     
)
AS
BEGIN
   SELECT
        PKID                      ,
        BarCode                   ,           
        ManufacturerPartNumber    ,			
		FullName                  ,            
        FullNameE                 ,			
		ShortDescription          , 			
		FullDescription           ,			
		Published                 ,			
		ShowOnHomePage            ,			
        AccountCode               ,			
        StockUnit                 ,			
	    PurchaseUnit              ,			
		SaleUnit                  ,  			
		AverageLandedCost         ,			
		AveragePurchasePrice      ,   			
		MarketPrice               ,			
		SalePrice                 ,         
		Weight                    ,	           
        [Size]                    ,            
        Color                     ,           
        SortFlag                  ,			
		CreatedOn                 ,			
		UpdatedOn                 
  FROM TProduct
  WHERE PKID= @PKID  
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
CREATE PROCEDURE SetProductCategory
(
	    @PKID    INT out,
        @ProductId  int,
        @CategoryId  int ,
        @IsTrueCategory  int
)
AS
BEGIN
         INSERT INTO TProduct_Category_Mapping
(	
	ProductID			    ,
	CategoryID				,
	IsTrueCategory			
	
	)
    VALUES (	
	@ProductId  				,
	@CategoryId   				,
	@IsTrueCategory		
			)	
     select @PKID=SCOPE_IDENTITY()   
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
CREATE PROCEDURE DeleteProductCategory
(
	    @ProductId    INT 
)
AS
BEGIN
         DELETE FROM TProduct_Category_Mapping  WHERE ProductID=@ProductId 
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
CREATE PROCEDURE SetProductPicture
(
	    @PKID    INT out,
        @ProductId  int,
        @PictureBinary image,
        @IsDefault  int 
        
)
AS
BEGIN
         INSERT INTO TProductPicture
(	
	ProductID			    ,
	PictureBinary			,
	IsDefault			
	
	)
    VALUES (	
	@ProductId  				,
	@PictureBinary   				,
	@IsDefault		
			)	
     select @PKID=SCOPE_IDENTITY()   
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
CREATE PROCEDURE DeleteProductPicture
(
	    @ProductId    INT 
)
AS
BEGIN
         DELETE FROM TProductPicture  WHERE ProductID=@ProductId 
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
CREATE PROCEDURE GetProductCategorysByProductId
(
	    @ProductId    INT     
)
AS
BEGIN
   SELECT 
        TProduct_Category_Mapping.ProductID,
        TProduct_Category_Mapping.CategoryID,
        TProduct_Category_Mapping.IsTrueCategory,
        TCategory.Name         
        
  FROM TProduct_Category_Mapping,TCategory 
  WHERE TProduct_Category_Mapping.ProductID= @ProductId and TProduct_Category_Mapping.CategoryID = TCategory.PKID
  
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
CREATE PROCEDURE GetPictureByProductId
(
	    @ProductId    INT     
)
AS
BEGIN
   SELECT 
          PKID,
          ProductID,
          PictureBinary,
          IsDefault
        
  FROM TProductPicture 
  WHERE ProductID=@ProductId
  
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              商品        -------------

---begin          供应商         ------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ProviderInsert
(
	@PKID				INT OUTPUT,  
	@Name	       NVARCHAR(255),
	@Address	  NVARCHAR(255),
	@ZipPostalCode	NVARCHAR(50),
	@Email	      NVARCHAR(50),
	@Linkman	 NVARCHAR(50),
    @PhoneNumber	NVARCHAR(50),
    @MobileNumber	NVARCHAR(50),
    @PIAAccountCode	NVARCHAR(50),
    @AccountCode	NVARCHAR(50),
    @VATRegNumber	NVARCHAR(50),
    @VATCode	 NVARCHAR(50),
    @Remark	     NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO TProvider(
    [Name] ,
	[Address],
	ZipPostalCode ,
	Email ,
	Linkman ,
	PhoneNumber,
	MobileNumber,
	PIAAccountCode,
	AccountCode ,
	VATRegNumber,
	VATCode ,
	Remark 
	)
    VALUES (
    @Name	       ,
	@Address	  ,
	@ZipPostalCode	,
	@Email	      ,
	@Linkman	 ,
    @PhoneNumber	,
    @MobileNumber	,
    @PIAAccountCode	,
    @AccountCode	,
    @VATRegNumber	,
    @VATCode	 ,
    @Remark	     
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
CREATE PROCEDURE ProviderUpdate
(
    @PKID				INT ,
	@Name	       NVARCHAR(255),
	@Address	  NVARCHAR(255),
	@ZipPostalCode	NVARCHAR(50),
	@Email	      NVARCHAR(50),
	@Linkman	 NVARCHAR(50),
    @PhoneNumber	NVARCHAR(50),
    @MobileNumber	NVARCHAR(50),
    @PIAAccountCode	NVARCHAR(50),
    @AccountCode	NVARCHAR(50),
    @VATRegNumber	NVARCHAR(50),
    @VATCode	 NVARCHAR(50),
    @Remark	     NVARCHAR(50)
)
AS
BEGIN
    UPDATE TProvider
    SET
	[Name]=@Name  ,
	[Address]=@Address ,
	ZipPostalCode = @ZipPostalCode ,
	Email = @Email,
	Linkman = @Linkman,
	PhoneNumber= @PhoneNumber,
	MobileNumber= @MobileNumber,
	PIAAccountCode= @PIAAccountCode,
	AccountCode = @AccountCode,
	VATRegNumber= @VATRegNumber,
	VATCode = @VATCode,
	Remark =@Remark

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
CREATE PROCEDURE  ProviderDelete
(
    @PKID			 int
)
AS
Begin
    delete from TProvider
	where PKID = @PKID
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
CREATE PROCEDURE CountProviderByName
(
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TProvider
	      WHERE [Name] = @Name
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
CREATE PROCEDURE CountProviderByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TProvider
	      WHERE [Name] = @Name and PKID <> @PKID
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
CREATE PROCEDURE SetProviderProduct
(
	    @PKID    INT out,
        @ProviderId  int,
        @ProductId  int ,
        @Price    money,
        @Valid    int
)
AS
BEGIN
         INSERT INTO TProviderProduct
          (	
			ProviderID			    ,
			ProductID				,
			Price                   ,			
			Valid  
	        )
    VALUES (	

			@ProviderID  				,
			@ProductID   				,
			@Price		        ,
			@Valid 
			)	
     select @PKID=SCOPE_IDENTITY()   
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
CREATE PROCEDURE GetProviderByID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TProvider
		  where PKID=@PKID
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
CREATE PROCEDURE GetProviderProductsByProviderId
(
	    @ProductId    INT     
)
AS
BEGIN
    SET NOCOUNT OFF
          select 
         TProviderProduct.Pkid,
         TProduct.FullName              
        
  FROM TProviderProduct,TProduct
  WHERE  TProviderProduct.ProductId = @ProductId and TProviderProduct.ProductID = TProduct.PKID
  
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
-----end         供应商          -----------------

--Begin              销售订单        -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE SalesOrderInsert
(
				@PKID								INT	OUT					,
				@OrderGUID							UNIQUEIDENTIFIER		,
				@CustomerAccountID					INT						,
				@SalesID							INT						,
				@SalesName							NVARCHAR(50)			,
				@GoodsValue							MONEY					,
				@ServiceFee							MONEY					,
				@TotalValue							MONEY					,
				@FlowStatusId						INT						,
				@OrderStatusId						INT						,
				@PaymentStatusId					INT						,
				@OutStockDate						DATETIME = NULL			,
				@InvoiceDate						DATETIME = NULL			,
				@DeliveryDate						DATETIME = NULL			,
				@OrderCompany						NVARCHAR(50)			,
				@ContactName						NVARCHAR(50)			,
				@ContactPhone						NVARCHAR(50)			,
				@ShippingAddress					NVARCHAR(200)			,
				@NeedInvoiceId						INT						,
				@HasInvoiceId						INT						,
				@InvoiceTitle						NVARCHAR(200)			,
				@VATCode							NVARCHAR(50)			,
				@OrderResourceId					INT						,
				@OrderRemark						NVARCHAR(200)			,
				@CreateOn							DATETIME				
)
AS
BEGIN
         INSERT INTO TSalesOrder
			(
         		OrderGUID							,
				CustomerAccountID					,
				SalesID								,
				SalesName							,
				GoodsValue							,
				ServiceFee							,
				TotalValue							,
				FlowStatusId						,
				OrderStatusId						,
				PaymentStatusId						,
				OutStockDate						,
				InvoiceDate							,
				DeliveryDate						,
				OrderCompany						,
				ContactName							,
				ContactPhone						,
				ShippingAddress						,
				NeedInvoiceId						,
				HasInvoiceId						,
				InvoiceTitle						,
				VATCode								,
				OrderResourceId						,
				OrderRemark							,
				CreateOn							
			)
    	 VALUES 
    		(	
         		@OrderGUID							,
				@CustomerAccountID					,
				@SalesID							,
				@SalesName							,
				@GoodsValue							,
				@ServiceFee							,
				@TotalValue							,
				@FlowStatusId						,
				@OrderStatusId						,
				@PaymentStatusId					,
				@OutStockDate						,
				@InvoiceDate						,
				@DeliveryDate						,
				@OrderCompany						,
				@ContactName						,
				@ContactPhone						,
				@ShippingAddress					,
				@NeedInvoiceId						,
				@HasInvoiceId						,
				@InvoiceTitle						,
				@VATCode							,
				@OrderResourceId					,
				@OrderRemark						,
				@CreateOn							
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
CREATE PROCEDURE SalesOrderUpdate
(
				@PKID								INT						,
				@OrderGUID							UNIQUEIDENTIFIER		,
				@CustomerAccountID					INT						,
				@SalesID							INT						,
				@SalesName							NVARCHAR(50)			,
				@GoodsValue							MONEY					,
				@ServiceFee							MONEY					,
				@TotalValue							MONEY					,
				@FlowStatusId						INT						,
				@OrderStatusId						INT						,
				@PaymentStatusId					INT						,
				@OutStockDate						DATETIME = NULL			,
				@InvoiceDate						DATETIME = NULL			,
				@DeliveryDate						DATETIME = NULL			,
				@OrderCompany						NVARCHAR(50)			,
				@ContactName						NVARCHAR(50)			,
				@ContactPhone						NVARCHAR(50)			,
				@ShippingAddress					NVARCHAR(200)			,
				@NeedInvoiceId						INT						,
				@HasInvoiceId							INT					,
				@InvoiceTitle						NVARCHAR(200)			,
				@VATCode							NVARCHAR(50)			,
				@OrderResourceId						INT					,
				@OrderRemark						NVARCHAR(200)			,
				@CreateOn							DATETIME				

)
AS
BEGIN
    UPDATE TSalesOrder
    SET
				OrderGUID			=@OrderGUID								,
				CustomerAccountID	=@CustomerAccountID						,
				SalesID				=@SalesID								,
				SalesName			=@SalesName								,
				GoodsValue			=@GoodsValue							,
				ServiceFee			=@ServiceFee							,
				TotalValue			=@TotalValue							,
				FlowStatusId		=@FlowStatusId							,
				OrderStatusId		=@OrderStatusId							,
				PaymentStatusId		=@PaymentStatusId						,
				OutStockDate		=@OutStockDate							,
				InvoiceDate			=@InvoiceDate							,
				DeliveryDate		=@DeliveryDate							,
				OrderCompany		=@OrderCompany							,
				ContactName			=@ContactName							,
				ContactPhone		=@ContactPhone							,
				ShippingAddress		=@ShippingAddress						,
				NeedInvoiceId		=@NeedInvoiceId							,
				HasInvoiceId		=@HasInvoiceId							,
				InvoiceTitle		=@InvoiceTitle							,
				VATCode				=@VATCode								,
				OrderResourceId		=@OrderResourceId						,
				OrderRemark			=@OrderRemark							,
				CreateOn			=@CreateOn								
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
CREATE PROCEDURE SalesOrderNoteInsert
(
				@PKID								INT	OUT					,
				@SalesOrderId						INT						,
				@Note								NVARCHAR(200)			,
				@CreateOn							DATETIME				
)
AS
BEGIN
         INSERT INTO TSalesOrderNote
			(
				SalesOrderId												,
				Note														,
				CreateOn							
			)
    	 VALUES 
    		(	
				@SalesOrderId												,
				@Note														,
				@CreateOn							
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
CREATE PROCEDURE SalesOrderItemInsert
(
				@PKID								INT	OUT					,
				@SalesOrderId						INT						,
				@ProductID							INT						,
				@ProductManufacturerPartNumber		NVARCHAR(50)			,
				@ProductFullName					NVARCHAR(100)			,
				@AveragePurchasePrice				MONEY					,
				@AverageLandedCost					MONEY					,
				@DefaultPrice						MONEY					,
				@SalePrice							MONEY					,
				@Quantity							DECIMAL(20,8)			,
				@LocatedQty							DECIMAL(20,8)			,
				@OutQty								DECIMAL(20,8)			
)
AS
BEGIN
         INSERT INTO TSalesOrderItem
			(
				SalesOrderId												,
				ProductID													,
				ProductManufacturerPartNumber								,
				ProductFullName												,
				AveragePurchasePrice										,
				AverageLandedCost											,
				DefaultPrice												,
				SalePrice													,
				Quantity													,
				LocatedQty													,
				OutQty														
			)
    	 VALUES 
    		(	
				@SalesOrderId												,
				@ProductID													,
				@ProductManufacturerPartNumber								,
				@ProductFullName											,
				@AveragePurchasePrice										,
				@AverageLandedCost											,
				@DefaultPrice												,
				@SalePrice													,
				@Quantity													,
				@LocatedQty													,
				@OutQty											
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
CREATE PROCEDURE  SalesOrderDelete
(
    @PKID			 INT
)
AS
BEGIN
    DELETE FROM TSalesOrder
	WHERE PKID = @PKID
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
CREATE PROCEDURE  DeleteSalesOrderNotesBySalesOrderId
(
    @SalesOrderId	 INT
)
AS
BEGIN
    DELETE FROM TSalesOrderNote
	WHERE SalesOrderId = @SalesOrderId
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
CREATE PROCEDURE  DeleteSalesOrderItemsBySalesOrderId
(
    @SalesOrderId	 INT
)
AS
BEGIN
    DELETE FROM TSalesOrderItem
	WHERE SalesOrderId = @SalesOrderId
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
CREATE PROCEDURE GetSalesOrderById
(
	    @PKID INT
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TSalesOrder.PKID				,
				TSalesOrder.OrderGUID			,
				TSalesOrder.CustomerAccountID	,
				TSalesOrder.SalesID				,
				TSalesOrder.SalesName			,
				TSalesOrder.GoodsValue			,
				TSalesOrder.ServiceFee			,
				TSalesOrder.TotalValue			,
				TSalesOrder.FlowStatusId		,
				TSalesOrder.OrderStatusId		,
				TSalesOrder.PaymentStatusId		,
				TSalesOrder.OutStockDate		,
				TSalesOrder.InvoiceDate			,
				TSalesOrder.DeliveryDate		,
				TSalesOrder.OrderCompany		,
				TSalesOrder.ContactName			,
				TSalesOrder.ContactPhone		,
				TSalesOrder.ShippingAddress		,
				TSalesOrder.NeedInvoiceId		,
				TSalesOrder.HasInvoiceId		,
				TSalesOrder.InvoiceTitle		,
				TSalesOrder.VATCode				,
				TSalesOrder.OrderResourceId		,
				TSalesOrder.OrderRemark			,
				TSalesOrder.CreateOn			
		  FROM	TSalesOrder
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
CREATE PROCEDURE GetSalesOrdersByCustomerAccountId
(
	    @CustomerAccountId INT
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TSalesOrder.PKID				,
				TSalesOrder.OrderGUID			,
				TSalesOrder.CustomerAccountID	,
				TSalesOrder.SalesID				,
				TSalesOrder.SalesName			,
				TSalesOrder.GoodsValue			,
				TSalesOrder.ServiceFee			,
				TSalesOrder.TotalValue			,
				TSalesOrder.FlowStatusId		,
				TSalesOrder.OrderStatusId		,
				TSalesOrder.PaymentStatusId		,
				TSalesOrder.OutStockDate		,
				TSalesOrder.InvoiceDate			,
				TSalesOrder.DeliveryDate		,
				TSalesOrder.OrderCompany		,
				TSalesOrder.ContactName			,
				TSalesOrder.ContactPhone		,
				TSalesOrder.ShippingAddress		,
				TSalesOrder.NeedInvoiceId			,
				TSalesOrder.HasInvoiceId			,
				TSalesOrder.InvoiceTitle		,
				TSalesOrder.VATCode				,
				TSalesOrder.OrderResourceId		,
				TSalesOrder.OrderRemark			,
				TSalesOrder.CreateOn			
		  FROM	TSalesOrder
		  WHERE CustomerAccountId=@CustomerAccountId
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
CREATE PROCEDURE GetSalesOrderByCondition
(
		@OrderStatusId	INT			= NULL,
		@OrderFrom		DATETIME	= NULL,
		@OrderTo		DATETIME	= NULL
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TSalesOrder.PKID				,
				TSalesOrder.OrderGUID			,
				TSalesOrder.CustomerAccountID	,
				TSalesOrder.SalesID				,
				TSalesOrder.SalesName			,
				TSalesOrder.GoodsValue			,
				TSalesOrder.ServiceFee			,
				TSalesOrder.TotalValue			,
				TSalesOrder.FlowStatusId		,
				TSalesOrder.OrderStatusId		,
				TSalesOrder.PaymentStatusId		,
				TSalesOrder.OutStockDate		,
				TSalesOrder.InvoiceDate			,
				TSalesOrder.DeliveryDate		,
				TSalesOrder.OrderCompany		,
				TSalesOrder.ContactName			,
				TSalesOrder.ContactPhone		,
				TSalesOrder.ShippingAddress		,
				TSalesOrder.NeedInvoiceId			,
				TSalesOrder.HasInvoiceId			,
				TSalesOrder.InvoiceTitle		,
				TSalesOrder.VATCode				,
				TSalesOrder.OrderResourceId		,
				TSalesOrder.OrderRemark			,
				TSalesOrder.CreateOn			
		  FROM	TSalesOrder
		  WHERE (@OrderStatusId IS NULL OR OrderStatusId=@OrderStatusId)
			AND (@OrderFrom IS NULL OR DATEDIFF(dd,@OrderFrom,CreateOn)>=0)
			AND (@OrderTo IS NULL OR DATEDIFF(dd,CreateOn,@OrderTo)>=0)
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
CREATE PROCEDURE GetSalesOrderNotesBySalesOrderId
(
		@SalesOrderId	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TSalesOrderNote.PKID			,	
				TSalesOrderNote.SalesOrderId	,	
				TSalesOrderNote.Note			,
				TSalesOrderNote.CreateOn							
		  FROM	TSalesOrderNote
		  WHERE SalesOrderId=@SalesOrderId
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
CREATE PROCEDURE GetSalesOrderItemsBySalesOrderId
(
		@SalesOrderId	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TSalesOrderItem.PKID							,
				TSalesOrderItem.SalesOrderId					,
				TSalesOrderItem.ProductID						,
				TSalesOrderItem.ProductManufacturerPartNumber	,
				TSalesOrderItem.ProductFullName					,
				TSalesOrderItem.AveragePurchasePrice			,
				TSalesOrderItem.AverageLandedCost				,
				TSalesOrderItem.DefaultPrice					,
				TSalesOrderItem.SalePrice						,
				TSalesOrderItem.Quantity						,
				TSalesOrderItem.LocatedQty						,
				TSalesOrderItem.OutQty														
		  FROM	TSalesOrderItem
		  WHERE SalesOrderId=@SalesOrderId
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

----End              销售订单        -------------


--Begin              价套        -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE PriceCodeInsert
(
				@PKID								INT	OUT					,
				@Name								NVARCHAR(200)			,
				@DateFrom							DATETIME		= NULL	,
				@DateTo								DATETIME		= NULL	,
				@PriceAdjustmentTypeId				INT						,
				@Remark								NVARCHAR(200)			,
				@IsVaild							INT						
)
AS
BEGIN
         INSERT INTO TPriceCode
			(
				[Name]														,
				DateFrom													,
				DateTo														,
				PriceAdjustmentTypeId										,
				Remark														,
				IsVaild										
			)
    	 VALUES 
    		(	
				@Name														,
				@DateFrom													,
				@DateTo														,
				@PriceAdjustmentTypeId										,
				@Remark														,
				@IsVaild									
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
CREATE PROCEDURE PriceCodeUpdate
(
				@PKID								INT						,
				@Name								NVARCHAR(200)			,
				@DateFrom							DATETIME		= NULL	,
				@DateTo								DATETIME		= NULL	,
				@PriceAdjustmentTypeId				INT						,
				@Remark								NVARCHAR(200)			,
				@IsVaild							INT						
)
AS
BEGIN
    UPDATE TPriceCode
    SET
				[Name]				=@Name									,
				DateFrom			=@DateFrom								,
				DateTo				=@DateTo								,
				PriceAdjustmentTypeId	=@PriceAdjustmentTypeId				,
				Remark				=@Remark								,
				IsVaild				=@IsVaild												
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
CREATE PROCEDURE ProductPriceInsert
(
				@PKID								INT	OUT					,
				@PriceCodeId						INT						,
				@ProductId							INT						,
				@Value								DECIMAL(20,8)			,
				@Unit								NVARCHAR(50)			,
				@Remark								NVARCHAR(200)						
)
AS
BEGIN
         INSERT INTO TProductPrice
			(
				PriceCodeId													,
				ProductId													,
				[Value]														,
				Unit														,
				Remark													
			)
    	 VALUES 
    		(	
				@PriceCodeId												,
				@ProductId													,
				@Value														,
				@Unit														,
				@Remark														
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
CREATE PROCEDURE  DeletePriceCodeById
(
    @PKID	 INT
)
AS
BEGIN
    DELETE FROM TPriceCode
	WHERE PKID = @PKID
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
CREATE PROCEDURE  DeleteProductPricesByPriceCodeId
(
    @PriceCodeId	 INT
)
AS
BEGIN
    DELETE FROM TProductPrice
	WHERE PriceCodeId = @PriceCodeId
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
CREATE PROCEDURE GetAllPriceCode
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TPriceCode.PKID									,
				TPriceCode.[Name]								,
				TPriceCode.DateFrom								,
				TPriceCode.DateTo								,
				TPriceCode.PriceAdjustmentTypeId				,
				TPriceCode.Remark								,
				TPriceCode.IsVaild				
		  FROM	TPriceCode
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
CREATE PROCEDURE GetPriceCodeById
(
		@PKID	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TPriceCode.PKID									,
				TPriceCode.[Name]								,
				TPriceCode.DateFrom								,
				TPriceCode.DateTo								,
				TPriceCode.PriceAdjustmentTypeId				,
				TPriceCode.Remark								,
				TPriceCode.IsVaild											
		  FROM	TPriceCode
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
CREATE PROCEDURE GetProductPricesByPriceCodeId
(
		@PriceCodeId	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TProductPrice.PKID											,
				TProductPrice.ProductId										,
				TProductPrice.PriceCodeId									,
				TProductPrice.[Value]										,
				TProductPrice.Unit											,
				TProductPrice.Remark													
		  FROM	TProductPrice
		  WHERE PriceCodeId=@PriceCodeId
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
CREATE PROCEDURE GetPriceCodeByTime
(
		@DateFrom	DATETIME = NULL,
		@DateTo		DATETIME = NULL
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TPriceCode.PKID									,
				TPriceCode.[Name]								,
				TPriceCode.DateFrom								,
				TPriceCode.DateTo								,
				TPriceCode.PriceAdjustmentTypeId				,
				TPriceCode.Remark								,
				TPriceCode.IsVaild											
		  FROM	TPriceCode
		  WHERE (@DateFrom IS NULL OR DATEDIFF(dd,@DateFrom,DateTo)>=0)
			AND	(@DateTo IS NULL OR DATEDIFF(dd,DateFrom,@DateTo)>=0)
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
CREATE PROCEDURE CustomerAccountMappingPriceCodeInsert
(
				@PKID								INT	OUT					,
				@CustomerAccountId					INT						,
				@PriceCodeId						INT
)
AS
BEGIN
         INSERT INTO TCustomerAccountMappingPriceCode
			(
				CustomerAccountId											,
				PriceCodeId							
			)
    	 VALUES 
    		(	
				@CustomerAccountId											,
				@PriceCodeId						
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
CREATE PROCEDURE  CustomerAccountPriceCodeDelete
(
				@CustomerAccountId					INT						,
				@PriceCodeId						INT
)
AS
BEGIN
    DELETE FROM TCustomerAccountMappingPriceCode
	WHERE 		CustomerAccountId=@CustomerAccountId
			AND	PriceCodeId=@PriceCodeId		
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
CREATE PROCEDURE GetPriceCodeIdsByCustomerAccountId
(
		@CustomerAccountId	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TCustomerAccountMappingPriceCode.PKID											,
				TCustomerAccountMappingPriceCode.CustomerAccountId								,
				TCustomerAccountMappingPriceCode.PriceCodeId									
		  FROM	TCustomerAccountMappingPriceCode
		  WHERE CustomerAccountId=@CustomerAccountId
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
CREATE PROCEDURE GetCustomerAccountIdsByPriceCodeId
(
		@PriceCodeId	INT	
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
				TCustomerAccountMappingPriceCode.PKID											,
				TCustomerAccountMappingPriceCode.CustomerAccountId								,
				TCustomerAccountMappingPriceCode.PriceCodeId									
		  FROM	TCustomerAccountMappingPriceCode
		  WHERE PriceCodeId=@PriceCodeId
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

----End              价套        -------------

/****** 对象:  StoredProcedure [InsertWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertWarehouse]
(
	@PKID INT OUT
	,@Name nvarchar(255)
	,@Type int
	,@PhoneNumber nvarchar(50)
	,@Email nvarchar(50)
	,@FaxNumber nvarchar(50)
	,@Address nvarchar(255)
	,@City nvarchar(50)
	,@StateProvince nvarchar(50)
	,@ZipPostalCode nvarchar(50)
	,@Valid int
	,@CreatedOn datetime
	,@UpdatedOn datetime
	,@OperatorID int
	,@Remark text
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TWarehouse]
		   ([Name]
		   ,[Type]
		   ,[PhoneNumber]
		   ,[Email]
		   ,[FaxNumber]
		   ,[Address]
		   ,[City]
		   ,[StateProvince]
		   ,[ZipPostalCode]
		   ,[Valid]
		   ,[CreatedOn]
		   ,[UpdatedOn]
		   ,[OperatorID]
		   ,[Remark])
	 VALUES
		   (@Name
		   ,@Type
		   ,@PhoneNumber
		   ,@Email
		   ,@FaxNumber
		   ,@Address
		   ,@City
		   ,@StateProvince
		   ,@ZipPostalCode
		   ,@Valid
		   ,@CreatedOn
		   ,@UpdatedOn
		   ,@OperatorID
		   ,@Remark)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [UpdateWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateWarehouse]
(
	@PKID INT
	,@Name nvarchar(255)
	,@Type int
	,@PhoneNumber nvarchar(50)
	,@Email nvarchar(50)
	,@FaxNumber nvarchar(50)
	,@Address nvarchar(255)
	,@City nvarchar(50)
	,@StateProvince nvarchar(50)
	,@ZipPostalCode nvarchar(50)
	,@Valid int
	,@UpdatedOn datetime
	,@OperatorID int
	,@Remark text
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TWarehouse]
		SET [Name] = @Name
		  ,[Type] = @Type
		  ,[PhoneNumber] = @PhoneNumber
		  ,[Email] = @Email
		  ,[FaxNumber] = @FaxNumber
		  ,[Address] = @Address
		  ,[City] = @City
		  ,[StateProvince] = @StateProvince
		  ,[ZipPostalCode] = @ZipPostalCode
		  ,[Valid] = @Valid
		  ,[UpdatedOn] = @UpdatedOn
		  ,[OperatorID] = @OperatorID
		  ,[Remark] = @Remark
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [DeleteWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [DeleteWarehouse]
(
	@PKID INT
)
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM [TWarehouse]
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [SetValidWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SetValidWarehouse]
(
	@PKID INT
	,@OperatorID int
	,@Valid INT
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TWarehouse]
		SET Valid=@Valid, OperatorID=@OperatorID
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [GetWarehouse]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetWarehouse]
(
	@PKID INT=NULL
	,@Name NVARCHAR(255)=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * FROM [TWarehouse]
	WHERE (@PKID IS NULL OR PKID=@PKID) 
		AND (@Name IS NULL OR [Name]=@Name)
	ORDER BY [Name]
END
GO

/****** 对象:  StoredProcedure [GetWarehouseList]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetWarehouseList]
(
	@Name NVARCHAR(255)=NULL
	,@Type INT=NULL
	,@Valid INT=NULL
	,@Address NVARCHAR(255)=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * FROM [TWarehouse]
	WHERE (@Name IS NULL OR [Name] LIKE '%'+@Name+'%')
		AND (@Type IS NULL OR [Type]=@Type)
		AND (@Valid IS NULL OR [Valid]=@Valid)
		AND (@Address IS NULL OR (
			[Address] LIKE '%'+@Address+'%'
			OR [City] LIKE '%'+@Address+'%'
			OR [StateProvince] LIKE '%'+@Address+'%'
			OR [Address]+[City] LIKE '%'+@Address+'%'
			OR [Address]+[StateProvince] LIKE '%'+@Address+'%'
			OR [City]+[Address] LIKE '%'+@Address+'%'
			OR [City]+[StateProvince] LIKE '%'+@Address+'%'
			OR [StateProvince]+[Address] LIKE '%'+@Address+'%'
			OR [StateProvince]+[City] LIKE '%'+@Address+'%'
			OR [Address]+[City]+[StateProvince] LIKE '%'+@Address+'%'
			OR [Address]+[StateProvince]+[City] LIKE '%'+@Address+'%'
			OR [City]+[Address]+[StateProvince] LIKE '%'+@Address+'%'
			OR [City]+[StateProvince]+[Address] LIKE '%'+@Address+'%'
			OR [StateProvince]+[Address]+[City] LIKE '%'+@Address+'%'
			OR [StateProvince]+[City]+[Address] LIKE '%'+@Address+'%'
			))
	ORDER BY [Name]
END
GO

/****** 对象:  StoredProcedure [InsertDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertDistribution]
(
	@PKID				INT OUT
	,@SalesOrderID		int
	,@DistributionManID	int
	,@CreatedOn			datetime
	,@UpdatedOn			datetime
	,@OperatorID		int
	,@OutStockStatus	int
	,@Valid				int
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TDistribution]
		([SalesOrderID]
		,[DistributionManID]
		,[CreatedOn]
		,[UpdatedOn]
		,[OperatorID]
		,[OutStockStatus]
		,[Valid])
	VALUES
		(@SalesOrderID
		,@DistributionManID	
		,@CreatedOn			
		,@UpdatedOn			
		,@OperatorID		
		,@OutStockStatus	
		,@Valid)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO	


/****** 对象:  StoredProcedure [UpdateDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateDistribution]
(
	@PKID				INT
	,@SalesOrderID		int
	,@DistributionManID	int
	,@UpdatedOn			datetime
	,@OperatorID		int
	,@OutStockStatus	int
	,@Valid				int
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TDistribution]
	SET [SalesOrderID] = @SalesOrderID
		  ,[DistributionManID] = @DistributionManID
		  ,[UpdatedOn] = @UpdatedOn
		  ,[OperatorID] = @OperatorID
		  ,[OutStockStatus] = @OutStockStatus
		  ,[Valid] = @Valid
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO	


/****** 对象:  StoredProcedure [SetDistributionValidityType]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SetDistributionValidityType]
(
	@PKID				INT
	,@UpdatedOn			datetime
	,@OperatorID		int
	,@Valid				int
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TDistribution]
	SET [UpdatedOn] = @UpdatedOn
		  ,[OperatorID] = @OperatorID
		  ,[Valid] = @Valid
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [SetDistributionOutStockStatus]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [SetDistributionOutStockStatus]
(
	@PKID				INT
	,@UpdatedOn			datetime
	,@OperatorID		int
	,@OutStockStatus	int
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TDistribution]
	SET [UpdatedOn] = @UpdatedOn
		  ,[OperatorID] = @OperatorID
		  ,[OutStockStatus] = @OutStockStatus
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [GetDistribution]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetDistribution]
(
	@PKID INT=NULL
	,@SalesOrderID INT=NULL
	,@CreatedOnFrom DATETIME=NULL
	,@CreatedOnTo DATETIME=NULL
	,@Valid INT=NULL
	,@OutStockStatus INT=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT A.PKID AS DistributionID,A.SalesOrderID,
		A.DistributionManID,A.CreatedOn,A.UpdatedOn,
		A.OperatorID,A.OutStockStatus,A.Valid, B.*
	FROM [TDistribution] A LEFT JOIN [TDistributionItem] B
	ON A.PKID=B.DistributionID
	WHERE (@PKID IS NULL OR A.PKID=@PKID) 
		AND (@SalesOrderID IS NULL OR [SalesOrderID]=@SalesOrderID)
		AND (@CreatedOnFrom IS NULL OR DATEDIFF(dd, @CreatedOnFrom, CreatedOn)>=0)
		AND (@CreatedOnTo IS NULL OR DATEDIFF(dd, CreatedOn, @CreatedOnTo)>=0)
		AND (@Valid IS NULL OR Valid=@Valid)
		AND (@OutStockStatus IS NULL OR OutStockStatus=@OutStockStatus)
	ORDER BY A.CreatedOn DESC
END
GO

/****** 对象:  StoredProcedure [InsertDistributionItem]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertDistributionItem]
(
	@PKID				INT OUT
	,@DistributionID	int
	,@ProductID			int
	,@WarehouseID		int
	,@Batch				nvarchar(50)
	,@Quantity			decimal(20,8)
	,@Unit				nvarchar(50)
	,@SalePrice			money
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TDistributionItem]
		   ([DistributionID]
		   ,[ProductID]
		   ,[WarehouseID]
		   ,[Batch]
		   ,[Quantity]
		   ,[Unit]
		   ,[SalePrice])
	 VALUES
		   (@DistributionID
			,@ProductID		
			,@WarehouseID	
			,@Batch			
			,@Quantity		
			,@Unit			
			,@SalePrice)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO	

/****** 对象:  StoredProcedure [DeleteDistributionItems]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [DeleteDistributionItems]
(
	@DistributionID	int
)
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM [TDistributionItem]
	WHERE DistributionID=@DistributionID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [InsertStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertStockTrans]
(
	@PKID						INT OUT
	,@ProductID					int					
	,@WarehouseID				int					
	,@Batch						nvarchar(50)					
	,@OrderType					int					
	,@OrderID					int					
	,@TransType					int					
	,@Quantity					decimal(20,8)					
	,@Unit						nvarchar(50)					
	,@TransDate					datetime					
	,@SalePrice					money					
	,@AccountCode				nvarchar(50)					
	,@AverageLandedCost			money					
	,@AveragePurchasePrice		money					
	,@OperatorID				int					
	,@Remark					text					
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TStockTrans]
			([ProductID]
			,[WarehouseID]
			,[Batch]
			,[OrderType]
			,[OrderID]
			,[TransType]
			,[Quantity]
			,[Unit]
			,[TransDate]
			,[SalePrice]
			,[AccountCode]
			,[AverageLandedCost]
			,[AveragePurchasePrice]
			,[OperatorID]
			,[Remark])
	VALUES
			(@ProductID				
			,@WarehouseID			
			,@Batch					
			,@OrderType				
			,@OrderID				
			,@TransType				
			,@Quantity				
			,@Unit					
			,@TransDate				
			,@SalePrice				
			,@AccountCode			
			,@AverageLandedCost		
			,@AveragePurchasePrice	
			,@OperatorID			
			,@Remark)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO


/****** 对象:  StoredProcedure [UpdateStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateStockTrans]
(
	@PKID						INT
	,@ProductID					int					
	,@WarehouseID				int					
	,@Batch						nvarchar(50)					
	,@OrderType					int					
	,@OrderID					int					
	,@TransType					int					
	,@Quantity					decimal(20,8)					
	,@Unit						nvarchar(50)					
	,@TransDate					datetime					
	,@SalePrice					money					
	,@AccountCode				nvarchar(50)					
	,@AverageLandedCost			money					
	,@AveragePurchasePrice		money					
	,@OperatorID				int					
	,@Remark					text					
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TStockTrans]
	   SET [ProductID] = @ProductID
		  ,[WarehouseID] = @WarehouseID
		  ,[Batch] = @Batch
		  ,[OrderType] = @OrderType
		  ,[OrderID] = @OrderID
		  ,[TransType] = @TransType
		  ,[Quantity] = @Quantity
		  ,[Unit] = @Unit
		  ,[TransDate] = @TransDate
		  ,[SalePrice] = @SalePrice
		  ,[AccountCode] = @AccountCode
		  ,[AverageLandedCost] = @AverageLandedCost
		  ,[AveragePurchasePrice] = @AveragePurchasePrice
		  ,[OperatorID] = @OperatorID
		  ,[Remark] = @Remark
	WHERE PKID=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [GetStockTrans]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetStockTrans]
(
	@OrderID		int=null
	,@OrderType		int=null					
	,@TransType		int=null					
	,@ProductID		int=null					
	,@WarehouseID	int=null					
	,@Batch			nvarchar(50)=null
	,@TransDateFrom	datetime=null					
	,@TransDateTo	datetime=null					
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * FROM [TStockTrans]
	WHERE (@OrderID IS NULL OR [OrderID]=@OrderID) 
		AND (@OrderType IS NULL OR [OrderType]=@OrderType)
		AND (@TransType IS NULL OR [TransType]=@TransType)
		AND (@ProductID IS NULL OR [ProductID]=@ProductID)
		AND (@WarehouseID IS NULL OR [WarehouseID]=@WarehouseID)
		AND (@Batch IS NULL OR [Batch] LIKE '%'+@Batch+'%')
		AND (@TransDateFrom IS NULL OR DATEDIFF(dd, @TransDateFrom, [TransDate])>=0)
		AND (@TransDateTo IS NULL OR DATEDIFF(dd, [TransDate], @TransDateTo)>=0)
	ORDER BY [TransDate] DESC 
END
GO

/****** 对象:  StoredProcedure [InsertProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertProductStock]
(
	@PKID INT OUT
	,@ProductID int
	,@Unit nvarchar(50)
	,@Balance decimal(20,8)
	,@ReservedQty decimal(20,8)
	,@LocatedQty decimal(20,8)
	,@AverageLandedCost money
	,@AveragePurchasePrice money
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TProductStock]
		   ([ProductID]
		   ,[Unit]
		   ,[Balance]
		   ,[ReservedQty]
		   ,[LocatedQty]
		   ,[AverageLandedCost]
		   ,[AveragePurchasePrice])
	 VALUES
		   (@ProductID
		   ,@Unit
		   ,@Balance
		   ,@ReservedQty
		   ,@LocatedQty
		   ,@AverageLandedCost
		   ,@AveragePurchasePrice)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [UpdateProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateProductStock]
(
	@PKID int
	,@ProductID int
	,@Unit nvarchar(50)
	,@Balance decimal(20,8)
	,@ReservedQty decimal(20,8)
	,@LocatedQty decimal(20,8)
	,@AverageLandedCost money
	,@AveragePurchasePrice money
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TProductStock]
		SET [ProductID]=@ProductID
		   ,[Unit]=@Unit
		   ,[Balance]=@Balance
		   ,[ReservedQty]=@ReservedQty
		   ,[LocatedQty]=@LocatedQty
		   ,[AverageLandedCost]=@AverageLandedCost
		   ,[AveragePurchasePrice]=@AveragePurchasePrice
	WHERE [PKID]=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [ModifyReserve]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ModifyReserve]
(
	@ProductID int
	,@ReservedQty decimal(20,8)
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TProductStock]
		SET [ReservedQty]=[ReservedQty] + @ReservedQty
	WHERE [ProductID]=@ProductID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [GetProductStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetProductStock]
(
	@ProductID INT=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * FROM [TProductStock]
	WHERE (@ProductID IS NULL OR ProductID=@ProductID)
	ORDER BY ProductID
END
GO

/****** 对象:  StoredProcedure [InsertBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [InsertBatchStock]
(
	@PKID INT OUT
	,@ProductID INT
	,@WarehouseID INT
	,@Batch NVARCHAR(50)
	,@Unit NVARCHAR(50)
	,@Balance DECIMAL(20,8)
	,@LocatedQty DECIMAL(20,8)
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [TBatchStock]
		   ([ProductID]
		   ,[WarehouseID]
		   ,[Batch]
		   ,[Unit]
		   ,[Balance]
		   ,[LocatedQty])
	 VALUES
		   (@ProductID
		   ,@WarehouseID
		   ,@Batch
		   ,@Unit
		   ,@Balance
		   ,@LocatedQty)
	SELECT @PKID=SCOPE_IDENTITY()
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [UpdateBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [UpdateBatchStock]
(
	@PKID int
	,@ProductID INT
	,@WarehouseID INT
	,@Batch NVARCHAR(50)
	,@Unit NVARCHAR(50)
	,@Balance DECIMAL(20,8)
	,@LocatedQty DECIMAL(20,8)
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [TBatchStock]
		SET [ProductID]=@ProductID
		   ,[WarehouseID]=@WarehouseID
		   ,[Batch]=@Batch
		   ,[Unit]=@Unit
		   ,[Balance]=@Balance
		   ,[LocatedQty]=@LocatedQty
	WHERE [PKID]=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [GetBatchStock]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetBatchStock]
(
	@ProductID INT=NULL
	,@WarehouseID INT=NULL
	,@Batch NVARCHAR(50)=NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [TBatchStock]
	WHERE (@ProductID IS NULL OR ProductID=@ProductID) 
		AND (@WarehouseID IS NULL OR WarehouseID=@WarehouseID)
		AND (@Batch IS NULL OR Batch=@Batch)
	ORDER BY ProductID
END
GO

/****** 对象:  StoredProcedure [GetBatchStockList]    脚本日期: 14/07/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetBatchStockList]
(
	@ProductID INT=NULL
	,@WarehouseID INT=NULL
	,@Batch NVARCHAR(50)=NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [TBatchStock]
	WHERE (@ProductID IS NULL OR [ProductID]=@ProductID) 
		AND (@WarehouseID IS NULL OR [WarehouseID]=@WarehouseID)
		AND (@Batch IS NULL OR [Batch] LIKE '%'+@Batch+'%')
	ORDER BY [ProductID]
END
GO

----BEGIN            采购订单      ------------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE PurchaseOrderInsert
(
	   @PKID								INT	OUT	              ,	
	   @ProviderID                          INT                   ,
       @OrderStatus                         INT                   ,
       @TotalValue                          MONEY	              ,
       @OtherCost                           MONEY	              ,
       @OrderDate                           DATETIME              ,
       @RequiredDate                        DATETIME              ,
       @DeliveryDate                        DATETIME = NULL       ,
       @PurchaserId                         INT                   ,
       @PurchaserName                       NVARCHAR(50)		  ,
       @AcceptProductManID                  INT                   ,
       @AcceptProductManName                NVARCHAR(50)		  ,
       @DeliveryAddress                     NVARCHAR(200)		  ,
       @InvoiceType                         INT                   ,
       @InvoiceId                           INT =NULL             ,
       @VATCode                             NVARCHAR(50)		  ,
       @VATRate                             DECIMAL               ,
       @Remark                              NVARCHAR(2000)	      ,
       @CreateOn							DATETIME		 
)
AS
BEGIN
    INSERT INTO TPurchaseOrder
	(
       ProviderID                      ,                 
       OrderStatus                     ,   
       TotalValue                      ,  
       OtherCost                       ,  
       OrderDate                       ,
       RequiredDate                    ,
       DeliveryDate                    ,
       PurchaserID                     , 
       PurchaserName                   ,
       AcceptProductManID              ,
       AcceptProductManName            , 
       DeliveryAddress                 ,  
       InvoiceType                     ,  
       InvoiceId                       ,    
       VATCode                         ,   
       VATRate                         ,    
       Remark                          ,    
       CreateOn							
     )
    	 VALUES (	
       @ProviderID                      ,                 
       @OrderStatus                     ,   
       @TotalValue                      ,  
       @OtherCost                       ,  
       @OrderDate                       ,
       @RequiredDate                    ,
       @DeliveryDate                    ,
       @PurchaserId                     , 
       @PurchaserName                   ,
       @AcceptProductManID              ,
       @AcceptProductManName            , 
       @DeliveryAddress                 ,  
       @InvoiceType                     ,  
       @InvoiceId                       ,    
       @VATCode                         ,   
       @VATRate                         ,    
       @Remark                          ,    
       @CreateOn							
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
CREATE PROCEDURE PurchaseOrderUpdate
(
       @PKID								INT		              ,	
	   @ProviderID                          INT                   ,
       @OrderStatus                         INT                   ,
       @TotalValue                          MONEY	              ,
       @OtherCost                           MONEY	              ,
       @OrderDate                           DATETIME              ,
       @RequiredDate                        DATETIME              ,
       @DeliveryDate                        DATETIME = NULL       ,
       @PurchaserId                         INT                   ,
       @PurchaserName                       NVARCHAR(50)		  ,
       @AcceptProductManID                  INT                   ,
       @AcceptProductManName                NVARCHAR(50)		  ,
       @DeliveryAddress                     NVARCHAR(200)		  ,
       @InvoiceType                         INT                   ,
       @InvoiceId                           INT =NULL             ,
       @VATCode                             NVARCHAR(50)		  ,
       @VATRate                             DECIMAL               ,
       @Remark                              NVARCHAR(2000)	      ,
       @CreateOn							DATETIME	
)
AS
BEGIN
    UPDATE TPurchaseOrder
    SET
       ProviderID                 =    @ProviderID                ,                 
       OrderStatus                =    @OrderStatus               ,   
       TotalValue                 =    @TotalValue                ,  
       OtherCost                  =    @OtherCost                 ,  
       OrderDate                  =    @OrderDate                 ,
       RequiredDate               =    @RequiredDate              ,
       DeliveryDate               =    @DeliveryDate              ,
       PurchaserID                =    @PurchaserId               , 
       PurchaserName              =    @PurchaserName             ,
       AcceptProductManID         =    @AcceptProductManID        ,
       AcceptProductManName       =    @AcceptProductManName      , 
       DeliveryAddress            =    @DeliveryAddress           ,  
       InvoiceType                =    @InvoiceType               ,  
       InvoiceId                  =    @InvoiceId                 ,    
       VATCode                    =    @VATCode                   ,   
       VATRate                    =    @VATRate                   ,    
       Remark                     =    @Remark                    ,    
       CreateOn					  =	   @CreateOn
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
CREATE PROCEDURE PurchaseOrderItemInsert
(
				@PKID								INT	OUT					,
				@PurchaseOrderId					INT						,
				@ProductId							INT						,
				@ManufacturerPartNumber		        NVARCHAR(50)			,
				@ProductFullName					NVARCHAR(100)			,
				@PurchasePrice				        MONEY					,
				@Quantity					        DECIMAL(20,8)		    ,
				@InStockQty						    DECIMAL(20,8)		    ,
				@Unit							    NVARCHAR(50)			
					
)
AS
BEGIN
         INSERT INTO TPurchaseOrderItem
			(			
                PurchaseOrderId								        	    ,
				ProductId													,
				ManufacturerPartNumber		       			                ,
				ProductFullName							                    	,
				PurchasePrice				       					                ,
				Quantity					        		                ,
				InStockQty						   		                    ,
				Unit															
			)
    	 VALUES 
    		(	
				@PurchaseOrderId								        	,
				@ProductId													,
				@ManufacturerPartNumber		       			                ,
				@ProductFullName							              	,
				@PurchasePrice				       					        ,
				@Quantity					        		                ,
				@InStockQty						   		                    ,
				@Unit							  										
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
CREATE PROCEDURE  PurchaseOrderDelete
(
    @PKID			 INT
)
AS
BEGIN
    DELETE FROM TPurchaseOrder
	WHERE PKID = @PKID
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
CREATE PROCEDURE  DeletePurchaseOrderItemsByPurchaseOrderId
(
    @PurchaseOrderId	 INT
)
AS
BEGIN
    DELETE FROM TPurchaseOrderItem
	WHERE PurchaseOrderId = @PurchaseOrderId
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
CREATE PROCEDURE GetPurchaseOrderById
(
	    @PKID INT
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
               TPurchaseOrder.PKID                            ,
		       TPurchaseOrder.ProviderID                      ,                 
			   TPurchaseOrder.OrderStatus                     ,   
			   TPurchaseOrder.TotalValue                      ,  
			   TPurchaseOrder.OtherCost                       ,  
			   TPurchaseOrder.OrderDate                       ,
			   TPurchaseOrder.RequiredDate                    ,
			   TPurchaseOrder.DeliveryDate                    ,
			   TPurchaseOrder.PurchaserID                     , 
			   TPurchaseOrder.PurchaserName                   ,
			   TPurchaseOrder.AcceptProductManID              ,
			   TPurchaseOrder.AcceptProductManName            , 
			   TPurchaseOrder.DeliveryAddress                 ,  
			   TPurchaseOrder.InvoiceType                     ,  
			   TPurchaseOrder.InvoiceId                       ,    
			   TPurchaseOrder.VATCode                         ,   
			   TPurchaseOrder.VATRate                         ,    
			   TPurchaseOrder.Remark                          ,    
			   TPurchaseOrder.CreateOn							
		  FROM	TPurchaseOrder
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
CREATE PROCEDURE GetPurchaseOrdeByCondition
(
	    @ProviderID                INT       = NULL,
        @OrderStatus               INT       = NULL,
        @OrderFrom		       DATETIME	     = NULL,
		@OrderTo		       DATETIME	     = NULL,
        @PurchaserName         NVARCHAR(50)  = NULL,
        @AcceptProductManName  NVARCHAR(50)  = NULL,
        @InvoiceType                INT      = NULL
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
               TPurchaseOrder.PKID                            ,
		       TPurchaseOrder.ProviderID                      ,                 
			   TPurchaseOrder.OrderStatus                     ,   
			   TPurchaseOrder.TotalValue                      ,  
			   TPurchaseOrder.OtherCost                       ,  
			   TPurchaseOrder.OrderDate                       ,
			   TPurchaseOrder.RequiredDate                    ,
			   TPurchaseOrder.DeliveryDate                    ,
			   TPurchaseOrder.PurchaserID                     , 
			   TPurchaseOrder.PurchaserName                   ,
			   TPurchaseOrder.AcceptProductManID              ,
			   TPurchaseOrder.AcceptProductManName            , 
			   TPurchaseOrder.DeliveryAddress                 ,  
			   TPurchaseOrder.InvoiceType                     ,  
			   TPurchaseOrder.InvoiceId                       ,    
			   TPurchaseOrder.VATCode                         ,   
			   TPurchaseOrder.VATRate                         ,    
			   TPurchaseOrder.Remark                          ,    
			   TPurchaseOrder.CreateOn							
		  FROM	TPurchaseOrder
		   WHERE (@ProviderID IS NULL OR ProviderID=@ProviderID)
            AND(OrderStatus IS NULL OR OrderStatus=@OrderStatus)
			AND (@OrderFrom IS NULL OR DATEDIFF(dd,@OrderFrom,OrderDate)>=0)
			AND (@OrderTo IS NULL OR DATEDIFF(dd,OrderDate,@OrderTo)>=0)
            AND (PurchaserName like '%'+@PurchaserName+'%')
            AND (AcceptProductManName like '%'+@AcceptProductManName+'%')
            AND (InvoiceType IS NULL OR InvoiceType=@InvoiceType)
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
CREATE PROCEDURE GetPurchaseOrderItemsByPurchaseOrderId
(
		 @PurchaseOrderId                INT     
)
AS
BEGIN
          SET NOCOUNT OFF
          SELECT 
                TPurchaseOrderItem.PKID                                                         ,
				TPurchaseOrderItem.PurchaseOrderId								        	    ,
				TPurchaseOrderItem.ProductId													,
				TPurchaseOrderItem.ManufacturerPartNumber		       			                ,
				TPurchaseOrderItem.ProductFullName							                    ,
				TPurchaseOrderItem.PurchasePrice				       					        ,
				TPurchaseOrderItem.Quantity					        		                    ,
				TPurchaseOrderItem.InStockQty						   		                    ,
				TPurchaseOrderItem.Unit													
		  FROM	TPurchaseOrderItem
		  WHERE PurchaseOrderId=@PurchaseOrderId
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



----END              采购订单      ------------------