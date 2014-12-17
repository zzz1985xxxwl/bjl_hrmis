//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeDetailBasicPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-21
// 概述: 显示员工基本信息的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class ViewBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IBasicInfoView _ItsView;

        public ViewBasicInfoPresenter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            BasicInfoDataBinder theDataBinder = new BasicInfoDataBinder(_ItsView);
            return theDataBinder.DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                BasicInfoViewIniter theIniter = new BasicInfoViewIniter(_ItsView);
                theIniter.InitTheViewToDefault();
            }
        }
    }
}