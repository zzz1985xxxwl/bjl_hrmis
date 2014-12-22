//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAttendanceReadRule.cs
// 创建者: 刘丹
// 创建日期: 2008-10-15
// 概述: 修改考勤读取设置
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
        /// 测试用
        /// </summary>
        public UpdateAttendanceReadRule(AttendanceReadRule readRule, IAttendanceReadRule ruleMock, Account loginUser)
        {
            _LoginUser = loginUser;
            _Read = readRule;
            _DalReadRull = ruleMock;
        }
        /// <summary>
        /// 判断记录是否存在
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
