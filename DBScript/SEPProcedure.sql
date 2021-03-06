/***********************************************************************************
**                                                                                **
**                               删除存储过程                                     **
**                                                                                **
***********************************************************************************/


--Begin              工作任务        ------------

IF OBJECT_ID(N'[dbo].[GetWorkTaskByAccountID]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetWorkTaskByAccountID]

IF OBJECT_ID(N'[dbo].[GetWorkTaskByResponsibleID]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetWorkTaskByResponsibleID]

IF OBJECT_ID(N'[dbo].[AddWorkTask]') IS NOT NULL
	DROP PROCEDURE [dbo].[AddWorkTask]

IF OBJECT_ID(N'[dbo].[UpdateWorkTask]') IS NOT NULL
	DROP PROCEDURE [dbo].[UpdateWorkTask]

IF OBJECT_ID(N'[dbo].[DeleteWorkTask]') IS NOT NULL
	DROP PROCEDURE [dbo].[DeleteWorkTask]

IF OBJECT_ID(N'[dbo].[GetWorkTask]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetWorkTask]

IF OBJECT_ID(N'[dbo].[GetMyWorkTaskByCondition]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetMyWorkTaskByCondition]

IF OBJECT_ID(N'[dbo].[GetResponsibleWorkTaskByCondition]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetResponsibleWorkTaskByCondition]

IF OBJECT_ID(N'[dbo].[DeleteWorkTaskResponsible]') IS NOT NULL
	DROP PROCEDURE [dbo].[DeleteWorkTaskResponsible]

IF OBJECT_ID(N'[dbo].[InsertWorkTaskResponsible]') IS NOT NULL
	DROP PROCEDURE [dbo].[InsertWorkTaskResponsible]

IF OBJECT_ID(N'[dbo].[AddWorkTaskQA]') IS NOT NULL
	DROP PROCEDURE [dbo].[AddWorkTaskQA]

IF OBJECT_ID(N'[dbo].[UpdateWorkTaskQA]') IS NOT NULL
	DROP PROCEDURE [dbo].[UpdateWorkTaskQA]

IF OBJECT_ID(N'[dbo].[DeleteWorkTaskQA]') IS NOT NULL
	DROP PROCEDURE [dbo].[DeleteWorkTaskQA]

IF OBJECT_ID(N'[dbo].[GetWorkTaskQA]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetWorkTaskQA]
GO
--End                工作任务        ------------

/****** 对象:  StoredProcedure [dbo].[InsertAccount]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAccount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertAccount]
GO

/****** 对象:  StoredProcedure [dbo].[ValidationName]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ValidationName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ValidationName]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateAccount]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAccount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateAccount]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAccount]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAccount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAccount]
GO

/****** 对象:  StoredProcedure [dbo].[ChangePassword]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ChangePassword]
GO

/****** 对象:  StoredProcedure [dbo].[ResetPassword]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetPassword]
GO

/****** 对象:  StoredProcedure [dbo].[ChangeUsbKey]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeUsbKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ChangeUsbKey]
GO

/****** 对象:  StoredProcedure [dbo].[GetAccount]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAccount]
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDepartmentByBackAccontsIDAndAuthID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDepartmentByBackAccontsIDAndAuthID]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccountsByAuthIdAndDeptId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAccountsByAuthIdAndDeptId]
GO

/***********************************************************************************/
/************         Begin   公告,目标,公司规章        ****************************/
/***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[AppendixInsert]    脚本日期: 02/23/2009 15:50:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppendixInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AppendixInsert]
GO

/****** 对象:  StoredProcedure [dbo].[BulletinInsert]    脚本日期: 02/23/2009 15:50:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BulletinInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BulletinInsert]
GO

/****** 对象:  StoredProcedure [dbo].[BulletinUpdate]    脚本日期: 02/23/2009 15:50:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BulletinUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BulletinUpdate]
GO

/****** 对象:  StoredProcedure [dbo].[CountAppendixByBulletinIDAndTitle]    脚本日期: 02/23/2009 15:51:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountAppendixByBulletinIDAndTitle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CountAppendixByBulletinIDAndTitle]
GO

/****** 对象:  StoredProcedure [dbo].[CountBulletinByTitle]    脚本日期: 02/23/2009 15:51:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountBulletinByTitle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CountBulletinByTitle]
GO

/****** 对象:  StoredProcedure [dbo].[CountBulletinByTitleDiffPKID]    脚本日期: 02/23/2009 15:52:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountBulletinByTitleDiffPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CountBulletinByTitleDiffPKID]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAppendixByBulletinID]    脚本日期: 02/23/2009 15:52:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAppendixByBulletinID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAppendixByBulletinID]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAppendixByPKID]    脚本日期: 02/23/2009 15:52:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAppendixByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAppendixByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteBulletinByPKID]    脚本日期: 02/23/2009 15:53:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteBulletinByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteBulletinByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[GetAllBulletin]    脚本日期: 02/23/2009 15:53:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllBulletin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllBulletin]
GO

/****** 对象:  StoredProcedure [dbo].[GetAppendixByBulletinID]    脚本日期: 02/23/2009 15:53:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAppendixByBulletinID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAppendixByBulletinID]
GO

/****** 对象:  StoredProcedure [dbo].[GetAppendixByPKID]    脚本日期: 02/23/2009 15:53:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAppendixByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAppendixByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByBulletinID]    脚本日期: 02/23/2009 15:54:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBulletinByBulletinID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetBulletinByBulletinID]
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByCondition]    脚本日期: 02/23/2009 15:54:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBulletinByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetBulletinByCondition]
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByTime]    脚本日期: 02/23/2009 15:54:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBulletinByTime]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetBulletinByTime]
GO

/****** 对象:  StoredProcedure [dbo].[GetLastBulletin]    脚本日期: 02/23/2009 15:54:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastBulletin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLastBulletin]
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixDeleteByCompanyReguId]    脚本日期: 02/23/2009 16:18:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyReguAppendixDeleteByCompanyReguId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyReguAppendixDeleteByCompanyReguId]
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixDeleteByPKID]    脚本日期: 02/23/2009 16:18:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyReguAppendixDeleteByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyReguAppendixDeleteByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixInsert]    脚本日期: 02/23/2009 16:19:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyReguAppendixInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyReguAppendixInsert]
GO

/****** 对象:  StoredProcedure [dbo].[CompanyRegulationsDeleteByPKID]    脚本日期: 02/23/2009 16:19:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyRegulationsDeleteByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyRegulationsDeleteByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[CompanyRegulationsInsert]    脚本日期: 02/23/2009 16:19:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyRegulationsInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CompanyRegulationsInsert]
GO

/****** 对象:  StoredProcedure [dbo].[GetCompanyReguAppendixByCompanyReguID]    脚本日期: 02/23/2009 16:19:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCompanyReguAppendixByCompanyReguID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCompanyReguAppendixByCompanyReguID]
GO

/****** 对象:  StoredProcedure [dbo].[GetCompanyRegulationsByType]    脚本日期: 02/23/2009 16:20:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCompanyRegulationsByType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCompanyRegulationsByType]
GO


/****** 对象:  StoredProcedure [dbo].[DeleteGoalByPKID]    脚本日期: 02/23/2009 16:40:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteGoalByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteGoalByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteGoalBySetHostID]    脚本日期: 02/23/2009 16:40:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteGoalBySetHostID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteGoalBySetHostID]
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalByPKID]    脚本日期: 02/23/2009 16:40:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGoalByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetGoalByPKID]
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalBySetHostID]    脚本日期: 02/23/2009 16:41:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGoalBySetHostID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetGoalBySetHostID]
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalCountByTitle]    脚本日期: 02/23/2009 16:41:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGoalCountByTitle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetGoalCountByTitle]
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalCountByTitleDiffPKID]    脚本日期: 02/24/2009 09:56:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGoalCountByTitleDiffPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetGoalCountByTitleDiffPKID]
GO

/****** 对象:  StoredProcedure [dbo].[GetLastGoalBySetHostID]    脚本日期: 02/24/2009 09:56:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastGoalBySetHostID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLastGoalBySetHostID]
GO

/****** 对象:  StoredProcedure [dbo].[GoalInsert]    脚本日期: 02/24/2009 09:56:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GoalInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GoalInsert]
GO

/****** 对象:  StoredProcedure [dbo].[GoalUpdate]    脚本日期: 02/24/2009 09:56:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GoalUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GoalUpdate]
GO

/***********************************************************************************/
/************         End     公告,目标,公司规章        ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************              Begin   职位，部门           ****************************/
/***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[InsertDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDepartment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertDepartment]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDepartment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateDepartment]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteDepartment]    脚本日期: 02/23/2009 16:06:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteDepartment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteDepartment]
GO

/****** 对象:  StoredProcedure [dbo].[GetDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDepartment]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDepartment]
GO

/****** 对象:  StoredProcedure [dbo].[GetDepartmentByEmployeeId]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDepartmentByEmployeeId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDepartmentByEmployeeId]
GO

/****** 对象:  StoredProcedure [dbo].[GetParentDeptByDeptId]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetParentDeptByDeptId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetParentDeptByDeptId]
GO


/****** 对象:  StoredProcedure [dbo].[InsertPosition]    脚本日期: 02/24/2009 10:51:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPositionGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPositionGrade]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateEmployee]    脚本日期: 02/24/2009 11:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePositionGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdatePositionGrade]
GO

/****** 对象:  StoredProcedure [dbo].[DeletePosition]    脚本日期: 02/24/2009 11:18:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeletePositionGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeletePositionGrade]
GO

/****** 对象:  StoredProcedure [dbo].[GetPosition]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPositionGrade]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPositionGrade]
GO

/***********************************************************************************/
/************              End     职位，部门           ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************              Begin     特殊日期           ****************************/
/***********************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSpecialDateByPKID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSpecialDateByPKID]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpecialDateInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SpecialDateInsert]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteSpecialDateByDate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteSpecialDateByDate]
GO

/***********************************************************************************/
/************              End     特殊日期             ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************              Begin     员工欢迎信         ****************************/
/***********************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WelcomeMailInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[WelcomeMailInsert]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastestWelcomeMail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLastestWelcomeMail]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastestWelcomeMailByTypeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLastestWelcomeMailByTypeID]
GO

/***********************************************************************************/
/************              End     员工欢迎信           ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************              Begin     电子签名         ****************************/
/***********************************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertElectronIdiograph]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertElectronIdiograph]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateElectronIdiograph]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateElectronIdiograph]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetElectronIdiographByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetElectronIdiographByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteElectronIdiographByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteElectronIdiographByAccountID]
GO

/***********************************************************************************/
/************              End     电子签名           ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************              start    便签             ****************************/
/***********************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NotesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NotesInsert]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NotesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NotesUpdate]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NotesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[NotesDelete]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNoteByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetNoteByID]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNotesByDate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetNotesByDate]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShareInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ShareInsert]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShareDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ShareDelete]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuitShare]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[QuitShare]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetShare]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetShare]
GO
/***********************************************************************************/
/************              end    便签             ****************************/
/***********************************************************************************/




--Begin              岗位性质        ------------

IF OBJECT_ID(N'[dbo].[AddPositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[AddPositionNature]
GO
IF OBJECT_ID(N'[dbo].[AddPositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[AddPositionNature]
GO
IF OBJECT_ID(N'[dbo].[UpdatePositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[UpdatePositionNature]
GO
IF OBJECT_ID(N'[dbo].[DeletePositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[DeletePositionNature]
GO
IF OBJECT_ID(N'[dbo].[GetPositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetPositionNature]
GO
IF OBJECT_ID(N'[dbo].[GetAllPositionNature]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetAllPositionNature]
GO
IF OBJECT_ID(N'[dbo].[GetPositionNatureByPositionID]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetPositionNatureByPositionID]
GO
IF OBJECT_ID(N'[dbo].[GetPositionDeptByPositionID]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetPositionDeptByPositionID]
GO
IF OBJECT_ID(N'[dbo].[GetPositionNatureListByName]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetPositionNatureListByName]
GO
IF OBJECT_ID(N'[dbo].[CountPositionNatureByNameDiffPKID]') IS NOT NULL
	DROP PROCEDURE [dbo].[CountPositionNatureByNameDiffPKID]
GO
IF OBJECT_ID(N'[dbo].[CountPositionByNatureId]') IS NOT NULL
	DROP PROCEDURE [dbo].[CountPositionByNatureId]
GO

--End              岗位性质        ------------

--Begin             职位               ------------
/****** 对象:  StoredProcedure [dbo].[InsertPosition]    脚本日期: 02/24/2009 10:51:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPosition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPosition]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateEmployee]    脚本日期: 02/24/2009 11:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePosition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdatePosition]
GO

/****** 对象:  StoredProcedure [dbo].[DeletePosition]    脚本日期: 02/24/2009 11:18:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeletePosition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeletePosition]
GO

/****** 对象:  StoredProcedure [dbo].[GetPosition]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPosition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPosition]
GO

/****** 对象:  StoredProcedure [dbo].[GetPositionByCondition]    脚本日期: 02/02/2009 16:43:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPositionByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetPositionByCondition]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeletePositionNatureRelationship]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeletePositionNatureRelationship]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPositionNatureRelationship]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPositionNatureRelationship]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllDepartmentOrderName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllDepartmentOrderName]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeletePositionDeptRelationship]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeletePositionDeptRelationship]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPositionDeptRelationship]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPositionDeptRelationship]
GO
--End  职位        ------------

/***********************************************************************************
**                                                                                **
**                               创建存储过程                                     **
**                                                                                **
***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[InsertAccount]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAccount]
(
	@PKID              INT OUT
	,@LoginName        NVARCHAR(50)
	,@Password         NVARCHAR(2000)
	,@UsbKey           NVARCHAR(2000)=NULL
	,@AccountType      INT
	,@EmployeeName     NVARCHAR(50)
	,@Email1           NVARCHAR(255)=NULL
	,@Email2           NVARCHAR(255)=NULL
	,@MobileNum        NVARCHAR(50)=NULL
	,@IsAcceptEmail    INT
	,@IsAcceptSMS      INT
	,@IsValidateUsbKey INT
	,@DepartmentId     INT=NULL
	,@PositionId       INT=NULL
	,@GradesID         INT=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO TAccount
			   ([LoginName]
				,[Password]
				,[UsbKey]
				,[AccountType]
				,[EmployeeName]
				,[Email1]
				,[Email2]
				,[MobileNum]
				,[IsAcceptEmail]
				,[IsAcceptSMS]
				,[IsValidateUsbKey]
				,[DepartmentId]
				,[PositionId]
				,[GradesID]
				)
		 VALUES
			   (@LoginName       
				,@Password        
				,@UsbKey          
				,@AccountType     
				,@EmployeeName    
				,@Email1          
				,@Email2          
				,@MobileNum       
				,@IsAcceptEmail   
				,@IsAcceptSMS     
				,@IsValidateUsbKey
				,@DepartmentId    
				,@PositionId
				,@GradesID 
				)
	SELECT @PKID=SCOPE_IDENTITY()
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[ValidationName]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidationName]
(
	@PKID INT=NULL
	,@LoginName        NVARCHAR(50)=NULL
	,@EmployeeName     NVARCHAR(50)=NULL
	,@MobileNum NVARCHAR(50)=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT * FROM TAccount
	WHERE (@PKID IS NULL OR [PKID]<>@PKID) 
		AND (@LoginName IS NULL OR [LoginName]=@LoginName)
		AND (@EmployeeName IS NULL OR [EmployeeName]=@EmployeeName)
		AND (@MobileNum IS NULL OR [MobileNum]=@MobileNum)
END
GO

/****** 对象:  StoredProcedure [dbo].[UpdateAccount]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAccount]
(
	@PKID              INT
	,@LoginName        NVARCHAR(50)
	,@AccountType      INT
	,@EmployeeName     NVARCHAR(50)
	,@Email1           NVARCHAR(255)=NULL
	,@Email2           NVARCHAR(255)=NULL
	,@MobileNum        NVARCHAR(50)=NULL
	,@IsAcceptEmail    INT
	,@IsAcceptSMS      INT
	,@IsValidateUsbKey INT
	,@DepartmentId     INT=NULL
	,@PositionId       INT=NULL
	,@GradesID         INT=NULL
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TAccount]
		SET [LoginName]         = @LoginName
			,[AccountType]      = @AccountType
			,[EmployeeName]     = @EmployeeName
			,[Email1]           = @Email1
			,[Email2]           = @Email2
			,[MobileNum]        = @MobileNum
			,[IsAcceptEmail]    = @IsAcceptEmail
			,[IsAcceptSMS]      = @IsAcceptSMS
			,[IsValidateUsbKey] = @IsValidateUsbKey
			,[DepartmentId]     = @DepartmentId
			,[PositionId]       = @PositionId
			,[GradesID]         = @GradesID
	WHERE [PKID]=@PKID
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAccount]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAccount]
(
	@PKID              INT
	,@AccountType      INT
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TAccount]
	   SET [AccountType]=@AccountType
	WHERE [PKID]=@PKID
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[ChangePassword]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
(
	@LoginName  NVARCHAR(50)
	,@Password  NVARCHAR(2000)
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TAccount]
	   SET [Password] = @Password
	WHERE [LoginName] = @LoginName
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[ResetPassword]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ResetPassword]
(
	@LoginName  NVARCHAR(50)
	,@Password  NVARCHAR(2000)
	,@IsValidateUsbKey INT
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TAccount]
	   SET [Password] = @Password
		  ,[IsValidateUsbKey] = @IsValidateUsbKey
	WHERE [LoginName] = @LoginName
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[ChangeUsbKey]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeUsbKey]
(
	@LoginName  NVARCHAR(50)
	,@UsbKey  NVARCHAR(2000)
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TAccount]
	   SET [UsbKey] = @UsbKey
	WHERE [LoginName] = @LoginName
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[GetAccount]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAccount]
(
	@PKID       INT=NULL
	,@LoginName NVARCHAR(50)=NULL
	,@EmployeeName     NVARCHAR(50)=NULL
	,@DepartmentId     INT=NULL
	,@PositionId       INT=NULL
	,@GradesID       INT=NULL
)
AS
BEGIN
	SELECT A.*,B.DepartmentName,C.PositionName,C.PositionDescription,C.MainDuties
    FROM [TAccount] A
	LEFT JOIN [TDepartment] B on A.DepartmentId=B.PKID
	LEFT JOIN [TPosition] C on A.PositionId=C.PKID
	WHERE (@PKID IS NULL OR A.[PKID]=@PKID) 
		AND (@LoginName IS NULL OR A.[LoginName]=@LoginName)
		
		AND (@EmployeeName IS NULL OR A.[EmployeeName] LIKE '%'+@EmployeeName+'%')
		AND (@DepartmentId IS NULL OR A.[DepartmentId]=@DepartmentId)
		AND (@PositionId IS NULL OR A.[PositionId]=@PositionId)
		AND (@GradesID IS NULL OR A.[GradesID]=@GradesID)
order by EmployeeName
END
GO









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
	ORDER BY AuthParentId ASC, PKID ASC
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
	SELECT DISTINCT B.PKID,B.AuthName,B.AuthParentId,B.NavigateUrl,B.IfHasDepartment,A.DepartmentID
	FROM TAccountAuth A 
		LEFT JOIN TAuth B ON A.AuthID = B.PKID
	WHERE AccountId=@AccountId
	ORDER BY B.AuthParentId ASC,B.PKID
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

/***********************************************************************************/
/************         Begin   公告,目标,公司规章        ****************************/
/***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[AppendixInsert]    脚本日期: 02/23/2009 15:55:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[AppendixInsert]
(
	    @PKID INT out,
        @BulletinID INT,
        @Title NVarChar(50),
        @Directory Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAppendix(BulletinID,Title,Directory)
          values(@BulletinID,@Title,@Directory)
          select @PKID=SCOPE_IDENTITY()
End
GO


/****** 对象:  StoredProcedure [dbo].[BulletinInsert]    脚本日期: 02/23/2009 16:05:30 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[BulletinInsert]
(
	    @PKID INT out,
        @Title NVarChar(50),
        @PublishTime DateTime,
        @Content Text,
        @DepartmentID INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TBulletin(Title,PublishTime,[Content],DepartmentID)
          values(@Title,@PublishTime,@Content,@DepartmentID)
          select @PKID=SCOPE_IDENTITY()
End
GO

/****** 对象:  StoredProcedure [dbo].[BulletinUpdate]    脚本日期: 02/23/2009 16:05:42 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[BulletinUpdate]
(
	    @PKID INT ,
        @Title NVarChar(50),
        @PublishTime DateTime,
        @Content Text,
        @DepartmentID INT
)
AS
Begin
          SET NOCOUNT OFF
          Update TBulletin set 
          Title=@Title ,
          PublishTime=@PublishTime ,
          [Content]=@Content ,
          DepartmentID=@DepartmentID
          where PKID=@PKID
          
End
GO

/****** 对象:  StoredProcedure [dbo].[CountAppendixByBulletinIDAndTitle]    脚本日期: 02/23/2009 16:05:57 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CountAppendixByBulletinIDAndTitle]
(
	      @BulletinID INT,
          @Title NVarChar(50)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TAppendix 
	      WHERE BulletinID=@BulletinID and Title=@Title
End
GO

/****** 对象:  StoredProcedure [dbo].[CountBulletinByTitle]    脚本日期: 02/23/2009 16:06:08 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CountBulletinByTitle]
(
	      @Title NVarChar(50)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TBulletin 
	      WHERE Title=@Title
End
GO

/****** 对象:  StoredProcedure [dbo].[CountBulletinByTitleDiffPKID]    脚本日期: 02/23/2009 16:06:35 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CountBulletinByTitleDiffPKID]
(
	      @PKID INT,
          @Title NVarChar(50)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TBulletin 
	      WHERE PKID<>@PKID and Title=@Title
End
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAppendixByBulletinID]    脚本日期: 02/23/2009 16:06:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteAppendixByBulletinID]
(
        @BulletinID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAppendix
	      WHERE BulletinID=@BulletinID
End
GO

/****** 对象:  StoredProcedure [dbo].[DeleteAppendixByPKID]    脚本日期: 02/23/2009 16:06:57 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteAppendixByPKID]
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAppendix
	      WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[DeleteBulletinByPKID]    脚本日期: 02/23/2009 16:07:09 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteBulletinByPKID]
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TBulletin
	      WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[GetAllBulletin]    脚本日期: 02/23/2009 16:07:22 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetAllBulletin]
AS
Begin
          SELECT PKID,Title,PublishTime ,DepartmentID
	      FROM TBulletin 
          order by  PublishTime Desc     
End
GO

/****** 对象:  StoredProcedure [dbo].[GetAppendixByBulletinID]    脚本日期: 02/23/2009 16:07:32 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetAppendixByBulletinID]
(
          @BulletinID INT
)
AS
Begin
          SELECT * 
	      FROM TAppendix Where
          BulletinID=@BulletinID
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetAppendixByPKID]    脚本日期: 02/23/2009 16:07:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetAppendixByPKID]
(
          @PKID INT
)
AS
Begin
          SELECT * 
	      FROM TAppendix Where
          PKID=@PKID
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByBulletinID]    脚本日期: 02/23/2009 16:08:07 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetBulletinByBulletinID]
(
          @PKID INT
)
AS
Begin
          SELECT * 
	      FROM TBulletin Where
          PKID=@PKID
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByCondition]    脚本日期: 02/23/2009 16:08:18 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetBulletinByCondition]
(
          @Title NVarChar(50),
          @PublishStartTime DateTime,
          @PublishEndTime DateTime
)
AS
Begin
          SELECT PKID,Title,PublishTime ,DepartmentID
	      FROM TBulletin Where
          (@Title='' or Title like '%' +@Title + '%' )
          And (datediff(dd, @PublishStartTime, PublishTime) >=0 )
          And (datediff(dd,PublishTime,@PublishEndTime)>=0  )
          order by  PublishTime Desc
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetBulletinByTime]    脚本日期: 02/23/2009 16:08:32 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetBulletinByTime]
(
          @PublishStartTime DateTime,
          @PublishEndTime DateTime
)
AS
Begin
          SELECT PKID,Title,PublishTime  
	      FROM TBulletin Where
          (datediff(dd, @PublishStartTime, PublishTime) >=0 )
          And (datediff(dd,PublishTime,@PublishEndTime)>=0  )
          order by  PublishTime Desc 
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetLastBulletin]    脚本日期: 02/23/2009 16:08:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetLastBulletin]
AS
Begin
          SELECT  PKID,Title,PublishTime ,DepartmentID
	      FROM TBulletin 
          order by  PublishTime Desc     
End
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixDeleteByCompanyReguId]    脚本日期: 02/23/2009 16:21:07 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CompanyReguAppendixDeleteByCompanyReguId]
(
	    @CompanyReguID INT
)
AS
Begin
	SET NOCOUNT OFF
	DELETE FROM [TCompanyReguAppendix] 
	WHERE CompanyReguID=@CompanyReguID
End
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixDeleteByPKID]    脚本日期: 02/23/2009 16:21:19 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CompanyReguAppendixDeleteByPKID]
(
	    @PKID INT
)
AS
Begin
	SET NOCOUNT OFF
	DELETE FROM [TCompanyReguAppendix] 
	WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[CompanyReguAppendixInsert]    脚本日期: 02/23/2009 16:21:36 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CompanyReguAppendixInsert]
(
	    @PKID INT OUT,
		@CompanyReguID INT,
        @FileName NVarChar(100),
        @Directory NVarChar(255),
        @UpLoadDate DATETIME
)
AS
Begin
        SET NOCOUNT OFF
		INSERT INTO [TCompanyReguAppendix]
			   ([CompanyReguID]
			   ,[FileName]
			   ,[Directory]
			   ,[UpLoadDate])
		 VALUES
			   (@CompanyReguID
			   ,@FileName
			   ,@Directory
			   ,@UpLoadDate)
		 SELECT @PKID=SCOPE_IDENTITY()
End
GO

/****** 对象:  StoredProcedure [dbo].[CompanyRegulationsDeleteByPKID]    脚本日期: 02/23/2009 16:21:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CompanyRegulationsDeleteByPKID]
(
	    @PKID INT
)
AS
Begin
	SET NOCOUNT OFF
	DELETE FROM [TCompanyRegulations] 
	WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[CompanyRegulationsInsert]    脚本日期: 02/23/2009 16:22:06 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[CompanyRegulationsInsert]
(
	    @PKID INT OUT,
		@CompanyReguType INT,
        @Title NVarChar(100),
        @Content Text
)
AS
Begin
          SET NOCOUNT OFF
          INSERT INTO [TCompanyRegulations]
           ([CompanyReguType]
           ,[Title]
           ,[Content])
		  VALUES
           (@CompanyReguType
           ,@Title
           ,@Content)
          select @PKID=SCOPE_IDENTITY()
End
GO

/****** 对象:  StoredProcedure [dbo].[GetCompanyReguAppendixByCompanyReguID]    脚本日期: 02/23/2009 16:22:23 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetCompanyReguAppendixByCompanyReguID]
(
	@CompanyReguID INT
)
AS
Begin
	SET NOCOUNT OFF
	SELECT [PKID]
      ,[CompanyReguID]
      ,[FileName]
      ,[Directory]
      ,[UpLoadDate]
	FROM [TCompanyReguAppendix]
	WHERE CompanyReguID=@CompanyReguID
END
GO

/****** 对象:  StoredProcedure [dbo].[GetCompanyRegulationsByType]    脚本日期: 02/23/2009 16:22:35 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetCompanyRegulationsByType]
(
	@CompanyReguType INT
)
AS
BEGIN
	SET NOCOUNT OFF
	SELECT [PKID]
      ,[CompanyReguType]
      ,[Title]
      ,[Content]
	FROM [TCompanyRegulations]
	WHERE [CompanyReguType]=@CompanyReguType
END
GO

/****** 对象:  StoredProcedure [dbo].[DeleteGoalByPKID]    脚本日期: 02/24/2009 09:57:31 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteGoalByPKID]
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TGoal
	      WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[DeleteGoalBySetHostID]    脚本日期: 02/24/2009 09:57:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteGoalBySetHostID]
(
        @SetHostID INT,
        @GoalType INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TGoal
	      WHERE SetHostID=@SetHostID and GoalType=@GoalType
End
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalByPKID]    脚本日期: 02/24/2009 09:57:57 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetGoalByPKID]
(
          @PKID INT
)
AS
Begin
          SELECT * 
	      FROM TGoal Where
          PKID=@PKID
         
End
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalBySetHostID]    脚本日期: 02/24/2009 09:58:10 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetGoalBySetHostID]
(
          @SetHostID INT,
          @GoalType INT
)
AS
Begin
          SELECT * 
	      FROM TGoal Where
          SetHostID=@SetHostID and GoalType=@GoalType
          order by SetTime desc
End
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalCountByTitle]    脚本日期: 02/24/2009 09:58:20 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetGoalCountByTitle]
(
          @SetHostID INT,
	      @Title NVarChar(50),
          @GoalType INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TGoal 
	      WHERE Title=@Title 
          and SetHostID=@SetHostID
          and GoalType=@GoalType
End
GO

/****** 对象:  StoredProcedure [dbo].[GetGoalCountByTitleDiffPKID]    脚本日期: 02/24/2009 09:58:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetGoalCountByTitleDiffPKID]
(
          @PKID INT,
          @SetHostID INT,
	      @Title NVarChar(50),
          @GoalType INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TGoal 
	      WHERE Title=@Title 
          and SetHostID=@SetHostID
          and GoalType=@GoalType
          and PKID<>@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[GetLastGoalBySetHostID]    脚本日期: 02/24/2009 09:58:58 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetLastGoalBySetHostID]
(
          @SetHostID INT,
          @GoalType INT
)
AS
Begin
          SELECT top 1 * 
	      FROM TGoal Where
          SetHostID=@SetHostID and GoalType=@GoalType 
          order by SetTime desc
End
GO

/****** 对象:  StoredProcedure [dbo].[GoalInsert]    脚本日期: 02/24/2009 09:59:08 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GoalInsert]
(
	    @PKID INT out,
        @SetHostID INT,
        @SetHostName NVarChar(50),
        @Title NVarChar(50),
        @Content Text,
        @SetTime DateTime,
        @GoalType INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TGoal(SetHostID,SetHostName,Title,[Content],
          SetTime,GoalType)
          values(@SetHostID,@SetHostName,@Title,@Content,
          @SetTime,@GoalType)
          select @PKID=SCOPE_IDENTITY()
End
GO

/****** 对象:  StoredProcedure [dbo].[GoalUpdate]    脚本日期: 02/24/2009 09:59:20 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GoalUpdate]
(
	    @PKID INT ,
        @SetHostID INT,
        @SetHostName NVarChar(50),
        @Title NVarChar(50),
        @Content Text,
        @SetTime DateTime,
        @GoalType INT
)
AS
Begin
          SET NOCOUNT OFF
          Update TGoal set 
          SetHostID=@SetHostID ,
          SetHostName=@SetHostName ,
          Title=@Title ,
          Content=@Content ,
          SetTime=@SetTime ,
          GoalType=@GoalType 
          where PKID=@PKID
          
End
GO
/***********************************************************************************/
/************         End     公告,目标,公司规章        ****************************/
/***********************************************************************************/

/***********************************************************************************/
/************              Begin   职位，部门           ****************************/
/***********************************************************************************/

/****** 对象:  StoredProcedure [dbo].[InsertDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDepartment]
(
	@PKID INT OUT,
	@DepartmentName nvarchar(50),
	@LeaderId int,
	@ParentId int
        ,@Address NVARCHAR(200)
        ,@Phone  NVARCHAR(50)
        ,@Fax NVARCHAR(50)
        ,@Others NVARCHAR(50)
        ,@Description Text
        ,@FoundationTime DateTime
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TDepartment]
           ([DepartmentName]
           ,[LeaderId]
           ,[ParentId]
        ,[Address]
        ,Phone 
        ,Fax 
        ,Others
        ,[Description] 
        ,FoundationTime)
     VALUES
           (@DepartmentName
           ,@LeaderId
           ,@ParentId
        ,@Address
        ,@Phone 
        ,@Fax 
        ,@Others
        ,@Description 
        ,@FoundationTime)
	SELECT @PKID=SCOPE_IDENTITY()
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[UpdateDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateDepartment]
(
	@PKID INT,
	@DepartmentName NVARCHAR(50),
	@LeaderId INT,
	@ParentId INT=NULL
        ,@Address NVARCHAR(200)
        ,@Phone  NVARCHAR(50)
        ,@Fax NVARCHAR(50)
        ,@Others NVARCHAR(50)
        ,@Description Text
        ,@FoundationTime DateTime
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TDepartment]
	SET [DepartmentName] = @DepartmentName
      ,[LeaderId] = @LeaderId
        ,[Address]=@Address
        ,Phone=@Phone
        ,Fax=@Fax
        ,Others=@Others
        ,[Description]=@Description
        ,FoundationTime=@FoundationTime
        ,[ParentId] = @ParentId
	WHERE [PKID]=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[DeleteDepartment]    脚本日期: 02/23/2009 16:06:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteDepartment]
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          DELETE FROM [TDepartment]
	      WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[GetDepartment]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDepartment]
(
	@PKID INT=NULL
	,@DepartmentName NVARCHAR(50)=NULL
	,@LeaderId INT=NULL
	,@ParentId INT=NULL
)
AS
BEGIN
	SELECT [PKID]
      ,[DepartmentName]
      ,[LeaderId]
      ,[ParentId]
        ,[Address]
        ,Phone 
        ,Fax 
        ,Others
        ,[Description] 
        ,FoundationTime
	FROM [TDepartment]
	WHERE (@PKID IS NULL OR [PKID]=@PKID)
		AND (@DepartmentName IS NULL OR [DepartmentName]=@DepartmentName)
		AND (@LeaderId IS NULL OR [LeaderId]=@LeaderId)
		AND (@ParentId IS NULL OR [ParentId]=@ParentId)
	ORDER BY [ParentId],pkid ASC
END
GO

/****** 对象:  StoredProcedure [dbo].[GetDepartmentByEmployeeId]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDepartmentByEmployeeId]
(
	@EmployeeId INT
)
AS
BEGIN
	SELECT B.[PKID]
		,B.[DepartmentName]
		,B.[LeaderId]
		,B.[ParentId] 
        ,B.[Address]
        ,B.Phone 
        ,B.Fax 
        ,B.Others
        ,B.[Description] 
        ,B.FoundationTime

	FROM [TAccount] A
		LEFT JOIN [TDepartment] B ON A.DepartmentId=B.PKID
	WHERE A.PKID=@EmployeeId
END
GO

/****** 对象:  StoredProcedure [dbo].[GetParentDeptByDeptId]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetParentDeptByDeptId]
(
	@PKID INT
)
AS
BEGIN
	SELECT B.[PKID]
		,B.[DepartmentName]
		,B.[LeaderId]
		,B.[ParentId] 
        ,B.[Address]
        ,B.Phone 
        ,B.Fax 
        ,B.Others
        ,B.[Description] 
        ,B.FoundationTime
	FROM [TDepartment] A
		LEFT JOIN [TDepartment] B ON A.ParentId=B.PKID
	WHERE A.PKID=@PKID
END
GO


/****** 对象:  StoredProcedure [dbo].[InsertPositionGrade]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPositionGrade]
(
	@PKID INT OUT,
	@PositionGradeName NVARCHAR(50),
	@PositionGradeDescription text='',
	@Sequence INT
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TPositionGrade]
           ([PositionGradeName]
           ,[PositionGradeDescription]
			,[Sequence])
     VALUES
           (@PositionGradeName
           ,@PositionGradeDescription
			,@Sequence)
	SELECT @PKID=SCOPE_IDENTITY()
    RETURN @@Rowcount
END
GO


/****** 对象:  StoredProcedure [dbo].[UpdatePositionGrade]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePositionGrade]
(
	@PKID INT,
	@PositionGradeName NVARCHAR(50),
	@PositionGradeDescription text='',
	@Sequence INT
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [TPositionGrade]
	SET [PositionGradeName] = @PositionGradeName
		,[Sequence]=@Sequence
      ,[PositionGradeDescription] = @PositionGradeDescription
	WHERE [PKID]=@PKID
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[DeletePositionGrade]    脚本日期: 02/23/2009 16:06:46 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeletePositionGrade]
(
        @PKID INT
)
AS
Begin
	SET NOCOUNT OFF
	DELETE FROM [TPositionGrade]
	WHERE PKID=@PKID
End
GO

/****** 对象:  StoredProcedure [dbo].[GetPositionGrade]    脚本日期: 02/02/2009 16:43:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPositionGrade]
(
	@PKID INT=NULL
	,@PositionGradeName NVARCHAR(50)=NULL
)
AS
BEGIN
	SELECT [PKID]
      ,[PositionGradeName]
      ,[PositionGradeDescription]
	  ,[Sequence]
  FROM [TPositionGrade]
	WHERE (@PKID IS NULL OR [PKID]=@PKID)
		AND (@PositionGradeName IS NULL OR [PositionGradeName]=@PositionGradeName)
	ORDER BY Sequence ASC
END
GO

/***********************************************************************************/
/************              End     职位，部门           ****************************/
/***********************************************************************************/



/***********************************************************************************/
/************              Begin   特殊日期			    ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetSpecialDateByPKID
(
	    @PKID INT=NULL
)
AS
Begin
          SET NOCOUNT OFF
          select * from TSpecialDate where @PKID IS NULL OR [PKID]=@PKID
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
CREATE PROCEDURE SpecialDateInsert
(
	    @PKID INT out,
        @SpecialDate DATETIME,
        @IsWork  INT,
        @SpecialHeader NVarChar(50),
        @SpecialDescription NVarChar(255),
        @SpecialForeColor NVarChar(50),
        @SpecialBackColor NVarChar(50)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TSpecialDate(SpecialDate,IsWork ,SpecialHeader,
                 SpecialDescription,SpecialForeColor,SpecialBackColor)
          values(@SpecialDate,@IsWork,@SpecialHeader,@SpecialDescription,
                 @SpecialForeColor,@SpecialBackColor)
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
CREATE PROCEDURE DeleteSpecialDateByDate
(
	    @SpecialDate DATETIME
)
AS
Begin
          SET NOCOUNT OFF
          delete from TSpecialDate where SpecialDate=@SpecialDate
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
/***********************************************************************************/
/************         End     特殊日期			        ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin     员工欢迎信		        ****************************/
/***********************************************************************************/


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE WelcomeMailInsert
(
        @PKID				INT out,
		@Content			TEXT,
		@EnableAutoSend		INT,
        @MailType           int
)
AS
BEGIN
          SET NOCOUNT ON
          INSERT INTO TWelcomeMail
           (
				[Content],
				EnableAutoSend,
                MailType
			)
          values
			(
				@Content,
				@EnableAutoSend,
                @MailType
			)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE GetLastestWelcomeMail
AS
BEGIN
    SELECT TOP 1
			PKID,
			[Content],
			EnableAutoSend,
            MailType
    FROM TWelcomeMail
	ORDER BY PKID DESC
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
CREATE PROCEDURE GetLastestWelcomeMailByTypeID
(
        @MailType           int
)
AS
BEGIN
    SELECT TOP 1
			PKID,
			[Content],
			EnableAutoSend
    FROM TWelcomeMail
    where MailType=@MailType
	ORDER BY PKID DESC
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/***********************************************************************************/
/************         End     员工欢迎信		        ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin     电子签名		        ****************************/
/***********************************************************************************/

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertElectronIdiograph
(
	@PKID           INT out,
	@AccountID      INT,
	@Picture			  Image	
)
AS
Begin
	SET NOCOUNT OFF
	INSERT INTO TElectronIdiograph(AccountID,Picture)
	VALUES (@AccountID,@Picture)
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
CREATE PROCEDURE UpdateElectronIdiograph
(
  @AccountID     INT,
	@Picture				    Image		
)
AS
Begin
          SET NOCOUNT OFF
          update TElectronIdiograph
          set [Picture]=  @Picture  
          where AccountID=@AccountID
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
create PROCEDURE GetElectronIdiographByAccountID
(
        @AccountID INT
)
AS
Begin
          SELECT * FROM TElectronIdiograph
	      WHERE AccountID = @AccountID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeleteElectronIdiographByAccountID]
(
        @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TElectronIdiograph
	      WHERE AccountID=@AccountID
End
GO
/***********************************************************************************/
/************         End     电子签名		        ****************************/
/***********************************************************************************/


/***********************************************************************************/
/************              start    便签             ****************************/
/***********************************************************************************/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[NotesInsert]
(
	    @PKID INT out,
        @Content NVarChar(2000),
        @AccountID int,
        @Type int,
        @Start DATETIME,
		@End DATETIME,
		@RangeStart DATETIME= NULL,
		@RangeEnd DATETIME = NULL,
		@TypeString NVarChar(250)= NULL
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TNotes([Content],AccountID,[Type],Start,[End],RangeStart,RangeEnd,TypeString)
          values(@Content,@AccountID,@Type,@Start,@End,@RangeStart,@RangeEnd,@TypeString)
          select @PKID=SCOPE_IDENTITY()
End
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[NotesUpdate]
(
	    @PKID INT out,
        @Content NVarChar(2000),
        @Type int,
        @Start DATETIME,
		@End DATETIME,
		@RangeStart DATETIME= NULL,
		@RangeEnd DATETIME = NULL,
		@TypeString NVarChar(250)= NULL
)
AS
Begin
          SET NOCOUNT OFF
          Update TNotes set 
          [Content]=@Content ,
          [Type]=@Type ,
          [Start]=@Start ,
          [End]=@End,
          RangeStart=@RangeStart,
		  RangeEnd=@RangeEnd,
		  TypeString=@TypeString
          where PKID=@PKID
End
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[NotesDelete]
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TNotes
	      WHERE PKID=@PKID
End
GO



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetNoteByID]
(
	@PKID INT
)
AS
BEGIN
	SET NOCOUNT OFF
	SELECT *
	FROM [TNotes]
	WHERE PKID=@PKID
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetNotesByDate]
(
	@AccountID INT,
    @Start DateTime,
	@End DateTime
)
AS
BEGIN
	SET NOCOUNT OFF
	select * from TNotes where 
	(AccountID=@AccountID or PKID in (Select NoteID from TNotesShare where AccountID=@AccountID))
	and ((datediff(dd,Start,@End)>=0 and datediff(dd,@Start,[End])>=0 and Type=1) or 
		(Type <>1 and datediff(dd,RangeStart,@End)>=0 and (RangeEnd=NULL or datediff(dd,@Start,RangeEnd)>=0) ))
END
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ShareInsert]
(
	    @PKID INT out,
        @NoteID INT,
        @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TNotesShare(NoteID,AccountID)
          values(@NoteID,@AccountID)
          select @PKID=SCOPE_IDENTITY()
End
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[ShareDelete]
(
        @NoteID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TNotesShare
	      WHERE NoteID=@NoteID
End
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[QuitShare]
(
        @NoteID INT,
        @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TNotesShare
	      WHERE NoteID=@NoteID and AccountID=@AccountID
End
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetShare]
(
	@NoteID INT
)
AS
BEGIN
	SET NOCOUNT OFF
	SELECT *
	FROM [TNotesShare]
	WHERE NoteID=@NoteID
END
GO

/***********************************************************************************/
/************              end    便签             ****************************/
/***********************************************************************************/
--Begin              工作任务        ------------
CREATE PROCEDURE [dbo].[AddWorkTask]
	@Account int,
	@Title nvarchar(200),
	@Content nvarchar(2000),
	@Priority int,
	@Status int,
	@StartDate datetime,
	@EndDate datetime,
	@Description nvarchar(2000),
	@Remark nvarchar(2000),
	@PKID int OUTPUT
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TWorkTask] (
	[Account],
	[Title],
	[Content],
	[Priority],
	[Status],
	[StartDate],
	[EndDate],
	[Description],
	[Remark]
) VALUES (
	@Account,
	@Title,
	@Content,
	@Priority,
	@Status,
	@StartDate,
	@EndDate,
	@Description,
	@Remark
)
SET @PKID = SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[UpdateWorkTask]
	@PKID int,
	@Account int,
	@Title nvarchar(200),
	@Content nvarchar(2000),
	@Priority int,
	@Status int,
	@StartDate datetime,
	@EndDate datetime,
	@Description nvarchar(2000),
	@Remark nvarchar(2000)
AS
SET NOCOUNT ON
UPDATE [dbo].[TWorkTask] SET
	[Account] = @Account,
	[Title] = @Title,
	[Content] = @Content,
	[Priority] = @Priority,
	[Status] = @Status,
	[StartDate] = @StartDate,
	[EndDate] = @EndDate,
	[Description] = @Description,
	[Remark] = @Remark
WHERE
	[PKID] = @PKID
GO


CREATE PROCEDURE [dbo].[DeleteWorkTask]
	@PKID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TWorkTask] WHERE	[PKID] = @PKID
DELETE FROM [dbo].[TWorkTaskResponsible] WHERE	[WorkTaskID] = @PKID
DELETE FROM [dbo].[TWorkTaskQA] WHERE	[WorkTaskID] = @PKID
GO

CREATE PROCEDURE [dbo].[GetWorkTask]
	@PKID int
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	[TWorkTask].[PKID],
	[Account],
	TAccount.EmployeeName as [AccountName],
	[Title],
	[Content],
	[Priority],
	[Status],
	[StartDate],
	[EndDate],
	[Description],
	[Remark]
FROM
	[dbo].[TWorkTask],TAccount
WHERE
	[TWorkTask].[PKID] = @PKID
AND TAccount.PKID = Account

SELECT AccountID,TAccount.EmployeeName as [AccountName]
FROM dbo.TWorkTaskResponsible,TAccount
WHERE TAccount.PKID = AccountID
AND WorkTaskID = @PKID


SELECT
	[TWorkTaskQA].[PKID],
	[WorkTaskID],
	[QAccount],
	TQAccount.EmployeeName as [QAccountName],
	[Question],
	[QuestionDate],
	[AAccount],
	TAAccount.EmployeeName as [AAccountName],
	[Answer],
	[AnswerDate]
FROM
	TAccount as TQAccount,[dbo].[TWorkTaskQA] left join TAccount as TAAccount on TAAccount.PKID = AAccount
WHERE
	WorkTaskID = @PKID
AND TQAccount.PKID = QAccount
ORDER BY [QuestionDate] DESC
GO

CREATE PROCEDURE [dbo].[GetMyWorkTaskByCondition]
	@Title	NVARCHAR(200),
	@From	DATETIME,
	@To		DATETIME,
	@Priority	INT,
	@IfApprove	INT,
	@IfOngoing	INT,
	@IfFinish	INT,
	@IfFailure	INT,
	@AccountID	INT
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	[TWorkTask].[PKID],
	[Account],
	TAccount.EmployeeName as [AccountName],
	[Title],
	[Content],
	[Priority],
	[Status],
	[StartDate],
	[EndDate],
	[Description],
	[Remark]
FROM
	[dbo].[TWorkTask],TAccount
WHERE
	TAccount.PKID = Account
AND (@AccountID = -1 OR [Account] = @AccountID)
AND Title like '%'+@Title+'%'
AND DATEDIFF(DD,StartDate,@To)>=0
AND DATEDIFF(DD,@From,EndDate)>=0
AND DATEDIFF(dd,@From,@To)>=0
AND (@Priority =-1 OR Priority = @Priority)
AND ((Status = @IfApprove)
OR (Status = @IfOngoing)
OR (Status = @IfFinish)
OR (Status = @IfFailure))
ORDER BY [Status],[EndDate],[PKID]
GO


CREATE PROCEDURE [dbo].[GetResponsibleWorkTaskByCondition]
	@Title	NVARCHAR(200),
	@From	DATETIME,
	@To		DATETIME,
	@Priority	INT,
	@IfApprove	INT,
	@IfOngoing	INT,
	@IfFinish	INT,
	@IfFailure	INT,
	@AccountID	INT
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	distinct [TWorkTask].[PKID],
	[Account],
	TAccount.EmployeeName as [AccountName],
	[Title],
	[Content],
	[Priority],
	[Status],
	[StartDate],
	[EndDate],
	[Description],
	[Remark]
FROM
	[dbo].[TWorkTask],TAccount,dbo.TWorkTaskResponsible
WHERE
	TAccount.PKID = Account
AND [TWorkTask].PKID = TWorkTaskResponsible.WorkTaskID
AND TWorkTaskResponsible.AccountID = @AccountID
AND Title like '%'+@Title+'%'
AND DATEDIFF(DD,StartDate,@To)>=0
AND DATEDIFF(DD,@From,EndDate)>=0
AND DATEDIFF(dd,@From,@To)>=0
AND (@Priority =-1 OR Priority = @Priority)
AND ((Status = @IfApprove)
OR (Status = @IfOngoing)
OR (Status = @IfFinish)
OR (Status = @IfFailure))
ORDER BY [Status],[EndDate],[PKID]
GO

CREATE PROCEDURE [dbo].[InsertWorkTaskResponsible]
	@WorkTaskID int,
	@AccountID int,
	@PKID int OUTPUT
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TWorkTaskResponsible] (
	[WorkTaskID],
	[AccountID]
) VALUES (
	@WorkTaskID,
	@AccountID
)
SET @PKID = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[DeleteWorkTaskResponsible]
	@WorkTaskID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TWorkTaskResponsible]
WHERE
	[WorkTaskID] = @WorkTaskID
GO


CREATE PROCEDURE [dbo].[AddWorkTaskQA]
	@WorkTaskID int,
	@QAccount int,
	@Question nvarchar(500),
	@QuestionDate datetime,
	@AAccount int,
	@Answer nvarchar(500),
	@AnswerDate datetime,
	@PKID int OUTPUT
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TWorkTaskQA] (
	[WorkTaskID],
	[QAccount],
	[Question],
	[QuestionDate],
	[AAccount],
	[Answer],
	[AnswerDate]
) VALUES (
	@WorkTaskID,
	@QAccount,
	@Question,
	@QuestionDate,
	@AAccount,
	@Answer,
	@AnswerDate
)
SET @PKID = SCOPE_IDENTITY()
GO


CREATE PROCEDURE [dbo].[UpdateWorkTaskQA]
	@PKID int,
	@WorkTaskID int,
	@QAccount int,
	@Question nvarchar(500),
	@QuestionDate datetime,
	@AAccount int,
	@Answer nvarchar(500),
	@AnswerDate datetime
AS
SET NOCOUNT ON
UPDATE [dbo].[TWorkTaskQA] SET
	[WorkTaskID] = @WorkTaskID,
	[QAccount] = @QAccount,
	[Question] = @Question,
	[QuestionDate] = @QuestionDate,
	[AAccount] = @AAccount,
	[Answer] = @Answer,
	[AnswerDate] = @AnswerDate
WHERE
	[PKID] = @PKID
GO


CREATE PROCEDURE [dbo].[DeleteWorkTaskQA]
	@PKID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TWorkTaskQA]
WHERE
	[PKID] = @PKID
GO


CREATE PROCEDURE [dbo].[GetWorkTaskQA]
	@PKID int
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	[TWorkTaskQA].[PKID],
	[WorkTaskID],
	[QAccount],
	TQAccount.EmployeeName as [QAccountName],
	[Question],
	[QuestionDate],
	[AAccount],
	TAAccount.EmployeeName as [AAccountName],
	[Answer],
	[AnswerDate]
FROM
	TAccount as TQAccount,[dbo].[TWorkTaskQA] left join TAccount as TAAccount on TAAccount.PKID = AAccount
WHERE
	[TWorkTaskQA].[PKID] = @PKID
AND TQAccount.PKID = QAccount
GO
--End                工作任务        ------------


--Begin              岗位性质        ------------SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddPositionNature]
	@Name nvarchar(255),
	@Description nvarchar(255),
	@PKID int OUTPUT
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TPositionNature] (
	[Name],
	[Description]
) VALUES (
	@Name,
	@Description
)
SET @PKID = SCOPE_IDENTITY()SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePositionNature]
	@PKID int,
	@Name nvarchar(255),
	@Description nvarchar(255)
AS
SET NOCOUNT ON
UPDATE [dbo].[TPositionNature] SET
	[Name] = @Name,
	[Description] = @Description
WHERE
	[PKID] = @PKIDSET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePositionNature]
	@PKID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TPositionNature]
WHERE
	[PKID] = @PKIDSET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPositionNature]	@PKID intASSET NOCOUNT ONSET TRANSACTION ISOLATION LEVEL READ COMMITTEDSELECT	[PKID],	[Name],	[Description]FROM	[dbo].[TPositionNature]WHERE	[PKID] = @PKIDSET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllPositionNature]ASSET NOCOUNT ONSET TRANSACTION ISOLATION LEVEL READ COMMITTEDSELECT	[PKID],	[Name],	[Description]FROM	[dbo].[TPositionNature]SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPositionNatureByPositionID]	@PositionID		intASSET NOCOUNT ONSET TRANSACTION ISOLATION LEVEL READ COMMITTEDSELECT	[PKID],	[Name],	[Description]FROM	[dbo].[TPositionNature]WHERE PKID IN (SELECT PositionNatureID FROM dbo.TPositionNatureRelationship WHERE PositionID = @PositionID)SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPositionDeptByPositionID]	@PositionID		intASSET NOCOUNT ONSET TRANSACTION ISOLATION LEVEL READ COMMITTEDSELECT *FROM	[dbo].[TDepartment]WHERE PKID IN (SELECT DeptID FROM dbo.TPositionDeptRelationship WHERE PositionID = @PositionID)SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetPositionNatureListByName]
	@Name			NVARCHAR(255)
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	[PKID],
	[Name],
	[Description]
