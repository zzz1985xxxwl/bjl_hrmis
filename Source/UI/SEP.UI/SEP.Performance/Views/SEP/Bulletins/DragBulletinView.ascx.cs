using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.Bulletins;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class DragBulletinView : UserControl, IListBulletinForwardView
    {
        private List<Model.Bulletins.Bulletin> _BulletinList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListBulletinForwardPresenter present = new ListBulletinForwardPresenter(this, Session[SessionKeys.LOGININFO] as Account);
            ShowBulletin += present.GetLastBulletin;
            if (!IsPostBack||IsFirstAdd)
            {
                BindBulletin();
                IsFirstAdd = false;
            }
        }

        private bool IsFirstAdd
        {
            get { return ViewState["IsFirstAdd"]==null; }
            set { ViewState["IsFirstAdd"] = value; }
        }

        public void BindBulletin()
        {
            if (ShowBulletin != null)
            {
                ShowBulletin(this, EventArgs.Empty);
            }
            gvBulletinList.DataSource = _BulletinList;
            gvBulletinList.DataBind();
        }


        public List<Model.Bulletins.Bulletin> BulletinList
        {
            get { return _BulletinList; }
            set
            {
                _BulletinList = value;
                for (int i = 0; i < _BulletinList.Count; i++)
                {
                    if (DateTime.Compare(DateTime.Now, _BulletinList[i].PublishTime.AddDays(10)) <= 0)
                    {
                        _BulletinList[i].Title = _BulletinList[i].Title + @"<img src=""../../../Pages/Image/new.gif"" border=""0"">";
                    }
                }
            }
        }

        public event EventHandler ShowBulletin;

        protected void BulletinList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBulletinList.PageIndex = e.NewPageIndex;
            BindBulletin();
        }

        protected void gvBulletinList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    string url = string.Format(@"../BulletinPages/BulletinShowDetailForward.aspx?BulletinID={0}",
                                               SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
                    Response.Write("<script>window.open(\"" + url + "\")</script>");
                    return;
            }
        }

        protected void gvBulletinList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
    }
}