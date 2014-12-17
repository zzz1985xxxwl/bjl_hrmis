using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.OverWorks;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class AllOverWork : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad(IsPostBack);
        }

        private void PageLoad(bool ispostback)
        {
            new OverWorkSelfListPresenter(OverWorkSelfListView1, LoginUser, ispostback);
            new OverWorkConfirmHistroyPresenter(OverWorkConfirmHistroyView1, LoginUser, ispostback);
            new OverWorkConfirmPresenter(OverWorkConfirmListView1, LoginUser, ispostback);
            lblOverWorkConfirmCount.Text = OverWorkConfirmListView1.ListCount;
            lblOverWorkHistoryCount.Text = OverWorkConfirmHistroyView1.ListCount;
            lblOverWorkCount.Text = OverWorkSelfListView1.ListCount;
            OverWorkConfirmListView1._ShowWindowForConfirmOperation = ShowConfirmOperation;
            OverOperationView1.UpdateListWindow += UpdateListWindow;
            OverWorkSelfListView1.btnFastCancelClick += ShowCancelOperation;
            OverWorkConfirmListView1._UpdateListWindow += UpdatePanel;
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
            new ConfirmOverWork(OverOperationView1, false, LoginUser, Convert.ToInt32(id));
            status = "confirm";
            mpeOperation.Show();
        }

        private void ShowCancelOperation(string id)
        {
            new CancelOverWork(OverOperationView1, false, LoginUser, Convert.ToInt32(id));
            status = "cancel";
            mpeOperation.Show();
        }

        public bool OverWorkOperationViewVisible
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
                new ConfirmOverWork(OverOperationView1);
            }
            else if (status == "cancel")
            {
                new CancelOverWork(OverOperationView1);
            }
        }

        private void UpdateListWindow(object source, EventArgs e)
        {
            if (string.IsNullOrEmpty(OverOperationView1.ResultMessage) && string.IsNullOrEmpty(OverOperationView1.RemarkMessage))
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