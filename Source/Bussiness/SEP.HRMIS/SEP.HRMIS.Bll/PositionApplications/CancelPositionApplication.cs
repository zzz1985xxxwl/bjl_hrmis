using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Bll.PositionApplications.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class CancelPositionApplication : Transaction
    {
        private readonly int _PositionApplicationID;
        private readonly int _OperatorID;
        private readonly RequestStatus _RequestStatus;
        private readonly string _Reason;
        private PositionApplication _PositionApplication;

        private readonly IPositionApplicationDal _PositionApplicationDal = DalFactory.DataAccess.CreatePositionApplication();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        /// <summary>
        /// 取消请假单
        /// </summary>
        public CancelPositionApplication(int positionApplicationID, int operatorID,
            RequestStatus requestStatus, string reason)
        {
            _PositionApplicationID = positionApplicationID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _PositionApplication = _PositionApplicationDal.GetPositionApplicationByPKID(_PositionApplicationID);
            //判断信息是否为空
            if (_PositionApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._PositionApplication_Not_Exit);
            }
            else
            {
                //判断该账号是否有流程
                _PositionApplication.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.PositionApp,
                                                                              _PositionApplication.Account.Id);
                if (_PositionApplication.DiyProcess == null)
                {
                    HrmisUtility.ThrowException(HrmisUtility._No_PositionApplication_DiyProcess);
                }
                //如果信息状态不是取消或提交状态，不能取消
                if (!RequestStatus.CanCancelStatus(_PositionApplication.Status))
                {
                    HrmisUtility.ThrowException(HrmisUtility._PositionApplication_CanNot_BeCancled);
                }
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// 操作结果
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return _ResultMessage;
            }
            set
            {
                _ResultMessage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                DiyStep currentStep = _PositionApplication.DiyProcess.FindCancelStep();
                DiyStep nextStep = _PositionApplication.DiyProcess.FindCancelNextStep();
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _PositionApplicationDal.UpdatePositionApplicationStatusByPositionApplicationID(_PositionApplicationID,
                                                                                      _RequestStatus, nextStep.DiyStepID);
                    PositionApplicationFlow flow = new PositionApplicationFlow(0, _PositionApplicationID,
                                                                               new Account(_OperatorID, "", ""),
                                                                               DateTime.Now, _RequestStatus, _Reason, _PositionApplication);
                    _PositionApplicationDal.InsertPositionApplicationFlow(flow);
                    ts.Complete();
                }
                List<string> accounts =
                    new GetDiyProcess(_DalEmployeeDiyProcess).GetAccountMailListByDiyProcessIDAccountID(
                        currentStep, _PositionApplication.Account.Id);
                new PositionApplicationMailAndPhoneDelegate().CancelMail(_PositionApplication.PKID, accounts, nextStep);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}