using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using SEP.HRMIS.IDal;
using System.Data;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationDal : ITraineeApplication
    {

        #region    parameter
        //course
        private const string _PKID = "@PKID";
        private const string _CourseName = "@CourseName";
        private const string _ApplicationId = "@ApplicationId";
        private const string _StratTime = "@StratTime";
        private const string _EndTime= "@EndTime";
        private const string _Skills = "@Skills";
        private const string _TrainOrgnatiaon = "@TrainOrgnatiaon";
        private const string _TrainHour = "@TrainHour";
        private const string _TrainCost = "@TrainCost";
        private const string _TrainType = "@TrainType";
        private const string _HasCertification = "@HasCertification";
        private const string _TrianPlace = "@TrianPlace";
        private const string _Trainer = "@Trainer";
        private const string _NextStepIndex = "@NextStepIndex";
        private const string _ApplicationStatus = "@ApplicationStatus";
        private const string _DiyProcess = "@DiyProcess";
        private const string _EduSpuCost = "@EduSpuCost";

        //CourseTrainee
        private const string _TrainAppID = "@TrainAppID";
        private const string _TraineeID = "@TraineeID";

        private const string _DbError = "数据库访问错误!";      
        private const string _OperatorID = "@OperatorID";
        private const string _OperationTime = "@OperationTime";
        private const string _Operation = "@Operation";
        private const string _Remark = "@Remark";
        #endregion

        #region  DB
        //course
        private const string _DBPKID = "PKID";
        private const string _DBCourseName = "CourseName";
        private const string _DBApplicationId = "ApplicationId";
        private const string _DBStratTime = "StratTime";
        private const string _DBEndTime = "EndTime";
        private const string _DBSkills = "Skills";
        private const string _DBTrainOrgnatiaon = "TrainOrgnatiaon";
        private const string _DBTrianPlace = "TrianPlace";
        private const string _DBTrainHour = "TrainHour";
        private const string _DBTrainCost = "TrainCost";
        private const string _DBTrainer = "Trainer";
        private const string _DBTrainType = "TrainType";
        private const string _DBNextStepIndex = "NextStepIndex";
        private const string _DBApplicationStatus = "ApplicationStatus";

        private const string _DBHasCertification = "HasCertification";

        private const string _DBTraineeID = "TraineeID";
        private const string _DbDiyProcess = "DiyProcess";
        private const string _DbEduSpuCost = "EduSpuCost";

        private const string _DBOperatorID = "OperatorID";
        private const string _DBOperationTime = "OperationTime";
        private const string _DBRemark = "Remark";
        private const string _DBOperation = "Operation";

        #endregion

        ///<summary>
        ///</summary>
        ///<param name="traineeApplication"></param>
        ///<exception cref="ApplicationException"></exception>
        public void InsertTraineeApplication(TraineeApplication traineeApplication)
        {
            try
            {
                traineeApplication.PKID = InsertTrainApplication(traineeApplication);
                if(traineeApplication.TraineeApplicationFlowList!=null)
                {
                    foreach(TraineeApplicationFlow flow in traineeApplication.TraineeApplicationFlowList)
                    {
                        flow.TraineeApplicationFlowID = InsertTraineeApplicationFlow(flow, traineeApplication.PKID);
                    }
                }
                if(traineeApplication.StudentList!=null)
                {
                    foreach (Account account in traineeApplication.StudentList)
                    {
                        InsertTrainAppTrainee(account.Id, traineeApplication.PKID);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="traineeApplication"></param>
        ///<exception cref="ApplicationException"></exception>
        public void UpdateTraineeApplication(TraineeApplication traineeApplication)
        {
            try
            {
                UpdateTrainApplication(traineeApplication);
                DeleteTraineeApplicationFlow(traineeApplication.PKID);
                DeleteTrainAppTrainee(traineeApplication.PKID);
                if (traineeApplication.TraineeApplicationFlowList != null)
                {
                    foreach (TraineeApplicationFlow flow in traineeApplication.TraineeApplicationFlowList)
                    {
                        flow.TraineeApplicationFlowID = InsertTraineeApplicationFlow(flow, traineeApplication.PKID);
                    }
                }
                if (traineeApplication.StudentList != null)
                {
                    foreach (Account account in traineeApplication.StudentList)
                    {
                        InsertTrainAppTrainee(account.Id, traineeApplication.PKID);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="traineeApplicationID"></param>
        public void DeleteTraineeApplication(int traineeApplicationID)
        {
            DeleteTrainApplication(traineeApplicationID);
            DeleteTraineeApplicationFlow(traineeApplicationID);
            DeleteTrainAppTrainee(traineeApplicationID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainAppID"></param>
        /// <returns></returns>
        public List<TraineeApplicationFlow> GetApplicationFlows(int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            List<TraineeApplicationFlow> flows = new List<TraineeApplicationFlow>();
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetTrainAppFlowByTrainAppID", cmd))
            {
                while (sdr.Read())
                {
                    TraineeApplicationFlow flow =
                        new TraineeApplicationFlow(new Account(Convert.ToInt32(sdr[_DBOperatorID]), string.Empty, string.Empty),
                                                   Convert.ToDateTime(sdr[_DBOperationTime]),
                                                   TraineeApplicationStatus.FindTraineeApplicationStatus(
                                                       Convert.ToInt32(sdr[_DBOperation])));
                    flow.Remark = sdr[_DBRemark].ToString();
                    flow.TraineeApplicationFlowID = Convert.ToInt32(sdr[_DBPKID]);
                    flows.Add(flow);

                }
                return flows;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        public List<TraineeApplication> GetEmployeeTraineeApplicationByEmployeeID(int employeeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ApplicationId, SqlDbType.Int).Value = employeeID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetTrainAppByApplicationId", cmd))
            {
                List<TraineeApplication> apps = new List<TraineeApplication>();
                while (sdr.Read())
                {
                    TraineeApplication app =
                        new TraineeApplication();
                    app.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    app.CourseName = (sdr[_DBCourseName]).ToString();
                    app.Applicant = new Account();
                    app.Applicant.Id = Convert.ToInt32(sdr[_DBApplicationId]);
                    app.TrainType =TrainScopeType.GetById( Convert.ToInt32(sdr[_DBTrainType]));
                    app.Trainer = (sdr[_DBTrainer]).ToString();
                    app.Skills = (sdr[_DBSkills]).ToString();
                    app.StratTime = Convert.ToDateTime(sdr[_DBStratTime]);
                    app.EndTime = Convert.ToDateTime(sdr[_DBEndTime]);
                    app.TrainPlace = (sdr[_DBTrianPlace]).ToString();
                    app.TrainOrgnatiaon = (sdr[_DBTrainOrgnatiaon]).ToString();
                    app.TrainHour = Convert.ToInt32(sdr[_DBTrainHour]);
                    app.TrainCost = Convert.ToInt32(sdr[_DBTrainCost]);
                    app.EduSpuCost = HrmisUtility.ConvertToDecimal(sdr[_DbEduSpuCost]);
                    app.HasCertifacation = (Convert.ToInt32(sdr[_DBHasCertification])).Equals(1);
                    app.NextStep = new DiyStep(Convert.ToInt32(sdr[_DBNextStepIndex]));
                    app.TraineeApplicationStatuss = TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32( sdr[_DBApplicationStatus]));
                    app.TraineeApplicationDiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                    apps.Add(app);
                }
                return apps;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="traineeName"></param>
        ///<param name="courseName"></param>
        ///<param name="traineeFrom"></param>
        ///<param name="traineeTo"></param>
        ///<param name="hasCertifacation"></param>
        ///<param name="trainScopeEnum"></param>
        ///<param name="statusEnum"></param>
        ///<returns></returns>
        public List<TraineeApplication> GetTraineeApplicationByCondition(string traineeName,string courseName, DateTime? traineeFrom, DateTime? traineeTo, int hasCertifacation, TrainScopeType trainScopeEnum, TraineeApplicationStatus statusEnum)
        {
              SqlCommand cmd = new SqlCommand();
           cmd.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = courseName;
           cmd.Parameters.Add(_Trainer, SqlDbType.NVarChar,50).Value = traineeName;
           cmd.Parameters.Add(_StratTime, SqlDbType.DateTime).Value = traineeFrom;
           cmd.Parameters.Add(_EndTime, SqlDbType.DateTime).Value = traineeTo;
           cmd.Parameters.Add(_TrainType, SqlDbType.Int).Value = trainScopeEnum.Id;
           cmd.Parameters.Add(_HasCertification, SqlDbType.Int).Value =hasCertifacation;
           cmd.Parameters.Add(_ApplicationStatus, SqlDbType.Int).Value = statusEnum.Id;
           using (
               SqlDataReader sdr =
                   SqlHelper.ExecuteReader("GetTrainApplicationByCondition", cmd))
           {
               List<TraineeApplication> apps = new List<TraineeApplication>();
               while (sdr.Read())
               {
                   TraineeApplication app =
                       new TraineeApplication();
                   app.PKID = Convert.ToInt32(sdr[_DBPKID]);
                   app.CourseName = (sdr[_DBCourseName]).ToString();
                   app.Applicant = new Account();
                   app.Applicant.Id = Convert.ToInt32(sdr[_DBApplicationId]);
                   app.TrainType = TrainScopeType.GetById(Convert.ToInt32(sdr[_DBTrainType]));
                   app.Trainer = (sdr[_DBTrainer]).ToString();
                   app.Skills = (sdr[_DBSkills]).ToString();
                   app.StratTime = Convert.ToDateTime(sdr[_DBStratTime]);
                   app.EndTime = Convert.ToDateTime(sdr[_DBEndTime]);
                   app.TrainPlace = (sdr[_DBTrianPlace]).ToString();
                   app.TrainOrgnatiaon = (sdr[_DBTrainOrgnatiaon]).ToString();
                   app.TrainHour = Convert.ToInt32(sdr[_DBTrainHour]);
                   app.TrainCost = Convert.ToInt32(sdr[_DBTrainCost]);
                   app.EduSpuCost = HrmisUtility.ConvertToDecimal(sdr[_DbEduSpuCost]);
                   app.HasCertifacation = (Convert.ToInt32(sdr[_DBHasCertification])).Equals(1);
                   app.NextStep = new DiyStep(Convert.ToInt32(sdr[_DBNextStepIndex]));
                   app.TraineeApplicationStatuss =
                       TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32(sdr[_DBApplicationStatus]));
                   app.TraineeApplicationDiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                   apps.Add(app);
               }
               return apps;
           }
        }

        ///<summary>
        ///</summary>
        ///<param name="TraineeApplicationID"></param>
        ///<returns></returns>
        public TraineeApplication GetTraineeApplicationByTraineeApplicationID(int TraineeApplicationID)
        {
            TraineeApplication app =new TraineeApplication();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = TraineeApplicationID;
            using (SqlDataReader sdr =SqlHelper.ExecuteReader("GetTrainApplicationByPKID", cmd))
            {
                while (sdr.Read())
                {

                    app.PKID = TraineeApplicationID;
                    app.CourseName = (sdr[_DBCourseName]).ToString();
                    app.Applicant = new Account();
                    app.Applicant.Id = Convert.ToInt32(sdr[_DBApplicationId]);
                    app.TrainType = TrainScopeType.GetById(Convert.ToInt32(sdr[_DBTrainType]));
                    app.Trainer = (sdr[_DBTrainer]).ToString();
                    app.Skills = (sdr[_DBSkills]).ToString();
                    app.StratTime = Convert.ToDateTime(sdr[_DBStratTime]);
                    app.EndTime = Convert.ToDateTime(sdr[_DBEndTime]);
                    app.TrainPlace = (sdr[_DBTrianPlace]).ToString();
                    app.TrainOrgnatiaon = (sdr[_DBTrainOrgnatiaon]).ToString();
                    app.TrainHour = Convert.ToInt32(sdr[_DBTrainHour]);
                    app.TrainCost = Convert.ToInt32(sdr[_DBTrainCost]);
                    app.EduSpuCost = HrmisUtility.ConvertToDecimal(sdr[_DbEduSpuCost]);
                    app.HasCertifacation = (Convert.ToInt32(sdr[_DBHasCertification])).Equals(1);
                    app.NextStep = new DiyStep(Convert.ToInt32(sdr[_DBNextStepIndex]));
                    app.TraineeApplicationStatuss = TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32(sdr[_DBApplicationStatus]));
                    app.TraineeApplicationDiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                    app.StudentList = GetAppTrainee(TraineeApplicationID);
                    app.TraineeApplicationFlowList = GetApplicationFlows(TraineeApplicationID);
                }
                return app;

            }
        }

        ///<summary>
        ///</summary>
        ///<param name="loginUser"></param>
        ///<param name="TraineeApplication"></param>
        ///<param name="traineeApplicationStatus"></param>
        public void ApproveTraineeApplication(Account loginUser, TraineeApplication TraineeApplication, 
            TraineeApplicationStatus traineeApplicationStatus)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = TraineeApplication.PKID;
                cmd.Parameters.Add(_ApplicationStatus, SqlDbType.Int).Value = traineeApplicationStatus.Id;
                cmd.Parameters.Add(_NextStepIndex, SqlDbType.Int).Value = TraineeApplication.NextStep.DiyStepID;
                SqlHelper.ExecuteNonQuery("UpdateTrainAppStatusByTrainAppID", cmd);

                //相关流程
                //DeleteTraineeApplicationFlow(TraineeApplication.PKID);
                if (TraineeApplication.TraineeApplicationFlowList != null)
                {
                    foreach (TraineeApplicationFlow flow in TraineeApplication.TraineeApplicationFlowList)
                    {
                        flow.TraineeApplicationFlowID = InsertTraineeApplicationFlow(flow, TraineeApplication.PKID);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<TraineeApplication> GetMyAuditingTraineeApplications(int accountID)
        {
           SqlCommand cmd = new SqlCommand();
           cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = accountID;
           using (
               SqlDataReader sdr =
                   SqlHelper.ExecuteReader("GetTrainAppConfirmHistoryByOperatorID", cmd))
           {
               List<TraineeApplication> apps = new List<TraineeApplication>();
               while (sdr.Read())
               {
                   TraineeApplication app =
                       new TraineeApplication();
                   app.PKID = Convert.ToInt32(sdr[_DBPKID]);
                   app.CourseName = (sdr[_DBCourseName]).ToString();
                   app.Applicant = new Account();
                   app.Applicant.Id = Convert.ToInt32(sdr[_DBApplicationId]);
                   app.TrainType = TrainScopeType.GetById(Convert.ToInt32(sdr[_DBTrainType]));
                   app.Trainer = (sdr[_DBTrainer]).ToString();
                   app.Skills = (sdr[_DBSkills]).ToString();
                   app.StratTime = Convert.ToDateTime(sdr[_DBStratTime]);
                   app.EndTime = Convert.ToDateTime(sdr[_DBEndTime]);
                   app.TrainPlace = (sdr[_DBTrianPlace]).ToString();
                   app.TrainOrgnatiaon = (sdr[_DBTrainOrgnatiaon]).ToString();
                   app.TrainHour = Convert.ToInt32(sdr[_DBTrainHour]);
                   app.TrainCost = Convert.ToInt32(sdr[_DBTrainCost]);
                   app.EduSpuCost = HrmisUtility.ConvertToDecimal(sdr[_DbEduSpuCost]);
                   app.HasCertifacation = (Convert.ToInt32(sdr[_DBHasCertification])).Equals(1);
                   app.NextStep = new DiyStep(Convert.ToInt32(sdr[_DBNextStepIndex]));
                   app.TraineeApplicationStatuss =
                       TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32(sdr[_DBApplicationStatus]));
                   app.TraineeApplicationDiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                   apps.Add(app);
               }
               return apps;
           }
        }

        /// <summary>
        /// 获取待审核的培训申请
        /// </summary>
        /// <returns></returns>
        public List<TraineeApplication> GetConfimingTraineeApplications()
        {
            SqlCommand cmd = new SqlCommand();
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetConfirmingTrainApplication", cmd))
            {
                List<TraineeApplication> apps = new List<TraineeApplication>();
                while (sdr.Read())
                {
                    TraineeApplication app =
                        new TraineeApplication();
                    app.PKID = Convert.ToInt32(sdr[_DBPKID]);
                    app.CourseName = (sdr[_DBCourseName]).ToString();
                    app.Applicant = new Account();
                    app.Applicant.Id = Convert.ToInt32(sdr[_DBApplicationId]);
                    app.TrainType = TrainScopeType.GetById(Convert.ToInt32(sdr[_DBTrainType]));
                    app.Trainer = (sdr[_DBTrainer]).ToString();
                    app.Skills = (sdr[_DBSkills]).ToString();
                    app.StratTime = Convert.ToDateTime(sdr[_DBStratTime]);
                    app.EndTime = Convert.ToDateTime(sdr[_DBEndTime]);
                    app.TrainPlace = (sdr[_DBTrianPlace]).ToString();
                    app.TrainOrgnatiaon = (sdr[_DBTrainOrgnatiaon]).ToString();
                    app.TrainHour = Convert.ToInt32(sdr[_DBTrainHour]);
                    app.TrainCost = Convert.ToInt32(sdr[_DBTrainCost]);
                    app.EduSpuCost = HrmisUtility.ConvertToDecimal(sdr[_DbEduSpuCost]);
                    app.HasCertifacation = (Convert.ToInt32(sdr[_DBHasCertification])).Equals(1);
                    app.NextStep = new DiyStep(Convert.ToInt32(sdr[_DBNextStepIndex]));
                    app.TraineeApplicationStatuss =
                        TraineeApplicationStatus.FindTraineeApplicationStatus(Convert.ToInt32(sdr[_DBApplicationStatus]));
                    app.TraineeApplicationDiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());

                    if (app.TraineeApplicationDiyProcess != null)
                    {
                        app.CurrentStep = app.TraineeApplicationDiyProcess.FindStep(app.NextStep.DiyStepID);
                    }
                    apps.Add(app);
                }
                return apps;
            }
        }

        #region 私有方法

        /// <summary>
        /// 新增申请培训
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <returns></returns>
        private static int InsertTrainApplication(TraineeApplication traineeApplication)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = traineeApplication.CourseName;
            sqlCommand.Parameters.Add(_ApplicationId, SqlDbType.Int).Value = traineeApplication.Applicant.Id;
            sqlCommand.Parameters.Add(_StratTime, SqlDbType.DateTime).Value = traineeApplication.StratTime;
            sqlCommand.Parameters.Add(_EndTime, SqlDbType.DateTime).Value = traineeApplication.EndTime;
            sqlCommand.Parameters.Add(_Skills, SqlDbType.NVarChar, 200).Value = traineeApplication.Skills;
            sqlCommand.Parameters.Add(_TrainOrgnatiaon, SqlDbType.NVarChar, 200).Value = traineeApplication.TrainOrgnatiaon;
            sqlCommand.Parameters.Add(_TrianPlace, SqlDbType.NVarChar, 200).Value = traineeApplication.TrainPlace;
            sqlCommand.Parameters.Add(_TrainHour, SqlDbType.Decimal).Value = traineeApplication.TrainHour;
            sqlCommand.Parameters.Add(_TrainCost, SqlDbType.Decimal).Value = traineeApplication.TrainCost;
            sqlCommand.Parameters.Add(_EduSpuCost, SqlDbType.Decimal).Value = traineeApplication.EduSpuCost.HasValue
                   ? (object)traineeApplication.EduSpuCost: DBNull.Value;
            sqlCommand.Parameters.Add(_Trainer, SqlDbType.NVarChar, 50).Value = traineeApplication.Trainer;
            sqlCommand.Parameters.Add(_TrainType, SqlDbType.Int).Value = traineeApplication.TrainType.Id;
            sqlCommand.Parameters.Add(_HasCertification, SqlDbType.Int).Value = traineeApplication.HasCertifacation;
            sqlCommand.Parameters.Add(_NextStepIndex, SqlDbType.Int).Value = 
                traineeApplication.NextStep.DiyStepID;
            sqlCommand.Parameters.Add(_ApplicationStatus, SqlDbType.Int).Value = traineeApplication.TraineeApplicationStatuss.Id;
            sqlCommand.Parameters.Add(_DiyProcess, SqlDbType.Text).Value = GetDiyProcess(traineeApplication);
            SqlHelper.ExecuteNonQueryReturnPKID("TrainApplicationInsert", sqlCommand, out pkid);
            return pkid;
        }

        /// <summary>
        /// 新增培训流程
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="trainAppID"></param>
        /// <returns></returns>
        private static int InsertTraineeApplicationFlow(TraineeApplicationFlow flow,int trainAppID)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            cmd.Parameters.Add(_OperatorID, SqlDbType.Int).Value = flow.Account.Id;
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = flow.OperationTime;
            cmd.Parameters.Add(_Operation, SqlDbType.Int).Value = Convert.ToInt32(flow.TraineeApplicationStatus.Id);
            if (flow.Remark == null)
            {
                cmd.Parameters.Add(_Remark, SqlDbType.NVarChar, 200).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_Remark, SqlDbType.NVarChar, 200).Value = flow.Remark;
            }
            SqlHelper.ExecuteNonQueryReturnPKID("InsertTrainAppFlow", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新申请培训
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <returns></returns>
        private static void UpdateTrainApplication(TraineeApplication traineeApplication)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Value = traineeApplication.PKID;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = traineeApplication.CourseName;
            sqlCommand.Parameters.Add(_ApplicationId, SqlDbType.Int).Value = traineeApplication.Applicant.Id;
            sqlCommand.Parameters.Add(_StratTime, SqlDbType.DateTime).Value = traineeApplication.StratTime;
            sqlCommand.Parameters.Add(_EndTime, SqlDbType.DateTime).Value = traineeApplication.EndTime;
            sqlCommand.Parameters.Add(_Skills, SqlDbType.NVarChar, 200).Value = traineeApplication.Skills;
            sqlCommand.Parameters.Add(_TrainOrgnatiaon, SqlDbType.NVarChar, 200).Value = traineeApplication.TrainOrgnatiaon;
            sqlCommand.Parameters.Add(_TrianPlace, SqlDbType.NVarChar, 200).Value = traineeApplication.TrainPlace;
            sqlCommand.Parameters.Add(_TrainHour, SqlDbType.Decimal).Value = traineeApplication.TrainHour;
            sqlCommand.Parameters.Add(_TrainCost, SqlDbType.Decimal).Value = traineeApplication.TrainCost;
            sqlCommand.Parameters.Add(_EduSpuCost, SqlDbType.Decimal).Value = traineeApplication.EduSpuCost.HasValue
                  ? (object)traineeApplication.EduSpuCost : DBNull.Value;
            sqlCommand.Parameters.Add(_Trainer, SqlDbType.NVarChar, 50).Value = traineeApplication.Trainer;
            sqlCommand.Parameters.Add(_TrainType, SqlDbType.Int).Value = traineeApplication.TrainType.Id;
            sqlCommand.Parameters.Add(_HasCertification, SqlDbType.Int).Value = traineeApplication.HasCertifacation;
            sqlCommand.Parameters.Add(_NextStepIndex, SqlDbType.Int).Value = 
                traineeApplication.NextStep.DiyStepID;
            sqlCommand.Parameters.Add(_ApplicationStatus, SqlDbType.Int).Value = traineeApplication.TraineeApplicationStatuss.Id;
            sqlCommand.Parameters.Add(_DiyProcess, SqlDbType.Text).Value = GetDiyProcess(traineeApplication);
            SqlHelper.ExecuteNonQuery("TrainApplicationUpdate", sqlCommand);
        }

        /// <summary>
        /// 删除申请培训
        /// </summary>
        /// <param name="trainAppID"></param>
        private static void DeleteTraineeApplicationFlow(int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            SqlHelper.ExecuteNonQuery("DeleteTrainAppFlowByTrainAppID", cmd);
        }

        /// <summary>
        /// 删除申请培训培训人员
        /// </summary>
        /// <param name="trainAppID"></param>
        private static void DeleteTrainAppTrainee(int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            SqlHelper.ExecuteNonQuery("TrainAppTraineeDelete", cmd);
        }

        /// <summary>
        /// 新增申请培训培训人员
        /// </summary>
        /// <param name="accountid"></param>
        /// <param name="trainAppID"></param>
        private static void InsertTrainAppTrainee(int accountid,int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            cmd.Parameters.Add(_TraineeID, SqlDbType.Int).Value = accountid;
            SqlHelper.ExecuteNonQuery("TrainAppTraineeInsert", cmd);
        }

        /// <summary>
        /// 删除培训课程
        /// </summary>
        /// <param name="trainAppID"></param>
        private static void DeleteTrainApplication(int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = trainAppID;
            SqlHelper.ExecuteNonQuery("TrainApplicationDelete", cmd);
        }

        /// <summary>
        /// 获取自定义流程
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <returns></returns>
        private static string GetDiyProcess(TraineeApplication traineeApplication)
        {
            string diyProcess = "";
            if (traineeApplication.TraineeApplicationDiyProcess != null && traineeApplication.TraineeApplicationDiyProcess.DiySteps != null)
            {
                foreach (DiyStep step in traineeApplication.TraineeApplicationDiyProcess.DiySteps)
                {
                    diyProcess += step.DiyStepID + "|" + step.Status + "|" + step.OperatorType.Id + "|" +
                                  step.OperatorID + "|";

                    foreach (Account account in step.MailAccount)
                    {
                        diyProcess += account.Id + ",";
                    }

                    diyProcess += ";";
                }
            }
            if (diyProcess.Length > 0)
            {
                diyProcess = diyProcess.Substring(0, diyProcess.Length - 1);
            }
            return diyProcess;
        }

        /// <summary>
        /// 获取申请培训中人员
        /// </summary>
        /// <param name="trainAppID"></param>
        /// <returns></returns>
        private static List<Account> GetAppTrainee(int trainAppID)
        {
            SqlCommand cmd = new SqlCommand();
            List<Account> accounts = new List<Account>();
            cmd.Parameters.Add(_TrainAppID, SqlDbType.Int).Value = trainAppID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetTrainAppTraineeByTrainAppId", cmd))
            {
                while (sdr.Read())
                {
                    Account account =
                        new Account();
                    account.Id = Convert.ToInt32(sdr[_DBTraineeID]);
                    accounts.Add(account);
                }
                return accounts;
            }
        }


        #endregion
    }
}