FROM
	[dbo].[TPositionNature]
WHERE [Name] like '%'+@Name+'%'
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CountPositionNatureByNameDiffPKID]
	@PKID			INT=NULL,
	@Name			NVARCHAR(255)
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT counts=COUNT([PKID]) FROM [dbo].[TPositionNature]
	WHERE (@PKID = -1 OR [PKID]<>@PKID) AND ([Name]=@Name)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CountPositionByNatureId]
	@PositionNatureId	INT
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT counts=COUNT([PKID]) 
FROM [dbo].[TPositionNatureRelationship]
WHERE [PositionNatureID]=@PositionNatureId--End              岗位性质        --------------Begin             职位           ------------SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPosition]
(
	@PositionName nvarchar(50),
	@LevelId int,
	@PositionDescription text,
	@Number nvarchar(255),
	@Reviewer int,
	@PositionStatus int,
	@Version nvarchar(255),
	@Commencement datetime,
	@Summary text,
	@MainDuties text,
	@ReportScope text,
	@ControlScope text,
	@Coordination text,
	@Authority text,
	@Education text,
	@ProfessionalBackground text,
	@WorkExperience text,
	@Qualification text,
	@Competence text,
	@OtherRequirements text,
	@KnowledgeAndSkills text,
	@RelatedProcesses text,
	@ManagementSkills text,
	@AuxiliarySkills text,
	@PKID int OUTPUT
)
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TPosition] (
	[PositionName],
	[LevelId],
	[PositionDescription],
	[Number],
	[Reviewer],
	[PositionStatus],
	[Version],
	[Commencement],
	[Summary],
	[MainDuties],
	[ReportScope],
	[ControlScope],
	[Coordination],
	[Authority],
	[Education],
	[ProfessionalBackground],
	[WorkExperience],
	[Qualification],
	[Competence],
	[OtherRequirements],
	[KnowledgeAndSkills],
	[RelatedProcesses],
	[ManagementSkills],
	[AuxiliarySkills]
) VALUES (
	@PositionName,
	@LevelId,
	@PositionDescription,
	@Number,
	@Reviewer,
	@PositionStatus,
	@Version,
	@Commencement,
	@Summary,
	@MainDuties,
	@ReportScope,
	@ControlScope,
	@Coordination,
	@Authority,
	@Education,
	@ProfessionalBackground,
	@WorkExperience,
	@Qualification,
	@Competence,
	@OtherRequirements,
	@KnowledgeAndSkills,
	@RelatedProcesses,
	@ManagementSkills,
	@AuxiliarySkills
)

