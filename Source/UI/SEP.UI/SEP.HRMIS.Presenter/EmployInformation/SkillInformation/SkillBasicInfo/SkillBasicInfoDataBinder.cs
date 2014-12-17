//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillBasicInfoDataBinder.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;

using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo
{
    public class SkillBasicInfoDataBinder : IDataBinder<Employee>
    {
        private readonly IEmployeeSkillView _ItsView;
        private Employee _TheEmployeToShow;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public SkillBasicInfoDataBinder(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheEmployeToShow = theDataToBind;
            bool retVal = true;
            if (_TheEmployeToShow != null)
            {
                retVal &= HandleEmployeeSkills();
            }
            return retVal;

        }
        
        private bool HandleEmployeeSkills()
        {
            Employee employee = _IEmployeeFacade.GetEmployeeSkillInfoByAccountID(_TheEmployeToShow.Account.Id);
            _TheEmployeToShow.EmployeeSkills = employee.EmployeeSkills;

            if(_TheEmployeToShow.EmployeeSkills != null)
            {
                _ItsView.EmployeeSkill = _TheEmployeToShow.EmployeeSkills;
                _ItsView.EmployeeSkillSource = _TheEmployeToShow.EmployeeSkills;

            }
            return true;
        }
    }
}
