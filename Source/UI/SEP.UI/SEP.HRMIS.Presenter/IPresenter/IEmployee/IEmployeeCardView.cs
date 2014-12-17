//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeCardView.cs
// 创建者: 刘丹
// 创建日期: 2008-08-06
// 概述: 员工卡片界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeCardView
    {
        List<Employee> Employees { set;}
    }
}
