//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFamilyInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �޸ļ�ͥ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation
{
    public class UpdateFamilyInfoPresenter : AddUpdateFamilyInfoPresenterBase, IUpdateEmployeePresenter
    {
        private readonly UpdateFamilyBasicInfoPresenter _BasicPresenter;

        public UpdateFamilyInfoPresenter(IFamilyInfoView itsView)
            : base(itsView)
        {
            _BasicPresenter = new UpdateFamilyBasicInfoPresenter(itsView.FamilyBasicInfoView);
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return _BasicPresenter.DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _BasicPresenter.CompleteTheObject(theObjectToComplete);
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