using SEP.HRMIS.Bll;

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// ɾ����ٵ�
    /// </summary>
    public class DeleteLeaveRequest : Transaction
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly int _LeaveRequestID;

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        public DeleteLeaveRequest(int leaveRequestID)
        {
            _LeaveRequestID = leaveRequestID;
        }

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        public DeleteLeaveRequest(int leaveRequestID, ILeaveRequestDal mockILeaveRequestDal)
        {
            _LeaveRequestID = leaveRequestID;
            _DalLeaveRequest = mockILeaveRequestDal;
        }

        /// <summary>
        /// ��Ч���ж�
        /// </summary>
        protected override void Validation()
        {
        }

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        protected override void ExcuteSelf()
        {
            _DalLeaveRequest.DeleteLeaveRequest(_LeaveRequestID);
        }
    }
}
