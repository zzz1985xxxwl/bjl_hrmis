//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAttendanceRule.cs
// ������: ����
// ��������: 2008-10-13
// ����: �޸İ��
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// �޸İ��
    /// </summary>
    public class UpdateDutyClass : Transaction
    {

        private readonly IPlanDutyDal _DalRull = DalFactory.DataAccess.CreatePlanDutyDal();
        private readonly DutyClass _DutyClass;
        /// <summary>
        /// �޸İ�𣬹��캯��
        /// </summary>
        /// <param name="rule"></param>
        public UpdateDutyClass(DutyClass rule)
        {
            _DutyClass = rule;
        }
        /// <summary>
        /// ������
        /// </summary>
        public UpdateDutyClass(DutyClass rule, IPlanDutyDal ruleMock)
        {
            _DutyClass = rule;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// �޸�ʱ�鿴������¼�Ƿ���ڣ����ж��Ƿ�������
        /// </summary>
        protected override void Validation()
        {
            if (_DalRull.GetDutyClassByPkid(_DutyClass.DutyClassID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._DutyClass_Not_Exist);
            }
            if (_DalRull.CountDutyClassByDutyClassDiffPkid(_DutyClass.DutyClassID, _DutyClass.DutyClassName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._DutyClass_Name_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalRull.UpdateDutyClass(_DutyClass);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
    
}
