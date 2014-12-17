//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAttendanceRule.cs
// 创建者: 刘丹
// 创建日期: 2008-10-13
// 概述: 修改班别
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// 修改班别
    /// </summary>
    public class UpdateDutyClass : Transaction
    {

        private readonly IPlanDutyDal _DalRull = DalFactory.DataAccess.CreatePlanDutyDal();
        private readonly DutyClass _DutyClass;
        /// <summary>
        /// 修改班别，构造函数
        /// </summary>
        /// <param name="rule"></param>
        public UpdateDutyClass(DutyClass rule)
        {
            _DutyClass = rule;
        }
        /// <summary>
        /// 测试用
        /// </summary>
        public UpdateDutyClass(DutyClass rule, IPlanDutyDal ruleMock)
        {
            _DutyClass = rule;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// 修改时查看该条记录是否存在，并判断是否有重名
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
