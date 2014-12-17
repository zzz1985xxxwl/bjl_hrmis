using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimburseConfirmHistoryListPresenter
    {
        private readonly IReimburseConfirmHistoryListView _IReimburseHistoryListView;
        private readonly int _EmployeeID;
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public ReimburseConfirmHistoryListPresenter(int employeeID, IReimburseConfirmHistoryListView iReimburseHistoryListView)
        {
            _EmployeeID = employeeID;
            _IReimburseHistoryListView = iReimburseHistoryListView;
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
            _IReimburseHistoryListView.EmployeeReimburseHistorySource =
                _IReimburseFacade.GetMyAuditingReimburses(_EmployeeID);
        }
        public event EventHandler btnAddClick;
        public event CommandEventHandler btnViewClick;
        private void AttachViewEvent()
        {
            _IReimburseHistoryListView.BindEmployeeReimburseHistorySource += BindGridview;
            _IReimburseHistoryListView.btnViewClick += btnViewClick;
        }
    }
}
