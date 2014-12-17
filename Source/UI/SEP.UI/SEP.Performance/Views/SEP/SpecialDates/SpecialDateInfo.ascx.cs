using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Performance.Views.SEP.SpecialDates
{
    public partial class SpecialDateInfo : UserControl, ISpecialDateInfoView
    {
        public ISpecialDateView SpecialDateView
        {
            get
            {
                return SetSpecialDateView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public ISpecialDateEditView SpecialDateEditView
        {
            get
            {
                return SpecialDateEditView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool SpecialDateEditViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    mpespecialDateEdit.Show();
                }
                else
                {
                    mpespecialDateEdit.Hide();
                }
            }
        }
    }
}