using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.FBQuesType
{
    public partial class FBQuesTypeView : UserControl, IFBQuesTypeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }
        private bool _ActionSuccess;

        #region IFBQuesTypeView ≥…‘±

        public string ResultMessage
        {
            //set { lblResultMessage.Text = value; }
            set
            {
                lblResultMessage.Text = value;
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
                return lblResultMessage.Text.Trim();
            }
        }

        public string Title
        {
            get
            {
                return FBQuesTypeOperation.Text.Trim();
            }
            set
            {
                FBQuesTypeOperation.Text = value;
            }
        }

        public string FBQuesTypeName
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

        public string NameMessage
        {
            get { return lblNameMessage.Text; }
            set { lblNameMessage.Text = value; }
        }

        public string FBQuesTypeID
        {
            get
            {
                return TxtID.Text.Trim();
            }
            set
            {
                TxtID.Text = value;
            }
        }

        public event  DelegateNoParameter ActionButtonEvent;

        public event DelegateNoParameter CancelButtonEvent;

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

        public bool SetIDReadonly
        {
            set { TxtID.ReadOnly = value; }
        }

        public bool SetNameReadonly
        {
            set { TxtName.ReadOnly = value; }
        }

        #endregion

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }  
    }
}