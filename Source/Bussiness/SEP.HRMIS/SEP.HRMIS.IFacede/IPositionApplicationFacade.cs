using System.Collections.Generic;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IFacede
{
    public interface IPositionApplicationFacade
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="positionApplication"></param>
        void AddPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="positionApplication"></param>
        void SubmitPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="positionApplication"></param>
        void UpdatePositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// 修改提交
        /// </summary>
        /// <param name="positionApplication"></param>
        void UpdateSubmitPositionApplication(PositionApplication positionApplication);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="positionApplicationID"></param>
        void DeletePositionApplication(int positionApplicationID);

        /// <summary>
        /// 根据账号ID获得该账号的所有信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<PositionApplication> GetPositionApplicationByAccountID(int accountID);

        /// <summary>
        /// 根据pkid获得信息
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        PositionApplication GetPositionApplicationByPKID(int pkid);

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="operatorID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string CancelPositionApplication(int positionApplicationID, int operatorID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="positionApplication"></param>
        /// <param name="accountID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string ApprovePositionApplication(PositionApplication positionApplication, int accountID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 根据账号ID获取该待审核的
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<PositionApplication> GetConfirmPositionApplication(int accountID);

        /// <summary>
        /// 审核过的
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
        /// 人事查询专用
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
