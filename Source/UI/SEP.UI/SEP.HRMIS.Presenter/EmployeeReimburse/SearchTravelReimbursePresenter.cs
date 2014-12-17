using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class SearchTravelReimbursePresenter : PresenterCore.BasePresenter
    {
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly ICompanyInvolveFacade _ICompanyInvolveFacade = InstanceFactory.CreateCompanyInvolveFacade();
        public ISearchTravelReimburseView _View;
        private readonly Account _LoginUser;
        private DateTime? dtApplyDateFrom;
        private DateTime? dtApplyDateTo;
        private DateTime? dtBillingTimeFrom;
        private DateTime? dtBillingTimeTo;
        protected DateTime tempStartTime;
        protected DateTime tempEndTime;

        public SearchTravelReimbursePresenter(ISearchTravelReimburseView view, Account loginUser)
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
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                _View.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();
                List<Department> deptList = _IDepartmentBll.GetAllDepartment();
                _View.DepartmentSource =
                    Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _LoginUser, HrmisPowers.A902);
                _View.CompanySource = _ICompanyInvolveFacade.GetAllCompanyHaveEmployee();
                _View.BillingTimeFrom = DateTime.Now.Year + "-" + DateTime.Now.Month + "-1";
                _View.BillingTimeTo =
                    Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-1").AddMonths(1).AddDays(-1).
                        ToShortDateString();
                BindReimburse(null, null);
            }
        }



        public void BindReimburse(object source, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    List<ReimburseTotal> reimburseTotalList = _IReimburseFacade.GetReiburseTotalByCondition(_LoginUser, _View.EmployeeName, _View.Destinations, _View.CustomerName, _View.ProjectName, dtApplyDateFrom, dtApplyDateTo, _View.Remark, Convert.ToInt32(_View.ReimburseCategoriesEnumID),dtBillingTimeFrom,dtBillingTimeTo,_View.DepartMentID,_View.CompanyID);
                    _View.ReimburseTotalListSource = reimburseTotalList;
                    _View.gvSearchReimburseTableSource =
                        EmployeeReimburse.ReimburseStatistics.UtilityPresenter.TurnToSearchReimburseDataTable(reimburseTotalList);
                    decimal longTripTotal = 0;
                    decimal shortTripTotal = 0;
                    decimal lodgingTotal = 0;
                    decimal entertainmentTotal = 0;
                    decimal otherTotal = 0;
                    decimal total = 0;
                    decimal outcityallowance = 0;
                    decimal mealTotal = 0;
                    decimal cityTrafficTotal = 0;
                    foreach (ReimburseTotal reimburseTotal in reimburseTotalList)
                    {
                        longTripTotal = longTripTotal + reimburseTotal.LongTripTotal;
                        shortTripTotal = shortTripTotal + reimburseTotal.ShortTripTotal;
                        lodgingTotal = lodgingTotal + reimburseTotal.LodgingTotal;
                        entertainmentTotal = entertainmentTotal + reimburseTotal.EntertainmentTotal;
                        otherTotal = otherTotal + reimburseTotal.OtherTotal;
                        outcityallowance += reimburseTotal.OutCityAllowance;
                        mealTotal = mealTotal + reimburseTotal.MealTotalCost;
                        cityTrafficTotal = cityTrafficTotal+reimburseTotal.CityTrafficTotalCost;
                        total = total + reimburseTotal.Total;
                    }
                    _View.LongTripTotal = longTripTotal.ToString();
                    _View.ShortTripTotal = shortTripTotal.ToString();
                    _View.LodgingTotal = lodgingTotal.ToString();
                    _View.EntertainmentTotal = entertainmentTotal.ToString();
                    _View.OtherTotal = otherTotal.ToString();
                    _View.Total = total.ToString();
                    _View.OutCityAllowanceTotal = outcityallowance.ToString();
                    _View.MealTotal = mealTotal.ToString();
                    _View.CityTrafficTotalTotal = cityTrafficTotal.ToString();
                    _View.Message =
                        "<span class='font14b'>共查到 </span>"
                        + "<span class='fontred'>" + _View.ReimburseTotalListSource.Count + "</span>"
                        + "<span class='font14b'> 个报销单; 共报销金额为</span>"
                        + "<span class='fontred'>" + total + "</span>"
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
            _View.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (!(VaildateApplyDateFrom() && VaildateApplyDateTo()))
            {
                ret = false;
            }
            else if (!(VaildateBillingTimeFrom() && VaildateBillingTimeTo()))
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
            return ret;
        }

        private bool VaildateBillingTimeFrom()
        {
            if (!string.IsNullOrEmpty(_View.BillingTimeFrom))
            {
                if (!DateTime.TryParse(_View.BillingTimeFrom, out tempStartTime))
                {
                    _View.BillingTimeMsg = "时间格式输入不正确";
                    return false;
                }
                dtBillingTimeFrom = tempStartTime;
            }
            return true;
        }

        private bool VaildateBillingTimeTo()
        {
            if (!string.IsNullOrEmpty(_View.BillingTimeTo))
            {
                if (!DateTime.TryParse(_View.BillingTimeTo, out tempStartTime))
                {
                    _View.BillingTimeMsg = "时间格式输入不正确";
                    return false;
                }
                dtBillingTimeTo = tempStartTime;
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
                dtApplyDateFrom = tempStartTime;
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
                dtApplyDateTo = tempEndTime;
            }
            return true;
        }

        #endregion
    }
}
