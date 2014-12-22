using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class AssessActivityFacade : IAssessActivityFacade
    {
        #region IAssessActivityFacade 成员

        /// <summary>
        /// 根据活动状态的ID，获取相应的考评活动
        /// </summary>
        public AssessActivity GetAssessActivityByAssessActivityID(int AssessActivityID)
        {
            return new GetAssessActivity().GetAssessActivityByAssessActivityID(AssessActivityID);
        }

        public List<Account> GetAssessActivityForManagerApply(int accountId)
        {
            return new GetAssessActivity().GetAssessActivityForManagerApply(accountId);
        }

        public List<AssessActivity> GetEmployeeFillActivitys(int currentEmployeeId)
        {
            return new GetAssessActivity().GetEmployeeFillActivitys(currentEmployeeId);
        }

        public List<AssessActivity> GetManagerFillActivitys(int currentManagerId)
        {
            return new GetAssessActivity().GetManagerFillActivitys(currentManagerId);
        }

        public List<AssessActivity> GetDirectFillActivitys(int currentDirectId)
        {
            return new GetAssessActivity().GetDirectFillActivitys(currentDirectId);
        }

        public List<AssessActivity> GetCeoFillActivitys(int currentCeoId)
        {
            return new GetAssessActivity().GetCeoFillActivitys(currentCeoId);
        }

        public List<AssessActivity> GetSummarizeCommmentFillActivitys(int currentDirectId)
        {
            return new GetAssessActivity().GetSummarizeCommmentFillActivitys(currentDirectId);
        }

        public List<AssessActivity> GetAssessActivityByCondition(string employeeName,
            AssessCharacterType assessCharacterType, AssessStatus status,
            DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
            int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            return new GetAssessActivity().GetAssessActivityByCondition(employeeName, assessCharacterType, status,
                                                                        hrSubmitTimeFrom, hrSubmitTimeTo,
                                                                        finishStatus, scopeFrom, scopeTo, departmentID,
                                                                        loginuser, power);
        }

        public List<AssessActivity> GetAnnualAssessActivityByCondition(string employeeName,
            AssessCharacterType assessCharacterType, AssessStatus status,
            DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
            int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            return new GetAssessActivity().GetAnnualAssessActivityByCondition(employeeName, assessCharacterType, status,
                                                                        hrSubmitTimeFrom, hrSubmitTimeTo,
                                                                        finishStatus, scopeFrom, scopeTo, departmentID,
                                                                        loginuser, power);
        }

        public List<AssessActivity> GetContractAssessActivityByCondition(string employeeName,
            AssessCharacterType assessCharacterType, AssessStatus status,
            DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
            int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power)
        {
            return new GetAssessActivity().GetContractAssessActivityByCondition(employeeName, assessCharacterType, status,
                                                                        hrSubmitTimeFrom, hrSubmitTimeTo,
                                                                        finishStatus, scopeFrom, scopeTo, departmentID,
                                                                        loginuser, power);
        }

        public List<Account> GetAssessActivityForHRApply(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, Account loginUser)
        {
            return new GetAssessActivity().GetAssessActivityForHRApply( employeeName,
                                                           employeeType,  positionID,
                                                           departmentID,
                                                           recursionDepartment, loginUser);
        }

      

        /// <summary>
        /// 获取员工参加的所有活动
        /// </summary>
        public List<AssessActivity> GetAssessActivityByAccountId(int accountId)
        {
            return new GetAssessActivity().GetAssessActivityByEmployee(accountId);
        }

        /// <summary>
        /// 根据主管查找他所有属下的assessActivity
        /// </summary>
        public List<AssessActivity> GetAssessActivityByManagerName(string managerName)
        {
            return new GetAssessActivity().GetAssessActivityByManagerName(managerName);
        }

        public List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string employeeName)
        {
            return new GetAssessActivity().GetAssessActivityHistoryByEmployeeName(employeeName);
        }

        /// <summary>
        /// 发起考评
        /// </summary>
        public void ManualAssess(AssessActivity assessActivity)
        {
            new ManualAssess(assessActivity).Excute();
        }

        /// <summary>
        /// 中断考核活动
        /// </summary>
        public void InterruptActivity(int assessActivityID)
        {
            new InterruptActivity(assessActivityID).Excute();
        }

        /// <summary>
        /// 确认考评
        /// </summary>
        public void ConfirmActivityExcute(int activityId, int assessTempletPaperId, DateTime managerExpectedFinish,
                        DateTime personalExpectedTime, string currentEmployeeName)
        {
            new ConfirmActivity(activityId, assessTempletPaperId, managerExpectedFinish,
                                personalExpectedTime, currentEmployeeName).Excute();
        }

        /// <summary>
        /// 个人考评项的事务
        /// </summary>
        public void FillEmployeeItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                          string intention, bool ifSubmit, string currentEmployeeName)
        {
            new FillEmployeeItems(activityId, answers, comments,
                                  intention, ifSubmit, currentEmployeeName).Excute();
        }

        /// <summary>
        /// 主管考评项的事务
        /// </summary>
        public void FillManagerItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                                    string intention, bool ifSubmit, string currentEmployeeName,decimal? salaryChange)
        {
            new FillManagerItems(activityId, answers, comments, intention, ifSubmit, currentEmployeeName,salaryChange).Excute();
        }

        /// <summary>
        /// 人事考评项的事务
        /// </summary>
        public void FillHRItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                                    bool ifSubmit, string currentEmployeeName,decimal? salarynow )
        {
            new FillHRItems(activityId, answers, comments, ifSubmit, currentEmployeeName, salarynow).Excute();
        }

        ///// <summary>
        ///// 总监考评项的事务
        ///// </summary>
        //public void FillDirectorCommentExcute(int activityId, string comment, string currentEmployeeName)
        //{
        //    new FillDirectorComment(activityId, comment, currentEmployeeName).Excute();
        //}

        /// <summary>
        /// CEO考评项的事务
        /// </summary>
        public void FillCEOCommentExcute(int activityId, string comment, string currentEmployeeName,decimal? salarychange )
        {
            new FillCEOComment(activityId, comment, currentEmployeeName, salarychange).Excute();
        }

        /// <summary>
        /// CEO考评项的事务
        /// </summary>
        public void FillSummarizeCommmentExcute(int activityId, string comment, string currentEmployeeName)
        {
            new FillSummarizeCommment(activityId, comment, currentEmployeeName).Excute();
        }

        /// <summary>
        /// 根据自定义流程步骤找出处理人
        /// </summary>
        public Account GetDiyStepAccount(int activityAccountId, DiyStep diyStep)
        {
            return new GetAssessActivity().GetDiyStepAccount(activityAccountId, diyStep);
        }

        /// <summary>
        /// 导出主管考评
        /// </summary>
        public string ExportLeaderAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportLeaderAssessForm(assessActivityId, employeeTemplateLocation).ExcuteSelf();
        }

        /// <summary>
        /// 导出个人考评
        /// </summary>
        public string ExportEmployeeSelfAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportEmployeeSelfAssessForm(assessActivityId, employeeTemplateLocation).ExcuteSelf();
        }

        public void SetEmployeeVisible(int assessActivityID, bool ifEmployeeVisible)
        {
            new SetEmployeeVisible(assessActivityID, ifEmployeeVisible).Excute();
        }

        /// <summary>
        /// 获取员工参加的所有活动
        /// </summary>
        public List<AssessActivity> GetMyAssessActivityByAccountId(int accountId)
        {
            return new GetAssessActivity().GetMyAssessActivityByAccountId(accountId);
        }

        public string ExportExportNormalForContractAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportNormalForContract(assessActivityId, employeeTemplateLocation).Excute();
        }

        public string ExportEmployeeNormalSummary(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportEmployeeNormlSummary(assessActivityId, employeeTemplateLocation).Excute();
        }

        public string ExportEmployeeAnnualSummary(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportEmployeeAnnualSummary(assessActivityId, employeeTemplateLocation).Excute();
        }

        public string ExportAnnualAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            return new ExportAnnualAssessForm(assessActivityId, employeeTemplateLocation).Excute();
        }
        public string ExportAnualAssessListExcel(string employeeTemplateLocation, string employeeName, DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                    int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID, Account loginuser, int power, AssessStatus assessStatus)
        {
            return
                new ExportAnualAssessListExcel(employeeTemplateLocation, employeeName, hrSubmitTimeFrom, hrSubmitTimeTo,
                                               finishStatus, scopeFrom, scopeTo, departmentID,
                                                                        loginuser, power, assessStatus).Excute();
        }


        public void DeleteAssessActivity(int assessActivityID)
        {
            new DeleteAssessActivity(assessActivityID).Excute();
        }
        #endregion
    }
}
