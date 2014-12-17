using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeHistory;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeHistoryListPresenter
    {
        private readonly IEmployeeHistoryListView _ItsView;
        private string _StringEmployeeID;
        private int _IntEmployeeID;
        private IEmployeeHistoryFacade _IEmployeeHistoryFacade = InstanceFactory.CreateEmployeeHistoryFacade();
        public EmployeeHistoryListPresenter(IEmployeeHistoryListView itsView, string employeeID)
        {
            _ItsView = itsView;
            EmployeeID = employeeID;
        }

        public string EmployeeID
        {
            get
            {
                return _StringEmployeeID;
            }
            set
            {
                _StringEmployeeID = value;
                int.TryParse(_StringEmployeeID, out _IntEmployeeID);
            }
        }

        public void Init(bool isPostBack)
        {

            AttachViewEvent();

            if (!isPostBack)
            {
                BindEmployeeHistorySource(null, null);
            }
        }

        private void BindEmployeeHistorySource(object sender, EventArgs e)
        {
            _ItsView.EmployeeHistorySource = _IEmployeeHistoryFacade.GetEmployeeHistoryByAccountID(_IntEmployeeID);
        }

        public event CommandEventHandler btnViewClick;
        private void AttachViewEvent()
        {
            _ItsView.btnViewClick += btnViewClick;
            _ItsView.BindEmployeeHistorySource += BindEmployeeHistorySource;
        }
    }
}