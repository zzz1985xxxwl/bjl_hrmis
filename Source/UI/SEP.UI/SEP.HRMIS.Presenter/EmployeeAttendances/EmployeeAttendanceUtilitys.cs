using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.EmployeeAttendances
{
    public static class EmployeeAttendanceUtilitys
    {
        public const string _Absent = "����";
        public const string _Later = "�ٵ�";
        public const string _EarlyLeave = "����";
        public const string _ErrorTheDay = "ʱ���ʽ���벻��ȷ";
        public const string _ErrorNoEventHandler = "δ�󶨴���ð�ť�¼�";
        public const string _ErrorEmployeeName = "Ա����������Ϊ��";
        public const string _ErrorInfluenceMinutes = "����������";
        public const string _ErrorAffactDays = "������0.5��1";

        public static DateTime _StratTime = new DateTime(1900, 1, 1);
        public static DateTime _EndTime = new DateTime(2999, 12, 31);
    }
}
