using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class MyTrainApplicationInfoView : UserControl, IMyTrainApplicationInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationOperationView1.btnCancelClick += HideWindow;
        }

        public IMyTrainApplicationView MyTrainApplicationListView
        {
            get { return MyTrainApplicationView1; }
        }

        public ITrainApplicationOperatorView OperationView
        {
            get { return TrainApplicationOperationView1; }
        }

        public ITrainApplicationConfirmListView ConfirmListView
        {
            get { return TrainApplicationConfirmListView1; }
        }

        public ITrainApplicationConfirmHistoryView ConfirmHistoryListView
        {
            get { return TrainApplicationConfirmHistoryView1; }
        }

        public bool OperationViewVisible
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

        public string TrainApplicationConfirmCount
        {
            get
            {
                return lblConfirmCount.Text;
            }
            set
            {
                lblConfirmCount.Text = value;
            }
        }

        public string MyTrainApplicationCount
        {
            get { return lblMyTrainApplicationCount.Text; }
            set { lblMyTrainApplicationCount.Text=value; }
        }

        public string TrainApplicationConfirmHistoryCount
        {
            get { return lblMyConfirmHistory.Text; }
            set { lblMyConfirmHistory.Text=value; }
        }

        public string ResultMessage
        {
            get { return lbResultMessage.Text; }
            set { lbResultMessage.Text=value; }
        }

        private void HideWindow(object sender, EventArgs e)
        {
            mpeOperation.Hide();
        }
    }
}