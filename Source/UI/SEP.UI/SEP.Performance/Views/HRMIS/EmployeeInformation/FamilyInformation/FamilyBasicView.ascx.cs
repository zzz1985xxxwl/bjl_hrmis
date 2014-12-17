//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyBasicView.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-10-02
// 概述: 家庭信息的基本信息界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.FamilyInformation
{
    public partial class FamilyBasicView : UserControl, IFamilyBasicInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grd.PageIndex = pageindex;
            FamilyMembersView = FamilyMembersDataSource;
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public event DelegateNoParameter BtnAddFamilyMemberEvent;
        public event DelegateID BtnUpdateFamilyMemberEvent;
        public event DelegateID BtnDeleteFamilyMemberEvent;
        public DlgFamilyMembers SendMembers;

        protected void btnAction_Click(object sender, EventArgs e)
        {
            BtnAddFamilyMemberEvent();
        }

        protected void BtnUpdate_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateFamilyMemberEvent(e.CommandArgument.ToString());
        }

        protected void BtnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteFamilyMemberEvent(e.CommandArgument.ToString());
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            FamilyMembersView = FamilyMembersDataSource;
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #region IFamilyBasicInfoView 成员

        public string FamilyAddress
        {
            get
            {
                return txtFamilyAddress.Text.Trim();
            }
            set
            {
                txtFamilyAddress.Text = value;
            }
        }
        public string FamilyAddressMessage
        {
            get
            {
                return lblAddressMessage.Text;
            }
            set
            {
                lblAddressMessage.Text = value;
            }
        }

        public string FamilyPhone
        {
            get
            {
                return txtFamilyPhone.Text.Trim();
            }
            set
            {
                txtFamilyPhone.Text = value;
            }
        }

        public string PostCode
        {
            get
            {
                return txtPostCode.Text.Trim();
            }
            set
            {
                txtPostCode.Text = value;
            }
        }

        public string PostCodeMessage
        {
            get
            {
                return lblPostCodeMessage.Text;
            }
            set
            {
                lblPostCodeMessage.Text = value;
            }
        }

        public string RPRAddress
        {
            get
            {
                return txtRPRAddress.Text.Trim();
            }
            set
            {
                txtRPRAddress.Text = value;
            }
        }

        public string RPRAddressMessage
        {
            get
            {
                return lblRPRAddressMessage.Text;
            }
            set
            {
                lblRPRAddressMessage.Text = value;
            }
        }

        public string PRPPostCode
        {
            get
            {
                return txtPRPPostCode.Text.Trim();

            }
            set
            {
                txtPRPPostCode.Text = value;
            }
        }

        public string PRPPostCodeMessage
        {
            get
            {
                return lblPRPPostCodeMessage.Text;
            }
            set
            {
                lblPRPPostCodeMessage.Text = value;
            }
        }

        public string PRPStreet
        {
            get
            {
                return txtPRPStreet.Text.Trim();
            }
            set
            {
                txtPRPStreet.Text = value;
            }
        }

        public string PRPArea
        {
            get
            {
                return txtPRPArea.Text.Trim();
            }
            set
            {
                txtPRPArea.Text = value;
            }
        }

        public string PRPAreaMessage
        {
            get
            {
                return lblPRPAreaMessage.Text;
            }
            set
            {
                lblPRPAreaMessage.Text = value;
            }
        }

        public string RecordPlace
        {
            get
            {
                return txtRecordPlace.Text.Trim();
            }
            set
            {
                txtRecordPlace.Text = value;
            }
        }

        public string EmergencyContacts
        {
            get
            {
                return txtEmergencyContacts.Text.Trim();
            }
            set
            {
                txtEmergencyContacts.Text = value;
            }
        }
        public string ChildName1
        {
            get
            {
                return txtChildName.Text.Trim();
            }
            set
            {
                txtChildName.Text = value;
            }
        }

        public string ChildBirthday1
        {
            get
            {
                return txtChildBirthday.Text.Trim();
            }
            set
            {
                txtChildBirthday.Text = value;
            }
        }

        public string ChildBirthday1Message
        {
            get
            {
                return lblChildBirthdayMessage.Text.Trim();
            }
            set
            {
                lblChildBirthdayMessage.Text = value;
            }
        }

        public string ChildName2
        {
            get
            {
                return txtChildName2.Text.Trim();
            }
            set
            {
                txtChildName2.Text = value;
            }
        }

        public string ChildBirthday2Message
        {
            get
            {
                return lblChildBirthday2Message.Text.Trim();
            }
            set
            {
                lblChildBirthday2Message.Text = value;
            }
        }

        public string ChildBirthday2
        {
            get
            {
                return txtChildBirthday2.Text.Trim();
            }
            set
            {
                txtChildBirthday2.Text = value;
            }
        }

        public List<FamilyMember> FamilyMembersView
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                //ViewState["FamilyMember"] = value;
                //if (SendMembers != null)
                //{
                //    SendMembers(value);
                //}
                grd.DataSource = value;
                grd.DataBind();
                if(value!=null&&value.Count!=0)
                {
                    Result.Visible = true;
                }
                else
                {
                    Result.Visible = false;
                }
            }
        }

        public List<FamilyMember> FamilyMembersDataSource
        {
            get
            {
                return (List<FamilyMember>)ViewState["FamilyMember"];
            }
            set
            {
                ViewState["FamilyMember"] = value;
                if(SendMembers!=null)
                {
                    SendMembers(value);
                }
            }
        }

        public bool BtnAddFamilyMemberVisible
        {
            get
            {
                return btnAction.Visible;
            }
            set
            {
                btnAction.Visible = value;
            }
        }

        public bool BtnUpdateFamilyMemberVisible
        {
            get
            {
                return grd.Columns[8].Visible;
            }
            set
            {
                grd.Columns[8].Visible = value;
            }
        }

        public bool BtnDeleteFamilyMemberVisible
        {
            get
            {
                return grd.Columns[9].Visible;
            }
            set
            {
                grd.Columns[9].Visible = value;
            }
        }

        #endregion
    }
}