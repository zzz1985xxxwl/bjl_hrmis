//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinShowDetailView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加BulletinShowDetailView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Bulletins;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class BulletinShowDetailView : UserControl, IBulletinShowDetailView
    {
        private List<Appendix> _AppendixList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAppendix.Visible = true;
            if (!IsPostBack)
            {
                EventHandler InitViewTemp = ShowBulletin;
                if (InitViewTemp != null)
                {
                    InitViewTemp(this, EventArgs.Empty);
                }
            }
        }

        protected void Download_Command(object sender, CommandEventArgs e)
        {
            lblAppendixMessage.Text = "";
            if (!File.Exists(e.CommandName))
            {
                lblAppendixMessage.Text = "该附件未能找到";
                return;
            }
            FileInfo fileInfo = new FileInfo(e.CommandName);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition",
                               "attachment;filename=" + HttpUtility.UrlEncode(e.CommandArgument.ToString()));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }


        public int BulletinID
        {
            get { return Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["BulletinID"])); }
            set { }
        }

        public string Content
        {
            get { return lblContent.Text.Trim(); }
            set { lblContent.Text = value; }
        }

        public string Title
        {
            get { return lblTitle.Text.Trim(); }
            set { lblTitle.Text = value; }
        }

        public string PublishTime
        {
            get { return lblTime.Text.Trim(); }
            set { lblTime.Text = value; }
        }

        public List<Appendix> AppendixList
        {
            get { return _AppendixList; }
            set
            {
                _AppendixList = value;
                DataBindForAppendixList();
                ShowAppendix.Visible = AppendixList.Count <= 0 ? false : true;
            }
        }

        public event EventHandler ShowBulletin;

        private void DataBindForAppendixList()
        {
            gvAppendixList.DataSource = AppendixList;
            gvAppendixList.DataBind();
            ShowAppendix.Visible = !(AppendixList.Count == 0);
        }

        public EventHandler GoBack;

        protected void BtnGoBack_Click(object sender, EventArgs e)
        {
            GoBack(this, null);
        }

        protected void gvAppendixList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }
    }
}