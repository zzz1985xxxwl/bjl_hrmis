 using System;
using SEP.HRMIS.IFacede;
 using SEP.HRMIS.Logic;
 using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse
{
    public class ReimburseUpdatePresenter
    {
        private readonly IReimburseView _IReimburseView;
        //private int _EmployeeID;
        private readonly Account _LoginUser;
        private readonly int _ReimburseID;
        //private IGetReimburse _IGetReimburse = new GetReimburse();
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

        public ReimburseUpdatePresenter(int reimburseID, Account loginUser, IReimburseView iReimburseView)
        {
            _LoginUser = loginUser;
            _ReimburseID = reimburseID;
            _IReimburseView = iReimburseView;
        }

        public void Init(bool isPostBack)
        {
            AttachViewEvent();
            _IReimburseView.SetFormReadonly = false;
            _IReimburseView.Operation = "修改报销单";
            if (!isPostBack)
            {
                try
                {
                    _IReimburseView.Message = string.Empty;

                    _IReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();

                    Employee employee = _IReimburseFacade.GetEmployeeReimburseByEmployeeID(_LoginUser.Id);
                    hrmisModel.Reimburse reimburse = employee.FindReimburseByReimburseID(_ReimburseID);
                    employee.Account.Name = _LoginUser.Name;
                    _IReimburseView.Employee = employee;
                    _IReimburseView.Reimburse = reimburse;

                    _IReimburseView.ReimburseCategoriesEnumID = reimburse.ReimburseCategoriesEnum.Id.ToString();
                    _IReimburseView.PaperCount = reimburse.PaperCount.ToString();
                    _IReimburseView.Destinations = reimburse.Destinations;
                    //_IReimburseView.CustomerName = _ICustomerInfoFacade.GetCustomerInfoByID(Convert.ToInt32(reimburse.CustomerID)).CompanyName;
                    _IReimburseView.ProjectName = reimburse.ProjectName;
                    _IReimburseView.Discription = reimburse.Discription;
                    _IReimburseView.ConsumeDateFrom = reimburse.ConsumeDateFrom.ToShortDateString();
                    _IReimburseView.ConsumeDateFromHour = reimburse.ConsumeDateFrom.Hour.ToString();
                    _IReimburseView.ConsumeDateFromMinute = reimburse.ConsumeDateFrom.Minute.ToString();
                    _IReimburseView.ConsumeDateTo = reimburse.ConsumeDateTo.ToShortDateString();
                    _IReimburseView.ConsumeDateToHour = reimburse.ConsumeDateTo.Hour.ToString();
                    _IReimburseView.ConsumeDateToMinute = reimburse.ConsumeDateTo.Minute.ToString();

                    _IReimburseView.DepartmentName = _LoginUser.Dept.DepartmentName;
                    _IReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                    _IReimburseView.ExchangeRateSource = ExchangeRateLogic.GetExchangeRateDistinctName();
                    _IReimburseView.ExchangeRateID = reimburse.ExchangeRateID;
                    BindReimburseHistorySource();
                }
                catch
                {
                    _IReimburseView.Message = "初始化信息失败";
                }
            }
            // 差旅报销
            if (_IReimburseView.ReimburseCategoriesEnumID == "0")
            {
                _IReimburseView.IsTravelReimburse = true;
            }
            // 非差旅报销
            else if (_IReimburseView.ReimburseCategoriesEnumID == "1")
            {
                _IReimburseView.IsTravelReimburse = false;
            }
        }
        public void btnSaveClick(object source, EventArgs e)
        {
            if (!new ReimburseValidater(_IReimburseView).Validate())
            {
                return;
            }
            Execute(ReimburseStatusEnum.Added);
        }
        public void btnSubmitClick(object source, EventArgs e)
        {
            if (!new ReimburseValidater(_IReimburseView).Validate())
            {
                return;
            }
            Execute(ReimburseStatusEnum.Reimbursing);
        }
        private void Execute(ReimburseStatusEnum reimburseStatusEnum)
        {
            hrmisModel.Reimburse reimburse = _IReimburseView.Reimburse;
            reimburse.ReimburseStatus = reimburseStatusEnum;
            if (reimburseStatusEnum == ReimburseStatusEnum.Reimbursing)
            {
                reimburse.CommitTime = DateTime.Now.ToString();
            }
            reimburse.ReimburseID = _ReimburseID;
            reimburse.Department = _LoginUser.Dept;

            reimburse.ReimburseCategoriesEnum =
                ReimburseCategoriesEnum.GetById(Convert.ToInt32(_IReimburseView.ReimburseCategoriesEnumID));
            DateTime consumeDateFrom = Convert.ToDateTime(_IReimburseView.ConsumeDateFrom);
            DateTime consumeDateTo = Convert.ToDateTime(_IReimburseView.ConsumeDateTo);
            reimburse.ConsumeDateFrom = new DateTime(consumeDateFrom.Year, consumeDateFrom.Month, consumeDateFrom.Day,
                                                     Convert.ToInt32(_IReimburseView.ConsumeDateFromHour),
                                                     Convert.ToInt32(_IReimburseView.ConsumeDateFromMinute), 0);
            reimburse.ConsumeDateTo = new DateTime(consumeDateTo.Year, consumeDateTo.Month, consumeDateTo.Day,
                                                     Convert.ToInt32(_IReimburseView.ConsumeDateToHour),
                                                     Convert.ToInt32(_IReimburseView.ConsumeDateToMinute), 0);
            reimburse.PaperCount = Convert.ToInt32(_IReimburseView.PaperCount);
            reimburse.Destinations = _IReimburseView.Destinations;
            reimburse.ExchangeRateID = _IReimburseView.ExchangeRateID;
            //reimburse.CustomerID = string.Empty;
            reimburse.ProjectName = _IReimburseView.ProjectName;
            reimburse.Discription = _IReimburseView.Discription;
            //UpdateReimburse updateReimburse = new UpdateReimburse(_EmployeeID, reimburse);
            //try
            //{
            //    updateReimburse.Excute();
            //    ToMyReimbursePage(null, null);
            //}
            //catch (ApplicationException ae)
            //{
            //    _IReimburseView.Message = ae.Message;
            //}
            try
            {
                _IReimburseFacade.UpdateReimburse(_LoginUser.Id, reimburse);
                ToMyReimbursePage(null, null);
            }
            catch (ApplicationException ae)
            {
                _IReimburseView.Message = ae.Message;
            }
        }
        public event EventHandler ToMyReimbursePage;
        private void AttachViewEvent()
        {
            _IReimburseView.btnSaveClick += btnSaveClick;
            _IReimburseView.btnSubmitClick += btnSubmitClick;
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
