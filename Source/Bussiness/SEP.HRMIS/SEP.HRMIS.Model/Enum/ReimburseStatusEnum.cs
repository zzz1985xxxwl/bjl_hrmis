//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReimburseStatusEnum.cs
// 创建者: 王莎莉
// 创建日期: 2008-10-06
// 概述: 报销单状态
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum ReimburseStatusEnum
    {
        Added,  //新增
        Reimbursing,  //提交中
        Reimbursed,       //已报销
        Return,//退回
        Auditing,//通过审核
        WaitAudit,//待财务审核
        All=-1
    }
}
