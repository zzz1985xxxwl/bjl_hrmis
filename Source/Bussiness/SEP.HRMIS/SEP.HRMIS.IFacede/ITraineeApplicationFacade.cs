using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface ITraineeApplicationFacade
    {
        /// <summary>
        /// 新增培训申请
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void AddTraineeApplication(TraineeApplication TraineeApplication);

        /// <summary>
        /// 修改培训申请
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void UpdateTraineeApplication( TraineeApplication TraineeApplication);

        /// <summary>
        /// 直接修改，不做任何判断
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void UpdateTraineeApplicationDal(TraineeApplication TraineeApplication);

        /// <summary>
        /// 删除培训申请
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        void DeleteTraineeApplication(int TraineeApplicationID);

        /// <summary>
        /// 我的培训申请
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TraineeApplication> GetEmployeeTraineeApplicationByEmployeeID(int id);

        /// <summary>
        /// 查询培训申请
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetTraineeApplicationByCondition(
            string trainerName, string studentName,string courseName,
            DateTime? traineeFrom, DateTime? traineeTo, int hasCertifacation,
            TrainScopeType trainScopeEnum,
            TraineeApplicationStatus statusEnum);


        /// <summary>
        /// 等待审核的培训申请
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetEmployeeReimbursingByLeadID(int accountID);

        /// <summary>
        /// 快速完成
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="TraineeApplicationID"></param>
        void ApproveTraineeApplication(Account loginUser, int TraineeApplicationID);

        /// <summary>
        /// 查找培训申请
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        TraineeApplication GetTraineeApplicationByPkid(int TraineeApplicationID);

        /// <summary>
        /// 已经审核的培训申请
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetMyAuditingTraineeApplications(int accountID);

        /// <summary>
        /// 培训申请的流程记录
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        /// <returns></returns>
        List<TraineeApplicationFlow> GetTraineeApplicationFlowByTraineeApplicationID(int TraineeApplicationID);

        /// <summary>
        /// 审核培训申请流程
        /// </summary>
        void ApproveTraineeApplicationWhole(Account loginUser, int TraineeApplicationID,TraineeApplicationStatus status,string remark);


    }
}
