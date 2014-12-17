//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名:AccountSetParaView.cs
// 创建者: wyq
// 创建日期: 2008-12-25
// 概述: 增加AccountSetParaView
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.HRMIS.Model.PayModule;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class AccountSetParaView : UserControl, IAccountSetParaView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPEAccountSetParaView');";
        }
        private bool _ActionSuccess;

        #region IAccountSetParaView
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        public event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        public event DelegateNoParameter CancelButtonEvent;

        public string AccountSetParaNameMsg
        {
            set
            {
                lblValidateName.Text = value;
            }
            get
            {
                return lblValidateName.Text.Trim();
            }
        }

        public string BindItemMsg
        {
            get { return lblValidateBindItem.Text; }
            set
            {
                lblValidateBindItem.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    ShowBindItem = true;
                }
            }
        }

        public string Message
        {
            set
            {
                LabResultMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbResultMessage.Style["display"] = "none";
                }
                else
                {
                    tbResultMessage.Style["display"] = "block";
                }
            }
            get
            {
                return LabResultMessage.Text.Trim();
            }
        }

        public string OperationTitle
        {
            get
            {
                return AccountSetParaOperation.Text;
            }
            set
            {
                AccountSetParaOperation.Text = value;
            }
        }

        public string AccountSetParaName
        {
            get
            {
                return TxtName.Text.Trim();

            }
            set { TxtName.Text = value; }
        }

        public string OperationType
        {
            get
            {
                return Operation.Value;
            }
            set
            {
                Operation.Value = value;
            }
        }

        public string AccountSetParaID
        {
            get
            {
                return lblAccountSetParaId.Text;
            }
            set { lblAccountSetParaId.Text = value; }
        }

        public string Description
        {
            get
            {
                return TxtDescrition.Text;

            }
            set
            {
                TxtDescrition.Text = value;
            }
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
                ddlFieldAttribute.Attributes["onChange"] = "showBindItem('" + ddlFieldAttribute.ClientID + "','" +
                                                           FieldAttributeEnum.BindField.Id + "','" +
                                                           divBindItem1.ClientID + "','" +
                                                           divBindItem2.ClientID + "');";
                ShowBindItem = SelectedFieldAttribute.Id == FieldAttributeEnum.CalculateField.Id ? true : false;
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
                if (value.Id == FieldAttributeEnum.BindField.Id)
                {
                    ShowBindItem = true;
                }
            }
        }
        public bool ShowBindItem
        {
            set
            {
                if (value)
                {
                    divBindItem1.Style["display"] = "block";
                    divBindItem2.Style["display"] = "block";
                }
                else
                {
                    divBindItem1.Style["display"] = "none";
                    divBindItem2.Style["display"] = "none";

                }
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

        public bool ActionSuccess
        {
            get
            {
                return _ActionSuccess;
            }
            set
            {
                _ActionSuccess = value;
            }
        }

        public bool SetReadonly
        {
            set
            {
                TxtName.ReadOnly = value;
                TxtDescrition.ReadOnly = value;
                ddlBindItem.Enabled = !value;
                ddlFieldAttribute.Enabled = !value;
                ddlMantissaRound.Enabled = !value;
                cbIsVisibleWhenZero.Enabled = !value;
                cbIsVisibleToEmployee.Enabled = !value;
            }
            get
            {
                return TxtName.ReadOnly;
            }
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

        public bool IsVisibleToEmployee
        {
            get { return cbIsVisibleToEmployee.Checked; }
            set { cbIsVisibleToEmployee.Checked = value; }
        }

        public bool IsVisibleWhenZero
        {
            get { return cbIsVisibleWhenZero.Checked; }
            set { cbIsVisibleWhenZero.Checked = value; }
        }

        #endregion


        protected void BtnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

    }
}