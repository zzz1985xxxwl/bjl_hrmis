using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.Performance.Views.HRMIS.Nationalitys
{
    public partial class NationalityInfoView : UserControl, INationalityInfoView
    {
        public INationalityListView NationalityListView
        {
            get
            {
                return NationalityListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public INationalityView NationalityView
        {
            get
            {
                return NationalityView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool NationalityViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    mpeNationality.Show();
                }
                else
                {
                    mpeNationality.Hide();
                }
            }
        }
    }
}