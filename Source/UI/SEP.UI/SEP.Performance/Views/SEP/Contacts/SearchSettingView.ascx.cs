using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IContact;

namespace SEP.Performance.Views.SEP.Contacts
{
    public partial class SearchSettingView : UserControl
    {
        public DelegateLinkmanSearch DlgSearchByName;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    bool hh = IsPostBack;
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DlgSearchByName != null)
                DlgSearchByName(txtName.Text.Trim());

            txtName.Text = String.Empty;
        }
    }
}