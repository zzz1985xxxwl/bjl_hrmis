//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewDimissionInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 查看离职信息的总界面的Presenter
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