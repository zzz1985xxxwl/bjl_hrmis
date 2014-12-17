using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ILeaveRequestFlowDal½Ó¿Ú
    /// </summary>
    public interface ILeaveRequestFlowDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestFlow"></param>
        /// <returns></returns>
        int InsertLeaveRequestFlow(LeaveRequestFlow leaveRequestFlow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        int DeleteLeaveRequestFlowByLeaveRequestID(int leaveRequestID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        LeaveRequestFlow GetLeaveRequestFlowByPKID(int pkid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestID(int leaveRequestID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestItemID(int leaveRequestItemID);
    }
}
