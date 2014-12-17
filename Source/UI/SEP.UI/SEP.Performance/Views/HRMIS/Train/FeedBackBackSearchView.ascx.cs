using System;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class FeedBackBackSearchView : System.Web.UI.UserControl, IFeedBackBackSearchView
    {
        #region IFeedBackBackSearchView ≥…‘±

        public string ResultMessage
        {
            set { LblMessage.Text = value; }
            get { return LblMessage.Text; }
        }

        public string OperationMessage
        {
            set { lbOperationType.Text = value; }
            get { return lbOperationType.Text; }
        }

        public string TrainCourese
        {
            get
            {
                return txtCourse.Text.Trim();
            }
            set
            {
                txtCourse.Text = value;
            }
        }

        public string FBEmployee
        {
            get
            {
                return tbName.Text.Trim();
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string FBTimeFrom
        {
            get
            {



                return tbStartFrom.Text;
            }
            set
            {
                tbStartFrom.Text = value;
            }
        }

        public string FBTimeTo
        {
            get
            {

                return tbStartTo.Text;
            }
            set
            {
                tbStartTo.Text = value;
            }
        }


        public IFeedBackListView listView
        {
            get
            {
                return FeedBackListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Status
        {
            get
            {
                if (string.IsNullOrEmpty(txtFeedBackStatus.SelectedValue))
                {
                    return "-1";
                }
                else
                    return txtFeedBackStatus.SelectedValue;
            }
            set { txtFeedBackStatus.SelectedItem.Value = value; }
        }


        //public List<string> StatusSource
        //{
        //    get
        //    {
        //        throw new Exception("The method or operation is not implemented.");
        //    }
        //    set
        //    {
        //        txtFeedBackStatus.Items.Clear();
        //        foreach (string statusType in value)
        //        {
        //            txtFeedBackStatus.Items.Add(new ListItem(statusType, statusType.ToString(), true));
        //        }
        //    }
        //}

        public bool SetCourseName
        {
            set { txtCourse.ReadOnly = value; }
        }

        // public event DelegateNoParameter btnSearchClick;


        #endregion
        public EventHandler SearchEvent;
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent(sender, e);
        }
    }
}