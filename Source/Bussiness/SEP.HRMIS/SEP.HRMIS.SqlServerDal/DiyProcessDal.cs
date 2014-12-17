using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class DiyProcessDal : IDiyProcessDal
    {
        #region 自由变量

        private const string _PKID = "@PKID";
        private const string _Name = "@Name";
        private const string _Type = "@Type";
        private const string _Remark = "@Remark";
        private const string _DiyProcessID = "@DiyProcessID";
        private const string _Status = "@Status";
        private const string _OperatorType = "@OperatorType";
        private const string _OperatorID = "@OperatorID";
        private const string _MailAccount = "@MailAccount";

        private const string _DBPKID = "PKID";
        private const string _DBType = "Type";
        private const string _DBName = "Name";
        private const string _DBStatus = "Status";
        private const string _DBRemark = "Remark";
        private const string _DBOperatorID = "OperatorID";
        private const string _DBOperatorType = "OperatorType";
        private const string _DBMailAccount = "MailAccount";
        private const string _DBCount = "counts";
       
        #endregion

        /// <summary>
        /// 新增自定义流程
        /// </summary>
        /// <param name="diyProcess"></param>
        /// <returns></returns>
        public int InsertDiyProcess(DiyProcess diyProcess)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int pkid;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = diyProcess.Name;
                cmd.Parameters.Add(_Type, SqlDbType.Int).Value = diyProcess.Type.Id;
                cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = diyProcess.Remark;
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertDiyProcess", cmd, out pkid);
                //循环新增每一个项
                for (int i = 0; i < diyProcess.DiySteps.Count; i++)
                {
                    InsertDiySteps(pkid, diyProcess.DiySteps[i], _Conn, _Trans);
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
        /// 新增自定义步骤
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <param name="diyStep"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        private static void InsertDiySteps(int diyProcessID, DiyStep diyStep, SqlConnection conn,
                                                   SqlTransaction trans)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcessID;
            cmd.Parameters.Add(_Status, SqlDbType.NVarChar, 50).Value = diyStep.Status;
            cmd.Parameters.Add(_OperatorType, SqlDbType.Int).Value = diyStep.OperatorType.Id;
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = diyStep.OperatorID;
            string mailAccount = "";
            foreach (Account account in diyStep.MailAccount)
            {
                mailAccount += account.Id + "|";
            }
            cmd.Parameters.Add(_MailAccount, SqlDbType.NVarChar, 255).Value = mailAccount;
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertDiySteps", cmd, conn, trans, out pkid);
        }

        /// <summary>
        /// 新增自定义流程
        /// </summary>
        /// <param name="diyProcess"></param>
        /// <returns></returns>
        public int UpdateDiyProcess(DiyProcess diyProcess)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int pkid;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = diyProcess.Name;
                cmd.Parameters.Add(_Type, SqlDbType.Int).Value = diyProcess.Type.Id;
                cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = diyProcess.Remark;
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = diyProcess.ID;
                SqlHelper.ExecuteNonQueryReturnPKID("UpdateDiyProcess", cmd, out pkid);

                cmd = new SqlCommand();
                cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcess.ID;
                SqlHelper.ExecuteNonQuery("DeleteDiyStepByProcessID", cmd);

                //循环新增每一个项
                for (int i = 0; i < diyProcess.DiySteps.Count; i++)
                {
                    InsertDiySteps(pkid, diyProcess.DiySteps[i], _Conn, _Trans);
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
        /// 删除自定义流程
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        public int DeleteDiyProcess(int diyProcessID)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int iRet;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = diyProcessID;
                iRet = SqlHelper.ExecuteNonQuery("DiyProcessDelete", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcessID;
                SqlHelper.ExecuteNonQuery("DeleteDiyStepByProcessID", cmd);
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
            return iRet;
        }

        /// <summary>
        /// 根据自定义流程
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        public DiyProcess GetDiyProcessByPKID(int diyProcessID)
        {
            DiyProcess diyProcess = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = diyProcessID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDiyProcessByPKID", cmd))
            {
                while (sdr.Read())
                {
                    diyProcess =
                        new DiyProcess((int) sdr[_DBPKID], sdr[_DBName].ToString(), sdr[_DBRemark].ToString(),
                                       new ProcessType((int) sdr[_DBType],
                                                       ProcessType.FindProcessTypeByID((int) sdr[_DBType])));
                }
            }
            if(diyProcess!=null)
            {
                diyProcess.DiySteps = GetDiyStepsByDiyProcessID(diyProcessID);
            }
            return diyProcess;
        }

        ///<summary>
        /// 根据自定义流程类型获取自定义流程
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<returns></returns>
        public List<DiyProcess> GetDiyProcessByProcessType(int processTypeId)
        {
            List<DiyProcess> diyProcesses = new List<DiyProcess>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = processTypeId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDiyProcessByProcessType", cmd))
            {
                while (sdr.Read())
                {
                    DiyProcess diyProcess =
                        new DiyProcess((int) sdr[_DBPKID], sdr[_DBName].ToString(), sdr[_DBRemark].ToString(),
                                       new ProcessType((int) sdr[_DBType],
                                                       ProcessType.FindProcessTypeByID((int) sdr[_DBType])));
                    diyProcesses.Add(diyProcess);
                }
            }

            return diyProcesses;
        }

        /// <summary>
        /// 通过帐号ID查找相关的帐套项
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        private static List<DiyStep> GetDiyStepsByDiyProcessID(int diyProcessID)
        {
            List<DiyStep> diySteps = new List<DiyStep>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcessID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDiyStepByDiyProcessID", cmd))
            {
                while (sdr.Read())
                {
                    DiyStep diyStep =
                        new DiyStep((int)sdr[_DBPKID], sdr[_DBStatus].ToString(),
                                    new OperatorType((int)sdr[_DBOperatorType], OperatorType.FindOperatorTypeByID((int)sdr[_DBOperatorType])),
                                    (int) sdr[_DBOperatorID]);
                    string[] mailAccount = sdr[_DBMailAccount].ToString().Split('|');
                    foreach(string accountId in mailAccount)
                    {
                        int id;
                        if(int.TryParse(accountId, out id))
                        {
                            diyStep.MailAccount.Add(new Account(Convert.ToInt32(accountId), string.Empty, string.Empty));
                        }
                    }
                    diySteps.Add(diyStep);
                }
            }
            return diySteps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountDiyProcessByName(string name)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountDiyProcessByName", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountDiyProcessByNameDiffPKID(int id,string name)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = id;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountDiyProcessByNameDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 将DiyProcess对象转化为字符串
        /// </summary>
        public static string ConvertToString(DiyProcess process)
        {
            string strProcess = String.Empty;

            if (process == null || process.DiySteps == null || process.DiySteps.Count == 0)
                return strProcess;

            foreach (DiyStep step in process.DiySteps)
            {
                strProcess += 
                    step.DiyStepID + "|" + 
                    step.Status + "|" + 
                    step.OperatorType.Id + "|" + 
                    step.OperatorID + "|";

                foreach (Account account in step.MailAccount)
                {
                    strProcess += account.Id + ",";
                }

                strProcess += ";";
            }
            if (strProcess.Length > 0)
            {
                strProcess = strProcess.Substring(0, strProcess.Length - 1);
            }

            return strProcess;
        }



        ///<summary>
        /// 根据自定义流程类型获取自定义流程
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<param name="name"></param>
        ///<returns></returns>
        public List<DiyProcess> GetDiyProcessByCondition(int processTypeId, string name)
        {
            List<DiyProcess> diyProcesses = new List<DiyProcess>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = processTypeId;
            cmd.Parameters.Add(_Name, SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDiyProcessByCondition", cmd))
            {
                while (sdr.Read())
                {
                    DiyProcess diyProcess =
                        new DiyProcess((int)sdr[_DBPKID], sdr[_DBName].ToString(), sdr[_DBRemark].ToString(),
                                       new ProcessType((int)sdr[_DBType],
                                                       ProcessType.FindProcessTypeByID((int)sdr[_DBType])));
                    diyProcesses.Add(diyProcess);
                }
            }

            return diyProcesses;
        }

        /// <summary>
        /// 将字符串转化为DiyProcess对象
        /// </summary>
        public static DiyProcess ConvertToObject(string strProcess)
        {
            DiyProcess process = new DiyProcess();
            List<DiyStep> diyStepList = new List<DiyStep>();
            string[] diySteps = strProcess.Split(';');
            foreach (string diyStep in diySteps)
            {
                string[] steps = diyStep.Split('|');
                if (steps.Length > 4)
                {
                    DiyStep step =
                        new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                    new OperatorType(Convert.ToInt32(steps[2]),
                                                     OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                    Convert.ToInt32(steps[3]));

                    string[] mailAccounts = steps[4].Split(',');
                    foreach (string mailAccount in mailAccounts)
                    {
                        if (!string.IsNullOrEmpty(mailAccount))
                        {
                            step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                        }
                    }

                    diyStepList.Add(step);
                }
            }

            process.DiySteps = diyStepList;
            return process;
        }
    }
}
