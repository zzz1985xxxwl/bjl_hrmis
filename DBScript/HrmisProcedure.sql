--------------------------------------------------
/*                 删除所有存储过程             */
--------------------------------------------------

--Begin              自定义流程        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDiyProcess]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertDiyProcess]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDiyProcess]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateDiyProcess]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiyProcessDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DiyProcessDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDiyProcessByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDiyProcessByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDiyProcessByProcessType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDiyProcessByProcessType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDiyProcessByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDiyProcessByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDiyStepByDiyProcessID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDiyStepByDiyProcessID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDiySteps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertDiySteps]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteDiyStepByProcessID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteDiyStepByProcessID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDiyStepByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDiyStepByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployeeDiyProcess]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployeeDiyProcess]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeDiyProcessByAccountIDAndType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeDiyProcessByAccountIDAndType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeDiyProcessByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeDiyProcessByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeDiyProcessByEmployeeIDAndTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeDiyProcessByEmployeeIDAndTypeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountDiyProcessByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountDiyProcessByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountDiyProcessByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountDiyProcessByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAccountByDiyProcessID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAccountByDiyProcessID]
GO

 
--End                自定义流程        ------------	

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentByBackAccontsIDAndAuthID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentByBackAccontsIDAndAuthID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CancelAccountAllAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CancelAccountAllAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetAccountAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetAccountAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountAuth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountAuth]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountsByAuthIdAndDeptId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountsByAuthIdAndDeptId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceViewCalendarByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceViewCalendarByCondition]
GO

--Begin               部门历史      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DepartmentHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DepartmentHistoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentByDepartmentIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentByDepartmentIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartmentByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartmentByDateTime]
GO
--End              部门历史      -------------

--Begin               职位历史      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PositionHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PositionHistoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionByPositionIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionByPositionIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionByDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PositionHistoryDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PositionHistoryDelete]
GO
--End               职位历史      -------------

--Begin          员工管理      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByAccountID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeBasicInfoByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeBasicInfoByAccountID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeBasicInfoByCompanyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeBasicInfoByCompanyID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllCompanyHaveEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllCompanyHaveEmployee]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeHistoryUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeHistoryUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryBasicInfoByEmployeeHistoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryBasicInfoByEmployeeHistoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSocietyWorkAgeByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSocietyWorkAgeByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeePhotoByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeePhotoByAccountID]
GO


--Begin             员工福利       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployeeWelfareByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployeeWelfareByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeWelfareByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeWelfareByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeWelfareByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeWelfareByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeWelfareByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeWelfareByAccountID]
GO
--End             员工福利       -------------

--Begin             员工福利历史       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeWelfareHistoryByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeWelfareHistoryByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateEmployeeWelfareHistoryByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateEmployeeWelfareHistoryByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeWelfareHistoryByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeWelfareHistoryByAccountID]
GO
--End             员工福利历史       -------------



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeBasicInfoByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeBasicInfoByDateTime]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByAccountIDAndTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByAccountIDAndTime]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParameterInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ParameterInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParameterUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ParameterUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParameterDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ParameterDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountParameterByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountParameterByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountParameterByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountParameterByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetParameterByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetParameterByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeHistoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountEmployeeNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountEmployeeNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllEmployeeBasicInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllEmployeeBasicInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllEmployeeInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllEmployeeInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByPositionID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByDepartmentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByDepartmentID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByBasicConditionRescurise]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByBasicConditionRescurise]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByBasicConditionNotRescurise]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByBasicConditionNotRescurise]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetManagerByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetManagerByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByResidencePermitDays]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByResidencePermitDays]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountEmployeeByNationalityID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountEmployeeByNationalityID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeContractInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeContractInsert]
GO 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeContractUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeContractUpdate]
GO 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeContractDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeContractDelete]
GO 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLastContractInAllTypeByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLastContractInAllTypeByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCurrentContractByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCurrentContractByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeContractByContractTypeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeContractByContractTypeId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeContractByContractId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeContractByContractId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeContractByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeContractByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllEmployeeContract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllEmployeeContract]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeContractByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeContractByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetParameterByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetParameterByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeadersByParentDepartmentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeadersByParentDepartmentID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeesExceptLeaderByDepartmentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeesExceptLeaderByDepartmentID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByLetter]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByLetter]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeNamesByFisrt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeNamesByFisrt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByBasicConditionAndLikeLoginName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByBasicConditionAndLikeLoginName]
GO

--End               员工、权限         ------------
--Begin             调休         ------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAdjustRestByAdjustID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAdjustRestByAdjustID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRestByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRestByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRestByAccountIDAndYear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRestByAccountIDAndYear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRestByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRestByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRestInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRestInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAdjustRestByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAdjustRestByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRestHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRestHistoryInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRestHistoryDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRestHistoryDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRestHistoryByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRestHistoryByAccountID]
GO


--End              调休       ------------
--Begin             员工修改历史         ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeHistoryByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeHistoryByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryBasicInfoByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryBasicInfoByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryBasicInfoByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryBasicInfoByDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryByDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryByDateTimeAndAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryByDateTimeAndAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeBasicInfoByDepartmentIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeBasicInfoByDepartmentIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeByDepartmentIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeByDepartmentIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryAtLeaveDate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryAtLeaveDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryBasicInfoAtLeaveDate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryBasicInfoAtLeaveDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeHistoryByEmployeeHistoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeHistoryByEmployeeHistoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeHistoryDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeHistoryDetails]
GO

--End               员工修改历史         ------------

--Begin             公告、目标、年假         ------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].VacationInsert') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[VacationInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].VacationUpdate') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[VacationUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].CountVacationByAccountID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountVacationByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].DeleteVacationByAccountID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteVacationByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].DeleteVacationByVacationID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteVacationByVacationID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetAllVacation') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllVacation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetVacationByCondition') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVacationByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetVacationByAccountID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVacationByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetLastVacationByAccountID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLastVacationByAccountID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetVacationByAccountIDAndTimeSpan') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVacationByAccountIDAndTimeSpan]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetNearVacationByAccountIDAndTime') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNearVacationByAccountIDAndTime]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetVacationByVacationID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVacationByVacationID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].ApplyAssessConditionInsert') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ApplyAssessConditionInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].ApplyAssessConditionDelete') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ApplyAssessConditionDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].ApplyAssessConditionDeleteByEmployeeContractID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ApplyAssessConditionDeleteByEmployeeContractID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetApplyAssessConditionByCurrDate') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetApplyAssessConditionByCurrDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetApplyAssessConditionByEmployeeContractID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetApplyAssessConditionByEmployeeContractID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].GetApplyAssessConditionByPKID') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetApplyAssessConditionByPKID]
GO



--End               公告、目标、年假         ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceByEmpId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceByEmpId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeAttendanceInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeAttendanceInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeAttendanceDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeAttendanceDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeAttendanceDeleteByEmpAndTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeAttendanceDeleteByEmpAndTime]
GO
--End               考勤       -------------


--Begin                技能及员工技能       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SkillInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SkillInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SkillUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SkillUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SkillDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SkillDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSkillByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSkillByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountSkillByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountSkillByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSkillsByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSkillsByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountSkillByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountSkillByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeSkillInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeSkillInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeSkillByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeSkillByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountEmployeeSkillBySkillID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountEmployeeSkillBySkillID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSkillByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSkillByAccountID]
GO

--end                技能及员工技能       -------------


--Begin                合同类型      -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContractTypeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContractTypeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContractTypeUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContractTypeUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContractTypeDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContractTypeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountContractTypeByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountContractTypeByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountContractTypeByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountContractTypeByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContractTypeByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetContractTypeByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContractTypeByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetContractTypeByCondition]
GO

--End                 合同类型      -------------


--Begin    记录合同模板的书签      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContractBookMarkInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContractBookMarkInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteContractBookMarkByContractTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteContractBookMarkByContractTypeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetContractBookMarkByContractTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetContractBookMarkByContractTypeID]
GO

--End    记录合同模板的书签      -------------


--Begin    记录员工合同的书签和值       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeContractBookMarkInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeContractBookMarkInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeContractBookMarkByEmployeeContractID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeContractBookMarkByEmployeeContractID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeContractBookMarkByContractID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeContractBookMarkByContractID]
GO
--End    记录员工合同的书签和值       -------------

--end          员工管理      -------------

--Begin          考勤管理      -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLeaveRequest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLeaveRequest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLeaveRequestItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLeaveRequestItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLeaveRequest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLeaveRequest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteLeaveRequest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteLeaveRequest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteLeaveRequestItemByLeaveRequestID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteLeaveRequestItemByLeaveRequestID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestItemByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestItemByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestItemByLeaveRequestID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestItemByLeaveRequestID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestByAccountIDForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestByAccountIDForCalendar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestItemByLeaveRequestIDForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestItemByLeaveRequestIDForCalendar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllLeaveRequestByAccountIDForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllLeaveRequestByAccountIDForCalendar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllLeaveRequestItemByLeaveRequestIDForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllLeaveRequestItemByLeaveRequestIDForCalendar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestDetailByAccountIDAndDate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestDetailByAccountIDAndDate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountLeaveRequestByLeaveRequestTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountLeaveRequestByLeaveRequestTypeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestFlowByLeaveRequestID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestFlowByLeaveRequestID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestFlowByLeaveRequestItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestFlowByLeaveRequestItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestFlowByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestFlowByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteLeaveRequestFlowByLeaveRequestID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteLeaveRequestFlowByLeaveRequestID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountLeaveRequestInRepeatDateDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountLeaveRequestInRepeatDateDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLeaveRequestFlow]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLeaveRequestFlow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestItemByAccountIDAndRequestStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestItemByAccountIDAndRequestStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SumLeaveRequestCostTimeByEmployeeIDAndStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SumLeaveRequestCostTimeByEmployeeIDAndStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLeaveRequestStatusByLeaveRequestItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLeaveRequestStatusByLeaveRequestItemID]
GO
  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLeaveRequestItemUseDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLeaveRequestItemUseDetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConfirmLeaveRequest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConfirmLeaveRequest]
GO 
  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestConfirmHistoryByOperatorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestConfirmHistoryByOperatorID]
GO 
  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLeaveRequestByCondition]
GO 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetVacationUsedDetailByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetVacationUsedDetailByAccountID]
GO
--End            考勤管理      -------------
--End            外出      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OutApplicationInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OutApplicationInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OutApplicationDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OutApplicationDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOutApplicationItemByOutApplicationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOutApplicationItemByOutApplicationID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationItemByOutApplicationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationItemByOutApplicationID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationItemByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationItemByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllOutApplicationByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllOutApplicationByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationByOutApplicationID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationByOutApplicationID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OutApplicationUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OutApplicationUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOutApplicationItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOutApplicationItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOutApplicationItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOutApplicationItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOutApplicationItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOutApplicationItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountOutApplicationInRepeatDateDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountOutApplicationInRepeatDateDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOutApplicationFlow]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOutApplicationFlow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationFlowByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationFlowByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOutApplicationFlowByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOutApplicationFlowByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOutApplicationItemStatusByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOutApplicationItemStatusByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNeedConfirmOutApplication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNeedConfirmOutApplication]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutConfirmHistroy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutConfirmHistroy]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationForCalendar]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllOutApplicationForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllOutApplicationForCalendar]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationDetailByEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationDetailByEmployee]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOutApplicationByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOutApplicationByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOutApplicationItemAdjustByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOutApplicationItemAdjustByItemID]
GO

--End            外出      -------------

--End            加班      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OverWorkInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OverWorkInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OverWorkDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OverWorkDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOverWorkItemByOverWorkID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOverWorkItemByOverWorkID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkItemByOverWorkID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkItemByOverWorkID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkItemByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkItemByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllOverWorkByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllOverWorkByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkByOverWorkID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkByOverWorkID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OverWorkUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OverWorkUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOverWorkItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOverWorkItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountOverWorkInRepeatDateDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountOverWorkInRepeatDateDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOverWorkFlow]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertOverWorkFlow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkFlowByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkFlowByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteOverWorkFlowByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteOverWorkFlowByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOverWorkItemAdjustByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOverWorkItemAdjustByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateOverWorkItemStatusByItemID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateOverWorkItemStatusByItemID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNeedConfirmOverWork]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNeedConfirmOverWork]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkConfirmHistroy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkConfirmHistroy]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkForCalendar]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllOverWorkForCalendar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllOverWorkForCalendar]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkDetailByEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkDetailByEmployee]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetOverWorkByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetOverWorkByCondition]
GO

--End            加班      -------------


--Begin          假期类别      -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LeaveRequestTypeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LeaveRequestTypeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LeaveRequestTypeUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[LeaveRequestTypeUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LeaveRequestTypeDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[LeaveRequestTypeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestTypeByPkid]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetLeaveRequestTypeByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestTypeByName]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetLeaveRequestTypeByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLeaveRequestTypeByNameLike]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetLeaveRequestTypeByNameLike]
GO
--End            假期类别      -------------

--Begin               考勤       -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeInAndOutByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeInAndOutByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployeeInAndOutRecord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployeeInAndOutRecord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeInAndOutRecord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeInAndOutRecord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeInAndOutRecord]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeInAndOutRecord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAttendanceReadTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAttendanceReadTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAttendanceReadTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAttendanceReadTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAttendanceReadTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAttendanceReadTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReadDataHistoryByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReadDataHistoryByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLastSuccessReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLastSuccessReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLastReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLastReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReadDataHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReadDataHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceReadTimeByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceReadTimeByPkid]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAttendanceInAndOutRecordLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAttendanceInAndOutRecordLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAttendanceInAndOutRecordLogByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAttendanceInAndOutRecordLogByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAttendanceInAndOutRecordLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAttendanceInAndOutRecordLog]
GO

--End               考勤       -------------


--Begin              税制        -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateTaxCutoffPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateTaxCutoffPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTaxCutoffPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTaxCutoffPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateForeignTaxCutoffPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateForeignTaxCutoffPoint]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetForeignTaxCutoffPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetForeignTaxCutoffPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertIndividualIncomeTax]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertIndividualIncomeTax]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateTaxBand]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateTaxBand]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteTaxBandByTaxBandID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteTaxBandByTaxBandID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTaxBandByTaxBandID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTaxBandByTaxBandID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllTaxBand]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllTaxBand]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTaxBandCountByBindMin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTaxBandCountByBindMin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTaxBandCountByBindMinDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTaxBandCountByBindMinDiffPKID]
GO

--End              税制        -------------


--Begin             帐套参数        ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAccountSetPara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAccountSetPara]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAccountSetPara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAccountSetPara]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAccountSetParaByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAccountSetParaByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAccountSetParaByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAccountSetParaByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetParaByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetParaByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetParaByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetParaByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetParaByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetParaByCondition]
GO


--End               帐套参数         ------------


--Begin             帐套       ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAccountSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAccountSet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAccountSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAccountSet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAccountSetByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAccountSetByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAccountSetByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAccountSetByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetByName]
GO



--End               帐套         ------------

--Begin             帐套项        ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAccountSetItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAccountSetItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAccountSetItemByAccountSetID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAccountSetItemByAccountSetID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAccountSetItemByAccountSetID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAccountSetItemByAccountSetID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAccountSetItemByAccountSetParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAccountSetItemByAccountSetParaID]
GO

--End              帐套项         ------------


--Begin    员工薪资       -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployeeAccountSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployeeAccountSet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeAccountSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeAccountSet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeAccountSetByEmployeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeAccountSetByEmployeeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountEmployeeAccountSetByAccountSetID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountEmployeeAccountSetByAccountSetID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeAccountSetByAccountSetID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeAccountSetByAccountSetID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertEmployeeSalaryHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertEmployeeSalaryHistory]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeSalaryHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeSalaryHistory]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSalaryByEmployeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSalaryByEmployeeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSalaryHistoryByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSalaryHistoryByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAdjustSalaryHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAdjustSalaryHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAdjustSalaryHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAdjustSalaryHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustSalaryHistoryByEmployeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustSalaryHistoryByEmployeeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustSalaryHistoryByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustSalaryHistoryByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustSalaryHistoryByEmployeeIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustSalaryHistoryByEmployeeIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSalaryByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSalaryByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeSalaryHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeSalaryHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllEmployeeAccountSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllEmployeeAccountSet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSalaryHistoryByEmployeeIdAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSalaryHistoryByEmployeeIdAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeSalaryHistoryByEmployeeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeSalaryHistoryByEmployeeId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeAccountSetByAccountSetParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeAccountSetByAccountSetParaID]
GO

--End    员工薪资       -------------

--Begin               考评管理       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplateItemInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplateItemInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountTemplateItemByTitle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountTemplateItemByTitle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplateItemByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplateItemByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllTemplateItems]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllTemplateItems]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTemplateItemsByConditon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTemplateItemsByConditon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplatePaperInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplatePaperInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplatePIShipInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplatePIShipInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPIShipByItemId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPIShipByItemId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplatePaperUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplatePaperUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplatePaperDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplatePaperDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllAssessTemplatePaper]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllAssessTemplatePaper]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplatePaperByPaperName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplatePaperByPaperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTemplatePapersExactlyByPaperName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTemplatePapersExactlyByPaperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplatePaperByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplatePaperByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTemplateItemIdInPaperByPaperId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTemplateItemIdInPaperByPaperId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountTemplatePaperByPaperNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountTemplatePaperByPaperNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountTemplatePaperByPaperName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountTemplatePaperByPaperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplateItemUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplateItemUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplateItemDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplateItemDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountTemplateItemByQuestionDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountTemplateItemByQuestionDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePaperAndItemRelation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePaperAndItemRelation]
GO

--End               考评管理       -------------


--begin             考评活动         ------------

/****** 对象:  StoredProcedure [dbo].[InsertAssessActivity]    脚本日期: 04/16/2009 12:54:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAssessActivity]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertAssessActivity]

/****** 对象:  StoredProcedure [dbo].[InsertAssessActivityItem]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAssessActivityItem]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertAssessActivityItem]

/****** 对象:  StoredProcedure [dbo].[InsertAssessActivityPaper]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAssessActivityPaper]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertAssessActivityPaper]

/****** 对象:  StoredProcedure [dbo].[UpdateAssessActivityPaper]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAssessActivityPaper]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateAssessActivityPaper]

/****** 对象:  StoredProcedure [dbo].[updateAssessActivity]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[updateAssessActivity]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[updateAssessActivity]

/****** 对象:  StoredProcedure [dbo].[UpdateAssessActivityEmployeeVisible]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateAssessActivityEmployeeVisible]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateAssessActivityEmployeeVisible]

/****** 对象:  StoredProcedure [dbo].[DeleteAssessActivityItemByAssessActivityID]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAssessActivityItemByAssessActivityID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAssessActivityItemByAssessActivityID]

/****** 对象:  StoredProcedure [dbo].[DeleteAssessActivityPaperByAssessActivityPaperID]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAssessActivityPaperByAssessActivityPaperID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAssessActivityPaperByAssessActivityPaperID]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityById]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityById]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityItemById]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityItemById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityItemById]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityItemByAssessActivityPaperId]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityItemByAssessActivityPaperId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityItemByAssessActivityPaperId]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityPaperById]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityPaperById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityPaperById]

/****** 对象:  StoredProcedure [dbo].[CountOpeningAssessActivityByEmployeeID]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountOpeningAssessActivityByEmployeeID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CountOpeningAssessActivityByEmployeeID]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByEmployee]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityByEmployee]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityByEmployee]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByEmployeeStatus]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityByEmployeeStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityByEmployeeStatus]

/****** 对象:  StoredProcedure [dbo].[GetAnnualAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAnnualAssessActivityByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAnnualAssessActivityByCondition]

/****** 对象:  StoredProcedure [dbo].[GetContractAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetContractAssessActivityByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetContractAssessActivityByCondition]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityByCondition]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByManagerName]    脚本日期: 04/16/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityHistoryByEmployeeName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityHistoryByEmployeeName]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAssessActivityByManagerName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAssessActivityByManagerName]

/****** 对象:  StoredProcedure [dbo].[DeleteAssessActivityByPkid]    脚本日期: 09/03/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteAssessActivityByPkid]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteAssessActivityByPkid]

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByManagerName]    脚本日期: 09/03/2009 12:54:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteActivityPaperByassessActivityID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteActivityPaperByassessActivityID]

--end               考评活动         ------------


--begin                报销单管理       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReimburseInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ReimburseInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReimburseItemInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ReimburseItemInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReimburseByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReimburseByID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReimburseItemByReimburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReimburseItemByReimburseID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseItemByReimburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseItemByReimburseID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseFlowByReimburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseFlowByReimburseID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReimburseFlowInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ReimburseFlowInsert]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReimburseFlowByReimburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReimburseFlowByReimburseID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByEmployeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByEmployeeID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReimburseByEmployeeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReimburseByEmployeeID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByCondition]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReiburseTotalByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReiburseTotalByCondition]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerCountByReiburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerCountByReiburseID]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReiburseByCustomerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReiburseByCustomerID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByEmployeeIDConsumeTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByEmployeeIDConsumeTime]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByEmployeeIDBillingTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByEmployeeIDBillingTime]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimburseByReimburseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimburseByReimburseID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateReimburseNextStepIndex]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateReimburseNextStepIndex]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateReimburseStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateReimburseStatus]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetMyAuditingReimburses]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetMyAuditingReimburses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReimbursesHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReimbursesHistory]
GO

--end                报销单管理       -------------

--begin                班别       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDutyClass]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertDutyClass]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateDutyClass]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateDutyClass]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteDutyClass]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteDutyClass]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDutyClassByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDutyClassByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDutyClassByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDutyClassByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountDutyClassByDutyClassName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountDutyClassByDutyClassName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountDutyClassByDutyClassDiffPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountDutyClassByDutyClassDiffPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPlanDutyTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPlanDutyTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePlanDutyTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePlanDutyTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePlanDutyTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePlanDutyTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyTableByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyTableByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyTableByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyTableByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyTableByConditionAndAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyTableByConditionAndAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertPlanDutyDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertPlanDutyDetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePlanDutyDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePlanDutyDetail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePlanDutyDetailByPlanDutyTableID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePlanDutyDetailByPlanDutyTableID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyDetailByPlanDutyTableID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyDetailByPlanDutyTableID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyDetailByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyDetailByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTPlanDuty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTPlanDuty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePlanDutyByPlanDutyTableID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePlanDutyByPlanDutyTableID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletePlanDutyByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeletePlanDutyByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyByPlanDutyTableID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyByPlanDutyTableID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountPlanDutyTableByPlanDutyTableName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountPlanDutyTableByPlanDutyTableName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountPlanDutyByPlanDutyDiffPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountPlanDutyByPlanDutyDiffPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyDetailByAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyDetailByAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyDetailByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyDetailByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPlanDutyDetailByAccountIDAndPlanDutyID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPlanDutyDetailByAccountIDAndPlanDutyID]
GO


--end                班别       -------------

--begin                培训       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainFBQuesInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainFBQuesInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainFBQuesUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainFBQuesUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainFBItemInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainFBItemInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteTrainFBItemByQuesID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteTrainFBItemByQuesID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainFBItemByQuesID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainFBItemByQuesID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteTrainFBQuesByQuesID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteTrainFBQuesByQuesID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainFBQuesByQuesID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainFBQuesByQuesID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainFBQuesByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainFBQuesByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountFBQuestionByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountFBQuestionByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountFBQuestionByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountFBQuestionByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseTraineeDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseTraineeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseTraineeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseTraineeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseSkillInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseSkillInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseSkillDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseSkillDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseFBResultInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseFBResultInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseFBResultDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseFBResultDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseFBInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseFBInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseFBDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CourseFBDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainCourseBySkillID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainCourseBySkillID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseFBResultByCourseIDAndTraineeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseFBResultByCourseIDAndTraineeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseFBByCourseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseFBByCourseID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseFBResultByCourseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseFBResultByCourseID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseSkillByCourseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseSkillByCourseID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseSkillByCourseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseSkillByCourseID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseTraineeByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseTraineeByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCourseTraineeByCourseID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCourseTraineeByCourseID]
GO


--Begin              培训反馈问卷       -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FeedBackPaperInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FeedBackPaperInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FeedBackPIShipInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FeedBackPIShipInsert]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FeedBackPaperUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FeedBackPaperUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteFeedBackPaperByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteFeedBackPaperByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFeedBackPaperByPaperName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFeedBackPaperByPaperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFeedBackPaperByPaperId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFeedBackPaperByPaperId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetQustionItemByPaperId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetQustionItemByPaperId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountFeedBackPaperByPaperNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountFeedBackPaperByPaperNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountFeedBackPaperByPaperName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountFeedBackPaperByPaperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteFeedBackRelation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteFeedBackRelation]
GO


--end                培训       -------------


--Begin               短信业务      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNeedConfirmMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNeedConfirmMessage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetToBeConfirmMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetToBeConfirmMessage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PhoneMessageUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PhoneMessageUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PhoneMessageInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PhoneMessageInsert]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPhoneMessageByType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPhoneMessageByType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPhoneMessageByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPhoneMessageByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetToBeConfirmPhoneMessageByAssessorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetToBeConfirmPhoneMessageByAssessorID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPhoneMessageByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPhoneMessageByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FinishPhoneMessageByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FinishPhoneMessageByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountToBeConfirmMessageWithSameAssessor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountToBeConfirmMessageWithSameAssessor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PhoneMessageDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PhoneMessageDelete]
GO


--End               短信业务      -------------

--Begin            FileCargo       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FileCargoInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FileCargoInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FileCargoUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FileCargoUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FileCargoDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FileCargoDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFileCargoByFileCargoID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFileCargoByFileCargoID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFileCargoByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFileCargoByAccountID]
GO

--End              FileCargo        -------------



--begion 培训申请
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainApplicationDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainApplicationDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateTrainAppStatusByTrainAppID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateTrainAppStatusByTrainAppID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteTrainAppFlowByTrainAppID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteTrainAppFlowByTrainAppID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainAppFlowByTrainAppID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainAppFlowByTrainAppID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTrainAppFlow]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTrainAppFlow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainAppTraineeByTrainAppId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainAppTraineeByTrainAppId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainApplicationByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainApplicationByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainApplicationByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainApplicationByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainAppTraineeInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainAppTraineeInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainAppTraineeDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainAppTraineeDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainApplicationUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainApplicationUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TrainApplicationInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[TrainApplicationInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConfirmingTrainApplication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConfirmingTrainApplication]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainAppByApplicationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainAppByApplicationId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTrainAppConfirmHistoryByOperatorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTrainAppConfirmHistoryByOperatorID]
GO

--end 培训申请-------


--Begin            AdjustRule       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRuleInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRuleInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRuleUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRuleUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdjustRuleDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AdjustRuleDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRuleByAdjustRuleID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRuleByAdjustRuleID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRuleByNameLike]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRuleByNameLike]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAdjustRuleByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAdjustRuleByNameDiffPKID]
GO


--End              AdjustRule        -------------

--Begin            EmployeeAdjustRule       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeAdjustRuleInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[EmployeeAdjustRuleInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateEmployeeAdjustRuleByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateEmployeeAdjustRuleByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEmployeeAdjustRuleByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEmployeeAdjustRuleByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAdjustRuleByAccountID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAdjustRuleByAccountID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEmployeeAdjustRuleByAdjustRuleID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEmployeeAdjustRuleByAdjustRuleID]
GO

--End            EmployeeAdjustRule       -------------

--Begin            TAssessTemplatePaperBindPostion       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssessTemplatePaperBindPostionInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AssessTemplatePaperBindPostionInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteAssessTemplatePaperBindPostionByPaperID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteAssessTemplatePaperBindPostionByPaperID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplatePaperBindPostionByPaperID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplatePaperBindPostionByPaperID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessTemplatePaperBindPostionByPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessTemplatePaperBindPostionByPositionID]
GO

--End            TAssessTemplatePaperBindPostion       -------------


--Begin            客户信息       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerInfoInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CustomerInfoInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerInfoUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CustomerInfoUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerInfoDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CustomerInfoDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerInfoByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerInfoByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerIDInfoByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerIDInfoByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCustomerInfoByNameLike]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCustomerInfoByNameLike]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCustomerInfoByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCustomerInfoByNameDiffPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCustomerInfoByCodeDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCustomerInfoByCodeDiffPKID]
GO

--End              客户信息        -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAssessReadMaxIOTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAssessReadMaxIOTime]
GO


--Begin            SystemError       -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SystemErrorInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SystemErrorInsert]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteSystemErrorByTypeAndMarkID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteSystemErrorByTypeAndMarkID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSystemErrorByTypeAndMarkID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSystemErrorByTypeAndMarkID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllSystemError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllSystemError]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetBaseError]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetBaseError]
GO



--Begin               职位历史      -------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PositionHistoryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PositionHistoryInsert]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddPositionNature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddPositionNature]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertPositionNatureRelationship]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertPositionNatureRelationship]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionByPositionIDAndDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionByPositionIDAndDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionNatureByPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionNatureByPositionID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionByDateTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionByDateTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PositionHistoryDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PositionHistoryDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionHistoryByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionHistoryByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPositionHistoryByPositionID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPositionHistoryByPositionID]
GO
--End               职位历史      -------------

--End              SystemError        -------------

--------------------------------------------------
/*                 创建所有存储过程             */
--------------------------------------------------

