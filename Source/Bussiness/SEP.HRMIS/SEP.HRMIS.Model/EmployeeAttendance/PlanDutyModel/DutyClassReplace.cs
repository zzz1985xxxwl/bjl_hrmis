
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// 班别替换，为页面显示使用
    ///</summary>
    [Serializable]
    public class DutyClassReplace
    {
        private DutyClass _OldDutyClass;
        private int _NewDutyClassID;

        ///<summary>
        /// 原班别
        ///</summary>
        public DutyClass OldDutyClass
        {
            get { return _OldDutyClass; }
            set { _OldDutyClass = value; }
        }
        /// <summary>
        /// 新版别ID
        /// </summary>
        public int NewDutyClassID
        {
            get { return _NewDutyClassID; }
            set { _NewDutyClassID = value; }
        }
    }
}
