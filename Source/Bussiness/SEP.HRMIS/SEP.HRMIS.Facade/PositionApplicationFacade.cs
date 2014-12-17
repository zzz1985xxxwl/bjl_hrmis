using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Bll.PositionApplications;

namespace SEP.HRMIS.Facade
{
    public class PositionApplicationFacade : IPositionApplicationFacade
    {
        public void AddPositionApplication(PositionApplication positionApplication)
        {
            new AddPositionApplication(positionApplication, false).Excute();
        }

        public void SubmitPositionApplication(PositionApplication positionApplication)
        {
            new AddPositionApplication(positionApplication, true).Excute();
        }

        public void UpdatePositionApplication(PositionApplication positionApplication)
        {
            new UpdatePositionApplication(positionApplication, false).Excute();
        }

        public void UpdateSubmitPositionApplication(PositionApplication positionApplication)
        {
            new UpdatePositionApplication(positionApplication, true).Excute();
        }

        public void DeletePositionApplication(int positionApplicationID)
        {
            new DeletePositionApplication(positionApplicationID).Excute();
        }

        public List<PositionApplication> GetPositionApplicationByAccountID(int accountID)
        {
            return new GetPositionApplication().GetPositionApplicationByAccountID(accountID);
        }

        public PositionApplication GetPositionApplicationByPKID(int pkid)
        {
            return new GetPositionApplication().GetPositionApplicationByPKID(pkid);
        }

        public string CancelPositionApplication(int positionApplicationID, int operatorID, RequestStatus requestStatus, string reason)
        {
            CancelPositionApplication cancelAllLeaveRequest =
                new CancelPositionApplication(positionApplicationID, operatorID, requestStatus, reason);
            cancelAllLeaveRequest.Excute();
            return cancelAllLeaveRequest.ResultMessage;
        }

        public string ApprovePositionApplication(PositionApplication positionApplication, int operatorID, RequestStatus requestStatus, string reason)
        {
            ApprovePositionApplication approveWholeLeaveRequest =
                new ApprovePositionApplication(positionApplication, operatorID, requestStatus, reason);
            approveWholeLeaveRequest.Excute();
            return approveWholeLeaveRequest.ResultMessage;
        }

        public List<PositionApplication> GetConfirmPositionApplication(int accountID)
        {
            return new GetPositionApplication().GetConfirmPositionApplication(accountID);
        }

        public List<PositionApplication> GetPositionApplicationConfirmHistoryByOperatorID(int operatorID, string name)
        {
            return new GetPositionApplication().GetPositionApplicationConfirmHistoryByOperatorID(operatorID, name);
        }

        public List<PositionApplicationFlow> GetPositionApplicationFlowByPositionApplicationID(int positionApplicationID)
        {
            return new GetPositionApplication().GetPositionApplicationFlowByPositionApplicationID(positionApplicationID);
        }
        public void SetIsPublishApplication(int appID, int isPublish)
        {
            new SetIsPublishApplication(appID, isPublish).Excute();
        }

        public List<PositionApplication> GetPositionApplicationByCondition(string name, string account, int isPublish, int status)
        {
            return new GetPositionApplication().GetPositionApplicationByCondition(name, account, isPublish, status);
        }
    }
}