--Begin               考勤管理         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertLeaveRequest
(
	    @PKID				INT out,
        @AccountID			INT,
        @LeaveRequestTypeID INT,
        @Reason				Text,
        @SubmitDate			DateTime,
		@AbsentFrom         DateTime,
		@AbsentTo           DateTime,
		@AbsentHours        Decimal(25,2),
        @DiyProcess			Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TLeaveRequest(AccountID,LeaveRequestTypeID,Reason,SubmitDate,AbsentFrom,AbsentTo,AbsentHours,DiyProcess)
          values(@AccountID,@LeaveRequestTypeID,@Reason,@SubmitDate,@AbsentFrom,@AbsentTo,@AbsentHours,@DiyProcess)
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
CREATE PROCEDURE UpdateLeaveRequest
(
	    @PKID				INT,
        @AccountID			INT,
        @LeaveRequestTypeID INT,
        @Reason				Text,
        @SubmitDate			DateTime,
		@AbsentFrom         DateTime,
		@AbsentTo           DateTime,
		@AbsentHours        Decimal(25,2)
)
AS
Begin
          SET NOCOUNT OFF
          update TLeaveRequest 
		  set   AccountID=@AccountID,
				LeaveRequestTypeID=@LeaveRequestTypeID,
				Reason=@Reason,
				SubmitDate=@SubmitDate,
				AbsentFrom=@AbsentFrom,
				AbsentTo=@AbsentTo,
				AbsentHours=@AbsentHours
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
CREATE PROCEDURE InsertLeaveRequestItem
(
	    @PKID				INT out,
        @LeaveRequestID		INT,
        @Status				INT,
        @AbsentFrom			DateTime,
        @AbsentTo			DateTime,
        @AbsentHours		Decimal(25,2),
		@NextProcessID		INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TLeaveRequestItem(LeaveRequestID,Status,AbsentFrom,AbsentTo,AbsentHours,NextProcessID)
          values(@LeaveRequestID,@Status,@AbsentFrom,@AbsentTo,@AbsentHours,@NextProcessID)
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
CREATE PROCEDURE DeleteLeaveRequest
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          delete from TLeaveRequest where PKID=@PKID
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
CREATE PROCEDURE DeleteLeaveRequestItemByLeaveRequestID
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          delete from TLeaveRequestItem where LeaveRequestID=@LeaveRequestID
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
CREATE PROCEDURE GetLeaveRequestByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          select TLeaveRequest.*,TLeaveRequestType.Name as AbsenceTypeName,TLeaveRequestType.LeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
                 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
		  from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequest.PKID=@PKID
			and TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
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
CREATE PROCEDURE GetLeaveRequestByAccountIDForCalendar
(
	    @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          select TLeaveRequest.*,TLeaveRequestType.Name as LeaveRequestTypeName,TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
		  		 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
          from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequest.AccountID=@AccountID
			and TLeaveRequest.PKID in 
				---0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
				(select LeaveRequestID from TLeaveRequestItem where Status in (3,4,5,8))
			and TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
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
CREATE PROCEDURE GetLeaveRequestItemByLeaveRequestIDForCalendar
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TLeaveRequestItem
		  where TLeaveRequestItem.LeaveRequestID=@LeaveRequestID
			---0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
			and Status in (3,4,5,8)
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
CREATE PROCEDURE GetAllLeaveRequestByAccountIDForCalendar
(
	    @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          select TLeaveRequest.*,TLeaveRequestType.Name as LeaveRequestTypeName,TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
		  		 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
          from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequest.AccountID=@AccountID
			and TLeaveRequest.PKID in 
				---0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
				(select LeaveRequestID from TLeaveRequestItem where Status in (0,1,3,4,5,7,8))
			and TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
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
CREATE PROCEDURE GetAllLeaveRequestItemByLeaveRequestIDForCalendar
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TLeaveRequestItem
		  where TLeaveRequestItem.LeaveRequestID=@LeaveRequestID
			---0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
			and Status in (0,1,3,4,5,7,8)
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
CREATE PROCEDURE GetLeaveRequestDetailByAccountIDAndDate 
(
    @Date DateTime,
    @AccountID int
)
AS
Begin
select TLeaveRequest.PKID 
from TLeaveRequest,TLeaveRequestItem
where TLeaveRequest.PKID = TLeaveRequestItem.LeaveRequestID
and AccountID=@AccountID  
and (datediff(dd,TLeaveRequestItem.AbsentFrom,@Date)>=0)
and (datediff(dd,@Date,TLeaveRequestItem.AbsentTo)>=0)
---0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
and (TLeaveRequestItem.Status in (0,1,3,4,5,7,8))
order by AccountID Asc
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
CREATE PROCEDURE GetLeaveRequestItemByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
         select *
		  from TLeaveRequestItem
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
CREATE PROCEDURE GetLeaveRequestItemByLeaveRequestID
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
		  from TLeaveRequestItem
		  where TLeaveRequestItem.LeaveRequestID=@LeaveRequestID
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
CREATE PROCEDURE CountLeaveRequestByLeaveRequestTypeID
(
	    @LeaveRequestTypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          select counts = COUNT(PKID)
		  from TLeaveRequest
		  where LeaveRequestTypeID=@LeaveRequestTypeID
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
CREATE PROCEDURE CountLeaveRequestInRepeatDateDiffPKID
(
	@AccountID int,
	@From datetime,
	@To datetime,
    @PKID int=null
)
AS
Begin
          SET NOCOUNT OFF
          select counts=count(PKID)
          from TLeaveRequest
          where pkid in
           (
          select a.PKID
		  from TLeaveRequest as a left join TLeaveRequestItem as b on a.PKID=b.LeaveRequestID
		  where AccountID=@AccountID 
          and (datediff(ss,b.AbsentTo,@From)<0 )
          and (datediff(ss,@To,b.AbsentFrom)<0 )
          and  Status not in (2,6) 
          and  (@PKID is null or a.PKID=-1 or a.PKID not in (@PKID) )
          group by a.PKID
           )
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
CREATE PROCEDURE GetLeaveRequestByAccountID
(
	    @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          select TLeaveRequest.*,TLeaveRequestType.Name as AbsenceTypeName,TLeaveRequestType.LeastHour,
				 TLeaveRequestType.Name as LeaveRequestTypeName,
				 TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
                 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
		  from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequest.AccountID=@AccountID
			and TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
		  order by TLeaveRequest.AbsentFrom desc
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
CREATE PROCEDURE InsertLeaveRequestFlow
(
	    @PKID INT out,
        @LeaveRequestItemID INT,
        @OperatorID INT,
        @Operation INT,
        @OperationTime DateTime,
        @Remark Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TLeaveRequestFlow(LeaveRequestItemID,OperatorID,Operation,
                 OperationTime,Remark)
          values(@LeaveRequestItemID,@OperatorID,@Operation,@OperationTime,@Remark)
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
CREATE PROCEDURE DeleteLeaveRequestFlowByLeaveRequestID
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          delete from TLeaveRequestFlow
		  where LeaveRequestItemID in (select pkid from TLeaveRequestItem where LeaveRequestID = @LeaveRequestID)
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
CREATE PROCEDURE GetLeaveRequestFlowByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
          from TLeaveRequestFlow
		  where TLeaveRequestFlow.PKID=@PKID
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
CREATE PROCEDURE GetLeaveRequestFlowByLeaveRequestID
(
	    @LeaveRequestID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
          from TLeaveRequestFlow
		  where LeaveRequestItemID in (select pkid from TLeaveRequestItem where LeaveRequestID = @LeaveRequestID)
		  order by LeaveRequestItemID,PKID
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
CREATE PROCEDURE GetLeaveRequestFlowByLeaveRequestItemID
(
	    @LeaveRequestItemID INT
)
AS
Begin
          SET NOCOUNT OFF
          select *
          from TLeaveRequestFlow
		  where LeaveRequestItemID = @LeaveRequestItemID
		  order by TLeaveRequestFlow.pkid
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
CREATE PROCEDURE SumLeaveRequestCostTimeByEmployeeIDAndStatus
(
	@AccountID int,
	@Status int,
	@LeaveRequestTypeID int
)
AS
Begin
    Select sum(TLeaveRequestItem.AbsentHours) as TotalHour
    from TLeaveRequest,TLeaveRequestItem
	where AccountID=@AccountID 
	  and Status=@Status 
	  and LeaveRequestTypeID=@LeaveRequestTypeID
	  and TLeaveRequest.PKID = TLeaveRequestItem.LeaveRequestID
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
CREATE PROCEDURE GetLeaveRequestItemByAccountIDAndRequestStatus
(
	@AccountID int,
	@Status int,
	@LeaveRequestTypeID int
)
AS
Begin
    Select TLeaveRequestItem.*
    from TLeaveRequest,TLeaveRequestItem
	where AccountID=@AccountID 
	  and (@Status = -1 or Status=@Status)
	  and (@LeaveRequestTypeID = -1 or LeaveRequestTypeID=@LeaveRequestTypeID)
	  and TLeaveRequest.PKID = TLeaveRequestItem.LeaveRequestID
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
CREATE PROCEDURE UpdateLeaveRequestStatusByLeaveRequestItemID
(
	    @LeaveRequestItemID INT,
        @Status INT,
        @NextProcessID INT
)
AS
Begin
          SET NOCOUNT OFF
          update dbo.TLeaveRequestItem set
            [Status] = @Status, NextProcessID = @NextProcessID
          where PKID=@LeaveRequestItemID
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
CREATE PROCEDURE UpdateLeaveRequestItemUseDetail
(
        @LeaveRequestItemID INT,
        @UseList Nvarchar(200)
)
AS
Begin
          SET NOCOUNT OFF
          update dbo.TLeaveRequestItem set
            UseList = @UseList
          where PKID=@LeaveRequestItemID
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
CREATE PROCEDURE GetConfirmLeaveRequest
AS
Begin
          SET NOCOUNT OFF
          select TLeaveRequest.*,TLeaveRequestType.LeastHour,
				 TLeaveRequestType.Name as LeaveRequestTypeName,
				 TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
		  		 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
         from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
			and TLeaveRequest.PKID in (
				select distinct TLeaveRequest.PKID 
				from TLeaveRequest,TLeaveRequestItem
				where TLeaveRequestItem.LeaveRequestID = TLeaveRequest.PKID
				and TLeaveRequestItem.Status in (1,4,7,8) 
			)
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
CREATE PROCEDURE GetLeaveRequestConfirmHistoryByOperatorID
(
	    @OperatorID INT,
        @From DateTime,
        @To   DateTime
)
AS
Begin
          SET NOCOUNT OFF
         select TLeaveRequest.*,TLeaveRequestType.Name as AbsenceTypeName,TLeaveRequestType.LeastHour,
				 TLeaveRequestType.Name as LeaveRequestTypeName,
				 TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
		  		 TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay
             from TLeaveRequest,TLeaveRequestType
		  where  TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
            and (@To='2900-12-31' or datediff(dd,AbsentFrom,@To)>=0)
            and (@From='1900-1-1' or datediff(dd,@From,AbsentTo)>=0)
			and TLeaveRequest.PKID in (
select LeaveRequestID from TLeaveRequestItem where pkid in 
(select LeaveRequestItemID from TLeaveRequestFlow where OperatorID=@OperatorID and Operation in(2,3,5,6,7,8))
			)
          order by pkid desc

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
CREATE PROCEDURE GetLeaveRequestByCondition
(
	@AccountID int,
    @From DateTime,
    @To   DateTime,
    @Status int
)
AS
Begin
		select TLeaveRequest.*,TLeaveRequestType.Name as AbsenceTypeName,TLeaveRequestType.LeastHour,
				 TLeaveRequestType.Name as LeaveRequestTypeName,
				 TLeaveRequestType.LeastHour as LeaveRequestTypeLeastHour,
				 TLeaveRequestType.Description as LeaveRequestTypeDescription,
				 TLeaveRequestType.IncludeNationalHolidays as  LeaveRequestTypeIncludeNationalHolidays,
		         TLeaveRequestType.IncludeRestDay as LeaveRequestTypeIncludeRestDay

          from TLeaveRequest,TLeaveRequestType
		  where TLeaveRequest.AccountID = @AccountID
		    and TLeaveRequestType.PKID = TLeaveRequest.LeaveRequestTypeID
			and (datediff(dd,AbsentFrom,@To)>=0)
			and (datediff(dd,@From,AbsentTo)>=0)
			and TLeaveRequest.PKID in (
				select distinct TLeaveRequest.PKID 
				from TLeaveRequest,TLeaveRequestItem
				where TLeaveRequestItem.LeaveRequestID = TLeaveRequest.PKID
				and (@Status = -1 or Status = @Status)
			)
          order by pkid desc
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
CREATE PROCEDURE GetVacationUsedDetailByAccountID
(
	@AccountID int
)
AS
Begin
		select a.pkid,a.leaverequestid,a.status,a.absentfrom,a.absentto,a.absenthours ,b.Reason from dbo.TLeaveRequestItem as a left join dbo.TLeaveRequest as b 
		on a.LeaveRequestID=b.PKID 
		where b.AccountID=@AccountID and LeaveRequestTypeID=1 and  Status in (3,4,5,8)
        order by a.AbsentTo desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End               考勤管理         ------------

--Begin          假期类别      -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE LeaveRequestTypeInsert
(
    @PKID                    INT OUTPUT,
    @Name		             NVARCHAR(50),
	@Description			 TEXT=null,
	@IncludeNationalHolidays INT,
    @IncludeRestDay          INT,
    @LeastHour               decimal(6,2)
)
AS
BEGIN
    INSERT INTO TLeaveRequestType(
		[Name],
		[Description],
		IncludeNationalHolidays,
        IncludeRestDay,
        LeastHour 
	)
    VALUES (
		@Name,
		@Description,
		@IncludeNationalHolidays,
        @IncludeRestDay,
        @LeastHour
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
CREATE PROCEDURE [dbo].[LeaveRequestTypeUpdate]
(
	    @PKID                    INT,
        @Name                    NVARCHAR(50),
        @Description             TEXT=null,
        @IncludeNationalHolidays INT ,--是否包括节假日 
        @IncludeRestDay          INT,
        @LeastHour               decimal(6,2) 
)
AS
BEGIN
		UPDATE [TLeaveRequestType]
        SET
			[Name]=@Name
			,[Description]=@Description 
			,IncludeNationalHolidays=@IncludeNationalHolidays
            ,IncludeRestDay=@IncludeRestDay
            ,LeastHour=@LeastHour
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
CREATE PROCEDURE [dbo].[LeaveRequestTypeDelete]
(
	    @PKID    INT     
)
AS
BEGIN
         DELETE FROM [TLeaveRequestType]  WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[GetLeaveRequestTypeByPkid]
(
	    @PKID    INT     
)
AS
BEGIN
         SELECT * FROM TLeaveRequestType WHERE PKID=@PKID 
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
CREATE PROCEDURE [dbo].[GetLeaveRequestTypeByName]
(
        @Name      NVARCHAR(50)
)
As
BEGIN 
     SELECT * FROM TLeaveRequestType 
     WHERE [Name]=@Name 
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
CREATE PROCEDURE [dbo].[GetLeaveRequestTypeByNameLike]
(
        @Name                    NVARCHAR(50)=null
)
As
BEGIN 
     SELECT * FROM TLeaveRequestType 
     WHERE (@Name IS NULL OR [Name] LIKE '%'+ @Name +'%') 
     ORDER BY PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End            假期类别      -------------
--Begin        外出         -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OutApplicationInsert
(
    @PKID                    INT OUTPUT,
    @AccountID		             int,
	@SubmitDate			 datetime,
	@From datetime,
    @To datetime,
    @CostTime decimal(25,2),
    @Reason text,
    @OutLocation NVarChar(250),
    @OutType  int,
    @DiyProcess text
)
AS
BEGIN
    INSERT INTO TOutApplication(
		AccountID,
		SubmitDate,
		[From],
        [To] ,
        [CostTime],
        [Reason] ,
        [OutLocation],
        OutType,
        [DiyProcess]
	)
    VALUES (
		@AccountID,
		@SubmitDate,
		@From,
        @To,
        @CostTime,
        @Reason,
        @OutLocation,
        @OutType,
        @DiyProcess 
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
CREATE PROCEDURE UpdateOutApplicationItem
(
	@PKID int,
	@OutApplicationID int,
	@Status int,
	@From datetime,
	@To datetime,
	@CostTime decimal(25, 2),
    @Adjust int,
    @AdjustHour decimal(25,2)
)
AS
Begin
    SET NOCOUNT OFF
UPDATE [TOutApplicationItem]
   SET [OutApplicationID] = @OutApplicationID
      ,[Status] = @Status
      ,[From] = @From
      ,[To] = @To
      ,[CostTime] = @CostTime
      ,[AdjustHour] = @AdjustHour
      ,[Adjust] = @Adjust
 WHERE [PKID] = @PKID
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
CREATE PROCEDURE InsertOutApplicationItem
(
	@PKID int OUTPUT,
	@OutApplicationID int,
	@Status int,
	@From datetime,
	@To datetime,
	@CostTime decimal(25, 2),
    @Adjust int,
    @AdjustHour decimal(25,2)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TOutApplicationItem([OutApplicationID], [Status], [From], [To], [CostTime],Adjust,AdjustHour)
    values(@OutApplicationID, @Status, @From, @To, @CostTime,@Adjust,@AdjustHour)
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
CREATE PROCEDURE OutApplicationUpdate
(
	@PKID int,
	@AccountID int,
	@SubmitDate datetime,
	@From datetime,
	@To datetime,
	@CostTime decimal(25, 2),
	@Reason text,
	@OutLocation nvarchar(50),
    @OutType int,
    @DiyProcess Text
)
AS
Begin
    SET NOCOUNT OFF
    Update TOutApplication
    set
	[AccountID] = @AccountID,
	[SubmitDate] = @SubmitDate,
	[From] = @From,
	[To] = @To,
	[CostTime] = @CostTime,
	[Reason] = @Reason,
	[OutLocation] = @OutLocation,
    OutType=@OutType,
    [DiyProcess]=@DiyProcess
    where [PKID] = @PKID	
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
CREATE PROCEDURE GetOutApplicationByOutApplicationID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], [AccountID], [SubmitDate], [From], [To], [CostTime], [Reason], [OutLocation],OutType,[DiyProcess]
    from TOutApplication
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetAllOutApplicationByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT  [PKID], [AccountID], [SubmitDate], [From], [To], [CostTime], [Reason], [OutLocation],OutType
    from TOutApplication
	where [AccountID] = @AccountID
    order by [SubmitDate] Desc
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
CREATE PROCEDURE GetOutApplicationItemByOutApplicationID
(
	@OutApplicationID int
)
AS
Begin
    Select  *
    from TOutApplicationItem 
	Where 	[OutApplicationID] = @OutApplicationID
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
CREATE PROCEDURE GetOutApplicationItemByItemID
(
	@PKID int
)
AS
Begin
    Select  *
    from TOutApplicationItem 
	Where 	[PKID] = @PKID
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
CREATE PROCEDURE DeleteOutApplicationItem
(
	@OutApplicationItemID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOutApplicationItem
     where pkid = @OutApplicationItemID
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
CREATE PROCEDURE DeleteOutApplicationItemByOutApplicationID
(
	@OutApplicationID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOutApplicationItem
     where [OutApplicationID] = @OutApplicationID
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
CREATE PROCEDURE OutApplicationDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOutApplication
     where [PKID] = @PKID
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
CREATE PROCEDURE CountOutApplicationInRepeatDateDiffPKID
(
	@AccountID int,
	@From datetime,
	@To datetime,
    @PKID int=null
)
AS
Begin
          SET NOCOUNT OFF
          select counts=count(PKID)
          from TOutApplication where PKID in
          (          
          select a.pkid 
		  from TOutApplication as a left join TOutApplicationItem as b on a.PKID=b.OutApplicationID
		  where AccountID=@AccountID 
          and (datediff(ss,b.[To],@From)<0 )
          and (datediff(ss,@To,b.[From])<0 )
          and  Status not in (2,6) 
          and  (@PKID is null or a.PKID=-1 or a.PKID not in (@PKID) )
          group by a.PKID
          )
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
CREATE PROCEDURE DeleteOutApplicationFlowByItemID
(
	@OutApplicationItemID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOutApplicationFlow
     where OutApplicationItemID = @OutApplicationItemID
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
CREATE PROCEDURE GetOutApplicationFlowByItemID
(
	@OutApplicationItemID int
)
AS
Begin
    Select  *
    from TOutApplicationFlow
	Where 	[OutApplicationItemID] = @OutApplicationItemID
    order by PKID
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
CREATE PROCEDURE InsertOutApplicationFlow
(
	@PKID int OUTPUT,
	@OutApplicationItemID int,
	@OperatorID int,
	@Operation int,
	@OperationTime datetime,
	@Remark text,
    @Step int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TOutApplicationFlow([OutApplicationItemID], [OperatorID], [Operation], [OperationTime], [Remark],Step)
    values(@OutApplicationItemID, @OperatorID, @Operation, @OperationTime, @Remark,@Step)
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
CREATE PROCEDURE UpdateOutApplicationItemStatusByItemID
(
	@PKID int,
	@Status int
)
AS
Begin
    SET NOCOUNT OFF
    Update TOutApplicationItem
    set	[Status] = @Status
    where [PKID] = @PKID	
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
CREATE PROCEDURE GetNeedConfirmOutApplication
AS
Begin
          SET NOCOUNT OFF
          select TOutApplication.* 
		  from TOutApplication
		  where PKID in 
          (
          select OutApplicationID from TOutApplicationItem where Status in (1,4,7,8)
          )
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
CREATE PROCEDURE GetOutConfirmHistroy
(
	@OperatorID int,
    @From DateTime,
    @To DateTime
)
AS
Begin
          SET NOCOUNT OFF
         select * from dbo.TOutApplication
where pkid in 
(select OutApplicationID from ToutApplicationItem where pkid in 
(select OutApplicationItemID from TOutApplicationFlow where OperatorID=@OperatorID and Operation in(2,3,5,6,7,8)))
and (@To='2900-12-31' or datediff(dd,[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,[To])>=0)
order by pkid desc
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
CREATE PROCEDURE GetOutApplicationForCalendar
(
    @AccountID int,
    @From DateTime,
    @To DateTime
)
AS
Begin
select * from TOutApplicationItem as a left join TOutApplication as b on a.OutApplicationID=b.PKID
where AccountID=@AccountID  
and (@To='2900-12-31' or datediff(dd,a.[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,a.[To])>=0)
and (a.Status in (3,4,5))
order by b.AccountID Asc
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
CREATE PROCEDURE GetAllOutApplicationForCalendar
(
    @AccountID int,
    @From DateTime,
    @To DateTime
)
AS 
Begin
select b.*
,a.PKID as TOutApplicationItemPKID
,a.OutApplicationID as TOutApplicationItemOutApplicationID
,a.Status as TOutApplicationItemStatus
,a.[From] as TOutApplicationItemFrom
,a.[To] as TOutApplicationItemTo
,a.CostTime as TOutApplicationItemCostTime
,a.AdjustHour as TOutApplicationItemAdjustHour
,a.Adjust as TOutApplicationItemAdjust
from TOutApplicationItem as a left join TOutApplication as b on a.OutApplicationID=b.PKID
where AccountID=@AccountID  
and (@To='2900-12-31' or datediff(dd,a.[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,a.[To])>=0)
and (a.Status in (0,1,3,4,5,7,8))
order by b.AccountID Asc
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
CREATE PROCEDURE GetOutApplicationDetailByEmployee
(
    @Date DateTime,
    @AccountID int
)
AS
Begin
select a.PKID from TOutApplication as a left join TOutApplicationItem as b on b.OutApplicationID=a.PKID
where AccountID=@AccountID  
and (datediff(dd,b.[From],@Date)>=0)
and (datediff(dd,@Date,b.[To])>=0)
and (b.Status in (0,1,3,4,5,7,8))
group by a.PKID 
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
CREATE PROCEDURE GetOutApplicationByCondition
(
    @AccountID int,
    @From DateTime,
    @To DateTime,
    @Status int,
    @OutType int
)
AS
Begin
select PKID from TOutApplication where 
AccountID=@AccountID
and (@OutType=-1 or OutType=@OutType)
and (datediff(dd,@From,[To])>=0)
and (datediff(dd,[From],@To)>=0)
and PKID in (select OutApplicationID from TOutApplicationItem where @Status=-1 or Status=@Status ) 
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
CREATE PROCEDURE UpdateOutApplicationItemAdjustByItemID
(
	@PKID int,
    @Adjust int,
    @AdjustHour decimal(25,2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TOutApplicationItem
    set	[Adjust]=@Adjust,AdjustHour=@AdjustHour
    where [PKID] = @PKID	
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End         外出          -------------
--Begin               考勤       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetEmployeeInAndOutByCondition
(
     @EmployeeId Int,
     @IOTimeStart     DateTime,--刷卡日期开始时间查询
     @IOTimeEnd       DateTime,--刷卡日期结束时间查询
     @IOStatus        Int,--刷卡状态，-1 ：所有，0：进，1：出
     @OperateStatus   INT,--操作状态查询，-1：所有，0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
     @DoorCardNo     Nvarchar(50),--卡号查询
     @OperateTimeStart    DateTime,--操作时间开始时间查询
     @OperateTimeEnd    DateTime--操的时间开始时间查询
)
AS
Begin
          SELECT A.PKID AS RecordID,A.EmployeeID,A.IOTime,
          A.IOStatus,A.OperateStatus,A.OperateTime,A.DoorCardNo
          from TEmployeeInAndOutRecord A
          WHERE (datediff(n,@IOTimeStart,IOTime)>=0 )
          AND(datediff(n,IOTime,@IOTimeEnd)>=0)
          AND(@IOStatus=-1 or IOStatus=@IOStatus)
          AND(@EmployeeId=-1 or A.EmployeeID=@EmployeeId)
          AND(@OperateStatus=-1 or OperateStatus=@OperateStatus)
          AND(@DoorCardNo='' or A.DoorCardNo like '%' +@DoorCardNo + '%')
          AND(datediff(dd,@OperateTimeStart,OperateTime)>=0 )
          AND(datediff(dd,OperateTime,@OperateTimeEnd)>=0)
          order By A.EmployeeID,A.IOTime desc
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
CREATE PROCEDURE [dbo].[InsertEmployeeInAndOutRecord]
(
	    @PKID           INT out,
        @EmployeeId     INT,
        @IOTime         DateTime,--刷卡日期开始时间查询
        @IOStatus       Int,--刷卡状态，-1 ：所以，0：进，1：出
        @DoorCardNo     Nvarchar(50),--部门查询
        @OperateStatus  INT,--0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
        @OperateTime    DateTime--每次操作的时间
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO [TEmployeeInAndOutRecord]
           ([EmployeeID]
           ,[DoorCardNo]
           ,[IOTime]
           ,[IOStatus]
           ,[OperateStatus]
           ,[OperateTime])
     VALUES
           (@EmployeeId        
           ,@DoorCardNo
           ,@IOTime
           ,@IOStatus
           ,@OperateStatus
           ,@OperateTime)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdateEmployeeInAndOutRecord]
(
	    @PKID           INT,
        @EmployeeId     INT,
        @IOTime         DateTime,--刷卡日期开始时间查询
        @IOStatus       Int,--刷卡状态，-1 ：所以，0：进，1：出
        @DoorCardNo     Nvarchar(50),--部门查询
        @OperateStatus  INT,--0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
        @OperateTime    DateTime--每次操作的时间
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE [TEmployeeInAndOutRecord]
         SET
           [EmployeeID]=@EmployeeId
           ,[DoorCardNo]=@DoorCardNo
           ,[IOTime]=@IOTime
           ,[IOStatus]=@IOStatus
           ,[OperateStatus]=@OperateStatus
           ,[OperateTime]=@OperateTime
          WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeleteEmployeeInAndOutRecord]
(
	    @EmployeeId           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM [TEmployeeInAndOutRecord]
         WHERE EmployeeID=@EmployeeId
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
CREATE PROCEDURE GetAllReadDataHistory
AS
Begin
          SELECT PKID,ReadTime,ReadResult,FailReason
          from TReadDataHistory
          order By TReadDataHistory.ReadTime  DESC
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
CREATE PROCEDURE GetReadDataHistoryByPkid
(
	    @PKID           INT
)
AS
Begin
          SELECT PKID,ReadTime,ReadResult,FailReason
          from TReadDataHistory
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
CREATE PROCEDURE GetLastSuccessReadDataHistory
AS
Begin
          SELECT top(1) PKID,ReadTime,ReadResult,FailReason
          from TReadDataHistory
         WHERE ReadResult =1
         order by ReadTime desc
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
CREATE PROCEDURE GetLastReadDataHistory
AS
Begin
          SELECT top(1) PKID,ReadTime,ReadResult,FailReason
          from TReadDataHistory
         order by ReadTime desc
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
CREATE PROCEDURE [dbo].[InsertReadDataHistory]
(
	    @PKID           INT out,
        @ReadTime       DateTime,
        @ReadResult     Int,
        @FailReason     text
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TReadDataHistory
           (ReadTime
           ,ReadResult,FailReason)
     VALUES
           (@ReadTime
           ,@ReadResult ,@FailReason      )
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdateReadDataHistory]
(
	    @PKID           INT,
        @ReadTime       DateTime,
        @ReadResult     Int,
        @FailReason      text
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE TReadDataHistory
         SET
           ReadTime=@ReadTime
           ,ReadResult=@ReadResult,
          FailReason=@FailReason
          WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeleteReadDataHistory]
(
	    @PKID           INT
)
AS
Begin
         SET NOCOUNT OFF
         Delete From TReadDataHistory
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
CREATE PROCEDURE GetAttendanceReadTimeByPkid
(
	    @PKID           INT
)
AS
Begin
          SELECT PKID,ReadDateTime,IsSendEmail,SendEmailRull
          from TAttendanceReadTime
         WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[InsertAttendanceReadTime]
(
	    @PKID           INT out,
        @ReadDateTime   DateTime,
        @IsSendEmail    INT,
        @SendEmailRull  INT
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TAttendanceReadTime
           (ReadDateTime,
            IsSendEmail,
            SendEmailRull)
          VALUES
           (@ReadDateTime,
            @IsSendEmail,
            @SendEmailRull)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdateAttendanceReadTime]
(
	    @PKID           INT,
        @ReadDateTime   DateTime,
        @IsSendEmail    INT,
        @SendEmailRull  INT
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE TAttendanceReadTime
         SET
         ReadDateTime=@ReadDateTime,
         IsSendEmail=@IsSendEmail,
         SendEmailRull=@SendEmailRull
         WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeleteAttendanceReadTime]
(
	    @PKID           INT
)
AS
Begin
         SET NOCOUNT OFF
         Delete from TAttendanceReadTime
         WHERE PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--Begin               考勤记录日志       -------------

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[InsertAttendanceInAndOutRecordLog]
(
	    @PKID           INT out,
        @EmployeeID     INT,
        @OldIOTime      DateTime,
        @OldIOStatus    Int,
        @NewIOTime      DateTime,
        @NewIOStatus    INT,
        @OperateStatus  INT,
        @Operator       Nvarchar(50),
        @OperateTime    DateTime,
        @OperateReason   Nvarchar(100)
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TInAndOutRecordLog
           (EmployeeID
           ,OldIOTime
           ,OldIOStatus
           ,NewIOTime
           ,NewIOStatus
           ,OperateStatus
           ,Operator
           ,OperateTime
           ,OperateReason)
     VALUES
           (@EmployeeID    
           ,@OldIOTime
           ,@OldIOStatus
           ,@NewIOTime
           ,@NewIOStatus
           ,@OperateStatus
           ,@Operator
           ,@OperateTime
           ,@OperateReason)         
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
CREATE PROCEDURE [dbo].[GetAttendanceInAndOutRecordLogByCondition]
(
     @OperateTimeStart   DateTime,
     @OperateTimeEnd     DateTime,
     @OldIOTimeStart     DateTime,
     @OldIOTimeEnd       DateTime,    
     @Operator           Nvarchar(50)   
)
AS
Begin
          SELECT B.Pkid as RecordID,B.EmployeeID,
           B.OldIOTime,B.OldIOStatus,
           B.NewIOTime,B.NewIOStatus,B.OperateStatus,
           B.Operator,B.OperateTime,B.OperateReason
          from TInAndOutRecordLog B
          WHERE (datediff(dd,@OldIOTimeStart,NewIOTime)>=0 )
          AND(datediff(dd,NewIOTime,@OldIOTimeEnd)>=0 )             
          AND Operator like '%'+ @Operator +'%' 
          AND(datediff(dd,@OperateTimeStart,OperateTime)>=0 )
          AND(datediff(dd,OperateTime,@OperateTimeEnd)>=0 )     
          order By RecordID
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
CREATE PROCEDURE [dbo].[DeleteAttendanceInAndOutRecordLog]
(
	    @Pkid           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM [TInAndOutRecordLog]
         WHERE Pkid=@Pkid
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
CREATE PROCEDURE GetAttendanceByCondition
(
	@EmployeeId int,
    @AttendanceType  int,
    @DayFrom DateTime,
    @DayTo   DateTime
)
AS
Begin
     SELECT TEmployeeAttendance.PKID,TEmployeeAttendance.EmployeeId,TEmployeeAttendance.[Name] as AttendanceName,[Days],[AddDutyDays],EarlyAndLateMunite,[TheDay],[AttendanceType]
    FROM  TEmployeeAttendance 
    WHERE (TEmployeeAttendance.EmployeeId=@EmployeeId OR @EmployeeId=-1)
    AND  (AttendanceType=@AttendanceType OR @AttendanceType=-1)
    AND  (@DayFrom='1900-1-1' or datediff(dd,@DayFrom,TheDay)>=0)
    AND  (@DayTo='2999-12-31' or datediff(dd,TheDay,@DayTo)>=0)
    order by TheDay desc
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
CREATE PROCEDURE GetAttendanceByEmpId
(
	@EmployeeId int      
)
AS
Begin
    SELECT PKID,[EmployeeId],[Name],[Days],[AddDutyDays],EarlyAndLateMunite,[TheDay],[AttendanceType]
    FROM  TEmployeeAttendance 
    WHERE EmployeeId=@EmployeeId
    order by PKID
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
CREATE PROCEDURE EmployeeAttendanceInsert
(
	@PKID int OUTPUT,
    @EmployeeId          INT ,
    @Name	            NVarChar(50),  
    @Days                decimal(9,2) ,   
    @AddDutyDays         decimal(9,2), 
    @Munite              int,
    @TheDay            DATETIME ,     
    @AttendanceType        INT        
)
AS
Begin
    INSERT INTO TEmployeeAttendance ([EmployeeId]
           ,[Name]
           ,[Days]
           ,[AddDutyDays]
           ,[EarlyAndLateMunite]
           ,[TheDay]
           ,[AttendanceType])
    VALUES (@EmployeeId
           ,@Name
           ,@Days
           ,@AddDutyDays
           ,@Munite
           ,@TheDay
           ,@AttendanceType)
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
CREATE PROCEDURE EmployeeAttendanceDelete
(
	@PKID int    
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TEmployeeAttendance
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
CREATE PROCEDURE GetAttendanceById
(
	@PKID int      
)
AS
Begin
    SELECT PKID,[EmployeeId],[Name],[Days],[AddDutyDays],EarlyAndLateMunite,[TheDay],[AttendanceType]
    FROM  TEmployeeAttendance 
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
CREATE PROCEDURE EmployeeAttendanceDeleteByEmpAndTime
(
	@EmployeeId int,
        @TheDay DateTime
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TEmployeeAttendance
     where EmployeeId= @EmployeeId and 
     (datediff(dd,@TheDay ,TheDay)=0 )
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



--End              考勤记录日志       -------------
--
---
--
--
--
---
--
--
--
--
--
--
--
--
--
--
--
--
--
--
--
--
--
---
--
--
--
--
--
--
--
--
--
---
--
--
---
--
--
--
---
---
--
--
--
---
---
--
--
--
--
--

--------------------------------------------------
/*                 创建所有存储过程                    */
--------------------------------------------------

--Begin               员工、权限       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ParameterInsert
(
	    @PKID INT out,
        @Name Nvarchar(50),
        @Type INT,
        @Description text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TParameter([Name],[Type],[Description])
          values(@Name,@Type,@Description)
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
CREATE PROCEDURE ParameterUpdate
(
	    @PKID INT out,
        @Name Nvarchar(50),
        @Description text
)
AS
Begin
          SET NOCOUNT OFF
          update TParameter
          set [Name] = @Name,  [Description]=  @Description 
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
CREATE PROCEDURE ParameterDelete
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TParameter
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
CREATE PROCEDURE CountParameterByName
(
	    @Name Nvarchar(50),
        @Type INT
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TParameter
	      WHERE [Name] = @Name and [Type] = @Type
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
CREATE PROCEDURE CountParameterByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(50),
        @Type INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TParameter
	      WHERE [Name] = @Name and [Type] = @Type and PKID <> @PKID
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
CREATE PROCEDURE GetParameterByPkid
(
	    @PKID INT
)
AS
Begin
          SELECT PKID,[Name],[Description]
	      FROM TParameter
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
CREATE PROCEDURE GetParameterByCondition
(
        @PKID INT,
	    @Name Nvarchar(50),
        @Type INT
)
AS
Begin
          SELECT PKID,[Name],[Description]
	      FROM TParameter
	      WHERE [Type] = @Type and [Name] like '%'+ @Name +'%' and (@PKID = -1 or PKID = @PKID)
          ORDER BY PKID
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
CREATE PROCEDURE [EmployeeHistoryInsert]
(
@PKID            INT out,
@AccountID  Int,
@CompanyID  Int,
@AccountType INT,
@MobileNum nvarchar(50),
@IsAcceptEmail INT,
@IsAcceptSMS INT,
@IsValidateUsbKey INT,
@LeaveDate        DateTime,
@Name          Nvarchar(50)  ,
@LoginName       Nvarchar(50)  ,
@Password        Nvarchar(2000),
@Email1           Nvarchar(255) ,
@Email2          Nvarchar(255),
@DepartmentID    INT,
@PositionID      INT,
@ComeDate        DateTime,
@Birthday        DateTime,
@ResidencePermit DateTime,
@EmployeeType    INT,
@EnglishName Nvarchar(50),
@Gender	INT,
@PoliticalAffiliation	INT,
@MaritalStatus	INT,
@EducationalBackground	INT,
@WorkType	INT,
@HasChild	INT,
@EmployeeDetails IMAGE,
@Certificates	Nvarchar(2000),
@PRPArea	Nvarchar(255),
@ProbationTime DateTime,
@UsbKey Nvarchar(2000),
@Photo  Image,
@DoorCardNo Nvarchar(50),--门禁卡卡号
@SocietyWorkAge int,--社会工龄
@OperatorID  INT,--操作人员，后台帐号ID
@OperationTime  DATETIME,--操作时间
@Remark	Nvarchar(255),

@LeaderName  Nvarchar(50),
@DepartmentName  Nvarchar(50),
@PositionName  Nvarchar(50),
@OperatorName Nvarchar(50),
@PositionGradeID int,
@ProbationStartTime Datetime,
@PrincipalShipID int,
@SalaryCardNo nvarchar(255),
@SalaryCardBank nvarchar(255)
)
AS
Begin
          SET NOCOUNT ON
INSERT INTO [dbo].[TEmployeeHistory]
           ([AccountID]
           ,[CompanyID]
           ,[AccountType]
           ,[MobileNum]
           ,[IsAcceptEmail]
           ,[IsAcceptSMS]
           ,[IsValidateUsbKey]
           ,[LeaveDate]
           ,[Name]
           ,[LoginName]
           ,[Password]
           ,[Email1]
           ,[Email2]
           ,[DepartmentID]
           ,[PositionID]
           ,[ComeDate]
           ,[Birthday]
           ,[ResidencePermit]
           ,[EmployeeType]
           ,[EnglishName]
           ,[Gender]
           ,[PoliticalAffiliation]
           ,[MaritalStatus]
           ,[EducationalBackground]
           ,[WorkType]
           ,[HasChild]
           ,[EmployeeDetails]
           ,[Certificates]
           ,[PRPArea]
           ,[ProbationTime]
           ,[UsbKey]
           ,[Photo]
           ,[DoorCardNo]
           ,[SocietyWorkAge]
           ,[OperatorID]
           ,[OperationTime]
           ,[Remark]
	,LeaderName
	,DepartmentName
	,PositionName
    ,OperatorName
    ,PositionGradeID
	,ProbationStartTime
	,PrincipalShipID
	,SalaryCardNo
	,SalaryCardBank
)
     VALUES
(
			@AccountID
           ,@CompanyID
           ,@AccountType
           ,@MobileNum
           ,@IsAcceptEmail
           ,@IsAcceptSMS
           ,@IsValidateUsbKey
           ,@LeaveDate
           ,@Name
           ,@LoginName
           ,@Password
           ,@Email1
           ,@Email2
           ,@DepartmentID
           ,@PositionID
           ,@ComeDate
           ,@Birthday
           ,@ResidencePermit
           ,@EmployeeType
           ,@EnglishName
           ,@Gender
           ,@PoliticalAffiliation
           ,@MaritalStatus
           ,@EducationalBackground
           ,@WorkType
           ,@HasChild
           ,@EmployeeDetails
           ,@Certificates
           ,@PRPArea
           ,@ProbationTime
           ,@UsbKey
           ,@Photo
           ,@DoorCardNo
           ,@SocietyWorkAge
           ,@OperatorID
           ,@OperationTime
           ,@Remark
	,@LeaderName
	,@DepartmentName
	,@PositionName
    ,@OperatorName
    ,@PositionGradeID
	,@ProbationStartTime
    ,@PrincipalShipID
	,@SalaryCardNo
	,@SalaryCardBank
)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [EmployeeHistoryUpdate]
(
@PKID            INT,
@AccountID  Int,
@CompanyID  Int,
@AccountType INT,
@MobileNum nvarchar(50),
@IsAcceptEmail INT,
@IsAcceptSMS INT,
@IsValidateUsbKey INT,
@LeaveDate        DateTime,
@Name          Nvarchar(50)  ,
@LoginName       Nvarchar(50)  ,
@Password        Nvarchar(2000),
@Email1           Nvarchar(255) ,
@Email2          Nvarchar(255),
@DepartmentID    INT,
@PositionID      INT,
@ComeDate        DateTime,
@Birthday        DateTime,
@ResidencePermit DateTime,
@EmployeeType    INT,
@EnglishName Nvarchar(50),
@Gender	INT,
@PoliticalAffiliation	INT,
@MaritalStatus	INT,
@EducationalBackground	INT,
@WorkType	INT,
@HasChild	INT,
@EmployeeDetails IMAGE,
@Certificates	Nvarchar(2000),
@PRPArea	Nvarchar(255),
@ProbationTime DateTime,
@UsbKey Nvarchar(2000),
@Photo  Image,
@DoorCardNo Nvarchar(50),--门禁卡卡号
@SocietyWorkAge int,--社会工龄
@OperatorID  INT,--操作人员，后台帐号ID
@OperationTime  DATETIME,--操作时间
@Remark	Nvarchar(255),
@LeaderName  Nvarchar(50),
@DepartmentName  Nvarchar(50),
@PositionName  Nvarchar(50),
@OperatorName Nvarchar(50),
@PositionGradeID int,
@ProbationStartTime DateTime,
@PrincipalShipID int,
@SalaryCardNo nvarchar(255),
@SalaryCardBank nvarchar(255)
)
AS
Begin
          SET NOCOUNT ON
UPDATE [TEmployeeHistory]
   SET [AccountID] =@AccountID
      ,[CompanyID] =@CompanyID
      ,[AccountType] =@AccountType
      ,[MobileNum] =@MobileNum
      ,[IsAcceptEmail] =@IsAcceptEmail
      ,[IsAcceptSMS] =@IsAcceptSMS
      ,[IsValidateUsbKey] =@IsValidateUsbKey
      ,[LeaveDate] =@LeaveDate
      ,[Name] =@Name
      ,[LoginName] =@LoginName
      ,[Password] =@Password
      ,[Email1] =@Email1
      ,[Email2] =@Email2
      ,[DepartmentID] =@DepartmentID
      ,[PositionID] =@PositionID
      ,[ComeDate] =@ComeDate
      ,[Birthday] =@Birthday
      ,[ResidencePermit] =@ResidencePermit
      ,[EmployeeType] =@EmployeeType
      ,[EnglishName] =@EnglishName
      ,[Gender] =@Gender
      ,[PoliticalAffiliation] =@PoliticalAffiliation
      ,[MaritalStatus] =@MaritalStatus
      ,[EducationalBackground] =@EducationalBackground
      ,[WorkType] =@WorkType
      ,[HasChild] =@HasChild
      ,[EmployeeDetails] =@EmployeeDetails
      ,[Certificates] =@Certificates
      ,[PRPArea] =@PRPArea
      ,[ProbationTime] =@ProbationTime
      ,[UsbKey] =@UsbKey
      ,[Photo] =@Photo
      ,[DoorCardNo] =@DoorCardNo
      ,[SocietyWorkAge] =@SocietyWorkAge
      ,[OperatorID] =@OperatorID
      ,[OperationTime] =@OperationTime
      ,[Remark] =@Remark
	,DepartmentName=@DepartmentName
	,PositionName=@PositionName
    ,OperatorName=@OperatorName
    ,LeaderName=@LeaderName
    ,PositionGradeID=@PositionGradeID
	,ProbationStartTime=@ProbationStartTime
    ,PrincipalShipID=@PrincipalShipID
	,SalaryCardNo=@SalaryCardNo
	,SalaryCardBank=@SalaryCardBank
WHERE pkid=@PKID

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
CREATE PROCEDURE [EmployeeInsert]
(
	    @PKID            INT out,
		@AccountID		 Int,
		@CompanyID		 Int,
		@CountryNationalityID		 Int,
		@LeaveDate		 DateTime,
		@ComeDate        DateTime,
		@Birthday        DateTime,
		@ResidencePermit DateTime,
	    @EmployeeType    INT,
		@EnglishName Nvarchar(50),
		@Gender	INT,
		@PoliticalAffiliation	INT,
		@MaritalStatus	INT,
		@EducationalBackground	INT,
		@WorkType	INT,
		@HasChild	INT,
		@EmployeeDetails IMAGE,
		@Certificates	Nvarchar(2000),
		@PRPArea	Nvarchar(255),
		@ProbationTime DateTime,
        @Photo Image,
		@DoorCardNo Nvarchar(50),
		@SocietyWorkAge int,
		@WorkPlace Nvarchar(50),
        @PositionGradeId  int,
		@ProbationStartTime DateTime,
        @PrincipalShipID int,
		@SalaryCardNo nvarchar(255),
		@SalaryCardBank nvarchar(255)
)
AS
Begin
          SET NOCOUNT ON
          INSERT INTO [dbo].[TEmployee]
           ([AccountID]
		   ,[CompanyID]
		   ,[CountryNationalityID]
		   ,[LeaveDate]
           ,[ComeDate]
           ,[Birthday]
           ,[ResidencePermit]
           ,[EmployeeType]
           ,[EnglishName]
           ,[Gender]
           ,[PoliticalAffiliation]
           ,[MaritalStatus]
           ,[EducationalBackground]
           ,[WorkType]
           ,[HasChild]
           ,[EmployeeDetails]
           ,[Certificates]
           ,[PRPArea]
		   ,[ProbationTime]
           ,[Photo]
		   ,DoorCardNo
		   ,SocietyWorkAge
		   ,WorkPlace
			,PositionGradeId
			,ProbationStartTime
            ,PrincipalShipID
			,SalaryCardNo
			,SalaryCardBank)
     VALUES
           (@AccountID
		   ,@CompanyID
		   ,@CountryNationalityID
		   ,@LeaveDate
           ,@ComeDate
           ,@Birthday
           ,@ResidencePermit
           ,@EmployeeType
           ,@EnglishName
           ,@Gender
           ,@PoliticalAffiliation
           ,@MaritalStatus
           ,@EducationalBackground
           ,@WorkType
           ,@HasChild
           ,@EmployeeDetails
           ,@Certificates
           ,@PRPArea
		   ,@ProbationTime
           ,@Photo
		   ,@DoorCardNo
		   ,@SocietyWorkAge
		   ,@WorkPlace
           ,@PositionGradeId
			,@ProbationStartTime
            ,@PrincipalShipID
			,@SalaryCardNo
			,@SalaryCardBank)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[EmployeeUpdate]
(
		@AccountID		 Int,
		@CompanyID		 Int,
		@CountryNationalityID		 Int,
		@LeaveDate		 DateTime,
		@ComeDate        DateTime,
		@Birthday        DateTime,
		@ResidencePermit DateTime,
	    @EmployeeType    INT,
        @EnglishName Nvarchar(50),
		@Gender	INT,
		@PoliticalAffiliation	INT,
		@MaritalStatus	INT,
		@EducationalBackground	INT,
		@WorkType	INT,
		@HasChild	INT,
		@EmployeeDetails IMAGE,
		@Certificates	Nvarchar(2000),
		@PRPArea	Nvarchar(255),
		@ProbationTime DateTime ,
        @Photo Image,
		@DoorCardNo Nvarchar(50),
		@SocietyWorkAge int,
		@WorkPlace Nvarchar(50),
        @PositionGradeId int,
		@ProbationStartTime DateTime,
        @PrincipalShipID int,
		@SalaryCardNo nvarchar(255),
		@SalaryCardBank nvarchar(255)
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE TEmployee 
		  SET
            [AccountID]=@AccountID
           ,[CompanyID]=@CompanyID
		   ,[CountryNationalityID]=@CountryNationalityID
           ,[LeaveDate]=@LeaveDate
           ,[ComeDate]=@ComeDate
           ,[Birthday]=@Birthday
           ,[ResidencePermit]=@ResidencePermit
           ,[EmployeeType]=@EmployeeType
           ,[EnglishName]=@EnglishName
           ,[Gender]=@Gender
           ,[PoliticalAffiliation]=@PoliticalAffiliation
           ,[MaritalStatus]=@MaritalStatus
           ,[EducationalBackground]=@EducationalBackground
           ,[WorkType]=@WorkType
           ,[HasChild]=@HasChild
           ,[EmployeeDetails]=@EmployeeDetails
           ,[Certificates]=@Certificates
           ,[PRPArea]=@PRPArea
		   ,[ProbationTime]=@ProbationTime
           ,[Photo]=@Photo
           ,[DoorCardNo]=@DoorCardNo
           ,[SocietyWorkAge]=@SocietyWorkAge
		   ,[WorkPlace] = @WorkPlace
           ,PositionGradeId=@PositionGradeId
			,ProbationStartTime=@ProbationStartTime
           ,PrincipalShipID=@PrincipalShipID
			,SalaryCardNo =@SalaryCardNo
			,SalaryCardBank=@SalaryCardBank
          Where AccountID=@AccountID
End
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteEmployeeByAccountID
(
        @AccountID   INT
                     
)
AS
Begin
          SET NOCOUNT OFF
          Delete TEmployee
          Where AccountID=@AccountID
         
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
CREATE PROCEDURE DeleteEmployeeHistoryByPKID
(
        @EmployeeHistoryID   INT
                     
)
AS
Begin
          SET NOCOUNT OFF
          Delete TEmployeeHistory
          Where PKID=@EmployeeHistoryID
         
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
go

CREATE PROCEDURE UpdateEmployeeHistoryDetails
(
        @PKID            INT,
      	@EmployeeDetails 		 IMAGE
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE TEmployeeHistory 
		  SET
           [EmployeeDetails]=@EmployeeDetails
          Where PKID=@PKID
End
SET QUOTED_IDENTIFIER OFF 


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetEmployeeHistoryByAccountID
(
        @AccountID   INT
)
AS
Begin
          SET NOCOUNT OFF
          SELECT *
		    FROM TEmployeeHistory
           WHERE AccountID=@AccountID
		ORDER BY Operationtime DESC
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
CREATE PROCEDURE GetEmployeeBasicInfoByDepartmentIDAndDateTime
(
        @DepartmentID   INT,
        @dt   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[AccountType]
      ,[MobileNum]
      ,[IsAcceptEmail]
      ,[IsAcceptSMS]
      ,[IsValidateUsbKey]
      ,[LeaveDate]
      ,[Name]
      ,[LoginName]
      ,[Password]
      ,[Email1]
      ,[Email2]
      ,[DepartmentID]
      ,[PositionID]
      ,[ComeDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      ,[UsbKey]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,[OperatorID]
      ,[OperationTime]
      ,[Remark]
,DepartmentName
,LeaderName
,PositionName 
,OperatorName
,PositionGradeID
,ProbationStartTime
,PrincipalShipID
,SalaryCardNo
,SalaryCardBank
		  from TEmployeeHistory ,
		      (select max(OperationTime) as tempOperationTime,accountid as tempaccountid 
			  from TEmployeeHistory
			  where datediff(dd,OperationTime ,@dt )>=0	
					group by accountid) temp
          where datediff(ss,OperationTime,tempOperationTime)=0
				and accountid = tempaccountid AND DepartmentID = @DepartmentID
          
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
CREATE PROCEDURE GetEmployeeByDepartmentIDAndDateTime
(
        @DepartmentID   INT,
        @dt   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT *
		  from TEmployeeHistory ,
		      (select max(OperationTime) as tempOperationTime,accountid as tempaccountid 
			  from TEmployeeHistory
			  where datediff(dd,OperationTime ,@dt )>=0	
					group by accountid) temp
          where datediff(ss,OperationTime,tempOperationTime)=0
				and accountid = tempaccountid AND DepartmentID = @DepartmentID
          
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
CREATE PROCEDURE [GetEmployeeHistoryByDateTimeAndAccount]
(
        @AccountID   INT,
        @OperationTime   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT top 1 *
		  from TEmployeeHistory 
where Accountid =@AccountID
and @OperationTime>=OperationTime
order  by OperationTime
          
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
CREATE PROCEDURE GetEmployeeHistoryByDateTime
(
        @OperationTime   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT TEmployeeHistory.*
          from TEmployeeHistory ,
		      (select max(OperationTime) as tempOperationTime,accountid as tempaccountid 
			  from TEmployeeHistory
			  where datediff(dd,OperationTime ,@OperationTime )>=0
					group by accountid) temp
          where datediff(ss,OperationTime,tempOperationTime)=0
				and accountid = tempaccountid
          
          
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
CREATE PROCEDURE GetEmployeeHistoryBasicInfoByDateTime
(
        @AccountID   INT,
        @OperationTime   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT top 1  [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[AccountType]
      ,[MobileNum]
      ,[IsAcceptEmail]
      ,[IsAcceptSMS]
      ,[IsValidateUsbKey]
      ,[LeaveDate]
      ,[Name]
      ,[LoginName]
      ,[Password]
      ,[Email1]
      ,[Email2]
      ,[DepartmentID]
      ,[PositionID]
      ,[ComeDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      ,[UsbKey]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,[OperatorID]
      ,[OperationTime]
      ,[Remark]
,DepartmentName
,LeaderName
,PositionName 
,OperatorName
,PositionGradeID
,ProbationStartTime
,PrincipalShipID
,SalaryCardNo
,SalaryCardBank
		  from TEmployeeHistory 
where Accountid =@AccountID
and @OperationTime>=OperationTime
order  by OperationTime
          
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
CREATE PROCEDURE GetEmployeeHistoryAtLeaveDate
(
        @AccoutID   INT
)
AS
Begin
          SET NOCOUNT OFF
SELECT top 1 TEmployeeHistory.*
		  from TEmployeeHistory ,TEmployee
		  where TEmployee.leaveDate=TEmployeeHistory.leaveDate
			 and @AccoutID=TEmployee.accountid
		  order by OperationTime
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
CREATE PROCEDURE GetEmployeeHistoryBasicInfoAtLeaveDate
(
        @AccoutID   INT
)
AS
Begin
          SET NOCOUNT OFF
SELECT top 1 
TEmployeeHistory.[PKID]
      ,TEmployeeHistory.[AccountID]
      ,TEmployeeHistory.[CompanyID]
      ,TEmployeeHistory.[AccountType]
      ,TEmployeeHistory.[MobileNum]
      ,TEmployeeHistory.[IsAcceptEmail]
      ,TEmployeeHistory.[IsAcceptSMS]
      ,TEmployeeHistory.[IsValidateUsbKey]
      ,TEmployeeHistory.[LeaveDate]
      ,TEmployeeHistory.[Name]
      ,TEmployeeHistory.[LoginName]
      ,TEmployeeHistory.[Password]
      ,TEmployeeHistory.[Email1]
      ,TEmployeeHistory.[Email2]
      ,TEmployeeHistory.[DepartmentID]
      ,TEmployeeHistory.[PositionID]
      ,TEmployeeHistory.[ComeDate]
      ,TEmployeeHistory.[Birthday]
      ,TEmployeeHistory.[ResidencePermit]
      ,TEmployeeHistory.[EmployeeType]
      ,TEmployeeHistory.[EnglishName]
      ,TEmployeeHistory.[Gender]
      ,TEmployeeHistory.[PoliticalAffiliation]
      ,TEmployeeHistory.[MaritalStatus]
      ,TEmployeeHistory.[EducationalBackground]
      ,TEmployeeHistory.[WorkType]
      ,TEmployeeHistory.[HasChild]
      --,[EmployeeDetails]
      ,TEmployeeHistory.[Certificates]
      ,TEmployeeHistory.[PRPArea]
      ,TEmployeeHistory.[ProbationTime]
      ,TEmployeeHistory.[UsbKey]
      --,[Photo]
      ,TEmployeeHistory.[DoorCardNo]
      ,TEmployeeHistory.[SocietyWorkAge]
      ,TEmployeeHistory.[OperatorID]
      ,TEmployeeHistory.[OperationTime]
      ,TEmployeeHistory.[Remark]
,TEmployeeHistory.DepartmentName
,TEmployeeHistory.LeaderName
,TEmployeeHistory.PositionName 
,TEmployeeHistory.OperatorName
,TEmployeeHistory.PositionGradeID
,TEmployeeHistory.ProbationStartTime
,TEmployeeHistory.PrincipalShipID
,TEmployeeHistory.SalaryCardNo
,TEmployeeHistory.SalaryCardBank
		  from TEmployeeHistory ,TEmployee
		  where TEmployee.leaveDate=TEmployeeHistory.leaveDate
			 and @AccoutID=TEmployee.accountid
		  order by OperationTime
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
CREATE PROCEDURE GetEmployeeHistoryByEmployeeHistoryID
(
        @EmployeeHistoryID  INT                     
)
AS
Begin
SELECT *
  FROM [TEmployeeHistory]
  WHERE PKID=@EmployeeHistoryID
  order by pkid desc
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
CREATE PROCEDURE GetEmployeeHistoryBasicInfoByEmployeeHistoryID
(
        @EmployeeHistoryID  INT                     
)
AS
Begin
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[AccountType]
      ,[MobileNum]
      ,[IsAcceptEmail]
      ,[IsAcceptSMS]
      ,[IsValidateUsbKey]
      ,[LeaveDate]
      ,[Name]
      ,[LoginName]
      ,[Password]
      ,[Email1]
      ,[Email2]
      ,[DepartmentID]
      ,[PositionID]
      ,[ComeDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      ,[UsbKey]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,[OperatorID]
      ,[OperationTime]
      ,[Remark]
,DepartmentName
,LeaderName
,PositionName 
,OperatorName
,PositionGradeID
,ProbationStartTime
,PrincipalShipID
,SalaryCardNo
,SalaryCardBank
  FROM [TEmployeeHistory]
  WHERE PKID=@EmployeeHistoryID
  order by pkid desc
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
CREATE PROCEDURE GetEmployeeHistoryBasicInfoByAccountID
(
        @AccountID  INT                     
)
AS
Begin
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[AccountType]
      ,[MobileNum]
      ,[IsAcceptEmail]
      ,[IsAcceptSMS]
      ,[IsValidateUsbKey]
      ,[LeaveDate]
      ,[Name]
      ,[LoginName]
      ,[Password]
      ,[Email1]
      ,[Email2]
      ,[DepartmentID]
      ,[PositionID]
      ,[ComeDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      ,[UsbKey]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,[OperatorID]
      ,[OperationTime]
      ,[Remark]
,LeaderName
,DepartmentName
,PositionName 
,OperatorName
,PositionGradeID
,ProbationStartTime
,PrincipalShipID
,SalaryCardNo
,SalaryCardBank
  FROM [TEmployeeHistory]
  WHERE AccountID=@AccountID
  order by pkid desc
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
CREATE PROCEDURE [dbo].[GetEmployeeByPkid]
(
        @AccountID  INT                     
)
AS
Begin
SELECT top 1 *
  FROM [dbo].[TEmployee]
  WHERE TEmployee.AccountID=@AccountID
  order by AccountID desc
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
CREATE PROCEDURE [dbo].[GetEmployeeBasicInfoByAccountID]
(
        @AccountID  INT                     
)
AS
Begin
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[ComeDate]
      ,[LeaveDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,PositionGradeId
	  ,ProbationStartTime
      ,PrincipalShipID
	  ,WorkPlace
	  ,SalaryCardNo
	  ,SalaryCardBank
  FROM [dbo].[TEmployee]
  WHERE TEmployee.AccountID=@AccountID
  order by pkid desc
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
CREATE PROCEDURE [dbo].[GetEmployeeBasicInfoByCompanyID]
(
        @CompanyID  INT                     
)
AS
Begin
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[ComeDate]
      ,[LeaveDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,PositionGradeId
		,ProbationStartTime
       ,PrincipalShipID
		,WorkPlace
		,SalaryCardNo
		,SalaryCardBank
  FROM [dbo].[TEmployee]
  WHERE @CompanyID=-1 or TEmployee.CompanyID=@CompanyID
  order by pkid desc
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
CREATE PROCEDURE [dbo].GetAllCompanyHaveEmployee
AS
Begin
SELECT distinct [CompanyID]
  FROM [dbo].[TEmployee]
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
CREATE PROCEDURE [dbo].[GetEmployeeByAccountID]
(
        @AccountID  INT                     
)
AS
Begin
SELECT *
  FROM [dbo].[TEmployee]
  WHERE TEmployee.AccountID=@AccountID
  order by pkid desc
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
CREATE PROCEDURE GetAllEmployeeInfo
AS
Begin
SELECT *
	    FROM  TEmployee
        ORDER BY TEmployee.PKID    
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
CREATE PROCEDURE GetAllEmployeeBasicInfo
AS
Begin
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[ComeDate]
      ,[LeaveDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,PositionGradeId
		,ProbationStartTime
      ,PrincipalShipID
	  ,WorkPlace
	  ,SalaryCardNo
	  ,SalaryCardBank
	    FROM  TEmployee
        ORDER BY TEmployee.PKID    
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
CREATE PROCEDURE GetEmployeeByResidencePermitDays
(
     @Days   INT
)
AS
Begin
          SELECT PKID
	      FROM TEmployee
	      WHERE DateDiff(dd,GetDate(),ResidencePermit)=@Days
          ORDER BY PKID       
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
CREATE PROCEDURE CountEmployeeByNationalityID
(
	    @CountryNationalityID int
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TEmployee
	      WHERE CountryNationalityID = @CountryNationalityID
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
CREATE PROCEDURE ApplyAssessConditionInsert
(
     @PKID           INT out,
     @EmployeeContractID     INT,
     @ApplyDate      DateTime,
     @AssessScopeFrom      DateTime,
     @AssessScopeTo      DateTime,
     @ApplyAssessCharacterType        INT 
   
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TApplyAssessCondition
(EmployeeContractID,ApplyDate,AssessScopeFrom,AssessScopeTo,ApplyAssessCharacterType)
          values(@EmployeeContractID,@ApplyDate,@AssessScopeFrom,@AssessScopeTo,@ApplyAssessCharacterType)
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
CREATE PROCEDURE ApplyAssessConditionDelete
(
     @PKID   INT

)
AS
Begin
          SET NOCOUNT OFF
          Delete TApplyAssessCondition 
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
CREATE PROCEDURE ApplyAssessConditionDeleteByEmployeeContractID
(
     @EmployeeContractID   INT

)
AS
Begin
          SET NOCOUNT OFF
          Delete TApplyAssessCondition 
          where EmployeeContractID=@EmployeeContractID
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
CREATE PROCEDURE GetApplyAssessConditionByCurrDate
(
     @CurrentTime   Datetime
)
AS
Begin
          Select *
          From  TApplyAssessCondition
          where ApplyDate=@CurrentTime 
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
CREATE PROCEDURE GetApplyAssessConditionByEmployeeContractID
(
     @EmployeeContractID   int
)
AS
Begin
          Select *
          From  TApplyAssessCondition
          where EmployeeContractID=@EmployeeContractID 
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
CREATE PROCEDURE GetApplyAssessConditionByPKID
(
     @PKID   int
)
AS
Begin
          Select *
          From  TApplyAssessCondition
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
CREATE PROCEDURE EmployeeContractInsert
(
     @PKID           INT out,
     @AccountID     INT,
     @ContractTypeID INT,
     @StartDate      DateTime,
     @EndDate        DateTime,
     @Remark         Text,
     @Attachment     Text 
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TEmployeeContract(AccountID,ContractTypeID,StartDate,EndDate,Remark,Attachment)
          values(@AccountID,@ContractTypeID,@StartDate,@EndDate,@Remark,@Attachment)
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
CREATE PROCEDURE EmployeeContractUpdate
(
     @PKID           INT,
     @ContractTypeID INT,
     @StartDate      DateTime,
     @EndDate        DateTime,
     @Remark         Text,
     @Attachment     Text 
)
AS
Begin
          SET NOCOUNT OFF
          Update TEmployeeContract 
          Set
          ContractTypeID=@ContractTypeID,
          StartDate=@StartDate,
          EndDate=@EndDate,
          Remark=@Remark,
          Attachment=@Attachment
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
CREATE PROCEDURE EmployeeContractDelete
(
     @PKID   INT

)
AS
Begin
          SET NOCOUNT OFF
          Delete TEmployeeContract 
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
CREATE PROCEDURE GetEmployeeContractByContractTypeId
(
     @ContractTypeId   INT
)
AS
Begin
          Select TEmployeeContract.PKID,AccountID,ContractTypeID,
                 TContractType.Name as ContractTypeName,StartDate,EndDate,Remark,Attachment
          From  TEmployeeContract,TContractType
          where ContractTypeId=@ContractTypeId 
            and TContractType.PKID = TEmployeeContract.ContractTypeID
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
CREATE PROCEDURE GetEmployeeContractByContractId
(
     @PKID   INT
)
AS
Begin
          Select TEmployeeContract.PKID,AccountID,ContractTypeID,
                 TContractType.Name as ContractTypeName,StartDate,EndDate,Remark,Attachment
          From   TEmployeeContract,TContractType
          where  TEmployeeContract.PKID=@PKID 
             and TEmployeeContract.ContractTypeID = TContractType.PKID
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
CREATE PROCEDURE GetLastContractInAllTypeByAccountID
(
     @AccountID   INT,
	 @CurrentTime DateTime
)
AS
Begin
          Select top 1 TEmployeeContract.PKID,AccountID,ContractTypeID,
                 TContractType.Name as ContractTypeName,StartDate,EndDate,Remark,Attachment
          From   TEmployeeContract,TContractType
          where  AccountID = @AccountID
            and  TEmployeeContract.ContractTypeID = TContractType.PKID
            and  (datediff(dd, StartDate, @CurrentTime) >=0 )
            and  (datediff(dd, @CurrentTime, EndDate) >=0 )
          order by TEmployeeContract.EndDate desc,TEmployeeContract.pkid desc
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
CREATE PROCEDURE GetCurrentContractByAccountID
(
     @AccountID   INT,
	 @CurrentTime DateTime
)
AS
Begin
          Select top 1 TEmployeeContract.PKID,AccountID,ContractTypeID,
                 TContractType.Name as ContractTypeName,StartDate,EndDate,Remark,Attachment
          From   TEmployeeContract,TContractType
          where  AccountID = @AccountID
            and  TEmployeeContract.ContractTypeID = TContractType.PKID
            and  (datediff(dd, StartDate, @CurrentTime) >=0 )
            and  (datediff(dd, @CurrentTime, EndDate) >=0 )
			and  ContractTypeID in (1,2,3,4)--劳动合同,劳动合同续签页,变更劳动合同协议书,实习协议
          order by TEmployeeContract.StartDate desc,TEmployeeContract.pkid desc
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
CREATE PROCEDURE GetEmployeeContractByAccountID
(
     @AccountID   INT
)
AS
Begin
          Select TEmployeeContract.PKID,TEmployeeContract.AccountID,ContractTypeID,
                 TContractType.Name as ContractTypeName,StartDate,EndDate,Remark,Attachment
          From   TEmployeeContract,TContractType
          where  TEmployeeContract.AccountID = @AccountID
            and  TEmployeeContract.ContractTypeID = TContractType.PKID
          order by TEmployeeContract.PKID DESC
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
CREATE PROCEDURE GetAllEmployeeContract
AS
Begin
          Select TEmployeeContract.PKID,TEmployeeContract.AccountID,
ContractTypeID,TContractType.Name as ContractTypeName,
StartDate,EndDate,
Remark,Attachment
          From   TEmployeeContract,TContractType
          where  TEmployeeContract.ContractTypeID = TContractType.PKID
           order by TEmployeeContract.AccountID Asc,StartDate DESC
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
CREATE PROCEDURE GetEmployeeContractByCondition
(
     @AccountID int,
     @StartTimeFrom datetime,
     @StartTimeTo datetime,
     @EndTimeFrom datetime,
     @EndTimeTo datetime,
     @ContractTypeID   INT
)
AS
Begin
          Select TEmployeeContract.PKID,TEmployeeContract.AccountID,
ContractTypeID,TContractType.Name as ContractTypeName,
StartDate,EndDate,
Remark,Attachment
          From   TEmployeeContract,TContractType
          where  (@ContractTypeId=-1 or ContractTypeId=@ContractTypeId )
            and (datediff(dd, @StartTimeFrom, StartDate) >=0 )
            and (datediff(dd,StartDate,@StartTimeTo)>=0  )
            and (datediff(dd, @EndTimeFrom, EndDate) >=0 )
            and (datediff(dd,EndDate,@EndTimeTo)>=0  )
            and  TEmployeeContract.ContractTypeID = TContractType.PKID
            and  (@AccountID=-1 or TEmployeeContract.AccountID =@AccountID)
           order by TEmployeeContract.AccountID Asc,StartDate DESC
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
CREATE PROCEDURE [dbo].[GetEmployeePhotoByAccountID]
(
        @AccountID  INT                     
)
AS
Begin
SELECT Photo
  FROM [dbo].[TEmployee]
  WHERE TEmployee.AccountID=@AccountID
  order by pkid desc
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--Begin             公告、目标、年假         ------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE VacationInsert
(
	    @PKID INT out,
        @AccountID INT,
        @EmployeeName NVarChar(50),
        @VacationDayNum Decimal(6,3),
        @VacationStartDate DateTime,
        @VacationEndDate DateTime,
        @UsedDayNum Decimal(6,3),
        @SurplusDayNum Decimal(6,3),
        @Remark text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TVacation(AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNum,SurplusDayNum,Remark)
          values(@AccountID,@EmployeeName,@VacationDayNum,@VacationStartDate,
          @VacationEndDate,@UsedDayNum,@SurplusDayNum,@Remark)
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
CREATE PROCEDURE VacationUpdate
(
	    @PKID INT ,
        @VacationDayNum Decimal(6,3),
        @VacationStartDate DateTime,
        @VacationEndDate DateTime,
        @UsedDayNum Decimal(6,3),
        @SurplusDayNum Decimal(6,3),
        @Remark text
)
AS
Begin
          SET NOCOUNT OFF
          Update TVacation set 
          VacationDayNum=@VacationDayNum ,
          VacationStartDate=@VacationStartDate ,
          VacationEndDate=@VacationEndDate ,
          UsedDayNum=@UsedDayNum ,
          SurplusDayNum=@SurplusDayNum ,
          Remark=@Remark
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
CREATE PROCEDURE CountVacationByAccountID
(
	      @AccountID INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TVacation 
	      WHERE AccountID=@AccountID
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
CREATE PROCEDURE DeleteVacationByAccountID
(
        @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TVacation
	      WHERE AccountID=@AccountID
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
CREATE PROCEDURE DeleteVacationByVacationID
(
        @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TVacation
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
CREATE PROCEDURE GetAllVacation
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation
          order by EmployeeName
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
CREATE PROCEDURE GetVacationByCondition
(
           @EmployeeName NvarChar(50),
           @VacationDayNumStart decimal(6,3),
           @VacationDayNumEnd decimal(6,3),
           @VacationEndDateStart DateTime,
           @VacationEndDateEnd DateTime,
           @SurplusDayNumStart decimal(6,3),
           @SurplusDayNumEnd decimal(6,3)
        
)
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation Where
           (@EmployeeName='' or EmployeeName like '%' +@EmployeeName + '%' )
          And (@VacationDayNumStart=-1 or VacationDayNum>=@VacationDayNumStart )
          And (@VacationDayNumEnd=-1 or VacationDayNum<=@VacationDayNumEnd )
          And (datediff(dd, @VacationEndDateStart, VacationEndDate) >=0 )
          And (datediff(dd,VacationEndDate,@VacationEndDateEnd)>=0  )
          And (@SurplusDayNumStart=-1 or SurplusDayNum>=@SurplusDayNumStart  )
          And (@SurplusDayNumEnd=-1 or SurplusDayNum<=@SurplusDayNumEnd  )
          order by EmployeeName
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
CREATE PROCEDURE GetVacationByAccountID
(
          @AccountID INT
)
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation
          Where AccountID=@AccountID order by VacationEndDate Desc
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
CREATE PROCEDURE GetLastVacationByAccountID
(
          @AccountID INT
)
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation
          Where AccountID=@AccountID and VacationEndDate in (select max(VacationEndDate) from TVacation where AccountID=@AccountID) 
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
CREATE PROCEDURE GetVacationByAccountIDAndTimeSpan
(
          @AccountID INT,
@VacationStartDate Datetime,
@VacationEndDate Datetime
)
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation
          Where AccountID=@AccountID 
--!(dtstart1>dtend2||dtstart2>dtend1)等价于 dtstart1<=dtend2 && dtstart2<=dtend1)
and datediff(dd,@VacationStartDate,VacationEndDate)>=0
and datediff(dd,VacationStartDate,@VacationEndDate)>=0
order by VacationStartDate,PKID
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
CREATE PROCEDURE GetNearVacationByAccountIDAndTime
(
          @AccountID INT,
          @VacationEndDate Datetime
)
AS
Begin
          Select top 1 *
          from TVacation
          Where AccountID=@AccountID 
          and datediff(dd,VacationEndDate,@VacationEndDate)<=0
          order by VacationEndDate
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
CREATE PROCEDURE GetVacationByVacationID
(
          @PKID INT
)
AS
Begin
          Select PKID,AccountID,EmployeeName,VacationDayNum,VacationStartDate,
          VacationEndDate,UsedDayNUm,SurplusDayNum,Remark
          from TVacation
          Where PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--Begin                 合同类型      -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ContractTypeInsert
(
	    @PKID INT out,
        @Name Nvarchar(50),
        @Template image
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TContractType([Name],[Template])
          values(@Name,@Template)
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
CREATE PROCEDURE ContractTypeUpdate
(
	    @PKID INT out,
        @Name Nvarchar(50),
        @Template image
)
AS
Begin
          SET NOCOUNT OFF
          update TContractType
          set [Name] = @Name,  [Template]=  @Template 
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
CREATE PROCEDURE ContractTypeDelete
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TContractType
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
CREATE PROCEDURE CountContractTypeByName
(
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TContractType
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
CREATE PROCEDURE CountContractTypeByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TContractType
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
CREATE PROCEDURE GetContractTypeByPkid
(
	    @PKID INT
)
AS
Begin
          SELECT PKID,[Name],[Template]
	      FROM TContractType
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
CREATE PROCEDURE GetContractTypeByCondition
(
        @PKID INT,
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT PKID,[Name],[Template]
	      FROM TContractType
	      WHERE  [Name] like '%'+ @Name +'%' and (@PKID = -1 or PKID = @PKID)
          ORDER BY PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End                 合同类型      -------------

--Begin    记录合同模板的书签      -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ContractBookMarkInsert
(
	    @PKID INT out,
        @ContractTypeID INT,
        @BookMarkName Nvarchar(50)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TContractBookMark([ContractTypeID],[BookMarkName])
          values(@ContractTypeID,@BookMarkName)
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
CREATE PROCEDURE DeleteContractBookMarkByContractTypeID
(
	    @ContractTypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TContractBookMark
	      WHERE  ContractTypeID = @ContractTypeID
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
CREATE PROCEDURE GetContractBookMarkByContractTypeID
(
     @ContractTypeID INT
)
AS
Begin
          SELECT PKID,[ContractTypeID],[BookMarkName]
	      FROM TContractBookMark
	      WHERE  ContractTypeID = @ContractTypeID
          ORDER BY PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End    记录合同模板的书签      -------------


--Begin    记录员工合同的书签和值      ---------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE EmployeeContractBookMarkInsert
(
	    @PKID INT out,
        @EmployeeContractID INT,
        @BookMarkName Nvarchar(50),
        @BookMarkValue Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TEmployeeContractBookMark([EmployeeContractID],[BookMarkName],BookMarkValue)
          values(@EmployeeContractID,@BookMarkName,@BookMarkValue)
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
CREATE PROCEDURE DeleteEmployeeContractBookMarkByEmployeeContractID
(
	    @EmployeeContractID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TEmployeeContractBookMark
	      WHERE  EmployeeContractID = @EmployeeContractID
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
CREATE PROCEDURE GetEmployeeContractBookMarkByContractID
(
     @EmployeeContractID INT
)
AS
Begin
          SELECT PKID,[EmployeeContractID],[BookMarkName],BookMarkValue
	      FROM TEmployeeContractBookMark
	      WHERE  EmployeeContractID = @EmployeeContractID
          ORDER BY PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End    记录员工合同的书签和值      ---------------

--Begin    为查询部门历史里的员工增加存储过程      ---------------


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
create PROCEDURE GetEmployeeBasicInfoByDateTime
(
        @dt   DateTime
)
AS
Begin
          SET NOCOUNT OFF
SELECT [PKID]
      ,[AccountID]
      ,[CompanyID]
      ,[AccountType]
      ,[MobileNum]
      ,[IsAcceptEmail]
      ,[IsAcceptSMS]
      ,[IsValidateUsbKey]
      ,[LeaveDate]
      ,[Name]
      ,[LoginName]
      ,[Password]
      ,[Email1]
      ,[Email2]
      ,[DepartmentID]
      ,[PositionID]
      ,[ComeDate]
      ,[Birthday]
      ,[ResidencePermit]
      ,[EmployeeType]
      ,[EnglishName]
      ,[Gender]
      ,[PoliticalAffiliation]
      ,[MaritalStatus]
      ,[EducationalBackground]
      ,[WorkType]
      ,[HasChild]
      --,[EmployeeDetails]
      ,[Certificates]
      ,[PRPArea]
      ,[ProbationTime]
      ,[UsbKey]
      --,[Photo]
      ,[DoorCardNo]
      ,[SocietyWorkAge]
      ,[OperatorID]
      ,[OperationTime]
      ,[Remark]
,DepartmentName
,LeaderName
,PositionName 
,OperatorName
,PositionGradeID
,ProbationStartTime
,SalaryCardNo
,SalaryCardBank
          from TEmployeeHistory ,
		      (select max(OperationTime) as tempOperationTime,accountid as tempaccountid 
			  from TEmployeeHistory
			  where datediff(dd,OperationTime ,@dt )>=0
					group by accountid) temp
          where datediff(ss,OperationTime,tempOperationTime)=0
				and accountid = tempaccountid
         
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
create PROCEDURE GetEmployeeByAccountIDAndTime
(
        @AccountID   INT,
        @dt   DateTime
)
AS
Begin
          SET NOCOUNT OFF
          SELECT AccountID,PKID
           FROM TEmployeeHistory
           WHERE TEmployeeHistory.OperationTime=@dt
			 AND TEmployeeHistory.AccountID=@AccountID
	    order by DepartmentID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End    为查询部门历史里的员工增加存储过程      ---------------



--Begin             员工福利       -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertEmployeeWelfareByAccountID
(
	@PKID int OUTPUT,
	@AccountID int,
	@SocialSecurityType int,
	@SocialSecurityBase decimal(25, 2),
	@YangLaoBase decimal(25, 2),
	@ShiYeBase decimal(25, 2),
	@YiLiaoBase decimal(25, 2),
	@SocialSecurityEffectiveYearMonth datetime,
	@AccumulationFundAccount nvarchar(255),
    @AccumulationFundSupplyAccount nvarchar(255),
    @AccumulationFundSupplyBase decimal(25, 2),
	@AccumulationFundBase decimal(25, 2),
	@AccumulationFundEffectiveMonthYear datetime
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TEmployeeWelfare([AccountID], [SocialSecurityType], [SocialSecurityBase], 
[SocialSecurityEffectiveYearMonth], [AccumulationFundAccount],
AccumulationFundSupplyAccount,AccumulationFundSupplyBase, 
[AccumulationFundBase], [AccumulationFundEffectiveMonthYear],
YangLaoBase,ShiYeBase,YiLiaoBase)
    values(@AccountID, @SocialSecurityType, @SocialSecurityBase, 
@SocialSecurityEffectiveYearMonth, @AccumulationFundAccount,
@AccumulationFundSupplyAccount,@AccumulationFundSupplyBase, 
@AccumulationFundBase, @AccumulationFundEffectiveMonthYear,
@YangLaoBase,@ShiYeBase,@YiLiaoBase)
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
CREATE PROCEDURE UpdateEmployeeWelfareByAccountID
(
	@AccountID int,
	@SocialSecurityType int,
	@YangLaoBase decimal(25, 2),
	@ShiYeBase decimal(25, 2),
	@YiLiaoBase decimal(25, 2),
	@SocialSecurityBase decimal(25, 2),
	@SocialSecurityEffectiveYearMonth datetime,
	@AccumulationFundAccount nvarchar(255),
    @AccumulationFundSupplyAccount nvarchar(255),
    @AccumulationFundSupplyBase decimal(25, 2),
	@AccumulationFundBase decimal(25, 2),
	@AccumulationFundEffectiveMonthYear datetime
)
AS
Begin
    SET NOCOUNT OFF
    Update TEmployeeWelfare
    set
	[SocialSecurityType] = @SocialSecurityType,
	[SocialSecurityBase] = @SocialSecurityBase,
	YangLaoBase = @YangLaoBase,
	ShiYeBase = @ShiYeBase,
	YiLiaoBase = @YiLiaoBase,
	[SocialSecurityEffectiveYearMonth] = @SocialSecurityEffectiveYearMonth,
	[AccumulationFundAccount] = @AccumulationFundAccount,
    [AccumulationFundSupplyAccount]=@AccumulationFundSupplyAccount,
    [AccumulationFundSupplyBase]=@AccumulationFundSupplyBase,
	[AccumulationFundBase] = @AccumulationFundBase,
	[AccumulationFundEffectiveMonthYear] = @AccumulationFundEffectiveMonthYear
    where [AccountID] = @AccountID	
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
CREATE PROCEDURE DeleteEmployeeWelfareByAccountID
(
	@AccountID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TEmployeeWelfare
     where [AccountID] = @AccountID
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
CREATE PROCEDURE GetEmployeeWelfareByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT  *
    from TEmployeeWelfare
	where 	[AccountID] = @AccountID

End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              员工福利        -------------

--Begin             员工福利历史       -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CreateEmployeeWelfareHistoryByAccountID
(
	@PKID int OUTPUT,
	@AccountID int,
	@SocialSecurityType int,
	@SocialSecurityBase decimal(25, 2),
	@YangLaoBase decimal(25, 2),
	@ShiYeBase decimal(25, 2),
	@YiLiaoBase decimal(25, 2),
	@SocialSecurityEffectiveYearMonth datetime,
	@AccumulationFundAccount nvarchar(255),
    @AccumulationFundSupplyAccount nvarchar(255),
    @AccumulationFundSupplyBase decimal(25, 2),
	@AccumulationFundBase decimal(25, 2),
	@AccumulationFundEffectiveMonthYear datetime,
	@OperationTime datetime,
	@AccountsBackName nvarchar(255)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TEmployeeWelfareHistory([AccountID], [SocialSecurityType], [SocialSecurityBase], 
[SocialSecurityEffectiveYearMonth], [AccumulationFundAccount],[AccumulationFundSupplyAccount], 
[AccumulationFundSupplyBase],[AccumulationFundBase], [AccumulationFundEffectiveMonthYear], 
[OperationTime], [AccountsBackName],
YangLaoBase,ShiYeBase,YiLiaoBase)
    values(@AccountID, @SocialSecurityType, @SocialSecurityBase, @SocialSecurityEffectiveYearMonth, 
@AccumulationFundAccount,@AccumulationFundSupplyAccount,@AccumulationFundSupplyBase,
@AccumulationFundBase, @AccumulationFundEffectiveMonthYear, @OperationTime, @AccountsBackName,
@YangLaoBase,@ShiYeBase,@YiLiaoBase)
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
CREATE PROCEDURE GetEmployeeWelfareHistoryByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT  *
    from TEmployeeWelfareHistory
	where 	[AccountID] = @AccountID
    order by [OperationTime] desc

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
CREATE PROCEDURE DeleteEmployeeWelfareHistoryByAccountID
(
	@AccountID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TEmployeeWelfareHistory
     where [AccountID] = @AccountID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              员工福利历史        -------------
--技能
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE SkillInsert
(
	    @PKID INT out,
        @Name Nvarchar(100),
        @TypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TSkill([Name],TypeID)
          values(@Name,@TypeID)
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
CREATE PROCEDURE SkillUpdate
(
	    @PKID INT,
        @Name Nvarchar(100),
        @TypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Update TSkill SET 
          [Name]=@Name,
          TypeID=@TypeID
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
CREATE PROCEDURE SkillDelete
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TSkill
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
CREATE PROCEDURE CountSkillByName
(
	    @Name Nvarchar(100)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TSkill
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
CREATE PROCEDURE CountSkillByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(100)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TSkill
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
CREATE PROCEDURE GetSkillByPkid
(
     @PKID INT
)
as 
Begin
         SELECT TSkill.PKID,TSkill.[Name],TSkill.TypeID,TParameter.Name as TypeName
	     FROM TSkill,TParameter 
         WHERE TSkill.PKID=@PKID
         AND TParameter.PKID=TSkill.TypeID
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
CREATE PROCEDURE GetSkillsByCondition
(
     @Name Nvarchar(100),
     @TypeID INT
)
as 
Begin
         SELECT TSkill.PKID,TSkill.[Name],TSkill.TypeID,TParameter.Name as TypeName
	     FROM TSkill,TParameter 
         WHERE TSkill.[Name] like '%'+@Name+'%'
         AND (@TypeID=-1 or TSkill.TypeID=@TypeID)
         AND TParameter.PKID=TSkill.TypeID
	order by TSkill.PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---员工技能

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE EmployeeSkillInsert
(
	    @PKID INT out,
        @AccountID INT,
        @SkillID    INT,
        @SkillName  Nvarchar(100),    
        @SkillRank INT,    
        @Score decimal,    
        @Remark text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TEmployeeSkill(AccountID,SkillID,SkillName,SkillRank,Score,Remark)
          values(@AccountID,@SkillID,@SkillName,@SkillRank,@Score,@Remark)
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
CREATE PROCEDURE DeleteEmployeeSkillByAccountID
(
	    @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TEmployeeSkill
          where AccountID = @AccountID
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
CREATE PROCEDURE GetEmployeeSkillByAccountID
(
     @AccountID INT,
     @SkillID    INT,
     @SkillName  Nvarchar(100),    
     @SkillRank INT
)
as 
Begin
         SELECT TEmployeeSkill.PKID,TEmployeeSkill.AccountID,TEmployeeSkill.SkillID,TEmployeeSkill.SkillName,TEmployeeSkill.SkillRank,TParameter.PKID as SkillTypeId, TParameter.Name as SkillTypeName,    
        TEmployeeSkill.Score,    TEmployeeSkill.Remark
	     FROM TEmployeeSkill,TSkill,TParameter 
         WHERE (@AccountID=-1 OR TEmployeeSkill.AccountID=@AccountID)
         AND TEmployeeSkill.SkillName like '%'+@SkillName+'%'
         AND TEmployeeSkill.SkillID=TSkill.PKID
         AND TParameter.PKID=TSkill.TypeID
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
CREATE PROCEDURE CountEmployeeSkillBySkillID
(
     @SkillID INT
)
as 
Begin
         SELECT Counts=count(AccountID)
	     FROM  TEmployeeSkill
         WHERE TEmployeeSkill.SkillID=@SkillID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--Begin               部门历史      -------------


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DepartmentHistoryInsert
(
    @PKID	  INT out,
    @DepartmentID  INT,
    @DepartmentName    Nvarchar(50),
    @LeaderID  INT,
    @LeaderName  Nvarchar(50),
    @ParentID  INT,
    @OperatorName   Nvarchar(50),
    @OperationTime  DateTime
        ,@Address NVARCHAR(200)
        ,@Phone  NVARCHAR(50)
        ,@Fax NVARCHAR(50)
        ,@Others NVARCHAR(50)
        ,@Description Text
        ,@FoundationTime DateTime
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TDepartmentHistory(DepartmentID,DepartmentName,LeaderID,LeaderName,ParentID,OperatorName,OperationTime        ,[Address]
        ,Phone 
        ,Fax 
        ,Others
        ,[Description] 
        ,FoundationTime)
          values(@DepartmentID,@DepartmentName,@LeaderID,@LeaderName,@ParentID,@OperatorName,@OperationTime        ,@Address
        ,@Phone 
        ,@Fax 
        ,@Others
        ,@Description 
        ,@FoundationTime)
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
CREATE PROCEDURE GetDepartmentByDepartmentIDAndDateTime
(
    @DepartmentID  INT,
    @OperationTime  DateTime
)
AS
Begin
          SET NOCOUNT OFF
          select top(1)* from TDepartmentHistory
          where @DepartmentID  =DepartmentID and
                datediff(dd,@OperationTime  ,OperationTime)<=0
                order by OperationTime desc
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
CREATE PROCEDURE GetDepartmentByDateTime
(
    @OperationTime  DateTime
)
AS
Begin
          SET NOCOUNT OFF
          select * from TDepartmentHistory 
          where datediff(s,
          (select top(1) OperationTime from TDepartmentHistory
          where datediff(dd,@OperationTime  ,OperationTime)<=0
                order by OperationTime desc) 
          ,OperationTime)=0 order by parentid

End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End                部门历史      -------------


--Begin               员工表后加字段  考勤，社会工龄       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAttendanceViewCalendarByCondition
(
	@EmployeeId int,
    @AttendanceType  int,
    @DayFrom DateTime,
    @DayTo   DateTime
)
AS
Begin
    SELECT TEmployeeAttendance.PKID,TEmployeeAttendance.[Name] as AttendanceName,TEmployeeAttendance.EmployeeId,[Days],[AddDutyDays],EarlyAndLateMunite,[TheDay],[AttendanceType]
    FROM  TEmployeeAttendance
    WHERE  (TEmployeeAttendance.EmployeeId=@EmployeeId OR @EmployeeId=-1)
    AND   (AttendanceType=@AttendanceType OR @AttendanceType=-1)
    AND  (@DayFrom='1900-1-1' or datediff(dd,@DayFrom,TheDay)>=0)
    AND  (@DayTo='2900-12-31' or datediff(dd,TheDay,@DayTo)>=0)
    order by PKID
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

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
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
	ORDER BY B.AuthParentId ASC,B.PKID
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



--Begin             帐套参数        ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertAccountSetPara
(
	@PKID INT out,
        @AccountSetParaName Nvarchar(255),
        @Description     Text,
        @FieldAttribute     INT,
        @BindItem           INT,     
        @MantissaRound      INT,     
        @IsVisibleToEmployee      INT,     
        @IsVisibleWhenZero      INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAccountSetPara
([AccountSetParaName]
,[FieldAttribute]
,BindItem 
,MantissaRound
,IsVisibleToEmployee
,IsVisibleWhenZero
,Description)
          values
(@AccountSetParaName 
,@FieldAttribute     
,@BindItem           
,@MantissaRound
,@IsVisibleToEmployee
,@IsVisibleWhenZero
,@Description)
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
CREATE PROCEDURE UpdateAccountSetPara
(
	@PKID INT out,
        @AccountSetParaName Nvarchar(255),
        @Description     Text,
        @FieldAttribute     INT,
        @BindItem           INT,     
        @MantissaRound      INT,     
        @IsVisibleToEmployee      INT,     
        @IsVisibleWhenZero      INT
)
AS
Begin
          SET NOCOUNT OFF
          update TAccountSetPara
          set [AccountSetParaName] = @AccountSetParaName , 
              [FieldAttribute]=  @FieldAttribute,
              BindItem=@BindItem ,
              MantissaRound=@MantissaRound,
              Description=@Description,     
              IsVisibleToEmployee=@IsVisibleToEmployee ,     
              IsVisibleWhenZero=@IsVisibleWhenZero     
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
CREATE PROCEDURE CountAccountSetParaByNameDiffPKID
(
	    @PKID INT,
	    @AccountSetParaName Nvarchar(255)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TAccountSetPara
	      WHERE [AccountSetParaName] = @AccountSetParaName  and PKID <> @PKID
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
CREATE PROCEDURE DeleteAccountSetParaByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAccountSetPara
	  WHERE  PKID = @PKID 
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
create PROCEDURE GetAccountSetParaByPKID
(
        @PKID INT
)
AS
Begin
          SELECT * FROM TAccountSetPara
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
create PROCEDURE GetAccountSetParaByName
(
        @AccountSetParaName Nvarchar(255)
)
AS
Begin
          SELECT * FROM TAccountSetPara
	      WHERE AccountSetParaName = @AccountSetParaName
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
create PROCEDURE GetAccountSetParaByCondition
(
        @AccountSetParaName Nvarchar(255),
        @FieldAttribute     INT,
        @BindItem           INT,     
        @MantissaRound      INT
)
AS
Begin
          SELECT * FROM TAccountSetPara
	     WHERE AccountSetParaName like '%'+ @AccountSetParaName  +'%' 
             and (@FieldAttribute      = -1 or FieldAttribute= @FieldAttribute)
             and (@BindItem            = -1 or BindItem = @BindItem)    
             and (@MantissaRound       = -1 or MantissaRound= @MantissaRound) 
             ORDER BY AccountSetParaName 
   End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End               帐套参数         ------------


--Begin             帐套       ------------


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertAccountSet
(
	@PKID INT out,
        @AccountSetName Nvarchar(255),
        @Description     Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAccountSet([AccountSetName],Description)
          values(@AccountSetName  ,@Description     )
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
CREATE PROCEDURE UpdateAccountSet
(
	@PKID INT out,
        @AccountSetName Nvarchar(255),
        @Description     Text
)
AS
Begin
          SET NOCOUNT OFF
          update TAccountSet
          set AccountSetName  = @AccountSetName , 
              Description     = @Description  
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
CREATE PROCEDURE CountAccountSetByNameDiffPKID
(
	    @PKID INT,
	    @AccountSetName Nvarchar(255)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TAccountSet
	      WHERE AccountSetName  = @AccountSetName and PKID <> @PKID
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
CREATE PROCEDURE DeleteAccountSetByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAccountSet
	  WHERE  PKID = @PKID 
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
create PROCEDURE GetAccountSetByPKID
(
        @PKID INT
)
AS
Begin
          SELECT * FROM TAccountSet
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
create PROCEDURE GetAccountSetByCondition
(
        @AccountSetName Nvarchar(255)
)
AS
Begin
          SELECT * FROM TAccountSet
	      WHERE AccountSetName like '%'+ @AccountSetName +'%' order by pkid desc
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
create PROCEDURE GetAccountSetByName
(
        @AccountSetName Nvarchar(255)
)
AS
Begin
          SELECT * FROM TAccountSet
	      WHERE AccountSetName = @AccountSetName order by pkid desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End               帐套         ------------

--Begin             帐套项        ------------


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertAccountSetItem
(
	@PKID               INT out,
        @AccountSetID       int,
        @AccountSetParaID   int,
@FieldAttribute int,
@BindItem int,
@MantissaRound int,
        @CalculateFormula   Nvarchar(255)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAccountSetItem(
			AccountSetID  ,
			AccountSetParaID   ,
			FieldAttribute,   
			BindItem,
			MantissaRound,
			CalculateFormula )
          values(
			@AccountSetID  ,
			@AccountSetParaID   ,   
			@FieldAttribute,
			@BindItem,
			@MantissaRound,
			@CalculateFormula )
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
CREATE PROCEDURE DeleteAccountSetItemByAccountSetID
(
	    @AccountSetID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAccountSetItem
	  WHERE  AccountSetID= @AccountSetID 
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
create PROCEDURE GetAccountSetItemByAccountSetID
(
        @AccountSetID INT
)
AS
Begin
          SELECT TAccountSetItem.* , 
          TAccountSetPara.AccountSetParaName,
	      TAccountSetPara.Description,
	      TAccountSetPara.IsVisibleToEmployee,
	      TAccountSetPara.IsVisibleWhenZero
          FROM TAccountSetItem 
          left join TAccountSetPara on TAccountSetItem.AccountSetParaID=TAccountSetPara.PKID
	      WHERE TAccountSetItem.AccountSetID=  @AccountSetID order by pkid
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
CREATE PROCEDURE CountAccountSetItemByAccountSetParaID
(
	    @AccountSetParaID int
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TAccountSetItem
	      WHERE AccountSetParaID  = @AccountSetParaID 
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              帐套项         ------------


--Begin            员工薪资        ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertEmployeeAccountSet
(
		@PKID               INT out,
        @AccountSetID       int,
        @AccountSetName	    Nvarchar(255),
        @EmployeeID		    int,
        @EmployeeAccountSetItems image,
        @Description	    Nvarchar(255)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TEmployeeAccountSet(AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,Description)
          values(@AccountSetID,@AccountSetName,@EmployeeID,@EmployeeAccountSetItems,@Description)
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
CREATE PROCEDURE UpdateEmployeeAccountSet
(
        @AccountSetID       int,
        @AccountSetName	    Nvarchar(255),
        @EmployeeID		    int,
        @EmployeeAccountSetItems image,
        @Description	    Nvarchar(255)
)
AS
Begin
          update TEmployeeAccountSet
          set AccountSetID = @AccountSetID, 
              AccountSetName = @AccountSetName,
              EmployeeAccountSetItems = @EmployeeAccountSetItems,
			  Description = @Description
          where EmployeeID=@EmployeeID
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
CREATE PROCEDURE GetEmployeeAccountSetByEmployeeID
(
		@EmployeeID               INT
)
AS
Begin
          select AccountSetID,AccountSetName,EmployeeAccountSetItems,Description from TEmployeeAccountSet
          where EmployeeID=@EmployeeID
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
CREATE PROCEDURE CountEmployeeAccountSetByAccountSetID
(
		@AccountSetID               INT
)
AS
Begin
          select count(pkid) as [Count] from TEmployeeAccountSet
          where AccountSetID=@AccountSetID
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
CREATE PROCEDURE GetEmployeeAccountSetByAccountSetID
(
		@AccountSetID               INT
)
AS
Begin
          select EmployeeID,AccountSetName,EmployeeAccountSetItems,Description from TEmployeeAccountSet
          where AccountSetID=@AccountSetID
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
CREATE PROCEDURE GetAllEmployeeAccountSet
AS
Begin
          SELECT TEmployeeAccountSet.*
          from TEmployeeAccountSet
          order By TEmployeeAccountSet.PKID   
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
CREATE PROCEDURE InsertEmployeeSalaryHistory
(
		@PKID               INT out,
        @AccountSetID       int,
        @AccountSetName	    Nvarchar(255),
        @EmployeeID		    int,
        @EmployeeAccountSetItems image,
	    @Status					int				,
	    @SalaryDateTime			DateTime		,
	    @AccountsBackName		Nvarchar(255),
        @Descpriton		Nvarchar(255)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TEmployeeSalaryHistory(AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,VersionNumber,[Status],SalaryDateTime,AccountsBackName,Descpriton)
          values(@AccountSetID,@AccountSetName,@EmployeeID,@EmployeeAccountSetItems,1,@Status,@SalaryDateTime,@AccountsBackName,@Descpriton)
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
CREATE PROCEDURE UpdateAdjustSalaryHistory
(
		@PKID						int,
        @EmployeeID					int,
        @AccountSetName				Nvarchar(255),
        @EmployeeAccountSetItems	image,
		@Description				Nvarchar(255),
        @ChangeDate					DateTime,
        @AccountsBackName			Nvarchar(255)
)
AS
Begin
UPDATE [TAdjustSalaryHistory]
   SET [EmployeeID] = @EmployeeID
      ,[AccountSetName] = @AccountSetName
      ,[EmployeeAccountSetItems] = @EmployeeAccountSetItems
      ,[Description] = @Description
      ,[ChangeDate] = @ChangeDate
      ,[AccountsBackName] = @AccountsBackName
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
CREATE PROCEDURE InsertAdjustSalaryHistory
(
		@PKID						int out,
        @EmployeeID					int,
        @AccountSetName				Nvarchar(255),
        @EmployeeAccountSetItems	image,
		@Description				Nvarchar(255),
        @ChangeDate					DateTime,
        @AccountsBackName			Nvarchar(255)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAdjustSalaryHistory
				(AccountSetName,EmployeeID,EmployeeAccountSetItems,ChangeDate,AccountsBackName,Description)
          values(@AccountSetName,@EmployeeID,@EmployeeAccountSetItems,@ChangeDate,@AccountsBackName,@Description)
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
CREATE PROCEDURE UpdateEmployeeSalaryHistory
(
		@PKID               INT,
        @AccountSetID       int,
        @AccountSetName	    Nvarchar(255),
        @EmployeeID		    int,
        @EmployeeAccountSetItems image,
	    @VersionNumber			int				,
	    @Status					int				,
	    @SalaryDateTime			DateTime		,
	    @AccountsBackName		Nvarchar(255),
        @Descpriton		Nvarchar(255)
)
AS
Begin
          update TEmployeeSalaryHistory
          set AccountSetID = @AccountSetID, 
              AccountSetName = @AccountSetName, 
              EmployeeID = @EmployeeID, 
              EmployeeAccountSetItems = @EmployeeAccountSetItems,
              VersionNumber=@VersionNumber,
	          [Status]=@Status,
	          SalaryDateTime=@SalaryDateTime,
	          AccountsBackName=@AccountsBackName,
              Descpriton=@Descpriton	
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
CREATE PROCEDURE GetEmployeeSalaryByEmployeeID
(
		@EmployeeID               INT
)
AS
Begin
          select PKID,AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,VersionNumber,[Status],SalaryDateTime,AccountsBackName,Descpriton
          from TEmployeeSalaryHistory
          where EmployeeID=@EmployeeID
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
CREATE PROCEDURE GetEmployeeSalaryHistoryByPKID
(
		@PKID               INT
)
AS
Begin
          select  PKID,AccountSetID,AccountSetName,EmployeeID,
EmployeeAccountSetItems,VersionNumber,[Status],
					SalaryDateTime,AccountsBackName,Descpriton
          from TEmployeeSalaryHistory
          where Pkid=@PKID
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
CREATE PROCEDURE GetEmployeeSalaryByCondition
(
     @AccountSetID   INT,
     @SalaryDateTime DateTime
)
AS
Begin
          select  TEmployeeSalaryHistory.PKID,AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,VersionNumber,[Status],
                  SalaryDateTime,AccountsBackName,Descpriton
          from TEmployeeSalaryHistory
          where (@AccountSetID=-1 or AccountSetID = @AccountSetID)
          and (SalaryDateTime =@SalaryDateTime)
          ORDER BY EmployeeID 
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
CREATE PROCEDURE DeleteEmployeeSalaryHistory
(
     @Pkid         INT
)
AS
Begin
          Delete from TEmployeeSalaryHistory
          where pkid=@Pkid
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
CREATE PROCEDURE GetAdjustSalaryHistoryByEmployeeID
(
        @EmployeeID					int
)
AS
Begin
          select PKID,AccountSetName,EmployeeAccountSetItems,ChangeDate,AccountsBackName,Description 
	      from TAdjustSalaryHistory
          where EmployeeID=@EmployeeID
          order by ChangeDate desc
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
CREATE PROCEDURE GetAdjustSalaryHistoryByPKID
(
        @PKID					int
)
AS
Begin
          select PKID,AccountSetName,EmployeeAccountSetItems,ChangeDate,AccountsBackName,Description,EmployeeID
			from TAdjustSalaryHistory
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
CREATE PROCEDURE GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
(
        @EmployeeID					int,
		@SalaryDateTime					DateTime
)
AS
Begin
          select  PKID,AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,VersionNumber,[Status],SalaryDateTime,AccountsBackName,Descpriton
          from TEmployeeSalaryHistory
          where EmployeeID=@EmployeeID and SalaryDateTime=@SalaryDateTime
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
CREATE PROCEDURE GetEmployeeSalaryHistoryByEmployeeId
(
        @EmployeeID					int
)
AS
Begin
          select  PKID,AccountSetID,AccountSetName,EmployeeID,EmployeeAccountSetItems,VersionNumber,[Status],SalaryDateTime,AccountsBackName,Descpriton
          from TEmployeeSalaryHistory
          where EmployeeID=@EmployeeID order by SalaryDateTime desc
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
CREATE PROCEDURE GetEmployeeAccountSetByAccountSetParaID
(
        @AccountSetParaID					int
)
AS
Begin
          SELECT TEmployeeAccountSet.*
          from TEmployeeAccountSet,TAccountSetItem
          WHERE  TEmployeeAccountSet.AccountSetID=TAccountSetItem.AccountSetID
			and AccountSetParaID=@AccountSetParaID
          order By TEmployeeAccountSet.PKID 
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
CREATE PROCEDURE GetAdjustSalaryHistoryByEmployeeIDAndDateTime
(
        @EmployeeID					int,
		@ChangeDate					DateTime
)
AS
Begin
          select AccountSetName,EmployeeAccountSetItems,ChangeDate,AccountsBackName,Description from TAdjustSalaryHistory
          where EmployeeID=@EmployeeID and ChangeDate=@ChangeDate
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              员工薪资        ------------

--Begin          税制            -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertIndividualIncomeTax
(
	@PKID int OUTPUT,
	@BandMin decimal(25, 2),
	@TaxRate decimal(25, 2),
	@Type int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TIndividualIncomeTax([BandMin], [TaxRate], [Type])
    values(@BandMin, @TaxRate, @Type)
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
CREATE PROCEDURE UpdateTaxCutoffPoint
(
	@BandMin decimal(25, 2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TIndividualIncomeTax
    set
	[BandMin] = @BandMin
    where [Type] = 0	
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
CREATE PROCEDURE UpdateForeignTaxCutoffPoint
(
	@BandMin decimal(25, 2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TIndividualIncomeTax
    set
	[BandMin] = @BandMin
    where [Type] = 2	
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
CREATE PROCEDURE GetTaxCutoffPoint
AS
Begin
    SELECT  [BandMin]
    from TIndividualIncomeTax
    where [Type] = 0

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
CREATE PROCEDURE GetForeignTaxCutoffPoint
AS
Begin
    SELECT  [BandMin]
    from TIndividualIncomeTax
    where [Type] = 2

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
CREATE PROCEDURE UpdateTaxBand
(
	@PKID int,
	@BandMin decimal(25, 2),
	@TaxRate decimal(25, 2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TIndividualIncomeTax
    set
	[BandMin] = @BandMin,
	[TaxRate] = @TaxRate
    where [PKID] = @PKID	
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
CREATE PROCEDURE DeleteTaxBandByTaxBandID
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TIndividualIncomeTax
     where [PKID] = @PKID
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
CREATE PROCEDURE GetTaxBandByTaxBandID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], [BandMin], [TaxRate]
    from TIndividualIncomeTax
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetAllTaxBand
as
Begin
    SELECT  [PKID], [BandMin], [TaxRate]
    from TIndividualIncomeTax
    where [Type] = 1
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
CREATE PROCEDURE GetTaxBandCountByBindMinDiffPKID
(
    @PKID int,
	@BandMin decimal(25, 2)
)
AS
Begin
    Select  counts=count(PKID)
    from TIndividualIncomeTax 
	Where
	[BandMin] = @BandMin
	AND PKID  not in(@PKID)
    AND Type=1
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
CREATE PROCEDURE GetTaxBandCountByBindMin
(
	@BandMin decimal(25, 2)
)
AS
Begin
    Select  counts=count(PKID)
    from TIndividualIncomeTax 
	Where
	[BandMin] = @BandMin
    AND Type=1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              税制        -------------
--Begin              调休        -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAdjustRestByAccountIDAndYear
(
	@AccountID int,
    @AdjustYear DateTime
)
AS
Begin
    SELECT *
    FROM  TAdjustRest
    WHERE AccountID=@AccountID
    and DateDiff(yy,AdjustYear,@AdjustYear)=0
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
CREATE PROCEDURE GetAdjustRestByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT *
    FROM  TAdjustRest
    WHERE AccountID=@AccountID
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
CREATE PROCEDURE GetAdjustRestByPKID
(
	@PKID int
)
AS
Begin
    SELECT *
    FROM  TAdjustRest
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
CREATE PROCEDURE UpdateAdjustRestByAdjustID
(
    @PKID int,
	@AccountID int,
    @Hours Decimal(25,2),
    @AdjustYear DateTime
)
AS
Begin
    SET NOCOUNT OFF
    Update TAdjustRest
    set
    AccountID=@AccountID,
    AdjustYear=@AdjustYear,
	Hours = @Hours
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
CREATE PROCEDURE AdjustRestInsert
(
    @PKID int OUTPUT,
    @AccountID          INT,
    @Hours Decimal(25,2) ,
    @AdjustYear  DateTime   
)
AS
Begin
    INSERT INTO TAdjustRest([AccountID],Hours,AdjustYear)
    VALUES (@AccountID,@Hours,@AdjustYear)
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
CREATE PROCEDURE DeleteAdjustRestByAccountID
(
	    @AccountID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAdjustRest
	      WHERE AccountID = @AccountID
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
CREATE PROCEDURE AdjustRestHistoryDelete
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAdjustRestHistory
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
CREATE PROCEDURE AdjustRestHistoryInsert
(
    @PKID int OUTPUT,   
@AccountID		int ,
@OccurTime			Datetime,
@OperatorId          INT,
@ChangeHours Decimal(25,2),--变动小时数，可能为正可能为负
--@ResultAdjustRestHours Decimal(25,2),--当前结算结果，剩余调休
@AdjustRestHistoryType  INT,--区分此次历史生成的信息来源
@RelevantID Int,
@Remark Nvarchar(255)
)
AS
Begin
    INSERT INTO TAdjustRestHistory
(
AccountID,
OccurTime,
OperatorId,
ChangeHours,
--ResultAdjustRestHours,
AdjustRestHistoryType,
RelevantID,
Remark
)
    VALUES (
@AccountID,
@OccurTime,
@OperatorId,
@ChangeHours,
--@ResultAdjustRestHours,
@AdjustRestHistoryType,
@RelevantID,
@Remark
)
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
CREATE PROCEDURE GetAdjustRestHistoryByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT *
    FROM  TAdjustRestHistory
    WHERE AccountID=@AccountID
	order by OccurTime desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              调休        -------------

--Begin               考评管理       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE AssessTemplateItemInsert
(
	    @PKID INT out,
        @Question Nvarchar(100),
        @OperateType INT,
        @AssessTemplateItemType INT , 
        @ItemClassfication INT,
        @ItemOption  Nvarchar(1000),
        @ItemDescription Text        
 )
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessTemplateItem(Question,OperateType,AssessTemplateItemType,ItemClassfication,ItemOption,ItemDescription)
          values(@Question,@OperateType,@AssessTemplateItemType,@ItemClassfication,@ItemOption,@ItemDescription)
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
CREATE PROCEDURE AssessTemplateItemUpdate
(
	    @PKID INT ,
        @Question Nvarchar(100),
        @OperateType INT,
        @AssessTemplateItemType INT , 
        @ItemClassfication INT,
        @ItemOption  Nvarchar(1000),
        @ItemDescription Text,       
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          Update TAssessTemplateItem 
          Set Question=@Question,OperateType =@OperateType,AssessTemplateItemType=@AssessTemplateItemType,ItemClassfication=@ItemClassfication,ItemOption=@ItemOption,ItemDescription=@ItemDescription
          Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE AssessTemplateItemDelete
(
	    @PKID INT,
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          DELETE From TAssessTemplateItem Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE CountTemplateItemByQuestionDiffPKID
(  
    @PKID int,    
    @Question Nvarchar(100)
)
AS
Begin
        Select counts = count(PKID)
        FROM TAssessTemplateItem WHERE (PKID<>@PKID)
        AND (Question =@Question)    
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
CREATE PROCEDURE CountTemplateItemByTitle
(   
    @Question Nvarchar(100)
)
AS
Begin
        Select Counts = count(PKID)
        FROM TAssessTemplateItem 
        WHERE Question=@Question
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
CREATE PROCEDURE GetAssessTemplateItemByPKID
(      
    @PKID  INT
)
AS
BEGIN	
	SELECT PKID,Question,OperateType,AssessTemplateItemType,ItemClassfication,ItemOption,ItemDescription
    FROM TAssessTemplateItem 
    WHERE PKID=@PKID
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
CREATE PROCEDURE GetTemplateItemsByConditon
(      
    @Question  Nvarchar(100),
    @OperateType int,   
    @ItemClassfication INT,
    @AssessTemplateItemType INT
)
AS
BEGIN	
    SET NOCOUNT ON
	SELECT PKID,Question,OperateType,AssessTemplateItemType,ItemClassfication,ItemOption,ItemDescription
    FROM TAssessTemplateItem 
    WHERE (Question like '%'+@Question+'%')
    and (@OperateType = -1 or OperateType=@OperateType)
    and (@ItemClassfication = -1 or ItemClassfication=@ItemClassfication) 
    and (@AssessTemplateItemType= -1 or AssessTemplateItemType=@AssessTemplateItemType) 
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
CREATE PROCEDURE GetAllTemplateItems
AS
BEGIN	
    SET NOCOUNT ON
	SELECT * FROM TAssessTemplateItem 
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
CREATE PROCEDURE AssessTemplatePaperInsert
(
	    @PKID INT out,
        @PaperName Nvarchar(50)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessTemplatePaper(PaperName)
          values(@PaperName)
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
CREATE PROCEDURE AssessTemplatePaperUpdate
(
	    @PKID INT ,
        @PaperName Nvarchar(50),
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          Update TAssessTemplatePaper 
          Set PaperName=@PaperName 
          Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE AssessTemplatePaperDelete
(
	    @PKID INT,
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          DELETE From TAssessTemplatePaper Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE GetAssessTemplatePaperByPKID
(      
    @PKID  INT
)
AS
BEGIN	
    select * from TAssessTemplatePaper
    where PKID=@PKID
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
CREATE PROCEDURE GetAllAssessTemplatePaper
AS
BEGIN	
      SELECT * from TAssessTemplatePaper
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
CREATE PROCEDURE GetTemplateItemIdInPaperByPaperId
(      
   @PKID INT
)
AS
BEGIN	
    select TAssessTemplatePaper.PKID as PaperID,
    TAssessTemplatePaper.PaperName, TAssessTemplateItem.PKID as ItemID,
    TAssessTemplateItem.Question,TAssessTemplateItem.OperateType,TAssessTemplateItem.AssessTemplateItemType,
    TAssessTemplateItem.ItemClassfication,TAssessTemplateItem.ItemOption,
    TAssessTemplateItem.ItemDescription ,TAssessTemplatePIShip.Weight
    from TAssessTemplatePaper,TAssessTemplatePIShip,TAssessTemplateItem
    where TAssessTemplatePaper.pkid = TAssessTemplatePIShip.AssessTemplatePaperID
    and TAssessTemplatePIShip.AssessTemplateItemID = TAssessTemplateItem.PKID
    and TAssessTemplatePaper.pkid=@PKID
 	order by PaperID,TAssessTemplatePIShip.PKID
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
CREATE PROCEDURE GetPIShipByItemId
(
	    @PKID INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TAssessTemplatePIShip
	      WHERE AssessTemplateItemID = @PKID
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
CREATE PROCEDURE GetAssessTemplatePaperByPaperName
(      
    @PaperName  Nvarchar(50)
)
AS
BEGIN	
    SET NOCOUNT ON
	SELECT * FROM TAssessTemplatePaper 
    WHERE (PaperName like '%'+@PaperName+'%')
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
CREATE PROCEDURE GetTemplatePapersExactlyByPaperName
(      
    @PaperName  Nvarchar(50)
)
AS
BEGIN	
    SET NOCOUNT ON
	SELECT * FROM TAssessTemplatePaper 
    WHERE PaperName = @PaperName
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
CREATE PROCEDURE CountTemplatePaperByPaperName
(  
    @PaperName Nvarchar(50)
)
AS
Begin
        Select Counts = count(PKID)
        FROM TAssessTemplatePaper 
        WHERE PaperName=@PaperName
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
CREATE PROCEDURE CountTemplatePaperByPaperNameDiffPKID
(  
    @PKID int,
    @PaperName Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TAssessTemplatePaper WHERE (PKID<>@PKID)
        AND (PaperName =@PaperName)    
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
CREATE PROCEDURE AssessTemplatePIShipInsert
(
	    @PKID INT out,
        @PaperID INT,
        @ItemID INT,
        @Weight decimal(25,2)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessTemplatePIShip (AssessTemplatePaperID,AssessTemplateItemID,Weight)
          values(@PaperID,@ItemID,@Weight)
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
CREATE PROCEDURE DeletePaperAndItemRelation
(
        @PaperID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete From TAssessTemplatePIShip Where(AssessTemplatePaperID=@PaperID)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End                 考评管理       -------------


--begin             考评活动         ------------

/****** 对象:  StoredProcedure [dbo].[InsertAssessActivity]    脚本日期: 04/16/2009 12:54:47 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[InsertAssessActivity]
(
	    @PKID INT out,
        @AssessEmployeeID INT,
        @AssessCharacter INT,
        @AssessStatus INT,
        @ScopeFrom DateTime,
        @ScopeTo DateTime,
        @PersonalGoal Text,
        @Reason Text,
        @AssessProposerName NVARCHAR(50),
        @Intention NVARCHAR(50),
        @HRConfirmerName NVARCHAR(50),
        @PersonalExpectedFinish DateTime,
        @ManagerExpectedFinish DateTime,
        @PaperName NVARCHAR(50),
        @Score Decimal(25,2),
        @EmployeeDept NVARCHAR(50),
		@Responsibility     NVARCHAR(255),
		@DiyProcess Text='',
		@NextStepIndex INT=-1,
		@IfEmployeeVisible int = 0
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessActivity(AssessEmployeeID,AssessCharacter,AssessStatus,
                 ScopeFrom,ScopeTo,PersonalGoal,Reason,AssessProposerName,Intention,
                 HRConfirmerName,PersonalExpectedFinish,ManagerExpectedFinish,PaperName,
                 Score,EmployeeDept,Responsibility,DiyProcess,NextStepIndex,IfEmployeeVisible)
          values(@AssessEmployeeID,@AssessCharacter,@AssessStatus,@ScopeFrom,@ScopeTo,
                 @PersonalGoal,@Reason,@AssessProposerName,@Intention,@HRConfirmerName,
                 @PersonalExpectedFinish,@ManagerExpectedFinish,@PaperName,@Score,@EmployeeDept,@Responsibility,
				 @DiyProcess,@NextStepIndex,@IfEmployeeVisible)
          select @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[InsertAssessActivityItem]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertAssessActivityItem
(
        @AssessActivityPaperID INT,
        @Type INT,
        @Question NVARCHAR(100),
        @Grade Decimal(25,2),
        @Note Text,
		@Option NVARCHAR(1000),
		@Classfication INT,
		@Description Text,
        @AssessTemplateItemType INT,
        @Weight  Decimal(25,2) 
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessActivityItem(AssessActivityPaperID,[Type],Question,
                 Grade,Note,[Option],Classfication,[Description],AssessTemplateItemType,Weight)
          values(@AssessActivityPaperID,@Type,@Question,@Grade,@Note,@Option,@Classfication,@Description,@AssessTemplateItemType,@Weight)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[InsertAssessActivityPaper]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertAssessActivityPaper
(
	    @PKID INT out,
        @AssessActivityID INT,
        @Type INT,
        @FillPerson NVARCHAR(50),
        @SubmitTime DateTime,
        @ChoseIntention NVARCHAR(50)='',
        @Content Text,
		@StepIndex int,
        @SalaryNow decimal(25,2)=null,
        @SalaryChange decimal(25,2)=null
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TAssessActivityPaper(AssessActivityID,[Type],FillPerson,
                 SubmitTime,ChoseIntention,[Content],StepIndex,SalaryNow,SalaryChange)
          values(@AssessActivityID,@Type,@FillPerson,@SubmitTime,@ChoseIntention,@Content,@StepIndex,@SalaryNow,@SalaryChange)
          select @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[UpdateAssessActivityPaper]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE UpdateAssessActivityPaper
(
	    @PKID INT,
        @AssessActivityID INT,
        @Type INT,
        @FillPerson NVARCHAR(50),
        @SubmitTime DateTime,
        @ChoseIntention NVARCHAR(50)='',
        @Content Text,
		@StepIndex int,
        @SalaryNow decimal(25,2)=null,
        @SalaryChange decimal(25,2)=null
)
AS
Begin
          SET NOCOUNT OFF
          update TAssessActivityPaper
			set AssessActivityID = AssessActivityID,
				[Type] = @Type,
				FillPerson = @FillPerson,
				SubmitTime = @SubmitTime,
				ChoseIntention = @ChoseIntention,
				[Content] = @Content,
				StepIndex = @StepIndex,
                SalaryNow=@SalaryNow,
                SalaryChange=@SalaryChange
          where PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[updateAssessActivity]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE updateAssessActivity
(
	    @PKID INT ,
        @AssessEmployeeID INT,
        @AssessCharacter INT,
        @AssessStatus INT,
        @ScopeFrom DateTime,
        @ScopeTo DateTime,
        @PersonalGoal Text,
        @Reason Text,
        @AssessProposerName NVARCHAR(50),
        @Intention NVARCHAR(50),
        @HRConfirmerName NVARCHAR(50),
        @PersonalExpectedFinish DateTime,
        @ManagerExpectedFinish DateTime,
        @PaperName NVARCHAR(50),
        @Score Decimal(25,2),
        @EmployeeDept NVARCHAR(50),
		@Responsibility NVARCHAR(255),
		@DiyProcess Text='',
		@NextStepIndex INT=-1,
		@IfEmployeeVisible int = 0
)
AS
Begin
          SET NOCOUNT OFF
          Update TAssessActivity 
          Set 
			AssessEmployeeID= @AssessEmployeeID,
			AssessCharacter=@AssessCharacter ,
			AssessStatus =@AssessStatus,
			ScopeFrom =@ScopeFrom,
			ScopeTo =@ScopeTo,
			PersonalGoal =@PersonalGoal,
			Reason=@Reason ,
			AssessProposerName =@AssessProposerName,
			Intention=@Intention ,
			HRConfirmerName =@HRConfirmerName,
			PersonalExpectedFinish=@PersonalExpectedFinish ,
			ManagerExpectedFinish=@ManagerExpectedFinish ,
			PaperName =@PaperName,
			Score =@Score,
			EmployeeDept =@EmployeeDept,
			Responsibility=@Responsibility,
			DiyProcess=@DiyProcess,
			NextStepIndex=@NextStepIndex,
			IfEmployeeVisible = @IfEmployeeVisible
          Where PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




/****** 对象:  StoredProcedure [dbo].[UpdateAssessActivityEmployeeVisible]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE UpdateAssessActivityEmployeeVisible
(
	    @PKID INT,
		@IfEmployeeVisible int = 0
)
AS
Begin
          SET NOCOUNT OFF
          Update TAssessActivity 
          Set IfEmployeeVisible = @IfEmployeeVisible
          Where PKID=@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[DeleteAssessActivityPaperByAssessActivityPaperID]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteAssessActivityPaperByAssessActivityPaperID
(
	    @AssessActivityPaperID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAssessActivityItem
	      WHERE AssessActivityPaperID = @AssessActivityPaperID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityById]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityById
(
        @PKID INT
)
AS
Begin
          SELECT PKID,AssessEmployeeID,AssessCharacter,AssessStatus,ScopeFrom,ScopeTo,
                 PersonalGoal,Reason,AssessProposerName,Intention,HRConfirmerName,
                 PersonalExpectedFinish,ManagerExpectedFinish,PaperName,Score,EmployeeDept,Responsibility,
				 DiyProcess,NextStepIndex,IfEmployeeVisible
          FROM TAssessActivity WHERE PKID=@PKID
          
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[GetAssessActivityItemById]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityItemById
(
        @AssessActivityPaperID INT
)
AS
Begin
          SELECT PKID,AssessActivityPaperID,[Type],Question,Grade,
                 Note,[Option],Classfication,[Description],AssessTemplateItemType,Weight
          FROM TAssessActivityItem WHERE AssessActivityPaperID=@AssessActivityPaperID
		  order by Classfication,pkid
          
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/****** 对象:  StoredProcedure [dbo].[GetAssessActivityItemByAssessActivityPaperId]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityItemByAssessActivityPaperId
(
        @AssessActivityPaperID INT
)
AS
Begin
          SELECT PKID,AssessActivityPaperID,[Type],Question,Grade,
                 Note,[Option],Classfication,[Description],AssessTemplateItemType,Weight
          FROM TAssessActivityItem WHERE AssessActivityPaperID=@AssessActivityPaperID
          order by pkid
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityPaperById]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityPaperById
(
        @AssessActivityID INT
)
AS
Begin
          SELECT *
          FROM TAssessActivityPaper WHERE AssessActivityID=@AssessActivityID
		  ORDER BY StepIndex
          
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[CountOpeningAssessActivityByEmployeeID]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CountOpeningAssessActivityByEmployeeID
(  
    @EmployeeID INT,
	@AssessCharacter int
)
AS
Begin
        Select Counts = count(PKID)
        FROM  TAssessActivity
        WHERE AssessEmployeeID=@EmployeeID
		And (@AssessCharacter=-1 or AssessCharacter=@AssessCharacter)
        AND AssessStatus BETWEEN 0 AND 4
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByEmployee]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityByEmployee
(  
    @EmployeeID INT
)
AS
Begin
        Select PKID
        FROM  TAssessActivity
        WHERE AssessEmployeeID=@EmployeeID
              ORDER BY PKID DESC
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByEmployeeStatus]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityByEmployeeStatus
(  
    @EmployeeID INT,
    @AssessStatus INT 
)
AS
Begin
        Select  PKID,AssessEmployeeID,AssessCharacter,AssessStatus,ScopeFrom,ScopeTo,
                 PersonalGoal,Reason,AssessProposerName,Intention,HRConfirmerName,
                 PersonalExpectedFinish,ManagerExpectedFinish,PaperName,Score,EmployeeDept,Responsibility,
				 DiyProcess,NextStepIndex,IfEmployeeVisible
        FROM  TAssessActivity
        WHERE (@EmployeeID=-1 or AssessEmployeeID=@EmployeeID)
        AND AssessStatus=@AssessStatus
        ORDER BY PKID DESC

End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityByCondition
(
     --@EmployeeName Nvarchar(50),
     @AssessCharacter     INT,
     @AssessStatus     INT,
     @HRSubmitTimeFrom DateTime,
     @HRSubmitTimeTo DateTime,
	 @FinishStatus       int,
	 @ScopeFrom DateTime,
	 @ScopeTo DateTime
)
AS
Begin
	SELECT A.[PKID],A.AssessCharacter,A.AssessStatus,
		A.ScopeFrom,A.ScopeTo,A.AssessProposerName,A.HRConfirmerName,
		A.PersonalExpectedFinish,A.ManagerExpectedFinish,
		A.Score,A.EmployeeDept,A.DiyProcess,A.NextStepIndex,A.IfEmployeeVisible
	FROM TAssessActivity A 
	WHERE
         A.PKID in (
				SELECT distinct AssessActivityID FROM TAssessActivityPaper C
				WHERE   (@HRSubmitTimeFrom IS NULL 
						OR DATEDIFF(dd, @HRSubmitTimeFrom, C.SubmitTime) >=0)
					AND (@HRSubmitTimeTo IS NULL 
						OR DATEDIFF(dd, C.SubmitTime, @HRSubmitTimeTo) >=0)
					)
        AND (@AssessCharacter=-1 OR A.AssessCharacter=@AssessCharacter)
		AND(@AssessStatus=-1 OR A.AssessStatus=@AssessStatus )
          and (@FinishStatus=-1 
				or (@FinishStatus = 0 and A.AssessStatus not in (6,7))--结束；中断
				or (@FinishStatus = 1 and A.AssessStatus in (6,7))
			   )
          and (@ScopeFrom is null or datediff(dd, @ScopeFrom, A.ScopeFrom) >=0)
          and (@ScopeTo is null or datediff(dd, A.ScopeTo, @ScopeTo) >=0)          
		 
	ORDER BY A.PKID DESC 
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAnnualAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE [GetAnnualAssessActivityByCondition]
(
     --@EmployeeName Nvarchar(50),
     @AssessCharacter     INT,
     @AssessStatus     INT,
     @HRSubmitTimeFrom DateTime,
     @HRSubmitTimeTo DateTime,
	 @FinishStatus       int,
	 @ScopeFrom DateTime,
	 @ScopeTo DateTime
)
AS
Begin
	SELECT A.[PKID],A.AssessCharacter,A.AssessStatus,
		A.ScopeFrom,A.ScopeTo,A.AssessProposerName,A.HRConfirmerName,
		A.PersonalExpectedFinish,A.ManagerExpectedFinish,
		A.Score,A.EmployeeDept,A.DiyProcess,A.NextStepIndex,A.IfEmployeeVisible
	FROM TAssessActivity A 
	WHERE
         A.PKID in (
				SELECT distinct AssessActivityID FROM TAssessActivityPaper C
				WHERE   (@HRSubmitTimeFrom IS NULL 
						OR DATEDIFF(dd, @HRSubmitTimeFrom, C.SubmitTime) >=0)
					AND (@HRSubmitTimeTo IS NULL 
						OR DATEDIFF(dd, C.SubmitTime, @HRSubmitTimeTo) >=0)
					)
        AND (@AssessCharacter=-1 OR A.AssessCharacter=@AssessCharacter)
		AND(@AssessStatus=-1 OR A.AssessStatus=@AssessStatus )
          and (@FinishStatus=-1 
				or (@FinishStatus = 0 and A.AssessStatus not in (6,7))--结束；中断
				or (@FinishStatus = 1 and A.AssessStatus in (6,7))
			   )
          and (@ScopeFrom is null or datediff(dd, @ScopeFrom, A.ScopeFrom) >=0)
          and (@ScopeTo is null or datediff(dd, A.ScopeTo, @ScopeTo) >=0) 
		and (A.AssessCharacter=8)         
		 
	ORDER BY A.PKID DESC 
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetContractAssessActivityByCondition]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE [GetContractAssessActivityByCondition]
(
     --@EmployeeName Nvarchar(50),
     @AssessCharacter     INT,
     @AssessStatus     INT,
     @HRSubmitTimeFrom DateTime,
     @HRSubmitTimeTo DateTime,
	 @FinishStatus       int,
	 @ScopeFrom DateTime,
	 @ScopeTo DateTime
)
AS
Begin
	SELECT A.[PKID],A.AssessCharacter,A.AssessStatus,
		A.ScopeFrom,A.ScopeTo,A.AssessProposerName,A.HRConfirmerName,
		A.PersonalExpectedFinish,A.ManagerExpectedFinish,
		A.Score,A.EmployeeDept,A.DiyProcess,A.NextStepIndex,A.IfEmployeeVisible
	FROM TAssessActivity A 
	WHERE
         A.PKID in (
				SELECT distinct AssessActivityID FROM TAssessActivityPaper C
				WHERE   (@HRSubmitTimeFrom IS NULL 
						OR DATEDIFF(dd, @HRSubmitTimeFrom, C.SubmitTime) >=0)
					AND (@HRSubmitTimeTo IS NULL 
						OR DATEDIFF(dd, C.SubmitTime, @HRSubmitTimeTo) >=0)
					)
        AND (@AssessCharacter=-1 OR A.AssessCharacter=@AssessCharacter)
		AND(@AssessStatus=-1 OR A.AssessStatus=@AssessStatus )
          and (@FinishStatus=-1 
				or (@FinishStatus = 0 and A.AssessStatus not in (6,7))--结束；中断
				or (@FinishStatus = 1 and A.AssessStatus in (6,7))
			   )
          and (@ScopeFrom is null or datediff(dd, @ScopeFrom, A.ScopeFrom) >=0)
          and (@ScopeTo is null or datediff(dd, A.ScopeTo, @ScopeTo) >=0) 
		and (A.AssessCharacter<>8)         
		 
	ORDER BY A.PKID DESC 
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** 对象:  StoredProcedure [dbo].[GetAssessActivityByManagerName]    脚本日期: 04/16/2009 12:54:47 ******/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessActivityByManagerName
(  
    @FillPerson Nvarchar(50)
)
AS
Begin
        Select distinct TAssessActivity.PKID
        FROM  TAssessActivity,TAssessActivityPaper
        WHERE 
		(TAssessActivityPaper.FillPerson=@FillPerson and TAssessActivityPaper.[Type]=2
		or
		TAssessActivity.AssessProposerName=@FillPerson)
        and TAssessActivity.PKID=TAssessActivityPaper.AssessActivityID
              order by TAssessActivity.PKID DESC
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
CREATE PROCEDURE GetAssessActivityHistoryByEmployeeName

(  
    @FillPerson Nvarchar(50)
)
AS
Begin
        Select distinct TAssessActivity.PKID
        FROM  TAssessActivity,TAssessActivityPaper
        WHERE 
		((TAssessActivityPaper.FillPerson=@FillPerson and TAssessActivityPaper.[Type]<>1)
		or
		TAssessActivity.AssessProposerName=@FillPerson)
        and TAssessActivity.PKID=TAssessActivityPaper.AssessActivityID
              order by TAssessActivity.PKID DESC
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
CREATE PROCEDURE DeleteAssessActivityByPkid
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAssessActivity
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
CREATE PROCEDURE DeleteActivityPaperByassessActivityID
(
	    @AssessActivityID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TAssessActivityPaper
	      WHERE AssessActivityID = @AssessActivityID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--end               考评活动         ------------



--begin                报销单管理       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE ReimburseInsert
(
@PKID				int OUTPUT,
@EmployeeId			INT,
@DepartmentID			Int,
@ApplyDate			DateTime,
@ReimburseCategoriesEnum	Int,
@PaperCount			Int,
@ConsumeDateFrom		DateTime,
@ConsumeDateTo			DateTime,
@Destinations			Nvarchar(50),
--@CustomerName			Nvarchar(50),
@Project			Nvarchar(50),
@ReimburseStatus		Int,
@TotalCost			Decimal(14,4),
@DepartmentName			Nvarchar(50) ,
@CommitTime			DateTime=null,
@BillingTime			DateTime=null,
@OutCityDays         Decimal(25,2), 
@OutCityAllowance    Decimal(14,2), 
@Remark               Nvarchar(500),
@Discription         Nvarchar(500),
@ExchangeRateID        int
)
AS
Begin
INSERT INTO TReimburse(
EmployeeId,
DepartmentID,
ApplyDate,
ReimburseCategoriesEnum,
PaperCount,
ConsumeDateFrom,
ConsumeDateTo,
Destinations,
--CustomerName,
Project,
ReimburseStatus,
TotalCost,
DepartmentName,
CommitTime,
BillingTime,
OutCityDays,
OutCityAllowance,
Remark,
Discription,
ExchangeRateID
)
VALUES (
@EmployeeId,
@DepartmentID,
@ApplyDate,
@ReimburseCategoriesEnum,
@PaperCount,
@ConsumeDateFrom,
@ConsumeDateTo,
@Destinations,
--@CustomerName,
@Project,
@ReimburseStatus,
@TotalCost,
@DepartmentName,
@CommitTime,
@BillingTime,
@OutCityDays,
@OutCityAllowance,
@Remark,
@Discription,
@ExchangeRateID
)
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
CREATE PROCEDURE ReimburseItemInsert
(
	@PKID			int OUTPUT,
	@ReimburseID		INT,
	@ReimburseType		Int,
	@ConsumePlace		nvarchar(100),
	@ProjectName		nvarchar(50),
    @CustomerID			int,
	@TotalCost		Decimal(14,2),
	@Reason			text,
	@CurrencyType    INT
)
AS
Begin
INSERT INTO TReimburseItem(
	ReimburseID,
	ReimburseType,
	ConsumePlace,
	ProjectName,
    CustomerID,
	TotalCost,
	Reason,
	CurrencyType
)
VALUES (
	@ReimburseID,
	@ReimburseType,
	@ConsumePlace,
	@ProjectName,
    @CustomerID,
	@TotalCost,
	@Reason,
	@CurrencyType
)
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
CREATE PROCEDURE DeleteReimburseItemByReimburseID
(
	    @ReimburseID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TReimburseItem
          where ReimburseID = @ReimburseID
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
CREATE PROCEDURE DeleteReimburseByID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TReimburse
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
CREATE PROCEDURE GetReimburseItemByReimburseID
(
	    @ReimburseID INT
)
AS
Begin
         SELECT a.*,c.Name as ExchangeRateName,c.Rate as ExchangeRate,c.Symbol as ExchangeSymbol
	     FROM TReimburseItem as a with(nolock) inner join TReimburse as b on a.ReimburseID=b.PKID
	     left join TExchangeRate as c  with(nolock) on b.ExchangeRateID=c.PKID
         WHERE ReimburseID = @ReimburseID 
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
CREATE PROCEDURE GetReimburseFlowByReimburseID
(
	    @ReimburseID INT
)
AS
Begin
         SELECT * 
	     FROM TReimburseFlow
         WHERE ReimburseID = @ReimburseID 
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
CREATE PROCEDURE DeleteReimburseFlowByReimburseID
(
	    @ReimburseID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TReimburseFlow
          where ReimburseID = @ReimburseID
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
CREATE PROCEDURE ReimburseFlowInsert
(
    @PKID int OUTPUT,
@ReimburseID         INT,
@OperatorID		 Int,
@ReimburseStatus		int,
@OperationTime		DateTime
)
AS
Begin
    INSERT INTO TReimburseFlow(
ReimburseID,
OperatorID,
ReimburseStatus,
OperationTime
)
    VALUES (
@ReimburseID,
@OperatorID,
@ReimburseStatus,
@OperationTime
)
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
CREATE PROCEDURE GetReimburseByEmployeeID
(
	    @EmployeeId INT
)
AS
Begin 
         SELECT a.*,b.Name as ExchangeRateName,b.Symbol as ExchangeSymbol,b.Rate as ExchangeRate
	     FROM TReimburse as a left join TExchangeRate as b on a.ExchangeRateID=b.PKID
         WHERE EmployeeId = @EmployeeId 
		order by ApplyDate desc,pkid desc
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
CREATE PROCEDURE DeleteReimburseByEmployeeID
(
	    @EmployeeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TReimburse
          where EmployeeID = @EmployeeID
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
CREATE PROCEDURE GetReimburseByCondition
(
     @DepartmentID     INT,
     @ReimburseStatus     INT,
     @ReimburseCategoriesEnum     INT,
     @ApplyDateFrom DateTime,
     @ApplyDateTo DateTime,
     @TotalCostFrom Decimal(14,2),
     @TotalCostTo Decimal(14,2),
     @BillingTimeFrom        DateTime,
     @BillingTimeTo        DateTime,
     @CompanyID            INT,
	 @FinishStatus       int
)
AS
Begin
          SELECT *
          from TReimburse
          WHERE 
		  (@DepartmentID=-1 or DepartmentID=@DepartmentID )
		  and (@ReimburseStatus=-1 or ReimburseStatus=@ReimburseStatus )
		  and (@ReimburseCategoriesEnum=-1 or ReimburseCategoriesEnum=@ReimburseCategoriesEnum )
          and (@ApplyDateFrom is null or datediff(dd, @ApplyDateFrom, ApplyDate) >=0)
          and (@ApplyDateTo is null or datediff(dd, ApplyDate, @ApplyDateTo) >=0)          
          AND(@TotalCostFrom is null or TotalCost>=@TotalCostFrom )
          AND(@TotalCostTo is null or TotalCost<=@TotalCostTo )
          and ((@BillingTimeFrom is null or datediff(dd, @BillingTimeFrom, TReimburse.BillingTime) >=0)
		  and (@BillingTimeTo is null or datediff(dd, TReimburse.BillingTime, @BillingTimeTo) >=0))
          and (@CompanyID=-1 or TReimburse.EmployeeId in (select AccountID from TEmployee where CompanyID=@CompanyID) ) 
          and (@FinishStatus=-1 
				or (@FinishStatus = 0 and Reimbursestatus not in (2))
				or (@FinishStatus = 1 and Reimbursestatus in (2))
			   ) 
          order By TReimburse.ApplyDate desc 

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
CREATE PROCEDURE GetCustomerCountByReiburseID
(
	@ReimburseID		INT
)
AS
Begin
select countId=count(distinct(customerid)) from dbo.TReimburseItem where reimburseid =@ReimburseID
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
CREATE PROCEDURE GetReiburseTotalByCondition
(
	@ReimburseStatus		INT,
	@ReimburseCategoriesEnum	INT,
	@CustomerName			Nvarchar(50),
	@Project			Nvarchar(50),
	@Destinations			Nvarchar(50),
	@ApplyDateFrom			DateTime,
	@ApplyDateTo			DateTime,
    @Remark               Nvarchar(500),
    @BillingTimeFrom        DateTime,
    @BillingTimeTo        DateTime,
    @CompanyID            INT
)
AS
Begin
         SELECT TReimburse.PKID AS ReimburseId,TReimburse.ApplyDate,TReimburse.EmployeeId,TReimburse.ConsumeDateFrom, TReimburse.ConsumeDateTo,TReimburse.PaperCount,TReimburse.ReimburseCategoriesEnum,TReimburse.OutCityAllowance,TReimburse.Remark,TReimburse.Discription,
           TReimburse.BillingTime,TReimburse.Destinations,TReimburse.Project,TReimburse.OutCityDays,
              TReimburseItem.PKID AS ReimburseItemId,TReimburseItem.ReimburseType,TReimburseItem.ConsumePlace,TReimburseItem.TotalCost,TReimburseItem.ProjectName,TReimburseItem.Reason,TReimburseItem.CustomerID,TReimburseItem.CurrencyType,TExchangeRate.Name as ExchangeRateName,TExchangeRate.Rate as ExchangeRate,TExchangeRate.Symbol as ExchangeSymbol
          from TReimburse
          inner join TReimburseItem on TReimburse.PKID=TReimburseItem.ReimburseID
          left join TExchangeRate on TExchangeRate.PKID=TReimburse.ExchangeRateID
          WHERE TReimburse.ReimburseStatus=@ReimburseStatus
		and (@ReimburseCategoriesEnum=-1 or TReimburse.ReimburseCategoriesEnum=@ReimburseCategoriesEnum) 
		and TReimburse.Project like '%'+ @Project +'%'
		and TReimburse.Destinations like '%'+ @Destinations +'%'
	    and TReimburse.Remark like '%'+ @Remark +'%'
		and ((@ApplyDateFrom is null or datediff(dd, @ApplyDateFrom, TReimburse.ConsumeDateTo) >=0)
		and (@ApplyDateTo is null or datediff(dd, TReimburse.ConsumeDateFrom, @ApplyDateTo) >=0))
        and ((@BillingTimeFrom is null or datediff(dd, @BillingTimeFrom, TReimburse.BillingTime) >=0)
		and (@BillingTimeTo is null or datediff(dd, TReimburse.BillingTime, @BillingTimeTo) >=0))
        and (@CustomerName='' or TReimburseItem.CustomerID in (select PKID from TCustomerInfo where TCustomerInfo.CompanyName like '%'+ @CustomerName +'%'))
        and (@CompanyID=-1 or TReimburse.EmployeeId in (select AccountID from TEmployee where CompanyID=@CompanyID) )      
 -- and TReimburseItem.CustomerID=TCustomerInfo.PKID
       -- and TCustomerInfo.CompanyName like '%'+ @CustomerName +'%'
          order By TReimburse.ApplyDate desc 

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
CREATE PROCEDURE GetReiburseByCustomerID
(
	@CustomerID			int
)
AS
Begin
          SELECT COUNT(PKID) as countId
          from TReimburseItem
          WHERE CustomerID=@CustomerID

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
CREATE PROCEDURE GetReimburseByDateTime
(
     @DateTime		DateTime,
     @ReimburseStatus	int
)
AS
Begin
          SELECT TReimburse.*, TExchangeRate.Symbol as ExchangeSymbol
          , TExchangeRate.Name as ExchangeRateName
          , TExchangeRate.Rate as ExchangeRate
          from TReimburse inner join TExchangeRate on TExchangeRate.PKID=ExchangeRateID
          WHERE 
	  CommitTime<=@DateTime
	  And @ReimburseStatus = @ReimburseStatus
          order By TReimburse.ApplyDate desc 

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
CREATE PROCEDURE GetReimburseByEmployeeIDConsumeTime
(
     @EmployeeId    INT,
     @ConsumeDateFrom DateTime,
     @ConsumeDateTo DateTime
)
AS
Begin
          SELECT TReimburse.ApplyDate,
          TReimburse.PKID,
          TReimburseItem.ReimburseType,
	  TReimburse.ConsumeDateFrom,
          TReimburse.ConsumeDateTo,
	  TReimburseItem.ConsumePlace,
          TReimburseItem.TotalCost,
	  TReimburse.PaperCount,
          TReimburseItem.ProjectName,
	  TReimburseItem.Reason,
      TReimburse.ReimburseCategoriesEnum,
      TReimburse.OutCityAllowance,
      TReimburse.Discription
          from TReimburse,TReimburseItem
          WHERE 
		  TReimburse.EmployeeId =@EmployeeId
		  and TReimburse.ReimburseStatus=2
          and TReimburse.pkid=TReimburseItem.ReimburseID
          AND TReimburse.ConsumeDateFrom<=@ConsumeDateTo
          AND TReimburse.ConsumeDateTo>=@ConsumeDateFrom
          order By TReimburseItem.ReimburseType
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
CREATE PROCEDURE GetReimburseByEmployeeIDBillingTime
(
     @EmployeeId    INT,
     @ConsumeDateFrom DateTime,
     @ConsumeDateTo DateTime
)
AS
Begin
          SELECT TReimburse.ApplyDate,
          TReimburse.PKID,
          TReimburseItem.ReimburseType,
	  TReimburse.ConsumeDateFrom,
          TReimburse.ConsumeDateTo,
          TReimburse.BillingTime,
	  TReimburseItem.ConsumePlace,
          TReimburseItem.TotalCost,
	  TReimburse.PaperCount,
          TReimburseItem.ProjectName,
	  TReimburseItem.Reason,
      TReimburse.ReimburseCategoriesEnum,
      TReimburse.OutCityAllowance,
      TExchangeRate.Rate as ExchangeRate
          from TReimburse
          inner join TReimburseItem on  TReimburse.pkid=TReimburseItem.ReimburseID
          inner join TExchangeRate on TReimburseItem.CurrencyType=TExchangeRate.PKID
          WHERE 
		  TReimburse.EmployeeId =@EmployeeId
		  and TReimburse.ReimburseStatus=2
          AND TReimburse.BillingTime<=@ConsumeDateTo
          AND TReimburse.BillingTime>=@ConsumeDateFrom
          order By TReimburseItem.ReimburseType
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
CREATE PROCEDURE GetReimburseByReimburseID
(
	    @PKID INT
)
AS
Begin 
         SELECT a.*,b.Name as ExchangeRateName,b.Symbol as ExchangeSymbol,b.Rate as ExchangeRate
	     FROM TReimburse as a left join TExchangeRate as b on a.ExchangeRateID=b.PKID
         WHERE a.PKID = @PKID 
		order by ApplyDate desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--SET ANSI_NULLS OFF
--GO
--SET QUOTED_IDENTIFIER OFF
--GO
--CREATE PROCEDURE [dbo].[UpdateReimburseNextStepIndex]
--(
--	    @PKID           INT,
--	    @NextStepIndex           INT,
--	    @ReimburseStatus           INT
--)
--AS
--Begin
--         SET NOCOUNT OFF
--         UPDATE [TReimburse]
--         SET
--           [NextStepIndex]=@NextStepIndex,
--           [ReimburseStatus]=@ReimburseStatus
--          WHERE PKID=@PKID
--End
--GO
--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[UpdateReimburseStatus]
(
	    @PKID			INT,
	    @ReimburseCategoriesEnum	INT,
	    @PaperCount			INT,
	    @Destinations		nvarchar(50),
	   -- @CustomerName		nvarchar(50),
	    @Project			nvarchar(50),
	    @ApplyDate		DateTime,
	    @ConsumeDateFrom		DateTime,
	    @ConsumeDateTo		DateTime,
	    @TotalCost			Decimal(14,4),
	    @BillingTime		DateTime=null,
	    @CommitTime			DateTime=null,
	    @ReimburseStatus           INT,
        @OutCityDays Decimal(25,2), 
        @OutCityAllowance decimal(14,2) ,
        @Remark nvarchar(500),
        @ExchangeRateID    int,
        @Discription nvarchar(500)
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE [TReimburse]
         SET
		ApplyDate=@ApplyDate,
		[ReimburseCategoriesEnum]=@ReimburseCategoriesEnum,
		[PaperCount]=@PaperCount,
		[Destinations]=@Destinations,
		--[CustomerName]=@CustomerName,
		[Project]=@Project,
		[ConsumeDateFrom]=@ConsumeDateFrom,
		[ConsumeDateTo]=@ConsumeDateTo,
		[TotalCost]=@TotalCost,
		[BillingTime]=@BillingTime,
		[CommitTime]=@CommitTime,
		[ReimburseStatus]=@ReimburseStatus,
        OutCityDays=@OutCityDays,
        OutCityAllowance=@OutCityAllowance,
        Remark= @Remark,
        ExchangeRateID=@ExchangeRateID,
        Discription=@Discription
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
CREATE PROCEDURE GetMyAuditingReimburses
(
	    @OperatorID INT
)
AS
Begin 
       SELECT  *
	     FROM TReimburse
         WHERE 
         PKID in (select ReimburseID from  TReimburseFlow where OperatorID = @OperatorID 
        and (TReimburseFlow.ReimburseStatus = 4 or TReimburseFlow.ReimburseStatus = 3))
      order by PKID desc
       
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
CREATE PROCEDURE GetReimbursesHistory
(
	    @ReimburseID INT
)
AS
Begin 
         SELECT 
         OperatorID,
         ReimburseStatus,
         OperationTime
	     	 FROM TReimburseFlow
         WHERE TReimburseFlow.ReimburseID = @ReimburseID 
				 order by OperationTime desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--end                报销单管理       -------------

--Begin              自定义流程       -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertDiyProcess
(
    @PKID			 int OUTPUT,
	@Name			 Nvarchar(50),
	@Type			 int,
	@Remark			 Nvarchar(50)
)
AS
Begin
    INSERT INTO TDiyProcess(
	[Name],
	[Type],
	Remark
)
    VALUES (
	@Name,
	@Type,
	@Remark
)
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
CREATE PROCEDURE UpdateDiyProcess
(
    @PKID			 int,
	@Name			 Nvarchar(50),
	@Type			 int,
	@Remark			 Nvarchar(50)
)
AS
Begin
    SET NOCOUNT OFF
    update TDiyProcess
	set	[Name] = @Name,
	[Type] = @Type,
	Remark = @Remark
    where [PKID] = @PKID	
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
CREATE PROCEDURE DiyProcessDelete
(
    @PKID			 int
)
AS
Begin
    delete from TDiyProcess
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
CREATE PROCEDURE InsertDiySteps
(
    @PKID			 int OUTPUT,
	@Status			 Nvarchar(50),
	@OperatorType	 int,
	@OperatorID		 int,
	@DiyProcessID	 int,
	@MailAccount	 Nvarchar(255)
)
AS
Begin
    INSERT INTO TDiyStep(
	[Status],
	OperatorType,
	OperatorID,
	DiyProcessID,
	MailAccount
)
    VALUES (
	@Status,
	@OperatorType,
	@OperatorID,
	@DiyProcessID,
	@MailAccount
)
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
CREATE PROCEDURE DeleteDiyStepByProcessID
(
    @DiyProcessID			 int
)
AS
Begin
    delete from TDiyStep
	where DiyProcessID = @DiyProcessID
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
CREATE PROCEDURE GetDiyProcessByPKID
(
    @PKID			 int
)
AS
Begin
    select * from TDiyProcess
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
CREATE PROCEDURE GetDiyProcessByProcessType
(
    @Type			 int
)
AS
Begin
    select * from TDiyProcess
	where [Type] = @Type
	order by [Name]
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
CREATE PROCEDURE GetDiyProcessByCondition
(
    @Type			 int,
	@Name			 Nvarchar(50)
)
AS
Begin
    select * from TDiyProcess
	where (@Type = -1 or [Type] = @Type)
	  and ([Name] like '%'+ @Name +'%')
	order by [Name]
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
CREATE PROCEDURE GetDiyStepByDiyProcessID
(
    @DiyProcessID			 int
)
AS
Begin
    select * from TDiyStep
	where DiyProcessID = @DiyProcessID
    order by TDiyStep.Pkid
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
CREATE PROCEDURE InsertEmployeeDiyProcess
(
    @PKID			 int OUTPUT,
	@AccountID		 int,
	@DiyProcessID	 int
)
AS
Begin
    INSERT INTO TEmployeeDiyProcess(
	AccountID,
	DiyProcessID
)
    VALUES (
	@AccountID,
	@DiyProcessID
)
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
CREATE PROCEDURE DeleteEmployeeDiyProcessByAccountIDAndType
(
    @AccountID		int,
    @Type			int
)
AS
Begin
    delete from TEmployeeDiyProcess
	where AccountID = @AccountID
	  and DiyProcessID in (select PKID from TDiyProcess where [TYPE] = @Type)
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
CREATE PROCEDURE DeleteEmployeeDiyProcessByAccountID
(
    @AccountID		int
)
AS
Begin
    delete from TEmployeeDiyProcess
	where AccountID = @AccountID
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
CREATE PROCEDURE GetEmployeeDiyProcessByEmployeeIDAndTypeID
(
    @AccountID		int,
    @Type			int
)
AS
Begin
    select * from TEmployeeDiyProcess
	where AccountID = @AccountID
	  and DiyProcessID 
	   in (select PKID from TDiyProcess where [TYPE] = @Type)
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
CREATE PROCEDURE CountDiyProcessByName
(
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TDiyProcess
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
CREATE PROCEDURE CountDiyProcessByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(50)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TDiyProcess
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
CREATE PROCEDURE CountAccountByDiyProcessID
(
	    @DiyProcessID INT
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TEmployeeDiyProcess
	      WHERE DiyProcessID = @DiyProcessID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End                自定义流程       -------------

--begin                班别       -------------

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[InsertDutyClass]
(
	    @PKID           INT out,
        @DutyClassName        Nvarchar(50),
        @FirstStartFromTime   DateTime, 
        @FirstStartToTime   DateTime, 
        @FirstEndTime     DateTime,  
        @SecondStartTime        DateTime,
        @SecondEndTime  DateTime,
        @AllLimitTime        Decimal,
        @LateTime  INT, 
        @EarlyLeaveTime  INT,
        @AbsentLateTime  INT, 
        @AbsentEarlyLeaveTime  INT
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TDutyClass
           (DutyClassName
           ,FirstStartFromTime
           ,FirstStartToTime
           ,FirstEndTime
           ,SecondStartTime
           ,SecondEndTime
           ,AllLimitTime
          ,LateTime 
          ,EarlyLeaveTime
          ,AbsentLateTime
          ,AbsentEarlyLeaveTime  )
     VALUES
           (@DutyClassName,
        @FirstStartFromTime   , 
        @FirstStartToTime   , 
        @FirstEndTime     ,  
        @SecondStartTime  ,
        @SecondEndTime  ,            
        @AllLimitTime,
            @LateTime, 
            @EarlyLeaveTime,
            @AbsentLateTime  , 
            @AbsentEarlyLeaveTime)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdateDutyClass]
(
	    	@PKID           INT,
        @DutyClassName        Nvarchar(50),
        @FirstStartFromTime   DateTime, 
        @FirstStartToTime   DateTime, 
        @FirstEndTime     DateTime,  
        @SecondStartTime        DateTime,
        @SecondEndTime  DateTime,
        @AllLimitTime        Decimal,
        @LateTime  INT, 
        @EarlyLeaveTime  INT,
        @AbsentLateTime  INT, 
        @AbsentEarlyLeaveTime  INT
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE TDutyClass
         SET
          DutyClassName=@DutyClassName
        ,FirstStartFromTime =@FirstStartFromTime
        ,FirstStartToTime =  @FirstStartToTime
        ,FirstEndTime  =@FirstEndTime
        ,SecondStartTime  =@SecondStartTime
        ,SecondEndTime  =@SecondEndTime
         ,AllLimitTime=@AllLimitTime
         ,LateTime=@LateTime
         ,EarlyLeaveTime=@EarlyLeaveTime
         ,AbsentLateTime=@AbsentLateTime
         ,AbsentEarlyLeaveTime=@AbsentEarlyLeaveTime
         WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeleteDutyClass]
(
	    @PKID           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM TDutyClass
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
CREATE PROCEDURE GetDutyClassByCondition
(
	    @PKID           INT,
        @DutyClassName        Nvarchar(50)
)
AS
Begin
          SELECT *
          from TDutyClass
          WHERE DutyClassName like '%'+ @DutyClassName +'%' and (@PKID = -1 or PKID = @PKID)
          order By PKID
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
CREATE PROCEDURE GetDutyClassByPkid
(
	    @PKID           INT
)
AS
Begin
          SELECT *
          from TDutyClass
          WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[CountDutyClassByDutyClassName]
(
        @DutyClassName        Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TDutyClass WHERE DutyClassName =@DutyClassName
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
CREATE PROCEDURE [dbo].[CountDutyClassByDutyClassDiffPkid]
(
	    	@PKID           INT,
        @DutyClassName        Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TDutyClass WHERE (PKID<>@PKID)
        AND (DutyClassName =@DutyClassName)  
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--end                班别       -------------


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[InsertPlanDutyTable]
(
	    	@PKID           INT out,
        @PlanDutyTableName        Nvarchar(50),
        @Period   INT, 
        @FromTime     DateTime,  
        @ToTime        DateTime
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TPlanDutyTable
           (PlanDutyTableName
           ,Period
           ,FromTime
           ,ToTime)
     VALUES
           (@PlanDutyTableName,
            @Period, 
            @FromTime,  
            @ToTime)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdatePlanDutyTable]
(
	    	@PKID           INT,
        @PlanDutyTableName        Nvarchar(50),
        @Period   INT, 
        @FromTime     DateTime,  
        @ToTime        DateTime
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE TPlanDutyTable
         SET
          PlanDutyTableName=@PlanDutyTableName
         ,Period=@Period
         ,FromTime=@FromTime
         ,ToTime=@ToTime
         WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeletePlanDutyTable]
(
	    @PKID           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM TPlanDutyTable
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
CREATE PROCEDURE GetPlanDutyTableByPkid
(
	    @PKID           INT
)
AS
Begin
          SELECT PKID,PlanDutyTableName,Period,FromTime,ToTime
          from TPlanDutyTable
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
CREATE PROCEDURE GetPlanDutyTableByCondition
(
        @PlanDutyTableName        Nvarchar(50),
        @FromTime DateTime,
     		@ToTime DateTime
)
AS
Begin
          SELECT PKID,PlanDutyTableName,Period,
					FromTime,ToTime
          from TPlanDutyTable
          WHERE 
		  		(PlanDutyTableName like '%'+ @PlanDutyTableName +'%' )
				and ((@FromTime is null or datediff(dd, @FromTime, toTime) >=0) and (@ToTime is null or datediff(dd, FromTime, @ToTime) >=0))
          order By PKID desc 
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
CREATE PROCEDURE GetPlanDutyTableByConditionAndAccountID
(
        @AccountID       Int,
        @FromTime DateTime,
     		@ToTime DateTime
)
AS
Begin
          SELECT TPlanDutyTable.PKID,PlanDutyTableName,Period,
					FromTime,ToTime
          from TPlanDutyTable,TPlanDuty
          WHERE 
			 ((@FromTime is null or datediff(dd, @FromTime, toTime) >=0) and (@ToTime is null or datediff(dd, FromTime, @ToTime) >=0))
                and (@AccountID=TPlanDuty.AccountID)
		  		and (TPlanDutyTable.PKID=TPlanDuty.PlanDutyTableID)
          order By PKID desc 
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
CREATE PROCEDURE [dbo].[InsertPlanDutyDetail]
(
	    	@PKID           INT out,
        @PlanDutyTableID        INT,
        @Date   DateTime, 
        @DutyClassID     INT
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TPlanDutyDetail
           (PlanDutyTableID
           ,Date
           ,DutyClassID)
     VALUES
           (@PlanDutyTableID,
            @Date, 
            @DutyClassID)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[UpdatePlanDutyDetail]
(
	    	@PKID           INT,
        @PlanDutyTableID        INT,
        @Date   DateTime, 
        @DutyClassID     INT
)
AS
Begin
         SET NOCOUNT OFF
         UPDATE TPlanDutyDetail
         SET
          PlanDutyTableID=@PlanDutyTableID
         ,Date=@Date
         ,DutyClassID=@DutyClassID
         WHERE PKID=@PKID
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
CREATE PROCEDURE [dbo].[DeletePlanDutyDetailByPlanDutyTableID]
(
	    @PlanDutyTableID           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM TPlanDutyDetail
         WHERE PlanDutyTableID=@PlanDutyTableID
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
CREATE PROCEDURE GetPlanDutyDetailByPlanDutyTableID
(
	    @PlanDutyTableID           INT
)
AS
Begin
          SELECT PKID,PlanDutyTableID,Date,DutyClassID
          from TPlanDutyDetail
          WHERE PlanDutyTableID=@PlanDutyTableID
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
CREATE PROCEDURE GetPlanDutyDetailByCondition
(
        @PlanDutyTableID Int,
        @DateStart DateTime,
     		@DateEnd DateTime,
     		@DutyClassID Int
)
AS
Begin
          SELECT PKID,PlanDutyTableID,Date,DutyClassID
          From TPlanDutyDetail
          WHERE 
		  		(@PlanDutyTableID=PlanDutyTableID)
		  		and (@DutyClassID=DutyClassID)
          and (@DateStart is null or datediff(dd, @DateStart, Date) >=0)
          and (@DateEnd is null or datediff(dd, Date, @DateEnd) >=0)
          order By PKID desc 
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
CREATE PROCEDURE [dbo].[InsertTPlanDuty]
(
	    	@PKID           INT out,
        @PlanDutyTableID        INT,
        @AccountID     INT
)
AS
Begin
         SET NOCOUNT OFF
         INSERT INTO TPlanDuty
           (PlanDutyTableID
           ,AccountID)
     VALUES
           (@PlanDutyTableID,
            @AccountID)
          SELECT @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE [dbo].[DeletePlanDutyByPlanDutyTableID]
(
	    @PlanDutyTableID           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM TPlanDuty
         WHERE PlanDutyTableID=@PlanDutyTableID
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
CREATE PROCEDURE [dbo].[DeletePlanDutyByAccountID]
(
	    @AccountID           INT
)
AS
Begin
         SET NOCOUNT OFF
         DELETE FROM TPlanDuty
         WHERE AccountID=@AccountID
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
CREATE PROCEDURE GetPlanDutyByCondition
(
        @PlanDutyTableName Nvarchar(50),
        @FromTimeStart DateTime,
        @FromTimeEnd DateTime,
        @ToTimeStart DateTime,
        @ToTimeEnd DateTime,
     		@AccountID Int
)
AS
Begin
          SELECT TPlanDutyTable.PKID,PlanDutyTableName,Period,FromTime,ToTime
          From TPlanDuty,TPlanDutyTable
          WHERE 
		  		(@PlanDutyTableName like '%'+ @PlanDutyTableName +'%' )
          and (@FromTimeStart is null or datediff(dd, @FromTimeStart, TPlanDutyTable.FromTime) >=0)
          and (@FromTimeEnd is null or datediff(dd, TPlanDutyTable.FromTime, @FromTimeEnd) >=0)          
          and (@ToTimeStart is null or datediff(dd, @ToTimeStart, TPlanDutyTable.ToTime) >=0)
          and (@ToTimeEnd is null or datediff(dd, TPlanDutyTable.ToTime, @ToTimeEnd) >=0) 
		  		and (@AccountID=TPlanDuty.AccountID)
		  		and (TPlanDutyTable.PKID=TPlanDuty.PlanDutyTableID)
          order By PKID desc 
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
CREATE PROCEDURE GetPlanDutyByPlanDutyTableID
(
     		@PlanDutyTableID Int
)
AS
Begin
          SELECT AccountID
          From TPlanDuty
          WHERE 
					(@PlanDutyTableID=PlanDutyTableID)
          order By PKID desc 
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
CREATE PROCEDURE [dbo].[CountPlanDutyTableByPlanDutyTableName]
(
        @PlanDutyTableName        Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TPlanDutyTable WHERE PlanDutyTableName =@PlanDutyTableName
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
CREATE PROCEDURE [dbo].[CountPlanDutyByPlanDutyDiffPkid]
(
	    	@PKID           INT,
        @PlanDutyTableName        Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TPlanDutyTable WHERE (PKID<>@PKID)
        AND (PlanDutyTableName =@PlanDutyTableName)  
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
CREATE PROCEDURE GetPlanDutyDetailByAccount
(
        @AccountID Int,
        @FromTime DateTime,
        @ToTime DateTime
)
AS
Begin
          SELECT TPlanDutyDetail.DutyClassID as PKID,
          TDutyClass.DutyClassName as DutyClassName,
          TDutyClass.FirstStartFromTime as FirstStartFromTime,
          TDutyClass.FirstStartToTime as FirstStartToTime,
          TDutyClass.FirstEndTime as FirstEndTime,
          TDutyClass.SecondStartTime as SecondStartTime,
          TDutyClass.SecondEndTime as SecondEndTime,
          TDutyClass.AllLimitTime as AllLimitTime,
          TDutyClass.LateTime as LateTime,
          TDutyClass.EarlyLeaveTime as EarlyLeaveTime,
          TDutyClass.AbsentLateTime as AbsentLateTime,
          TDutyClass.AbsentEarlyLeaveTime as AbsentEarlyLeaveTime,

          TPlanDutyDetail.Date as Date
          From TPlanDutyDetail left join TDutyClass on TPlanDutyDetail.DutyClassID=TDutyClass.PKID,TPlanDuty,TPlanDutyTable
          WHERE 
		  		(@FromTime is null or datediff(dd, @FromTime, TPlanDutyDetail.Date) >=0)
          and (@ToTime is null or datediff(dd, TPlanDutyDetail.Date, @ToTime) >=0)  
		  		and (@AccountID=TPlanDuty.AccountID)
		  		and (TPlanDutyTable.PKID=TPlanDuty.PlanDutyTableID)
		  		and (TPlanDutyTable.PKID=TPlanDutyDetail.PlanDutyTableID)	
          order By Date asc
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
CREATE PROCEDURE GetPlanDutyDetailByAccountID
(
        @AccountID Int,
        @FromTime DateTime,
        @ToTime DateTime
)
AS
Begin
          SELECT counts = count(TPlanDutyTable.PKID)
          From TPlanDutyTable,TPlanDuty
          WHERE 
          ((@FromTime is null or datediff(dd, @FromTime, TPlanDutyTable.toTime) >=0) and (@ToTime is null or datediff(dd, TPlanDutyTable.FromTime, @ToTime) >=0))
		  		and (@AccountID=TPlanDuty.AccountID)
		  		and (TPlanDutyTable.PKID=TPlanDuty.PlanDutyTableID)
		  		

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
CREATE PROCEDURE GetPlanDutyDetailByAccountIDAndPlanDutyID
(
        @PlanDutyTableID Int,
        @AccountID Int,
        @FromTime DateTime,
        @ToTime DateTime
)
AS
Begin
          SELECT counts = count(TPlanDutyTable.PKID)
          From TPlanDutyTable,TPlanDuty
          WHERE 
          ((@FromTime is null or datediff(dd, @FromTime, TPlanDutyTable.toTime) >=0) and (@ToTime is null or datediff(dd, TPlanDutyTable.FromTime, @ToTime) >=0))
		  		and (@AccountID=TPlanDuty.AccountID)
		  		and (TPlanDutyTable.PKID=TPlanDuty.PlanDutyTableID)
		  		and (TPlanDutyTable.PKID<>@PlanDutyTableID)
		  		

End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--end                班别       -------------


--Begin        加班         -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE OverWorkInsert
(
    @PKID                    INT OUTPUT,
    @AccountID		             int,
	@SubmitDate			 datetime,
	@From datetime,
    @To datetime,
    @CostTime decimal(25,2),
    @Reason text,
    @ProjectName NVarChar(250),
    @DiyProcess text
)
AS
BEGIN
    INSERT INTO TOverWork(
		AccountID,
		SubmitDate,
		[From],
        [To] ,
        [CostTime],
        [Reason] ,
        [ProjectName],
        [DiyProcess]
	)
    VALUES (
		@AccountID,
		@SubmitDate,
		@From,
        @To,
        @CostTime,
        @Reason,
        @ProjectName,
        @DiyProcess
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
CREATE PROCEDURE InsertOverWorkItem
(
	@PKID int OUTPUT,
	@OverWorkID int,
	@Status int,
	@From datetime,
	@To datetime,
	@CostTime decimal(25, 2),
    @Adjust  int,
    @AdjustHour decimal(25,2),
    @OverWorkType  int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TOverWorkItem([OverWorkID], [Status], [From], [To], [CostTime],Adjust,OverWorkType,AdjustHour)
    values(@OverWorkID, @Status, @From, @To, @CostTime,@Adjust,@OverWorkType,@AdjustHour)
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
CREATE PROCEDURE OverWorkUpdate
(
	@PKID int,
	@AccountID int,
	@SubmitDate datetime,
	@From datetime,
	@To datetime,
	@CostTime decimal(25, 2),
	@Reason text,
	@ProjectName nvarchar(50),
    @DiyProcess text
)
AS
Begin
    SET NOCOUNT OFF
    Update TOverWork
    set
	[AccountID] = @AccountID,
	[SubmitDate] = @SubmitDate,
	[From] = @From,
	[To] = @To,
	[CostTime] = @CostTime,
	[Reason] = @Reason,
	[ProjectName] = @ProjectName,
    [DiyProcess]=@DiyProcess
    where [PKID] = @PKID	
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
CREATE PROCEDURE GetOverWorkByOverWorkID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], [AccountID], [SubmitDate], [From], [To], [CostTime], [Reason], [ProjectName],[DiyProcess]
    from TOverWork
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetAllOverWorkByAccountID
(
	@AccountID int
)
AS
Begin
    SELECT  [PKID], [AccountID], [SubmitDate], [From], [To], [CostTime], [Reason], [ProjectName]
    from TOverWork
	where [AccountID] = @AccountID
    order by [SubmitDate] Desc
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
CREATE PROCEDURE GetOverWorkItemByOverWorkID
(
	@OverWorkID int
)
AS
Begin
    Select  *
    from TOverWorkItem 
	Where 	[OverWorkID] = @OverWorkID
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
CREATE PROCEDURE GetOverWorkItemByItemID
(
	@PKID int
)
AS
Begin
    Select *
    from TOverWorkItem 
	Where 	[PKID] = @PKID
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
CREATE PROCEDURE DeleteOverWorkItemByOverWorkID
(
	@OverWorkID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOverWorkItem
     where [OverWorkID] = @OverWorkID
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
CREATE PROCEDURE OverWorkDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOverWork
     where [PKID] = @PKID
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
CREATE PROCEDURE CountOverWorkInRepeatDateDiffPKID
(
	@AccountID int,
	@From datetime,
	@To datetime,
    @PKID int=null
)
AS
Begin
          SET NOCOUNT OFF
          select counts=count(PKID) from TOverWork where pkid in        
         ( select a.PKID
		  from TOverWork as a left join TOverWorkItem as b on a.PKID=b.OverWorkID
		  where AccountID=@AccountID 
          and (datediff(ss,b.[To],@From)<0 )
          and (datediff(ss,@To,b.[From])<0 )
          and  Status not in (2,6) 
          and  (@PKID is null or a.PKID=-1 or a.PKID not in (@PKID) )
          group by a.PKID
           )
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
CREATE PROCEDURE DeleteOverWorkFlowByItemID
(
	@OverWorkItemID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TOverWorkFlow
     where OverWorkItemID = @OverWorkItemID
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
CREATE PROCEDURE GetOverWorkFlowByItemID
(
	@OverWorkItemID int
)
AS
Begin
    Select  [PKID], [OverWorkItemID], [OperatorID], [Operation], [OperationTime], [Remark],Step
    from TOverWorkFlow
	Where 	[OverWorkItemID] = @OverWorkItemID
    order by PKID
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
CREATE PROCEDURE InsertOverWorkFlow
(
	@PKID int OUTPUT,
	@OverWorkItemID int,
	@OperatorID int,
	@Operation int,
	@OperationTime datetime,
	@Remark text,
    @Step int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TOverWorkFlow([OverWorkItemID], [OperatorID], [Operation], [OperationTime], [Remark],Step)
    values(@OverWorkItemID, @OperatorID, @Operation, @OperationTime, @Remark,@Step)
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
CREATE PROCEDURE UpdateOverWorkItemAdjustByItemID
(
	@PKID int,
    @Adjust int,
    @AdjustHour decimal(25,2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TOverWorkItem
    set	[Adjust]=@Adjust,AdjustHour=@AdjustHour
    where [PKID] = @PKID	
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
CREATE PROCEDURE UpdateOverWorkItemStatusByItemID
(
	@PKID int,
	@Status int
)
AS
Begin
    SET NOCOUNT OFF
    Update TOverWorkItem
    set	[Status] = @Status
    where [PKID] = @PKID	
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
CREATE PROCEDURE GetNeedConfirmOverWork
AS
Begin
          SET NOCOUNT OFF
          select TOverWork.* 
		  from TOverWork
		  where PKID in 
          (
          select OverWorkID from TOverWorkItem where Status in (1,4,7,8)
          )

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
CREATE PROCEDURE GetOverWorkConfirmHistroy
(
	@OperatorID int,
    @From DateTime,
    @To DateTime
)
AS
Begin
          SET NOCOUNT OFF
         select * from dbo.TOverWork
where pkid in 
(select OverWorkID from TOverWorkItem where pkid in 
(select OverWorkItemID from TOverWorkFlow where OperatorID=@OperatorID and Operation in(2,3,5,6,7,8)))
 and (@To='2900-12-31' or datediff(dd,[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,[To])>=0)
order by pkid desc
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
CREATE PROCEDURE GetOverWorkForCalendar
(
    @AccountID int,
    @From DateTime,
    @To DateTime
)
AS
Begin
select * from TOverWorkItem as a left join TOverWork as b on a.OverWorkID=b.PKID
where AccountID=@AccountID  
and (@To='2900-12-31' or datediff(dd,a.[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,a.[To])>=0)
and (a.Status in (3,4,5,8))
order by b.AccountID Asc
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
CREATE PROCEDURE GetAllOverWorkForCalendar
(
    @AccountID int,
    @From DateTime,
    @To DateTime
)
AS
Begin
select b.*
, a.PKID as TOverWorkItemPKID
, a.OverWorkID as TOverWorkItemOverWorkID
, a.Status as TOverWorkItemStatus
, a.[From] as TOverWorkItemFrom
, a.[To] as TOverWorkItemTo
, a.CostTime as TOverWorkItemCostTime
, a.OverWorkType as TOverWorkItemOverWorkType
, a.Adjust as TOverWorkItemAdjust
, a.AdjustHour as TOverWorkItemAdjustHour

from TOverWorkItem as a left join TOverWork as b on a.OverWorkID=b.PKID
where AccountID=@AccountID  
and (@To='2900-12-31' or datediff(dd,a.[From],@To)>=0)
and (@From='1900-1-1' or datediff(dd,@From,a.[To])>=0)
and (a.Status in (0,1,3,4,5,7,8))
order by b.AccountID Asc
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
CREATE PROCEDURE GetOverWorkDetailByEmployee
(
    @Date DateTime,
    @AccountID int
)
AS
Begin
select a.PKID from TOverWork as a left join TOverWorkItem as b on b.OverWorkID=a.PKID
where AccountID=@AccountID  
and (datediff(dd,b.[From],@Date)>=0)
and (datediff(dd,@Date,b.[To])>=0)
and (b.Status in (0,1,3,4,5,7,8))
group by a.PKID
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
CREATE PROCEDURE GetOverWorkByCondition
(
    @AccountID int,
    @From DateTime,
    @To DateTime,
    @Status int
)
AS
Begin
select PKID from TOverWork where 
AccountID=@AccountID
and (datediff(dd,@From,[To])>=0)
and (datediff(dd,[From],@To)>=0)
and PKID in (select OverWorkID from TOverWorkItem where @Status=-1 or Status=@Status) 
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End         加班          -------------


--begin                培训       -------------
--反馈问题，反馈项
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainFBQuesInsert
(
	    @PKID INT out,
        @Name Nvarchar(100),
        @TypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TTrainFBQues([Name],TypeID)
          values(@Name,@TypeID)
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
CREATE PROCEDURE TrainFBQuesUpdate
(
	    @PKID INT,
        @Name Nvarchar(100),
        @TypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Update TTrainFBQues SET 
          [Name]=@Name,
          TypeID=@TypeID
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
CREATE PROCEDURE TrainFBItemInsert
(
	    @PKID INT out,
        @Name Nvarchar(100),
        @QuesID INT,
        @Score  INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TTrainFBItem([Name],QuesID,Score)
          values(@Name,@QuesID,@Score)
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
CREATE PROCEDURE DeleteTrainFBQuesByQuesID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TTrainFBQues
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
CREATE PROCEDURE DeleteTrainFBItemByQuesID
(
	    @QuesID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TTrainFBItem
          where QuesID = @QuesID
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
CREATE PROCEDURE CountFBQuestionByName
(
	    @Name Nvarchar(100)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TTrainFBQues
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
CREATE PROCEDURE CountFBQuestionByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(100)
)
AS
Begin
          SELECT Counts=count(PKID) 
	      FROM TTrainFBQues
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
CREATE PROCEDURE GetTrainFBQuesByQuesID
(
	    @PKID INT
)
AS
Begin
         SELECT TTrainFBQues.PKID,TTrainFBQues.[Name],TTrainFBQues.TypeID,TParameter.Name as TypeName
	     FROM TTrainFBQues,TParameter 
         WHERE TTrainFBQues.PKID = @PKID 
         AND TParameter.PKID=TTrainFBQues.TypeID
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
CREATE PROCEDURE GetTrainFBItemByQuesID
(
	    @QuesID INT
)
AS
Begin
         SELECT PKID,[Name],QuesID,Score
	     FROM TTrainFBItem 
         WHERE QuesID = @QuesID 
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
CREATE PROCEDURE GetTrainFBQuesByCondition
(
     @Name Nvarchar(100),
     @TypeID INT
)
as 
Begin
         SELECT TTrainFBQues.PKID,TTrainFBQues.[Name],TTrainFBQues.TypeID,TParameter.Name as TypeName
	     FROM TTrainFBQues,TParameter 
         WHERE TTrainFBQues.[Name] like '%'+@Name+'%'
         AND (@TypeID=-1 or TTrainFBQues.TypeID=@TypeID)
         AND TParameter.PKID=TTrainFBQues.TypeID
	order by TTrainFBQues.PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--课程
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseDelete
(	 
       @PKID	INT 
)
AS
	SET NOCOUNT OFF
	DELETE FROM TCourse WHERE (PKID=@PKID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseInsert
(	@PKID INT out,
	@CourseName	Nvarchar(200),
	@CoordinatorID	INT,
	@CoordinatorName	Nvarchar(50),
	@Scope	Int,
	@Status	Int,
	@Trainer	Nvarchar(50),
	@ExpectST	DateTime,
	@ExpectET	DateTime,
	@ActualST	DateTime,
	@ActualET	DateTime,
	@ExpectHour	Decimal (25,2),
	@ActualHour	Decimal (25,2),
	@ExpectCost	Decimal (25,2),
	@ActualCost	Decimal (25,2),
    @TrianPlace Nvarchar(200),
	@FBCount	Int,
	@Score	Decimal (25,2),
    @FeedBackPaperId int,
    @HasCertification int
)
AS
	SET NOCOUNT OFF;
	INSERT into TCourse(CourseName,CoordinatorID,CoordinatorName,Scope,Status,Trainer,ExpectST,ExpectET,ActualST,ActualET,ExpectHour,ActualHour,ExpectCost,ActualCost,TrianPlace,FBCount,Score,FeedBackPaperId,HasCertification)
	values(@CourseName,@CoordinatorID,@CoordinatorName,@Scope,@Status,@Trainer,@ExpectST,@ExpectET,@ActualST,@ActualET,@ExpectHour,@ActualHour,@ExpectCost,@ActualCost,@TrianPlace,@FBCount,@Score,@FeedBackPaperId,@HasCertification)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseUpdate
(	
	@PKID INT ,
	@CourseName	Nvarchar(200),
	@CoordinatorID	INT,
	@CoordinatorName	Nvarchar(50),
	@Scope	Int,
	@Status	Int,
	@Trainer	Nvarchar(50),
	@ExpectST	DateTime,
	@ExpectET	DateTime,
	@ActualST	DateTime,
	@ActualET	DateTime,
	@ExpectHour	Decimal (25,2),
	@ActualHour	Decimal (25,2),
	@ExpectCost	Decimal (25,2),
	@ActualCost	Decimal (25,2),
    @TrianPlace Nvarchar(200),
	@FBCount	Int,
	@Score	Decimal (25,2),
    @FeedBackPaperId int,
    @HasCertification int
)
AS
Begin
	SET NOCOUNT OFF
	UPDATE  TCourse set
	CourseName=@CourseName,
	CoordinatorID=@CoordinatorID,
	CoordinatorName=@CoordinatorName,
	Scope=@Scope,
	Status=@Status,
	Trainer=@Trainer,
	ExpectST=@ExpectST,
	ExpectET=@ExpectET,
	ActualST=@ActualST,
	ActualET=@ActualET,
	ExpectHour=@ExpectHour,
	ActualHour=@ActualHour,
	ExpectCost=@ExpectCost,
	ActualCost=@ActualCost,
    TrianPlace=@TrianPlace,
	FBCount=@FBCount,
	Score=@Score,
    FeedBackPaperId=@FeedBackPaperId,
    HasCertification=@HasCertification 
	Where PKID =@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--课程反馈

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseFBDelete
(	
    @CourseID	INT 
)
as 
Begin
	SET NOCOUNT OFF;
	DELETE FROM TCourseFB WHERE (CourseID=@CourseId)
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
CREATE PROCEDURE CourseFBInsert
(	
    @PKID	INT out,
	@CourseID	INT,
	@FBQues	NVARCHAR(200),
	@FBItems	NVARCHAR(2000),
	@FBItemsScore	NVARCHAR(50)
)
AS
	SET NOCOUNT OFF;
	INSERT into TCourseFB(CourseID,FBQues,FBItems,FBItemsScore)
	values(@CourseID,@FBQues,@FBItems,@FBItemsScore)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--课程反馈结果

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseFBResultDelete
(	 
       @CourseID	INT 
)
AS
	SET NOCOUNT OFF;
	DELETE FROM TCourseFBResult WHERE (CourseID=@CourseID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseFBResultInsert
(	
    @PKID	INT out,
	@CourseID	INT,
	@CourseFBID	INT,
	@TraineeID	INT,
	@TraineeName  Nvarchar(50),
	@Score	INT

)
AS
	SET NOCOUNT OFF;
	INSERT into TCourseFBResult(CourseID,CourseFBID,TraineeID,TraineeName,Score)
	values(@CourseID,@CourseFBID,@TraineeID,@TraineeName,@Score)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--课程技能
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseSkillDelete
(	 
     @CourseID	INT 
)
AS
	SET NOCOUNT OFF;
	DELETE FROM TCourseSkill WHERE (CourseID=@CourseID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseSkillInsert
(	
    @PKID	INT out,
	@CourseID	INT,
	@SkillID	INT,
	@CourseName	Nvarchar(200),
	@SkillName	Nvarchar(100) 
)
AS
	SET NOCOUNT OFF;
	INSERT into TCourseSkill(CourseID,CourseName,SkillID,SkillName)
	values(@CourseID,@CourseName,@SkillID,@SkillName)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetTrainCourseBySkillID
(
     @SkillID INT
)
as 
Begin
         SELECT Counts=count(CourseID)
	     FROM  TCourseSkill
         WHERE TCourseSkill.SkillID=@SkillID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---课程相关培训人

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseTraineeDelete
(	
     @CourseID	INT 
)
AS
	SET NOCOUNT OFF;
	DELETE FROM TCourseTrainee WHERE (CourseID=@CourseID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CourseTraineeInsert
(	
    @PKID	INT out,
	@CourseID INT,
	@CourseName Nvarchar(200),
	@TraineeID	INT,
	@TraineeName	Nvarchar(50),
	@FBTime	DateTime,
	@Status  INT,
	@Score Decimal,
	@Suggestion Text,
    @CertificationName	  Nvarchar(50)
)
AS
	SET NOCOUNT OFF;
	INSERT into TCourseTrainee(CourseID,CourseName,TraineeID,TraineeName,FBTime,[Status],Score,Suggestion,CertificationName)
	values(@CourseID,@CourseName,@TraineeID,@TraineeName,@FBTime,@Status,@Score,@Suggestion,@CertificationName)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--course get
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseByCondition
(     
    @CourseName Nvarchar(200),
	@CoordinatorName nvarchar(50),
	@Trainer Nvarchar(50),
	@SkillName Nvarchar(100),
	@TraineeName Nvarchar(50),
	@Scope INT,
	@Status INT,
	@ExpectST DateTime,
	@ExpectET DateTime,
	@ActualST DateTime,
	@ActualET DateTime,
	@FromExpectCost Decimal(25,2),
	@ToExpectCost Decimal(25,2),
	@FromActualCost Decimal(25,2),
	@ToActualCost Decimal(25,2)
)AS
begin 
        SET NOCOUNT ON
        select distinct TCourse.PKID, TCourse.CourseName,CoordinatorID,CoordinatorName, TCourse.Scope, TCourse.Status, TCourse.Trainer, TCourse.ExpectST, TCourse.ExpectET, TCourse.ActualST, TCourse.ActualET, TCourse.ExpectHour, TCourse.ActualHour, TCourse.ExpectCost, TCourse.ActualCost,TCourse.TrianPlace,TCourse.FBCount, TCourse.Score
        from TCourse , TCourseSkill, TCourseTrainee
        WHERE(TCourse.PKID = TCourseSkill.CourseID)and(TCourse.PKID=TCourseTrainee.CourseID) 
        And  (@CourseName ='' or TCourse.CourseName LIKE '%' +@CourseName + '%')
		and (@CoordinatorName ='' or CoordinatorName LIKE '%' +@CoordinatorName + '%')
		And (@Trainer ='' or Trainer LIKE '%' +@Trainer + '%')
		And (@TraineeName ='' or TCourseTrainee.TraineeName LIKE '%' +@TraineeName + '%' )
		And (@Scope =-1 or Scope = @Scope)
		And (@Status =-1 or TCourse.Status = @Status)
		And (@SkillName ='' or TCourseSkill.SkillName like '%'+@SkillName + '%' )
		and (@ExpectST IS NULL or @ExpectST ='' or datediff(dd, @ExpectST, ExpectST) >=0 )
		and (@ExpectET IS NULL or @ExpectET ='' or datediff(dd, ExpectET, @ExpectET) >=0 )
		and (@ActualST IS NULL or @ActualST ='' or datediff(dd, @ActualST, ActualST) >=0 )
		and (@ActualET IS NULL or @ActualET ='' or datediff(dd, ActualET, @ActualET) >=0 )
		And (@FromExpectCost = -1 or ExpectCost >= @FromExpectCost)
		And (@ToExpectCost = -1 or ExpectCost <= @ToExpectCost)
		And (@FromActualCost = -1 or ActualCost >= @FromActualCost)
		And (@ToActualCost = -1 or ActualCost <= @ToActualCost)
order by TCourse.ActualST desc
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseByPKID
(      
      	@PKID INT
)AS
begin
    SET NOCOUNT OFF
    select *
    from TCourse 
    WHERE (PKID = @PKID )
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseFBByCourseID
(  
      	@CourseID INT
)
AS
begin
    SET NOCOUNT ON
	SELECT * FROM  TCourseFB where (CourseID = @CourseID or @CourseID = -1)
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseFBResultByCourseIDAndTraineeID
(    	
    @CourseID INT,
    @TraineeID INT
)
AS
begin
    SET NOCOUNT ON
	SELECT * FROM  TCourseFBResult 
    where (CourseID = @CourseID or @CourseID = -1)
    and (TraineeID = @TraineeID or @TraineeID=-1)
	order by PKID
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseSkillByCourseID
(      
      	@CourseID int
)AS
begin
    SET NOCOUNT ON
	SELECT * FROM  TCourseSkill where CourseID = @CourseID 
	order by PKID
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseTraineeByCourseID
( 
      	@CourseID INT
)AS
begin
   SET NOCOUNT ON
	SELECT * FROM  TCourseTrainee where (CourseID=@CourseID or @CourseID = -1)
	ORDER BY PKID
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCourseTraineeByCondition
(       
	@TraineeID    int,
    @CourseID   int,
	@CourseName	  Nvarchar(200),
	@TraineeName  Nvarchar(50),
    @Status int,
	@StartTime   DateTime,
	@EndTime    DateTime

)AS
begin 
  SET NOCOUNT ON
     select TCourseTrainee.PKID,CourseID,TCourse.CourseName,TCourse.ExpectST,TCourse.ExpectET,TraineeID,TraineeName,FBTime,TCourseTrainee.[Status],TCourseTrainee.Score,Suggestion,CertificationName
     from TCourseTrainee,TCourse
     WHERE (@CourseName ='' or TCourseTrainee.CourseName LIKE '%' +@CourseName + '%')
     and (@TraineeID = -1 or TraineeID = @TraineeID)	
     and (@CourseID = -1 or CourseID = @CourseID)	
     and (@Status = -1 or TCourseTrainee.[Status] = @Status)	
     And (@TraineeName ='' or TraineeName LIKE '%' +@TraineeName + '%' )
	 and (datediff(dd,@StartTime ,FBTime ) >=0 or @StartTime=null)
	 and (datediff(dd,FBTime,@EndTime) >=0 or @EndTime=null)
     and TCourse.pkid=TCourseTrainee.CourseID
    order by pkid desc
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--反馈问卷
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE FeedBackPaperInsert
(
	    @PKID INT out,
        @PaperName Nvarchar(50)
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TFeedBackPaper(PaperName)
          values(@PaperName)
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
CREATE PROCEDURE FeedBackPaperUpdate
(
	    @PKID INT ,
        @PaperName Nvarchar(50),
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          Update TFeedBackPaper 
          Set PaperName=@PaperName 
          Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE DeleteFeedBackPaperByID
(
	    @PKID INT,
        @count INT out
)
AS
Begin
          SET NOCOUNT OFF
          DELETE From TFeedBackPaper Where PKID=@PKID
          Select @count=@@rowcount
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
CREATE PROCEDURE GetFeedBackPaperByPaperId
(      
    @PKID  INT
)
AS
BEGIN	
    select * from TFeedBackPaper
    where PKID=@PKID
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
CREATE PROCEDURE GetQustionItemByPaperId
(      
   @PKID INT
)
AS
BEGIN	
    select TFeedBackPaper.PKID as PaperID,
    TFeedBackPaper.PaperName, TFeedBackPIShip.QuetionItemID as ItemID
    from TFeedBackPaper,TFeedBackPIShip
    where TFeedBackPaper.pkid = TFeedBackPIShip.FeedBackPaperID
    and TFeedBackPaper.pkid=@PKID
 	order by PaperID,ItemID
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetFeedBackPaperByPaperName
(      
    @PaperName  Nvarchar(50)
)
AS
BEGIN	
    SET NOCOUNT ON
	SELECT * FROM TFeedBackPaper 
    WHERE (PaperName like '%'+@PaperName+'%')
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
CREATE PROCEDURE CountFeedBackPaperByPaperName
(  
    @PaperName Nvarchar(50)
)
AS
Begin
        Select Counts = count(PKID)
        FROM TFeedBackPaper 
        WHERE PaperName=@PaperName
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
CREATE PROCEDURE CountFeedBackPaperByPaperNameDiffPKID
(  
    @PKID int,
    @PaperName Nvarchar(50)
)
AS
Begin
        Select counts = count(PKID)
        FROM TFeedBackPaper WHERE (PKID<>@PKID)
        AND (PaperName =@PaperName)    
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
CREATE PROCEDURE FeedBackPIShipInsert
(
	    @PKID INT out,
        @PaperID INT,
        @ItemID INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TFeedBackPIShip (FeedBackPaperID,QuetionItemID)
          values(@PaperID,@ItemID)
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
CREATE PROCEDURE DeleteFeedBackRelation
(
        @PaperID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete From TFeedBackPIShip Where(FeedBackPaperID=@PaperID)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--end                培训       -------------








--Begin                短信业务      -------------



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetNeedConfirmMessage
AS
Begin
          Select *
          From  TPhoneMessage
          where  Status <> 2
          order by PKID Asc
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
CREATE PROCEDURE GetToBeConfirmMessage
AS
Begin
          Select *
          From  TPhoneMessage
          where  Status = 1
          order by PKID Asc
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
CREATE PROCEDURE PhoneMessageUpdate
(
        @PKID       INT,
        @Message    NVarChar (1000),
        @AssessorID INT,
        @AssessorName NVarChar(50),
        @Status     Int,
        @Answer     NVarChar (1000),
        @SendTime   DateTime 
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE TPhoneMessage
		  SET
          [Message]=@Message,
          AssessorID=@AssessorID,
          AssessorName=@AssessorName,
          Status=@Status,
          Answer=@Answer,
          SendTime=@SendTime
          Where PKID=@PKID
End
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE PhoneMessageInsert
(
        @PKID        INT out,
        @RequesterID    INT,
        @RequesterName  NVarChar(50),
        @AssessorID INT,
        @AssessorName NVarChar(50),
        @Status INT,
        @Answer NVarChar (1000),
        @TypeID     INT,
        @Type       INT,
        @Message    NVarChar (1000),
        @InsertTime DateTime
)
AS
BEGIN
          SET NOCOUNT ON
          Insert into TPhoneMessage
           (RequesterID,RequesterName,TypeID,[Type],[Message],[InsertTime],AssessorID,AssessorName,Answer,Status)
          values(@RequesterID,@RequesterName,@TypeID,@Type,@Message,@InsertTime,@AssessorID,@AssessorName,@Answer,@Status)
          select @PKID=SCOPE_IDENTITY()
End
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetPhoneMessageByType
(
        @TypeID     INT,
        @Type       INT
)
AS
Begin
          Select *
          From  TPhoneMessage
          where [Type]=@Type and TypeID=@TypeID
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
CREATE PROCEDURE GetPhoneMessageByPKID
(
        @PKID INT
)
AS
Begin
          Select *
          From  TPhoneMessage
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
CREATE PROCEDURE GetToBeConfirmPhoneMessageByAssessorID
(
        @AssessorID INT
)
AS
Begin
          Select *
          From  TPhoneMessage
          where AssessorID=@AssessorID and Status = 1 
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
CREATE PROCEDURE GetPhoneMessageByCondition
(
        @AssessorID INT,
        @Status INT
)
AS
Begin
          Select *
          From  TPhoneMessage
          where (@AssessorID <=0 or AssessorID=@AssessorID) 
                 and (@Status<0 or  Status = @Status)
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
CREATE PROCEDURE FinishPhoneMessageByPKID
(
        @PKID       INT
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE TPhoneMessage
		  SET
          Status=2
          Where PKID=@PKID
End
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CountToBeConfirmMessageWithSameAssessor
(
        @AssessorID INT
)
AS
Begin
          SELECT [Count]=count(PKID) 
	      FROM TPhoneMessage
	      WHERE AssessorID =@AssessorID
          and Status=1
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
CREATE PROCEDURE PhoneMessageDelete
(
        @PKID       INT
)
AS
BEGIN
          SET NOCOUNT OFF
          Delete from TPhoneMessage
          where PKID = @PKID
End
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End                短信业务      -------------



--Begin             员工档案       -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE FileCargoInsert
(
	@PKID int OUTPUT,
	@AccountID int,
	@FileCargoName nvarchar(50),
	@Remark nvarchar(2000),
	@File nvarchar(250)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TFileCargo([AccountID], [FileCargoName], [Remark], [File])
    values(@AccountID, @FileCargoName, @Remark, @File)
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
CREATE PROCEDURE FileCargoUpdate
(
	@PKID int,
	@AccountID int,
	@FileCargoName nvarchar(50),
	@Remark nvarchar(2000),
	@File nvarchar(250)
)
AS
Begin
    SET NOCOUNT OFF
    Update TFileCargo
    set
	[AccountID] = @AccountID,
	[FileCargoName] = @FileCargoName,
	[Remark] = @Remark,
	[File] = @File
    where [PKID] = @PKID	
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
CREATE PROCEDURE FileCargoDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TFileCargo
     where [PKID] = @PKID
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
CREATE PROCEDURE GetFileCargoByFileCargoID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], [AccountID], [FileCargoName], [Remark], [File]
    from TFileCargo
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetFileCargoByAccountID
(
	@AccountID int
)
AS
Begin
    Select  [PKID], [AccountID], [FileCargoName], [Remark], [File]
    from TFileCargo 
	Where
	[AccountID] = @AccountID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              员工档案        -------------

--begion 培训申请----

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainApplicationDelete
(	 
       @PKID	INT 
)
AS
	SET NOCOUNT OFF
	DELETE FROM TTrainApplication WHERE (PKID=@PKID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainApplicationInsert
(	
    @PKID INT out,
	@CourseName	Nvarchar(200),
	@ApplicationId	INT,
	@StratTime	DateTime,
	@EndTime	DateTime,
	@Skills	Nvarchar(200),
	@TrainOrgnatiaon	Nvarchar(200),
    @TrianPlace Nvarchar(200),
	@TrainHour	Decimal (25,2),
	@TrainCost	Decimal (25,2),
    @EduSpuCost	Decimal (25,2),
	@Trainer	Nvarchar(50),
    @TrainType int,
    @HasCertification int,
    @NextStepIndex int,
    @ApplicationStatus  int,
    @DiyProcess  TEXT
)
AS
	SET NOCOUNT OFF;
	INSERT into TTrainApplication(CourseName,ApplicationId,StratTime,EndTime,Skills,TrainOrgnatiaon,TrianPlace,TrainHour,TrainCost,EduSpuCost,Trainer,TrainType,HasCertification,NextStepIndex,ApplicationStatus,DiyProcess)
	values(@CourseName,@ApplicationId,@StratTime,@EndTime,@Skills,@TrainOrgnatiaon,@TrianPlace,@TrainHour,@TrainCost,@EduSpuCost,@Trainer,@TrainType,@HasCertification,@NextStepIndex,@ApplicationStatus,@DiyProcess)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainApplicationUpdate
(	
    @PKID INT ,
	@CourseName	Nvarchar(200),
	@ApplicationId	INT,
	@StratTime	DateTime,
	@EndTime	DateTime,
	@Skills	Nvarchar(200),
	@TrainOrgnatiaon	Nvarchar(200),
    @TrianPlace Nvarchar(200),
	@TrainHour	Decimal (25,2),
	@TrainCost	Decimal (25,2),
    @EduSpuCost	Decimal (25,2),
	@Trainer	Nvarchar(50),
    @TrainType int,
    @HasCertification int,
    @NextStepIndex int,
    @ApplicationStatus  int,
    @DiyProcess  TEXT
)
AS
Begin
	SET NOCOUNT OFF
	UPDATE  TTrainApplication set
	CourseName=@CourseName,
	ApplicationId=@ApplicationId,
	StratTime=@StratTime,
	EndTime=@EndTime,
	Skills=@Skills,
	TrainOrgnatiaon=@TrainOrgnatiaon,
	TrianPlace=@TrianPlace,
	TrainHour=@TrainHour,
	TrainCost=@TrainCost,
	Trainer=@Trainer,
	TrainType=@TrainType,
    HasCertification=@HasCertification, 
    NextStepIndex=@NextStepIndex,
    ApplicationStatus=@ApplicationStatus,
    DiyProcess=@DiyProcess,
    EduSpuCost=@EduSpuCost
	Where PKID =@PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

---课程相关培训人

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainAppTraineeDelete
(	
     @TrainAppID	INT 
)
AS
	SET NOCOUNT OFF;
	DELETE FROM TTrainAppTrainee WHERE (TrainAppID=@TrainAppID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE TrainAppTraineeInsert
(	
    @PKID	INT out,
	@TrainAppID INT,
	@TraineeID	INT
)
AS
	SET NOCOUNT OFF;
	INSERT into TTrainAppTrainee(TrainAppID,TraineeID)
	values(@TrainAppID,@TraineeID)
	Select @PKID=SCOPE_IDENTITY()
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--course get
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetTrainApplicationByCondition
(     
	@CourseName	Nvarchar(200),
	@Trainer	Nvarchar(50),
	@StratTime	DateTime,
	@EndTime	DateTime,
    @TrainType int,
    @HasCertification int,
    @ApplicationStatus  int
)AS
begin 
        SET NOCOUNT ON
        select *
        from TTrainApplication
        WHERE (@CourseName ='' or CourseName LIKE '%' +@CourseName + '%')
        and (@Trainer ='' or Trainer LIKE '%' +@Trainer + '%')
		and (@StratTime IS NULL or @StratTime ='' or datediff(dd, @StratTime, StratTime) >=0 )
		and (@EndTime IS NULL or @EndTime ='' or datediff(dd, @EndTime, EndTime) <=0 )
		And (@TrainType = -1 or TrainType = @TrainType)
		And (@ApplicationStatus = -1 or ApplicationStatus = @ApplicationStatus)
		And (@HasCertification = -1 or HasCertification = @HasCertification)
        order by pkid 
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetTrainApplicationByPKID
(      
      	@PKID INT
)AS
begin
    SET NOCOUNT OFF
    select *
    from TTrainApplication 
    WHERE (PKID = @PKID )
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetTrainAppTraineeByTrainAppId
(      
	@TrainAppID int
)AS
begin
    SET NOCOUNT OFF
    select 	TrainAppID,TraineeID
    from TTrainAppTrainee 
    WHERE TrainAppID = @TrainAppID
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteTrainAppFlowByTrainAppID
(
	@TrainAppID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TTrainAppFlow
     where TrainAppID = @TrainAppID
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
CREATE PROCEDURE GetTrainAppFlowByTrainAppID
(
	@TrainAppID int
)
AS
Begin
    Select  [PKID], TrainAppID, [OperatorID], [Operation], [OperationTime],Remark
    from TTrainAppFlow
	Where 	TrainAppID = @TrainAppID
    order by PKID
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
CREATE PROCEDURE InsertTrainAppFlow
(
	@PKID int OUTPUT,
	@TrainAppID int,
	@OperatorID int,
	@Operation int,
	@OperationTime datetime,
    @Remark  Nvarchar(200)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TTrainAppFlow(TrainAppID, [OperatorID], [Operation], [OperationTime],Remark)
    values(@TrainAppID, @OperatorID, @Operation, @OperationTime,@Remark)
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
CREATE PROCEDURE UpdateTrainAppStatusByTrainAppID
(
	@PKID int,
    @NextStepIndex           INT,
	@ApplicationStatus int
)
AS
Begin
    SET NOCOUNT OFF
    Update TTrainApplication
    set	ApplicationStatus = @ApplicationStatus,NextStepIndex=@NextStepIndex
    where [PKID] = @PKID	
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
CREATE PROCEDURE GetTrainAppByApplicationId
(
    @ApplicationId int
)
AS
Begin
select *
from TTrainApplication 
where ApplicationId=@ApplicationId  
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
CREATE PROCEDURE GetConfirmingTrainApplication
AS
Begin 
       SELECT  *
	     FROM TTrainApplication
         WHERE  ApplicationStatus in (1,4)
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
CREATE PROCEDURE GetTrainAppConfirmHistoryByOperatorID
(
	    @OperatorID INT
)
AS
Begin
          SET NOCOUNT OFF
         select * 
             from TTrainApplication
		  where  TTrainApplication.PKID in (
				select distinct TrainAppID 
				from TTrainAppFlow
				where (TTrainAppFlow.OperatorID = @OperatorID)
                and  (TTrainAppFlow.Operation = 2 or TTrainAppFlow.Operation = 3 or TTrainAppFlow.Operation = 4))
          order by pkid desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--end 培训申请------


--- start 调休规则 -------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE AdjustRuleInsert
(
	@PKID int OUTPUT,
	@Name nvarchar(200),
	@OverWorkPuTongRate decimal(25, 2),
	@OverWorkJieRiRate decimal(25, 2),
	@OverWorkShuangXiuRate decimal(25, 2),
	@OutCityPuTongRate decimal(25, 2),
	@OutCityJieRiRate decimal(25, 2),
	@OutCityShuangXiuRate decimal(25, 2)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TAdjustRule([Name], [OverWorkPuTongRate], [OverWorkJieRiRate], [OverWorkShuangXiuRate], [OutCityPuTongRate], [OutCityJieRiRate], [OutCityShuangXiuRate])
    values(@Name, @OverWorkPuTongRate, @OverWorkJieRiRate, @OverWorkShuangXiuRate, @OutCityPuTongRate, @OutCityJieRiRate, @OutCityShuangXiuRate)
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
CREATE PROCEDURE AdjustRuleUpdate
(
	@PKID int,
	@Name nvarchar(200),
	@OverWorkPuTongRate decimal(25, 2),
	@OverWorkJieRiRate decimal(25, 2),
	@OverWorkShuangXiuRate decimal(25, 2),
	@OutCityPuTongRate decimal(25, 2),
	@OutCityJieRiRate decimal(25, 2),
	@OutCityShuangXiuRate decimal(25, 2)
)
AS
Begin
    SET NOCOUNT OFF
    Update TAdjustRule
    set
	[Name] = @Name,
	[OverWorkPuTongRate] = @OverWorkPuTongRate,
	[OverWorkJieRiRate] = @OverWorkJieRiRate,
	[OverWorkShuangXiuRate] = @OverWorkShuangXiuRate,
	[OutCityPuTongRate] = @OutCityPuTongRate,
	[OutCityJieRiRate] = @OutCityJieRiRate,
	[OutCityShuangXiuRate] = @OutCityShuangXiuRate
    where [PKID] = @PKID	
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
CREATE PROCEDURE AdjustRuleDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TAdjustRule
     where [PKID] = @PKID
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
CREATE PROCEDURE GetAdjustRuleByAdjustRuleID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], [Name], [OverWorkPuTongRate], [OverWorkJieRiRate], [OverWorkShuangXiuRate], [OutCityPuTongRate], [OutCityJieRiRate], [OutCityShuangXiuRate]
    from TAdjustRule
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetAdjustRuleByNameLike
(
	@Name nvarchar(200)
)
AS
Begin
    Select  [PKID], [Name], [OverWorkPuTongRate], [OverWorkJieRiRate], [OverWorkShuangXiuRate], [OutCityPuTongRate], [OutCityJieRiRate], [OutCityShuangXiuRate]
    from TAdjustRule 
	Where
	Name like '%' +@Name + '%'
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
CREATE PROCEDURE CountAdjustRuleByNameDiffPKID
(
    @PKID int,
	@Name nvarchar(200)
)
AS
Begin
    Select  counts=count(PKID)
    from TAdjustRule 
	Where
	[Name] = @Name and (PKID != @PKID)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--- end   调休规则 -------

--- start   调休规则绑定人 -------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE EmployeeAdjustRuleInsert
(
	@PKID int OUTPUT,
	@AccountID int,
	@AdjustRuleID int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TEmployeeAdjustRule([AccountID], [AdjustRuleID])
    values(@AccountID, @AdjustRuleID)
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
CREATE PROCEDURE UpdateEmployeeAdjustRuleByAccountID
(
	@AccountID int,
	@AdjustRuleID int
)
AS
Begin
    SET NOCOUNT OFF
    Update TEmployeeAdjustRule
    set
	[AdjustRuleID] = @AdjustRuleID
    where AccountID = @AccountID	
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
CREATE PROCEDURE DeleteEmployeeAdjustRuleByAccountID
(
	@AccountID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TEmployeeAdjustRule
     where AccountID = @AccountID
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
CREATE PROCEDURE GetAdjustRuleByAccountID
(
	@AccountID int
)
AS
Begin
     SET NOCOUNT OFF
    Select * from TAdjustRule where pkid in
   ( select AdjustRuleID from TEmployeeAdjustRule where AccountID=@AccountID)
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
CREATE PROCEDURE GetEmployeeAdjustRuleByAdjustRuleID
(
	@AdjustRuleID int
)
AS
Begin
     SET NOCOUNT OFF
    Select * from TEmployeeAdjustRule where AdjustRuleID=@AdjustRuleID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--- end     调休规则绑定人 -------


--Begin             AssessTemplatePaperBindPostion       -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE AssessTemplatePaperBindPostionInsert
(
	@PKID int OUTPUT,
	@PaperID int,
	@PositionID int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TAssessTemplatePaperBindPostion([PaperID], [PositionID])
    values(@PaperID, @PositionID)
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
CREATE PROCEDURE DeleteAssessTemplatePaperBindPostionByPaperID
(
	@PaperID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TAssessTemplatePaperBindPostion
     where PaperID = @PaperID
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
CREATE PROCEDURE GetAssessTemplatePaperBindPostionByPaperID
(
	@PaperID int
)
AS
Begin
    SELECT  [PKID], [PaperID], [PositionID]
    from TAssessTemplatePaperBindPostion
	where 	PaperID = @PaperID

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
CREATE PROCEDURE GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID
(
	@PaperID int,
	@PositionID int
)
AS
Begin
    Select  *
    from TAssessTemplatePaperBindPostion 
	Where
	 [PositionID] = @PositionID
     and [PaperID] <> @PaperID
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
CREATE PROCEDURE GetAssessTemplatePaperBindPostionByPositionID
(
	@PositionID int
)
AS
Begin
    Select  *
    from TAssessTemplatePaperBindPostion 
	Where
	 [PositionID] = @PositionID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End              AssessTemplatePaperBindPostion        -------------


--- start 客户信息 -------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CustomerInfoInsert
(
	@PKID int OUTPUT,
	@CompanyName nvarchar(200)
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TCustomerInfo(CompanyName)
    values(@CompanyName)
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
CREATE PROCEDURE CustomerInfoUpdate
(
	@PKID int,
	@CompanyName nvarchar(200)
)
AS
Begin
    SET NOCOUNT OFF
    Update TCustomerInfo
    set CompanyName = @CompanyName
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
CREATE PROCEDURE CustomerInfoDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TCustomerInfo
     where [PKID] = @PKID
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
CREATE PROCEDURE GetCustomerInfoByPKID
(
	@PKID int
)
AS
Begin
    SELECT  [PKID], CompanyName
    from TCustomerInfo
	where 	[PKID] = @PKID

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
CREATE PROCEDURE GetCustomerIDInfoByName
(
	@CompanyName nvarchar(200)
)
AS
Begin
    SELECT  [PKID], CompanyName
    from TCustomerInfo
	where 	[CompanyName] = @CompanyName

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
CREATE PROCEDURE GetCustomerInfoByNameLike
(
	@CompanyName nvarchar(200)
)
AS
Begin
    Select  [PKID], CompanyName
    from TCustomerInfo 
	Where CompanyName like '%' +@CompanyName + '%'
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
CREATE PROCEDURE CountCustomerInfoByNameDiffPKID
(
    @PKID int,
	@CompanyName nvarchar(200)
)
AS
Begin
    Select  counts=count(PKID)
    from TCustomerInfo 
	Where
	CompanyName = @CompanyName and (PKID != @PKID)
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
CREATE PROCEDURE CountCustomerInfoByCodeDiffPKID
(
    @PKID int,
	@CompanyName nvarchar(200)
)
AS
Begin
    Select  counts=count(PKID)
    from TCustomerInfo 
	Where
	CompanyName like @CompanyName +' %' and (PKID != @PKID)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--- end   客户信息 -------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAssessReadMaxIOTime
AS
Begin
    Select Max(IOTime) as ReadTime
    from dbo.TEmployeeInAndOutRecord
	Where OperateStatus=0
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--Begin             SystemError       -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE SystemErrorInsert
(
	@PKID int OUTPUT,
	@ErrorType int,
	@MarkID int
)
AS
Begin
    SET NOCOUNT OFF
    Insert into TSystemError( [ErrorType], [MarkID])
    values( @ErrorType, @MarkID)
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
CREATE PROCEDURE DeleteSystemErrorByTypeAndMarkID
(
	@ErrorType int,
    @MarkID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TSystemError
     where MarkID=@MarkID and ErrorType = @ErrorType 
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
CREATE PROCEDURE GetSystemErrorByTypeAndMarkID
(
	@ErrorType int,
    @MarkID int
)
AS
Begin
    SELECT  *
    from TSystemError
	where MarkID=@MarkID and ErrorType = @ErrorType 

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
CREATE PROCEDURE GetAllSystemError

AS
Begin
    Select  *
    from TSystemError 
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
CREATE PROCEDURE GetBaseError
as
Begin
    select a.AccountID ,a.DoorCardNo,k.PlanDutyTableID as PlanDutyTableID,d.DiyProcessID as LeaveRequestDiyID ,e.DiyProcessID as OutDiyID,
f.DiyProcessID as OverWorkDiyID,g.DiyProcessID as AssessDiyID,
h.DiyProcessID as HRPrincipalDiyID,i.DiyProcessID as ReimburseDiyID,
j.DiyProcessID as TraineeDiyID 
from (select AccountID, DoorCardNo from Temployee where EmployeeType<>4) as a  left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=0) as d on a.AccountID=d.AccountID  left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=1) as e on a.AccountID=e.AccountID left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=2) as f on a.AccountID=f.AccountID left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=3) as g on a.AccountID=g.AccountID left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=4) as h on a.AccountID=h.AccountID left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=5) as i on a.AccountID=i.AccountID left join 
(select b.AccountID,b.DiyProcessID,c.[Type] from dbo.TEmployeeDiyProcess as b , dbo.TDiyProcess as c 
where b.diyprocessid=c.pkid and c.[type]=6) as j on a.AccountID=j.AccountID left join 
(select a.AccountID ,sum(b.PlanDutyTableID) as PlanDutyTableID from Temployee as a left join TPlanDuty as b on a.AccountID=b.AccountID 
where a.EmployeeType<>4 group by a.AccountID) as k on a.AccountID=k.AccountID 
 order by accountid
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--End              SystemError        -------------


--Begin               职位历史      -------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE PositionHistoryInsert
(
	@PKID INT out,
	@PositionID int,
	@PositionName nvarchar(50),
	@PositionGradeName nvarchar(50),
	@PositionGradeSequence int,
	@PositionDescription	text,
	@Number nvarchar(255),
	@ReviewerID int,
	@ReviewerName nvarchar(50),
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
	@OperatorName nvarchar(50),
	@OperationTime datetime
)
AS
Begin
          SET NOCOUNT OFF
INSERT INTO [dbo].[TPositionHistory] (
	[PositionID],
	[PositionName],
	[PositionGradeName],
	[PositionGradeSequence],
	[PositionDescription],
	[Number],
	[ReviewerID],
	[ReviewerName],
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
	[AuxiliarySkills],
	[OperatorName],
	[OperationTime]
) VALUES (
	@PositionID,
	@PositionName,
	@PositionGradeName,
	@PositionGradeSequence,
	@PositionDescription,
	@Number,
	@ReviewerID,
	@ReviewerName,
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
	@AuxiliarySkills,
	@OperatorName,
	@OperationTime
)
select @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[AddPositionNature]
	@Name nvarchar(255),
	@Description nvarchar(255),
	@PKID int OUTPUT
AS
SET NOCOUNT ON
INSERT INTO [dbo].[TPositionNatureHistory] (
	[Name],
	[Description]
) VALUES (
	@Name,
	@Description
)
SET @PKID = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[InsertPositionNatureRelationship]
	@PKID int OUTPUT,
	@PositionID int,
	@PositionNatureID int
AS
SET NOCOUNT ON
INSERT INTO [TPositionNatureRelationshipHistory](
	PositionID,
	PositionNatureID
) VALUES(
	@PositionID,
	@PositionNatureID
)

SET @PKID = SCOPE_IDENTITY()
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetPositionByPositionIDAndDateTime
(
        @PositionID INT,
        @OperationTime DateTime
)
AS
Begin
          SET NOCOUNT OFF
          select * from TPositionHistory where PositionID=@PositionID 
          and OperationTime in 
          (select max(OperationTime) from TPositionHistory where datediff(dd,OperationTime,@OperationTime)>=0)
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE [dbo].[GetPositionNatureByPositionID]
	@PositionID		int
AS
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SELECT
	[PKID],
	[Name],
	[Description]
FROM
	[dbo].[TPositionNatureHistory]
WHERE PKID IN 
(SELECT PositionNatureID FROM dbo.TPositionNatureRelationshipHistory WHERE PositionID = @PositionID)
GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetPositionByDateTime
(
        @OperationTime DateTime
)
AS
Begin
          SET NOCOUNT OFF
          select *
          from TPositionHistory where  OperationTime in 
          (select max(OperationTime) from TPositionHistory where OperationTime<=@OperationTime)
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
CREATE PROCEDURE PositionHistoryDelete
(
	@PKID int
)
AS
Begin
     SET NOCOUNT OFF
     Delete from TPositionHistory
     where [PKID] = @PKID
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
CREATE PROCEDURE GetPositionHistoryByPKID
(
    @PKID int
)
AS
Begin
SET NOCOUNT OFF
select * from TPositionHistory where PKID = @PKID
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
CREATE PROCEDURE GetPositionHistoryByPositionID
(
    @PositionID	int
)
AS
Begin
SET NOCOUNT OFF
select * from TPositionHistory where PositionID = @PositionID order by pkid desc
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End                 职位历史      -------------