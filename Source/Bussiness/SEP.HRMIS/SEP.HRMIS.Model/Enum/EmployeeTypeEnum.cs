//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeTypeEnum.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-12
// 概述: 员工类型
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工类型
    /// </summary>
    public enum EmployeeTypeEnum
    {  
        /// <summary>
        /// 全部
        /// </summary>
        All=-1,
        /// <summary>
        /// 实习
        /// </summary>
        PracticeEmployee,
        /// <summary>
        /// 试用
        /// </summary>
        ProbationEmployee,
        /// <summary>
        /// 正式
        /// </summary>
        NormalEmployee,
        /// <summary>
        /// 兼职
        /// </summary>
        PartTimeEmployee,
        /// <summary>
        /// 离职
        /// </summary>
        DimissionEmployee,        
        /// <summary>
        /// 借用
        /// </summary>
        BorrowedEmployee,
        /// <summary>
        /// 退休
        /// </summary>
        Retirement,
        /// <summary>
        /// 退聘
        /// </summary>
        RetirementHire,
        /// <summary>
        /// 劳务
        /// </summary>
        WorkEmployee
    }
}
