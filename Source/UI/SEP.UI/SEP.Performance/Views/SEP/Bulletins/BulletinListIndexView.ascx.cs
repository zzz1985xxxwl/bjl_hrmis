using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class BulletinListIndexView : UserControl, IListBulletinForwardView
    {
        private List<Model.Bulletins.Bulletin> _BulletinList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBulletin();
            }
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

        public string Type
        {
            set
            {
                if (value == "Index")
                {
                    gvBulletinList.Columns[1].Visible = true;
                    gvBulletinList.Columns[4].Visible = true;
                    gvBulletinList.Columns[2].Visible = false;
                }
                else
                {
                    gvBulletinList.AlternatingRowStyle.BackColor = Color.FromName("#f8f8f8");
                    gvBulletinList.Columns[1].Visible = false;
                    gvBulletinList.Columns[4].Visible = false;
                    gvBulletinList.Columns[2].Visible = true;
                }
            }
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
                        _BulletinList[i].Title = _BulletinList[i].Title + @"<img src=""../image/new.gif"" border=""0"">";
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

        public int GetRowsCount()
        {
            return _BulletinList.Count;
        }

        protected void gvBulletinList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(
                        string.Format(@"..\BulletinPages\BulletinShowDetailForward.aspx?BulletinID={0}",
                                      SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
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