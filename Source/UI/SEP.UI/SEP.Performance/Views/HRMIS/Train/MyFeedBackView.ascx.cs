using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class MyFeedBackView : UserControl,IMyFeedBackView
    {
        public IFeedBackListView CourseStartView
        {
            get { return FeedBackListViewStrat; }
            set { throw new NotImplementedException(); }
        }

        public IFeedBackListView CourseEndView
        {
            get { return FeedBackListViewEnd; }
            set { throw new NotImplementedException(); }
        }

        public string ErrorMessage
        {
            set
            {
                LblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbSelf.Style["display"] = "none";
                }
                else
                {
                    tbSelf.Style["display"] = "block";
                }
            }
        }
    }
}