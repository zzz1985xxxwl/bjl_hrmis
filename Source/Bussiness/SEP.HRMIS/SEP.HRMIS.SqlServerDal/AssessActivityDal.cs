//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityDal.cs
// 创建者: tang manli
// 创建日期: 2008-05-23
// 概述: 实现IAssessActivity接口中的方法
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class AssessActivityDal : IAssessActivity
    {
        private readonly IEmployee _Employee = new EmployeeDal();

        private const string _DbCounts = "Counts";

        #region use to begin transcation
        private SqlConnection _Conn;
        private SqlTransaction _Trans;
        #endregion

        #region parameters of main table
        private const string _PKID = "@PKID";
        private const string _AssessActivityID = "@AssessActivityID";
        private const string _EmployeeID = "@EmployeeID";
        private const string _AssessEmployeeID = "@AssessEmployeeID";
        private const string _AssessCharacter = "@AssessCharacter";
        private const string _AssessActivityStatus = "@AssessStatus";
        private const string _FinishStatus = "@FinishStatus";
        private const string _ScopeFrom = "@ScopeFrom";
        private const string _ScopeTo = "@ScopeTo";
        private const string _PersonalGoal = "@PersonalGoal";
        private const string _AssessProposerName = "@AssessProposerName";
        private const string _Reason = "@Reason";
        private const string _Intention = "@Intention";
        private const string _HRConfirmerName = "@HRConfirmerName";
        private const string _PersonalExpectedFinish = "@PersonalExpectedFinish";
        private const string _ManagerExpectedFinish = "@ManagerExpectedFinish";
        private const string _PaperName = "@PaperName";
        private const string _Score = "@Score";
        private const string _EmployeeDept = "@EmployeeDept";
        private const string _Responsibility = "@Responsibility";
        //private const string _EmployeeName = "@EmployeeName";
        private const string _HRSubmitTimeFrom = "@HRSubmitTimeFrom";
        private const string _HRSubmitTimeTo = "@HRSubmitTimeTo";
        private const string _IfEmployeeVisible = "@IfEmployeeVisible";

        private const string _ParmDiyProcess = "@DiyProcess";
        private const string _ParmNextStepIndex = "@NextStepIndex";
        private const string _AssessActivityPaperID = "@AssessActivityPaperID";
        #endregion

        #region parameters of paper table
        private const string _PaperType = "@Type";
        private const string _FillPerson = "@FillPerson";
        private const string _SubmitTime = "@SubmitTime";
        private const string _ChoseIntention = "@ChoseIntention";
        private const string _Content = "@Content";
        private const string _StepIndex = "@StepIndex";
        private const string _SalaryNow = "@SalaryNow";
        private const string _SalaryChange = "@SalaryChange";
        #endregion

        #region parameters of item table
        private const string _ItemType = "@Type";
        private const string _Question = "@Question";
        private const string _Grade = "@Grade";
        private const string _Note = "@Note";
        private const string _Option = "@Option";
        private const string _Classfication = "@Classfication";
        private const string _Description = "@Description";
        #endregion

        #region columns of main table
        private const string _DbPKID = "PKID";
        private const string _DbEmployeeID = "AssessEmployeeID";
        private const string _DbAssessCharacter = "AssessCharacter";
        private const string _DbAssessStatus = "AssessStatus";
        private const string _DbScopeFrom = "ScopeFrom";
        private const string _DbScopeTo = "ScopeTo";
        private const string _DbReason = "Reason";
        private const string _DbPersonalGoal = "PersonalGoal";
        private const string _DbAssessProposerName = "AssessProposerName";
        private const string _DbIntention = "Intention";
        private const string _DbHRConfirmerName = "HRConfirmerName";
        private const string _DbPersonalExpectedFinish = "PersonalExpectedFinish";
        private const string _DbManagerExpectedFinish = "ManagerExpectedFinish";
        private const string _DbPaperName = "PaperName";
        private const string _DbScore = "Score";
        private const string _DbEmployeeDept = "EmployeeDept";
        private const string _DbResponsibility = "Responsibility";
        private const string _DbIfEmployeeVisible = "IfEmployeeVisible";

        private const string _DbDiyProcess = "DiyProcess";
        private const string _DBNextStepIndex = "NextStepIndex";
        #endregion

        #region cloumns of paper table
        private const string _DbFillPerson = "FillPerson";
        private const string _DbSubmitTime = "SubmitTime";
        private const string _DbChoseIntention = "ChoseIntention";
        private const string _DbContent = "Content";
        private const string _DbStepIndex = "StepIndex";
        private const string _DbSalaryNow = "SalaryNow";
        private const string _DbSalaryChange = "SalaryChange";
        #endregion

        #region columns of item table
        private const string _DbType = "Type";
        private const string _DbQuestion = "Question";
        private const string _DbGrade = "Grade";
        private const string _DbNote = "Note";
        private const string _DbOption = "Option";
        private const string _DbClassfication = "Classfication";
        private const string _DbDescription = "Description";
        #endregion

        private const string _AssessTemplateItemType = "@AssessTemplateItemType";
        private const string _DbAssessTemplateItemType = "AssessTemplateItemType";
        private const string _Weight = "@Weight";
        private const string _DbWeight = "Weight";

        /// <summary>
        /// 新增考核活动
        /// </summary>
        public int InsertAssessActivity(AssessActivity obj)
        {
            InitializeTranscation();
        
            int activityId;
            //insert to main table
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_AssessEmployeeID, SqlDbType.Int).Value = obj.ItsEmployee.Account.Id;
                cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = obj.AssessCharacterType;
                cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = obj.ItsAssessStatus;
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = obj.ScopeFrom;
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = obj.ScopeTo;
                cmd.Parameters.Add(_PersonalGoal, SqlDbType.Text).Value = obj.PersonalGoal;
                cmd.Parameters.Add(_AssessProposerName, SqlDbType.NVarChar, 50).Value = obj.AssessProposerName;
                cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = obj.Reason;
                cmd.Parameters.Add(_Intention, SqlDbType.NVarChar, 50).Value = obj.Intention;
                cmd.Parameters.Add(_HRConfirmerName, SqlDbType.NVarChar, 50).Value = obj.HRConfirmerName;
                cmd.Parameters.Add(_PersonalExpectedFinish, SqlDbType.DateTime).Value = obj.PersonalExpectedFinish;
                cmd.Parameters.Add(_ManagerExpectedFinish, SqlDbType.DateTime).Value = obj.ManagerExpectedFinish;
                cmd.Parameters.Add(_PaperName, SqlDbType.NVarChar, 50).Value = obj.ItsAssessActivityPaper.PaperName;
                cmd.Parameters.Add(_Score, SqlDbType.Decimal).Value = obj.ItsAssessActivityPaper.Score;
                cmd.Parameters.Add(_EmployeeDept, SqlDbType.NVarChar, 50).Value = obj.EmployeeDept;
                cmd.Parameters.Add(_Responsibility, SqlDbType.NVarChar, 255).Value = obj.Responsibility;

                cmd.Parameters.Add(_ParmDiyProcess, SqlDbType.Text).Value = DiyProcessDal.ConvertToString(obj.DiyProcess);
                cmd.Parameters.Add(_ParmNextStepIndex, SqlDbType.Int).Value = obj.NextStepIndex;
                cmd.Parameters.Add(_IfEmployeeVisible, SqlDbType.Int).Value = obj.IfEmployeeVisible;
                
                SqlHelper.TransExecuteNonQueryReturnPKID("InsertAssessActivity", cmd, _Conn,_Trans, out activityId);
                obj.AssessActivityID = activityId;
                //insert to paper table
                InsertPaperTable(obj);

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

            return activityId;
        }

        #region all insert method

        private void InsertItemTable(int assessActivityPaperID, SubmitInfo submitInfo)
        {
            SqlCommand cmd = new SqlCommand();
            for (int i = 0; i < submitInfo.ItsAssessActivityItems.Count; i++)
            {
                cmd.Parameters.Add(_AssessActivityPaperID, SqlDbType.Int).Value = assessActivityPaperID;
                cmd.Parameters.Add(_ItemType, SqlDbType.Int).Value = submitInfo.SubmitInfoType.Id;
                cmd.Parameters.Add(_Question, SqlDbType.NVarChar, 100).Value =
                    submitInfo.ItsAssessActivityItems[i].Question;
                cmd.Parameters.Add(_Grade, SqlDbType.Decimal).Value =
                    submitInfo.ItsAssessActivityItems[i].Grade;
                cmd.Parameters.Add(_Note, SqlDbType.Text).Value =
                    submitInfo.ItsAssessActivityItems[i].Note;
                cmd.Parameters.Add(_Option, SqlDbType.NVarChar, 1000).Value =
                    submitInfo.ItsAssessActivityItems[i].Option;
                cmd.Parameters.Add(_Classfication, SqlDbType.Int).Value =
                    submitInfo.ItsAssessActivityItems[i].Classfication;
                cmd.Parameters.Add(_Description, SqlDbType.Text).Value =
                    submitInfo.ItsAssessActivityItems[i].Description;
                cmd.Parameters.Add(_AssessTemplateItemType, SqlDbType.Int).Value =
                    submitInfo.ItsAssessActivityItems[i].AssessTemplateItemType;
                cmd.Parameters.Add(_Weight, SqlDbType.Decimal).Value =
                  submitInfo.ItsAssessActivityItems[i].Weight;
                ExcuteTranscation("InsertAssessActivityItem", cmd);
            }
        }

        private void InsertPaperTable(AssessActivity obj)
        {
            for (int i = 0; i < obj.DiyProcess.DiySteps.Count; i++)
            {
                int activityPaperId;
                InsertSubmitInfo(i, obj, out activityPaperId);
                //InsertItemTable(activityPaperId, obj);
            }
        }

        private void InsertSubmitInfo(int stepIndex, AssessActivity obj,out int activityPaperId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AssessActivityID, SqlDbType.Int).Value = obj.AssessActivityID;
            cmd.Parameters.Add(_PaperType, SqlDbType.Int).Value =
                obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].SubmitInfoType.Id;
            cmd.Parameters.Add(_FillPerson, SqlDbType.NVarChar, 50).Value =
                obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].FillPerson;
            cmd.Parameters.Add(_SubmitTime, SqlDbType.DateTime).Value =
                obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].SubmitTime;
            cmd.Parameters.Add(_ChoseIntention, SqlDbType.NVarChar, 50).Value =
                obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].Choose;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value =
                obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].Comment;
            cmd.Parameters.Add(_SalaryNow, SqlDbType.Decimal).Value =
               obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].SalaryNow;
            cmd.Parameters.Add(_SalaryChange, SqlDbType.Decimal).Value =
               obj.ItsAssessActivityPaper.SubmitInfoes[stepIndex].SalaryChange;
            cmd.Parameters.Add(_StepIndex, SqlDbType.Int).Value = stepIndex;
            SqlHelper.TransExecuteNonQueryReturnPKID("InsertAssessActivityPaper", cmd, _Conn, _Trans, out activityPaperId);
        }

        #endregion

        ///<summary>
        ///</summary>
        ///<param name="obj"></param>
        ///<returns></returns>
        public int UpdateAssessActivity(AssessActivity obj)
        {
            InitializeTranscation();
            int activityId = obj.AssessActivityID;
            int affectRows;

            try
            {
                //update its main table
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = activityId;
                cmd.Parameters.Add(_AssessEmployeeID, SqlDbType.Int).Value = obj.ItsEmployee.Account.Id;
                cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = obj.AssessCharacterType;
                cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = obj.ItsAssessStatus;
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = obj.ScopeFrom;
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = obj.ScopeTo;
                cmd.Parameters.Add(_PersonalGoal, SqlDbType.Text).Value = obj.PersonalGoal;
                cmd.Parameters.Add(_AssessProposerName, SqlDbType.NVarChar, 50).Value = obj.AssessProposerName;
                cmd.Parameters.Add(_Reason, SqlDbType.Text).Value = obj.Reason;
                cmd.Parameters.Add(_Intention, SqlDbType.NVarChar, 50).Value = obj.Intention;
                cmd.Parameters.Add(_HRConfirmerName, SqlDbType.NVarChar, 50).Value = obj.HRConfirmerName;
                cmd.Parameters.Add(_PersonalExpectedFinish, SqlDbType.DateTime).Value = obj.PersonalExpectedFinish;
                cmd.Parameters.Add(_ManagerExpectedFinish, SqlDbType.DateTime).Value = obj.ManagerExpectedFinish;
                cmd.Parameters.Add(_PaperName, SqlDbType.NVarChar, 50).Value = obj.ItsAssessActivityPaper.PaperName;
                cmd.Parameters.Add(_Score, SqlDbType.Decimal).Value = obj.ItsAssessActivityPaper.Score;
                cmd.Parameters.Add(_EmployeeDept, SqlDbType.NVarChar, 50).Value = obj.EmployeeDept;
                cmd.Parameters.Add(_Responsibility, SqlDbType.NVarChar, 255).Value = obj.Responsibility;
                cmd.Parameters.Add(_ParmDiyProcess, SqlDbType.Text).Value = DiyProcessDal.ConvertToString(obj.DiyProcess);
                cmd.Parameters.Add(_ParmNextStepIndex, SqlDbType.Int).Value = obj.NextStepIndex;
                cmd.Parameters.Add(_IfEmployeeVisible, SqlDbType.Int).Value = obj.IfEmployeeVisible;
                affectRows = SqlHelper.TransExecuteNonQuery("UpdateAssessActivity", cmd, _Conn, _Trans);

                ////delete its paper table
                //DeletePaperTable(activityId);
                ////delete its item table
                //DeleteItemTable(activityId);

                ////insert its paper table
                //InsertPaperTable(obj);
                ////insert its item table
                //InsertItemTable(activityId, obj);

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
            return affectRows;
        }

        ///<summary>
        ///</summary>
        ///<param name="submitInfo"></param>
        ///<param name="assessActivityID"></param>
        ///<returns></returns>
        public int UpdateAssessActivityPaper(SubmitInfo submitInfo, int assessActivityID)
        {
            InitializeTranscation();
            int affectRows;

            try
            {
                //update its main table
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = submitInfo.SubmitInfoID;
                cmd.Parameters.Add(_AssessActivityID, SqlDbType.Int).Value = assessActivityID;
                cmd.Parameters.Add(_PaperType, SqlDbType.Int).Value = submitInfo.SubmitInfoType.Id;
                cmd.Parameters.Add(_FillPerson, SqlDbType.NVarChar, 50).Value = submitInfo.FillPerson;
                cmd.Parameters.Add(_SubmitTime, SqlDbType.DateTime).Value = submitInfo.SubmitTime;
                cmd.Parameters.Add(_ChoseIntention, SqlDbType.NVarChar, 50).Value = submitInfo.Choose;
                cmd.Parameters.Add(_Content, SqlDbType.Text).Value = submitInfo.Comment;
                cmd.Parameters.Add(_StepIndex, SqlDbType.Int).Value = submitInfo.StepIndex;
                cmd.Parameters.Add(_SalaryNow, SqlDbType.Decimal).Value = submitInfo.SalaryNow;
                cmd.Parameters.Add(_SalaryChange, SqlDbType.Decimal).Value = submitInfo.SalaryChange;
                affectRows = SqlHelper.TransExecuteNonQuery("UpdateAssessActivityPaper", cmd, _Conn, _Trans);

                //delete its item table
                DeleteItemTable(submitInfo.SubmitInfoID);

                //insert its item table
                InsertItemTable(submitInfo.SubmitInfoID, submitInfo);

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
            return affectRows;
        }

        #region add by liudan 2009-09-03
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessActivityID"></param>
        public void DeleteAssessActivity(int assessActivityID)
        {
            InitializeTranscation();

            try
            {
                DeleteAssessActivityByPkid(assessActivityID);
                List<int> paperIds = GetActivityPaperIdByassessActivityID(assessActivityID);
                DeleteActivityPaperByassessActivityID(assessActivityID);
                foreach(int id in paperIds)
                {
                    DeleteItemTable(id);
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

        /// <summary>
        /// 删除考评活动
        /// </summary>
        /// <param name="assessActivityID"></param>
        private static void DeleteAssessActivityByPkid(int assessActivityID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = assessActivityID;
            SqlHelper.ExecuteNonQuery("DeleteAssessActivityByPkid", cmd);
        }

        /// <summary>
        /// 删除考评活动相关paperid
        /// </summary>
        /// <param name="assessActivityID"></param>
        private static void DeleteActivityPaperByassessActivityID(int assessActivityID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessActivityID, SqlDbType.Int).Value = assessActivityID;
            SqlHelper.ExecuteNonQuery("DeleteActivityPaperByassessActivityID", cmd);
        }

        /// <summary>
        /// 获取考评活动相关paperid
        /// </summary>
        /// <param name="assessActivityID"></param>
        private static List<int> GetActivityPaperIdByassessActivityID(int assessActivityID)
        {
            List<int> paperIDs=new List<int>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessActivityID, SqlDbType.Int).Value =assessActivityID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetAssessActivityPaperById", cmd))
            {
                while (sdr.Read())
                {
                    int paperID = Convert.ToInt32(sdr[_DbPKID]);
                    paperIDs.Add(paperID);
                }
            }
            return paperIDs;
        }

        #endregion

        ///<summary>
        ///</summary>
        ///<param name="assessActivityID"></param>
        ///<param name="ifEmployeeVisible"></param>
        ///<returns></returns>
        public int UpdateAssessActivityEmployeeVisible(int assessActivityID, bool ifEmployeeVisible)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = assessActivityID;
            cmd.Parameters.Add(_IfEmployeeVisible, SqlDbType.Int).Value = ifEmployeeVisible;
            return SqlHelper.ExecuteNonQuery("UpdateAssessActivityEmployeeVisible", cmd);
        }

        private void DeleteItemTable(int assessActivityPaperID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessActivityPaperID, SqlDbType.Int).Value = assessActivityPaperID;
            ExcuteTranscation("DeleteAssessActivityPaperByAssessActivityPaperID", cmd);
        }

        /// <summary>
        /// 通过AssessActivity的PKID查找AssessActivity
        /// </summary>
        public AssessActivity GetAssessActivityById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityById", cmd))
            {
                while (sdr.Read())
                {
                    AssessActivity assessActivity = new AssessActivity();

                    //rechieve from its main table
                    assessActivity.AssessActivityID = Convert.ToInt32(sdr[_DbPKID]);
                    assessActivity.ItsEmployee = RechieveEmployee((int)sdr[_DbEmployeeID]);
                    assessActivity.AssessCharacterType = (AssessCharacterType)sdr[_DbAssessCharacter];
                    assessActivity.ItsAssessStatus =  (AssessStatus)sdr[_DbAssessStatus];
                    assessActivity.ScopeFrom = Convert.ToDateTime(sdr[_DbScopeFrom]);
                    assessActivity.ScopeTo = Convert.ToDateTime(sdr[_DbScopeTo]);
                    assessActivity.PersonalGoal = sdr[_DbPersonalGoal].ToString();
                    assessActivity.AssessProposerName = sdr[_DbAssessProposerName].ToString();
                    assessActivity.Intention = sdr[_DbIntention].ToString();// RechieveIntention(sdr[_DbIntention].ToString());
                    assessActivity.Reason = sdr[_DbReason].ToString();
                    assessActivity.HRConfirmerName = sdr[_DbHRConfirmerName].ToString();
                    assessActivity.PersonalExpectedFinish =Convert.ToDateTime(sdr[_DbPersonalExpectedFinish]);
                    assessActivity.ManagerExpectedFinish =Convert.ToDateTime(sdr[_DbManagerExpectedFinish]);
                    assessActivity.ItsAssessActivityPaper = RechievePaper(sdr[_DbPaperName].ToString(), (decimal)sdr[_DbScore]);
                    assessActivity.EmployeeDept = sdr[_DbEmployeeDept].ToString();
                    assessActivity.Responsibility = sdr[_DbResponsibility].ToString();
                    assessActivity.NextStepIndex = Convert.ToInt32(sdr[_DBNextStepIndex]);
                    assessActivity.DiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                    if (sdr[_DbIfEmployeeVisible].ToString() == "1")
                    {
                        assessActivity.IfEmployeeVisible = true;
                    }
                    //rechieve from its paper table
                    RechieveItsPaper(assessActivity);
                    //rechieve from tis item table
                    RechieveItsItem(assessActivity.ItsAssessActivityPaper.PaperName, assessActivity);

                    return assessActivity;
                }
            }
            return null;
        }

        #region all rechieve methods

        private static void RechieveItsSubmitInfo(int paperID, SubmitInfo submitInfo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessActivityPaperID, SqlDbType.Int).Value = paperID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetAssessActivityItemByAssessActivityPaperId", cmd))
            {
                while (sdr.Read())
                {
                    AssessActivityItem assessActivityItem = new AssessActivityItem(sdr[_DbQuestion].ToString(), sdr[_DbOption].ToString(), (ItemClassficationEmnu)sdr[_DbClassfication], sdr[_DbDescription].ToString());
                    assessActivityItem.Grade = Convert.ToDecimal(sdr[_DbGrade]);
                    assessActivityItem.Note = sdr[_DbNote].ToString();
                    assessActivityItem.AssessTemplateItemType = (AssessTemplateItemType)sdr[_DbAssessTemplateItemType];
                    assessActivityItem.Weight = Convert.ToDecimal(sdr[_DbWeight]);
                    assessActivityItem.AssessActivityItemType = (AssessActivityItemType)sdr[_DbType];
                    submitInfo.ItsAssessActivityItems.Add(assessActivityItem);
                }
            }
        }

        private static void RechieveItsItem(string paperName, AssessActivity assessActivity)
        {
            AssessTemplatePaper assessTemplatePaper =
                new AssessTemplatePaperDal().GetTemplatePapersExactlyByPaperName(paperName);

            if (assessTemplatePaper != null)
            {
                //assessTemplatePaper = new AssessTemplatePaperDal().GetAssessTempletPaperById(assessTemplatePaper.AssessTemplatePaperID);
                assessTemplatePaper = new AssessTemplatePaperDal().GetTempletPaperAndItemById(assessTemplatePaper.AssessTemplatePaperID);

                foreach (AssessTemplateItem item in assessTemplatePaper.ItsAssessTemplateItems)
                {
                    switch (item.ItsOperateType)
                    {
                        case OperateType.HR:
                            HRItem hrItem =
                                new HRItem(item.Question, item.Option, item.Classfication, item.Description);
                            hrItem.Grade = 0;
                            hrItem.Note = "";
                            hrItem.AssessTemplateItemType = item.AssessTemplateItemType;
                            hrItem.Weight = item.Weight;
                            assessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(hrItem);
                            break;
                        case OperateType.NotHR:
                            PersonalItem personalItem =
                                new PersonalItem(item.Question, item.Option, item.Classfication, item.Description);
                            personalItem.Grade = 0;
                            personalItem.Note = "";
                            personalItem.AssessTemplateItemType = item.AssessTemplateItemType;
                            personalItem.Weight = item.Weight;
                            assessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(personalItem);
                            ManagerItem managerItem =
                                new ManagerItem(item.Question, item.Option, item.Classfication, item.Description);
                            managerItem.Grade = 0;
                            managerItem.Note = "";
                            managerItem.AssessTemplateItemType = item.AssessTemplateItemType;
                            managerItem.Weight = item.Weight;
                            assessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(managerItem);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void RechieveItsPaper(AssessActivity assessActivity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AssessActivityID, SqlDbType.Int).Value =
                assessActivity.AssessActivityID;
            using (
                SqlDataReader sdr =
                    SqlHelper.ExecuteReader("GetAssessActivityPaperById", cmd))
            {
                while (sdr.Read())
                {
                    SubmitInfo submitInfo = new SubmitInfo();
                    submitInfo.Choose = sdr[_DbChoseIntention].ToString();
                    submitInfo.Comment = sdr[_DbContent].ToString();
                    submitInfo.FillPerson = sdr[_DbFillPerson].ToString();
                    submitInfo.StepIndex = Convert.ToInt32(sdr[_DbStepIndex]);
                    submitInfo.SubmitTime = Convert.ToDateTime(sdr[_DbSubmitTime]);
                    submitInfo.SalaryNow = EmployeeWelfare.ConvertToDecimal(sdr[_DbSalaryNow]);
                    submitInfo.SalaryChange = EmployeeWelfare.ConvertToDecimal(sdr[_DbSalaryChange]);
                    submitInfo.SubmitInfoType =
                        SubmitInfoType.RechieveSubmitInfoTypeByID(Convert.ToInt32(sdr[_DbType]));
                    assessActivity.ItsAssessActivityPaper.SubmitInfoes.Add(submitInfo);

                    int paperID = Convert.ToInt32(sdr[_DbPKID]);
                    submitInfo.SubmitInfoID = paperID;
                    RechieveItsSubmitInfo(paperID, submitInfo);
                }
            }
        }

        private static AssessActivityPaper RechievePaper(string paperName, decimal score)
        {
            AssessActivityPaper retPaper = new AssessActivityPaper(paperName);
            retPaper.Score = score;
            return retPaper;
        }

        private Employee RechieveEmployee(int accountId)
        {
            return _Employee.GetEmployeeByAccountID(accountId);
        }

        #endregion

        /// <summary>
        /// 通过EmployeeID查找员工正在参加的考评活动的数目
        /// </summary>
        public int CountOpeningAssessActivityByAccountId(int accountId, AssessCharacterType assessCharacterType)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = (int)assessCharacterType;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountOpeningAssessActivityByEmployeeID", cmd))
            {
                sdr.Read();
                return (int) sdr[_DbCounts];
            }
        }

        /// <summary>
        /// 通过assessCharacterType查找员工选择的意向
        /// </summary>
        public string GetIntentionByCharacter(AssessCharacterType assessCharacterType)
        {
            switch (assessCharacterType)
            {
                case AssessCharacterType.NormalForContract:
                    return "续签/不再续签/调整工作岗位后续签";
                case AssessCharacterType.ProbationI:
                    return "继续试用/提前转正/转岗/培训";
                case AssessCharacterType.ProbationII:
                    return "按期转正/解除劳动合同";
                case AssessCharacterType.PracticeI:
                    return "继续实习，并签三方协议/不再实习";
                case AssessCharacterType.PracticeII:
                    return "签合同/不签合同";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 查找employee的所有的assessActivity
        /// </summary>
        public List<AssessActivity> GetAssessActivityByEmployee(int employeeID)
        {
            List<AssessActivity> retList = new List<AssessActivity>();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = employeeID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityByEmployee", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    retList.Add(GetAssessActivityById(assessActivityId));
                }
            }
            return retList;
        }

        /// <summary>
        /// 查找employee的状态为status的所有的assessActivity
        /// </summary>
        public List<AssessActivity> GetAssessActivityByEmployeeStatus(int employeeID, AssessStatus status)
        {
            List<AssessActivity> retList = new List<AssessActivity>();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = employeeID;
            cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = status;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityByEmployeeStatus", cmd))
            {
                while (sdr.Read())
                {
                    AssessActivity assessActivity = new AssessActivity();
                    //rechieve from its main table
                    assessActivity.AssessActivityID = Convert.ToInt32(sdr[_DbPKID]);
                    assessActivity.ItsEmployee = RechieveEmployee((int)sdr[_DbEmployeeID]);
                    assessActivity.AssessCharacterType = (AssessCharacterType)sdr[_DbAssessCharacter];
                    assessActivity.ItsAssessStatus = (AssessStatus)sdr[_DbAssessStatus];
                    assessActivity.ScopeFrom = Convert.ToDateTime(sdr[_DbScopeFrom]);
                    assessActivity.ScopeTo = Convert.ToDateTime(sdr[_DbScopeTo]);
                    assessActivity.PersonalGoal = sdr[_DbPersonalGoal].ToString();
                    assessActivity.AssessProposerName = sdr[_DbAssessProposerName].ToString();
                    assessActivity.Intention = sdr[_DbIntention].ToString();// RechieveIntention(sdr[_DbIntention].ToString());
                    assessActivity.Reason = sdr[_DbReason].ToString();
                    assessActivity.HRConfirmerName = sdr[_DbHRConfirmerName].ToString();
                    assessActivity.PersonalExpectedFinish = Convert.ToDateTime(sdr[_DbPersonalExpectedFinish]);
                    assessActivity.ManagerExpectedFinish = Convert.ToDateTime(sdr[_DbManagerExpectedFinish]);
                    assessActivity.ItsAssessActivityPaper = RechievePaper(sdr[_DbPaperName].ToString(), (decimal)sdr[_DbScore]);
                    assessActivity.EmployeeDept = sdr[_DbEmployeeDept].ToString();
                    assessActivity.Responsibility = sdr[_DbResponsibility].ToString();
                    assessActivity.NextStepIndex = Convert.ToInt32(sdr[_DBNextStepIndex]);
                    assessActivity.DiyProcess = DiyProcessDal.ConvertToObject(sdr[_DbDiyProcess].ToString());
                    if (sdr[_DbIfEmployeeVisible].ToString() == "1")
                    {
                        assessActivity.IfEmployeeVisible = true;
                    }
                    retList.Add(assessActivity);
                }
            }
            return retList;
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        /// <param name="assessCharacterType"></param>
        /// <param name="status"></param>
        /// <param name="hrSubmitTimeFrom"></param>
        /// <param name="hrSubmitTimeTo"></param>
        /// <returns></returns>
        /// <param name="finishStatus"></param>
        /// <param name="scopeFrom"></param>
        /// <param name="scopeTo"></param>
        public List<AssessActivity> GetAssessActivityByCondition(AssessCharacterType assessCharacterType, AssessStatus status, DateTime?
            hrSubmitTimeFrom, DateTime? hrSubmitTimeTo, int finishStatus, DateTime? scopeFrom, DateTime? scopeTo)
        {
            List<AssessActivity> assessActivityList = new List<AssessActivity>();
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar).Value = employeeName;
            cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = assessCharacterType;
            cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = status;
            cmd.Parameters.Add(_FinishStatus, SqlDbType.Int).Value = finishStatus;
            if (hrSubmitTimeFrom.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = hrSubmitTimeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (hrSubmitTimeTo.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = hrSubmitTimeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeFrom.HasValue)
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = scopeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeTo.HasValue)
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = scopeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    assessActivityList.Add(GetAssessActivityById(assessActivityId));
                }
            }

            return assessActivityList;
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        /// <param name="assessCharacterType"></param>
        /// <param name="status"></param>
        /// <param name="hrSubmitTimeFrom"></param>
        /// <param name="hrSubmitTimeTo"></param>
        /// <returns></returns>
        /// <param name="finishStatus"></param>
        /// <param name="scopeFrom"></param>
        /// <param name="scopeTo"></param>
        public List<AssessActivity> GetAnnualAssessActivityByCondition(AssessCharacterType assessCharacterType, AssessStatus status, DateTime?
            hrSubmitTimeFrom, DateTime? hrSubmitTimeTo, int finishStatus, DateTime? scopeFrom, DateTime? scopeTo)
        {
            List<AssessActivity> assessActivityList = new List<AssessActivity>();
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar).Value = employeeName;
            cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = assessCharacterType;
            cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = status;
            cmd.Parameters.Add(_FinishStatus, SqlDbType.Int).Value = finishStatus;
            if (hrSubmitTimeFrom.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = hrSubmitTimeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (hrSubmitTimeTo.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = hrSubmitTimeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeFrom.HasValue)
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = scopeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeTo.HasValue)
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = scopeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAnnualAssessActivityByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    assessActivityList.Add(GetAssessActivityById(assessActivityId));
                }
            }

            return assessActivityList;
        }

        /// <summary>
        /// 根据employeeName、assessCharacterType、status、HRSubmitTime的查找所有的assessActivity
        /// </summary>
        /// <param name="assessCharacterType"></param>
        /// <param name="status"></param>
        /// <param name="hrSubmitTimeFrom"></param>
        /// <param name="hrSubmitTimeTo"></param>
        /// <returns></returns>
        /// <param name="finishStatus"></param>
        /// <param name="scopeFrom"></param>
        /// <param name="scopeTo"></param>
        public List<AssessActivity> GetContractAssessActivityByCondition(AssessCharacterType assessCharacterType, AssessStatus status, DateTime?
            hrSubmitTimeFrom, DateTime? hrSubmitTimeTo, int finishStatus, DateTime? scopeFrom, DateTime? scopeTo)
        {
            List<AssessActivity> assessActivityList = new List<AssessActivity>();
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar).Value = employeeName;
            cmd.Parameters.Add(_AssessCharacter, SqlDbType.Int).Value = assessCharacterType;
            cmd.Parameters.Add(_AssessActivityStatus, SqlDbType.Int).Value = status;
            cmd.Parameters.Add(_FinishStatus, SqlDbType.Int).Value = finishStatus;
            if (hrSubmitTimeFrom.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = hrSubmitTimeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (hrSubmitTimeTo.HasValue)
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = hrSubmitTimeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_HRSubmitTimeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeFrom.HasValue)
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = scopeFrom.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeFrom, SqlDbType.DateTime).Value = DBNull.Value;
            }
            if (scopeTo.HasValue)
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = scopeTo.Value;
            }
            else
            {
                cmd.Parameters.Add(_ScopeTo, SqlDbType.DateTime).Value = DBNull.Value;
            }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetContractAssessActivityByCondition", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    assessActivityList.Add(GetAssessActivityById(assessActivityId));
                }
            }

            return assessActivityList;
        }

        /// <summary>
        /// 查找主管属下的所有assessActivity
        /// </summary>
        public List<AssessActivity> GetAssessActivityByManagerName(string managerName)
        {
            List<AssessActivity> retList = new List<AssessActivity>();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_FillPerson, SqlDbType.NVarChar).Value = managerName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityByManagerName", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    retList.Add(GetAssessActivityById(assessActivityId));
                }
            }
            return retList;
        }
        /// <summary>
        /// 查找自己参与过的考评
        /// </summary>
        public List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string managerName)
        {
            List<AssessActivity> retList = new List<AssessActivity>();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_FillPerson, SqlDbType.NVarChar).Value = managerName;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessActivityHistoryByEmployeeName", cmd))
            {
                while (sdr.Read())
                {
                    int assessActivityId = (int)sdr[_DbPKID];
                    retList.Add(GetAssessActivityById(assessActivityId));
                }
            }
            return retList;
        }

        #region transcation related

        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        private void ExcuteTranscation(string procedureName, SqlCommand cmd)
        {
            SqlHelper.TransExecuteNonQuery(procedureName, cmd, _Conn, _Trans);
        }

        #endregion

    }
}
