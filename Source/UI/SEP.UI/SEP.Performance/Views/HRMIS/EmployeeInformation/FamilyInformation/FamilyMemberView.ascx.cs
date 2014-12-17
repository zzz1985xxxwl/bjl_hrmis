using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.FamilyInformation
{
    public partial class FamilyMemberView : UserControl, IFamilyMemberView
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
        
        #region IFamilyMemberView ≥…‘±
        
        public string Id
        {
            get
            {
                return lblID.Text;
            }
            set
            {
                lblID.Text = value;
            }
        }

        public string Title
        {
            get
            {
                return lblTitle.Text.Trim();

            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public string Name
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

        public string NameMessage
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }
        
        public string Relationship
        {
            get
            {
                return txtRelationShip.Text.Trim();
            }
            set
            {
                txtRelationShip.Text = value;
            }
        }

        public string RelationshipMessage
        {
            get
            {
                return lblRelationShip.Text;

            }
            set
            {
                lblRelationShip.Text = value;
            }
        }

        public string Age
        {
            get
            {
                return txtAge.Text.Trim();
            }
            set
            {
                txtAge.Text = value;
            }
        }

        public string AgeMessage
        {
            get
            {
                return lblAge.Text.Trim();
            }
            set
            {
                lblAge.Text = value;
            }
        }

        public string Birthday
        {
            get
            {
                return txtBirthday.Text.Trim();
            }
            set
            {
                txtBirthday.Text = value;
            }
        }

        public string BirthdayMessage
        {
            get
            {
                return lblBirthday.Text.Trim();
            }
            set
            {
                lblBirthday.Text = value;
            }
        }

        public string Company
        {
            get
            {
                return txtCompany.Text.Trim();
            }
            set
            {
                txtCompany.Text = value;
            }
        }

        public string Remark
        {
            get
            {
                return txtRemark.Text.Trim();

            }
            set
            {
                txtRemark.Text = value;
            }
        }

        public List<FamilyMember> FamilyMemberDataSource
        {
            get
            {
                //return Session["FamilyMember"] as List<FamilyMember>;
                return (List<FamilyMember>) ViewState["FamilyMember"];
            }
            set
            {
                //Session["FamilyMember"] = value;
                ViewState["FamilyMember"] = value;
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

        #endregion
    }
}