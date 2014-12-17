using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.Performance.Views.EmployeeInformation.SkillInfomation
{
    public partial class EmployeeSkillInfoView : UserControl, IEmployeeSkillInfoView
    {
        
        #region IEmployeeSkillInfoView ≥…‘±

        public IEmployeeSkillView IEmployeeSkillView
        {
            get
            {
                return EmployeeSkillListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IEmpSkillView IEmpSkillView
        {
            get
            {
                return EmployeeSkillView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool SkillInfoViewVisiable
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if(value)
                {
                    ModalPopupExtender1.Show();
                }
                else
                {
                    ModalPopupExtender1.Hide();
                }
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EmployeeSkillListView1.SendEmployeeSkills = SendEmployeeSkills;
        }

        private void SendEmployeeSkills(List<EmployeeSkill> employeeSkills)
        {
            EmployeeSkillView1.EmployeeSkillSource = employeeSkills;
        }
    }
}