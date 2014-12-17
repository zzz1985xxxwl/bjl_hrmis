using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimburseHistoryListPresenter
    {
        private readonly IReimburseHistoryListView _IReimburseHistoryListView;
        private int _EmployeeID;
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public ReimburseHistoryListPresenter(int employeeID, IReimburseHistoryListView iReimburseHistoryListView)
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
            //IGetReimburse iGetReimburse = new GetReimburse();
            _IReimburseHistoryListView.EmployeeReimburseHistorySource =
                _IReimburseFacade.GetEmployeeReimburseHistoryByEmployeeID(_EmployeeID);
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
