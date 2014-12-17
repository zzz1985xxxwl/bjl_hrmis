using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.HRMIS.Bll.TraineeApplications
{
    public class DeleteTraineeApplication: Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static ITraineeApplication _DalTraineeApplication = DalFactory.DataAccess.CreateTraineeApplication();

        private readonly int _TraineeApplicationID;

        /// <summary>
        /// 构造函数
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

            //验证培训申请已存在，培训申请已进入培训申请流程不可修改或删除
            if (_TraineeApplicationOld == null)
            {
                throw new ApplicationException("该培训申请不存在!");
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
