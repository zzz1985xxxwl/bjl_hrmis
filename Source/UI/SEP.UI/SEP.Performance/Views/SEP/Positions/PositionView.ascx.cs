//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名:PositionView.cs
// 创建者: colbert
// 创建日期: 2009-03-03
// 概述: 职位信息
// ----------------------------------------------------------------

using System;
using System.Web.UI;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.SEP.Positions
{
    public partial class PositionView : UserControl, IPositionView
    {
        private bool _ActionSuccess;
        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

        public string positionName
        {

            get
            {
                return TxtName.Text.Trim();
            }
            set
            {
                TxtName.Text = value;
            }

        }

        public string positionID
        {
            get
            {
                return lblNum.Text;

            }
            set
            {
                lblNum.Text = value;
            }

        }

        public bool SetReadonly
        {
            set
            {
                TxtName.ReadOnly = value;
                //ddlGrade.Enabled = !value;
                txtDescription.ReadOnly = value;
            }
        }

        public string OperationType
        {
            get
            {
                try
                {
                    return ViewState["OperationType"].ToString();
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                ViewState["OperationType"] = value;
            }
        }
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
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

        //public string PositionGradeNullMessage
        //{
        //    set
        //    {
        //        lbGradeNullMessage.Text = value;
        //    }
        //    get
        //    {
        //        return lbGradeNullMessage.Text.Trim();
        //    }
        //}

        //public List<PositionGrade> PositionGradeSource
        //{
        //    get
        //    {
        //        throw new Exception("The method or operation is not implemented.");
        //    }
        //    set
        //    {
        //        ddlGrade.Items.Clear();
        //        foreach (PositionGrade positionGrade in value)
        //        {
        //            ddlGrade.Items.Add(new ListItem(positionGrade.Name, positionGrade.Id.ToString(), true));
        //        }
        //    }
        //}

        //public string PositionGradeId
        //{
        //    get
        //    {
        //        return ddlGrade.SelectedValue;
        //    }
        //    set
        //    {
        //        ddlGrade.SelectedValue = value;
        //    }
        //}

        public Account Operator
        {
            get
            {
                return Session[SessionKeys.LOGININFO] as Account;
            }
        }

        //public string PositionGradeName
        //{
        //    get
        //    {
        //        return ddlGrade.Text;
        //    }
        //    set
        //    {
        //        ddlGrade.Text = value;
        //    }
        //}

        #region IPositionView 成员

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
        }

        public string PositionMsg
        {
            set
            {
                lbNameMsg.Text = value;
            }
        }

        //public string GradeMsg
        //{
        //    set
        //    {
        //        lbGradeNullMessage.Text = value;
        //    }
        //}

        public string Title
        {
            set
            {
                PositionOperation.Text = value;
            }
        }

        public string CancelButtonClientEvent
        {
            set
            {
                BtnCancel.OnClientClick = value;
            }
        }

        #endregion
    }
}
