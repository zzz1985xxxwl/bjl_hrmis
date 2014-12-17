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
        /// Ա������
        /// </summary>
        List<EmployeeSkill> EmployeeSkill { get; set;}
        /// <summary>
        /// Ա�����ܵ�Session�洢
        /// </summary>
        List<EmployeeSkill> EmployeeSkillSource { get; set;}

        // ����
        event DelegateNoParameter btnAddClick;
        bool btnAddClickVisible { get; set;}
        // �޸�
        event DelegateID btnUpdateClick;
        bool btnUpdateClickVisible { get; set;}
        // ɾ��
        event DelegateID btnDeleteClick;
        bool btnDeleteClickVisible { get; set;}

        event DelegateNoParameter SkillTypeSelectChangeEvent;

    }
}
