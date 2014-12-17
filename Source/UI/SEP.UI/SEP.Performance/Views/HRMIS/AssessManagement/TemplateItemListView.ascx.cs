using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Model;
using ShiXin.Security;


namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class TemplateItemListView : UserControl, ITemplateItemListView
    {
        private List<AssessTemplateItem> _Items=new List<AssessTemplateItem>();
        private OperateType _OperateType;
        private readonly int _All = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItem();
                DisplayItem();
            }
            BindPageTemplate();
        }


        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvitemlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvitemlist.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public EventHandler btnSearchClick;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchClick(sender, e);
            BindItem();
            DisplayItem();
        }

        public OperateType OperateType
        {
            get
            {
                switch (listOperateType.SelectedIndex)
                {

                    case 1: 
                        _OperateType = OperateType.HR;
                        break;
                    case 2: 
                        _OperateType = OperateType.NotHR;
                        break;
                    case 0:
                        _OperateType = OperateType.ALL;
                        break;
                }
                return _OperateType;
            }
        }

        public string Question
        {
            get { return txtQuestion.Text; }
        }

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public List<AssessTemplateItem> TemplateItems
        {
            set
            {
                _Items = value;
                //BindItem();
                //DisplayItem();
            }
            get
            {
                return _Items;
            }
        }

        private void BindItem()
        {
            btnSearchClick(this, null);
            grvitemlist.DataSource = _Items;
            grvitemlist.DataBind();
            if (_Items.Count > 0)
            {
                tbSearch.Style["display"] = "block";
            }
            else
            {
                tbSearch.Style["display"] = "none";
            }
        }

        public Dictionary<string, string> ItemClassficationSource
        {
            set
            {
                listItemClassfication.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listItemClassfication.Items.Add(itemAll);
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listItemClassfication.Items.Add(item);
                }
            }
        }

        public string ItemClassfication
        {
            get { return listItemClassfication.SelectedItem.Value; }
        }

        public string DelMessage
        {
            set { lblDelMsg.Text = value; }
        }

        public AssessTemplateItemType SelectedAssessTemplateItemType
        {
            //千万不要交换item的次序，不然会有问题
            get { return (AssessTemplateItemType) (ddItemType.SelectedIndex - 1); }
        }

        protected void grvitemlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvitemlist.PageIndex = e.NewPageIndex;
            BindItem();
            DisplayItem();
        }

        /// <summary>
        /// 分类界面显示
        /// </summary>
        /// <returns></returns>
        private void DisplayItem()
        {
            foreach (GridViewRow row in grvitemlist.Rows)
            {
                CheckBox chbType = (CheckBox)row.FindControl("chbType");
                chbType.Enabled = false;
                if (chbType.Text == "HR")
                {
                    chbType.Checked = true;
                    chbType.Text = "";
                }
                else
                {
                    chbType.Text = "";
                }
                Label lblType = (Label)row.FindControl("lblType");
                lblType.Text = AssessUtility.GetChoosedItemClassficationName(lblType.Text);
            }
        }

        public CommandEventHandler ItemDeleteEvent;
        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            ItemDeleteEvent(sender, e);
            BindItem();
            DisplayItem();
        }

        protected void grvitemlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessTemplateItemDetail.aspx?ItemID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void grvitemlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Response.Redirect("AssessTemItemAdd.aspx");
        }

    }
}