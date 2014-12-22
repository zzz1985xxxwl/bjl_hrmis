using SEP.HRMIS.Bll;

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// É¾³ýÇë¼Ùµ¥
    /// </summary>
    public class DeleteLeaveRequest : Transaction
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly int _LeaveRequestID;

        /// <summary>
        /// É¾³ýÇë¼Ùµ¥
        /// </summary>
        public DeleteLeaveRequest(int leaveRequestID)
        {
            _LeaveRequestID = leaveRequestID;
        }

        /// <summary>
        /// É¾³ýÇë¼Ùµ¥
        /// </summary>
        public DeleteLeaveRequest(int leaveRequestID, ILeaveRequestDal mockILeaveRequestDal)
        {
            _LeaveRequestID = leaveRequestID;
            _DalLeaveRequest = mockILeaveRequestDal;
        }

        /// <summary>
        /// ÓÐÐ§ÐÔÅÐ¶Ï
        /// </summary>
        protected override void Validation()
        {
        }

        /// <summary>
        /// É¾³ýÇë¼Ùµ¥
        /// </summary>
        protected override void ExcuteSelf()
        {
            _DalLeaveRequest.DeleteLeaveRequest(_LeaveRequestID);
        }
    }
}
