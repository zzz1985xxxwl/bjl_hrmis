using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.HRMIS.Model;
using System.Collections.Generic;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ְλ��ʷ
    /// </summary>
    public interface IPositionHistoryFacade
    {
        /// <summary>
        /// ����ְλ��ʷ�����޸�ְλ�ȼ�ʱ����
        /// </summary>
        /// <param name="operatorAccount"></param>
        void AddPositionHistoryFacade(Account operatorAccount);
        /// <summary>
        /// ����ְλ��ʷ�����޸�ĳ��ְλʱ���ã�������Positioin��ص�Ա����ʷ
        /// </summary>
        /// <param name="operatorAccount"></param>
        /// <param name="position"></param>
        void AddPositionHistoryFacade(Account operatorAccount, Position position);


        PositionHistory GetPositionHistoryByPKID(int pkid);

        List<PositionHistory> GetPositionHistoryByPositionID(int positionID);
    }
}
