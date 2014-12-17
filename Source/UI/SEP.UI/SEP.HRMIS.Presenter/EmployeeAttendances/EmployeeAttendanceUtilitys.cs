using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.EmployeeAttendances
{
    public static class EmployeeAttendanceUtilitys
    {
        public const string _Absent = "旷工";
        public const string _Later = "迟到";
        public const string _EarlyLeave = "早退";
        public const string _ErrorTheDay = "时间格式输入不正确";
        public const string _ErrorNoEventHandler = "未绑定处理该按钮事件";
        public const string _ErrorEmployeeName = "员工姓名不可为空";
        public const string _ErrorInfluenceMinutes = "请填入整数";
        public const string _ErrorAffactDays = "请填入0.5或1";

        public static DateTime _StratTime = new DateTime(1900, 1, 1);
        public static DateTime _EndTime = new DateTime(2999, 12, 31);
    }
}
