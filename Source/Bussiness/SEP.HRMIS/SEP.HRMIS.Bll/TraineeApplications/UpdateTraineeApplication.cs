using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.TraineeApplications.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.TraineeApplications
{
    ///<summary>
    ///</summary>
    public class UpdateTraineeApplication: Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static ITraineeApplication _DalTraineeApplication = new TraineeApplicationDal();
        private static IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();
        private readonly TraineeApplication _TraineeApplication;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <returns></returns>
        public UpdateTraineeApplication(TraineeApplication TraineeApplication)
        {
            _TraineeApplication = TraineeApplication;
        }
        ///<summary>
        ///</summary>
        ///<param name="TraineeApplication"></param>
        ///<param name="iTraineeApplicationMock"></param>
        ///<param name="iEmployeeDiyProcessMock"></param>
        public UpdateTraineeApplication( TraineeApplication TraineeApplication, ITraineeApplication iTraineeApplicationMock, IEmployeeDiyProcessDal iEmployeeDiyProcessMock)
        {
            _DalTraineeApplication = iTraineeApplicationMock;
            _DalEmployeeDiyProcess = iEmployeeDiyProcessMock;
            _TraineeApplication = TraineeApplication;
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
            TraineeApplication _TraineeApplicationOld = _DalTraineeApplication.
    GetTraineeApplicationByTraineeApplicationID(_TraineeApplication.PKID);

            //��֤��ѵ�����Ѵ��ڣ���ѵ�����ѽ�����ѵ�������̲����޸Ļ�ɾ��
            if (_TraineeApplicationOld == null)
            {
                throw new ApplicationException("����ѵ���벻����!");
            }
            else if (_TraineeApplicationOld.TraineeApplicationStatuss.Id
                != TraineeApplicationStatus.New.Id)
            {
                throw new ApplicationException("��ѵ�����ѽ�����ѵ�������̲����޸Ļ�ɾ��!");
            }
        }

        protected override void ExcuteSelf()
        {
            //�޸���ѵ����Ļ�����Ϣ
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    DiyStep currentStep = _TraineeApplication.TraineeApplicationDiyProcess.FindFirstStep();
                    DiyStep nextStep = _TraineeApplication.TraineeApplicationDiyProcess.FindSecondStep();

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
                        _TraineeApplication.NextStep = currentStep;
                    }
                    _TraineeApplication.CurrentStep = currentStep;
                    _DalTraineeApplication.UpdateTraineeApplication(_TraineeApplication);
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
        /// <summary>
        /// 
        /// </summary>
        public void FastUpdate()
        {
            _DalTraineeApplication.UpdateTraineeApplication(_TraineeApplication);
        }
    }
}
