//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewFamilyInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �鿴��ͥ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation
{
    public class ViewFamilyInfoPresenter:IViewEmployeePresenter
    {
       private readonly ViewFamilyBasicInfoPresenter _BasicPresenter;

        public ViewFamilyInfoPresenter(IFamilyInfoView itsView)
        {
            _BasicPresenter = new ViewFamilyBasicInfoPresenter(itsView.FamilyBasicInfoView);
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
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