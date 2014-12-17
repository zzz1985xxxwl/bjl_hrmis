//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 数据收集接口，将view的数据赋给对象
// ----------------------------------------------------------------
namespace SEP.Presenter.IPresenter
{
    public interface IDataCollector<T>
    {
        void CompleteTheObject(T theObjectToComplete);
    }
}