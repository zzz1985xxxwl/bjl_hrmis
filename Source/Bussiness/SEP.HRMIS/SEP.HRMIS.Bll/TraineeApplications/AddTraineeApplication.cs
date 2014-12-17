using System;
using System.Collections.Generic;
using System.Transactions;
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
    public class AddTraineeApplication: Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static ITraineeApplication _DalTraineeApplication = DalFactory.DataAccess.CreateTraineeApplication();
        private readonly TraineeApplication _TraineeApplication;
        private static IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        //private Account _LoginUser;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <returns></returns>
        public AddTraineeApplication(TraineeApplication traineeApplication)
        {
            _TraineeApplication = traineeApplication;
        }
        /// <summary>
        /// ������ѵ����
        /// </summary>
        public AddTraineeApplication(
            TraineeApplication traineeApplication, ITraineeApplication iTraineeApplicationMock, 
            IEmployeeDiyProcessDal iEmployeeDiyProcess)
        {
            _DalTraineeApplication = iTraineeApplicationMock;
            _TraineeApplication = traineeApplication;
            _DalEmployeeDiyProcess = iEmployeeDiyProcess;
        }

        protected override void Validation()
        {
            //�жϸ��˺��Ƿ�����ѵ��������
            _TraineeApplication.TraineeApplicationDiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID
                (ProcessType.TraineeApplication, _TraineeApplication.Applicant.Id);
            if (_TraineeApplication.TraineeApplicationDiyProcess == null)
            {
                throw new ApplicationException("���˺�û����ѵ��������!");
            }
        }
        // ������ѵ������Ϣ
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    DiyStep currentStep = _TraineeApplication.TraineeApplicationDiyProcess.FindFirstStep();
                    DiyStep nextStep = _TraineeApplication.TraineeApplicationDiyProcess.FindSecondStep();
                    _TraineeApplication.CurrentStep = currentStep;
                    if (_TraineeApplication.TraineeApplicationStatuss
                        == TraineeApplicationStatus.Submit)
                    {
                        _TraineeApplication.NextStep = nextStep;
                        _TraineeApplication.TraineeApplicationFlowList =
                            new List<TraineeApplicationFlow>();
                        _TraineeApplication.TraineeApplicationFlowList.Add(
                            new TraineeApplicationFlow(_TraineeApplication.Applicant, DateTime.Now,
                                                       _TraineeApplication.TraineeApplicationStatuss));
                    }
                    else
                    {
                        _TraineeApplication.NextStep=currentStep;
                    }
                    _TraineeApplication.CurrentStep = currentStep;
                    _DalTraineeApplication.InsertTraineeApplication(_TraineeApplication);
                    ts.Complete();
                    if (_TraineeApplication.TraineeApplicationStatuss
                       == TraineeApplicationStatus.Submit)
                    {
                        new TraineeApplicationMailAndPhoneDelegate().
                            SubmitOperation(_TraineeApplication);
                    }
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
