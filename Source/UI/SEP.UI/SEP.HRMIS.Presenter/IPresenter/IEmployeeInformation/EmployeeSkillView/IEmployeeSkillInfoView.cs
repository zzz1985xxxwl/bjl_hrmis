using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView
{
    public interface IEmployeeSkillInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IEmployeeSkillView IEmployeeSkillView { get; set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IEmpSkillView IEmpSkillView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool SkillInfoViewVisiable{ get; set;}
    }

    public delegate void DlgEmployeeSkills(List<EmployeeSkill> employeeSkills);

}
