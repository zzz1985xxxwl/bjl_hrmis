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
        /// ������ѵ����
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void AddTraineeApplication(TraineeApplication TraineeApplication);

        /// <summary>
        /// �޸���ѵ����
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void UpdateTraineeApplication( TraineeApplication TraineeApplication);

        /// <summary>
        /// ֱ���޸ģ������κ��ж�
        /// </summary>
        /// <param name="TraineeApplication"></param>
        void UpdateTraineeApplicationDal(TraineeApplication TraineeApplication);

        /// <summary>
        /// ɾ����ѵ����
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        void DeleteTraineeApplication(int TraineeApplicationID);

        /// <summary>
        /// �ҵ���ѵ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TraineeApplication> GetEmployeeTraineeApplicationByEmployeeID(int id);

        /// <summary>
        /// ��ѯ��ѵ����
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetTraineeApplicationByCondition(
            string trainerName, string studentName,string courseName,
            DateTime? traineeFrom, DateTime? traineeTo, int hasCertifacation,
            TrainScopeType trainScopeEnum,
            TraineeApplicationStatus statusEnum);


        /// <summary>
        /// �ȴ���˵���ѵ����
        /// </summary>
        /// <returns></returns>
        List<TraineeApplication> GetEmployeeReimbursingByLeadID(int accountID);

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="TraineeApplicationID"></param>
        void ApproveTraineeApplication(Account loginUser, int TraineeApplicationID);

        /// <summary>
        /// ������ѵ����
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        TraineeApplication GetTraineeApplicationByPkid(int TraineeApplicationID);

        /// <summary>
        /// �Ѿ���˵���ѵ����
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetMyAuditingTraineeApplications(int accountID);

        /// <summary>
        /// ��ѵ��������̼�¼
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        /// <returns></returns>
        List<TraineeApplicationFlow> GetTraineeApplicationFlowByTraineeApplicationID(int TraineeApplicationID);

        /// <summary>
        /// �����ѵ��������
        /// </summary>
        void ApproveTraineeApplicationWhole(Account loginUser, int TraineeApplicationID,TraineeApplicationStatus status,string remark);


    }
}
