//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinListForwardView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinListForwardView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class BulletinListForwardView : UserControl, IListBulletinForwardView
    {
        private List<Model.Bulletins.Bulletin> _BulletinList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBulletin();
            }
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvBulletinList.PageIndex = pageindex;
            BindBulletin();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvBulletinList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
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

        public List<Model.Bulletins.Bulletin> BulletinList
        {
            get { return _BulletinList; }
            set
            {
                _BulletinList = value;
                lblCurrentCount.Text = value.Count.ToString();
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
                    Response.Redirect(
                        string.Format("BulletinShowDetailForward.aspx?BulletinID={0}",
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