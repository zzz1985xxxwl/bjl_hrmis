using System.Transactions;
using SEP.Model.Accounts;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class QuickInterruptReimburse : Transaction
    {
                /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly int _ReimburseID;
        private readonly Account _LoginUser;
        private Model.Reimburse _Reimburse;

        public QuickInterruptReimburse(Account loginUser, int reimburseID)
        {
            _ReimburseID = reimburseID;
            _LoginUser = loginUser;
        }

        public QuickInterruptReimburse(Account loginUser, int reimburseID, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _LoginUser = loginUser;

        }
        protected override void Validation()
        {
            _Reimburse = _DalReimburse.GetReimburseByReimburseID(_ReimburseID);
            if (_Reimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Interrupt)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Interruptted);
            }
            if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursed)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _Reimburse.ReimburseStatus = ReimburseStatusEnum.Interrupt;
                    _DalReimburse.UpdateReimburse(_LoginUser, _Reimburse);

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
