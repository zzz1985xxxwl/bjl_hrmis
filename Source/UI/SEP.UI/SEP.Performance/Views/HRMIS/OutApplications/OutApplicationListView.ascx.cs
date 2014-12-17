using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.OutApplications;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class AllOutApplication : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad(IsPostBack);
        }

        private void PageLoad(bool ispostback)
        {
            new OutApplicationSelfListPresenter(OutApplicationSelfListView1, LoginUser, ispostback);
            new OutApplicationConfirmHistroyPresenter(OutApplicationConfirmHistroyView1, LoginUser, ispostback);
            new OutApplicationConfirmPresenter(OutApplicationConfirmListView1, LoginUser, ispostback);
            lblOutApplicationConfirmCount.Text = OutApplicationConfirmListView1.ListCount;
            lblOutApplicationHistoryCount.Text = OutApplicationConfirmHistroyView1.ListCount;
            lblOutApplicationCount.Text = OutApplicationSelfListView1.ListCount;
            OutApplicationConfirmListView1._ShowWindowForConfirmOperation = ShowConfirmOperation;
            OperationView1.UpdateListWindow += UpdateListWindow;
            OutApplicationSelfListView1.btnFastCancelClick += ShowCancelOperation;
            OutApplicationConfirmListView1._UpdateListWindow += UpdatePanel;
            InitOperation();
        }

        private string status
        {
            get
            {
                if (ViewState["status"] == null)
                {
                    return "confirm";
                }
                else
                {
                    return ViewState["status"].ToString();
                }
            }
            set { ViewState["status"] = value; }
        }

        private Account _LoginUser;

        public Account LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }

        private void ShowConfirmOperation(string id)
        {
            new ConfirmOutApplication(OperationView1, false, LoginUser, Convert.ToInt32(id));
            status = "confirm";
            mpeOperation.Show();
        }

        private void ShowCancelOperation(string id)
        {
            new CancelOutApplication(OperationView1, false, LoginUser, Convert.ToInt32(id));
            status = "cancel";
            mpeOperation.Show();
        }

        public bool OutApplicationOperationViewVisible
        {
            set
            {
                if (value)
                {
                    UpdatePanel1.Update();
                    mpeOperation.Show();
                }
                else
                {
                    mpeOperation.Hide();
                }
            }
        }

        private void InitOperation()
        {
            if (status == "confirm")
            {
                new ConfirmOutApplication(OperationView1);
            }
            else if (status == "cancel")
            {
                new CancelOutApplication(OperationView1);
            }
        }

        private void UpdateListWindow(object source, EventArgs e)
        {
            if (string.IsNullOrEmpty(OperationView1.ResultMessage) && string.IsNullOrEmpty(OperationView1.RemarkMessage))
            {
                UpdatePanel();
                mpeOperation.Hide();
            }
            else
            {
                mpeOperation.Show();
            }
        }

        private void UpdatePanel()
        {
            PageLoad(false);
            UpdatePanel1.Update();
        }
    }
}