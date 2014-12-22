using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class GetPositionHistory
    {
        private readonly IPositionHistory _DalPositionHistory =new PositionHistoryDal(); 

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
