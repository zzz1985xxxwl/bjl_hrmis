using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class GetPositionHistory
    {
        private readonly IPositionHistory _DalPositionHistory = DalFactory.DataAccess.CreatePositionHistory();

        public PositionHistory GetPositionHistoryByPKID(int pkid)
        {
            return _DalPositionHistory.GetPositionHistoryByPKID(pkid);
        }

        public List<PositionHistory> GetPositionHistoryByPositionID(int positionID)
        {
            return _DalPositionHistory.GetPositionHistoryByPositionID(positionID);
        }
    }
}
