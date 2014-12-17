using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IDal
{
    public interface ITraineeApplication
    {
        void InsertTraineeApplication(TraineeApplication traineeApplication);
        void UpdateTraineeApplication(TraineeApplication traineeApplication);
        void DeleteTraineeApplication(int traineeApplicationID);

        List<TraineeApplication> GetEmployeeTraineeApplicationByEmployeeID(int employeeID);
        List<TraineeApplication> GetTraineeApplicationByCondition
            (string traineeName, string courseName,
            DateTime? traineeFrom, DateTime? traineeTo,int hasCertifacation,
            TrainScopeType trainScopeEnum,
            TraineeApplicationStatus statusEnum);

        TraineeApplication GetTraineeApplicationByTraineeApplicationID(int TraineeApplicationID);
        void ApproveTraineeApplication(Account loginUser, TraineeApplication TraineeApplication,
            TraineeApplicationStatus traineeApplicationStatus);

        /// <summary>
        /// ��ȡ��½������˵���ѵ����
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<TraineeApplication> GetMyAuditingTraineeApplications(int accountID);

        /// <summary>
        /// ��ȡ����˵���ѵ����
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetConfimingTraineeApplications();
        /// <summary>
        /// �����ѵ��������
        /// </summary>
        /// <param name="trainAppID"></param>
        /// <returns></returns>
        List<TraineeApplicationFlow> GetApplicationFlows(int trainAppID);
    }
}
