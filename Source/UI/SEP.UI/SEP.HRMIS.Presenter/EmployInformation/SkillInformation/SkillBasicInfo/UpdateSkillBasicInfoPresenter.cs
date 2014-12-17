//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateSkillBasicInfoPresenter.cs
// ������: ���޾�
// ��������: 2008-11-06
// ����: Ա�����ܵ�Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo
{
    public class UpdateSkillBasicInfoPresenter : IUpdateEmployeePresenter
    {
        private IEmployeeSkillView _ItsView;

        public UpdateSkillBasicInfoPresenter(IEmployeeSkillView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }


        public bool DataBind(Employee theDataToBind)
        {
            return new SkillBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
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

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                //Session����Ϊ��
                _ItsView.EmployeeSkillSource = new List<EmployeeSkill>();

                _ItsView.btnAddClickVisible = true;
                _ItsView.btnUpdateClickVisible = true;
                _ItsView.btnDeleteClickVisible = true;
            }
            _ItsView.EmployeeSkill = _ItsView.EmployeeSkillSource;

        }

    }
}
