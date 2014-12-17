using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.HRMIS.Bll.TraineeApplications
{
    public class DeleteTraineeApplication: Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static ITraineeApplication _DalTraineeApplication = DalFactory.DataAccess.CreateTraineeApplication();

        private readonly int _TraineeApplicationID;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <returns></returns>
        public DeleteTraineeApplication( int TraineeApplicationID)
        {
            _TraineeApplicationID = TraineeApplicationID;
        }

        public DeleteTraineeApplication(int traineeApplicationID, ITraineeApplication iTraineeApplicationMock)
        {
            _DalTraineeApplication = iTraineeApplicationMock;
            _TraineeApplicationID = traineeApplicationID;
        }
        protected override void Validation()
        {
            TraineeApplication _TraineeApplicationOld = _DalTraineeApplication.
    GetTraineeApplicationByTraineeApplicationID(_TraineeApplicationID);

            //��֤��ѵ�����Ѵ��ڣ���ѵ�����ѽ�����ѵ�������̲����޸Ļ�ɾ��
            if (_TraineeApplicationOld == null)
            {
                throw new ApplicationException("����ѵ���벻����!");
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalTraineeApplication.DeleteTraineeApplication(_TraineeApplicationID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
