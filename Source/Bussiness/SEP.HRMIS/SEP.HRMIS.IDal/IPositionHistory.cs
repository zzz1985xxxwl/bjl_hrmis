
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Positions;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 职位历史数据库交互
    /// </summary>
    public interface IPositionHistory
    {
        /// <summary>
        /// 新增职位历史
        /// </summary>
        /// <param name="positionHistory"></param>
        /// <returns></returns>
        int CreatePositionHistory(PositionHistory positionHistory);

        Position GetPositionByPositionIDAndDateTime(int positionID, DateTime dt);

        List<Position> GetPositionByDateTime(DateTime dt);
        /// <summary>
        /// 删除职位历史
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        int DeletePositionHistory(int pkid);
        PositionHistory GetPositionHistoryByPKID(int pkid);

        List<PositionHistory> GetPositionHistoryByPositionID(int positionID);
    }
}
