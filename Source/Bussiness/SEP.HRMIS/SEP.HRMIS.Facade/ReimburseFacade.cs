using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.Reimburse;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// ReimburseµÄFacade
    /// </summary>
    public class ReimburseFacade : IReimburseFacade
    {

        #region IReimburseFacede ³ÉÔ±

        public void AddReimburse(int Employeed, Reimburse reimburse)
        {
            new AddReimburse(Employeed, reimburse).Excute();
        }

        public void UpdateReimburse(int Employeed ,Reimburse reimburse)
        {
            new UpdateReimburse(Employeed, reimburse).Excute();
        }

        public void DeleteReimburse(int Employeed, int reimburseID)
        {
            new DeleteReimburse(Employeed,reimburseID).Excute();
        }

        public Employee GetEmployeeReimbursingByEmployeeID(int id)
        {
            return new GetReimburse().GetEmployeeReimbursingByEmployeeID(id);
        }

        public Employee GetEmployeeReimburseHistoryByEmployeeID(int id)
        {
            return new GetReimburse().GetEmployeeReimburseHistoryByEmployeeID(id);
        }

        public Employee GetEmployeeReimburseByEmployeeID(int id)
        {
            return new GetReimburse().GetEmployeeReimburseByEmployeeID(id);
        }

        public List<Reimburse> GetReimburseByCondition(Account loginUser, string employeename, int departmentid,
                                                       ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                       decimal? totalcostfrom, decimal? totalcostto,
                                                       DateTime? applydateFrom, DateTime? applydateTo,
                                                       DateTime? billtimeFrom, DateTime? billtimeTo, int companyID,
                                                       int auth,int finishStatus)
        {
            return
                new GetReimburse().GetReimburseByCondition(loginUser, employeename, departmentid, statusEnum,
                                                           reimburseCategoriesEnumID, totalcostfrom, totalcostto,
                                                           applydateFrom, applydateTo, billtimeFrom, billtimeTo,
                                                           companyID, auth, finishStatus);
        }
        public List<Reimburse> GetReimburseForCustomerByCondition(Account loginUser, string employeename, int departmentid,
                                                      ReimburseStatusEnum statusEnum, int reimburseCategoriesEnumID,
                                                      decimal? totalcostfrom,
                                                      decimal? totalcostto, DateTime? applydateFrom,
                                                      DateTime? applydateTo,
                                                      DateTime? billtimeFrom, DateTime? billtimeTo, int companyID,
                                                      int auth, int finishStatus, int isCustomerFilled)
        {
            return
                new GetReimburse().GetReimburseForCustomerByCondition(loginUser, employeename, departmentid, statusEnum,
                                                                      reimburseCategoriesEnumID, totalcostfrom,
                                                                      totalcostto,
                                                                      applydateFrom, applydateTo, billtimeFrom,
                                                                      billtimeTo,
                                                                      companyID, auth, finishStatus, isCustomerFilled);
        }

        public int  FinishEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator)
        {
            FinishEmployeeReimburses finishEmployeeReimburses=new FinishEmployeeReimburses(employeeId, reimburses, curroperator);
            finishEmployeeReimburses.Excute();
            return finishEmployeeReimburses.FailCount;
            
        }

        //public int InterruptEmployeeReimburses(int employeeId, System.Collections.Generic.List<Model.Reimburse> reimburses, Model.Employee curroperator)
        //{
        //    InterruptEmployeeReimburses interruptEmployeeReimburses = new InterruptEmployeeReimburses(employeeId, reimburses, curroperator);
        //    interruptEmployeeReimburses.Excute();
        //    return interruptEmployeeReimburses.FailCount;
        //}

        //public Employee GetEmployeeReimbursingByLeadID(Account loginUser)
        //{
        //    return new GetReimburse().GetEmployeeReimbursingByLeadID(loginUser);
        //}

        public void QuickPassReimburses(Account loginUser, int reimburseID, int paperCount, string destinations, string customerName, string projectName, DateTime consumeDateFrom, DateTime consumeDateTo,string remark,decimal outcityAllowance,decimal  outcitydays)
        {
            QuickPassReimburse quickPassReimburse = new QuickPassReimburse(loginUser, reimburseID, paperCount, destinations, customerName, projectName, consumeDateFrom, consumeDateTo, remark, outcityAllowance,  outcitydays);
            quickPassReimburse.Excute();
            ReimburseSendMail reimburseSendMail = new ReimburseSendMail(reimburseID);
            reimburseSendMail.Excute();
        }

        //public void InterruptOrCancelReimburses(Account loginUser, int reimburseID, ReimburseStatusEnum statusEnum)
        //{
        //    InterruptOrCancelReimburses interruptReimburse = new InterruptOrCancelReimburses(loginUser, reimburseID,statusEnum);
        //    interruptReimburse.Excute();
        //}

        public Reimburse GetReimburseByPkid(int reimburseID)
        {
            return new GetReimburse().GetReimburseByPkid(reimburseID);
        }

        public Employee GetMyAuditingReimburses(int accountID)
        {
            return new GetReimburse().GetMyAuditingReimburses(accountID);
        }

        public List<ReimburseFlow> GetReimbursesHistory(int ReimburseID)
        {
            return new GetReimburse().GetReimbursesHistory(ReimburseID);
        }

        //public Account IsCEOElectricName(Reimburse reimburse)
        //{
        //    return new GetReimburse().IsCEOElectricName(reimburse);
        //}

        //public Account IsFinanceElectricName(Reimburse reimburse)
        //{
        //    return new GetReimburse().IsFinanceElectricName(reimburse);
        //}

        //public Account IsDepartmentLeaderElectricName(Reimburse reimburse)
        //{
        //    return new GetReimburse().IsDepartmentLeaderElectricName(reimburse);
        //}
        public List<EmployeeReimburseStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,
            int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            GetEmployeeReimburseStatistics getEmployeeReimburseStatistics=new GetEmployeeReimburseStatistics();
            return getEmployeeReimburseStatistics.DepartmentStatistics(startDt, endDt, departmentID,companyID,
                                                                   isIncludeChildDeptMember, loginUser);
        }
        public List<EmployeeReimburseStatistics> EmployeeStatistics(DateTime startDt, DateTime endDt, int departmentID,
            int companyID, string employeeName, Account loginUser)
        {
            GetEmployeeReimburseStatistics getEmployeeReimburseStatistics = new GetEmployeeReimburseStatistics();
            return getEmployeeReimburseStatistics.EmployeeStatistics(startDt, endDt, departmentID, companyID,
                                                                   employeeName, loginUser);
        }

        public int WaitAuditReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator)
        {
            WaitAuditReimburses waitAuditReimburses = new WaitAuditReimburses(employeeId, reimburses, curroperator);
            waitAuditReimburses.Excute();
            return waitAuditReimburses.FailCount;
        }

        public int ReturnEmployeeReimburses(int employeeId, List<Reimburse> reimburses, Employee curroperator)
        {
            ReturnEmployeeReimburses returnEmployeeReimburses = new ReturnEmployeeReimburses(employeeId, reimburses, curroperator);
            returnEmployeeReimburses.Excute();
            return returnEmployeeReimburses.FailCount;
        }

        public void ReturnOrCancelReimburses(int reimburseID, Employee curroperator)
        {
            ReturntOrCancelReimburses returntOrCancelReimburses = new ReturntOrCancelReimburses(reimburseID, curroperator);
            returntOrCancelReimburses.Excute();
        }

        public void SetBillingTime(int reimburseID, DateTime billingTime, Employee curroperator)
        {
            SetBillingTime setBillingTime = new SetBillingTime(reimburseID,billingTime,curroperator);
            setBillingTime.Excute();

        }

        public List<ReimburseTotal> GetReiburseTotalByCondition(Account loginUser, string employeename, string place, string customerName,
            string projectName, DateTime? applydateFrom, DateTime? applydateTo, string remark, int ReimburseCategoriesId, DateTime? billingTimeFrom,
                                                    DateTime? billingTimeTo, int departmentID,int companyID)
        {
            return new GetReimburse().GetReiburseTotalByCondition(loginUser, employeename, place, customerName, projectName, applydateFrom, applydateTo, remark, ReimburseCategoriesId, billingTimeFrom, billingTimeTo, departmentID, companyID);
        }

        public bool GetReiburseByCustomerID(int customerID)
        {
            return new GetReimburse().GetReiburseByCustomerID(customerID);
        }

        public void UpdateReimburseItemCustomer(Reimburse reimburse)
        {
            new UpdateReimburseItemCustomer(reimburse).Excute();
        }

        #endregion
    }
}