SET @PKID = SCOPE_IDENTITY()/****** 对象:  StoredProcedure [dbo].[UpdatePosition]    脚本日期: 02/02/2009 16:43:47 ******/SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePosition]
(
	@PKID int,
	@PositionName nvarchar(50),
	@LevelId int,
	@PositionDescription text,
	@Number nvarchar(255),
	@Reviewer int,
	@PositionStatus int,
	@Version nvarchar(255),
	@Commencement datetime,
	@Summary text,
	@MainDuties text,

	@ReportScope text,
	@ControlScope text,
	@Coordination text,
	@Authority text,
	@Education text,
	@ProfessionalBackground text,
	@WorkExperience text,
	@Qualification text,
	@Competence text,
	@OtherRequirements text,
	@KnowledgeAndSkills text,
	@RelatedProcesses text,
	@ManagementSkills text,
	@AuxiliarySkills text
)
AS
SET NOCOUNT ON
UPDATE [dbo].[TPosition] SET
	[PositionName] = @PositionName,
	[LevelId] = @LevelId,
	[PositionDescription] = @PositionDescription,
	[Number] = @Number,
	[Reviewer] = @Reviewer,
	[PositionStatus] = @PositionStatus,
	[Version] = @Version,
	[Commencement] = @Commencement,
	[Summary] = @Summary,
	[MainDuties] = @MainDuties,
	[ReportScope] = @ReportScope,
	[ControlScope] = @ControlScope,
	[Coordination] = @Coordination,
	[Authority] = @Authority,
	[Education] = @Education,
	[ProfessionalBackground] = @ProfessionalBackground,
	[WorkExperience] = @WorkExperience,
	[Qualification] = @Qualification,
	[Competence] = @Competence,
	[OtherRequirements] = @OtherRequirements,
	[KnowledgeAndSkills] = @KnowledgeAndSkills,
	[RelatedProcesses] = @RelatedProcesses,
	[ManagementSkills] = @ManagementSkills,
	[AuxiliarySkills] = @AuxiliarySkills
