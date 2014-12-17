using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView
{
    public interface IEmployeeSkillInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IEmployeeSkillView IEmployeeSkillView { get; set;}
        /// <summary>
        /// С����
        /// </summary>
        IEmpSkillView IEmpSkillView { get; set;}
        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool SkillInfoViewVisiable{ get; set;}
    }

    public delegate void DlgEmployeeSkills(List<EmployeeSkill> employeeSkills);

}
