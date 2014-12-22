using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IReimburseFacade
    {
        /// <summary>
        /// 新增报销单
        /// </summary>
        /// <param name="reimburse"></param>
        /// <param name="Employeed"></param>
        void AddReimburse(int Employeed, Reimburse reimburse);

        /// <summary>
        /// 修改报销单
        /// </summary>
        /// <param name="reimburse"></param>
        /// <param name="Employeed"></param>
        void UpdateReimburse(int Employeed, Reimburse reimburse);

        /// <summary>
        /// 删除报销单
        /// </summary>
        /// <param name="reimburseID"></param>
        /// <param name="Employeed"></param>
        void DeleteReimburse(int Employeed, int reimburseID);

        /// <summary>
        /// 等待的报销
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimbursingByEmployeeID(int id);

        /// <summary>
        /// 我的报销历史
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimburseHistoryByEmployeeID(int id);

        /// <summary>
        /// 我的报销
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimburseByEmployeeID(int id);

        /// <summary>
        /// 查询报销
        /// </summary>
        /// <returns></returns>
        List<Reimburse> GetReimburseByCondition(Account loginUser, string employeename, int departmentid,
                                                ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                decimal? totalcostfrom,
                                                decimal? totalcostto, DateTime? applydateFrom, DateTime? applydateTo,
                                                DateTime? billtimeFrom, DateTime? billtimeTo, int companyID, int auth, int finishStatus);

        /// <summary>
        /// 查询客户维护
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="employeename"></param>
        /// <param name="departmentid"></param>
        /// <param name="statusEnum"></param>
        /// <param name="reimburseCategoriesEnumID"></param>
        /// <param name="totalcostfrom"></param>
        /// <param name="totalcostto"></param>
        /// <param name="applydateFrom"></param>
        /// <param name="applydateTo"></param>
        /// <param name="billtimeFrom"></param>
        /// <param name="billtimeTo"></param>
        /// <param name="companyID"></param>
        /// <param name="auth"></param>
        /// <param name="finishStatus"></param>
        /// <returns></returns>
        /// <param name="isCustomerFilled"></param>
        List<Reimburse> GetReimburseForCustomerByCondition(Account loginUser, string employeename, int departmentid,
                                                           ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                           decimal? totalcostfrom,
                                                           decimal? totalcostto, DateTime? applydateFrom,
                                                           DateTime? applydateTo,
                                                           DateTime? billtimeFrom, DateTime? billtimeTo, int companyID,
                                                           int auth, int finishStatus, int isCustomerFilled);

        /// <summary>
        /// 完成报销单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int FinishEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        ///// <summary>
        ///// 中断报销单
        ///// </summary>
        ///// <param name="employeeId"></param>
        ///// <param name="reimburses"></param>
        ///// <param name="curroperator"></param> 
        //int InterruptEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);


        ///// <summary>
        ///// 等待审核的报销
        ///// </summary>
        ///// <param name="loginUser"></param>
        ///// <returns></returns>
        //Employee GetEmployeeReimbursingByLeadID(Account loginUser);

        /// <summary>
        /// 快速完成
        /// </summary>
        void QuickPassReimburses(Account loginUser, int reimburseID, int paperCount, string destinations,
                                 string customerName, string projectName, DateTime consumeDateFrom,
                                 DateTime consumeDateTo,string remark,decimal outcityAllowance,decimal  outcitydays);


        ///// <summary>
        ///// 不通过报销单
        ///// </summary>
        ///// <param name="loginUser"></param>
        ///// <param name="reimburseID"></param>
        ///// <param name="statusEnum"></param>
        //void InterruptOrCancelReimburses(Account loginUser, int reimburseID, ReimburseStatusEnum statusEnum);

        /// <summary>
        /// 查找报销
        /// </summary>
        /// <param name="reimburseID"></param>
        Reimburse GetReimburseByPkid(int reimburseID);

        ///// <summary>
        ///// 已经审核的报销
        ///// </summary>
        ///// <param name="accountID"></param>
        ///// <returns></returns>
        //Employee GetMyAuditingReimburses(int accountID);

        /// <summary>
        /// 报销的流程记录
        /// </summary>
        /// <param name="ReimburseID"></param>
        /// <returns></returns>
        List<ReimburseFlow> GetReimbursesHistory(int ReimburseID);

        ///// <summary>
        ///// 是否有CEO签名
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsCEOElectricName(Reimburse reimburse);

        ///// <summary>
        ///// 是否有财务签名
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsFinanceElectricName(Reimburse reimburse);

        ///// <summary>
        ///// 是否有部门领导签名
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsDepartmentLeaderElectricName(Reimburse reimburse);

        ///<summary>
        /// 报销统计
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="companyID"></param>
        ///<param name="isIncludeChildDeptMember"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        List<EmployeeReimburseStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,int companyID,
                                                               bool isIncludeChildDeptMember, Account loginUser);

        List<EmployeeReimburseStatistics> EmployeeStatistics(DateTime startDt, DateTime endDt, int departmentID,
                                                             int companyID, string employeeName, Account loginUser);

        /// <summary>
        /// 设置待审核的报销单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int WaitAuditReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        /// <summary>
        /// 退回报销单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int ReturnEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        /// <summary>
        /// 退回报销单
        /// </summary>
        /// <param name="reimburseID"></param>
        ///  <param name="curroperator"></param>
        void ReturnOrCancelReimburses(int reimburseID,Employee curroperator);

        /// <summary>
        /// 设置记账时间
        /// </summary>
        /// <param name="reimburseID"></param>
        /// <param name="billingTime"></param>
        ///  <param name="curroperator"></param>
        void SetBillingTime(int reimburseID,DateTime billingTime,Employee curroperator);

        /// <summary>
        /// 查询差旅报销统计
        /// </summary>
        /// <returns></returns>
        List<ReimburseTotal> GetReiburseTotalByCondition(Account loginUser, string employeename, string place, string customerName,
            string projectName, DateTime? applydateFrom, DateTime? applydateTo, string remark, int ReimburseCategoriesId, DateTime? billingTimeFrom,
                                                    DateTime? billingTimeTo, int departmentID,int companyID);


        /// <summary>
        /// 根据客户ID查找是否有报销单
        /// </summary>
        /// <returns></returns>
        bool GetReiburseByCustomerID(int customerID);

        /// <summary>
        /// 修改报销项客户
        /// </summary>
        /// <param name="reimburse"></param>
        void UpdateReimburseItemCustomer(Reimburse reimburse);

    }
}
