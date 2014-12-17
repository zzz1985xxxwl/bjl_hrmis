//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewDimissionInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �鿴��ְ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation
{
    public class ViewDimissionInfoPresenter : IViewEmployeePresenter
    {
        private readonly ViewDimissionBasicInfoPresenter _BasicPresenter;

        public ViewDimissionInfoPresenter(IDimissionInfoView itsView)
        {
            _BasicPresenter = new ViewDimissionBasicInfoPresenter(itsView.DimmissionBasicView);
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