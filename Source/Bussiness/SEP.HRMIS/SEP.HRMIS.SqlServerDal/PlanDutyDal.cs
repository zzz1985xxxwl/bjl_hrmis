using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class PlanDutyDal : IPlanDutyDal
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmDutyClassName = "@DutyClassName";
        private const string _ParmFirstStartFromTime = "@FirstStartFromTime";
        private const string _ParmFirstStartToTime = "@FirstStartToTime";
        private const string _ParmFirstEndTime = "@FirstEndTime";
        private const string _ParmSecondStartTime = "@SecondStartTime";
        private const string _ParmSecondEndTime = "@SecondEndTime";
        
        private const string _ParmAllLimitTime = "@AllLimitTime";
        private const string _ParmLateTime = "@LateTime";
        private const string _ParmEarlyLeaveTime = "@EarlyLeaveTime";
        private const string _ParmAbsentLateTime = "@AbsentLateTime";
        private const string _ParmAbsentEarlyLeaveTime = "@AbsentEarlyLeaveTime";

        private const string _DbPKID = "PKID";
        private const string _DbDutyClassName = "DutyClassName";
        private const string _DbFirstStartFromTime = "FirstStartFromTime";
        private const string _DbFirstStartToTime = "FirstStartToTime";
        private const string _DbFirstEndTime = "FirstEndTime";
        private const string _DbSecondStartTime = "SecondStartTime";
        private const string _DbSecondEndTime = "SecondEndTime";
        
        private const string _DbAllLimitTime = "AllLimitTime";
        private const string _DbLateTime = "LateTime";
        private const string _DbEarlyLeaveTime = "EarlyLeaveTime";
        private const string _DbAbsentLateTime = "AbsentLateTime";
        private const string _DbAbsentEarlyLeaveTime = "AbsentEarlyLeaveTime";

        private const string _DbCount = "Counts";
        private readonly int _retVal = -1;
        private const string _DbCounts = "counts";
        private const string _PlanDutyTableName = "@PlanDutyTableName";
        private const string _Period = "@Period";
        private const string _FromTime = "@FromTime";
        private const string _ToTime = "@ToTime";
        private const string _DbPlanDutyTableName = "PlanDutyTableName";
        private const string _DbPeriod = "Period";
        private const string _DbFromTime = "FromTime";
        private const string _DbToTime = "ToTime";
        private const string _DbFromTimeStart = "FromTimeStart";
        private const string _DbFromTimeEnd = "FromTimeEnd";
        private const string _DbToTimeStart = "ToTimeStart";
        private const string _DbToTimeEnd = "ToTimeEnd";

        private const string _PlanDutyTableID = "@PlanDutyTableID";
        private const string _Date = "@Date";
        private const string _DutyClassID = "@DutyClassID";
        private const string _DbPlanDutyTableID = "PlanDutyTableID";
        private const string _DbDate = "Date";
        private const string _DbDutyClassID = "DutyClassID";
        //private const string _DbDateStart = "DateStart";
        //private const string _DbDateEnd = "DateEnd";
        //private const string _DbDutyClassID = "DutyClassID";

        private const string _AccountID = "@AccountID";
        private const string _DbAccountID = "AccountID";
        private SqlConnection _Conn;
        private SqlTransaction _Trans;

        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        #region IPlanDutyDal 成员
        #region 班别
        /// <summary>
        /// 插入班别
        /// </summary>
        /// <param name="dutyClass"></param>
        /// <returns></returns>
        public int InsertDutyClass(DutyClass dutyClass)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_ParmDutyClassName, SqlDbType.NVarChar, 50).Value = dutyClass.DutyClassName;
            sqlCommand.Parameters.Add(_ParmFirstStartFromTime, SqlDbType.DateTime).Value = dutyClass.FirstStartFromTime;
            sqlCommand.Parameters.Add(_ParmFirstStartToTime, SqlDbType.DateTime).Value = dutyClass.FirstStartToTime;
            sqlCommand.Parameters.Add(_ParmFirstEndTime, SqlDbType.DateTime).Value = dutyClass.FirstEndTime;
            sqlCommand.Parameters.Add(_ParmSecondStartTime, SqlDbType.DateTime).Value = dutyClass.SecondStartTime;
            sqlCommand.Parameters.Add(_ParmSecondEndTime, SqlDbType.DateTime).Value = dutyClass.SecondEndTime;
            
            sqlCommand.Parameters.Add(_ParmAllLimitTime, SqlDbType.Decimal).Value = dutyClass.AllLimitTime;
            sqlCommand.Parameters.Add(_ParmLateTime, SqlDbType.Int).Value = dutyClass.LateTime;
            sqlCommand.Parameters.Add(_ParmEarlyLeaveTime, SqlDbType.Int).Value = dutyClass.EarlyLeaveTime;
            sqlCommand.Parameters.Add(_ParmAbsentLateTime, SqlDbType.Int).Value = dutyClass.AbsentLateTime;
            sqlCommand.Parameters.Add(_ParmAbsentEarlyLeaveTime, SqlDbType.Int).Value = dutyClass.AbsentEarlyLeaveTime;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertDutyClass", sqlCommand, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新班别
        /// </summary>
        /// <param name="dutyClass"></param>
        /// <returns></returns>
        public int UpdateDutyClass(DutyClass dutyClass)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = dutyClass.DutyClassID;
            sqlCommand.Parameters.Add(_ParmDutyClassName, SqlDbType.NVarChar, 50).Value = dutyClass.DutyClassName;
            sqlCommand.Parameters.Add(_ParmFirstStartFromTime, SqlDbType.DateTime).Value = dutyClass.FirstStartFromTime;
            sqlCommand.Parameters.Add(_ParmFirstStartToTime, SqlDbType.DateTime).Value = dutyClass.FirstStartToTime;
            sqlCommand.Parameters.Add(_ParmFirstEndTime, SqlDbType.DateTime).Value = dutyClass.FirstEndTime;
            sqlCommand.Parameters.Add(_ParmSecondStartTime, SqlDbType.DateTime).Value = dutyClass.SecondStartTime;
            sqlCommand.Parameters.Add(_ParmSecondEndTime, SqlDbType.DateTime).Value = dutyClass.SecondEndTime;
            sqlCommand.Parameters.Add(_ParmAllLimitTime, SqlDbType.Decimal).Value = dutyClass.AllLimitTime;
            sqlCommand.Parameters.Add(_ParmLateTime, SqlDbType.Int).Value = dutyClass.LateTime;
            sqlCommand.Parameters.Add(_ParmEarlyLeaveTime, SqlDbType.Int).Value = dutyClass.EarlyLeaveTime;
            sqlCommand.Parameters.Add(_ParmAbsentLateTime, SqlDbType.Int).Value = dutyClass.AbsentLateTime;
            sqlCommand.Parameters.Add(_ParmAbsentEarlyLeaveTime, SqlDbType.Int).Value = dutyClass.AbsentEarlyLeaveTime;

            return SqlHelper.ExecuteNonQuery("UpdateDutyClass", sqlCommand);
        }

        /// <summary>
        /// 删除班别
        /// </summary>
        /// <param name="attendanceId"></param>
        /// <returns></returns>
        public int DeleteDutyClass(int attendanceId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = attendanceId;
            return SqlHelper.ExecuteNonQuery("DeleteDutyClass", cmd);
        }

        /// <summary>
        /// 通过条件得到班别
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="dutyClassName"></param>
        /// <returns></returns>
        public List<DutyClass> GetDutyClassByCondition(int pkid, string dutyClassName)
        {
            List<DutyClass> dutyClasss = new List<DutyClass>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            sqlCommand.Parameters.Add(_DbDutyClassName, SqlDbType.NVarChar, 50).Value = dutyClassName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDutyClassByCondition", sqlCommand))
            {
                while (sdr.Read())
                {
                    DutyClass dutyClass = new DutyClass();
                    dutyClass.DutyClassID = Convert.ToInt32(sdr[_DbPKID]);
                    dutyClass.DutyClassName = (sdr[_DbDutyClassName]).ToString();
                    dutyClass.FirstStartFromTime = Convert.ToDateTime(sdr[_DbFirstStartFromTime]);
                    dutyClass.FirstStartToTime = Convert.ToDateTime(sdr[_DbFirstStartToTime]);
                    dutyClass.FirstEndTime = Convert.ToDateTime(sdr[_DbFirstEndTime]);
                    dutyClass.SecondStartTime = Convert.ToDateTime(sdr[_DbSecondStartTime]);
                    dutyClass.SecondEndTime = Convert.ToDateTime(sdr[_DbSecondEndTime]);
                    
                    dutyClass.AllLimitTime = Convert.ToDecimal(sdr[_DbAllLimitTime]);
                    dutyClass.LateTime = Convert.ToInt32(sdr[_DbLateTime]);
                    dutyClass.EarlyLeaveTime = Convert.ToInt32(sdr[_DbEarlyLeaveTime]);
                    dutyClass.AbsentEarlyLeaveTime = Convert.ToInt32(sdr[_DbAbsentEarlyLeaveTime]);
                    dutyClass.AbsentLateTime = Convert.ToInt32(sdr[_DbAbsentLateTime]);
                    dutyClasss.Add(dutyClass);
                }
                return dutyClasss;
            }
        }

        /// <summary>
        /// 通过pkid查找班别
        /// </summary>
        public DutyClass GetDutyClassByPkid(int pkid)
        {
            DutyClass dutyClass = null;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDutyClassByPkid", sqlCommand))
            {
                while (sdr.Read())
                {
                    dutyClass = new DutyClass();
                    dutyClass.DutyClassID = Convert.ToInt32(sdr[_DbPKID]);
                    dutyClass.DutyClassName = (sdr[_DbDutyClassName]).ToString();
                    dutyClass.FirstStartFromTime = Convert.ToDateTime(sdr[_DbFirstStartFromTime]);
                    dutyClass.FirstStartToTime = Convert.ToDateTime(sdr[_DbFirstStartToTime]);
                    dutyClass.FirstEndTime = Convert.ToDateTime(sdr[_DbFirstEndTime]);
                    dutyClass.SecondStartTime = Convert.ToDateTime(sdr[_DbSecondStartTime]);
                    dutyClass.SecondEndTime = Convert.ToDateTime(sdr[_DbSecondEndTime]);
                    dutyClass.AllLimitTime = Convert.ToDecimal(sdr[_DbAllLimitTime]);
                    dutyClass.LateTime = Convert.ToInt32(sdr[_DbLateTime]);
                    dutyClass.EarlyLeaveTime = Convert.ToInt32(sdr[_DbEarlyLeaveTime]);
                    dutyClass.AbsentEarlyLeaveTime = Convert.ToInt32(sdr[_DbAbsentEarlyLeaveTime]);
                    dutyClass.AbsentLateTime = Convert.ToInt32(sdr[_DbAbsentLateTime]);

                }
                return dutyClass;
            }
        }

        /// <summary>
        /// 得到相同名称的班别，用来判新增时的重名
        /// </summary>
        /// <param name="dutyClassName"></param>
        /// <returns></returns>
        public int CountDutyClassByDutyClassName(string dutyClassName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmDutyClassName, SqlDbType.NVarChar, 50).Value = dutyClassName;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountDutyClassByDutyClassName", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 得到不同pkid，相同名称的班别，用来判重名
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="dutyClassName"></param>
        /// <returns></returns>
        public int CountDutyClassByDutyClassDiffPkid(int pkid, string dutyClassName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmDutyClassName, SqlDbType.NVarChar, 50).Value = dutyClassName;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountDutyClassByDutyClassDiffPkid", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        #endregion

        #region 排班表
        /// <summary>
        /// 添加排班表
        /// </summary>
        /// <param name="planDutyTable"></param>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public int InsertPlanDutyTable(PlanDutyTable planDutyTable, List<Account> accounts)
        {
            InitializeTranscation();
            int pkid;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(_PlanDutyTableName, SqlDbType.NVarChar, 50).Value =
                    planDutyTable.PlanDutyTableName;
                sqlCommand.Parameters.Add(_Period, SqlDbType.Int).Value = planDutyTable.Period;
                sqlCommand.Parameters.Add(_FromTime, SqlDbType.DateTime).Value = planDutyTable.FromTime;
                sqlCommand.Parameters.Add(_ToTime, SqlDbType.DateTime).Value = planDutyTable.ToTime;
                SqlHelper.TransExecuteNonQueryReturnPKID("InsertPlanDutyTable", sqlCommand, _Conn, _Trans, out pkid);
                foreach (PlanDutyDetail planDutyDetail in planDutyTable.PlanDutyDetailList)
                {
                    InsertPlanDutyDetail(planDutyDetail, pkid, _Conn, _Trans);
                }
                foreach (Account account in accounts)
                {
                    InsertTPlanDuty(pkid, account.Id, _Conn, _Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return pkid;
        }

        /// <summary>
        /// 更新排班表
        /// </summary>
        /// <param name="planDutyTable"></param>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public int UpdatePlanDutyTable(PlanDutyTable planDutyTable, List<Account> accounts)
        {
            InitializeTranscation();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = planDutyTable.PlanDutyTableID;
                sqlCommand.Parameters.Add(_PlanDutyTableName, SqlDbType.NVarChar, 50).Value =
                    planDutyTable.PlanDutyTableName;
                sqlCommand.Parameters.Add(_Period, SqlDbType.Int).Value = planDutyTable.Period;
                sqlCommand.Parameters.Add(_FromTime, SqlDbType.DateTime).Value = planDutyTable.FromTime;
                sqlCommand.Parameters.Add(_ToTime, SqlDbType.DateTime).Value = planDutyTable.ToTime;
                SqlHelper.TransExecuteNonQuery("UpdatePlanDutyTable", sqlCommand, _Conn, _Trans);
                //删除原有的每一个项
                DeletePlanDutyDetailByPlanDutyTableID(planDutyTable.PlanDutyTableID, _Conn, _Trans);
                DeletePlanDutyByPlanDutyTableID(planDutyTable.PlanDutyTableID, _Conn, _Trans);
                foreach (PlanDutyDetail planDutyDetail in planDutyTable.PlanDutyDetailList)
                {
                    InsertPlanDutyDetail(planDutyDetail, planDutyTable.PlanDutyTableID, _Conn, _Trans);
                }

                foreach (Account account in accounts)
                {
                    InsertTPlanDuty(planDutyTable.PlanDutyTableID, account.Id, _Conn, _Trans);
                }
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return planDutyTable.PlanDutyTableID;
        }

        /// <summary>
        /// 删除排班表
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public int DeletePlanDutyTable(int pkid)
        {
            InitializeTranscation();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
                DeletePlanDutyDetailByPlanDutyTableID(pkid, _Conn, _Trans);
                DeletePlanDutyByPlanDutyTableID(pkid, _Conn, _Trans);
                SqlHelper.TransExecuteNonQuery("DeletePlanDutyTable", cmd, _Conn, _Trans);
                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }
            return pkid;
        }

        /// <summary>
        /// 查找排班表
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public PlanDutyTable GetPlanDutyTableByPkid(int pkid)
        {
            PlanDutyTable planDutyTable = null;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyTableByPkid", sqlCommand))
            {
                while (sdr.Read())
                {
                    planDutyTable = new PlanDutyTable();
                    planDutyTable.PlanDutyTableID = Convert.ToInt32(sdr[_DbPKID]);
                    planDutyTable.PlanDutyTableName = (sdr[_DbPlanDutyTableName]).ToString();
                    planDutyTable.Period = Convert.ToInt32(sdr[_DbPeriod]);
                    planDutyTable.FromTime = Convert.ToDateTime(sdr[_DbFromTime]);
                    planDutyTable.ToTime = Convert.ToDateTime(sdr[_DbToTime]);
                    planDutyTable.PlanDutyAccountList = GetPlanDutyByPlanDutyTableID(planDutyTable.PlanDutyTableID);
                    planDutyTable.PlanDutyDetailList = GetPlanDutyDetailByPlanDutyTableID(pkid);
                }
                return planDutyTable;
            }
        }

        ///// <summary>
        ///// 查找排班表
        ///// </summary>
        ///// <param name="planDutyTableName"></param>
        ///// <param name="fromTimeStart"></param>
        ///// <param name="fromTimeEnd"></param>
        ///// <param name="toTimeStart"></param>
        ///// <param name="toTimeEnd"></param>
        ///// <returns></returns>
        //public List<PlanDutyTable> GetPlanDutyTableByCondition(string planDutyTableName, DateTime fromTimeStart, DateTime fromTimeEnd, DateTime toTimeStart, DateTime toTimeEnd)
        //{
        //    List<PlanDutyTable> planDutyTables = new List<PlanDutyTable>();
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Parameters.Add(_DbPlanDutyTableName, SqlDbType.NVarChar, 50).Value = planDutyTableName;
        //    sqlCommand.Parameters.Add(_DbFromTimeStart, SqlDbType.DateTime).Value = fromTimeStart;
        //    sqlCommand.Parameters.Add(_DbFromTimeEnd, SqlDbType.DateTime).Value = fromTimeEnd;
        //    sqlCommand.Parameters.Add(_DbToTimeStart, SqlDbType.DateTime).Value = toTimeStart;
        //    sqlCommand.Parameters.Add(_DbToTimeEnd, SqlDbType.DateTime).Value = toTimeEnd;
        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyTableByCondition", sqlCommand))
        //    {
        //        while (sdr.Read())
        //        {
        //            PlanDutyTable planDutyTable = new PlanDutyTable();
        //            planDutyTable.PlanDutyTableID = Convert.ToInt32(sdr[_DbPKID]);
        //            planDutyTable.PlanDutyTableName = (sdr[_DbPlanDutyTableName]).ToString();
        //            planDutyTable.Period = Convert.ToInt32(sdr[_DbPeriod]);
        //            planDutyTable.FromTime = Convert.ToDateTime(sdr[_DbFromTime]);
        //            planDutyTable.ToTime = Convert.ToDateTime(sdr[_DbToTime]);
        //            planDutyTable.PlanDutyAccountList = GetPlanDutyByPlanDutyTableID(planDutyTable.PlanDutyTableID);
        //            planDutyTables.Add(planDutyTable);
        //        }
        //        return planDutyTables;
        //    }
        //}

        /// <summary>
        /// 查找排班表
        /// </summary>
        /// <param name="PlanDutyTableName"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        public List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName,DateTime fromTime, DateTime toTime)
        {
            List<PlanDutyTable> planDutyTables = new List<PlanDutyTable>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbPlanDutyTableName, SqlDbType.NVarChar, 50).Value = PlanDutyTableName;
            sqlCommand.Parameters.Add(_DbFromTime, SqlDbType.DateTime).Value = fromTime;
            sqlCommand.Parameters.Add(_DbToTime, SqlDbType.DateTime).Value = toTime;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyTableByCondition", sqlCommand))
            {
                while (sdr.Read())
                {
                    PlanDutyTable planDutyTable = new PlanDutyTable();
                    planDutyTable.PlanDutyTableID = Convert.ToInt32(sdr[_DbPKID]);
                    planDutyTable.PlanDutyTableName = (sdr[_DbPlanDutyTableName]).ToString();
                    planDutyTable.Period = Convert.ToInt32(sdr[_DbPeriod]);
                    planDutyTable.FromTime = Convert.ToDateTime(sdr[_DbFromTime]);
                    planDutyTable.ToTime = Convert.ToDateTime(sdr[_DbToTime]);
                    planDutyTable.PlanDutyAccountList = GetPlanDutyByPlanDutyTableID(planDutyTable.PlanDutyTableID);
                    planDutyTables.Add(planDutyTable);
                }
                return planDutyTables;
            }
        }

        /// <summary>
        /// 查找排班表员工列表
        /// </summary>
        /// <param name="planDutyTableID"></param>
        /// <returns></returns>
        private static List<Account> GetPlanDutyByPlanDutyTableID(int planDutyTableID)
        {
            List<Account> accounts = new List<Account>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbPlanDutyTableID, SqlDbType.Int).Value = planDutyTableID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyByPlanDutyTableID", sqlCommand))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountID]);
                    accounts.Add(account);
                }
                return accounts;
            }
        }
        #endregion

        #region 班别详情

        /// <summary>
        /// 插入班别详情
        /// </summary>
        /// <param name="planDutyDetail"></param>
        /// <param name="PlanDutyTableID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void InsertPlanDutyDetail(PlanDutyDetail planDutyDetail, int PlanDutyTableID, SqlConnection conn, SqlTransaction trans)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_PlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
            sqlCommand.Parameters.Add(_Date, SqlDbType.DateTime).Value = planDutyDetail.Date;
            sqlCommand.Parameters.Add(_DutyClassID, SqlDbType.Int).Value = planDutyDetail.PlanDutyClass.DutyClassID;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertPlanDutyDetail", sqlCommand, conn, trans, out pkid);
            //return pkid;
        }

        ///// <summary>
        ///// 更新班别详情
        ///// </summary>
        ///// <param name="planDutyDetail"></param>
        ///// <param name="PlanDutyTableID"></param>
        ///// <returns></returns>
        //private static void UpdatePlanDutyDetail(PlanDutyDetail planDutyDetail, int PlanDutyTableID)
        //{
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = planDutyDetail.PlanDutyDetailID;
        //    sqlCommand.Parameters.Add(_PlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
        //    sqlCommand.Parameters.Add(_Date, SqlDbType.DateTime).Value = planDutyDetail.Date;
        //    sqlCommand.Parameters.Add(_DutyClassID, SqlDbType.Int).Value = planDutyDetail.PlanDutyClass.DutyClassID;
        //    return SqlHelper.ExecuteNonQuery("UpdatePlanDutyDetail", sqlCommand);
        //}

        /// <summary>
        /// 删除班别详情
        /// </summary>
        /// <param name="PlanDutyTableID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void DeletePlanDutyDetailByPlanDutyTableID(int PlanDutyTableID, SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
            SqlHelper.TransExecuteNonQuery("DeletePlanDutyDetailByPlanDutyTableID", cmd, conn, trans);
        }

        /// <summary>
        /// 获取班别详情
        /// </summary>
        /// <param name="PlanDutyTableID"></param>
        /// <returns></returns>
        private static List<PlanDutyDetail> GetPlanDutyDetailByPlanDutyTableID(int PlanDutyTableID)
        {
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbPlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyDetailByPlanDutyTableID", sqlCommand))
            {
                while (sdr.Read())
                {
                    PlanDutyDetail planDutyDetail = new PlanDutyDetail();
                    planDutyDetail.PlanDutyDetailID = Convert.ToInt32(sdr[_DbPKID]);
                    planDutyDetail.Date = Convert.ToDateTime(sdr[_DbDate]);
                    planDutyDetail.PlanDutyClass = new DutyClass();
                    planDutyDetail.PlanDutyClass.DutyClassID = Convert.ToInt32(sdr[_DbDutyClassID]);
                    planDutyDetails.Add(planDutyDetail);
                }
                return planDutyDetails;
            }
        }

        ///// <summary>
        ///// 获取班别详情
        ///// </summary>
        ///// <param name="planDutyTableID"></param>
        ///// <param name="dateStart"></param>
        ///// <param name="dateEnd"></param>
        ///// <param name="dutyClassID"></param>
        ///// <returns></returns>
        //private List<PlanDutyDetail> GetPlanDutyDetailByCondition(int planDutyTableID, DateTime dateStart, DateTime dateEnd, int dutyClassID)
        //{
        //    List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Parameters.Add(_DbPlanDutyTableID, SqlDbType.Int).Value = planDutyTableID;
        //    sqlCommand.Parameters.Add(_DbDateStart, SqlDbType.DateTime).Value = dateStart;
        //    sqlCommand.Parameters.Add(_DbDateEnd, SqlDbType.DateTime).Value = dateEnd;
        //    sqlCommand.Parameters.Add(_DbDutyClassID, SqlDbType.Int).Value = dutyClassID;
        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyDetailByCondition", sqlCommand))
        //    {
        //        while (sdr.Read())
        //        {
        //            PlanDutyDetail planDutyDetail = new PlanDutyDetail();
        //            planDutyDetail.PlanDutyDetailID = Convert.ToInt32(sdr[_DbPKID]);
        //            planDutyDetail.Date = Convert.ToDateTime(sdr[_DbDate]);

        //            planDutyDetails.Add(planDutyDetail);
        //        }
        //        return planDutyDetails;
        //    }
        //}

        #endregion

        #region 班别绑定

        /// <summary>
        /// 添加班别绑定
        /// </summary>
        /// <param name="PlanDutyTableID"></param>
        /// <param name="AccountID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void InsertTPlanDuty(int PlanDutyTableID, int AccountID, SqlConnection conn, SqlTransaction trans)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_PlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
            sqlCommand.Parameters.Add(_AccountID, SqlDbType.Int).Value = AccountID;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertTPlanDuty", sqlCommand, conn, trans, out pkid);
        }

        /// <summary>
        /// 删除班别绑定
        /// </summary>
        /// <param name="PlanDutyTableID"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        private static void DeletePlanDutyByPlanDutyTableID(int PlanDutyTableID, SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PlanDutyTableID, SqlDbType.Int).Value = PlanDutyTableID;
            SqlHelper.TransExecuteNonQuery("DeletePlanDutyByPlanDutyTableID", cmd, conn, trans);
        }

        /// <summary>
        /// 删除班别绑定
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public int DeletePlanDutyByAccountID(int AccountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = AccountID;
            return SqlHelper.ExecuteNonQuery("DeletePlanDutyByAccountID", cmd);
        }

        /// <summary>
        /// 查找班别绑定
        /// </summary>
        /// <param name="planDutyTableName"></param>
        /// <param name="fromTimeStart"></param>
        /// <param name="fromTimeEnd"></param>
        /// <param name="toTimeStart"></param>
        /// <param name="toTimeEnd"></param>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public List<PlanDutyTable> GetPlanDutyByCondition(string planDutyTableName, DateTime fromTimeStart, DateTime fromTimeEnd, DateTime toTimeStart, DateTime toTimeEnd, int AccountID)
        {
            List<PlanDutyTable> planDutyTables = new List<PlanDutyTable>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbPlanDutyTableName, SqlDbType.NVarChar, 50).Value = planDutyTableName;
            sqlCommand.Parameters.Add(_DbFromTimeStart, SqlDbType.DateTime).Value = fromTimeStart;
            sqlCommand.Parameters.Add(_DbFromTimeEnd, SqlDbType.DateTime).Value = fromTimeEnd;
            sqlCommand.Parameters.Add(_DbToTimeStart, SqlDbType.DateTime).Value = toTimeStart;
            sqlCommand.Parameters.Add(_DbToTimeEnd, SqlDbType.DateTime).Value = toTimeEnd;
            sqlCommand.Parameters.Add(_DbAccountID, SqlDbType.Int).Value = AccountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyByCondition", sqlCommand))
            {
                while (sdr.Read())
                {
                    PlanDutyTable planDutyTable = new PlanDutyTable();
                    planDutyTable.PlanDutyTableID = Convert.ToInt32(sdr[_DbPKID]);
                    planDutyTable.PlanDutyTableName = (sdr[_DbPlanDutyTableName]).ToString();
                    planDutyTable.Period = Convert.ToInt32(sdr[_DbPeriod]);
                    planDutyTable.FromTime = Convert.ToDateTime(sdr[_DbFromTime]);
                    planDutyTable.ToTime = Convert.ToDateTime(sdr[_DbToTime]);
                    planDutyTables.Add(planDutyTable);
                }
                return planDutyTables;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="accountid"></param>
        /// <returns></returns>
        public List<PlanDutyTable> GetPlanDutyTableByConditionAndAccountID(DateTime fromTime, DateTime toTime, int accountid)
        {
            List<PlanDutyTable> planDutyTables = new List<PlanDutyTable>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbFromTime, SqlDbType.DateTime).Value = fromTime;
            sqlCommand.Parameters.Add(_DbToTime, SqlDbType.DateTime).Value = toTime;
            sqlCommand.Parameters.Add(_DbAccountID, SqlDbType.Int).Value = accountid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyTableByConditionAndAccountID", sqlCommand))
            {
                while (sdr.Read())
                {
                    PlanDutyTable planDutyTable = new PlanDutyTable();
                    planDutyTable.PlanDutyTableID = Convert.ToInt32(sdr[_DbPKID]);
                    planDutyTable.PlanDutyTableName = (sdr[_DbPlanDutyTableName]).ToString();
                    planDutyTable.Period = Convert.ToInt32(sdr[_DbPeriod]);
                    planDutyTable.FromTime = Convert.ToDateTime(sdr[_DbFromTime]);
                    planDutyTable.ToTime = Convert.ToDateTime(sdr[_DbToTime]);
                    planDutyTable.PlanDutyAccountList = GetPlanDutyByPlanDutyTableID(planDutyTable.PlanDutyTableID);
                    planDutyTables.Add(planDutyTable);
                }
                return planDutyTables;
            }
        }

        #endregion
        #endregion

        #region IPlanDutyDal 成员

        /// <summary>
        /// 得到相同名称的班别，用来判新增时的重名
        /// </summary>
        /// <param name="planDutyTableName"></param>
        /// <returns></returns>
        public int CountPlanDutyTableByPlanDutyTableName(string planDutyTableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PlanDutyTableName, SqlDbType.NVarChar, 50).Value = planDutyTableName;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountPlanDutyTableByPlanDutyTableName", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 得到不同pkid，相同名称的班别，用来判重名
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="planDutyTableName"></param>
        /// <returns></returns>
        public int CountPlanDutyByPlanDutyDiffPkid(int pkid, string planDutyTableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PlanDutyTableName, SqlDbType.NVarChar, 50).Value = planDutyTableName;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountPlanDutyByPlanDutyDiffPkid", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        #endregion

        #region IPlanDutyDal 成员


        public List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbAccountID, SqlDbType.Int).Value = AccountID;
            sqlCommand.Parameters.Add(_DbFromTime, SqlDbType.DateTime).Value = dateStart;
            sqlCommand.Parameters.Add(_DbToTime, SqlDbType.DateTime).Value = dateEnd;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyDetailByAccount", sqlCommand))
            {
                while (sdr.Read())
                {
                    PlanDutyDetail planDutyDetail = new PlanDutyDetail();
                    planDutyDetail.PlanDutyClass = new DutyClass();
                    planDutyDetail.PlanDutyClass.DutyClassID = Convert.ToInt32(sdr[_DbPKID]);
                    if (planDutyDetail.PlanDutyClass.DutyClassID!= -1)
                    {
                        planDutyDetail.PlanDutyClass.DutyClassName = (sdr[_DbDutyClassName]).ToString();
                        planDutyDetail.PlanDutyClass.FirstStartFromTime = Convert.ToDateTime(sdr[_DbFirstStartFromTime]);
                        planDutyDetail.PlanDutyClass.FirstStartToTime = Convert.ToDateTime(sdr[_DbFirstStartToTime]);
                        planDutyDetail.PlanDutyClass.FirstEndTime = Convert.ToDateTime(sdr[_DbFirstEndTime]);
                        planDutyDetail.PlanDutyClass.SecondStartTime = Convert.ToDateTime(sdr[_DbSecondStartTime]);
                        planDutyDetail.PlanDutyClass.SecondEndTime = Convert.ToDateTime(sdr[_DbSecondEndTime]);
                        planDutyDetail.PlanDutyClass.AllLimitTime = Convert.ToDecimal(sdr[_DbAllLimitTime]);
                        planDutyDetail.PlanDutyClass.LateTime = Convert.ToInt32(sdr[_DbLateTime]);
                        planDutyDetail.PlanDutyClass.EarlyLeaveTime = Convert.ToInt32(sdr[_DbEarlyLeaveTime]);
                        planDutyDetail.PlanDutyClass.AbsentEarlyLeaveTime = Convert.ToInt32(sdr[_DbAbsentEarlyLeaveTime]);
                        planDutyDetail.PlanDutyClass.AbsentLateTime = Convert.ToInt32(sdr[_DbAbsentLateTime]);
                        planDutyDetail.Date = Convert.ToDateTime(sdr[_DbDate]);
                    }
                    else
                    {
                        planDutyDetail.PlanDutyClass.DutyClassName = "休息";
                        planDutyDetail.Date = Convert.ToDateTime(sdr[_DbDate]);
                    }
                    planDutyDetails.Add(planDutyDetail);
                }
                return planDutyDetails;
            }
        }

        #endregion

        #region IPlanDutyDal 成员


        ///<summary>
        ///</summary>
        ///<param name="AccountID"></param>
        ///<param name="dateStart"></param>
        ///<param name="dateEnd"></param>
        ///<returns></returns>
        public int GetPlanDutyDetailByAccountID(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            int count = 0;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbAccountID, SqlDbType.Int).Value = AccountID;
            sqlCommand.Parameters.Add(_DbFromTime, SqlDbType.DateTime).Value = dateStart;
            sqlCommand.Parameters.Add(_DbToTime, SqlDbType.DateTime).Value = dateEnd;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyDetailByAccountID", sqlCommand))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DbCounts]);
                }
                return count;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="PlanDutyID"></param>
        ///<param name="AccountID"></param>
        ///<param name="dateStart"></param>
        ///<param name="dateEnd"></param>
        ///<returns></returns>
        public int GetPlanDutyDetailByAccountIDAndPlanDutyID(int PlanDutyID, int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            int count = 0;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_DbPlanDutyTableID, SqlDbType.Int).Value = PlanDutyID;
            sqlCommand.Parameters.Add(_DbAccountID, SqlDbType.Int).Value = AccountID;
            sqlCommand.Parameters.Add(_DbFromTime, SqlDbType.DateTime).Value = dateStart;
            sqlCommand.Parameters.Add(_DbToTime, SqlDbType.DateTime).Value = dateEnd;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPlanDutyDetailByAccountIDAndPlanDutyID", sqlCommand))
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr[_DbCounts]);
                }
                return count;
            }
        }

        #endregion
    }
}
