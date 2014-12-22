using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.HRMIS.Model;
using System.Collections.Generic;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 职位历史
    /// </summary>
    public interface IPositionHistoryFacade
    {
        /// <summary>
        /// 新增职位历史，当修改职位等级时调用
        /// </summary>
        /// <param name="operatorAccount"></param>
        void AddPositionHistoryFacade(Account operatorAccount);
        /// <summary>
        /// 新增职位历史，当修改某个职位时调用，并生成Positioin相关的员工历史
        /// </summary>
        /// <param name="operatorAccount"></param>
        /// <param name="position"></param>
        void AddPositionHistoryFacade(Account operatorAccount, Position position);


        PositionHistory GetPositionHistoryByPKID(int pkid);

        List<PositionHistory> GetPositionHistoryByPositionID(int positionID);
    }
}
