using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class SearchReimburseInfoView : UserControl, ISearchReimburseInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region ISearchReimburseInfoView ≥…‘±

        public ISearchReimburseView SearchReimburseView
        {
            get { return SearchReimburseView1; }
        }

        public IBillingTimeDetailView BillingTimeDetailView
        {
            get { return BillingTimeDetail1; }
        }

        public bool BillingTimeDetailViewVisible
        {
            set
            {
                if (value)
                {
                    mpeSearchReimburse.Show();
                }
                else
                {
                    mpeSearchReimburse.Hide();
                }
            }
        }

        #endregion
    }
}