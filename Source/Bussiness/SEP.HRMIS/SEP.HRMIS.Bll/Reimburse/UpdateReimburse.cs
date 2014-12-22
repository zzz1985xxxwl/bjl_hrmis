using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateReimburse : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = new ReimburseDal();
        // private Employee _EmployeeReimburse;
        private readonly int _EmployeeID;
        private readonly HRMISModel.Reimburse _Reimburse;
        //private HRMISModel.Reimburse _OldRimburse;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public UpdateReimburse(int employeeID, HRMISModel.Reimburse reimburse)
        {
            _EmployeeID = employeeID;
            _Reimburse = reimburse;
            SetEmployeeReimburse();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="reimburse"></param>
        /// <param name="iReimburseMock"></param>
        public UpdateReimburse(int employeeID, HRMISModel.Reimburse reimburse, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _EmployeeID = employeeID;
            _Reimburse = reimburse;
            SetEmployeeReimburse();
        }
        private void SetEmployeeReimburse()
        {
            // _EmployeeReimburse = _DalReimburse.GetEmployeeReimburseByEmployeeID(_EmployeeID);
            //_Reimburse.Department = _EmployeeReimburse.Account.Dept;
        }

        protected override void Validation()
        {
            //验证报销单已存在，报销单已进入报销流程不可修改或删除
            //_OldRimburse = _EmployeeReimburse.FindReimburseByReimburseID(_Reimburse.ReimburseID);
            //if (_OldRimburse == null)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            //}
            //else if (_OldRimburse.ReimburseStatus != ReimburseStatusEnum.Added && _OldRimburse.ReimburseStatus != ReimburseStatusEnum.Return)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Update_Or_Delete);
            //}
        }

        protected override void ExcuteSelf()
        {
            //修改报销单的基本信息
            try
            {
                HRMISModel.Reimburse reimburseToUpdate = _DalReimburse.GetReimburseByReimburseID(_Reimburse.ReimburseID);
                //List<ReimburseFlow> reimburseFlows = _DalReimburse.GetReimburseByReimburseID(_Reimburse.ReimburseID).ReimburseFlows;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    //_EmployeeReimburse.RemoveReimburseByReimburseID(_Reimburse.ReimburseID);

                    if (reimburseToUpdate.ReimburseFlows != null)
                    {
                        _Reimburse.ReimburseFlows = reimburseToUpdate.ReimburseFlows;
                    }
                    else
                    {
                        _Reimburse.ReimburseFlows = new List<ReimburseFlow>();
                    }
                    if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
                    {
                        _Reimburse.ReimburseFlows.Add(
                            new ReimburseFlow(new Employee { Account = new Account { Id = _EmployeeID } }, DateTime.Now, _Reimburse.ReimburseStatus));
                    }
                    else
                    {
                        _Reimburse.ReimburseStatus = reimburseToUpdate.ReimburseStatus;
                    }
                    //_EmployeeReimburse.Reimburses.Add(_Reimburse);
                    _DalReimburse.UpdateEmployeeReimburse(_Reimburse);

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
