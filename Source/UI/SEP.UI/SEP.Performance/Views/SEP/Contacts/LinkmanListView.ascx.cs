using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.IPresenter.IContact;

namespace SEP.Performance.Views.SEP.Contacts
{
    public partial class LinkmanListView : UserControl
    {
        private ComService.ServiceModels.Contact _contactSrc;
        private void Refresh(int pageIndex)
        {
            if (_contactSrc == null)
                _contactSrc = (ComService.ServiceModels.Contact)ViewState["contact"];

            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = _contactSrc.Linkmans;
            pds.AllowPaging = true;
            pds.PageSize = listLinkMan.RepeatColumns * 5;

            pageIndex = pageIndex < 0 ? 0 : pageIndex;
            pageIndex = pageIndex >= pds.PageCount ? pds.PageCount - 1 : pageIndex;

            pds.CurrentPageIndex = pageIndex;
            lbtPrevPage.Enabled = !pds.IsFirstPage;
            lbtNextPage.Enabled = !pds.IsLastPage;

            listLinkMan.DataSource = pds;
            listLinkMan.DataBind();
            if (IsCompany)
            {
                foreach (DataListItem dl in listLinkMan.Items)
                {
                    ImageButton button = (ImageButton) dl.FindControl("Btndelete");
                    button.Visible = false;
                    button.Enabled = false;
                }
            }
            tbPage.Style["display"] = (lbtPrevPage.Enabled || lbtNextPage.Enabled) ? "block" : "none";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_contactSrc == null && Visible)
                _contactSrc = (ComService.ServiceModels.Contact)ViewState["contact"];

            if (ViewState["pageindex"] == null)
            {
                CurrPageIndex = 0;
            }
        }
        protected void Update_Command(object sender, CommandEventArgs e)
        {
            if (DlgUpdate != null)
                DlgUpdate(_contactSrc.GetLinkmanById(new Guid(e.CommandArgument.ToString())));
        }
        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            if (DlgDelete != null)
                DlgDelete(new Guid(e.CommandArgument.ToString()));
        }
        protected void Page_Command(object sender, CommandEventArgs e)
        {
            CurrPageIndex = e.CommandArgument.ToString() == "Prev" ? CurrPageIndex - 1 : CurrPageIndex + 1;
        }

        public DelegateLinkman DlgUpdate;
        public DelegeteGuid DlgDelete;
        public ComService.ServiceModels.Contact ContactSrc
        {
            get
            {
                if(_contactSrc == null)
                    _contactSrc = (ComService.ServiceModels.Contact)ViewState["contact"];

                return _contactSrc;
            }
            set
            {
                _contactSrc = value;
                ViewState["contact"] = value;
            }
        }
        public int CurrPageIndex
        {
            get
            {
                return (int)ViewState["pageindex"];
            }
            set
            {
                ViewState["pageindex"] = value;
                Refresh(value);
            }
        }

        public bool IsCompany
        {
            get
            {
                return Session["TeleBookIsCompany"].Equals("Company");
                //return _isCompany;
            }
        }
    }
}