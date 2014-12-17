//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalendarShowType.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;

namespace SEP.Model.CalendarExt
{
    public class CalendarShowType
    {
        private readonly int _ID;
        private readonly string _Name;
        private readonly string _Color;
        private readonly bool _DefalutChecked;

        public CalendarShowType(int id, string name, string color, bool defalutChecked)
        {
            _ID = id;
            _Name = name;
            _Color = color;
            _DefalutChecked = defalutChecked;
        }
        /// <summary>
        /// ���  ��Ϣ�ı���ɫΪ#FFEDED
        /// </summary>
        public static CalendarShowType DutyClass = new CalendarShowType(0, "���", "#407f9f",true);
        /// <summary>
        /// ��
        /// </summary>
        public static CalendarShowType Attendance = new CalendarShowType(1, "�򿨼�¼", "#8517e2",false);
        /// <summary>
        /// ���
        /// </summary>
        public static CalendarShowType Leave = new CalendarShowType(2, "���", "#c98502",true);
        public static CalendarShowType Out = new CalendarShowType(3, "���", "#008000",true);
        public static CalendarShowType OverWork = new CalendarShowType(4, "�Ӱ�", "#e21717",false);
        /// <summary>
        /// ����
        /// </summary>
        public static CalendarShowType Task = new CalendarShowType(5, "����", "#000000",false);
        /// <summary>
        /// ��ǩ
        /// </summary>
        public static CalendarShowType Note = new CalendarShowType(6, "��ǩ", "#cc1a7b",true);
        /// <summary>
        /// ȱ��
        /// </summary>
        public static CalendarShowType Absent = new CalendarShowType(7, "ȱ��", "#0c75b8",true);
         /// <summary>
        /// �����ƻ�
        /// </summary>
        public static CalendarShowType WorkTask = new CalendarShowType(9, "�����ƻ�", "#ff6501", true);
        

        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Color
        {
            get { return _Color; }
        }

        public bool DefaultChecked
        {
            get { return _DefalutChecked; }
        }

        public static List<CalendarShowType> GetHrType()
        {
            List<CalendarShowType> list = new List<CalendarShowType>();
            list.Add(DutyClass);
            list.Add(Attendance);
            list.Add(Leave);
            list.Add(Out);
            list.Add(OverWork);
            list.Add(Absent);
            return list;
        }
        public static List<CalendarShowType> GetSepType()
        {
            List<CalendarShowType> list = new List<CalendarShowType>();
            list.Add(Task);
            list.Add(Note);
            list.Add(WorkTask);
            return list;
        }
    }
}