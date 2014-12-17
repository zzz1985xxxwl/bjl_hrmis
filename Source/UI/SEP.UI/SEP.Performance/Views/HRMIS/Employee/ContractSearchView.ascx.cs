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
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.Employee
{
    public partial class ContractSearchView : UserControl, ISearchContractListView
    {
        private List<Contract> _Contract;
        private readonly int _All = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindContract();
            }
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvcontract.PageIndex = pageindex;
            BindContract();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvcontract, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void grvcontract_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvcontract.PageIndex = e.NewPageIndex;
            BindContract();
        }

        /// <summary>
        /// datagridview 绑定数据
        /// </summary>
        private void BindContract()
        {
            searchEvent(this, null);
            if (_Contract != null)
            {
                grvcontract.DataSource = _Contract;
                grvcontract.DataBind();
                DownLoadStatusDisplay();
                if (_Contract.Count > 0)
                {
                    tbSearch.Style["display"] = "block";
                }
                else
                {
                    tbSearch.Style["display"] = "none";
                }
            }
        }

        public List<global::SEP.HRMIS.Model.ContractType> ContractTypeSource
        {
            set
            {
                listContractType.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listContractType.Items.Add(itemAll);
                foreach (global::SEP.HRMIS.Model.ContractType type in value)
                {
                    ListItem item = new ListItem(type.ContractTypeName, type.ContractTypeID.ToString(), true);
                    listContractType.Items.Add(item);
                }
            }
        }

        public string ResultMessage
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    tbNoDataMessage.Style["display"] = "none";
                }
                else
                {
                    tbNoDataMessage.Style["display"] = "block";
                    lblMessage.Text = value;
                }
            }
        }

        public string StartTimeFrom
        {
            get { return txtStartFrom.Text; }
        }

        public string TimeErrorMessage
        {
            set
            {
                lblMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbNoDataMessage.Style["display"] = "none";
                }
                else
                {
                    tbNoDataMessage.Style["display"] = "block";
                }
            }
        }

        public string StartTimeTo
        {
            get { return txtStartTo.Text; }
        }

        public string EndTimeTo
        {
            get { return txtEndTo.Text; }
        }

        public string EndTimeFrom
        {
            get { return txtEndFrom.Text; }
        }

        public string EmployeeName
        {
            get { return txtName.Text; }
        }

        public string ContractTypeId
        {
            get { return listContractType.SelectedValue; }
        }

        public List<Contract> contracts
        {
            set
            {
                _Contract = value;
                //BindContract();
            }
            get { return _Contract; }
        }

        public EventHandler searchEvent;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grvcontract.PageIndex = 0;
            BindContract();
        }

        protected void grvcontract_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        public event DelegateReturnString ContractDownLoadEvent;

        protected void DownLoad_Command(object sender, CommandEventArgs e)
        {
            string filename = ContractDownLoadEvent(Convert.ToInt32(e.CommandArgument));
            if (string.IsNullOrEmpty(filename))
            {
                //todo 
                //ResultMessage = "下载失败";
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

        public event CommandEventHandler ContractEditEvent;

        protected void Update_Command(object sender, CommandEventArgs e)
        {
            ContractEditEvent(sender, e);
        }

        public event CommandEventHandler ContractDeleteEvent;

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            ContractDeleteEvent(sender, e);
        }

        public event DelegateReturnBool IsDownLoadEnable;

        private void DownLoadStatusDisplay()
        {
            foreach (GridViewRow row in grvcontract.Rows)
            {
                LinkButton btnDownLoad = (LinkButton) row.FindControl("btnDownLoad");
                btnDownLoad.Enabled = IsDownLoadEnable(Convert.ToInt32(btnDownLoad.CommandArgument));
            }
        }

        public string EmployeeStatusId
        {
            get { return ddlEmployeeStatus.SelectedValue; }
        }
    }
}