using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// �������
    /// </summary>
    public class InsertDutyClass : Transaction
    {
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly DutyClass _DutyClass;
        private int _CurrentId;
        /// <summary>
        /// ��������캯��
        /// </summary>
        /// <param name="dutyClass"></param>
        public InsertDutyClass(DutyClass dutyClass)
        {
            _DutyClass = dutyClass;
        }
        /// <summary>
        /// ��������캯��������
        /// </summary>
        /// <param name="dutyClass"></param>
        /// <param name="ruleMock"></param>
        public InsertDutyClass(DutyClass dutyClass, IPlanDutyDal ruleMock)
        {
            _DutyClass = dutyClass;
            _DalRull = ruleMock;
        }

        protected override void Validation()
        {
           if(_DalRull.CountDutyClassByDutyClassName(_DutyClass.DutyClassName)>0)
           {
               BllUtility.ThrowException(BllExceptionConst._DutyClass_Name_Repeat);
           }
        }

        protected override void ExcuteSelf()
        {
            try
            {
               _CurrentId = _DalRull.InsertDutyClass(_DutyClass);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
        /// <summary>
        /// ��ǰID��Ϊ����ʹ��
        /// </summary>
        public int CurrentId
        {
            get
            {
                return _CurrentId;
            }
        }
    }
}
