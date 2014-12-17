using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;

namespace SEP.Performance.Views.HRMIS.CompanyTeleBooks
{
    public partial class CompanyLinkManInfo : UserControl, ICompanyLinkManInfoView
    {
        public ICompanyLinkListView LinkManListView
        {
            get { return CompanyLinkManListView1; }
            set { throw new System.NotImplementedException(); }
        }

        public ICompnayLinkManView LinkManView
        {
            get { return CompanyLinkManView1; }
            set { throw new System.NotImplementedException(); }
        }

        public bool LinkManViewVisible
        {
            get { throw new System.NotImplementedException(); }
            set
            {
                if (value)
                {
                    mpeCompanyLinkMan.Show();
                }
                else
                {
                    mpeCompanyLinkMan.Hide();
                }
            }
        }
    }
}