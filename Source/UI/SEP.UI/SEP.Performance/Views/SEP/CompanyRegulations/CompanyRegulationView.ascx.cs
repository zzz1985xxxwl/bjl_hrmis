using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.IPresenter.ICompanyRegulations;

using CompanyReguAppendix = SEP.Model.CompanyRegulations.CompanyReguAppendix;
using ReguType = SEP.Model.CompanyRegulations.ReguType;

namespace SEP.Performance.Views
{
    public partial class CompanyRegulationView : UserControl, ICompanyRegulation
    {
       private List<CompanyReguAppendix> _AppendixList;
        private ReguType _ReguType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EventHandler InitViewTemp = ShowApplication;
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
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(e.CommandArgument.ToString()));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        public string PageTitle
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public ReguType ReguType
        {
            get { return _ReguType; }
            set { _ReguType = value; }
        }

        public string Content
        {
            get { return lblContent.Text.Trim(); }
            set { lblContent.Text = value; }
        }

        public List<CompanyReguAppendix> AppendixList
        {
            get { return _AppendixList; }
            set
            {
                _AppendixList = value;
                DataBindForAppendixList();
                ShowAppendix.Visible = AppendixList.Count <= 0 ? false : true;
            }
        }

        public event EventHandler ShowApplication;
        private void DataBindForAppendixList()
        {
            gvAppendixList.DataSource = AppendixList;
            gvAppendixList.DataBind();
            list.Visible = !(AppendixList.Count == 0);
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