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
        /// 获取登陆人已审核的培训申请
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<TraineeApplication> GetMyAuditingTraineeApplications(int accountID);

        /// <summary>
        /// 获取待审核的培训申请
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetConfimingTraineeApplications();
        /// <summary>
        /// 获得培训申请流程
        /// </summary>
        /// <param name="trainAppID"></param>
        /// <returns></returns>
        List<TraineeApplicationFlow> GetApplicationFlows(int trainAppID);
    }
}
