//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseUtility.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述:培训课程错误信息
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseUtility
    {
        public const string AddPageTitle = "新增培训课程";
        public const string AddOperationType = "Add";

        public const string UpdatePageTitle = "修改培训课程";
        public const string UpdateOperationType = "Update";

        public const string DeletePageTitle = "删除培训课程";
        public const string DeleteOperationType = "Delete";

        public const string DetailPageTitle = "查看培训课程";
        public const string DetailOperationType = "Detail";

        public const string _IsEmpty = "不能为空";
        public const string _FieldWrongFormat = "格式不对";
        public const string _StartEndDateError = "开始日期晚于结束日期";
        public const string _ExpectHourError = "计划课时不能小于等于0";
        public const string _ExpectCostError = "计划成本不能小于等于0";
        public const string _ActualHourError = "实际课时不能小于等于0";
        public const string _ActualCostError = "实际成本不能小于等于0";

        public const string _ErrorNullLeaveRequestType = "没有任何培训课程";

        public const string _InitError = "初始化错误";
    }
}
