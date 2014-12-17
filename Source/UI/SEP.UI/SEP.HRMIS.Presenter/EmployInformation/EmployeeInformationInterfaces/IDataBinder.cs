//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 数据绑定接口，将对象绑定到view
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces
{
    public interface IDataBinder<T>
    {
        bool DataBind(T theDataToBind);
    }
}