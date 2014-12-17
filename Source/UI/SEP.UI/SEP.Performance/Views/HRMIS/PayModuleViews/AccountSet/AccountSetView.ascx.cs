//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetView.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using AccountSet=SEP.HRMIS.Model.PayModule.AccountSet;
using AccountSetItem=SEP.HRMIS.Model.PayModule.AccountSetItem;
using FieldAttributeEnum=SEP.HRMIS.Model.PayModule.FieldAttributeEnum;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class AccountSetView : UserControl, IAccountSetView
    {
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

        public event DelegateNoParameter btnCopyEvent;
        public event DelegateNoParameter btnPasteEvent;

        public AccountSet SessionCopyAccountSet
        {
            get { return Session[AccountSetUtility.SessionCopyAccountSet] as AccountSet; }
            set
            {
                if (value != null)
                {
                    Session[AccountSetUtility.SessionCopyAccountSet] = value;
                    if (OperationTitle == AccountSetUtility.AddPageTitle ||
                        OperationTitle == AccountSetUtility.UpdatePageTitle)
                    {
                        SetbtnPasteVisible = SessionCopyAccountSet == null ? false : true;
                    }
                }
            }
        }

        public bool SetbtnPasteVisible
        {
            set { btnPaste.Visible = value; }
        }

        public string OperatorName
        {
            get
            {
                Account accountOperator = Session[SessionKeys.LOGININFO] as Account;
                if (accountOperator != null)
                {
                    return accountOperator.Name;
                }
                else
                {
                    return "";
                }
            }
        }

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;
        public event Delegate2Parameter txtAccountSetParaChangedForUpdateEvent;
        public event DelegateID txtAccountSetParaChangedForAddEvent;
        
        public event DelegateID lbDeleteItemEvent;
        public event DelegateID lbAddNewItemEvent;
        public event DelegateID lbUpItemEvent;
        public event DelegateID lbDownItemEvent;

        public string AccountSetNameMsg
        {
            set { lblNameMsg.Text = value; }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string AccountSetName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string Description
        {
            get { return txtDescrition.Text.Trim(); }
            set { txtDescrition.Text = value; }
        }

        public string OperationTitle
        {
            get { return lblOperationTitle.Text.Trim(); }
            set { lblOperationTitle.Text = value; }
        }

        public bool SetFormReadOnly
        {
            set
            {
                txtName.ReadOnly = value;
                txtDescrition.ReadOnly = value;
                gvAccountSetItemList.Columns[5].Visible = !value;
                gvAccountSetItemList.Columns[7].Visible = !value;
                gvAccountSetItemList.Columns[8].Visible = !value;
                gvAccountSetItemList.Columns[9].Visible = !value;
                gvAccountSetItemList.Columns[10].Visible = !value;
                SetgvAccountSetItemColumnFalse(value);
                btnPaste.Visible = !value;
            }
        }

        private void SetgvAccountSetItemColumnFalse(bool value)
        {
            for (int i = 0; i < gvAccountSetItemList.Rows.Count; i++)
            {
                TextBox txtCaculate =
                    (TextBox)gvAccountSetItemList.Rows[i].FindControl("txtCaculate");
                if (txtCaculate != null)
                {
                    txtCaculate.ReadOnly = value;
                }
                DropDownList ddlAccountSetPara =
                    (DropDownList) gvAccountSetItemList.Rows[i].FindControl("ddlAccountSetPara");
                if (ddlAccountSetPara != null)
                {
                    ddlAccountSetPara.Enabled = !value;
                }
                DropDownList ddlFieldAttribute =
                    (DropDownList) gvAccountSetItemList.Rows[i].FindControl("ddlFieldAttribute");
                if (ddlFieldAttribute != null)
                {
                    ddlFieldAttribute.Enabled = !value;
                }
                DropDownList ddlBindItem =
                    (DropDownList)gvAccountSetItemList.Rows[i].FindControl("ddlBindItem");
                if (ddlBindItem != null)
                {
                    ddlBindItem.Enabled = !value;
                }
                DropDownList ddlMantissaRound =
                    (DropDownList)gvAccountSetItemList.Rows[i].FindControl("ddlMantissaRound");
                if (ddlMantissaRound != null)
                {
                    ddlMantissaRound.Enabled = !value;
                }

            }
        }

        public List<AccountSetItem> AccountSetItemList
        {
            get
            {
                List<AccountSetItem> accountSetItemList = (List<AccountSetItem>)ViewState["_AccountSetItemList"];
                GetGridViewValue(accountSetItemList);
                return accountSetItemList;
            }
            set
            {
                ViewState["_AccountSetItemList"] = value;
                Session["AccountSetItemListForCheck"] = value;
                gvAccountSetItemList.DataSource = value;
                gvAccountSetItemList.DataBind();

                if (value == null || value.Count == 0)
                {
                    tbAccountSetItem.Style["display"] = "none";
                }
                else
                {
                    tbAccountSetItem.Style["display"] = "block";
                    if (_AccountSetPara != null && _AccountSetPara.Count > 0)
                    {
                        SetGridViewDisplay(value);
                    }
                }
            }
        }

        #region AccountSetItemList 内部方法
        private void GetGridViewValue(List<AccountSetItem> accountSetItemList)
        {
            for (int i = 0; i < accountSetItemList.Count; i++)
            {
                TextBox txtCaculate =
                    (TextBox) gvAccountSetItemList.Rows[i].FindControl("txtCaculate");
                if (txtCaculate != null)
                {
                    accountSetItemList[i].CalculateFormula = txtCaculate.Text.Trim();
                }
                DropDownList ddlFieldAttribute =
                    (DropDownList)gvAccountSetItemList.Rows[i].FindControl("ddlFieldAttribute");
                if (ddlFieldAttribute != null)
                {
                    accountSetItemList[i].AccountSetPara.FieldAttribute =
                        new FieldAttributeEnum(Convert.ToInt32(ddlFieldAttribute.SelectedValue), "");
                }
                DropDownList ddlBindItem =
                    (DropDownList)gvAccountSetItemList.Rows[i].FindControl("ddlBindItem");
                if (ddlBindItem != null)
                {
                    accountSetItemList[i].AccountSetPara.BindItem =
                        new BindItemEnum(Convert.ToInt32(ddlBindItem.SelectedValue), "");
                }
                DropDownList ddlMantissaRound =
                    (DropDownList)gvAccountSetItemList.Rows[i].FindControl("ddlMantissaRound");
                if (ddlMantissaRound != null)
                {
                    accountSetItemList[i].AccountSetPara.MantissaRound =
                        new MantissaRoundEnum(Convert.ToInt32(ddlMantissaRound.SelectedValue), "");
                }
            }
        }

        private void SetGridViewDisplay(List<AccountSetItem> accountSetItemList)
        {
            for (int i = 0; i < accountSetItemList.Count; i++)
            {
                SetGridViewRowtxtAccountSetParaDisplay(i, accountSetItemList);
                SetGridViewRowtxtCaculateDisplay(i, accountSetItemList);
                SetGridViewRowddlBindItemDisplay(i, accountSetItemList);
                SetGridViewRowddlFieldAttributeDisplay(i, accountSetItemList);
                SetGridViewRowddlMantissaRoundDisplay(i, accountSetItemList);
                if (i < accountSetItemList.Count - 1)
                {
                    SetGridViewRowLinkButtonDisplay(i);
                }
            }
        }

        private void SetGridViewRowtxtAccountSetParaDisplay(int rowIndex, List<AccountSetItem> accountSetItemList)
        {
            TextBox txtAccountSetPara = (TextBox)gvAccountSetItemList.Rows[rowIndex].FindControl("txtAccountSetPara");
            if (txtAccountSetPara == null)
            {
                return;
            }
            if (accountSetItemList[rowIndex].AccountSetPara != null)
            {
                txtAccountSetPara.Text = accountSetItemList[rowIndex].AccountSetPara.AccountSetParaName;
            }
        }

        private void SetGridViewRowddlBindItemDisplay(int rowIndex, List<AccountSetItem> accountSetItemList)
        {
            DropDownList ddlBindItem =
                (DropDownList) gvAccountSetItemList.Rows[rowIndex].FindControl("ddlBindItem");
            if (ddlBindItem == null)
            {
                return;
            }

            ddlBindItem.Style["display"] = "none";
            BindddlBindItem(ddlBindItem);
            if (accountSetItemList[rowIndex].AccountSetPara != null &&
                accountSetItemList[rowIndex].AccountSetPara.BindItem != null)
            {
                ddlBindItem.SelectedValue =
                    accountSetItemList[rowIndex].AccountSetPara.BindItem.Id.ToString();
            }
            if (accountSetItemList[rowIndex].AccountSetPara != null &&
                accountSetItemList[rowIndex].AccountSetPara.FieldAttribute != null &&
                accountSetItemList[rowIndex].AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.BindField.Id)
            {
                ddlBindItem.Style["display"] = "block";
            }
        }

        private void BindddlBindItem(DropDownList ddlBindItem)
        {
            List<BindItemEnum> BindItemEnumSource = BindItemEnum.GetAllBindItemsExceptNull();
            ddlBindItem.Items.Clear();
            foreach (BindItemEnum BindItem in BindItemEnumSource)
            {
                ListItem item = new ListItem(BindItem.Name, BindItem.Id.ToString(), true);
                ddlBindItem.Items.Add(item);
            }
        }

        private void SetGridViewRowddlMantissaRoundDisplay(int rowIndex, List<AccountSetItem> accountSetItemList)
        {
            DropDownList ddlMantissaRound =
                (DropDownList)gvAccountSetItemList.Rows[rowIndex].FindControl("ddlMantissaRound");
            if (ddlMantissaRound == null)
            {
                return;
            }

            ddlMantissaRound.Style["display"] = "none";
            BindddlMantissaRound(ddlMantissaRound);

            if (accountSetItemList[rowIndex].AccountSetPara != null &&
                accountSetItemList[rowIndex].AccountSetPara.AccountSetParaID != -1 &&
                accountSetItemList[rowIndex].AccountSetPara.MantissaRound != null)
            {
                ddlMantissaRound.Style["display"] = "block";
                ddlMantissaRound.SelectedValue =
                    accountSetItemList[rowIndex].AccountSetPara.MantissaRound.Id.ToString();
            }
        }

        private static void BindddlMantissaRound(DropDownList ddlMantissaRound)
        {
            List<MantissaRoundEnum> MantissaRoundEnumSource = MantissaRoundEnum.GetAllBindItemsExceptNull();
            ddlMantissaRound.Items.Clear();
            foreach (MantissaRoundEnum mantissaRound in MantissaRoundEnumSource)
            {
                ListItem item = new ListItem(mantissaRound.Name, mantissaRound.Id.ToString(), true);
                ddlMantissaRound.Items.Add(item);
            }
        }

        private void SetGridViewRowddlFieldAttributeDisplay(int rowIndex, List<AccountSetItem> accountSetItemList)
        {
            DropDownList ddlFieldAttribute =
                (DropDownList) gvAccountSetItemList.Rows[rowIndex].FindControl("ddlFieldAttribute");
            if (ddlFieldAttribute == null)
            {
                return;
            }

            ddlFieldAttribute.Style["display"] = "none";
            BindddlFieldAttribute(ddlFieldAttribute);

            if (accountSetItemList[rowIndex].AccountSetPara != null && 
                accountSetItemList[rowIndex].AccountSetPara.AccountSetParaID != -1 &&
                accountSetItemList[rowIndex].AccountSetPara.FieldAttribute != null)
            {
                ddlFieldAttribute.Style["display"] = "block";
                ddlFieldAttribute.SelectedValue =
                    accountSetItemList[rowIndex].AccountSetPara.FieldAttribute.Id.ToString();

                DropDownList ddlBindItem =
                    (DropDownList) gvAccountSetItemList.Rows[rowIndex].FindControl("ddlBindItem");
                TextBox txtCaculate = (TextBox)gvAccountSetItemList.Rows[rowIndex].FindControl("txtCaculate");
                HtmlImage imgResult = (HtmlImage)gvAccountSetItemList.Rows[rowIndex].FindControl("imgResult");
                if (txtCaculate != null && imgResult != null && ddlBindItem != null)
                {
                    ddlFieldAttribute.Attributes["onChange"] = "showBindItem('" + ddlFieldAttribute.ClientID + "','" +
                                                               FieldAttributeEnum.BindField.Id + "','" +
                                                               FieldAttributeEnum.CalculateField.Id + "','" +
                                                               ddlBindItem.ClientID + "','" +
                                                               txtCaculate.ClientID + "','" +
                                                               imgResult.ClientID + "');";
                }
            }
        }

        private static void BindddlFieldAttribute(DropDownList ddlFieldAttribute)
        {
            List<FieldAttributeEnum> FieldAttributeEnumSource = FieldAttributeEnum.GetAllBindItemsExceptNull();
            ddlFieldAttribute.Items.Clear();
            foreach (FieldAttributeEnum fieldAttribute in FieldAttributeEnumSource)
            {
                ListItem item = new ListItem(fieldAttribute.Name, fieldAttribute.Id.ToString(), true);
                ddlFieldAttribute.Items.Add(item);
            }
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton)gvAccountSetItemList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)gvAccountSetItemList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../image/file_cancel.gif border=0>";
            }
            LinkButton lbUpItem = (LinkButton)gvAccountSetItemList.Rows[rowIndex].FindControl("lbUpItem");
            if (lbUpItem != null)
            {
                lbUpItem.Text = "<img src=../../image/Up_icon.gif border=0>";
            }
            LinkButton lbDownItem = (LinkButton)gvAccountSetItemList.Rows[rowIndex].FindControl("lbDownItem");
            if (lbDownItem != null)
            {
                lbDownItem.Text = "<img src=../../image/Down_icon.gif border=0>";
            }
        }

        private void SetGridViewRowtxtCaculateDisplay(int rowIndex, List<AccountSetItem> accountSetItemList)
        {
            TextBox txtCaculate = (TextBox) gvAccountSetItemList.Rows[rowIndex].FindControl("txtCaculate");
            HtmlImage imgResult = (HtmlImage) gvAccountSetItemList.Rows[rowIndex].FindControl("imgResult");
            if (txtCaculate == null || imgResult == null)
            {
                return;
            }
            txtCaculate.Style["display"] = "none";
            imgResult.Style["display"] = "none";
            if (accountSetItemList[rowIndex].AccountSetPara != null &&
                accountSetItemList[rowIndex].AccountSetPara.FieldAttribute != null)
            {
                txtCaculate.Text = accountSetItemList[rowIndex].CalculateFormula;
                txtCaculate.Attributes["onblur"] = "postRequestServer('" +
                                                   imgResult.ClientID + "','" +
                                                   accountSetItemList[rowIndex].AccountSetPara.AccountSetParaID + "','" +
                                                   rowIndex +
                                                   "',this.value);";
                if (accountSetItemList[rowIndex].AccountSetPara.FieldAttribute.Id ==
                    FieldAttributeEnum.CalculateField.Id)
                {
                    //验证表达式 并显示结果
                    try
                    {
                        if (!string.IsNullOrEmpty(accountSetItemList[rowIndex].CalculateFormula))
                        {
                            accountSetItemList[rowIndex].CheckItemValidation(accountSetItemList);
                            imgResult.Style["display"] = "block";
                            imgResult.Src = "../../../../Pages/image/right_icon.gif";
                        }
                    }
                    catch
                    {
                        imgResult.Style["display"] = "block";
                        imgResult.Src = "../../../../Pages/image/wrong_icon.gif";
                    }
                    txtCaculate.Style["display"] = "block";
                }
            }
        }

        #endregion

        private List<AccountSetPara> _AccountSetPara;
        public List<AccountSetPara> AccountSetPara
        {
            set { _AccountSetPara = value; }
        }

        protected void gvAccountSetItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        protected void lbDeleteItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDeleteItem = sender as LinkButton;
            if (lbDeleteItem == null)
            {
                return;
            }
            GridViewRow row = lbDeleteItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (lbDeleteItemEvent != null)
            {
                lbDeleteItemEvent(row.RowIndex.ToString());
            }
        }

        protected void lbAddItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbAddItem = sender as LinkButton;
            if (lbAddItem == null)
            {
                return;
            }
            GridViewRow row = lbAddItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (lbAddNewItemEvent != null)
            {
                lbAddNewItemEvent(row.RowIndex.ToString());
            }
        }

        protected void lbDownItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDownItem = sender as LinkButton;
            if (lbDownItem == null)
            {
                return;
            }
            GridViewRow row = lbDownItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (lbDownItemEvent != null)
            {
                lbDownItemEvent(row.RowIndex.ToString());
            }
        }

        protected void lbUpItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbUpItem = sender as LinkButton;
            if (lbUpItem == null)
            {
                return;
            }
            GridViewRow row = lbUpItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (lbUpItemEvent != null)
            {
                lbUpItemEvent(row.RowIndex.ToString());
            }
        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {
            if (btnCopyEvent == null)
            {
                return;
            }
            btnCopyEvent();
        }

        protected void btnPaste_Click(object sender, EventArgs e)
        {
            if (btnPasteEvent == null)
            {
                return;
            }
            btnPasteEvent();
        }

        protected void txtAccountSetPara_OnTextChanged(object sender, EventArgs e)
        {
            TextBox txtAccountSetPara = sender as TextBox;
            if (txtAccountSetPara == null)
            {
                return;
            }
            GridViewRow row = txtAccountSetPara.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (row.RowIndex + 1 == AccountSetItemList.Count)
            {
                if (txtAccountSetParaChangedForAddEvent != null)
                {
                    txtAccountSetParaChangedForAddEvent(txtAccountSetPara.Text.Trim());
                }
            }
            else
            {
                if (txtAccountSetParaChangedForUpdateEvent != null)
                {
                    txtAccountSetParaChangedForUpdateEvent(row.RowIndex.ToString(), txtAccountSetPara.Text.Trim());
                }
            }
        }
    }
}