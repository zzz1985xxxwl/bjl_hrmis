using System.Transactions;
using SEP.Model.Accounts;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class InterruptOrCancelReimburses : Transaction
    {
                /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly int _ReimburseID;
        private readonly Account _LoginUser;
        private Model.Reimburse _Reimburse;
        private Model.ReimburseStatusEnum _StatusEnum;

        public InterruptOrCancelReimburses(Account loginUser, int reimburseID, ReimburseStatusEnum statusEnum)
        {
            _ReimburseID = reimburseID;
            _LoginUser = loginUser;
            _StatusEnum = statusEnum;
        }

        public InterruptOrCancelReimburses(Account loginUser, int reimburseID,ReimburseStatusEnum statusEnum, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _LoginUser = loginUser;
            _StatusEnum = statusEnum;

        }
        protected override void Validation()
        {
            _Reimburse = _DalReimburse.GetReimburseByReimburseID(_ReimburseID);
            if (_Reimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Return)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Interruptted);
            }
            if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursed)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
            }
            //if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Cancel)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
            //}
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _Reimburse.ReimburseStatus = _StatusEnum;
                    _DalReimburse.UpdateReimburse(_LoginUser, _Reimburse, _StatusEnum);

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
