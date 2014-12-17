using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComService.ServiceModels;
using SEP.Presenter.Contacts;
using SEP.Presenter.IPresenter.IContact;
using SEP.Model.Accounts;
using SEP.Performance;
using SEP.Performance.Pages;

namespace SEP.Performance.Views.SEP.Contacts
{
    public partial class ContactView : UserControl, IEmployeeContact
    {

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                tbMessage.Style["display"] = string.IsNullOrEmpty(value) ? "none" : "block";
            }
        }

        /// <summary>
        /// true:显示详情页面
        /// false:显示列表页面
        /// </summary>
        private bool IsDisplayDetail
        {
            set
            {
                LinkmanListView1.Visible = !value;
                LinkmanView1.Visible = value;
            }
        }
        /// <summary>
        /// 删除缓存中的联系人
        /// </summary>
        private void RemoveLinkmanByGuid(Guid linkmanId)
        {
            for (int i = LinkmanListView1.ContactSrc.Linkmans.Count - 1; i >= 0; i--)
            {
                if (linkmanId.ToString() == LinkmanListView1.ContactSrc.Linkmans[i].Id.ToString())
                {
                    LinkmanListView1.ContactSrc.Linkmans.RemoveAt(i);
                    break;
                }
            }
        }
        /// <summary>
        /// 设置字母的默认样式
        /// </summary>
        private void SetLetterDefaultStyle()
        {
            foreach (object o in Controls)
            {
                Button btn = o as Button;
                if (btn != null && btn.CssClass == "contactLetterClick")
                {
                    btn.CssClass = "contactLetter";
                    break;
                }
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ContactPresenter presenter = new ContactPresenter(this);
            if (Session["TeleBookIsCompany"] == null)
            {
                Session["TeleBookIsCompany"] = "0";
            }
            SearchSettingView1.DlgSearchByName = btnSearch_Click;

            LinkmanView1.DlgSaveLinkman = btnSave_Click;
            LinkmanView1.DlgCancel = btnCancel_Click;

            LinkmanListView1.DlgDelete = Delete_Command;
            LinkmanListView1.DlgUpdate = Update_Command;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["isfirst"] == null)
            {
                SearchByName("");
                ViewState["isfirst"] = new object();
            }
            if (Session["TeleBookIsCompany"] == null)
            {
                Session["TeleBookIsCompany"] = "0";
                SetAddButtonVisible();
            }
            Company.Visible=Company.Enabled = BasePage.HasHrmisSystem;
        }
        /// <summary>
        /// 按索引搜索联系人
        /// </summary>
        protected void btnLetter_Click(object sender, EventArgs e)
        {
            Message = string.Empty;
            SetLetterDefaultStyle();

            Button btn = sender as Button;
            if (btn != null) btn.CssClass = "contactLetterClick";
            if (btn != null && SearchByIndexKey != null)
                SearchByIndexKey(btn.Text);

            IsDisplayDetail = false;
            LinkmanListView1.CurrPageIndex = 0;
        }
        /// <summary>
        /// 按联系人姓名搜索联系人
        /// </summary>
        protected void btnSearch_Click(string name)
        {
            Message = string.Empty;
            SetLetterDefaultStyle();

            if (SearchByName != null)
                SearchByName(name);

            IsDisplayDetail = false;
            LinkmanListView1.CurrPageIndex = 0;
        }
        /// <summary>
        /// 新增联系人
        /// </summary>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Message = string.Empty;
            LinkmanView1.CurrentLinkman = new Linkman();

            IsDisplayDetail = true;
        }
        /// <summary>
        /// 修改联系人
        /// </summary>
        protected void Update_Command(Linkman linkman)
        {
            LinkmanView1.CurrentLinkman = linkman;

            IsDisplayDetail = true;
        }
        /// <summary>
        /// 保存联系人
        /// </summary>
        protected void btnSave_Click()
        {
            try
            {
                Message = String.Empty;

                if (SaveLinkman != null)
                    SaveLinkman(LinkmanView1.CurrentLinkman);

                IsDisplayDetail = false;

                RemoveLinkmanByGuid(LinkmanView1.CurrentLinkman.Id);
                LinkmanListView1.ContactSrc.Linkmans.Add(LinkmanView1.CurrentLinkman);
                LinkmanListView1.CurrPageIndex = 0;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
            }
        }
        /// <summary>
        /// 取消保存联系人
        /// </summary>
        protected void btnCancel_Click()
        {
            Message = string.Empty;
            IsDisplayDetail = false;

            LinkmanListView1.CurrPageIndex = 0;
        }
        /// <summary>
        /// 删除联系人
        /// </summary>
        protected void Delete_Command(Guid linkmanId)
        {
            if (DeleteLinkman != null)
                DeleteLinkman(linkmanId);

            RemoveLinkmanByGuid(linkmanId);
            LinkmanListView1.CurrPageIndex = 0;
        }
        #region ILinkmanSearch 成员

        public event DelegateLinkmanSearch SearchByName;
        public event DelegateLinkmanSearch SearchByIndexKey;
        public event DelegateLinkman SaveLinkman;
        public event DelegeteGuid DeleteLinkman;
        public int UserId
        {
            get
            {
                Account account = Session[SessionKeys.LOGININFO] as Account;
                return account != null ? account.Id : 0;
                //return Convert.ToInt32(Session[SessionUtility.EMPLOYEEID]);
            }
        }


        public bool IsCompany
        {
            get
            {
                return Session["TeleBookIsCompany"].Equals("Company");
            }
        }

        public Contact CurrentContact
        {
            set
            {
                LinkmanListView1.ContactSrc = value;
            }
        }

        #endregion

        protected void IsCompany_Click(object sender, EventArgs e)
        {
            //ImageButton button = sender as ImageButton;
            LinkButton button = sender as LinkButton;
            if (button != null) Session["TeleBookIsCompany"] = button.ID;
            SetAddButtonVisible();
            btnSearch_Click(string.Empty);
        }

        private void SetAddButtonVisible()
        {
            if (Session["TeleBookIsCompany"].Equals(Company.ID))
            {
                AddBtn.Visible = false;
                AddBtn.Enabled = false;
                companydiv.Attributes["class"] = "floatbtbg";
                persondiv.Attributes["class"] = "floatsetbt";
            }
            else
            {
                AddBtn.Visible = true;
                AddBtn.Enabled = true;
                companydiv.Attributes["class"] = "floatsetbt";
                persondiv.Attributes["class"] = "floatbtbg";
            }
        }
    }
}