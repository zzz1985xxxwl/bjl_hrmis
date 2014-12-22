//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAttendanceReadRule.cs
// ������: ����
// ��������: 2008-10-15
// ����: �޸Ŀ��ڶ�ȡ����
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class UpdateAttendanceReadRule:Transaction
    {
        private readonly IAttendanceReadRule _DalReadRull = new AttendanceReadRuleDal();
        private readonly AttendanceReadRule _Read;
        private readonly Account _LoginUser;

        ///<summary>
        ///</summary>
        ///<param name="readRule"></param>
        public UpdateAttendanceReadRule(AttendanceReadRule readRule,Account loginUser)
        {
            _LoginUser = loginUser;
            _Read = readRule;
        }
        /// <summary>
        /// ������
        /// </summary>
        public UpdateAttendanceReadRule(AttendanceReadRule readRule, IAttendanceReadRule ruleMock, Account loginUser)
        {
            _LoginUser = loginUser;
            _Read = readRule;
            _DalReadRull = ruleMock;
        }
        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        protected override void Validation()
        {
            if (_DalReadRull.GetAttendanceReadRuleByPkid(_Read.AttendanceReadTimeId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AttendanceReadRule_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalReadRull.UpdateAttendanceReadRule(_Read);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
