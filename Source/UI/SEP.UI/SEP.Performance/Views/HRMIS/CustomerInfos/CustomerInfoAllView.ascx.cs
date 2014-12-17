using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;

namespace SEP.Performance.Views.HRMIS.CustomerInfos
{
    public partial class CustomerInfoAllView : UserControl, ICustomerInfoAllView
    {

        public ICustomerInfoListView CustomerInfoListView
        {
            get { return CustomerInfoListView1; }
        }

        public ICustomerInfoView CustomerInfoView
        {
            get { return CustomerInfoView1; }
        }

        public bool ShowCustomerInfoViewVisible
        {
            set
            {
                if (value)
                {
                    mpeInfo.Show();
                }
                else
                {
                    mpeInfo.Hide();
                }
            }
        }
    }
}