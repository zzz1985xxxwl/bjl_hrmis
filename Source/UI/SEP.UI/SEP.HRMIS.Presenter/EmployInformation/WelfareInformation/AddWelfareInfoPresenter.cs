//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增福利界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class AddWelfareInfoPresenter:IAddEmployeePresenter
    {
        private readonly IWelfareInfoView _ItsView;

        public  AddWelfareInfoPresenter(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool Vaildate()
        {
           return  new WelfareInfoVaildater(_ItsView).Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new WelfareInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            WelfareInfoViewIniter welfareInfoViewIniter = new WelfareInfoViewIniter(_ItsView);
            welfareInfoViewIniter.SetFiledAndMessageEmpty();
            if (!pageIsPostBack)
            {
                _ItsView.EmployeeWelfareHistory = null;
                welfareInfoViewIniter.InitTheViewToDefault();
            }
        }

    }
}