//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewSkillInfoPresenter.cs
// ������: ���޾�
// ��������: 2008-11-06
// ����: Ա�����ܵ�Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class ViewSkillInfoPresenter : IViewEmployeePresenter
    {
        private readonly ViewSkillBasicInfoPresenter _BasicPresenter;

        public ViewSkillInfoPresenter(IEmployeeSkillInfoView itsView)
        {
            _BasicPresenter = new  ViewSkillBasicInfoPresenter(itsView.IEmployeeSkillView);
            AttachViewEvent();
        }

        public bool DataBind(Model.Employee theDataToBind)
        {
            return _BasicPresenter.DataBind(theDataToBind);
        }


        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);         
        }

      
    }
}
