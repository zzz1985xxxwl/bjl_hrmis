using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using SEP.HRMIS.Bll.TraineeApplications;
namespace SEP.HRMIS.Facade
{
    public class TraineeApplicationFacade : ITraineeApplicationFacade
    {
        /// <summary>
        /// –¬‘ˆ≈‡—µ…Í«Î
        /// </summary>
        /// <param name="traineeApplication"></param>
        public void AddTraineeApplication(TraineeApplication traineeApplication)
        {
            new AddTraineeApplication(traineeApplication).Excute();
        }

        /// <summary>
        /// –ﬁ∏ƒ≈‡—µ…Í«Î
        /// </summary>
        /// <param name="traineeApplication"></param>
        public void UpdateTraineeApplication(TraineeApplication traineeApplication)
        {
            new UpdateTraineeApplication(traineeApplication).Excute();
        }

        public void UpdateTraineeApplicationDal(TraineeApplication TraineeApplication)
        {
            new UpdateTraineeApplication(TraineeApplication).FastUpdate();
        }

        /// <summary>
        /// …æ≥˝≈‡—µ…Í«Î
        /// </summary>
        /// <param name="traineeApplicationID"></param>
        public void DeleteTraineeApplication( int traineeApplicationID)
        {
            new DeleteTraineeApplication(traineeApplicationID).Excute();
        }

        /// <summary>
        /// Œ“µƒ≈‡—µ…Í«Î
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TraineeApplication> GetEmployeeTraineeApplicationByEmployeeID(int id)
        {
            return new GetTraineeApplication().GetTraineeApplicationByAccountID(id);
        }

        /// <summary>
        /// ≤È—Ø≈‡—µ…Í«Î
        /// </summary>
        /// <returns></returns>
        public List<TraineeApplication> GetTraineeApplicationByCondition(
            string traineeName, string studentName, string courseName,
            DateTime? traineeFrom, DateTime? traineeTo, int hasCertifacation,
            TrainScopeType trainScopeEnum,
            TraineeApplicationStatus statusEnum)
        {
            return new GetTraineeApplication().GetTraineeApplicationByCondition(
                traineeName, studentName, courseName,traineeFrom, traineeTo, hasCertifacation,
             trainScopeEnum,statusEnum);
        }


        /// <summary>
        /// µ»¥˝…Û∫Àµƒ≈‡—µ…Í«Î
        /// </summary>
        /// <returns></returns>
        public List<TraineeApplication> GetEmployeeReimbursingByLeadID(int accountID)
        {
            return new GetTraineeApplication().GetConfirmTraineeApplication(accountID);
        }

        /// <summary>
        /// …Û∫À
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="traineeApplicationID"></param>
        public void ApproveTraineeApplication(Account loginUser, int traineeApplicationID)
        {
            new ApproveTraineeApplication(loginUser, traineeApplicationID, TraineeApplicationStatus.ApprovePass,"OK").Excute();
        }

        /// <summary>
        /// ≤È’“≈‡—µ…Í«Î
        /// </summary>
        /// <param name="TraineeApplicationID"></param>
        public TraineeApplication GetTraineeApplicationByPkid(int TraineeApplicationID)
        {
            return new GetTraineeApplication().GetTraineeApplicationByPKID(TraineeApplicationID);
            //return new TraineeApplication();
        }

        /// <summary>
        /// “—æ≠…Û∫Àµƒ≈‡—µ…Í«Î
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetMyAuditingTraineeApplications(int accountID)
        {
            Employee employee = new Employee(accountID, EmployeeTypeEnum.NormalEmployee);
            employee.TraineeApplicationList = new GetTraineeApplication().GetMyAuditingTraineeApplications(accountID);
            return employee;       
        }

        /// <summary>
        /// ≈‡—µ…Í«Îµƒ¡˜≥Ãº«¬º
        /// </summary>
        /// <param name="traineeApplicationID"></param>
        /// <returns></returns>
        public List<TraineeApplicationFlow> GetTraineeApplicationFlowByTraineeApplicationID(int traineeApplicationID)
        {
            return new GetTraineeApplication().GetTraineeApplicationFlowByTraineeApplicationID(traineeApplicationID);

        }

        public void ApproveTraineeApplicationWhole(Account loginUser, int TraineeApplicationID, 
            TraineeApplicationStatus status, string remark)
        {
            new ApproveTraineeApplication(loginUser, TraineeApplicationID,status,remark).Excute();
        }
    }
}
