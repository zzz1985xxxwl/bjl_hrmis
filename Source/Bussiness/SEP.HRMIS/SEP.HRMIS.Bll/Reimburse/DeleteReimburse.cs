using HRMISModel = SEP.HRMIS.Model;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class DeleteReimburse : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();

        private readonly int _ReimburseID;
        private readonly int _EmployeeID;
        private Employee _EmployeeReimburse;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public DeleteReimburse(int employeeID, int reimburseID)
        {
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
        }

        public DeleteReimburse(int employeeID, int reimburseID, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
        }
        protected override void Validation()
        {
            //验证报销单已存在，报销单已进入报销流程不可修改或删除
            _EmployeeReimburse = _DalReimburse.GetEmployeeReimburseByEmployeeID(_EmployeeID);
            HRMISModel.Reimburse reimburseOld = _EmployeeReimburse.FindReimburseByReimburseID(_ReimburseID);
            if (reimburseOld == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
            else if (reimburseOld.ReimburseStatus != ReimburseStatusEnum.Added && reimburseOld.ReimburseStatus != ReimburseStatusEnum.Return)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Update_Or_Delete);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                //删除报销单
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _EmployeeReimburse.RemoveReimburseByReimburseID(_ReimburseID);
                    //_DalReimburse.UpdateEmployeeReimburse(_EmployeeReimburse);
                    _DalReimburse.DeleteReimburseByID(_ReimburseID);
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
