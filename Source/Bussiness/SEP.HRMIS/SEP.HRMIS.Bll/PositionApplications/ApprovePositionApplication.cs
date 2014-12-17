using System;
using System.Transactions;
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
    public class ApprovePositionApplication : Transaction
    {
        private readonly int _OperatorID;
        private readonly string _Reason;
        private RequestStatus _RequestStatus;
        private readonly PositionApplication _PositionApplication;

        private readonly IPositionApplicationDal _PositionApplicationDal = DalFactory.DataAccess.CreatePositionApplication();

        /// <summary>
        /// 取消
        /// </summary>
        public ApprovePositionApplication(PositionApplication positionApplication, int operatorID,
                                       RequestStatus requestStatus, string reason)
        {
            _PositionApplication = positionApplication;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            //判断信息是否为空
            if (_PositionApplication == _PositionApplicationDal.GetPositionApplicationByPKID(_PositionApplication.PKID))
            {
                HrmisUtility.ThrowException(HrmisUtility._PositionApplication_Not_Exit);
            }
            else
            {
                //如果请假信息状态不是提交或取消请假状态，不能审批
                if (!RequestStatus.CanApproveStatus(_PositionApplication.Status))
                {
                    HrmisUtility.ThrowException(HrmisUtility._PositionApplication_CanNot_BeApproved);
                }
                _PositionApplication.CurrentStep.OperatorID =
                    new GetPositionApplication().ChangeOperatorToEmployee(_PositionApplication, _PositionApplication.CurrentStep);

                if (_PositionApplication.CurrentStep.OperatorID != _OperatorID)
                {
                    HrmisUtility.ThrowException(HrmisUtility._No_Auth_To_Approve);
                }
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// 操作结果
        /// </summary>
        public string ResultMessage
        {
            get { return _ResultMessage; }
            set { _ResultMessage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            DiyStep cstep;
            DiyStep nstep;
            ConfirmItem(out cstep, out nstep);
            new PositionApplicationMailAndPhoneDelegate().ConfirmOperationMail(_PositionApplication, _OperatorID, cstep, nstep);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfirmItem(out DiyStep cstep, out DiyStep nstep)
        {
            Validation();
            cstep = null;
            nstep = null;
            try
            {
                DiyStep currentStep = _PositionApplication.DiyProcess.FindStep(_PositionApplication.CurrentStep.DiyStepID);
                DiyStep nextStep = _PositionApplication.DiyProcess.FindNextStep(_PositionApplication.CurrentStep.DiyStepID);
                if (nextStep == null)
                {
                    nextStep = new DiyStep(0, "结束", OperatorType.Others, 0);
                }

                ChangeRequestStatus(nextStep);

                if (_RequestStatus.Id == RequestStatus.ApproveFail.Id ||
                    _RequestStatus.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    nextStep = new DiyStep(0, "结束", OperatorType.Others, 0);
                }

                _PositionApplication.Status = _RequestStatus;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _PositionApplicationDal.UpdatePositionApplication(_PositionApplication);
                    _PositionApplicationDal.UpdatePositionApplicationStatusByPositionApplicationID(_PositionApplication.PKID,
                                                                                      _RequestStatus, nextStep.DiyStepID);
                    PositionApplicationFlow flow = new PositionApplicationFlow(0, _PositionApplication.PKID,
                                                                               new Account(_OperatorID, "", ""),
                                                                               DateTime.Now, _RequestStatus, _Reason, _PositionApplication);
                    _PositionApplicationDal.InsertPositionApplicationFlow(flow);
                    ts.Complete();
                }
                new PositionApplicationMailAndPhoneDelegate().ConfirmOperationMail(_PositionApplication, _OperatorID, currentStep, nextStep);
                cstep = currentStep;
                nstep = nextStep;
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void ChangeRequestStatus(DiyStep nextStep)
        {
            if (nextStep.Status != "取消" && _RequestStatus.Id == RequestStatus.ApprovePass.Id)
            {
                _RequestStatus = RequestStatus.Approving;
            }
            if (nextStep.Status != "结束" && _RequestStatus.Id == RequestStatus.ApproveCancelPass.Id)
            {
                _RequestStatus = RequestStatus.CancelApproving;
            }
        }
    }
}