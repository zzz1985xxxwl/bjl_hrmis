using System;
using System.Collections.Generic;

namespace SEP.Model
{
    [Serializable]
    public class WTStatus
    {
        private readonly int _Id;
        private readonly string _Name;
        private readonly string _Style;
        private readonly string _LineStyle;

        public WTStatus(int id, string name, string style,string linestyle)
        {
            _Id = id;
            _Name = name;
            _Style = style;
            _LineStyle = linestyle;
        }

        public int Id
        {
            get { return _Id; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Style
        {
            get { return _Style; }
        }
        public string LineStyle
        {
            get { return _LineStyle; }
        }

        #region 重写Equals

        public override bool Equals(object obj)
        {
            WTStatus anOtherObj = obj as WTStatus;
            if (anOtherObj == null)
            {
                return false;
            }

            return _Id.Equals(anOtherObj._Id) &&
                   _Name.Equals(anOtherObj._Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public static WTStatus All = new WTStatus(-1, "", "","");
        public static WTStatus NotStarted = new WTStatus(1, "未开始", "Status_Blue", "trline_Blue");
        public static WTStatus Ongoing = new WTStatus(2, "进行中", "Status_Yellow", "trline_Yellow");
        public static WTStatus Failure = new WTStatus(3, "未完成", "Status_Red", "trline_Red");
        public static WTStatus Finish = new WTStatus(4, "已完成", "Status_Green", "trline_Green");

        public static WTStatus GetById(int id)
        {
            switch (id)
            {
                case -1:
                    return All;
                case 1:
                    return NotStarted;
                case 2:
                    return Ongoing;
                case 3:
                    return Failure;
                case 4:
                    return Finish;
                default:
                    return All;
            }
        }

        public static List<WTStatus> AllWTStatus
        {
            get
            {
                List<WTStatus> allWTStatus = new List<WTStatus>();
                allWTStatus.Add(All);
                allWTStatus.Add(NotStarted);
                allWTStatus.Add(Ongoing);
                allWTStatus.Add(Failure);
                allWTStatus.Add(Finish);
                return allWTStatus;
            }
        }

        public static List<WTStatus> GetWTStatus
        {
            get
            {
                List<WTStatus> allWTStatus = new List<WTStatus>();
                allWTStatus.Add(NotStarted);
                allWTStatus.Add(Ongoing);
                allWTStatus.Add(Failure);
                allWTStatus.Add(Finish);
                return allWTStatus;
            }
        }
    }
}