using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.SystemErrors;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors
{
    public partial class DutyCalssErrorListView : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new DutyCalssErrorListPresenter(SystemErrorListView1, Session[SessionKeys.LOGININFO] as Account,
                                            PageIsPostBack);
        }

        private bool PageIsPostBack
        {
            get
            {
                if (ViewState["IsFisrt"] == null)
                {
                    ViewState["IsFisrt"] = "added";
                    return false;
                }
                return IsPostBack;
            }
        }
    }
}