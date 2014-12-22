using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IReimburseFacade
    {
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="reimburse"></param>
        /// <param name="Employeed"></param>
        void AddReimburse(int Employeed, Reimburse reimburse);

        /// <summary>
        /// �޸ı�����
        /// </summary>
        /// <param name="reimburse"></param>
        /// <param name="Employeed"></param>
        void UpdateReimburse(int Employeed, Reimburse reimburse);

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="reimburseID"></param>
        /// <param name="Employeed"></param>
        void DeleteReimburse(int Employeed, int reimburseID);

        /// <summary>
        /// �ȴ��ı���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimbursingByEmployeeID(int id);

        /// <summary>
        /// �ҵı�����ʷ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimburseHistoryByEmployeeID(int id);

        /// <summary>
        /// �ҵı���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeReimburseByEmployeeID(int id);

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        List<Reimburse> GetReimburseByCondition(Account loginUser, string employeename, int departmentid,
                                                ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                decimal? totalcostfrom,
                                                decimal? totalcostto, DateTime? applydateFrom, DateTime? applydateTo,
                                                DateTime? billtimeFrom, DateTime? billtimeTo, int companyID, int auth, int finishStatus);

        /// <summary>
        /// ��ѯ�ͻ�ά��
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
        /// ��ɱ�����
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int FinishEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        ///// <summary>
        ///// �жϱ�����
        ///// </summary>
        ///// <param name="employeeId"></param>
        ///// <param name="reimburses"></param>
        ///// <param name="curroperator"></param> 
        //int InterruptEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);


        ///// <summary>
        ///// �ȴ���˵ı���
        ///// </summary>
        ///// <param name="loginUser"></param>
        ///// <returns></returns>
        //Employee GetEmployeeReimbursingByLeadID(Account loginUser);

        /// <summary>
        /// �������
        /// </summary>
        void QuickPassReimburses(Account loginUser, int reimburseID, int paperCount, string destinations,
                                 string customerName, string projectName, DateTime consumeDateFrom,
                                 DateTime consumeDateTo,string remark,decimal outcityAllowance,decimal  outcitydays);


        ///// <summary>
        ///// ��ͨ��������
        ///// </summary>
        ///// <param name="loginUser"></param>
        ///// <param name="reimburseID"></param>
        ///// <param name="statusEnum"></param>
        //void InterruptOrCancelReimburses(Account loginUser, int reimburseID, ReimburseStatusEnum statusEnum);

        /// <summary>
        /// ���ұ���
        /// </summary>
        /// <param name="reimburseID"></param>
        Reimburse GetReimburseByPkid(int reimburseID);

        ///// <summary>
        ///// �Ѿ���˵ı���
        ///// </summary>
        ///// <param name="accountID"></param>
        ///// <returns></returns>
        //Employee GetMyAuditingReimburses(int accountID);

        /// <summary>
        /// ���������̼�¼
        /// </summary>
        /// <param name="ReimburseID"></param>
        /// <returns></returns>
        List<ReimburseFlow> GetReimbursesHistory(int ReimburseID);

        ///// <summary>
        ///// �Ƿ���CEOǩ��
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsCEOElectricName(Reimburse reimburse);

        ///// <summary>
        ///// �Ƿ��в���ǩ��
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsFinanceElectricName(Reimburse reimburse);

        ///// <summary>
        ///// �Ƿ��в����쵼ǩ��
        ///// </summary>
        ///// <param name="reimburse"></param>
        ///// <returns></returns>
        //Account IsDepartmentLeaderElectricName(Reimburse reimburse);

        ///<summary>
        /// ����ͳ��
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
        /// ���ô���˵ı�����
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int WaitAuditReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        /// <summary>
        /// �˻ر�����
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="reimburses"></param>
        /// <param name="curroperator"></param> 
        int ReturnEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator);

        /// <summary>
        /// �˻ر�����
        /// </summary>
        /// <param name="reimburseID"></param>
        ///  <param name="curroperator"></param>
        void ReturnOrCancelReimburses(int reimburseID,Employee curroperator);

        /// <summary>
        /// ���ü���ʱ��
        /// </summary>
        /// <param name="reimburseID"></param>
        /// <param name="billingTime"></param>
        ///  <param name="curroperator"></param>
        void SetBillingTime(int reimburseID,DateTime billingTime,Employee curroperator);

        /// <summary>
        /// ��ѯ���ñ���ͳ��
        /// </summary>
        /// <returns></returns>
        List<ReimburseTotal> GetReiburseTotalByCondition(Account loginUser, string employeename, string place, string customerName,
            string projectName, DateTime? applydateFrom, DateTime? applydateTo, string remark, int ReimburseCategoriesId, DateTime? billingTimeFrom,
                                                    DateTime? billingTimeTo, int departmentID,int companyID);


        /// <summary>
        /// ���ݿͻ�ID�����Ƿ��б�����
        /// </summary>
        /// <returns></returns>
        bool GetReiburseByCustomerID(int customerID);

        /// <summary>
        /// �޸ı�����ͻ�
        /// </summary>
        /// <param name="reimburse"></param>
        void UpdateReimburseItemCustomer(Reimburse reimburse);

    }
}
