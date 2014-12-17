using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.DataAccess;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class ReturnEmployeeReimburses : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly List<HRMISModel.Reimburse> _ReimburseID;
        private readonly int _EmployeeID;
        private readonly Employee _Operator;
        //private Employee _EmployeeReimburse;
        private int _FailCount;
        public int FailCount
        {
            get { return _FailCount; }
            set { _FailCount = value; }
        }
        public ReturnEmployeeReimburses(int employeeID, List<HRMISModel.Reimburse> reimburseID, Employee _operator)
        {
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
            _Operator = _operator;
        }
        public ReturnEmployeeReimburses(int employeeID, List<HRMISModel.Reimburse> reimburseID, Employee _operator, IReimburse dalReimburse)
        {
            _ReimburseID = reimburseID;
            _EmployeeID = employeeID;
            _Operator = _operator;
            _DalReimburse = dalReimburse;
        }

        protected override void Validation()
        {
        }
        private bool ValidationEach(HRMISModel.Reimburse reimburseToUpdate)
        {
            try
            {
                if (reimburseToUpdate == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
                }
                else if (reimburseToUpdate.ReimburseStatus == ReimburseStatusEnum.Added)
                {
                    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Added);
                }
                else if (reimburseToUpdate.ReimburseStatus == ReimburseStatusEnum.Reimbursed)
                {
                    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursed);
                }
                else if (reimburseToUpdate.ReimburseStatus == ReimburseStatusEnum.Return)
                {
                    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Return);
                }
                //else if (reimburseToUpdate.ReimburseStatus == ReimburseStatusEnum.Auditing)
                //{
                //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Auditing);
                //}
                //else if (reimburseToUpdate.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
                //{
                //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursing);
                //}
                return true;
            }
            catch
            {
                FailCount++;
                return false;
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                //_EmployeeReimburse = _DalReimburse.GetEmployeeReimburseByEmployeeID(_EmployeeID);
                //if (_EmployeeReimburse.Reimburses == null)
                //{
                //    BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
                //}
                for (var i = 0; i < _ReimburseID.Count; i++)
                {
                    HRMISModel.Reimburse reimburseToUpdate = _DalReimburse.GetReimburseByReimburseID(_ReimburseID[i].ReimburseID);
                    if (!ValidationEach(reimburseToUpdate))
                    {
                        continue;
                    }
                    ReimburseDA.UpdateReimburseStatus(_ReimburseID[i].ReimburseID, ReimburseStatusEnum.Return);
                    ReimburseFlowDA.Insert(new ReimburseFlow(_Operator, DateTime.Now, ReimburseStatusEnum.Return), _ReimburseID[i].ReimburseID);
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
