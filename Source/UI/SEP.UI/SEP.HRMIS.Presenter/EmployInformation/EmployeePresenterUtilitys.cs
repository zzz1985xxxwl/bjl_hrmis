//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: EmployeePresenterUtilitys.cs
// 创建者: 倪豪
// 创建日期: 2008-06-16
// 概述: 所有EmployeeView相关的常量字段，以及多处使用的方法都置于此类
// ----------------------------------------------------------------
using System.Text.RegularExpressions;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public static class EmployeePresenterUtilitys
    {
        #region message

        public const string _FieldNotEmpty = "不可为空";
        public const string _FieldWrongFormat = "格式不对";
        public const string _ErrorType = "无效的类型";
        public const string _TypeNotDefined = "未指定的类型";
        public const string _ObjectIsNull = "待填写Employee对象为Null，请联系管理员查看事件原因";

        #region EmployeeBasicInfo

        public const string _ErrorGender = "无效的性别类型";
        
        #endregion

        #region ResumeInfo

        public const string _ResumeEducationExperienceAdd = "新增教育培训经历";
        public const string _ResumeEducationExperienceUpdate = "修改教育培训经历";
        public const string _ResumeWorkExperienceAdd = "新增工作经历";
        public const string _ResumeWorkExperienceUpdate = "修改工作经历";

        #endregion

        #region DimissionInfo

        public const string _ErrorNumberRequired = "必须为数字";
        public const string _DimissionInfoFileCargoAdd = "新增档案";
        public const string _DimissionInfoFileCargoUpdate = "修改档案";

        #endregion

        #region FamilyInfo

        public const string _FamilyMebmerAdd = "新增家庭成员信息";
        public const string _FamilyMebmerUpdate = "修改家庭成员信息";


        #endregion

        #region EmployeeInfo

        public const string _ErrorEmployeeNotCompleted = "员工信息填写不完整或填写格式有误!";

        #endregion

        public const string _SkillSourceNull = "技能源为空";
        public const string _SkillNameRepeat = "技能名重复";

        //public const string _ErrorImage = "&nbsp;&nbsp;&nbsp;<img src='image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        #endregion
    }
}