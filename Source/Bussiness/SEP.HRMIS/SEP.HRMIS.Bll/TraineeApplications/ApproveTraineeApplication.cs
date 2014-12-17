using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.TraineeApplications.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.TraineeApplications
{
    ///<summary>
    ///</summary>
    public class ApproveTraineeApplication: Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static ITraineeApplication _DalTraineeApplication = 
            DalFactory.DataAccess.CreateTraineeApplication();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        private readonly int _TraineeApplicationID;
        private readonly Account _LoginUser;
        private TraineeApplication _TraineeApplication;
        private readonly TraineeApplicationStatus _Status;
        private readonly string _Remark;

        ///<summary>
        ///</summary>
        ///<param name="loginUser"></param>
        ///<param name="TraineeApplicationID"></param>
        ///<param name="status"></param>
        ///<param name="remark"></param>
        public ApproveTraineeApplication(Account loginUser, int TraineeApplicationID,
            TraineeApplicationStatus status, string remark)
        {
            _TraineeApplicationID = TraineeApplicationID;
            _LoginUser = loginUser;
            _Status = status;
            _Remark = remark;
        }

        ///<summary>
        ///</summary>
        ///<param name="loginUser"></param>
        ///<param name="TraineeApplicationID"></param>
        ///<param name="iTraineeApplicationMock"></param>
        ///<param name="iEmployeeDiyProcessMock"></param>
        ///<param name="status"></param>
        ///<param name="remark"></param>
        public ApproveTraineeApplication(Account loginUser, int TraineeApplicationID, 
            ITraineeApplication iTraineeApplicationMock, IEmployeeDiyProcessDal iEmployeeDiyProcessMock,
            TraineeApplicationStatus status, string remark)
        {
            _DalTraineeApplication = iTraineeApplicationMock;
            _DalEmployeeDiyProcess = iEmployeeDiyProcessMock;
            _TraineeApplicationID = TraineeApplicationID;
            _LoginUser = loginUser;
            _Status = status;
            _Remark = remark;
        }

        protected override void Validation()
        {
            _TraineeApplication = _DalTraineeApplication.GetTraineeApplicationByTraineeApplicationID(_TraineeApplicationID);
            if (_TraineeApplication == null)
            {
                throw new ApplicationException("该培训申请不存在!");
            }
        }
        protected override void ExcuteSelf()
        {
            try
            {
                DiyStep currentStep=_TraineeApplication.TraineeApplicationDiyProcess.FindStep
                    (_TraineeApplication.NextStep.DiyStepID);
                //TraineeApplicationStatus traineeApplicationStatus = _TraineeApplication.TraineeApplicationStatuss;
                DiyStep nextStep = _TraineeApplication.TraineeApplicationDiyProcess.FindNextStep
                    (_TraineeApplication.NextStep.DiyStepID);
                if (nextStep == null)
                {
                    nextStep = new DiyStep(0, "结束", OperatorType.Others, 0);
                }
                if (_Status.Id == TraineeApplicationStatus.ApproveFail.Id)
                {
                    nextStep = new DiyStep(0, "结束", OperatorType.Others, 0);
                }

                _TraineeApplication.NextStep = nextStep;
                _TraineeApplication.CurrentStep = currentStep;
                if (nextStep.DiyStepID != 0)
                {
                    _TraineeApplication.TraineeApplicationStatuss = TraineeApplicationStatus.Approving;
                }
                else
                {
                    _TraineeApplication.TraineeApplicationStatuss = _Status;
                }
                //_TraineeApplication.TraineeApplicationFlowList =
                //    new List<TraineeApplicationFlow>();
                //_TraineeApplication.TraineeApplicationFlowList.Add(
                //    new TraineeApplicationFlow(_LoginUser, DateTime.Now,
                //                               _TraineeApplication.TraineeApplicationStatuss));
                TraineeApplicationFlow flow =
                    new TraineeApplicationFlow(_LoginUser, DateTime.Now,
                                               _TraineeApplication.TraineeApplicationStatuss);
                flow.Remark = _Remark;
                _TraineeApplication.TraineeApplicationFlowList=new List<TraineeApplicationFlow>();
                _TraineeApplication.TraineeApplicationFlowList.Add(flow);
                _DalTraineeApplication.ApproveTraineeApplication(_LoginUser, _TraineeApplication,
                                                                 _TraineeApplication.TraineeApplicationStatuss);
                DiyProcess hrDiyProcess = _DalEmployeeDiyProcess.
                    GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal,
                                                           _TraineeApplication.Applicant.Id);

                List<Account> accountList = new List<Account>();
                if (hrDiyProcess != null && hrDiyProcess.DiySteps != null && hrDiyProcess.DiySteps.Count > 0)
                {
                    accountList = hrDiyProcess.DiySteps[0].MailAccount;
                }
                new TraineeApplicationMailAndPhoneDelegate().ConfirmOperation(_TraineeApplication,
                                                                              accountList, _LoginUser.Id);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
