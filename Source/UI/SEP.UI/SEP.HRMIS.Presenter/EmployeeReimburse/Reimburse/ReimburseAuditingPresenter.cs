using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.IBll;
using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse
{
    public class ReimburseAuditingPresenter
    {
        private readonly IEmployeeReimburseView _IEmployeeReimburseView;
        //private readonly IReimburseView _IReimburseView;
        private readonly Account _Loginuser;
        private readonly int _ReimburseID;
        //private IGetReimburseFacade _IGetReimburse = new GetReimburse();
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly ICustomerInfoFacade _ICustomerInfoFacade = InstanceFactory.CreateCustomerInfoFacade();
        public ReimburseAuditingPresenter(int reimburseID, Account loginuser, IEmployeeReimburseView iEmployeeReimburseView)
        {
            _ReimburseID = reimburseID;
            _IEmployeeReimburseView = iEmployeeReimburseView;
            _Loginuser = loginuser;
        }

        public void Init(bool isPostBack)
        {
            _IEmployeeReimburseView.IReimburseView.Operation = "报销单详情";
            //_IEmployeeReimburseView.IReimburseView.SetFormReadonly = true;
            _IEmployeeReimburseView.IReimburseView.SetComfirmReadonly = true;
            AttachViewEvent();
            if (!isPostBack)
            {
                try
                {
                    //_IEmployeeReimburseView.IReimburseView.Message = string.Empty;
                    //Employee employee = new Employee();
                    //hrmisModel.Reimburse reimburse = _IReimburseFacade.GetReimburseByPkid(_ReimburseID);
                    //Account account = BllInstance.AccountBllInstance.GetAccountById(reimburse.ApplierID);
                    //employee.Account = new Account();
                    //employee.Account.Name = account.Name;
                    //_IEmployeeReimburseView.IReimburseView.Employee = employee;
                    //_IEmployeeReimburseView.IReimburseView.Reimburse = reimburse;
                    //_IEmployeeReimburseView.IReimburseView.DepartmentName = reimburse.Department.DepartmentName;
                    //_IEmployeeReimburseView.IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;

                    _IEmployeeReimburseView.IReimburseView.Message = string.Empty;

                    _IEmployeeReimburseView.IReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();

                    Employee employee = new Employee();
                    hrmisModel.Reimburse reimburse = _IReimburseFacade.GetReimburseByPkid(_ReimburseID);
                    Account account = BllInstance.AccountBllInstance.GetAccountById(reimburse.ApplierID);
                    employee.Account = new Account();
                    employee.Account.Name = account.Name;

                    _IEmployeeReimburseView.IReimburseView.Employee = employee;
                    _IEmployeeReimburseView.IReimburseView.Reimburse = reimburse;

                    _IEmployeeReimburseView.IReimburseView.ReimburseCategoriesEnumID = reimburse.ReimburseCategoriesEnum.Id.ToString();
                    _IEmployeeReimburseView.IReimburseView.PaperCount = reimburse.PaperCount.ToString();
                    _IEmployeeReimburseView.IReimburseView.Destinations = reimburse.Destinations;
                    //_IEmployeeReimburseView.IReimburseView.CustomerName = _ICustomerInfoFacade.GetCustomerInfoByID(reimburse.CustomerID);
                    _IEmployeeReimburseView.IReimburseView.ProjectName = reimburse.ProjectName;
                    _IEmployeeReimburseView.IReimburseView.Discription = reimburse.Discription;
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateFrom = reimburse.ConsumeDateFrom.ToShortDateString();
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateFromHour = reimburse.ConsumeDateFrom.Hour.ToString();
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateFromMinute = reimburse.ConsumeDateFrom.Minute.ToString();
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateTo = reimburse.ConsumeDateTo.ToShortDateString();
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateToHour = reimburse.ConsumeDateTo.Hour.ToString();
                    _IEmployeeReimburseView.IReimburseView.ConsumeDateToMinute = reimburse.ConsumeDateTo.Minute.ToString();
                    _IEmployeeReimburseView.IReimburseView.DepartmentName = reimburse.Department.DepartmentName;
                    _IEmployeeReimburseView.IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                    _IEmployeeReimburseView.IReimburseView.SetFormReadonly = true;
                    _IEmployeeReimburseView.IReimburseView.SetDeleteFormButton = 3;
                    _IEmployeeReimburseView.IReimburseView.ExchangeRateSource = ExchangeRateLogic.GetExchangeRateDistinctName();
                    _IEmployeeReimburseView.IReimburseView.ExchangeRateID = reimburse.ExchangeRateID;
                    BindReimburseHistorySource();
                }
                catch
                {
                    _IEmployeeReimburseView.IReimburseView.Message = "初始化信息失败";
                }
            }
            // 差旅报销
            if (_IEmployeeReimburseView.IReimburseView.ReimburseCategoriesEnumID == "0")
            {
                _IEmployeeReimburseView.IReimburseView.IsTravelReimburse = true;
            }
            // 非差旅报销
            else if (_IEmployeeReimburseView.IReimburseView.ReimburseCategoriesEnumID == "1")
            {
                _IEmployeeReimburseView.IReimburseView.IsTravelReimburse = false;
            }
        }

        public event EventHandler ToMyReimbursePage;
        private void AttachViewEvent()
        {
            _IEmployeeReimburseView.IReimburseView.btnPassClick += FinishEvent;
            _IEmployeeReimburseView.IReimburseView.btnIntermitClick += IntermitEvent;
            //_IEmployeeReimburseView.IReimburseView.btnDetailClick += btnDetailClickEvent;

            //_IEmployeeReimburseView.IReimburseItemView.btnOKClick += btnOKClickEvent;
            //_IEmployeeReimburseView.IReimburseItemView.btnCancelOnClientClick = "return CloseModalPopupExtender('" + _IEmployeeReimburseView.divMPEReimburseClientID +
            //                                   "');";
            //_IEmployeeReimburseView.IReimburseItemView.btnCancelClick += btnCancelClickEvent;
            new ReimburseItemEventsHandler(_IEmployeeReimburseView);
        }


        public void FinishEvent(string reimburseID)
        {
            try
            {
                if (!new ReimburseValidater(_IEmployeeReimburseView.IReimburseView).Validate(isAuditing:true))
                {
                    return;
                }
                //if (_IEmployeeReimburseView.IReimburseView.IsTravelReimburse)
                //{
                //    // 客户不能为空
                //    if (string.IsNullOrEmpty(_IEmployeeReimburseView.IReimburseView.CustomerName.Trim()))
                //    {
                //        _IEmployeeReimburseView.IReimburseView.CustomerNameMsg = ReimburseUtility._IsEmpty;
                //        return;
                //    }

                //    if (
                //        _ICustomerInfoFacade.GetCustomerIDInfoByName(
                //            _IEmployeeReimburseView.IReimburseView.CustomerName.Trim()) == null)
                //    {
                //        _IEmployeeReimburseView.IReimburseView.CustomerNameMsg = ReimburseUtility._IsNotCustomer;
                //        return;
                //    }
                //}

                DateTime consumeDateFrom = Convert.ToDateTime(_IEmployeeReimburseView.IReimburseView.ConsumeDateFrom);
                DateTime consumeDateTo = Convert.ToDateTime(_IEmployeeReimburseView.IReimburseView.ConsumeDateTo);
                DateTime tempConsumeDateFrom = new DateTime(consumeDateFrom.Year, consumeDateFrom.Month, consumeDateFrom.Day,
                                                         Convert.ToInt32(_IEmployeeReimburseView.IReimburseView.ConsumeDateFromHour),
                                                         Convert.ToInt32(_IEmployeeReimburseView.IReimburseView.ConsumeDateFromMinute), 0);
                DateTime tempConsumeDateTo = new DateTime(consumeDateTo.Year, consumeDateTo.Month, consumeDateTo.Day,
                                                         Convert.ToInt32(_IEmployeeReimburseView.IReimburseView.ConsumeDateToHour),
                                                         Convert.ToInt32(_IEmployeeReimburseView.IReimburseView.ConsumeDateToMinute), 0);

                decimal outcityallowance = 0;
                decimal outcitydays = 0;
                if (!string.IsNullOrEmpty(_IEmployeeReimburseView.IReimburseView.OutCityAllowance))
                {
                    outcityallowance = Convert.ToDecimal(_IEmployeeReimburseView.IReimburseView.OutCityAllowance);
                }
                if (!string.IsNullOrEmpty(_IEmployeeReimburseView.IReimburseView.OutCityDays))
                {
                    outcitydays = Convert.ToDecimal(_IEmployeeReimburseView.IReimburseView.OutCityDays);
                }
                _IReimburseFacade.QuickPassReimburses(_Loginuser, Convert.ToInt32(reimburseID),
                                                      Convert.ToInt32(_IEmployeeReimburseView.IReimburseView.PaperCount),
                                                      _IEmployeeReimburseView.IReimburseView.Destinations, string.Empty,

                                                      _IEmployeeReimburseView.IReimburseView.ProjectName,
                                                      tempConsumeDateFrom, tempConsumeDateTo, _IEmployeeReimburseView.IReimburseView.Remark, outcityallowance, outcitydays);
            }
            catch (Exception ex)
            {
                _IEmployeeReimburseView.IReimburseView.Message = ex.Message;
            }
        }

        public void IntermitEvent(string reimburseID)
        {
            try
            {
                Employee curroperator = new Employee(new Account(), "", "", EmployeeTypeEnum.All, null, null);
                curroperator.Account.Id = _Loginuser.Id;
                _IReimburseFacade.ReturnOrCancelReimburses(Convert.ToInt32(reimburseID), curroperator);
            }
            catch (Exception ex)
            {
                _IEmployeeReimburseView.IReimburseView.Message = ex.Message;
            }
        }

        public void BindReimburseHistorySource()
        {
            try
            {
                _IEmployeeReimburseView.IReimburseView.ReimburseHistorySource = _IReimburseFacade.GetReimbursesHistory(_ReimburseID);
            }
            catch (Exception)
            {
                _IEmployeeReimburseView.IReimburseView.Message = "初始化信息失败";
            }

        }

        //private void btnDetailClickEvent(string e)
        //{
        //    _IEmployeeReimburseView.IReimburseItemView.OperationType = "detail";
        //    _IEmployeeReimburseView.IReimburseItemView.ReimburseItemID = e;
        //    new ReimburseItemDetailPresenter(_IEmployeeReimburseView.IReimburseItemView, e).InitView();
        //    _IEmployeeReimburseView.ReimburseItemVisiable = true;
        //}

        //private void btnCancelClickEvent(object sender, EventArgs e)
        //{
        //    _IEmployeeReimburseView.ReimburseItemVisiable = false;
        //}

        //private void btnOKClickEvent(object sender, EventArgs e)
        //{
        //    if (_IEmployeeReimburseView.IReimburseItemView.ActionSuccess)
        //    {
        //        _IEmployeeReimburseView.ReimburseItemVisiable = false;
        //        _IEmployeeReimburseView.IReimburseView.ReimburseItemSource = _IEmployeeReimburseView.IReimburseItemView.ReimburseItemSource;
        //    }
        //    else
        //    {
        //        _IEmployeeReimburseView.ReimburseItemVisiable = true;
        //    }
        //}
    }
}
