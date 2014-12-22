using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class GetReimburse
    {
        private static IReimburse _DalReimburse = new ReimburseDal();
        ////private static IGetDepartment _IGetDepartment = new GetDepartment();
        private static IDepartmentBll _IGetDepartment = BllInstance.DepartmentBllInstance;


        public Employee GetEmployeeReimbursingByEmployeeID(int id)
        {
            Employee employee = _DalReimburse.GetEmployeeReimburseByEmployeeID(id);
            //for (int i = 0; i < employee.Reimburses.Count; i++)
            //{
            //    if (employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Interrupt || employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Reimbursed || employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Cancel)
            //    {
            //        employee.Reimburses.RemoveAt(i);
            //        i--;
            //    }
            //}
            return employee;
        }

        public Employee GetEmployeeReimburseHistoryByEmployeeID(int id)
        {
            Employee employee = _DalReimburse.GetEmployeeReimburseByEmployeeID(id);
            for (int i = 0; i < employee.Reimburses.Count; i++)
            {
                if (employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Added ||
                    employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Reimbursing ||
                    employee.Reimburses[i].ReimburseStatus == ReimburseStatusEnum.Auditing)
                {
                    employee.Reimburses.RemoveAt(i);
                    i--;
                }
            }
            return employee;
        }

        public Employee GetEmployeeReimburseByEmployeeID(int id)
        {
            return _DalReimburse.GetEmployeeReimburseByEmployeeID(id);
        }

        public List<Model.Reimburse> GetReimburseByCondition(Account loginUser, string employeename, int departmentid,
                                                             ReimburseStatusEnum statusEnum,
                                                             int reimburseCategoriesEnumID, decimal? totalcostfrom,
                                                             decimal? totalcostto, DateTime? applydateFrom,
                                                             DateTime? applydateTo, DateTime? billtimeFrom, DateTime? billtimeTo,
                                                             int companyID, int auth, int finishStatus)
        {
            List<Model.Reimburse> reimburses = new List<Model.Reimburse>();

            if (departmentid != -1)
            {
                reimburses =
                    _DalReimburse.GetReimburseByCondition(departmentid, statusEnum, reimburseCategoriesEnumID,
                                                          totalcostfrom,
                                                          totalcostto, applydateFrom, applydateTo, billtimeFrom,
                                                          billtimeTo, companyID, finishStatus);
                List<Department> departments = _IGetDepartment.GetChildDeptList(departmentid);
                foreach (Department department in departments)
                {
                    reimburses.AddRange(
                        _DalReimburse.GetReimburseByCondition(department.Id, statusEnum, reimburseCategoriesEnumID,
                                                              totalcostfrom,
                                                              totalcostto, applydateFrom, applydateTo, billtimeFrom,
                                                              billtimeTo, companyID, finishStatus));
                }
            }
            else
            {
                reimburses = _DalReimburse.GetReimburseByCondition(departmentid, statusEnum, reimburseCategoriesEnumID,
                                                              totalcostfrom,
                                                              totalcostto, applydateFrom, applydateTo, billtimeFrom,
                                                              billtimeTo, companyID, finishStatus);
            }
            List<Account> accounts =
                BllInstance.AccountBllInstance.GetAccountByBaseCondition(employeename, departmentid, -1, null, true, null);
            accounts = Tools.RemoteUnAuthAccount(accounts, AuthType.HRMIS, loginUser, auth);
            for (int i = reimburses.Count - 1; i >= 0; i--)
            {
                if (!IsContainsAccount(accounts, reimburses[i].ApplierID))
                {
                    reimburses.RemoveAt(i);
                }
                else
                {
                    Account account = BllInstance.AccountBllInstance.GetAccountById(reimburses[i].ApplierID);
                    reimburses[i].ApplerName = account.Name;
                    reimburses[i].Department.DepartmentName = account.Dept.DepartmentName;
                }
            }


            return reimburses;
        }
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
        /// <param name="isCustomerFilled"></param>
        /// <returns></returns>
        public List<Model.Reimburse> GetReimburseForCustomerByCondition(Account loginUser, string employeename, int departmentid,
                                                             ReimburseStatusEnum statusEnum,
                                                             int reimburseCategoriesEnumID, decimal? totalcostfrom,
                                                             decimal? totalcostto, DateTime? applydateFrom,
                                                             DateTime? applydateTo, DateTime? billtimeFrom, DateTime? billtimeTo,
                                                             int companyID, int auth, int finishStatus, int isCustomerFilled)
        {
            List<Model.Reimburse> reimburses =
                GetReimburseByCondition(loginUser, employeename, departmentid, statusEnum, reimburseCategoriesEnumID,
                                        totalcostfrom, totalcostto, applydateFrom, applydateTo, billtimeFrom, billtimeTo,
                                        companyID, auth, finishStatus);
            reimburses = RemoveReimburseByStatus(reimburses, ReimburseStatusEnum.Added);
            //ƥ��IsCustomerNull����
            for (int i = 0; i < reimburses.Count; i++)
            {
                if (isCustomerFilled == 1 && string.IsNullOrEmpty(reimburses[i].CustomerContentShow))
                {
                    reimburses.RemoveAt(i);
                    i--;
                }
                if (isCustomerFilled == 0 && !string.IsNullOrEmpty(reimburses[i].CustomerContentShow))
                {
                    reimburses.RemoveAt(i);
                    i--;
                }
            }

            return reimburses;
        }
        private List<Model.Reimburse> RemoveReimburseByStatus(List<Model.Reimburse> reimburseList, ReimburseStatusEnum reimburseStatusEnum)
        {
            List<Model.Reimburse> returnList = new List<Model.Reimburse>();
            foreach (Model.Reimburse reimburse in reimburseList)
            {
                if (!reimburse.ReimburseStatus.Equals(reimburseStatusEnum))
                {
                    returnList.Add(reimburse);
                }
            }
            return returnList;
        }

        private bool IsContainsAccount(List<Account> accounts, int accountId)
        {
            foreach (Account account in accounts)
            {
                if (account.Id == accountId)
                    return true;
            }
            return false;
        }

        ///// <summary>
        ///// ������Ҫ��˵ı�����
        ///// </summary>
        //public Employee GetEmployeeReimbursingByLeadID(Account loginUser)
        //{
        //    Employee employee = _DalReimburse.GetEmployeeReimburseByEmployeeID(loginUser.Id);
        //    employee.Reimburses = _DalReimburse.GetReimburseByCondition(-1, ReimburseStatusEnum.All, null, null, null, null);

        //    List<Model.Reimburse> retReimburses = new List<Model.Reimburse>();
        //    foreach (Model.Reimburse item in employee.Reimburses)
        //    {
        //        if (item.DiyProcess.DiySteps.Count != item.NextStepIndex)
        //        {
        //            Account operAccount =
        //                GetDiyStepAccount(item.ApplierID, item.DiyProcess.DiySteps[item.NextStepIndex]);
        //            if (operAccount == null)
        //            {
        //                if (item.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
        //                {
        //                    new InterruptOrCancelReimburses(loginUser, item.ReimburseID, ReimburseStatusEnum.Return).Excute();
        //                    continue;
        //                }
        //            }
        //            else if (operAccount.Id == loginUser.Id)
        //            {
        //                // ȥ���������ѱ������жϵı�����
        //                if (item.ReimburseStatus != ReimburseStatusEnum.Added &&
        //                    item.ReimburseStatus != ReimburseStatusEnum.Reimbursed &&
        //                    item.ReimburseStatus != ReimburseStatusEnum.Return// &&
        //                    //item.ReimburseStatus != ReimburseStatusEnum.Cancel
        //                    )
        //                {
        //                    item.ApplerName = BllInstance.AccountBllInstance.GetAccountById(item.ApplierID).Name;
        //                    retReimburses.Add(item);
        //                }
        //            }
        //        }
        //    }

        //    employee.Reimburses = retReimburses;
        //    return employee;
        //}

        /// <summary>
        /// �����Զ������̲����ҳ�������
        /// </summary>
        private Account GetDiyStepAccount(int activityAccountId, DiyStep diyStep)
        {
            try
            {
                Account account = null;
                switch (diyStep.OperatorType.Id)
                {
                    //"����"
                    case 0:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        break;
                    //"��������"
                    case 1:
                        account = BllInstance.AccountBllInstance.GetLeaderByAccountId(activityAccountId);
                        break;
                    //"�ϼ���������";
                    case 2:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null).Leader;
                        break;
                    //"���ϼ���������"
                    case 3:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept.Id, null).Leader;
                        break;
                    //"�����ϼ���������"
                    case 4:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept4 = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        dept4 = BllInstance.DepartmentBllInstance.GetParentDept(dept4.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept4.Id, null).Leader;
                        break;
                    //"�������ϼ���������"
                    case 5:
                        account = BllInstance.AccountBllInstance.GetAccountById(activityAccountId);
                        Department dept5 = BllInstance.DepartmentBllInstance.GetParentDept(account.Dept.Id, null);
                        dept5 = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null);
                        dept5 = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null);
                        account = BllInstance.DepartmentBllInstance.GetParentDept(dept5.Id, null).Leader;
                        break;
                    //"����"
                    case 6:
                        account = BllInstance.AccountBllInstance.GetAccountById(diyStep.OperatorID);
                        break;
                    default:
                        break;
                }
                return account;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ����pkid�ұ���
        /// </summary>
        public Model.Reimburse GetReimburseByPkid(int id)
        {
            return _DalReimburse.GetReimburseByReimburseID(id);
        }

        /// <summary>
        /// �����������ɵı�����
        /// </summary>
        public Employee GetMyAuditingReimburses(int accountID)
        {
            Employee employee = _DalReimburse.GetEmployeeReimburseByEmployeeID(accountID);
            employee.Reimburses = _DalReimburse.GetMyAuditingReimburses(accountID);

            foreach (Model.Reimburse item in employee.Reimburses)
            {
                item.ApplerName = BllInstance.AccountBllInstance.GetAccountById(item.ApplierID).Name;
            }
            return employee;
        }

        /// <summary>
        /// ��������������ʷ
        /// </summary>
        public List<ReimburseFlow> GetReimbursesHistory(int reimburseID)
        {
            List<ReimburseFlow> reimburseFlows = _DalReimburse.GetReimbursesHistory(reimburseID);

            foreach (ReimburseFlow item in reimburseFlows)
            {
                item.Operator.Account.Name =
                    BllInstance.AccountBllInstance.GetAccountById(item.Operator.Account.Id).Name;
            }
            return reimburseFlows;
        }

        ///// <summary>
        ///// �Ƿ���CEOǩ��
        ///// </summary>
        //public Account IsCEOElectricName(HRMISModel.Reimburse reimburse)
        //{
        //    for (int i = 0 ; i < reimburse.DiyProcess.DiySteps.Count;i++)
        //    {
        //        if (reimburse.DiyProcess.DiySteps[i].Status == "CEO����ǩ��")
        //        {
        //            Account account = GetDiyStepAccount(reimburse.ApplierID, reimburse.DiyProcess.DiySteps[i]);
        //            List<ReimburseFlow> reimburseFlows = GetReimbursesHistory(reimburse.ReimburseID);
        //            foreach (ReimburseFlow item in reimburseFlows)
        //            {
        //                if (item.Operator.Account.Id == account.Id && item.ReimburseStatusEnum == ReimburseStatusEnum.Auditing)
        //                {
        //                    return account;
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}

        ///// <summary>
        ///// �Ƿ��в���ǩ��
        ///// </summary>
        //public Account IsFinanceElectricName(HRMISModel.Reimburse reimburse)
        //{
        //    for (int i = 0; i < reimburse.DiyProcess.DiySteps.Count; i++)
        //    {
        //        if (reimburse.DiyProcess.DiySteps[i].Status == "�������ǩ��")
        //        {
        //            Account account = GetDiyStepAccount(reimburse.ApplierID, reimburse.DiyProcess.DiySteps[i]);
        //            List<ReimburseFlow> reimburseFlows = GetReimbursesHistory(reimburse.ReimburseID);
        //            foreach (ReimburseFlow item in reimburseFlows)
        //            {
        //                if (item.Operator.Account.Id == account.Id && item.ReimburseStatusEnum == ReimburseStatusEnum.Auditing)
        //                {
        //                    return account;
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// �Ƿ��в����쵼ǩ��
        ///// </summary>
        //public Account IsDepartmentLeaderElectricName(HRMISModel.Reimburse reimburse)
        //{
        //    for (int i = 0; i < reimburse.DiyProcess.DiySteps.Count; i++)
        //    {
        //        if (reimburse.DiyProcess.DiySteps[i].Status == "�����쵼����ǩ��")
        //        {
        //            Account account = GetDiyStepAccount(reimburse.ApplierID, reimburse.DiyProcess.DiySteps[i]);
        //            List<ReimburseFlow> reimburseFlows = GetReimbursesHistory(reimburse.ReimburseID);
        //            foreach (ReimburseFlow item in reimburseFlows)
        //            {
        //                if (item.Operator.Account.Id == account.Id && item.ReimburseStatusEnum == ReimburseStatusEnum.Auditing)
        //                {
        //                    return account;
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        public List<ReimburseTotal> GetReiburseTotalByCondition(Account loginUser, string employeename, string place,
                                                                string customerName,
                                                                string projectName, DateTime? applydateFrom,
                                                                DateTime? applydateTo, string remark,
                                                                int ReimburseCategoriesId, DateTime? billingTimeFrom,
                                                                DateTime? billingTimeTo, int departmentID, int companyID)
        {
            List<Model.Reimburse> reimburses =
                _DalReimburse.GetReiburseTotalByCondition(employeename, place, customerName, projectName, applydateFrom,
                                                          applydateTo, remark, ReimburseCategoriesId, billingTimeFrom,
                                                          billingTimeTo, companyID);

            List<Account> accounts = new List<Account>();

            accounts = BllInstance.AccountBllInstance.GetAccountByBaseCondition(employeename, departmentID, -1, null, true, null);

            accounts = Tools.RemoteUnAuthAccount(accounts, AuthType.HRMIS, loginUser, HrmisPowers.A902);

            for (int i = reimburses.Count - 1; i >= 0; i--)
            {
                if (!IsContainsAccount(accounts, reimburses[i].ApplierID))
                {
                    reimburses.RemoveAt(i);
                }
                else
                {
                    Account account = BllInstance.AccountBllInstance.GetAccountById(reimburses[i].ApplierID);
                    reimburses[i].ApplerName = account.Name;
                    reimburses[i].Department = account.Dept;
                    //reimburses[i].Department.DepartmentName = account.Dept.DepartmentName;
                }
            }

            List<ReimburseTotal> reimburseTotals = new List<ReimburseTotal>();

            if (reimburses.Count != 0)
            {
                for (int i = 0; i < reimburses.Count; i++)
                {
                    ReimburseTotal reimburseTotal = new ReimburseTotal();
                    bool isContain = false;
                    reimburseTotal.CustomerIds = new List<int>();
                    foreach (ReimburseTotal total in reimburseTotals)
                    {
                        if (!total.ReimburseID.Equals(reimburses[i].ReimburseID)) continue;
                        reimburseTotal = total;
                        isContain = true;
                        break;
                    }
                    reimburseTotal.ReimburseID = reimburses[i].ReimburseID;
                    // �·�
                    reimburseTotal.Month = Convert.ToDateTime(reimburses[i].BillingTime).Month.ToString();
                    // Ա������
                    reimburseTotal.Name = reimburses[i].ApplerName;
                    // ����ص�
                    reimburseTotal.Place = reimburses[i].Destinations;
                    // ������Ŀ
                    reimburseTotal.Projuct = reimburses[i].ProjectName;
                    //��������
                    reimburseTotal.OutCityDays = reimburses[i].OutCityDays;
                    //�����
                    reimburseTotal.OutCityAllowance = reimburses[i].OutCityAllowance;
                    //��ע
                    reimburseTotal.Remark = reimburses[i].Remark;
                    reimburseTotal.Discription = reimburses[i].Discription;
                    //����
                    reimburseTotal.ReimburseCategories = reimburses[i].ReimburseCategoriesEnum;

                    // ���ʼʱ��
                    reimburseTotal.StartTime = reimburses[i].ConsumeDateFrom.ToShortDateString();
                    // �������ʱ��
                    reimburseTotal.EndTime = reimburses[i].ConsumeDateTo.ToShortDateString();

                    for (int j = 0; j < reimburses[i].ReimburseItems.Count; j++)
                    {
                        // ��;�ϼ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.LongDistanceCost)
                        {
                            reimburseTotal.LongTripTotal = reimburseTotal.LongTripTotal +
                                                           reimburses[i].ReimburseItems[j].ExchangeCost;
                        }

                        // ��;�ϼ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.ShortDistanceCost)
                        {
                            reimburseTotal.ShortTripTotal = reimburseTotal.ShortTripTotal +
                                                            reimburses[i].ReimburseItems[j].ExchangeCost;
                        }

                        // ס�޺ϼ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.LodgingCost)
                        {
                            reimburseTotal.LodgingTotal = reimburseTotal.LodgingTotal +
                                                          reimburses[i].ReimburseItems[j].ExchangeCost;
                        }

                        // ���ʺϼ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum ==
                            ReimburseTypeEnum.CommunicationEntertainmentCost)
                        {
                            reimburseTotal.EntertainmentTotal = reimburseTotal.EntertainmentTotal +
                                                                reimburses[i].ReimburseItems[j].ExchangeCost;
                        }

                        // �����ϼ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.OtherCost)
                        {
                            reimburseTotal.OtherTotal = reimburseTotal.OtherTotal +
                                                        reimburses[i].ReimburseItems[j].ExchangeCost;
                        }
                        //�ͷ�
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.MealCost)
                        {
                            reimburseTotal.MealTotalCost = reimburseTotal.MealTotalCost +
                                                           reimburses[i].ReimburseItems[j].ExchangeCost;
                        }
                        //���ڽ�ͨ��
                        if (reimburses[i].ReimburseItems[j].ReimburseTypeEnum == ReimburseTypeEnum.CityTrafficCost)
                        {
                            reimburseTotal.CityTrafficTotalCost = reimburseTotal.CityTrafficTotalCost +
                                                                  reimburses[i].ReimburseItems[j].ExchangeCost;
                        }
                        int customerId = reimburses[i].ReimburseItems[j].CustomerID;
                        if (customerId == 0 || reimburseTotal.CustomerIds.Contains(customerId)) continue;
                        reimburseTotal.CustomerIds.Add(customerId);
                        reimburseTotal.CustomerName = reimburseTotal.CustomerName +
                                                      reimburses[i].ReimburseItems[j].CustomerName + ";";
                    }
                    int count = _DalReimburse.GetCustomerCountByReiburseID(reimburseTotal.ReimburseID);
                    if (count > 1)
                    {
                        reimburseTotal.OutCityAllowance =
                            decimal.Round(reimburseTotal.OutCityAllowance * reimburseTotal.CustomerIds.Count / count, 2);
                    }
                    // С��
                    reimburseTotal.Total =
                        decimal.Round(reimburseTotal.LongTripTotal +
                                      reimburseTotal.ShortTripTotal +
                                      reimburseTotal.LodgingTotal +
                                      reimburseTotal.EntertainmentTotal +
                                      reimburseTotal.OtherTotal + reimburseTotal.OutCityAllowance +
                                      reimburseTotal.MealTotalCost + reimburseTotal.CityTrafficTotalCost, 2);
                    if (!isContain)
                    {
                        reimburseTotals.Add(reimburseTotal);
                    }
                }
            }
            return reimburseTotals;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public bool GetReiburseByCustomerID(int customerID)
        {
            return _DalReimburse.GetReiburseByCustomerID(customerID);
        }
    }
}