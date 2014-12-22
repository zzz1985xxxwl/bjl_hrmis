using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// ɾ�����
    /// </summary>
    public class DeletePlanDuty : Transaction
    {
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly int _PlanDutyTableId;
        /// <summary>
        /// �޸İ�𣬹��캯��
        /// </summary>
        /// <param name="planDutyTableId"></param>
        public DeletePlanDuty(int planDutyTableId)
        {
            _PlanDutyTableId = planDutyTableId;
        }
        /// <summary>
        /// ������
        /// </summary>
        public DeletePlanDuty(int planDutyTableId, IPlanDutyDal ruleMock)
        {
            _PlanDutyTableId = planDutyTableId;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// �޸�ʱ�鿴������¼�Ƿ���ڣ����ж��Ƿ�������
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
                _DalRull.DeletePlanDutyTable(_PlanDutyTableId);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
