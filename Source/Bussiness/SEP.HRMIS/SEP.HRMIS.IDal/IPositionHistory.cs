
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Positions;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ְλ��ʷ���ݿ⽻��
    /// </summary>
    public interface IPositionHistory
    {
        /// <summary>
        /// ����ְλ��ʷ
        /// </summary>
        /// <param name="positionHistory"></param>
        /// <returns></returns>
        int CreatePositionHistory(PositionHistory positionHistory);

        Position GetPositionByPositionIDAndDateTime(int positionID, DateTime dt);

        List<Position> GetPositionByDateTime(DateTime dt);
        /// <summary>
        /// ɾ��ְλ��ʷ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        int DeletePositionHistory(int pkid);
        PositionHistory GetPositionHistoryByPKID(int pkid);

        List<PositionHistory> GetPositionHistoryByPositionID(int positionID);
    }
}
