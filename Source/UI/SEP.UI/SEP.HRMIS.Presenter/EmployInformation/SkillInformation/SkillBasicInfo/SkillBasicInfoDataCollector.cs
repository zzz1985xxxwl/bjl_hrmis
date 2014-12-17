//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SkillBasicInfoDataCollector.cs
// ������: ���޾�
// ��������: 2008-11-06
// ����: Ա�����ܵ�Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo
{
    public class SkillBasicInfoDataCollector : IDataCollector<Employee>
    {
        private readonly IEmployeeSkillView _ItsView;
        private Employee _TheEmployeeToComplete;

        public SkillBasicInfoDataCollector(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _TheEmployeeToComplete = theObjectToComplete;
            if (_TheEmployeeToComplete == null)
            {
                throw new Exception(EmployeePresenterUtilitys._ObjectIsNull);
            }
            HandleSkillInfo();
        }

        private void HandleSkillInfo()
        {
            _TheEmployeeToComplete.EmployeeSkills = _ItsView.EmployeeSkillSource;
        }
    }
}
