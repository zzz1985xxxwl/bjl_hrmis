using System;
using System.Web.UI;
using ComService.ServiceModels;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.SEP.Contacts
{
    public partial class LinkmanView : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isCompany = Session["TeleBookIsCompany"].Equals("Company");
            txtName.ReadOnly = isCompany;
            txtMobil.ReadOnly = isCompany;
            txtHome.ReadOnly = isCompany;
            txtOffice.ReadOnly = isCompany;
            txtEmail.ReadOnly = isCompany;
        }

        private Linkman _currentLinkman;
        /// <summary>
        /// 显示联系人
        /// </summary>
        private void ShowDetail()
        {
            txtName.Text = _currentLinkman.Name;
            ViewState["linkmanid"] = _currentLinkman.Id;

            LinkmanDetail temp = _currentLinkman.GetLinkmanDetailByType(InfoType.Num_Mobile);
            txtMobil.Text = temp.Value;
            ViewState["mobile"] = temp.Id;

            temp = _currentLinkman.GetLinkmanDetailByType(InfoType.Addr_Home);
            txtHome.Text = temp.Value;
            ViewState["home"] = temp.Id;

            temp = _currentLinkman.GetLinkmanDetailByType(InfoType.Addr_Work);
            txtOffice.Text = temp.Value;
            ViewState["work"] = temp.Id;

            temp = _currentLinkman.GetLinkmanDetailByType(InfoType.Addr_Email);
            txtEmail.Text = temp.Value;
            ViewState["email"] = temp.Id;

        }
        /// <summary>
        /// 获取联系人
        /// </summary>
        private void Refresh()
        {
            _currentLinkman = new Linkman((Guid)ViewState["linkmanid"]);
            _currentLinkman.Name = txtName.Text.Trim();

            LinkmanDetail temp;

            temp = new LinkmanDetail((Guid)ViewState["mobile"], InfoType.Num_Mobile);
            temp.Value = txtMobil.Text.Trim();
            _currentLinkman.Details.Add(temp);


            temp = new LinkmanDetail((Guid)ViewState["home"], InfoType.Addr_Home);
            temp.Value = txtHome.Text.Trim();
            _currentLinkman.Details.Add(temp);

            temp = new LinkmanDetail((Guid)ViewState["work"], InfoType.Addr_Work);
            temp.Value = txtOffice.Text.Trim();
            _currentLinkman.Details.Add(temp);

            temp = new LinkmanDetail((Guid)ViewState["email"], InfoType.Addr_Email);
            temp.Value = txtEmail.Text.Trim();
            _currentLinkman.Details.Add(temp);
        }


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    bool hh = IsPostBack;
        //}
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (IsCompany)
                DlgCancel();
            else
            {
                if (DlgSaveLinkman != null)
                    DlgSaveLinkman();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (DlgCancel != null)
                DlgCancel();
        }


        public DelegateNoParameter DlgSaveLinkman;
        public DelegateNoParameter DlgCancel;
        public Linkman CurrentLinkman
        {
            get
            {
                Refresh();
                return _currentLinkman;
            }
            set
            {
                _currentLinkman = value;
                ShowDetail();
            }
        }

          //表示是否为公司联系人
        public bool IsCompany
        {
            get
            {
                return Session["TeleBookIsCompany"].Equals("Company");
            }
        }
    }
}