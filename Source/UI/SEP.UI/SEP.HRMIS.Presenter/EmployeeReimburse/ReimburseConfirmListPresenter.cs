using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimburseConfirmListPresenter
    {
        private readonly IReimburseConfirmListView _IReimburseConfirmListView;
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly Account _Curroperator = new Account();
        public ReimburseConfirmListPresenter(Account loginUser, IReimburseConfirmListView iReimburseConfirmListView)
        {
            _Curroperator = loginUser;
            _IReimburseConfirmListView = iReimburseConfirmListView;
        }
        public void Init(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                BindGridview(null, null);
            }
        }

        private void BindGridview(object sender, EventArgs e)
        {
            _IReimburseConfirmListView.EmployeeReimbursingSource =
                _IReimburseFacade.GetEmployeeReimbursingByLeadID(_Curroperator);
        }
        public event CommandEventHandler btnUpdateClick;
        public event CommandEventHandler btnViewClick;

        public event DelegateNoParameter UpdateView;
        private void AttachViewEvent()
        {
            _IReimburseConfirmListView.btnViewClick += btnViewClick;
            _IReimburseConfirmListView.BindEmployeeReimbursingSource += BindGridview;
            _IReimburseConfirmListView.QuickPassEvent += QuickPassEvent;
        }

        public void QuickPassEvent(object sender, CommandEventArgs e)
        {
            _IReimburseFacade.QuickPassReimburses(_Curroperator, Convert.ToInt32(e.CommandArgument));
        }
    }
}
