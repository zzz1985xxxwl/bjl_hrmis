using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse
{
    public class ReimburseDeletePresenter
    {
        private readonly IReimburseView _IReimburseView;
        //private int _EmployeeID;
        private readonly Account _LoginUser;
        private readonly int _ReimburseID;
        //private IGetReimburse _IGetReimburse = new GetReimburse();
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public ReimburseDeletePresenter(int reimburseID, Account loginUser, IReimburseView iReimburseView)
        {
            _LoginUser = loginUser;
            _ReimburseID = reimburseID;
            _IReimburseView = iReimburseView;
        }

        public void Init(bool isPostBack)
        {
            _IReimburseView.Operation = "删除报销单";
            _IReimburseView.SetFormReadonly = true;
            _IReimburseView.SetDetailReadonly = true;
            AttachViewEvent();
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
                    //_IReimburseView.CustomerName = reimburse.CustomerName;
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
                    _IReimburseView.SetDeleteFormButton = 2;
                    _IReimburseView.ExchangeRateSource = ExchangeRateLogic.GetExchangeRateDistinctName();
                    _IReimburseView.ExchangeRateID = reimburse.ExchangeRateID;
                    BindReimburseHistorySource();
                }
                catch
                {
                    _IReimburseView.Message = "初始化信息失败";
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
        }

        public void btnDeleteClick(object source, EventArgs e)
        {
            //DeleteReimburse deleteReimburse = new DeleteReimburse(_EmployeeID, _ReimburseID);
            //try
            //{
            //    deleteReimburse.Excute();
            //    ToMyReimbursePage(null, null);
            //}
            //catch (ApplicationException ae)
            //{
            //    _IReimburseView.Message = ae.Message;
            //}
            try
            {
                _IReimburseFacade.DeleteReimburse(_LoginUser.Id, _ReimburseID);
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
            _IReimburseView.btnOKClick += btnDeleteClick;
            _IReimburseView.btnCancelClick += ToMyReimbursePage;
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
