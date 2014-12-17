using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.Skill
{
    public partial class SkillView : UserControl, ISkillView
    {

        //private readonly int _All = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divSkill');";
        }

        public string Message
        {
            get { return lblMessage.Text; }
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

        public string SkillNameMsg
        {
            get { return lblNameMsg.Text; }
            set { lblNameMsg.Text = value; }
        }

        public string SkillID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public string SkillName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string SkillType
        {
            get
            {
                return listSkillType.SelectedValue;
            }
            set
            {
                listSkillType.SelectedValue = value;
            }
        }

        public string SkillTypeMsg
        {
            get { return lblSTMsg.Text; }
            set { lblSTMsg.Text = value; }
        }

        //private List<Model.SkillType> skillTypes;

        public List<HRMISModel.SkillType> SkillTypes
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                listSkillType.Items.Clear();
                foreach (HRMISModel.SkillType skillType in value)
                {
                    listSkillType.Items.Add(new ListItem(skillType.Name, skillType.ParameterID.ToString(), true));
                }
            }
        }

        public string OperationTitle
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }

        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        public event DelegateNoParameter CancelButtonEvent;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }
    }
}