using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class SearchReimburseInfoPresenter : BasePresenter
    {
        private DateTime? dtApplyDateFrom;
        private DateTime? dtApplyDateTo;
        private DateTime? dtBillingTimeFrom;
        private DateTime? dtBillingTimeTo;
        private decimal? dTotalCostFrom;
        private decimal? dTotalCostTo;

        protected DateTime tempStartTime;
        protected DateTime tempEndTime;
        protected decimal tempTotalCostFrom;
        protected decimal tempTotalCostTo;

        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly ICompanyInvolveFacade _ICompanyInvolveFacade = InstanceFactory.CreateCompanyInvolveFacade();
        public ISearchReimburseInfoView _View;
        private readonly Account _LoginUser;
        public SearchReimburseInfoPresenter(ISearchReimburseInfoView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
            _LoginUser = loginUser;
            SwitchLittleViewPresenter();
        }

        private void SwitchLittleViewPresenter()
        {
            new BillingTimeAddPresenter(_View.BillingTimeDetailView);
        }

        public override void Initialize(bool isPostBack)
        {

            AttachViewEvent();
            if (!isPostBack)
            {
                _View.SearchReimburseView.ReimburseStatus = GetReimburseStatusEnum();
                _View.SearchReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();
                //_IGetDepartment = new GetDepartment();
                List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
                _View.SearchReimburseView.DepartmentSource = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A901);
                _View.SearchReimburseView.CompanySource = _ICompanyInvolveFacade.GetAllCompanyHaveEmployee();
                BindReimburse(null, null);
            }
        }

        private void AttachViewEvent()
        {
            _View.SearchReimburseView.btnSearchClick += BindReimburse;
            _View.SearchReimburseView.btnViewClick += btnViewClick;
            _View.SearchReimburseView.btnReimbursedClick += btnReimbursedClick;
            _View.SearchReimburseView.btnReturnClick += btnReturnClick;
            _View.SearchReimburseView.btnWaitAuditClick += btnWaitAuditClick;
            //小界面按钮
            _View.SearchReimburseView.BtnReimbursedEvent += ShowReimbursedView;
            _View.BillingTimeDetailView.ActionButtonEvent += ActionEvent;
        }

        private void ShowReimbursedView(string id)
        {
            new BillingTimeAddPresenter(_View.BillingTimeDetailView).InitView(id);
            _View.BillingTimeDetailViewVisible = true;
        }

        private void ActionEvent()
        {
            if (_View.BillingTimeDetailView.ActionSuccess)
            {

                Employee curroperator = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
                curroperator.Account.Id = _LoginUser.Id;
                try
                {
                    _IReimburseFacade.SetBillingTime(Convert.ToInt32(_View.BillingTimeDetailView.ReimburseID), Convert.ToDateTime(_View.BillingTimeDetailView.BillingTime), curroperator);
                    BindReimburse(null, null);
                    _View.BillingTimeDetailViewVisible = false;
                }
                catch (Exception ex)
                {
                    _View.BillingTimeDetailViewVisible = true;
                    _View.BillingTimeDetailView.Message = ex.Message;
                }
            }
            else
            {
                _View.BillingTimeDetailViewVisible = true;
            }
        }

        private void btnWaitAuditClick(object sender, EventArgs e)
        {
            List<string> _reimburses = _View.SearchReimburseView.SelectedReimburses;
            Employee curroperator = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
            curroperator.Account.Id = _LoginUser.Id;
            int iFailCount = 0;
            List<Employee> employeeReimbuses = GenerateEmployeeReimbuses(_reimburses);
            try
            {
                foreach (Employee employeeReimbuse in employeeReimbuses)
                {
                    iFailCount += _IReimburseFacade.WaitAuditReimburses(employeeReimbuse.Account.Id, employeeReimbuse.Reimburses, curroperator);
                }
                BindReimburse(null, null);
                _View.SearchReimburseView.Message =
                    "<span class='font14b'>成功将 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单置为待财务审核</span>";
                _View.SearchReimburseView.Message = iFailCount == 0
                                    ? _View.SearchReimburseView.Message
                                    : _View.SearchReimburseView.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在提交状态，无法置为待财务审核。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.SearchReimburseView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void btnReturnClick(object sender, EventArgs e)
        {
            List<string> _reimburses = _View.SearchReimburseView.SelectedReimburses;
            Employee curroperator = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
            curroperator.Account.Id = _LoginUser.Id;
            int iFailCount = 0;
            List<Employee> employeeReimbuses = GenerateEmployeeReimbuses(_reimburses);
            try
            {
                foreach (Employee employeeReimbuse in employeeReimbuses)
                {
                    iFailCount += _IReimburseFacade.ReturnEmployeeReimburses(employeeReimbuse.Account.Id, employeeReimbuse.Reimburses, curroperator);
                }
                BindReimburse(null, null);
                _View.SearchReimburseView.Message =
                    "<span class='font14b'>成功退回 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单</span>";
                _View.SearchReimburseView.Message = iFailCount == 0
                                    ? _View.SearchReimburseView.Message
                                    : _View.SearchReimburseView.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在待财务审核状态中，无法退回。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.SearchReimburseView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private List<Employee> GenerateEmployeeReimbuses(List<string> reimburses)
        {
            List<Employee> retEmployeeReimburses = new List<Employee>();
            foreach (string strreimburse in reimburses)
            {
                bool b_AddEmployee = true;
                for (int i = 0; i < retEmployeeReimburses.Count; i++)
                {
                    if (retEmployeeReimburses[i].Account.Id == Convert.ToInt32(strreimburse.Split('|')[1]))
                    {
                        hrmisModel.Reimburse reimburse = new hrmisModel.Reimburse(new DateTime(2008, 2, 2), ReimburseStatusEnum.Added);
                        reimburse.ReimburseID = Convert.ToInt32(strreimburse.Split('|')[0]);
                        retEmployeeReimburses[i].Reimburses.Add(reimburse);
                        b_AddEmployee = false;
                    }
                }
                if (b_AddEmployee)
                {
                    //Employee employee = new Employee("", "", "", EmployeeTypeEnum.All, null, null, null);
                    Employee employee = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
                    employee.Account.Id = Convert.ToInt32(strreimburse.Split('|')[1]);
                    employee.Reimburses = new List<hrmisModel.Reimburse>();
                    hrmisModel.Reimburse reimburse = new hrmisModel.Reimburse(new DateTime(2008, 2, 2), ReimburseStatusEnum.Added);
                    reimburse.ReimburseID = Convert.ToInt32(strreimburse.Split('|')[0]);
                    employee.Reimburses.Add(reimburse);
                    retEmployeeReimburses.Add(employee);
                }
            }
            return retEmployeeReimburses;
        }


        private void btnReimbursedClick(object sender, EventArgs e)
        {
            List<string> _reimburses = _View.SearchReimburseView.SelectedReimburses;
            //Employee curroperator = new Employee("", "", "", EmployeeTypeEnum.All, null, null, null);
            Employee curroperator = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
            curroperator.Account.Id = _LoginUser.Id;
            int iFailCount = 0;
            List<Employee> employeeReimbuses = GenerateEmployeeReimbuses(_reimburses);
            try
            {
                foreach (Employee employeeReimbuse in employeeReimbuses)
                {
                    //FinishEmployeeReimburses finishEmployeeReimburses =
                    //    new FinishEmployeeReimburses(employeeReimbuse.Account.Id, employeeReimbuse.Reimburses,
                    //                                    curroperator);
                    //finishEmployeeReimburses.Excute();
                    //iFailCount += finishEmployeeReimburses.FailCount;
                    iFailCount += _IReimburseFacade.FinishEmployeeReimburses(employeeReimbuse.Account.Id, employeeReimbuse.Reimburses, curroperator);
                }
                BindReimburse(null, null);
                _View.SearchReimburseView.Message =
                    "<span class='font14b'>成功结束 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单</span>";
                _View.SearchReimburseView.Message = iFailCount == 0
                                    ? _View.SearchReimburseView.Message
                                    : _View.SearchReimburseView.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在报销状态中，无法结束。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.SearchReimburseView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public event CommandEventHandler btnViewClick;
        public void BindReimburse(object source, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    List<Model.Reimburse> reimburseList = ReimburseLogic.GetReimburseByCondition(_LoginUser, _View.SearchReimburseView.EmployeeName,
                                                                  Convert.ToInt32(_View.SearchReimburseView.DepartmentID),
                                                                  (ReimburseStatusEnum)
                                                                  Convert.ToInt32(
                                                                      _View.SearchReimburseView.SelectedReimburseStatus), null, null,
                                                                  Convert.ToInt32(
                                                                      _View.SearchReimburseView.
                                                                          ReimburseCategoriesEnumID),
                                                                  dTotalCostFrom, dTotalCostTo, dtApplyDateFrom,
                                                                  dtApplyDateTo, dtBillingTimeFrom, dtBillingTimeTo,
                                                                  _View.SearchReimburseView.CompanyID, _View.SearchReimburseView.SelectedFinishStatus, HrmisPowers.A901, _View.SearchReimburseView.PagerEntity);
                    _View.SearchReimburseView.ReimburseListSource = reimburseList;
                    _View.SearchReimburseView.Message =
                        "<span class='font14b'>共查到 </span>"
                        + "<span class='fontred'>" + _View.SearchReimburseView.ReimburseListSource.Count + "</span>"
                        + "<span class='font14b'> 个报销单; 共报销金额为</span>"
                        + GetTotalCountStr(reimburseList);
                }
                catch (ApplicationException ex)
                {
                    _View.SearchReimburseView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public static string GetTotalCountStr(List<Model.Reimburse> reimburseList)
        {
            Dictionary<string, decimal> counts = new Dictionary<string, decimal>();
            foreach (Model.Reimburse reimburse in reimburseList)
            {
                if (!counts.ContainsKey(reimburse.ExchangeRateName))
                {
                    counts.Add(reimburse.ExchangeRateName, 0);
                }
                counts[reimburse.ExchangeRateName] += reimburse.TotalCost;
            }
            string countstr = "";
            foreach (KeyValuePair<string, decimal> kvp in counts)
            {
                countstr += kvp.Key + "<span class='fontred'>" + kvp.Value.ToString("F2") + "</span>；";
            }
            return countstr;
        }

        #region private Validation
        public bool Validation()
        {
            _View.SearchReimburseView.TotalCostMsg = string.Empty;
            _View.SearchReimburseView.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (!(VaildateApplyDateFrom() && VaildateApplyDateTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.SearchReimburseView.ApplyDateFrom) && !string.IsNullOrEmpty(_View.SearchReimburseView.ApplyDateTo))
            {
                if (DateTime.Compare(Convert.ToDateTime(dtApplyDateFrom), Convert.ToDateTime(dtApplyDateTo)) > 0)
                {
                    _View.SearchReimburseView.ApplyDateMsg = "开始时间不可晚于结束时间";
                    ret = false;
                }
            }
            if (!(VaildateBillingTimeFrom() && VaildateBillingTimeTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.SearchReimburseView.BillingTimeFrom) && !string.IsNullOrEmpty(_View.SearchReimburseView.BillingTimeTo))
            {
                if (DateTime.Compare(Convert.ToDateTime(dtBillingTimeFrom), Convert.ToDateTime(dtBillingTimeTo)) > 0)
                {
                    _View.SearchReimburseView.BillingTimeMsg = "开始时间不可晚于结束时间";
                    ret = false;
                }
            }
            if (!(VaildateTotalCostFrom() && VaildateTotalCostTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.SearchReimburseView.TotalCostFrom) && !string.IsNullOrEmpty(_View.SearchReimburseView.TotalCostTo))
            {
                if (tempTotalCostFrom > tempTotalCostTo)
                {
                    _View.SearchReimburseView.TotalCostMsg = "无效的查询范围";
                    ret = false;
                }
            }
            return ret;
        }

        private bool VaildateTotalCostFrom()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.TotalCostFrom))
            {
                if (!Decimal.TryParse(_View.SearchReimburseView.TotalCostFrom, out tempTotalCostFrom))
                {
                    _View.SearchReimburseView.TotalCostMsg = "请输入数字";
                    return false;
                }
                else
                {
                    dTotalCostFrom = tempTotalCostFrom;
                }
            }
            return true;
        }

        private bool VaildateTotalCostTo()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.TotalCostTo))
            {
                if (!Decimal.TryParse(_View.SearchReimburseView.TotalCostTo, out tempTotalCostTo))
                {
                    _View.SearchReimburseView.TotalCostMsg = "请输入数字";
                    return false;
                }
                else
                {
                    dTotalCostTo = tempTotalCostTo;
                }
            }
            return true;
        }
        private bool VaildateApplyDateFrom()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.ApplyDateFrom))
            {
                if (!DateTime.TryParse(_View.SearchReimburseView.ApplyDateFrom, out tempStartTime))
                {
                    _View.SearchReimburseView.ApplyDateMsg = "时间格式输入不正确";
                    return false;
                }
                else
                {
                    dtApplyDateFrom = tempStartTime;
                }
            }
            return true;
        }

        private bool VaildateApplyDateTo()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.ApplyDateTo))
            {
                if (!DateTime.TryParse(_View.SearchReimburseView.ApplyDateTo, out tempEndTime))
                {
                    _View.SearchReimburseView.ApplyDateMsg = "时间格式输入不正确";
                    return false;
                }
                else
                {
                    dtApplyDateTo = tempEndTime;
                }
            }
            return true;
        }
        private bool VaildateBillingTimeFrom()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.BillingTimeFrom))
            {
                if (!DateTime.TryParse(_View.SearchReimburseView.BillingTimeFrom, out tempStartTime))
                {
                    _View.SearchReimburseView.BillingTimeMsg = "时间格式输入不正确";
                    return false;
                }
                dtBillingTimeFrom = tempStartTime;
            }
            return true;
        }

        private bool VaildateBillingTimeTo()
        {
            if (!string.IsNullOrEmpty(_View.SearchReimburseView.BillingTimeTo))
            {
                if (!DateTime.TryParse(_View.SearchReimburseView.BillingTimeTo, out tempStartTime))
                {
                    _View.SearchReimburseView.BillingTimeMsg = "时间格式输入不正确";
                    return false;
                }
                dtBillingTimeTo = tempStartTime;
            }
            return true;
        }
        #endregion
        #region private method

        private static Dictionary<string, string> GetReimburseStatusEnum()
        {
            Dictionary<string, string> reimburseType = new Dictionary<string, string>();
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.All);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Added);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Reimbursing);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.WaitAudit);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Auditing);
            //hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Return);
            hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Reimbursed);
            //hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Interrupt);

            //hrmisModel.Reimburse.AddReimburseStatusValueAndNameIntoDictionary(reimburseType, ReimburseStatusEnum.Cancel);
            return reimburseType;
        }
        #endregion

    }
}
