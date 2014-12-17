//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeSkillListPresenter.cs
// ������: ���޾�
// ��������: 2008-11-06
// ����: Ա�����ܵ�Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillListPresenter : IAddEmployeePresenter
    {
        private readonly IEmployeeSkillView _ItsView;


        public EmployeeSkillListPresenter(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool isPostBack)
        {           

            if (!isPostBack)
            {
                //Session����Ϊ��
                _ItsView.EmployeeSkillSource = new List<EmployeeSkill>();

                _ItsView.btnAddClickVisible = true;
                _ItsView.btnUpdateClickVisible = true;
                _ItsView.btnDeleteClickVisible = true;
            }
            _ItsView.EmployeeSkill = _ItsView.EmployeeSkillSource;
        }

        public bool Vaildate()
        {
            return true;
        }


        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new SkillBasicInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }


        public void AttachViewEvent()
        {
        }

    }
}
