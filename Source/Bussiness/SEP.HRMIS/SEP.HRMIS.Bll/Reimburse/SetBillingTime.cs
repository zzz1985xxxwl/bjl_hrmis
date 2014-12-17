using System;
using System.Collections.Generic;
using SEP.HRMIS.Logic;
using HRMISModel = SEP.HRMIS.Model;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    public class SetBillingTime : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly int _ReimburseID;
        private Model.Reimburse _Reimburse;
        private readonly Employee _Operator;
        private readonly DateTime _BillingTime;
        private int _ExchangeRateID;
        public SetBillingTime(int reimburseID, DateTime billingTime, Employee _operator)
        {
            _ReimburseID = reimburseID;
            _BillingTime = billingTime;
            _Operator = _operator;
        }

        public SetBillingTime(int reimburseID, Employee _operator, DateTime billingTime, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _ReimburseID = reimburseID;
            _BillingTime = billingTime;
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
            else if (_Reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Has_Reimbursing);
            }
            var exchangeRate = ExchangeRateLogic.GetExchangeRateByCondition(_Reimburse.ExchangeRateID, new DateTime(_BillingTime.Year,_BillingTime.Month,1));
            if (exchangeRate == null)
            {
                throw new ApplicationException("此月份尚未添加汇率");
            }
            else
            {
                _ExchangeRateID = exchangeRate.PKID;
            }
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
                    new ReimburseFlow(_Operator, DateTime.Now, ReimburseStatusEnum.Reimbursed));
                reimburseToUpdate.ReimburseStatus = ReimburseStatusEnum.Reimbursed;
                // 记账时间
                reimburseToUpdate.BillingTime = _BillingTime.ToString();
                reimburseToUpdate.ExchangeRateID = _ExchangeRateID;
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