WHERE
	[PKID] = @PKID
RETURN @@Rowcount/****** 对象:  StoredProcedure [dbo].[DeletePosition]    脚本日期: 02/23/2009 16:06:46 ******/SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[DeletePosition]
(
        @PKID INT
)
AS
Begin
SET NOCOUNT OFF
DELETE FROM [TPositionNatureRelationship]	WHERE PositionID=@PKID
DELETE FROM [TPositionDeptRelationship]	WHERE PositionID=@PKID
DELETE FROM [TPosition]	WHERE PKID=@PKID
End
/****** 对象:  StoredProcedure [dbo].[GetPosition]    脚本日期: 02/02/2009 16:43:47 ******/SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPosition]
(
	@PKID INT=NULL
	,@PositionName NVARCHAR(50)=NULL
	,@LevelId INT=NULL
)
AS
BEGIN
	SELECT
	[PKID],
	[PositionName],
	[LevelId],
	[PositionDescription],
	[Number],
	[Reviewer],
	[PositionStatus],
	[Version],
	[Commencement],
	[Summary],
	[MainDuties],
	[ReportScope],
	[ControlScope],
	[Coordination],
	[Authority],
	[Education],
	[ProfessionalBackground],
	[WorkExperience],
	[Qualification],
	[Competence],
	[OtherRequirements],
	[KnowledgeAndSkills],
	[RelatedProcesses],
	[ManagementSkills],
	[AuxiliarySkills]
