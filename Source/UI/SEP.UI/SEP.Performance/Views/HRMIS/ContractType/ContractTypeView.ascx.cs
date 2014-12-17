//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeView.ascx.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-08
// 概述: 合同类型的小界面
// ----------------------------------------------------------------
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.ContractType
{
    public partial class ContractTypeView : UserControl, IContractType
    {
        private bool _ActionSuccess;
        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }
        //btnCancel.OnClientClick
        //return CloseModalPopupExtender('" + _IEmployeeReimburseView.divMPEReimburseClientID +"');";

        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }
            //_IEmployeeReimburseView.IReimburseItemView.btnCancelOnClientClick = "return CloseModalPopupExtender('" + _IEmployeeReimburseView.divMPEReimburseClientID +
            //                                   "');";

        #region IContractType 成员

        public string ContractTypeID
        {
            get
            {
                return txtID.Text.Trim();
            }
            set
            {
                txtID.Text = value;
            }
        }

        public string ContractTypeName
        {
            get
            {
                return txtName.Text.Trim();
            }
            set
            {
                txtName.Text = value;
            }
        }

        /// <summary>
        /// 判断文件格式
        /// </summary>
        public bool CheckFileType
        {
            get
            {
                if (!fuTemplate.HasFile)
                {
                    return true;
                }
                
                //string fileContentType = fuTemplate.PostedFile.ContentType;
                var fileContentType=Path.GetExtension(fuTemplate.PostedFile.FileName);
                switch (fileContentType)
                {
                    case ".doc":
                        return true;
                    case ".docx":
                        return true;
                    default:
                        return false;
                }
            }
            set { }//For Test
        }
        public byte[] ContractTypeTemplate
        {
            get
            {
                if (fuTemplate.HasFile)
                {
                    if (CheckFileType)
                    {
                        HttpPostedFile hpfTemplate = fuTemplate.PostedFile;
                        int upPhotoLength = hpfTemplate.ContentLength;
                        byte[] array = new Byte[upPhotoLength];
                        Stream templatestream = hpfTemplate.InputStream;
                        templatestream.Read(array, 0, upPhotoLength);
                        return array;
                    }
                }
                return null;
            }
        }
      

        public string ResultMessage
        {
            set
            {
                lblResultMessage.Text = value;
                tbNoDataMessage.Style["display"] = String.IsNullOrEmpty(value) ? "none" : "block";
            }
            get
            {
                return lblResultMessage.Text;
            }
        }

        public string ValidateID
        {
            get
            {
                return lblValidateID.Text;
            }
            set
            {
                lblValidateID.Text = value;
            }
        }

        public string ValidateName
        {
            get
            {
                return lblValidateName.Text;
            }
            set
            {
                lblValidateName.Text = value;
            }
        }

        public bool SetReadonly
        {
            get
            {
                return txtName.ReadOnly; 
            }
            set
            {
                txtName.ReadOnly = value; 
            }
        }

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                 lblTitle.Text = value; 
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

        public bool ActionButtonEnable
        {
            get
            {
                return btnOK.Visible;
            }
            set
            {
                btnOK.Visible = value;
            }
        }

        #endregion

    }
}

#region 过期代码
//public partial class ContractTypeView : UserControl, IContractTypeView
    //{
    //    public string ContractTypeID
    //    {
    //        get
    //        {
    //            return txtID.Text.Trim();
    //        }
    //        set
    //        {
    //            txtID.Text = value;
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
    //            txtName.Text = value;
    //        }
    //    }

    //    public string ResultMessage
    //    {
    //        set
    //        {
    //            lblResultMessage.Text = value;
    //            tbNoDataMessage.Style["display"] = String.IsNullOrEmpty(value) ? "none" : "block";
    //        }
    //        get
    //        {
    //            return lblResultMessage.Text;
    //        }
    //    }

    //    public string ValidateID
    //    {
    //        get
    //        {
    //            return lblValidateID.Text;
    //        }
    //        set
    //        {
    //            lblValidateID.Text = value;
    //        }
    //    }

    //    public string ValidateName
    //    {
    //        get
    //        {
    //            return lblValidateName.Text;
    //        }
    //        set
    //        {
    //             lblValidateName.Text = value;
    //        }
    //    }

    //    public bool SetReadonly
    //    {
    //        set
    //        {
    //            txtName.ReadOnly = value; 
    //        }
    //    }

    //    public string Title
    //    {
    //        set { lblTitle.Text = value; }
    //    }

    //    public event EventHandler btnOKClick;
    //    protected void btnOK_ServerClick(object sender, EventArgs e)
    //    {
    //        btnOKClick(sender, e);
    //        _UpdateListWindow();
    //    }

    //    public event EventHandler btnCancelServerClick;
    //    protected void btnCancel_ServerClick(object sender, EventArgs e)
    //    {
    //        btnCancelServerClick(sender, e);
    //    }

    //    public delegate void UpdateListWindow();
    //    public UpdateListWindow _UpdateListWindow;
    //}
#endregion
