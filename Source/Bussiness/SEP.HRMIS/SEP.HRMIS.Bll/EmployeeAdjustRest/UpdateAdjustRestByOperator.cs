using System;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 更新员工调休记录，并记录历史
    /// </summary>
    public class UpdateAdjustRestByOperator : Transaction
    {
        private readonly IAdjustRest _IAdjustRest = new AdjustRestDal();
        private readonly IAdjustRestHistory _IAdjustRestHistory = new AdjustRestHistoryDal();
        private readonly AdjustRestHistory _AdjustRestHistory;
        private AdjustRest _AdjustRest;
        private readonly int _OperatorID;
        private readonly decimal _SurplusAdjustRest;
        private readonly string _Remark;
        private readonly int _AdjustRestID;

        /// <summary>
        /// 手工修改
        /// </summary>
        public UpdateAdjustRestByOperator(int adjustID, decimal surplusAdjustRest, string remark, int operatorID)
        {
            _SurplusAdjustRest = surplusAdjustRest;
            _Remark = remark;
            _OperatorID = operatorID;
            _AdjustRestHistory = GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum.ModifyByOperator, operatorID);
            _AdjustRestHistory.AdjustRestHistoryTypeEnum = AdjustRestHistoryTypeEnum.ModifyByOperator;
            _AdjustRestID = adjustID;
        }

        /// <summary>
        /// for test
        /// </summary>
        public UpdateAdjustRestByOperator(int adjustID, decimal surplusAdjustRest, string remark, int operatorID,
                                          IAdjustRest mockAdjustRest, IAdjustRestHistory mockAdjustRestHistory)
            : this(adjustID, surplusAdjustRest, remark, operatorID)
        {
            _IAdjustRest = mockAdjustRest;
            _IAdjustRestHistory = mockAdjustRestHistory;
        }

        #region Common Method      

        /// <summary>
        /// 
        /// </summary>
        public static AdjustRestHistory GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum type, int accountid)
        {
            AdjustRestHistory adjustRestHistory =
                new AdjustRestHistory(0, DateTime.Now, 0, type);
            adjustRestHistory.Operator = new Account(accountid, "", "");
            return adjustRestHistory;
        }

        private void InitAdjustRest()
        {
            _AdjustRest = _IAdjustRest.GetAdjustRestByPKID(_AdjustRestID);
        }

        #endregion

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            DataReady();
            //没有任何变化且没有任何备注
            if (string.IsNullOrEmpty(_AdjustRestHistory.Remark) && _AdjustRestHistory.ChangeHours == 0)
            {
                return;
            }
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                _IAdjustRest.UpdateAdjustRest(_AdjustRest);
                _IAdjustRestHistory.InsertAdjustRestHistory(_AdjustRest.Employee.Account.Id, _AdjustRestHistory);
                ts.Complete();
            }
        }

        private void DataReady()
        {
            InitAdjustRest();
            _AdjustRestHistory.ChangeHours = _SurplusAdjustRest - _AdjustRest.SurplusHours;
            _AdjustRestHistory.Remark = _Remark;
            _AdjustRestHistory.Operator.Id = _OperatorID;
            _AdjustRest.SurplusHours = _SurplusAdjustRest;
        }
    }
}