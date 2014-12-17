using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class PositionApplicationDal : IPositionApplicationDal
    {
        public int InsertPositionApplication(PositionApplication positionApplication)
        {
            int iRet;
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                SqlCommand cmd = new SqlCommand();
                AddInsertParameters(cmd, positionApplication);
                cmd.Parameters.AddWithValue("@PKID", 0);
                cmd.Parameters["@PKID"].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("AddPositionApplication", cmd, out iRet);

                //循环修改每一个项
                for (int i = 0; i < positionApplication.Position.Nature.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdNature = new SqlCommand();
                    cmdNature.Parameters.AddWithValue("@PositionAppID", iRet);
                    cmdNature.Parameters.AddWithValue("@PositionNatureID", positionApplication.Position.Nature[i].Pkid);
                    cmdNature.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationNature", cmdNature, _Conn, _Trans, out pkid);
                }

                for (int i = 0; i < positionApplication.Position.Departments.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdDepartments = new SqlCommand();
                    cmdDepartments.Parameters.AddWithValue("@PositionAppID", iRet);
                    cmdDepartments.Parameters.AddWithValue("@DeptID", positionApplication.Position.Departments[i].Id);
                    cmdDepartments.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationDepartment", cmdDepartments, _Conn, _Trans, out pkid);
                }

                for (int i = 0; i < positionApplication.Position.Members.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdMembers = new SqlCommand();
                    cmdMembers.Parameters.AddWithValue("@PositionAppID", iRet);
                    cmdMembers.Parameters.AddWithValue("@AccountID", positionApplication.Position.Members[i].Id);
                    cmdMembers.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationMember", cmdMembers, _Conn, _Trans, out pkid);
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

            return iRet;
        }

        private static void AddInsertParameters(SqlCommand cm, PositionApplication positionApplication)
        {
            cm.Parameters.AddWithValue("@Applicant", positionApplication.Account.Id);
            cm.Parameters.AddWithValue("@IsPublish", positionApplication.IsPublish);
            cm.Parameters.AddWithValue("@Type", positionApplication.Type.Id);
            cm.Parameters.AddWithValue("@Status", positionApplication.Status.Id);
            cm.Parameters.AddWithValue("@NextStep", positionApplication.NextStep.DiyStepID);
            cm.Parameters.AddWithValue("@DiyProcess", DiyProcess.ConvertToString(positionApplication.DiyProcess));
            cm.Parameters.AddWithValue("@PositionID", positionApplication.Position.Id);
            cm.Parameters.AddWithValue("@PositionName", positionApplication.Position.Name);
            cm.Parameters.AddWithValue("@PositionDescription", positionApplication.Position.Description);
            cm.Parameters.AddWithValue("@LevelId", positionApplication.Position.Grade.Id);
            cm.Parameters.AddWithValue("@Summary", positionApplication.Position.Summary);
            cm.Parameters.AddWithValue("@MainDuties", positionApplication.Position.MainDuties);
            cm.Parameters.AddWithValue("@ReportScope", positionApplication.Position.ReportScope);
            cm.Parameters.AddWithValue("@ControlScope", positionApplication.Position.ControlScope);
            cm.Parameters.AddWithValue("@Coordination", positionApplication.Position.Coordination);
            cm.Parameters.AddWithValue("@Authority", positionApplication.Position.Authority);
            cm.Parameters.AddWithValue("@Education", positionApplication.Position.Education);
            cm.Parameters.AddWithValue("@ProfessionalBackground", positionApplication.Position.ProfessionalBackground);
            cm.Parameters.AddWithValue("@WorkExperience", positionApplication.Position.WorkExperience);
            cm.Parameters.AddWithValue("@Qualification", positionApplication.Position.Qualification);
            cm.Parameters.AddWithValue("@Competence", positionApplication.Position.Competence);
            cm.Parameters.AddWithValue("@OtherRequirements", positionApplication.Position.OtherRequirements);
            cm.Parameters.AddWithValue("@KnowledgeAndSkills", positionApplication.Position.KnowledgeAndSkills);
            cm.Parameters.AddWithValue("@RelatedProcesses", positionApplication.Position.RelatedProcesses);
            cm.Parameters.AddWithValue("@ManagementSkills", positionApplication.Position.ManagementSkills);
            cm.Parameters.AddWithValue("@AuxiliarySkills", positionApplication.Position.AuxiliarySkills);
        }

        public void UpdatePositionApplication(PositionApplication positionApplication)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("PositionApplicationID", SqlDbType.Int).Value = positionApplication.PKID;
                SqlHelper.ExecuteNonQuery("DeletePositionApplicationDepartmentByPositionApplicationID", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add("PositionApplicationID", SqlDbType.Int).Value = positionApplication.PKID;
                SqlHelper.ExecuteNonQuery("DeletePositionApplicationNatureByPositionApplicationID", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add("PositionApplicationID", SqlDbType.Int).Value = positionApplication.PKID;
                SqlHelper.ExecuteNonQuery("DeletePositionApplicationMemberByPositionApplicationID", cmd);

                cmd = new SqlCommand();
                AddInsertParameters(cmd, positionApplication);
                cmd.Parameters.AddWithValue("@PKID", positionApplication.PKID);
                SqlHelper.ExecuteNonQuery("UpdatePositionApplication", cmd);

                //循环修改每一个项
                for (int i = 0; i < positionApplication.Position.Nature.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdNature = new SqlCommand();
                    cmdNature.Parameters.AddWithValue("@PositionAppID", positionApplication.PKID);
                    cmdNature.Parameters.AddWithValue("@PositionNatureID", positionApplication.Position.Nature[i].Pkid);
                    cmdNature.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationNature", cmdNature, _Conn, _Trans, out pkid);
                }

                for (int i = 0; i < positionApplication.Position.Departments.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdDepartments = new SqlCommand();
                    cmdDepartments.Parameters.AddWithValue("@PositionAppID", positionApplication.PKID);
                    cmdDepartments.Parameters.AddWithValue("@DeptID", positionApplication.Position.Departments[i].Id);
                    cmdDepartments.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationDepartment", cmdDepartments, _Conn, _Trans, out pkid);
                }

                for (int i = 0; i < positionApplication.Position.Members.Count; i++)
                {
                    int pkid;
                    SqlCommand cmdMembers = new SqlCommand();
                    cmdMembers.Parameters.AddWithValue("@PositionAppID", positionApplication.PKID);
                    cmdMembers.Parameters.AddWithValue("@AccountID", positionApplication.Position.Members[i].Id);
                    cmdMembers.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    SqlHelper.TransExecuteNonQueryReturnPKID("InsertPositionApplicationMember", cmdMembers, _Conn, _Trans, out pkid);
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
        }

        public void DeletePositionApplication(int positionApplicationID)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("@PKID", SqlDbType.Int).Value = positionApplicationID;
                SqlHelper.ExecuteNonQuery("DeletePositionApplication", cmd);
                //SqlHelper.ExecuteNonQuery("DeletePositionApplicationDepartmentByPositionApplicationID", cmd);
                //SqlHelper.ExecuteNonQuery("DeletePositionApplicationNatureByPositionApplicationID", cmd);
                //SqlHelper.ExecuteNonQuery("DeletePositionApplicationMemberByPositionApplicationID", cmd);
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
        }

        public int InsertPositionApplicationFlow(PositionApplicationFlow flow)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PositionAppID", flow.PositionApplicationID);
            cmd.Parameters.AddWithValue("@OperatorID", flow.Account.Id);
            cmd.Parameters.AddWithValue("@Operation", flow.Status.Id);
            cmd.Parameters.AddWithValue("@OperationTime", flow.OperationTime);
            cmd.Parameters.AddWithValue("@Remark", flow.Remark);
            PositionApplication pa =new PositionApplication();
            if (flow.Detail != null && flow.Detail.Position != null)
            {
                pa.Position = flow.Detail.Position;
            }
            cmd.Parameters.AddWithValue("@Detail", EncryptFlowDetail(pa));
            cmd.Parameters.Add("@PKID", SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertPositionApplicationFlow", cmd, out pkid);
            return pkid;
        }
        private static byte[] EncryptFlowDetail(PositionApplication pa)
        {
            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, pa);
            byte[] bt = ms.ToArray();
            ms.Close();

            return bt;
        }

        private static PositionApplication DecryptFlowDetail(object sdrdetail)
        {
            byte[] byteDetail = sdrdetail as byte[];
            if (byteDetail == null)
            {
                return null;
            }

            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(byteDetail);
            return formatter.Deserialize(ms) as PositionApplication;
        }

        public void UpdatePositionApplicationStatusByPositionApplicationID(int positionApplicationID, RequestStatus status, int nextStepID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@PKID", positionApplicationID);
            cmd.Parameters.AddWithValue("@Status", status.Id);
            cmd.Parameters.AddWithValue("@NextStep", nextStepID);
            SqlHelper.ExecuteNonQuery("UpdatePositionApplicationStatusByPositionApplicationID", cmd);
        }

        public PositionApplication GetPositionApplicationByPKID(int PositionApplicationID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@PKID", SqlDbType.Int).Value = PositionApplicationID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplication", cmd))
            {
                while (sdr.Read())
                {
                    PositionApplication positionApplication = FetchObject(sdr);
                    if (positionApplication.DiyProcess != null)
                    {
                        positionApplication.CurrentStep =
                            positionApplication.DiyProcess.FindStep(positionApplication.NextStep.DiyStepID);
                    }
                    FetchChildren(sdr, positionApplication);
                    positionApplication.PositionApplicationFlowList =
                        GetPositionApplicationFlowByPositionApplicationID(PositionApplicationID);
                    return positionApplication;
                }
                return null;
            }
        }

        private static PositionApplication FetchObject(IDataRecord sdr)
        {
            PositionApplication positionApplication = new PositionApplication();
            positionApplication.PKID = (int)sdr["PKID"];
            positionApplication.Account = new Account((int)sdr["Applicant"], "", "");
            positionApplication.IsPublish = (int)sdr["IsPublish"];
            positionApplication.Type = AppType.FindAppType((int)sdr["Type"]);
            positionApplication.Status = RequestStatus.FindRequestStatus((int)sdr["Status"]);
            positionApplication.NextStep = new DiyStep((int)sdr["NextStep"]);
            positionApplication.DiyProcess = DiyProcess.ConvertToObject(sdr["DiyProcess"].ToString());
            positionApplication.Position = new Position((int)sdr["PositionID"], sdr["PositionName"].ToString(),
                                                        new PositionGrade((int)sdr["LevelId"], "", ""));
            positionApplication.Position.Description = sdr["PositionDescription"].ToString();
            positionApplication.Position.Summary = sdr["Summary"].ToString();
            positionApplication.Position.MainDuties = sdr["MainDuties"].ToString();
            positionApplication.Position.ReportScope = sdr["ReportScope"].ToString();
            positionApplication.Position.ControlScope = sdr["ControlScope"].ToString();
            positionApplication.Position.Coordination = sdr["Coordination"].ToString();
            positionApplication.Position.Authority = sdr["Authority"].ToString();
            positionApplication.Position.Education = sdr["Education"].ToString();
            positionApplication.Position.ProfessionalBackground = sdr["ProfessionalBackground"].ToString();
            positionApplication.Position.WorkExperience = sdr["WorkExperience"].ToString();
            positionApplication.Position.Qualification = sdr["Qualification"].ToString();
            positionApplication.Position.Competence = sdr["Competence"].ToString();
            positionApplication.Position.OtherRequirements = sdr["OtherRequirements"].ToString();
            positionApplication.Position.KnowledgeAndSkills = sdr["KnowledgeAndSkills"].ToString();
            positionApplication.Position.RelatedProcesses = sdr["RelatedProcesses"].ToString();
            positionApplication.Position.ManagementSkills = sdr["ManagementSkills"].ToString();
            positionApplication.Position.AuxiliarySkills = sdr["AuxiliarySkills"].ToString();
            return positionApplication;
        }

        private static void FetchChildren(IDataReader sdr, PositionApplication positionApplication)
        {
            sdr.NextResult();
            positionApplication.Position.Nature = new List<PositionNature>();
            while (sdr.Read())
            {
                PositionNature positionNature = new PositionNature();
                positionNature.Pkid = (int)sdr["PositionNatureID"];
                positionApplication.Position.Nature.Add(positionNature);
            }

            sdr.NextResult();
            positionApplication.Position.Departments = new List<Department>();
            while (sdr.Read())
            {
                positionApplication.Position.Departments.Add(new Department((int)sdr["DeptID"], ""));
            }

            sdr.NextResult();
            positionApplication.Position.Members = new List<Account>();
            while (sdr.Read())
            {
                positionApplication.Position.Members.Add(new Account((int)sdr["AccountID"], "", ""));
            }
        }

        public List<PositionApplication> GetPositionApplicationByAccountID(int accountID)
        {
            List<PositionApplication> iRet = new List<PositionApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@Applicant", SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    iRet.Add(FetchObject(sdr));
                }
            }
            return iRet;
        }

        public List<PositionApplication> GetConfirmPositionApplication()
        {
            List<PositionApplication> iRet = new List<PositionApplication>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetConfirmPositionApplication", cmd))
            {
                while (sdr.Read())
                {
                    PositionApplication positionApplication = FetchObject(sdr);
                    if (positionApplication.DiyProcess != null)
                    {
                        positionApplication.CurrentStep =
                            positionApplication.DiyProcess.FindStep(positionApplication.NextStep.DiyStepID);
                    }
                    iRet.Add(positionApplication);
                }
            }
            return iRet;
        }

        public List<PositionApplication> GetPositionApplicationConfirmHistoryByOperatorID(int operatorID)
        {
            List<PositionApplication> iRet = new List<PositionApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@OperatorID", SqlDbType.Int).Value = operatorID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationConfirmHistoryByOperatorID", cmd))
            {
                while (sdr.Read())
                {
                    iRet.Add(FetchObject(sdr));
                }
            }
            return iRet;
        }

        public List<PositionApplicationFlow> GetPositionApplicationFlowByPositionApplicationID(int positionApplicationID)
        {
            List<PositionApplicationFlow> iRet = new List<PositionApplicationFlow>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@PositionApplicationID", SqlDbType.Int).Value = positionApplicationID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationFlowByPositionApplicationID", cmd))
            {
                while (sdr.Read())
                {
                    iRet.Add(new PositionApplicationFlow((int) sdr["PKID"], (int) sdr["PositionAppID"],
                                                         new Account((int) sdr["OperatorID"], "", ""),
                                                         (DateTime) sdr["OperationTime"],
                                                         RequestStatus.FindRequestStatus((int) sdr["Operation"]),
                                                         sdr["Remark"].ToString(), DecryptFlowDetail(sdr["Detail"])));
                }
            }
            return iRet;
        }

        public int SetIsPublishApplication(int id, int publish)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@PKID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@IsPublish", SqlDbType.Int).Value = publish;
            return SqlHelper.ExecuteNonQuery("SetIsPublishApplication", cmd);
        }

        public List<PositionApplication> GetPositionApplicationByCondition(string name, int isPublish, int status)
        {
            List<PositionApplication> iRet = new List<PositionApplication>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@IsPublish", isPublish);
            switch(status)
            {
                case 0://进行中
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationByConditionIng", cmd))
                    {
                        while (sdr.Read())
                        {
                            iRet.Add(FetchObject(sdr));
                        }
                    }
                    break;
                case 1://审核通过
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationByConditionPass", cmd))
                    {
                        while (sdr.Read())
                        {
                            iRet.Add(FetchObject(sdr));
                        }
                    }
                    break;
                case 2://审核不通过
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationByConditionFail", cmd))
                    {
                        while (sdr.Read())
                        {
                            iRet.Add(FetchObject(sdr));
                        }
                    }
                    break;
                case -1://全部
                    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetPositionApplicationByCondition", cmd))
                    {
                        while (sdr.Read())
                        {
                            iRet.Add(FetchObject(sdr));
                        }
                    }
                    break;
            }
            return iRet;
        }
    }
}