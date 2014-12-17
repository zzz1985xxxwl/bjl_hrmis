using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.DimissionInformation
{
    public partial class FileCargosView : UserControl,IFileCargoView
    {
        public event DelegateNoParameter BtnActionEvent;
        public event DelegateNoParameter BtnCancelEvent;
        private bool _ActionSuccess;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            BtnActionEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }

        #region IFileCargoView ≥…‘±

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string Id
        {
            get
            {
                return lblId.Text;
            }
            set
            {
                lblId.Text = value;
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

        public string FileCargoName
        {
            get { return ddFileCargoType.SelectedItem.Value; }
            set { ddFileCargoType.SelectedValue = value; }
        }

        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
            set { txtRemark.Text = value; }
        }

        public List<FileCargoName> FileCargoNameSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach(FileCargoName fcn in value)
                {
                    ddFileCargoType.Items.Add(new ListItem(fcn.Name,fcn.Id.ToString()));
                }
            }
        }

        public List<FileCargo> FileCargoDataSource
        {
            get
            {
               // return Session["FileCargo"] as List<FileCargo>;
                return (List<FileCargo>)ViewState["_FileCargo"];
            }
            set
            {
                //Session["FileCargo"] = value;
                ViewState["_FileCargo"] = value;

            }
        }

        #endregion
    }
}