//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: OutInRecordOperateStatusEnum.cs
// 创建者: wangyueqi
// 创建日期: 2008-10-16
// 概述: 进出记录的操作类型
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    public enum OutInRecordOperateStatusEnum
    {
        All=-1,
        /// <summary>
        /// 0:表示从OA数据库读入
        /// </summary>
        ReadFromDataBase = 0,
        /// <summary>
        /// 1：考勤人员新增
        /// </summary>
        AddByOperator = 1,
        /// <summary>
        /// 2：考勤人员修改
        /// </summary>
        ModifyByOperator = 2,
        /// <summary>
        /// 3:考勤人员删除
        /// </summary>
        DeleteByOperator = 3,

        /// <summary>
        /// 4:考勤人员外借XLS表导入
        /// </summary>
        ImportByOperator = 4

    }
}
