using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.Model.Accounts;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class ReturntOrCancelReimburses : Transaction
    {
                       /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly int _ReimburseID;
        private Model.Reimburse _Reimburse;
        private readonly Employee _Operator;

        public ReturntOrCancelReimburses(int reimburseID, Employee _operator)
        {
            _ReimburseID = reimburseID;
            _Operator = _operator;
        }

        public ReturntOrCancelReimburses(int reimburseID, Employee _operator, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _Operator = _operator;

        }
        protected override void Validation()
        {
            _Reimburse = _DalReimburse.GetReimburseByReimburseID(_ReimburseID);
            if (_Reimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Added)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Added);
            }
            else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursed)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
            }
            else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Return)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Return);
            }
            //else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Auditing)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Auditing);
            //}
            //else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursing);
            //}
        }

        protected override void ExcuteSelf()
        {
            try
            {
                HRMISModel.Reimburse reimburseToUpdate = _DalReimburse.GetReimburseByReimburseID(_ReimburseID);

                if (reimburseToUpdate.ReimburseFlows == null)
                {
                    reimburseToUpdate.ReimburseFlows = new List<ReimburseFlow>();
                }
                reimburseToUpdate.ReimburseFlows.Add(
                    new ReimburseFlow(_Operator, DateTime.Now, ReimburseStatusEnum.Return));
                reimburseToUpdate.ReimburseStatus = ReimburseStatusEnum.Return;//将add改成retrun by xwl 2009-9-3
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalReimburse.UpdateEmployeeReimburse(reimburseToUpdate);
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
