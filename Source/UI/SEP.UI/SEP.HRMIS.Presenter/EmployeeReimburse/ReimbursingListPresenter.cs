using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class ReimbursingListPresenter
    {
        private readonly IReimbursingListView _IReimbursingListView;
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        private readonly Account _Curroperator;
        private readonly int _AccountID;
        public ReimbursingListPresenter(Account loginUser, IReimbursingListView iReimbursingListView)
        {
            _Curroperator = loginUser;
            _AccountID = loginUser.Id;
            _IReimbursingListView = iReimbursingListView;
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
            _IReimbursingListView.EmployeeReimbursingSource =
                _IReimburseFacade.GetEmployeeReimbursingByEmployeeID(_AccountID);
        }
        public event EventHandler btnAddClick;
        public event CommandEventHandler btnUpdateClick;
        public event CommandEventHandler btnDeleteClick;
        public event CommandEventHandler btnViewClick;
        private void AttachViewEvent()
        {
            _IReimbursingListView.btnAddClick += btnAddClick;
            _IReimbursingListView.btnUpdateClick += btnUpdateClick;
            _IReimbursingListView.btnDeleteClick += btnDeleteClick;
            _IReimbursingListView.btnViewClick += btnViewClick;
            _IReimbursingListView.BindEmployeeReimbursingSource += BindGridview;
        }
    }
}
