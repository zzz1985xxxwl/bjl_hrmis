//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名:PositionTypeListView.cs
// 创建者:张燕
// 创建日期: 2008-06-23
// 修改日期：2008-10-07
// 概述: 增加PositionTypeListView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;
using SEP.Presenter.Core;
using SEP.Model.Positions;
using SEP.HRMIS.Model.PayModule;
using SEP.Performance;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class AccountSetParaListView : UserControl, IAccountSetParaListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            GridView1.PageIndex = pageindex;
            BtnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(GridView1, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected List<Position> _PositionSource;
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter btnSearchClick;

        #region IPositionListView

        /// <summary>
        /// 帐套参数名称
        /// </summary>
        public string AccountSetParaName
        {
            get { return TxtName.Text; }
            set { TxtName.Text = value; }
        }

        public List<FieldAttributeEnum> FieldAttributeSource
        {
            get { return new List<FieldAttributeEnum>(); }
            set
            {
                ddlFieldAttribute.Items.Clear();
                foreach (FieldAttributeEnum fieldAttribute in value)
                {
                    ListItem item = new ListItem(fieldAttribute.Name, fieldAttribute.Id.ToString(), true);
                    ddlFieldAttribute.Items.Add(item);
                }
            }
        }

        public List<BindItemEnum> BindItemSource
        {
            get { return new List<BindItemEnum>(); }
            set
            {
                ddlBindItem.Items.Clear();
                foreach (BindItemEnum bindItem in value)
                {
                    ListItem item = new ListItem(bindItem.Name, bindItem.Id.ToString(), true);
                    ddlBindItem.Items.Add(item);
                }
            }
        }

        public List<MantissaRoundEnum> MantissaRoundSource
        {
            get { return new List<MantissaRoundEnum>(); }
            set
            {
                ddlMantissaRound.Items.Clear();
                foreach (MantissaRoundEnum mantissaRound in value)
                {
                    ListItem item = new ListItem(mantissaRound.Name, mantissaRound.Id.ToString(), true);
                    ddlMantissaRound.Items.Add(item);
                }
            }
        }


        public FieldAttributeEnum SelectedFieldAttribute
        {
            get
            {
                return new FieldAttributeEnum(Convert.ToInt32(ddlFieldAttribute.SelectedItem.Value), ddlFieldAttribute.SelectedItem.Text);
            }
            set
            {
                ddlFieldAttribute.SelectedValue = value.Id.ToString();
            }
        }

        public BindItemEnum SelectedBindItem
        {
            get
            {
                return new BindItemEnum(Convert.ToInt32(ddlBindItem.SelectedItem.Value), ddlBindItem.SelectedItem.Text);
            }
            set
            {
                ddlBindItem.SelectedValue = value.Id.ToString();
            }
        }

        public MantissaRoundEnum SelectedMantissaRound
        {
            get
            {
                return new MantissaRoundEnum(Convert.ToInt32(ddlMantissaRound.SelectedItem.Value), ddlMantissaRound.SelectedItem.Text);
            }
            set
            {
                ddlMantissaRound.SelectedValue = value.Id.ToString();
            }
        }

        public string Message
        {
            set { LblMessage.Text = value; }
            get { return LblMessage.Text; }
        }



        public List<AccountSetPara> AccountSetParaList
        {
            set
            {
                GridView1.DataSource = value;
                GridView1.DataBind();
                if (value == null || value.Count == 0)
                {
                    Result.Style["display"] = "none";
                    LblMessage.Text = "0";
                }
                else
                {
                    Result.Style["display"] = "block";
                    LblMessage.Text = value.Count.ToString();
                }
            }
            get
            {
                return new List<AccountSetPara>();
            }
        }
        #endregion

        public class HiddenPost : ITemplate
        {
            /// <summary> 
            /// 实现接口ITemplate的方法 
            public void InstantiateIn(Control container)
            {
                Button btnHiddenPostButton = new Button();
                btnHiddenPostButton.ID = "btnHiddenPostButton";
                btnHiddenPostButton.Text = "";
                btnHiddenPostButton.CommandName = "HiddenPostButtonCommand";
                btnHiddenPostButton.Style["display"] = "none";
                container.Controls.Add(btnHiddenPostButton);
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            btnSearchClick();
            //GridView1.DataSource = _PositionSource;
            //GridView1.DataBind();
        }


        protected void lbModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void lbDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BtnSearch_Click(sender, e);

            //GridView1.DataSource = _PositionSource;
            //GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as LinkButton;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

    }
}