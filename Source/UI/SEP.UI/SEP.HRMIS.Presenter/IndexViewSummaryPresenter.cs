using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class IndexViewSummaryPresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly IOutApplicationFacade _OutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly IOverWorkFacade _OverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly IAssessActivityFacade _AssessActivityFacade = InstanceFactory.AssessActivityFacade;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();
        public int GetLeaveRequestConfirmCount(Account loginUser)
        {
            return _ILeaveRequestFacade.GetConfirmLeaveRequest(loginUser.Id).Count;
        }

        public int GetOutApplicationConfirmCount(Account loginUser)
        {
            return _OutApplicationFacade.GetConfirmOutApplicationByNextOperatorID(loginUser.Id).Count;
        }

        public int GetOverWorkConfirmCount(Account loginUser)
        {
            return _OverWorkFacade.GetConfirmOverWorkByNextOperatorID(loginUser.Id).Count;
        }

        public int GetAssessActivityConfirmCount(Account loginUser)
        {
            int count = _AssessActivityFacade.GetCeoFillActivitys(loginUser.Id).Count;
            count += _AssessActivityFacade.GetEmployeeFillActivitys(loginUser.Id).Count;
            count += _AssessActivityFacade.GetManagerFillActivitys(loginUser.Id).Count;
            count += GetHrFillActivitys(loginUser).Count;
            count += _AssessActivityFacade.GetSummarizeCommmentFillActivitys(loginUser.Id).Count;
            return count;
        }
        public int GetTrainApplicationConfirmCount(Account loginUser)
        {
            return _ITrainFacade.GetEmployeeReimbursingByLeadID(loginUser.Id).Count;
        }

        private List<Model.AssessActivity> GetHrFillActivitys(Account loginUser)
        {
            List<Model.AssessActivity> list =
                AssessActivityLogic.GetAssessActivityByEmployeeStatus(-1, AssessStatus.HRFilling);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Account operAccount =
                    InstanceFactory.AssessActivityFacade.GetDiyStepAccount(list[i].ItsEmployee.Account.Id,
                                                                           list[i].DiyProcess.DiySteps[
                                                                               list[i].NextStepIndex]);
                if (operAccount == null)
                {
                    InstanceFactory.AssessActivityFacade.InterruptActivity(list[i].AssessActivityID);
                    list.RemoveAt(i);
                }
                else if (operAccount.Id != loginUser.Id)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }
    }
}
