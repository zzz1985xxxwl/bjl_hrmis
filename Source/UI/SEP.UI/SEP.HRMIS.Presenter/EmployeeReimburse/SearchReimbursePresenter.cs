using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.IBll;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class SearchReimbursePresenter : PresenterCore.BasePresenter
    {
        private DateTime? dtApplyDateFrom;
        private DateTime? dtApplyDateTo;
        private decimal? dTotalCostFrom;
        private decimal? dTotalCostTo;

        protected DateTime tempStartTime;
        protected DateTime tempEndTime;
        protected decimal tempTotalCostFrom;
        protected decimal tempTotalCostTo;

        //private IGetReimburse _IGetReimburse = new GetReimburse();

        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

        public ISearchReimburseView _View;
        //private IGetDepartment _IGetDepartment;
        //private int _CurrOperatorID;
        private readonly Account _LoginUser;

        public SearchReimbursePresenter(ISearchReimburseView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
            _LoginUser = loginUser;
        }
        private void AttachViewEvent()
        {
            _View.btnSearchClick += BindReimburse;
            _View.btnViewClick += btnViewClick;
            _View.btnReimbursedClick += btnReimbursedClick;
            _View.btnReturnClick += btnReturnClick;
            _View.btnWaitAuditClick += btnWaitAuditClick;
        }

        private void btnWaitAuditClick(object sender, EventArgs e)
        {
            List<string> _reimburses = _View.SelectedReimburses;
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
                _View.Message =
                    "<span class='font14b'>成功将 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单置为待财务审核</span>";
                _View.Message = iFailCount == 0
                                    ? _View.Message
                                    : _View.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在提交状态，无法置为待财务审核。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void btnReturnClick(object sender, EventArgs e)
        {
            List<string> _reimburses = _View.SelectedReimburses;
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
                _View.Message =
                    "<span class='font14b'>成功退回 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单</span>";
                _View.Message = iFailCount == 0
                                    ? _View.Message
                                    : _View.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在待财务审核状态中，无法退回。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
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
            List<string> _reimburses = _View.SelectedReimburses;
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
                _View.Message =
                    "<span class='font14b'>成功结束 </span>"
                    + "<span class='fontred'>" + (_reimburses.Count - iFailCount) + "</span>"
                    + "<span class='font14b'> 个报销单</span>";
                _View.Message = iFailCount == 0
                                    ? _View.Message
                                    : _View.Message + "<span class='font14b'>； 其中</span><span class='fontred'>" +
                                      (iFailCount) +
                                      "</span><span class='font14b'> 个报销单不在报销状态中，无法结束。</span>";
            }
            catch (ApplicationException ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                _View.ReimburseStatus = GetReimburseStatusEnum();
                //_IGetDepartment = new GetDepartment();
                List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
                _View.DepartmentSource = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS,_LoginUser, HrmisPowers.A504);
                BindReimburse(null, null);
            }
        }

        public event CommandEventHandler btnViewClick;
        public void BindReimburse(object source, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    List<Model.Reimburse> reimburseList= _IReimburseFacade.GetReimburseByCondition(_LoginUser, _View.EmployeeName, Convert.ToInt32(_View.DepartmentID),
                                                            (ReimburseStatusEnum)Convert.ToInt32(_View.SelectedReimburseStatus),
                                                            dTotalCostFrom, dTotalCostTo, dtApplyDateFrom, dtApplyDateTo);
                    _View.ReimburseListSource = reimburseList;
                    decimal count = 0;
                    foreach(Model.Reimburse reimburse in reimburseList)
                    {
                        count = count + reimburse.TotalCost;
                    }
                    _View.Message =
                        "<span class='font14b'>共查到 </span>"
                        + "<span class='fontred'>" + _View.ReimburseListSource.Count + "</span>"
                        + "<span class='font14b'> 个报销单; 共报销金额为</span>"
                        + "<span class='fontred'>" + count + "</span>"
                        + "<span class='font14b'> 元</span>";
                }
                catch (ApplicationException ex)
                {
                    _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }
        #region private Validation
        public bool Validation()
        {
            _View.TotalCostMsg = string.Empty;
            _View.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (!(VaildateApplyDateFrom() && VaildateApplyDateTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.ApplyDateFrom) && !string.IsNullOrEmpty(_View.ApplyDateTo))
            {
                if (DateTime.Compare(tempStartTime, tempEndTime) > 0)
                {
                    _View.ApplyDateMsg = "开始时间不可晚于结束时间";
                    ret = false;
                }
            }
            if (!(VaildateTotalCostFrom() && VaildateTotalCostTo()))
            {
                ret = false;
            }
            else if (!string.IsNullOrEmpty(_View.TotalCostFrom) && !string.IsNullOrEmpty(_View.TotalCostTo))
            {
                if (tempTotalCostFrom > tempTotalCostTo)
                {
                    _View.TotalCostMsg = "无效的查询范围";
                    ret = false;
                }
            }
            return ret;
        }

        private bool VaildateTotalCostFrom()
        {
            if (!string.IsNullOrEmpty(_View.TotalCostFrom))
            {
                if (!Decimal.TryParse(_View.TotalCostFrom, out tempTotalCostFrom))
                {
                    _View.TotalCostMsg = "请输入数字";
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
            if (!string.IsNullOrEmpty(_View.TotalCostTo))
            {
                if (!Decimal.TryParse(_View.TotalCostTo, out tempTotalCostTo))
                {
                    _View.TotalCostMsg = "请输入数字";
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
            if (!string.IsNullOrEmpty(_View.ApplyDateFrom))
            {
                if (!DateTime.TryParse(_View.ApplyDateFrom, out tempStartTime))
                {
                    _View.ApplyDateMsg = "时间格式输入不正确";
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
            if (!string.IsNullOrEmpty(_View.ApplyDateTo))
            {
                if (!DateTime.TryParse(_View.ApplyDateTo, out tempEndTime))
                {
                    _View.ApplyDateMsg = "时间格式输入不正确";
                    return false;
                }
                else
                {
                    dtApplyDateTo = tempEndTime;
                }
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
