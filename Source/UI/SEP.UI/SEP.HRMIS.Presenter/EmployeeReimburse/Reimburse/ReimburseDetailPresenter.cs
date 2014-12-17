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
    public class ReimburseDetailPresenter
    {
        private readonly IReimburseView _IReimburseView;
        //private int _EmployeeID;
        private int _ReimburseID;
        //private IGetReimburseFacade _IGetReimburse = new GetReimburse();
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly ICustomerInfoFacade _ICustomerInfoFacade = InstanceFactory.CreateCustomerInfoFacade();
        public ReimburseDetailPresenter(int reimburseID, IReimburseView iReimburseView)
        {
            _ReimburseID = reimburseID;
            _IReimburseView = iReimburseView;
        }

        public void Init(bool isPostBack)
        {
            _IReimburseView.Operation = "报销单详情";
            _IReimburseView.SetFormReadonly = true;
            AttachViewEvent();
            if (!isPostBack)
            {
                try
                {
                    //_IReimburseView.Message = string.Empty;
                    //Employee employee = _IReimburseFacade.GetEmployeeReimburseByEmployeeID(_Loginuser.Id);
                    //Account account = BllInstance.AccountBllInstance.GetAccountById(_Loginuser.Id);
                    //employee.Account.Name = account.Name;
                    //hrmisModel.Reimburse reimburse = employee.FindReimburseByReimburseID(_ReimburseID);

                    //_IReimburseView.Employee = employee;
                    //_IReimburseView.Reimburse = reimburse;
                    //_IReimburseView.DepartmentName = reimburse.Department.DepartmentName;
                    //_IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                    //_IReimburseView.SetDeleteFormButton = true;

                    _IReimburseView.Message = string.Empty;

                    _IReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();

                    Employee employee = new Employee();
                    hrmisModel.Reimburse reimburse = _IReimburseFacade.GetReimburseByPkid(_ReimburseID);
                    Account account = BllInstance.AccountBllInstance.GetAccountById(reimburse.ApplierID);
                    employee.Account = new Account();
                    employee.Account.Name = account.Name;

                    _IReimburseView.Employee = employee;
                    _IReimburseView.Reimburse = reimburse;

                    _IReimburseView.ReimburseCategoriesEnumID = reimburse.ReimburseCategoriesEnum.Id.ToString();
                    _IReimburseView.PaperCount = reimburse.PaperCount.ToString();
                    _IReimburseView.Destinations = reimburse.Destinations;

                    int tempCustomerID;
                    //if(int.TryParse(reimburse.CustomerID,out tempCustomerID))
                    //{
                    //    _IReimburseView.CustomerName = _ICustomerInfoFacade.GetCustomerInfoByID(tempCustomerID).CompanyName;
                    //}
                    _IReimburseView.SetDetailReadonly = true;
                    _IReimburseView.ProjectName = reimburse.ProjectName;
                    _IReimburseView.Discription = reimburse.Discription;
                    _IReimburseView.ConsumeDateFrom = reimburse.ConsumeDateFrom.ToShortDateString();
                    _IReimburseView.ConsumeDateFromHour = reimburse.ConsumeDateFrom.Hour.ToString();
                    _IReimburseView.ConsumeDateFromMinute = reimburse.ConsumeDateFrom.Minute.ToString();
                    _IReimburseView.ConsumeDateTo = reimburse.ConsumeDateTo.ToShortDateString();
                    _IReimburseView.ConsumeDateToHour = reimburse.ConsumeDateTo.Hour.ToString();
                    _IReimburseView.ConsumeDateToMinute = reimburse.ConsumeDateTo.Minute.ToString();
                    _IReimburseView.DepartmentName = reimburse.Department.DepartmentName;
                    _IReimburseView.OutCityAllowance = reimburse.OutCityAllowance.ToString();
                    _IReimburseView.OutCityDays = reimburse.OutCityDays.ToString();
                    _IReimburseView.Remark = reimburse.Remark;
                    _IReimburseView.Discription = reimburse.Discription;
                    _IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                    _IReimburseView.SetDeleteFormButton = 2;
                    _IReimburseView.ExchangeRateSource = ExchangeRateLogic.GetExchangeRateDistinctName();
                    _IReimburseView.ExchangeRateID = reimburse.ExchangeRateID;
                    BindReimburseHistorySource();
                }
                catch  (Exception ex)
                {
                    _IReimburseView.Message = ex.Message;
                }
            }
            // 差旅报销
            if (_IReimburseView.ReimburseCategoriesEnumID == ReimburseCategoriesEnum.TravelReimburse.Id.ToString())
            {
                _IReimburseView.IsTravelReimburse = true;
            }
            // 非差旅报销
            else if (_IReimburseView.ReimburseCategoriesEnumID == ReimburseCategoriesEnum.UnTravelReimburse.Id.ToString())
            {
                _IReimburseView.IsTravelReimburse = false;
            }
        }

        public event EventHandler ToMyReimbursePage;
        private void AttachViewEvent()
        {
            _IReimburseView.btnOKClick += ToMyReimbursePage;
            _IReimburseView.btnCancelClick += ToMyReimbursePage;
            _IReimburseView.BindReimburseHistorySource += BindReimburseHistorySource;
        }

        public void BindReimburseHistorySource()
        {
            try
            {
                _IReimburseView.ReimburseHistorySource = _IReimburseFacade.GetReimbursesHistory(_ReimburseID);
            }
            catch (Exception)
            {
                _IReimburseView.Message = "初始化信息失败";
            }

        }

    }
}
