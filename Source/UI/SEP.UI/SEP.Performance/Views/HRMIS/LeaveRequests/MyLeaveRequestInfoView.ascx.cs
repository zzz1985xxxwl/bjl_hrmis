using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class MyLeaveRequestInfoView : UserControl, IMyLeaveRequestInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeaveRequestOperationView.btnCancelClick += HideWindow;
        }

        public IMyLeaveRequestListView MyLeaveRequestListView
        {
            get
            {
                return MyLeaveRequestListView1;
            }
        }

        public ILeaveRequestOperationView LeaveRequestOperationView
        {
            get
            {
                return LeaveRequestOperationView1;
            }
        }

        public IMyLeaveRequestConfirmListView MyLeaveRequestConfirmListView
        {
            get
            {
                return MyLeaveRequestConfirmListView1;
            }
        }

        public IMyLeaveRequestConfirmHistoryListView MyLeaveRequestConfirmHistoryListView
        {
            get
            {
                return MyLeaveRequestConfirmHistoryListView1;
            }
        }

        private void HideWindow(object sender, EventArgs e)
        {
            mpeOperation.Hide();
        }

        public bool LeaveRequestOperationViewVisible
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

        public string LeaveRequestConfirmCount
        {
            get
            {
                return lblLeaveRequestConfirmCount.Text;
            }
            set
            {
                lblLeaveRequestConfirmCount.Text = value;
            }
        }

        public string MyLeaveRequestCount
        {
            get
            {
                return lblMyLeaveRequestCount.Text;
            }
            set
            {
                lblMyLeaveRequestCount.Text = value;
            }
        }

        public string MyLeaveRequestConfirmHistoryCount
        {
            get
            {
                return lblMyLeaveRequestConfirmHistory.Text;
            }
            set
            {
                lblMyLeaveRequestConfirmHistory.Text = value;
            }
        }

        public string ResultMessage
        {
            get { return lbResultMessage.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divResultMessage.Style["display"] = "none";
                }
                else
                {
                    divResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }
    }
}