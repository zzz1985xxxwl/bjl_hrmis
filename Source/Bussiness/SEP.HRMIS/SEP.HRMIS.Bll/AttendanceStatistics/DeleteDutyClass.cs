using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// 删除班别
    /// </summary>
    public class DeleteDutyClass : Transaction
    {
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly int _DutyClassID;
        /// <summary>
        /// 修改班别，构造函数
        /// </summary>
        /// <param name="dutyClassID"></param>
        public DeleteDutyClass(int dutyClassID)
        {
            _DutyClassID = dutyClassID;
        }
        /// <summary>
        /// 测试用
        /// </summary>
        public DeleteDutyClass(int dutyClassID, IPlanDutyDal ruleMock)
        {
            _DutyClassID = dutyClassID;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// 修改时查看该条记录是否存在，并判断是否有重名
        /// </summary>
        protected override void Validation()
        {
            //if (_DalRull.GetDutyClassByPkid(_DutyClass.DutyClassID) == null)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._AttendanceRule_Not_Exist);
            //}
            //if (_DalRull.CountDutyClassByDutyClassDiffPkid(_DutyClass.DutyClassID, _DutyClass.DutyClassName) > 0)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._AttendanceRule_Name_Repeat);
            //}
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalRull.DeleteDutyClass(_DutyClassID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
