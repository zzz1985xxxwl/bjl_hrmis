using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// 修改班别
    /// </summary>
    public class UpdatePlanDuty : Transaction
    {
        
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly PlanDutyTable _PlanDutyTable;
        private string _RepeatAccountList = string.Empty; 
        /// <summary>
        /// 修改班别，构造函数
        /// </summary>
        public UpdatePlanDuty(PlanDutyTable planDutyTable)
        {
            _PlanDutyTable = planDutyTable;

        }
        /// <summary>
        /// 测试用
        /// </summary>
        public UpdatePlanDuty(PlanDutyTable planDutyTable, IPlanDutyDal ruleMock)
        {
            _PlanDutyTable = planDutyTable;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// 修改时查看该条记录是否存在，并判断是否有重名
        /// </summary>
        protected override void Validation()
        {
            if (_DalRull.GetPlanDutyTableByPkid(_PlanDutyTable.PlanDutyTableID) == null)
            {
                throw new ApplicationException("该排班表不存在");
                BllUtility.ThrowException(BllExceptionConst._DutyClass_Not_Exist);
            }
            if (_DalRull.CountPlanDutyByPlanDutyDiffPkid(_PlanDutyTable.PlanDutyTableID, _PlanDutyTable.PlanDutyTableName) > 0)
            {
                throw new ApplicationException("该排班表名字重复");
            }
            for (int i = 0; i < _PlanDutyTable.PlanDutyAccountList.Count; i++)
            {
                if (_DalRull.GetPlanDutyDetailByAccountIDAndPlanDutyID(_PlanDutyTable.PlanDutyTableID, _PlanDutyTable.PlanDutyAccountList[i].Id, _PlanDutyTable.FromTime,
                                                    _PlanDutyTable.ToTime) > 0)
                {
                    _RepeatAccountList = _RepeatAccountList + BllInstance.AccountBllInstance.GetAccountById(_PlanDutyTable.PlanDutyAccountList[i].Id).Name + ",";
                }
            }
            if (_RepeatAccountList != string.Empty)
            {
                throw new ApplicationException(_RepeatAccountList + "该时间段内已存在排班");
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalRull.UpdatePlanDutyTable(_PlanDutyTable, _PlanDutyTable.PlanDutyAccountList);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
