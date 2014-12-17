using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.HRMIS.Model;
using System.Collections.Generic;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 职位历史
    /// </summary>
    public class PositionHistoryFacade : IPositionHistoryFacade
    {
        public void AddPositionHistoryFacade(Account operatorAccount)
        {
            new AddPositionHistory(operatorAccount).Excute();
        }

        public void AddPositionHistoryFacade(Account operatorAccount, Position position)
        {
            new AddPositionHistory(operatorAccount, position).Excute();
        }

        public PositionHistory GetPositionHistoryByPKID(int pkid)
        {
            return new GetPositionHistory().GetPositionHistoryByPKID(pkid);
        }

        public List<PositionHistory> GetPositionHistoryByPositionID(int positionID)
        {
            return new GetPositionHistory().GetPositionHistoryByPositionID(positionID);
        }
    }
}
