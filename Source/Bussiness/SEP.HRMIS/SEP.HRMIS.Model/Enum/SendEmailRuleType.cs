//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SendEmailRullType.cs
// 创建者: 刘丹
// 创建日期: 2008-10-15
// 概述: 读取考勤后，发送给人事邮件的规则
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum SendEmailRuleType
    {
        InEmpty,    //找进入时间为空的记录，发送给人事
        OutEmpty,   //找出去时间为空的记录，发送给人事
        InAndOutEmpty, //找进入时间和出去时间都为空的记录，发送给人事
        InOrOutEmpty  //找进入时间或者出去时间为空的记录，发送给人事
 
    }
}
