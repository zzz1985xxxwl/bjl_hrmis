//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeListView.ascx.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-08
// 概述: 合同类型的大界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.ContractType
{
    public partial class ContractTypeListView : UserControl, IContractTypeList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            dg.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(dg, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected List<HRMISModel.ContractType> _ContractTypeSource;
       
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnDetialEvent;
        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateReturnByte BtnDownLordEvent;


        private void DownLoadStatusDisplay()
        {
            foreach (GridViewRow row in dg.Rows)
            {
                LinkButton btnDownLoad = (LinkButton)row.FindControl("btnDownLoad");
                Label lblHasTemplate = (Label)row.FindControl("lblHasTemplate");
                if(lblHasTemplate.Text.Trim()=="True")
                {
                    btnDownLoad.Enabled = true;
                }
            }
        }

        #region 事件处理
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void lbModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void lbDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }


        #endregion

        #region 下一页处理
        protected void dg1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dg.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void dg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetialEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void dg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as LinkButton;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
        #endregion

        #region IContractTypeList 成员

        public List<HRMISModel.ContractType> ContractTypeSource
        {
            get
            {
                return _ContractTypeSource;
            }
            set
            {
                _ContractTypeSource = value;
                dg.DataSource = value;
                dg.DataBind();
                DownLoadStatusDisplay();
                if (_ContractTypeSource == null || _ContractTypeSource.Count == 0)
                {
                    Result.Style["display"] = "none";
                }
                else
                {
                    Result.Style["display"] = "block";
                }

            }
        }

        public string Message
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public string ContractTypeName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        //public string ContractTypeID
        //{
        //    get
        //    {
        //        return txtID.Text;
        //    }
        //    set
        //    {
        //        txtID.Text = value;
        //    }
        //}

        #endregion

        protected void DownLoad_Command(object sender, CommandEventArgs e)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(e.CommandName+".doc", Encoding.UTF8));
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            byte[] template = BtnDownLordEvent(Convert.ToInt32(e.CommandArgument));
            Response.OutputStream.Write(template, 0, template.Length);
            Response.Flush();
            Response.End(); ;
        }
    }
}


