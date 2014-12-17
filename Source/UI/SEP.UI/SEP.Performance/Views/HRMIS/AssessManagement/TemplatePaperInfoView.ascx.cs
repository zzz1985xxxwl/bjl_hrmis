using System;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class TemplatePaperInfoView : System.Web.UI.UserControl, ITemplatePaperInfoView
    {
        public ITemplatePaperListView TemplatePaperListView
        {
            get { return TemplatePaperListView1; }
            set { throw new NotImplementedException(); }
        }

        public ITemplatePaperView TemplatePaperView
        {
            get { return TemplatePaperView1; }
            set { throw new NotImplementedException(); }
        }

        public bool ShowTemplatePaperViewVisible
        {
            get { throw new NotImplementedException(); }
            set
            {
                if (value)
                {
                    mpeTemplatePaper.Show();
                }
                else
                {
                    mpeTemplatePaper.Hide();
                }
            }
        }
    }
}