FROM [TPosition]
WHERE (@PKID IS NULL OR [PKID]=@PKID)
	AND (@PositionName IS NULL OR [PositionName]=@PositionName)
	AND (@LevelId IS NULL OR [LevelId]=@LevelId)
order by [PositionName]
END
/****** 对象:  StoredProcedure [dbo].[GetPositionByCondition]    脚本日期: 02/02/2009 16:43:47 ******/SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPositionByCondition]
(
	@PKID INT=NULL
	,@PositionName NVARCHAR(50)=NULL
)
AS
BEGIN
	SELECT
	[PKID],
	[PositionName],
	[LevelId],
	[PositionDescription],
	[Number],
	[Reviewer],
	[PositionStatus],
	[Version],
	[Commencement],
	[Summary],
	[MainDuties],
	[ReportScope],
	[ControlScope],
	[Coordination],
	[Authority],
	[Education],
	[ProfessionalBackground],
	[WorkExperience],
	[Qualification],
	[Competence],
	[OtherRequirements],
	[KnowledgeAndSkills],
	[RelatedProcesses],
	[ManagementSkills],
	[AuxiliarySkills]
FROM [TPosition]
WHERE (@PKID IS NULL OR [PKID]=@PKID)
	AND (@PositionName IS NULL OR [PositionName] LIKE '%'+@PositionName+'%')