#region 过期代码
    //public partial class ContractTypeListView : UserControl, IContractTypeListView
    //{
    //    public delegate void ShowItemWindowForAdd();
    //    public ShowItemWindowForAdd _ShowItemWindowForAdd;
    //    public delegate void ShowItemWindowForModify(string id);
    //    public ShowItemWindowForModify _ShowItemWindowForModify;
    //    public delegate void ShowItemWindowForDelete(string id);
    //    public ShowItemWindowForDelete _ShowItemWindowForDelete;
    //    public delegate void ShowItemWindowForDetail(string id);
    //    public ShowItemWindowForDetail _ShowItemWindowForDetail;
    //    public delegate void UpdateListWindow();
    //    public UpdateListWindow _UpdateListWindow;

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (!IsPostBack)
    //        {
    //            BindItem();
    //        }
    //    }

    //    private List<Model.ContractType> _ContractTypes;

    //    public string ContractTypeID
    //    {
    //        get
    //        {
    //             return txtID.Text.Trim();
    //        }
    //        set
    //        {
    //            throw new Exception("The method or operation is not implemented.");
    //        }

    //    }

    //    public string ContractTypeName
    //    {
    //        get
    //        {
    //            return txtName.Text.Trim();
    //        }
    //        set
    //        {
    //            throw new Exception("The method or operation is not implemented.");
    //        }
    //    }

    //    public string Message
    //    {
    //        get
    //        {
    //            throw new Exception("The method or operation is not implemented.");
    //        }
    //        set
    //        {
    //             lblMessage.Text = value;
    //        }
    //    }

    //    public List<Model.ContractType> ContractTypes
    //    {
    //        set
    //        {
    //            _ContractTypes = value;
    //            //dg.Columns.Clear();


    //            //TemplateField templateField = new TemplateField();
    //            //templateField.ItemTemplate = new HiddenPost();
    //            //templateField.HeaderImageUrl = "../../Pages/image/icon02.jpg";
    //            //dg.Columns.Add(templateField);

    //            //HyperLinkField link = new HyperLinkField();
    //            //link.HeaderText = "编号";
    //            //link.HeaderStyle.Width = 80;
    //            //link.ItemStyle.Width = 80;
    //            //link.DataTextField = "ParameterID";
    //            //string[] fields = new string[1];
    //            //fields[0] = "ParameterID";
    //            //dg.Columns.Add(link);

    //            //BoundField col2 = new BoundField();
    //            //col2.HeaderText = "合同类型名称";
    //            //col2.HeaderStyle.Width = 120;
    //            //col2.ItemStyle.Width = 120;
    //            //col2.DataField = "Name";
    //            //dg.Columns.Add(col2);

    //            //link = new HyperLinkField();
    //            //link.HeaderText = "";
    //            //link.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    //            //link.ItemStyle.Width = 100;
    //            //link.Text = "修改";
    //            //link.DataNavigateUrlFields = fields;
    //            //link.DataNavigateUrlFormatString = "../../Pages/ContractTypeUpdate.aspx?ContractTypeID={0}";
    //            //dg.Columns.Add(link);

    //            //link = new HyperLinkField();
    //            //link.HeaderText = "";
    //            //link.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
    //            //link.ItemStyle.Width = 100;
    //            //link.Text ="删除";
    //            //link.DataNavigateUrlFields = fields;
    //            //link.DataNavigateUrlFormatString = "../../Pages/ContractTypeDelete.aspx?ContractTypeID={0}";
    //            //dg.Columns.Add(link);

    //            //_ContractTypes = value;
    //            //dg.DataSource = value;
    //            //dg.DataBind();

    //            //if (_ContractTypes==null||_ContractTypes.Count==0)
    //            //{
    //            //    Result.Style["display"] = "none";
    //            //}
    //            //else
    //            //{
    //            //    Result.Style["display"] = "block";
    //            //}
    //            //int page = dg.PageIndex;
    //            //for (int i = 0; i < dg.Rows.Count; i++)
    //            //{
    //            //    int row = page * dg.PageSize + i;
    //            //    ((Button)dg.Rows[i].Cells[0].Controls[0]).CommandArgument = value[row].ParameterID.ToString();
    //            //}
    //            //dg.Columns[0].ItemStyle.Width = Unit.Percentage(8);
    //        }
    //        get
    //        {
    //            return _ContractTypes;
    //        }
    //    }
    //    private void BindItem()
    //    {
    //        btnSearchClick(this, null);
    //        dg.DataSource = _ContractTypes;
    //        dg.DataBind();
    //        if (_ContractTypes == null || _ContractTypes.Count == 0)
    //        {
    //            Result.Style["display"] = "none";
    //        }
    //        else
    //        {
    //            Result.Style["display"] = "block";
    //        }
    //    }
    //    public class HiddenPost : ITemplate
    //    {
    //        /// <summary> 
    //        /// 实现接口ITemplate的方法 
    //        public void InstantiateIn(Control container)
    //        {
    //            Button btnHiddenPostButton = new Button();
    //            btnHiddenPostButton.ID = "btnHiddenPostButton";
    //            btnHiddenPostButton.Text = "";
    //            btnHiddenPostButton.CommandName = "HiddenPostButtonCommand";
    //            btnHiddenPostButton.Style["display"] = "none";
    //            container.Controls.Add(btnHiddenPostButton);
    //        }
    //    } 
    //    public event EventHandler btnSearchClick;
    //    protected void btnSearch_Click(object sender, EventArgs e)
    //    {
    //        btnSearchClick(sender, e);
    //        BindItem();
    //    }

    //    protected void dg1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //    {
    //        dg.PageIndex = e.NewPageIndex;
    //        BindItem();
    //    }

    //    protected void dg_RowCommand(object sender, GridViewCommandEventArgs e)
    //    {
    //        switch (e.CommandName)
    //        {
    //            case "HiddenPostButtonCommand":
    //                _ShowItemWindowForDetail(e.CommandArgument.ToString());
    //                return;
    //        }
    //    }

    //    protected void dg_RowDataBound(object sender, GridViewRowEventArgs e)
    //    {
    //        Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
    //        if (btnHiddenPostButton != null)
    //        {
    //            ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
    //        }
    //    }

    //    public void Search()
    //    {
    //        btnSearch_Click(null,null);
    //    }

    //    protected void btnAdd_Click(object sender, EventArgs e)
    //    {
    //        _ShowItemWindowForAdd();
    //    }

    //    protected void lbModify_Click(object sender, CommandEventArgs e)
    //    {
    //        _ShowItemWindowForModify(e.CommandArgument.ToString());
    //    }

    //    protected void lbDelete_Click(object sender, CommandEventArgs e)
    //    {
    //        _ShowItemWindowForDelete(e.CommandArgument.ToString());
    //    }
    //}
#endregion

