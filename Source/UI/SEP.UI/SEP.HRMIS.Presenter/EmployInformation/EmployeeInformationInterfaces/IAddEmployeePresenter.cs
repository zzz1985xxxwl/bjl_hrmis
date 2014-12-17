//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAddEmployeePresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: Employee的新增的每一个tab页面应当实现该接口
// ----------------------------------------------------------------
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces
{
    public interface IAddEmployeePresenter : IVaildater, IDataCollector<Employee>, IEmployeeBasePresenter
    {
    }
}