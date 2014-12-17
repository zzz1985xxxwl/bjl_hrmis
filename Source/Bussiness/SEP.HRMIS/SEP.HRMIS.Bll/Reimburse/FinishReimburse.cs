using System;
using System.Collections.Generic;
using HRMISModel = SEP.HRMIS.Model;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class FinishReimburse : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly int _ReimburseID;
        private readonly int _EmployeeID;
        private readonly Employee _Operator;
        private Employee _EmployeeReimburse;
        private HRMISModel.Reimburse reimburse;

        public FinishReimburse(int employeeID, int reimburseID, Employee _operator)
        {
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
            _Operator = _operator;
        }
        public FinishReimburse(int employeeID, int reimburseID, Employee _operator, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
            _Operator = _operator;

        }
        protected override void Validation()
        {
            _EmployeeReimburse = _DalReimburse.GetEmployeeReimburseByEmployeeID(_EmployeeID);
            reimburse = _EmployeeReimburse.FindReimburseByReimburseID(_ReimburseID);
            if (reimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            if (reimburse.ReimburseStatus == ReimburseStatusEnum.Return)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Interruptted);
            }
            if (reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursed)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
            }
            if (reimburse.ReimburseStatus == ReimburseStatusEnum.Added)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Added);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _EmployeeReimburse.RemoveReimburseByReimburseID(_ReimburseID);
                    if (reimburse.ReimburseFlows == null)
                    {
                        reimburse.ReimburseFlows = new List<ReimburseFlow>();
                    }
                    reimburse.ReimburseFlows.Add(
                        new ReimburseFlow(_Operator, DateTime.Now, ReimburseStatusEnum.Reimbursed));
                    reimburse.ReimburseStatus = ReimburseStatusEnum.Reimbursed;
                    _EmployeeReimburse.Reimburses.Add(reimburse);
                    _DalReimburse.UpdateEmployeeReimburse(_EmployeeReimburse);

                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
