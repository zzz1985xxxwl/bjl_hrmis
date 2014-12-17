//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateDimissionInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 修改离职信息的总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation
{
    public class UpdateDimissionInfoPresenter : AddUpdateDimissionPresenterBase,IUpdateEmployeePresenter
    {
        private readonly UpdateDimissionBasicInfoPresenter _BasicPresenter;


        public UpdateDimissionInfoPresenter(IDimissionInfoView itsView)
            :base(itsView)
        {
            _BasicPresenter = new UpdateDimissionBasicInfoPresenter(itsView.DimmissionBasicView);
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