END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePositionNatureRelationship]
	@PositionID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TPositionNatureRelationship]	WHERE	[PositionID] = @PositionID

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPositionNatureRelationship]
	@PKID int OUTPUT,
	@PositionID int,
	@PositionNatureID int
AS
SET NOCOUNT ON
INSERT INTO [TPositionNatureRelationship](
	PositionID,
	PositionNatureID
) VALUES(
	@PositionID,
	@PositionNatureID
)
SET @PKID = SCOPE_IDENTITY()



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*start PositionDeptRelationship*/

CREATE PROCEDURE [dbo].[DeletePositionDeptRelationship]
	@PositionID int
AS
SET NOCOUNT ON
DELETE FROM [dbo].[TPositionDeptRelationship]	WHERE	[PositionID] = @PositionID


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllDepartmentOrderName]
AS
BEGIN
	SELECT [PKID]
      ,[DepartmentName]
      ,[LeaderId]
      ,[ParentId]
        ,[Address]
        ,Phone 
        ,Fax 
        ,Others
        ,[Description] 
        ,FoundationTime
	FROM [TDepartment]
	ORDER BY DepartmentName
END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPositionDeptRelationship]
	@PKID int OUTPUT,
	@PositionID int,
	@DeptID int
AS
SET NOCOUNT ON
INSERT INTO [TPositionDeptRelationship](
	PositionID,
	DeptID
) VALUES(
	@PositionID,
	@DeptID
)

SET @PKID = SCOPE_IDENTITY()
--End              职位            ------------