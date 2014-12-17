//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateDimissionBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �޸���ְ��Ϣ�Ĵ�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class UpdateDimissionBasicInfoPresenter : AddUpdateDimissionBasicInfoPresenterBase,IUpdateEmployeePresenter
    {
        public UpdateDimissionBasicInfoPresenter(IDimissionBasicView itsView)
            :base(itsView)
        {
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new DimissionBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return new DimissionBasicInfoVaildater(_ItsView).Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new DimissionBasicInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                new DimissionBasicInfoViewIniter(_ItsView).InitTheViewToDefault();

                //_ItsView.BtnAddFileCargoVisible = true;
                //_ItsView.BtnUpdateFileCargoVisible = true;
                //_ItsView.BtnDeleteFileCargoVisible = true;
                _ItsView.DimissionReasonTypeEnable = true;
            }
            //_ItsView.FileCargoDataView = _ItsView.FileCargoDataSource;
        }
    }
}