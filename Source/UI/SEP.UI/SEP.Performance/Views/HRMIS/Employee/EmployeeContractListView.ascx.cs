using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Presenter.Core;


namespace SEP.Performance.Views.Employee
{
    public partial class EmployeeContractListView : UserControl, IEmployeeContractListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvcontractlist.PageIndex = pageindex;
            grvcontractlist.DataSource = _Contract;
            grvcontractlist.DataBind();
            DownLoadStatusDisplay();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvcontractlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<Contract> _Contract
        {
            get { return ViewState["Contract"] as List<Contract>; }
            set { ViewState["Contract"] = value; }
        }

        protected void grvcontractlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvcontractlist.PageIndex = e.NewPageIndex;
            grvcontractlist.DataSource = _Contract;
            grvcontractlist.DataBind();
            DownLoadStatusDisplay();
        }

        public CommandEventHandler ContractDeleteEvent;
        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            ContractDeleteEvent(sender, e);
        }

        public EventHandler ContractAddEvent;
        protected void Add_Command(object sender, EventArgs e)
        {
            ContractAddEvent(sender, e);
        }

        public event DelegateReturnString ContractDownLoadEvent;
        protected void DownLoad_Command(object sender, CommandEventArgs e)
        {
           
            string filename = ContractDownLoadEvent(Convert.ToInt32(e.CommandArgument));
            if (string.IsNullOrEmpty(filename))
            {
                ResultMessage = "œ¬‘ÿ ß∞‹";
                return;
            }
            FileInfo fileInfo = new FileInfo(filename);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        public event DelegateReturnBool IsDownLoadEnable;
        private void DownLoadStatusDisplay()
        {
            foreach (GridViewRow row in grvcontractlist.Rows)
            {
                LinkButton btnDownLoad = (LinkButton)row.FindControl("btnDownLoad");
                btnDownLoad.Enabled = IsDownLoadEnable(Convert.ToInt32(btnDownLoad.CommandArgument));
            }
        }
        public CommandEventHandler ContractEditEvent;
        protected void Update_Command(object sender, CommandEventArgs e)
        {
            ContractEditEvent(sender, e);
        }

        public string EmployeeName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lblEmployeeName.Text = value;
                    tbNoDataMessage.Style["display"] = "block";
                    tbEmployeeName.Style["display"] = "block";
                    tbEmployeeGridView.Style["display"] = "block";
                }
                else
                {
                    tbNoDataMessage.Style["display"] = "block";
                    tbEmployeeName.Style["display"] = "none";
                    tbEmployeeGridView.Style["display"] = "none";
                }
            }
        }

        public string ResultMessage
        {
            set { lblResult.Text = value; }
        }

        //public string NoDataMessage
        //{
        //    set
        //    {
        //        lblMessage.Text = value;
        //    }
        //}

        public bool setGirdViewConlumn
        {
            set
            {
                if (value)
                {
                    grvcontractlist.Columns[7].Visible = false;
                    grvcontractlist.Columns[8].Visible = false;
                }
                else
                {
                    grvcontractlist.Columns[7].Visible = true;
                    grvcontractlist.Columns[8].Visible = true;
                }
            }
        }



        public List<Contract> EmployeeContract
        {
            set
            {
                _Contract = value;
                grvcontractlist.DataSource = value;
                grvcontractlist.DataBind();
                DownLoadStatusDisplay();
            }
        }

        public bool ButtonEnable
        {
            set
            {
                btnAdd.Enabled = value;
                if (value)
                {
                    tbAdd.Style["display"] = "block";
                }
                else
                {
                    tbAdd.Style["display"] = "none";
                }
            }
        }

        public CommandEventHandler ContractDetailEvent;
        protected void grvcontractlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (ContractDetailEvent != null)
                    {
                        ContractDetailEvent(sender, e);
                    }
                    return;
            }
        }

        protected void grvcontractlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                if (grvcontractlist.Columns[7].Visible)
                {
                    ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
                }
                else
                {
                    ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);

                }
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../EmployeePages/EmployeeList.aspx");
        }

     
    }
}