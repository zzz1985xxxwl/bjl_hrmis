//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFamilyBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �޸ļ�ͥ�Ĵ�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class ViewFamilyBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IFamilyBasicInfoView _ItsView;

        public ViewFamilyBasicInfoPresenter(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new FamilyBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                new FamilyBasicInfoViewIniter(_ItsView).InitTheViewToDefault();

                _ItsView.BtnAddFamilyMemberVisible = false;
                _ItsView.BtnUpdateFamilyMemberVisible = false;
                _ItsView.BtnDeleteFamilyMemberVisible = false;
            }
            _ItsView.FamilyMembersView = _ItsView.FamilyMembersDataSource;
        }
    }
}