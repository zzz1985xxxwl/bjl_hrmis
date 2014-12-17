//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ICheckRule.cs
// 创建者:wang shali,tang.manli
// 创建日期: 2008-05-20
// 概述: 系统定时判断员工是否满足考核条件
// ----------------------------------------------------------------
namespace SEP.HRMIS.Bll.AssessActivity
{
    public interface ICheckRule
    {
        void CheckRule(int employeeID);
    }
}
