using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse
{
    public class ReimburseAddPresenter : PresenterCore.BasePresenter
    {
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly IReimburseView _IReimburseView;
        //private int _EmployeeID;
        //private GetEmployee _GetEmployee = new GetEmployee();
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        private readonly Account _LoginUser;

        public ReimburseAddPresenter(Account loginUser , IReimburseView iReimburseView)
            : base(loginUser)
        {
            _LoginUser = loginUser;
            //_EmployeeID = employeeID;
            _IReimburseView = iReimburseView;
            //_IReimburseView.Reimburse.Department = loginUser.Dept;
        }
        public void Init(bool isPostBack)
        {
            AttachViewEvent();
            _IReimburseView.SetFormReadonly = false;
            _IReimburseView.Operation = "新增报销单";
            _IReimburseView.SetOutCityVisible = false;
            if (!isPostBack)
            {
                _IReimburseView.ReimburseCategoriesEnumDataSrc = ReimburseCategoriesEnum.GetAll();
                _IReimburseView.ConsumeDateFrom = DateTime.Now.ToShortDateString();
                _IReimburseView.ConsumeDateFromHour = DateTime.Now.Hour.ToString();
                _IReimburseView.ConsumeDateFromMinute = DateTime.Now.Minute.ToString();
                _IReimburseView.ConsumeDateTo = _IReimburseView.ConsumeDateFrom;
                _IReimburseView.ConsumeDateToHour = _IReimburseView.ConsumeDateFromHour;
                _IReimburseView.ConsumeDateToMinute = _IReimburseView.ConsumeDateFromMinute;
                _IReimburseView.Message = string.Empty;

                _IReimburseView.Employee = _IEmployeeFacade.GetEmployeeByAccountID(LoginUser.Id);
                _IReimburseView.DepartmentName = LoginUser.Dept.DepartmentName;
                _IReimburseView.ApplyDate = DateTime.Now.ToShortDateString();
                _IReimburseView.ExchangeRateSource = ExchangeRateLogic.GetExchangeRateDistinctName();
                //if (_IReimburseView.ReimburseItemSource == null)
                //{
                _IReimburseView.ReimburseItemSource = new List<hrmisModel.ReimburseItem>();
                //}
                //else
                //{
                //    _IReimburseView.ReimburseItemSource = _IReimburseView.ReimburseItemSource;
                //}
                _IReimburseView.ReimburseHistorySource = null;
            }
            // Add bjl start
            // 差旅报销
            if (_IReimburseView.ReimburseCategoriesEnumID == "0")
            {
                _IReimburseView.IsTravelReimburse = true;
            }
            // 非差旅报销
            else if(_IReimburseView.ReimburseCategoriesEnumID == "1")
            {
                _IReimburseView.IsTravelReimburse = false;
            }
            // Add bjl end
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
            //reimburse.CustomerID = string.Empty;
            reimburse.ProjectName = _IReimburseView.ProjectName;
            reimburse.ExchangeRateID = _IReimburseView.ExchangeRateID;
            reimburse.Discription = _IReimburseView.Discription;
            //AddReimburse addReimburse = new AddReimburse(LoginUser.Id, reimburse);
            //try
            //{
            //    addReimburse.Excute();
            //    ToMyReimbursePage(null, null);
            //}
            //catch (ApplicationException ae)
            //{
            //    _IReimburseView.Message = ae.Message;
            //}
            try
            {
                _IReimburseFacade.AddReimburse(LoginUser.Id, reimburse);
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

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
