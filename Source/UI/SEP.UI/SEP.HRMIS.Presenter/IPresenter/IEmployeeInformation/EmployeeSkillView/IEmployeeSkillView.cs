using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView
{
    public interface IEmployeeSkillView
    {
        /// <summary>
        /// 员工技能
        /// </summary>
        List<EmployeeSkill> EmployeeSkill { get; set;}
        /// <summary>
        /// 员工技能的Session存储
        /// </summary>
        List<EmployeeSkill> EmployeeSkillSource { get; set;}

        // 新增
        event DelegateNoParameter btnAddClick;
        bool btnAddClickVisible { get; set;}
        // 修改
        event DelegateID btnUpdateClick;
        bool btnUpdateClickVisible { get; set;}
        // 删除
        event DelegateID btnDeleteClick;
        bool btnDeleteClickVisible { get; set;}

        event DelegateNoParameter SkillTypeSelectChangeEvent;

    }
}
