
using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel
{
    ///<summary>
    /// ����滻��Ϊҳ����ʾʹ��
    ///</summary>
    [Serializable]
    public class DutyClassReplace
    {
        private DutyClass _OldDutyClass;
        private int _NewDutyClassID;

        ///<summary>
        /// ԭ���
        ///</summary>
        public DutyClass OldDutyClass
        {
            get { return _OldDutyClass; }
            set { _OldDutyClass = value; }
        }
        /// <summary>
        /// �°��ID
        /// </summary>
        public int NewDutyClassID
        {
            get { return _NewDutyClassID; }
            set { _NewDutyClassID = value; }
        }
    }
}
