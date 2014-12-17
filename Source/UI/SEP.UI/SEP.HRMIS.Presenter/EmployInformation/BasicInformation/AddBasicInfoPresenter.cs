//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeDetailBasicPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-09-04
// 概述: 员工新增基本信息的
// 修改: 整理代码，分离表示层对象 by 倪豪
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class AddBasicInfoPresenter:IAddEmployeePresenter
    {
        protected readonly IBasicInfoView _ItsView;

        public AddBasicInfoPresenter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if(!pageIsPostBack)
            {
                //初始化员工基本信
                BasicInfoViewIniter theViewIniter = new BasicInfoViewIniter(_ItsView);
                theViewIniter.InitTheViewToDefault();
                _ItsView.PhotoHref = "javascript:PhotoHiddenBtnClick();";
            }
        }
        public bool Vaildate()
        {
            //验证
            BasicInfoVaildater theVaildater = new BasicInfoVaildater(_ItsView);
            return theVaildater.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            BasicInfoDataCollector theDataCollector = new BasicInfoDataCollector(_ItsView);
            //员工基本信息数据收集
            theDataCollector.CompleteTheObject(theObjectToComplete);
            //为员工的帐号设置默认密码
            //移到业务层
            //theObjectToComplete.AccountsFront.SetDefaultPassword();
        }
    }
}
