//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillInfoPresenter.cs
// ������: ���޾�
// ��������: 2008-11-06
// ����: Ա�����ܵ�Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class AddSkillInfoPresenter : EmployeeSkillPresenter, IAddEmployeePresenter
    {
        private readonly EmployeeSkillListPresenter _BasicPresenter;

        public AddSkillInfoPresenter(IEmployeeSkillInfoView itsView) : base(itsView)
        {
            _BasicPresenter = new EmployeeSkillListPresenter(itsView.IEmployeeSkillView);
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }

        public void CompleteTheObject(Model.Employee theObjectToComplete)
        {
            _BasicPresenter.CompleteTheObject(theObjectToComplete);
        }


        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);
        }

        public void AttachViewEvent()
        {
        }
    }
}
