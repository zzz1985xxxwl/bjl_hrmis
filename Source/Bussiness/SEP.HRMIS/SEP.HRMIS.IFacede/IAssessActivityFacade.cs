using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.DiyProcesss;
using System.IO;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 考核活动业务接口
    /// </summary>
    public interface IAssessActivityFacade
    {
        /// <summary>
        /// 根据活动状态的ID，获取相应的考评活动
        /// </summary>
        AssessActivity GetAssessActivityByAssessActivityID(int AssessActivityID);

        /// <summary>
        /// 获取accountId能发起考评申请的所有员工
        /// </summary>
        List<Account> GetAssessActivityForManagerApply(int accountId);

        /// <summary>
        /// 为HR获取可申请考核的员工
        /// </summary>
        List<Account> GetAssessActivityForHRApply(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, Account loginUser);

        /// <summary>
        /// 根据活动状态，获取待EmployeeID处理的考评活动
        /// </summary>
        /// <param name="EmployeeID">有活动等待Employee去处理</param>
        /// <param name="Status">处理的流转状态</param>
        /// <returns></returns>
        //List<AssessActivity> GetAssessActivityByEmployeeStatus(int EmployeeID, AssessStatus Status);

        ///<summary>
        /// 通过当前的员工的Id，获取所有待当前员工填写的考评活动
        ///</summary>
        List<AssessActivity> GetEmployeeFillActivitys(int currentEmployeeId);

        /// <summary>
        /// 通过当前的主管的Id，获取所有待当前主管填写的考评活动
        /// </summary>
        List<AssessActivity> GetManagerFillActivitys(int currentManagerId);

        ///// <summary>
        ///// 通过当前的总监的Id，获取所有待当前总监填写的考评活动
        ///// </summary>
        //List<AssessActivity> GetDirectFillActivitys(int currentDirectId);

        /// <summary>
        /// 通过当前的Ceo的Id，获取所有待当前Ceo填写的考评活动
        /// </summary>
        List<AssessActivity> GetCeoFillActivitys(int currentCeoId);

        /// <summary>
        /// 通过当前的总监的Id，获取所有待当前总监填写的考评活动
        /// </summary>
        List<AssessActivity> GetSummarizeCommmentFillActivitys(int currentDirectId);

        /// <summary>
        /// 条件查询考核活动
        /// </summary>
        List<AssessActivity> GetAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// 条件查询考核活动
        /// </summary>
        List<AssessActivity> GetAnnualAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// 条件查询考核活动
        /// </summary>
        List<AssessActivity> GetContractAssessActivityByCondition(string employeeName,
                                                          AssessCharacterType assessCharacterType, AssessStatus status,
                                                          DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                          int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power);

        /// <summary>
        /// 获取EmployeeID员工参加的所有活动
        /// </summary>
        List<AssessActivity> GetAssessActivityByAccountId(int accountId);

        /// <summary>
        /// 根据主管查找他所有属下的assessActivity
        /// </summary>
        List<AssessActivity> GetAssessActivityByManagerName(string managerName);

        /// <summary>
        /// 查找自己参与过的考评
        /// </summary>
        List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string employeeName);

        /// <summary>
        /// 发起考评
        /// </summary>
        void ManualAssess(AssessActivity assessActivity);

        /// <summary>
        /// 中断考核活动
        /// </summary>
        void InterruptActivity(int assessActivityID);

        /// <summary>
        /// 确认考评
        /// </summary>
        void ConfirmActivityExcute(int activityId, int assessTempletPaperId, DateTime managerExpectedFinish,
                        DateTime personalExpectedTime, string currentEmployeeName);

        /// <summary>
        /// 个人考评项的事务
        /// </summary>
        void FillEmployeeItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                          string intention, bool ifSubmit, string currentEmployeeName);

        /// <summary>
        /// 主管考评项的事务
        /// </summary>
        void FillManagerItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                                    string intention, bool ifSubmit, string currentEmployeeName, decimal? salaryChange);

        /// <summary>
        /// 人事考评项的事务
        /// </summary>
        void FillHRItemsExcute(int activityId, List<AssessActivityItem> answers, string comments,
                               bool ifSubmit, string currentEmployeeName, decimal? salaryNow);

        ///// <summary>
        ///// 总监考评项的事务
        ///// </summary>
        //void FillDirectorCommentExcute(int activityId, string comment, string currentEmployeeName);

        /// <summary>
        /// CEO考评项的事务
        /// </summary>
        void FillCEOCommentExcute(int activityId, string comment, string currentEmployeeName, decimal? salaryChange);

        /// <summary>
        /// CEO考评项的事务
        /// </summary>
        void FillSummarizeCommmentExcute(int activityId, string comment, string currentEmployeeName);

        /// <summary>
        /// 根据自定义流程步骤找出处理人
        /// </summary>
        Account GetDiyStepAccount(int activityAccountId, DiyStep diyStep);


        /// <summary>
        /// 导出主管考评
        /// </summary>
        string ExportLeaderAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// 导出个人考评
        /// </summary>
        string ExportEmployeeSelfAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// 设置员工是否可见
        /// </summary>
        void SetEmployeeVisible(int assessActivityID, bool ifEmployeeVisible);

        /// <summary>
        /// 获得我的绩效考评
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        List<AssessActivity> GetMyAssessActivityByAccountId(int EmployeeID);

        /// <summary>
        /// 导出合同期满评估表
        /// </summary>
        string ExportExportNormalForContractAssessForm(int assessActivityId, string employeeTemplateLocation);
        /// <summary>
        /// 导出员工除年终绩效外的个人工作总结表
        /// </summary>
        string ExportEmployeeNormalSummary(int assessActivityId, string employeeTemplateLocation);

        ///<summary>
        /// 导出员工年终绩效个人工作总结表
        ///</summary>
        string ExportEmployeeAnnualSummary(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// 导出年度员工考核统计表(除年终绩效)
        /// </summary>
        string ExportAnnualAssessForm(int assessActivityId, string employeeTemplateLocation);

        /// <summary>
        /// 导出员工年终绩效考评
        /// </summary>
        MemoryStream ExportAnualAssessListExcel(string employeeTemplateLocation, string employeeName,
                                           DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                           int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                           Account loginuser, int power, AssessStatus assessStatus);

        /// <summary>
        /// 删除考评活动
        /// </summary>
        /// <param name="assessActivityID"></param>
        void DeleteAssessActivity(int assessActivityID);
    }
}
