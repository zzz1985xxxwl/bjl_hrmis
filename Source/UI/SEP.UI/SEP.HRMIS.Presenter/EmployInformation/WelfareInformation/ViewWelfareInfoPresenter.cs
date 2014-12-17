//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewWelfareInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 查看福利界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class ViewWelfareInfoPresenter:IViewEmployeePresenter
    {
         private readonly IWelfareInfoView _ItsView;

        public  ViewWelfareInfoPresenter(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new WelfareInfoDataBinder(_ItsView).DataBind(theDataToBind);
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
                welfareInfoViewIniter.InitTheViewToDefault();
            }
        }
    }
}