using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 实现ILeaveRequestFlowDal接口中的方法
    /// </summary>
    public class LeaveRequestFlowDal : ILeaveRequestFlowDal
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmOperatorID = "@OperatorID";
        private const string _ParmOperationTime = "@OperationTime";
        private const string _ParmLeaveRequestID = "@LeaveRequestID";
        private const string _ParmLeaveRequestItemID = "@LeaveRequestItemID";
        private const string _ParmLeaveRequestOperation = "@Operation";
        private const string _ParmRemark = "@Remark";

        private const string _DBOperatorID = "OperatorID";
        private const string _DBOperationTime = "OperationTime";
        private const string _DBRemark = "Remark";
        private const string _DBLeaveRequestItemID = "LeaveRequestItemID";
        private const string _DBOperation = "Operation";
        private const string _DBPKID = "PKID";

        /// <summary>
        /// 员工提交请假申请
        /// </summary>
        /// <param name="leaveRequestFlow"></param>
        /// <returns></returns>
        public int InsertLeaveRequestFlow(LeaveRequestFlow leaveRequestFlow)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestItemID, SqlDbType.Int).Value = leaveRequestFlow.LeaveRequestItem.LeaveRequestItemID;
            cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = leaveRequestFlow.Account.Id;
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = leaveRequestFlow.OperationTime;
            cmd.Parameters.Add(_ParmLeaveRequestOperation, SqlDbType.Int).Value = leaveRequestFlow.LeaveRequestStatus.Id;
            cmd.Parameters.Add(_ParmRemark, SqlDbType.Text).Value = leaveRequestFlow.Remark;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertLeaveRequestFlow", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 根据LeaveRequestID删除请假单历史流程
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public int DeleteLeaveRequestFlowByLeaveRequestID(int leaveRequestID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            SqlHelper.ExecuteNonQuery("DeleteLeaveRequestFlowByLeaveRequestID", cmd);
            return leaveRequestID;
        }

        /// <summary>
        /// 根据PKID查询请假单
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public LeaveRequestFlow GetLeaveRequestFlowByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestFlowByPKID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
                    leaveRequestFlow.LeaveRequestFlowID = pkid;
                    leaveRequestFlow.Account = new Account((int) sdr[_DBOperatorID], "", "");
                    leaveRequestFlow.LeaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBLeaveRequestItemID], Convert.ToDateTime("1900-1-1"),
                                             Convert.ToDateTime("1900-1-1"), 0, RequestStatus.All);
                    leaveRequestFlow.LeaveRequestStatus = RequestStatus.FindRequestStatus((Int32)sdr[_DBOperation]);
                    leaveRequestFlow.OperationTime = Convert.ToDateTime(sdr[_DBOperationTime]);
                    leaveRequestFlow.Remark = sdr[_DBRemark].ToString();

                    return leaveRequestFlow;
                }
                return null;
            }
        }

        /// <summary>
        /// 根据PKID查询请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestID(int leaveRequestID)
        {
            List<LeaveRequestFlow> iRet = new List<LeaveRequestFlow>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestID, SqlDbType.Int).Value = leaveRequestID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestFlowByLeaveRequestID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
                    leaveRequestFlow.LeaveRequestFlowID = (int)sdr[_DBPKID];
                    leaveRequestFlow.Account = new Account((int)sdr[_DBOperatorID], "", "");
                    leaveRequestFlow.LeaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBLeaveRequestItemID], Convert.ToDateTime("1900-1-1"),
                                             Convert.ToDateTime("1900-1-1"), 0, RequestStatus.All);
                    leaveRequestFlow.LeaveRequestStatus = RequestStatus.FindRequestStatus((Int32)sdr[_DBOperation]);
                    leaveRequestFlow.OperationTime = Convert.ToDateTime(sdr[_DBOperationTime]);
                    leaveRequestFlow.Remark = sdr[_DBRemark].ToString();
                    iRet.Add(leaveRequestFlow);
                }
                return iRet;
            }
        }

        /// <summary>
        /// 根据PKID查询请假单
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        public List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestItemID(int leaveRequestItemID)
        {
            List<LeaveRequestFlow> iRet = new List<LeaveRequestFlow>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmLeaveRequestItemID, SqlDbType.Int).Value = leaveRequestItemID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLeaveRequestFlowByLeaveRequestItemID", cmd))
            {
                while (sdr.Read())
                {
                    LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
                    leaveRequestFlow.LeaveRequestFlowID = (int)sdr[_DBPKID];
                    leaveRequestFlow.Account = new Account((int)sdr[_DBOperatorID], "", "");
                    leaveRequestFlow.LeaveRequestItem =
                        new LeaveRequestItem((int)sdr[_DBLeaveRequestItemID], Convert.ToDateTime("1900-1-1"),
                                             Convert.ToDateTime("1900-1-1"), 0, RequestStatus.All);
                    leaveRequestFlow.LeaveRequestStatus = RequestStatus.FindRequestStatus((Int32)sdr[_DBOperation]);
                    leaveRequestFlow.OperationTime = Convert.ToDateTime(sdr[_DBOperationTime]);
                    iRet.Add(leaveRequestFlow);
                }
                return iRet;
            }
        }

    }
}
