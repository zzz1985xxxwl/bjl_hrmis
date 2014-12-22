using System.Collections.Generic;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IFacede
{
    public interface IPositionApplicationFacade
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="positionApplication"></param>
        void AddPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="positionApplication"></param>
        void SubmitPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="positionApplication"></param>
        void UpdatePositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// �޸��ύ
        /// </summary>
        /// <param name="positionApplication"></param>
        void UpdateSubmitPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="positionApplicationID"></param>
        void DeletePositionApplication(int positionApplicationID);

        /// <summary>
        /// �����˺�ID��ø��˺ŵ�������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<PositionApplication> GetPositionApplicationByAccountID(int accountID);

        /// <summary>
        /// ����pkid�����Ϣ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        PositionApplication GetPositionApplicationByPKID(int pkid);

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="operatorID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string CancelPositionApplication(int positionApplicationID, int operatorID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="positionApplication"></param>
        /// <param name="accountID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string ApprovePositionApplication(PositionApplication positionApplication, int accountID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// �����˺�ID��ȡ�ô���˵�
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<PositionApplication> GetConfirmPositionApplication(int accountID);

        /// <summary>
        /// ��˹���
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<PositionApplication> GetPositionApplicationConfirmHistoryByOperatorID(int operatorID, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <returns></returns>
        List<PositionApplicationFlow> GetPositionApplicationFlowByPositionApplicationID(int positionApplicationID);

        void SetIsPublishApplication(int appID, int isPublish);

        /// <summary>
        /// ���²�ѯר��
        /// </summary>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="isPublish"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        List<PositionApplication> GetPositionApplicationByCondition(string name, string account, int isPublish,
                                                                        int status);
    }
}
