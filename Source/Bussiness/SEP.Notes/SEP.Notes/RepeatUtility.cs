//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: RepeatUtility.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Notes.RepeatTypes;

namespace SEP.Notes
{
    /// <summary>
    /// </summary>
    public class RepeatUtility
    {
        /// <summary>
        /// 通过id得到类型
        /// </summary>
        public static IRepeat GetRepeatType(int typeid)
        {
            switch (typeid)
            {
                case 1:
                    return new NoRepeat();
                case 2:
                    return new DayRepeat();
                case 3:
                    return new WeekRepeat();
                case 4:
                    return new MonthRepeat();
            }
            return null;
        }

        /// <summary>
        /// 通过类型得到id
        /// </summary>
        public static int GetTypeIndex(IRepeat repeatType)
        {
            if (repeatType is NoRepeat)
            {
                return 1;
            }
            else if (repeatType is DayRepeat)
            {
                return 2;
            }
            else if (repeatType is WeekRepeat)
            {
                return 3;
            }
            else if (repeatType is MonthRepeat)
            {
                return 4;
            }
            return 1;
        }

        public static List<NameValue> GetAll()
        {
            List<NameValue> r = new List<NameValue>();
            r.Add(new NameValue("1", "无定期"));
            r.Add(new NameValue("2", "按天"));
            r.Add(new NameValue("3", "按周"));
            r.Add(new NameValue("4", "按月"));
            return r;
        }

        public static List<IRepeat> GetAllRepeat()
        {
            List<IRepeat> r = new List<IRepeat>();
            r.Add(new NoRepeat());
            r.Add(new DayRepeat());
            r.Add(new WeekRepeat());
            r.Add(new MonthRepeat());
            return r;
        }

        public static DateTime ConvertToDateTime(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }

        public static string DetailString(Notes note, DateTime start, DateTime end)
        {
            string content;
            if (note.FindMine)
            {
                if (note.IsMine)
                {
                    content =
                        string.Format(
                            "<div class='notesEditDetail'><div><span class='content' title='{0}'>{0}</span><a onclick='noteUpdateShow({1},this)'>修改</a><a onclick='noteDelete({1},this)'>删除</a></div><div>{2}--{3}</div></div>",
                            note.Content, note.PKID, start.ToShortTimeString(), end.ToShortTimeString());
                }
                else
                {
                    content =
                        string.Format(
                            "<div class='notesEditDetail'><div><span class='content' title='{0}'>{0}</span><a onclick='noteDetailShow({1},this)'>详情</a><a onclick='noteExitShare({1},this)'>退出</a></div><div>{2}--{3}<span class='shareFrom'>--来自{4}的共享</span></div></div>",
                            note.Content, note.PKID, start.ToShortTimeString(), end.ToShortTimeString(), note.Owner.Name);
                }
            }
            else
            {
                content =
                    string.Format(
                        "<div class='notesEditDetail'><div><span class='content' title='{0}'>{0}</span><a onclick='noteDetailShow({1},this)'>详情</a><a></a></div><div>{2}--{3}</div></div>",
                        note.Content, note.PKID, start.ToShortTimeString(), end.ToShortTimeString());
            }
            return content;
        }
    }


    public class NameValue
    {
        public string Name;
        public string Value;

        public NameValue(string value, string name)
        {
            Name = name;
            Value = value;
        }
    }
}