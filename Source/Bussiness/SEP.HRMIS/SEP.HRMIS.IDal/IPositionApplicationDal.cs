using System.Collections.Generic;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    public interface IPositionApplicationDal
    {
        int InsertPositionApplication(PositionApplication positionApplication);

        void UpdatePositionApplication(PositionApplication positionApplication);

        void DeletePositionApplication(int positionApplicationID);

        int InsertPositionApplicationFlow(PositionApplicationFlow flow);

        void UpdatePositionApplicationStatusByPositionApplicationID(int positionApplicationID, RequestStatus status, int nextStepID);

        PositionApplication GetPositionApplicationByPKID(int PositionApplicationID);

        List<PositionApplication> GetPositionApplicationByAccountID(int accountID);

        List<PositionApplication> GetConfirmPositionApplication();

        List<PositionApplication> GetPositionApplicationConfirmHistoryByOperatorID(int operatorID);

        List<PositionApplicationFlow> GetPositionApplicationFlowByPositionApplicationID(int positionApplicationID);

        int SetIsPublishApplication(int id, int publish);

        List<PositionApplication> GetPositionApplicationByCondition(string name, int isPublish, int status);

    }
}
