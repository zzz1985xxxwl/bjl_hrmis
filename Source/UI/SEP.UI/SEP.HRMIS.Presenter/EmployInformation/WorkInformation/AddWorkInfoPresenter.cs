//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddWorkInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增工作信息界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class AddWorkInfoPresenter:WorkInfoPresenterBase,IAddEmployeePresenter
    {
        public AddWorkInfoPresenter(IWorkInfoView itsView)
            :base(itsView)
        {
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return new WorkInfoVaildater(_ItsView).Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new WorkInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if(!pageIsPostBack)
            {
                _ItsView.ContractManageVisible = false;
                new WorkInfoViewIniter(_ItsView).InitTheViewToDefault();
                FatherSelectChangeEvent();
                DepartmentSelectChangeEvent();
            }
        }
    }
}