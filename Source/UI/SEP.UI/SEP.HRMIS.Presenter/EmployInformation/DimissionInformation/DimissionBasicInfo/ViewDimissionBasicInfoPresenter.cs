//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewDimissionBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �鿴��Ϣ�Ĵ��������ݰ���
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class ViewDimissionBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IDimissionBasicView _ItsView;

        public ViewDimissionBasicInfoPresenter(IDimissionBasicView itsView)
        {
            _ItsView = itsView;
        }
        
        public bool DataBind(Employee theDataToBind)
        {
            return new DimissionBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }
        
        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                new DimissionBasicInfoViewIniter(_ItsView).InitTheViewToDefault();

                //_ItsView.BtnAddFileCargoVisible = false;
                //_ItsView.BtnUpdateFileCargoVisible = false;
                //_ItsView.BtnDeleteFileCargoVisible = false;
                _ItsView.DimissionReasonTypeEnable = false;
            }
            //_ItsView.FileCargoDataView = _ItsView.FileCargoDataSource;
        }

    }
}