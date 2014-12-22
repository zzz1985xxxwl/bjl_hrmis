using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// 新增排班
    /// </summary>
    public class InsertPlanDuty : Transaction
    {
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly PlanDutyTable _PlanDutyTable;
        private int _CurrentId;
        private string _RepeatAccountList = string.Empty;
                /// <summary>
        /// 新增班别构造函数
        /// </summary>
        /// <param name="planDutyTable"></param>
        public InsertPlanDuty(PlanDutyTable planDutyTable)
        {
            _PlanDutyTable = planDutyTable;
        }
        /// <summary>
        /// 新增班别构造函数，测试
        /// </summary>
        /// <param name="planDutyTable"></param>
        /// <param name="ruleMock"></param>
        public InsertPlanDuty(PlanDutyTable planDutyTable, IPlanDutyDal ruleMock)
        {
            _PlanDutyTable = planDutyTable;
            _DalRull = ruleMock;
        }

        protected override void Validation()
        {
            if (_DalRull.CountPlanDutyTableByPlanDutyTableName(_PlanDutyTable.PlanDutyTableName) > 0)
            {
                throw new ApplicationException("排班表名字重复");
                //BllUtility.ThrowException(BllExceptionConst._DutyClass_Name_Repeat);
            }
            for (int i = 0; i < _PlanDutyTable.PlanDutyAccountList.Count;i++)
            {
                if (_DalRull.GetPlanDutyDetailByAccountID(_PlanDutyTable.PlanDutyAccountList[i].Id, _PlanDutyTable.FromTime,
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
                _CurrentId = _DalRull.InsertPlanDutyTable(_PlanDutyTable, _PlanDutyTable.PlanDutyAccountList);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
        /// <summary>
        /// 当前ID，为测试使用
        /// </summary>
        public int CurrentId
        {
            get
            {
                return _CurrentId;
            }
        }

        public string RepeatAccountList
        {
            get { return _RepeatAccountList; }
            set { _RepeatAccountList = value; }
        }
    }
}
