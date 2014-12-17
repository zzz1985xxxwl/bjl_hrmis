//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainDal.cs
// 创建者:刘丹
// 创建日期: 2008-10-10
// 概述: ITrain接口实现
// ----------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class TrainDal : ITrain
    {
        #region    parameter
        //course
        private const string _PKID = "@PKID";
        private const string _CourseName = "@CourseName";
        private const string _CoordinatorID = "@CoordinatorID";
        private const string _CoordinatorName = "@CoordinatorName";
        private const string _Scope = "@Scope";
        private const string _Status = "@Status";
        private const string _Trainer = "@Trainer";
        private const string _ExpectST = "@ExpectST";
        private const string _ExpectET = "@ExpectET";
        private const string _ActualST = "@ActualST";
        private const string _ActualET = "@ActualET";
        private const string _ExpectHour = "@ExpectHour";
        private const string _ActualHour = "@ActualHour";
        private const string _ExpectCost = "@ExpectCost";
        private const string _ActualCost = "@ActualCost";
        private const string _FBCount = "@FBCount";
        private const string _Score = "@Score";
        private const string _TrianPlace = "@TrianPlace";
        private const string _FeedBackPaperId = "@FeedBackPaperId";
        private const string _HasCertification = "@HasCertification";
        //CourseFB                                      
        private const string _CourseID = "@CourseID";
        private const string _FBQues = "@FBQues";
        private const string _FBItems = "@FBItems";
        private const string _FBItemsScore = "@FBItemsScore";
        //CourseFBResult
        private const string _CourseFBID = "@CourseFBID";
        private const string _TraineeID = "@TraineeID";
        private const string _TraineeName = "@TraineeName";
        private const string _TraineeScore = "@Score";
        private const string _CertificationName = "@CertificationName";
        //skill
        private const string _SkillID = "@SkillID";
        private const string _SkillName = "@SkillName";
        //CourseTrainee
        private const string _FBTime = "@FBTime";
        private const string _TrainFBStatus = "@Status";
        private const string _TrainFBAllScore = "@Score";
        private const string _Suggestion = "@Suggestion";

        //Condition
        private const string _FromExpectCost = "@FromExpectCost";
        private const string _ToExpectCost = "@ToExpectCost";
        private const string _FromActualCost = "@FromActualCost";
        private const string _ToActualCost = "@ToActualCost";
        private const string _StartTime = "@StartTime";
        private const string _EndTime = "@EndTime";

        private const string _DbError = "数据库访问错误!";
        #endregion

        #region  DB
        //course
        private const string _DBPKID = "PKID";
        private const string _DBCourseName = "CourseName";
        private const string _DBCoordinatorID = "CoordinatorID";
        private const string _DBCoordinatorName = "CoordinatorName";
        private const string _DBScope = "Scope";
        private const string _DBStatus = "Status";
        private const string _DBTrainer = "Trainer";
        private const string _DBExpectST = "ExpectST";
        private const string _DBExpectET = "ExpectET";
        private const string _DBActualST = "ActualST";
        private const string _DBActualET = "ActualET";
        private const string _DBExpectHour = "ExpectHour";
        private const string _DBActualHour = "ActualHour";
        private const string _DBExpectCost = "ExpectCost";
        private const string _DBActualCost = "ActualCost";
        private const string _DBTrianPlace = "TrianPlace";
        private const string _DBFBCount = "FBCount";
        private const string _DBScore = "Score";
        private const string _DBFeedBackPaperId = "FeedBackPaperId";
        private const string _DBHasCertification = "HasCertification";
        //CourseFB                                      
        private const string _DBCourseID = "CourseID";
        private const string _DBFBQues = "FBQues";
        private const string _DBFBItems = "FBItems";
        private const string _DBFBItemsScore = "FBItemsScore";
        //CourseFBResult
        private const string _DBCourseFBID = "CourseFBID";
        private const string _DBTraineeID = "TraineeID";
        private const string _DBTraineeName = "TraineeName";
        private const string _DBTraineeScore = "Score";
        private const string _DBCertificationName = "CertificationName";
        //skill
        private const string _DBSkillID = "SkillID";
        private const string _DBSkillName = "SkillName";
        //CourseTrainee
        private const string _DBFBTime = "FBTime";
        //private const string _DBTrainFBStatus = "Status";
        private const string _DBTrainFBAllScore = "Score";
        private const string _DBSuggestion = "Suggestion";
        private readonly int _retVal = -1;
        private const string _DbCount = "Counts";
        #endregion

        public void InsertTrainCourse(Course obj)
        {
            try
            {
                obj.CourseID = InsertCourse(obj);
                if (obj.Skill != null)
                {
                    foreach (Skill skill in obj.Skill)
                    {
                        InsertCourseSkill(skill, obj.CourseID, obj.CourseName);
                    }
                }
                if (obj.TrainFBResult.FBPaperItem != null)
                {
                    foreach (FBPaperItem item in obj.TrainFBResult.FBPaperItem)
                    {
                        item.FBPaperItemId = InsertCourseFB(obj.CourseID, item);
                    }
                }
                if (obj.TrainFBResult.TrainEmployeeFBs != null)
                {
                    foreach (TrainEmployeeFB employee in obj.TrainFBResult.TrainEmployeeFBs)
                    {
                        InsertCourseTraineeWithoutFb(employee.Trainee, obj.CourseID, obj.CourseName);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void UpdateTrainCourse(Course obj)
        {
            try
            {
                UpdateCourse(obj);
                //删除所有技能再新增
                DeleteCourseSkill(obj.CourseID);
                if (obj.Skill != null)
                {

                    foreach (Skill skill in obj.Skill)
                    {
                        InsertCourseSkill(skill, obj.CourseID, obj.CourseName);
                    }
                }
                // 删除所有课程对应的员工，再新增
                DeleteCourseTrainee(obj.CourseID);


                foreach (TrainEmployeeFB employeeFb in obj.TrainFBResult.TrainEmployeeFBs)
                {
                    if (employeeFb.FBTime == null)
                    {
                        InsertCourseTraineeWithoutFb(employeeFb.Trainee, obj.CourseID, obj.CourseName);
                    }
                    else
                    {
                        InsertCourseTrainee(obj.CourseID, obj.CourseName, employeeFb);
                    }
                }

                //删除课程对应的所有反馈。再新增
                DeleteCourseFBResult(obj.CourseID);
                if (obj.TrainFBResult.TrainEmployeeFBs != null)
                {
                    foreach (TrainEmployeeFB employeeFb in obj.TrainFBResult.TrainEmployeeFBs)
                    {
                        if (employeeFb.FBItem != null)
                        {
                            foreach (TraineeFBItem item in employeeFb.FBItem)
                            {
                                InsertCourseFBResult(obj.CourseID, item, employeeFb.Trainee);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void DeleteTrainCourse(int courseId)
        {
            try
            {
                DeleteCourse(courseId);
                DeleteCourseSkill(courseId);
                DeleteCourseFB(courseId);
                DeleteCourseFBResult(courseId);
                DeleteCourseTrainee(courseId);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public Course GetTrainCourseByPKID(int pkid)
        {
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseByPKID", sqlCommmand))
            {
                while (sdr.Read())
                {
                    Course course=new Course();
                    course.CourseID = Convert.ToInt32(sdr[_DBPKID]);
                    course.CourseName =sdr[_DBCourseName].ToString();
                    //course.Coordinator = _EmployeeDal.GetEmployeeByAccountID(Convert.ToInt32(sdr[_DBCoordinatorID]));
                    course.Coordinator = new Account();
                    course.Coordinator.Id = Convert.ToInt32(sdr[_DBCoordinatorID]);
                    course.Coordinator.Name = sdr[_DBCoordinatorName].ToString();
                    course.Scope = (TrainScopeEnum)sdr[_DBScope];
                    course.Status = (TrainStatusEnum) sdr[_DBStatus];
                    course.Trainer = sdr[_DBTrainer].ToString();
                    course.ExpectST = Convert.ToDateTime(sdr[_DBExpectST]);
                    course.ExpectET = Convert.ToDateTime(sdr[_DBExpectET]);
                    course.ActualST = Convert.ToDateTime(sdr[_DBActualST]);
                    course.ActualET = Convert.ToDateTime(sdr[_DBActualET]);
                    course.ExpectHour = Convert.ToDecimal(sdr[_DBExpectHour]);
                    course.ExpectCost = Convert.ToDecimal(sdr[_DBExpectCost]);
                    course.ActualHour = Convert.ToDecimal(sdr[_DBActualHour]);
                    course.ActualCost = Convert.ToDecimal(sdr[_DBActualCost]);
                    course.TrainPlace = sdr[_DBTrianPlace].ToString();
                    course.Skill = GetCourseSkill(course.CourseID);
                    course.TrainFBResult=new TrainFBResult();
                    course.TrainFBResult.FBPaperItem = GetFBPaperItem(course.CourseID);
                    course.TrainFBResult.FeedBackCount = Convert.ToInt32(sdr[_DBFBCount]);
                    course.TrainFBResult.CourseScore = Convert.ToDecimal(sdr[_DBScore]);
                    course.CourseFeedBackPaper=new FeedBackPaper();
                    course.CourseFeedBackPaper.FeedBackPaperId = Convert.ToInt32(sdr[_DBFeedBackPaperId]);
                    course.HasCertification = Convert.ToInt32(sdr[_DBHasCertification]);
                    List<TrainEmployeeFB> emplooyeeFbs = GetCourseTrainnee(course.CourseID);
                    foreach (TrainEmployeeFB fb in emplooyeeFbs)
                    {
                        fb.FBItem = GetEmployeeFBItem(fb.Trainee.Id, course.CourseID);
                    }
                    course.TrainFBResult.TrainEmployeeFBs = emplooyeeFbs;
                    return course;
                }
            }
            return null;
        }

        //只保存了些基本信息，详细信息需通过pkid获取
        public List<Course> GetCourseByConditon(string courseName, string coordinator, int scope, int status,
                                                string trainer, string trainee, string skillName,
                                                DateTime expectedTimeFrom, DateTime expectedTimeTo,
                                                DateTime actualTimeFrom, DateTime actualTimeTo, decimal expctedCostFrom,
                                                decimal expectedCostTo, decimal actaulCostFrom, decimal actualCostTo)
        {
            List<Course> courses = new List<Course>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_CourseName, SqlDbType.NVarChar,200).Value = courseName;
            sqlCommmand.Parameters.Add(_CoordinatorName, SqlDbType.NVarChar, 50).Value = coordinator;
            sqlCommmand.Parameters.Add(_Trainer, SqlDbType.NVarChar, 50).Value = trainer;
            sqlCommmand.Parameters.Add(_TraineeName, SqlDbType.NVarChar,50).Value = trainee;
            sqlCommmand.Parameters.Add(_SkillName, SqlDbType.NVarChar,100).Value = skillName;
            sqlCommmand.Parameters.Add(_Scope, SqlDbType.Int).Value = scope;
            sqlCommmand.Parameters.Add(_Status, SqlDbType.Int).Value = status;
            sqlCommmand.Parameters.Add(_ExpectST, SqlDbType.DateTime).Value = expectedTimeFrom;
            sqlCommmand.Parameters.Add(_ExpectET, SqlDbType.DateTime).Value = expectedTimeTo;
            sqlCommmand.Parameters.Add(_ActualST, SqlDbType.DateTime).Value = actualTimeFrom;
            sqlCommmand.Parameters.Add(_ActualET, SqlDbType.DateTime).Value = actualTimeTo;
            sqlCommmand.Parameters.Add(_FromExpectCost, SqlDbType.Decimal).Value = expctedCostFrom;
            sqlCommmand.Parameters.Add(_ToExpectCost, SqlDbType.Decimal).Value = expectedCostTo;
            sqlCommmand.Parameters.Add(_FromActualCost, SqlDbType.Decimal).Value = actaulCostFrom;
            sqlCommmand.Parameters.Add(_ToActualCost, SqlDbType.Decimal).Value = actualCostTo;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseByCondition", sqlCommmand))
            {
                while (sdr.Read())
                {
                    Course course = new Course();
                    course.CourseID = Convert.ToInt32(sdr[_DBPKID]);
                    course.CourseName = sdr[_DBCourseName].ToString();
                    //course.Coordinator = _EmployeeDal.GetEmployeeByAccountID(Convert.ToInt32(sdr[_DBCoordinatorID]));
                    course.Coordinator = new Account();
                    course.Coordinator.Id = Convert.ToInt32(sdr[_DBCoordinatorID]);
                    course.Coordinator.Name = sdr[_DBCoordinatorName].ToString();
                    course.Scope = (TrainScopeEnum)sdr[_DBScope];
                    course.Status = (TrainStatusEnum)sdr[_DBStatus];
                    course.Trainer = sdr[_DBTrainer].ToString();
                    course.ExpectST = Convert.ToDateTime(sdr[_DBExpectST]);
                    course.ExpectET = Convert.ToDateTime(sdr[_DBExpectET]);
                    course.ActualST = Convert.ToDateTime(sdr[_DBActualST]);
                    course.ActualET = Convert.ToDateTime(sdr[_DBActualET]);
                    course.ExpectHour = Convert.ToDecimal(sdr[_DBExpectHour]);
                    course.ExpectCost = Convert.ToDecimal(sdr[_DBExpectCost]);
                    course.ActualHour = Convert.ToDecimal(sdr[_DBActualHour]);
                    course.ActualCost = Convert.ToDecimal(sdr[_DBActualCost]);
                    course.TrainPlace = sdr[_DBTrianPlace].ToString();
                    course.TrainFBResult = new TrainFBResult();
                    course.TrainFBResult.FBPaperItem = GetFBPaperItem(course.CourseID);
                    course.TrainFBResult.FeedBackCount = Convert.ToInt32(sdr[_DBFBCount]);
                    course.TrainFBResult.CourseScore = Convert.ToDecimal(sdr[_DBScore]);
                    courses.Add(course);
                }
            }
            return courses;
        }

        public List<Course> GetCourseTrainneeByCondition(int traineeID, int courseId,string courseName, string traineeName,
                                               int status, DateTime? startTime, DateTime? endTime)
        {
            List<Course> courses = new List<Course>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_TraineeID, SqlDbType.Int).Value = traineeID;
            sqlCommmand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommmand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = courseName;
            sqlCommmand.Parameters.Add(_TraineeName, SqlDbType.NVarChar, 50).Value = traineeName;
            sqlCommmand.Parameters.Add(_Status, SqlDbType.Int).Value = status;
            if (startTime == null)
            {
                sqlCommmand.Parameters.Add(_StartTime, SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                sqlCommmand.Parameters.Add(_StartTime, SqlDbType.DateTime).Value = startTime;
            }
            if (endTime == null)
            {
                sqlCommmand.Parameters.Add(_EndTime, SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                sqlCommmand.Parameters.Add(_EndTime, SqlDbType.DateTime).Value = endTime;
            }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseTraineeByCondition", sqlCommmand))
            {
                while (sdr.Read())
                {
                    Course course = new Course();
                    course.CourseID = Convert.ToInt32(sdr[_DBCourseID]);
                    course.CourseName = sdr[_DBCourseName].ToString();
                    course.ExpectST = Convert.ToDateTime(sdr[_DBExpectST]);
                    course.ExpectET = Convert.ToDateTime(sdr[_DBExpectET]);
                    course.TrainFBResult=new TrainFBResult();
                    course.TrainFBResult.TrainEmployeeFBs = new List<TrainEmployeeFB>();
                    TrainEmployeeFB employeeFb;
                    if (sdr[_DBFBTime] != DBNull.Value)
                    {
                        employeeFb = new TrainEmployeeFB(Convert.ToDateTime(sdr[_DBFBTime]), sdr[_DBSuggestion].ToString());
        
                    }
                    else
                    {
                        employeeFb = new TrainEmployeeFB(null, sdr[_DBSuggestion].ToString());
                    }
                    //employeeFb.Trainee = _EmployeeDal.GetEmployeeByAccountID(Convert.ToInt32(sdr[_DBTraineeID]));
                    employeeFb.Trainee = new Account();
                    employeeFb.Trainee.Id = Convert.ToInt32(sdr[_DBTraineeID]);
                    employeeFb.Trainee.Name = sdr[_DBTraineeName].ToString();
                    employeeFb.Score = Convert.ToDecimal(sdr[_DBTrainFBAllScore]);
                    if (sdr[_DBCertificationName] != DBNull.Value)
                    {
                        employeeFb.CertificationName = sdr[_DBCertificationName].ToString();
                    }
                    course.TrainFBResult.TrainEmployeeFBs.Add(employeeFb);
                    courses.Add(course);
                }
            }
            return courses;
        }

        #region insert
        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        private static int InsertCourse(Course course)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = course.CourseName;
            sqlCommand.Parameters.Add(_CoordinatorID, SqlDbType.Int).Value = course.Coordinator.Id;
            sqlCommand.Parameters.Add(_CoordinatorName, SqlDbType.NVarChar, 50).Value = course.Coordinator.Name;
            sqlCommand.Parameters.Add(_Scope, SqlDbType.Int).Value = course.Scope;
            sqlCommand.Parameters.Add(_Status, SqlDbType.Int).Value = course.Status;
            sqlCommand.Parameters.Add(_Trainer, SqlDbType.NVarChar, 50).Value = course.Trainer;
            sqlCommand.Parameters.Add(_ExpectST, SqlDbType.DateTime).Value = course.ExpectST;
            sqlCommand.Parameters.Add(_ExpectET, SqlDbType.DateTime).Value = course.ExpectET;
            sqlCommand.Parameters.Add(_ActualST, SqlDbType.DateTime).Value = course.ActualST;
            sqlCommand.Parameters.Add(_ActualET, SqlDbType.DateTime).Value = course.ActualET;
            sqlCommand.Parameters.Add(_ExpectHour, SqlDbType.Decimal).Value = course.ExpectHour;
            sqlCommand.Parameters.Add(_ActualHour, SqlDbType.Decimal).Value = course.ActualHour;
            sqlCommand.Parameters.Add(_ExpectCost, SqlDbType.Decimal).Value = course.ExpectCost;
            sqlCommand.Parameters.Add(_ActualCost, SqlDbType.Decimal).Value = course.ActualCost;
            sqlCommand.Parameters.Add(_TrianPlace, SqlDbType.NVarChar, 200).Value = course.TrainPlace;
            sqlCommand.Parameters.Add(_FBCount, SqlDbType.Int).Value = course.TrainFBResult.FeedBackCount;
            sqlCommand.Parameters.Add(_FeedBackPaperId, SqlDbType.Int).Value = course.CourseFeedBackPaper.FeedBackPaperId;
            sqlCommand.Parameters.Add(_HasCertification, SqlDbType.Int).Value = course.HasCertification; 
            if (course.Status == TrainStatusEnum.End)
            {
                sqlCommand.Parameters.Add(_Score, SqlDbType.Decimal).Value = course.TrainFBResult.CourseScore;
            }
            else
            {
                sqlCommand.Parameters.Add(_Score, SqlDbType.Decimal).Value = 0;
            }

            SqlHelper.ExecuteNonQueryReturnPKID("CourseInsert", sqlCommand, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新课程
        /// </summary>
        /// <param name="course"></param>
        private static void UpdateCourse(Course course)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Value = course.CourseID;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = course.CourseName;
            sqlCommand.Parameters.Add(_CoordinatorID, SqlDbType.Int).Value = course.Coordinator.Id;
            sqlCommand.Parameters.Add(_CoordinatorName, SqlDbType.NVarChar, 50).Value = course.Coordinator.Name;
            sqlCommand.Parameters.Add(_Scope, SqlDbType.Int).Value = course.Scope;
            sqlCommand.Parameters.Add(_Status, SqlDbType.Int).Value = course.Status;
            sqlCommand.Parameters.Add(_Trainer, SqlDbType.NVarChar, 50).Value = course.Trainer;
            sqlCommand.Parameters.Add(_ExpectST, SqlDbType.DateTime).Value = course.ExpectST;
            sqlCommand.Parameters.Add(_ExpectET, SqlDbType.DateTime).Value = course.ExpectET;
            sqlCommand.Parameters.Add(_ActualST, SqlDbType.DateTime).Value = course.ActualST;
            sqlCommand.Parameters.Add(_ActualET, SqlDbType.DateTime).Value = course.ActualET;
            sqlCommand.Parameters.Add(_ExpectHour, SqlDbType.Decimal).Value = course.ExpectHour;
            sqlCommand.Parameters.Add(_ActualHour, SqlDbType.Decimal).Value = course.ActualHour;
            sqlCommand.Parameters.Add(_ExpectCost, SqlDbType.Decimal).Value = course.ExpectCost;
            sqlCommand.Parameters.Add(_ActualCost, SqlDbType.Decimal).Value = course.ActualCost;
            sqlCommand.Parameters.Add(_TrianPlace, SqlDbType.NVarChar, 200).Value = course.TrainPlace;
            sqlCommand.Parameters.Add(_FBCount, SqlDbType.Int).Value = course.TrainFBResult.FeedBackCount;
            sqlCommand.Parameters.Add(_FeedBackPaperId, SqlDbType.Int).Value = course.CourseFeedBackPaper.FeedBackPaperId;
            sqlCommand.Parameters.Add(_HasCertification, SqlDbType.Int).Value = course.HasCertification;
            if (course.Status == TrainStatusEnum.End)
            {
                sqlCommand.Parameters.Add(_Score, SqlDbType.Decimal).Value = course.TrainFBResult.CourseScore;
            }
            else
            {
                sqlCommand.Parameters.Add(_Score, SqlDbType.Decimal).Value = 0;
            }
            SqlHelper.ExecuteNonQuery("CourseUpdate", sqlCommand);
        }

        /// <summary>
        /// 新增课程技能
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        /// <returns></returns>
        private static void InsertCourseSkill(Skill skill, int courseId, string courseName)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = courseName;
            sqlCommand.Parameters.Add(_SkillID, SqlDbType.Int).Value = skill.SkillID;
            sqlCommand.Parameters.Add(_SkillName, SqlDbType.NVarChar, 100).Value = skill.SkillName;
            SqlHelper.ExecuteNonQueryReturnPKID("CourseSkillInsert", sqlCommand, out pkid);
        }

        /// <summary>
        /// 新增课程培训人员
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        /// <param name="fb"></param>
        private static void InsertCourseTrainee(int courseId, string courseName, TrainEmployeeFB fb)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = courseName;
            sqlCommand.Parameters.Add(_TraineeID, SqlDbType.Int).Value = fb.Trainee.Id;
            sqlCommand.Parameters.Add(_TraineeName, SqlDbType.NVarChar, 50).Value = fb.Trainee.Name;
            sqlCommand.Parameters.Add(_FBTime, SqlDbType.DateTime).Value = fb.FBTime;
            sqlCommand.Parameters.Add(_TrainFBAllScore, SqlDbType.Decimal).Value = fb.Score;
            sqlCommand.Parameters.Add(_Suggestion, SqlDbType.Text).Value = fb.Remark;
            sqlCommand.Parameters.Add(_TrainFBStatus, SqlDbType.Int).Value = 1; //反馈
            sqlCommand.Parameters.Add(_CertificationName, SqlDbType.NVarChar, 50).Value = fb.CertificationName;
            SqlHelper.ExecuteNonQueryReturnPKID("CourseTraineeInsert", sqlCommand, out pkid);
        }

        /// <summary>
        /// 新增课程培训人员
        /// </summary>
        /// <param name="account"></param>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        private static void InsertCourseTraineeWithoutFb(Account account, int courseId, string courseName)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommand.Parameters.Add(_CourseName, SqlDbType.NVarChar, 200).Value = courseName;
            sqlCommand.Parameters.Add(_TraineeID, SqlDbType.Int).Value = account.Id;
            sqlCommand.Parameters.Add(_TraineeName, SqlDbType.NVarChar, 50).Value = account.Name;
            sqlCommand.Parameters.Add(_FBTime, SqlDbType.DateTime).Value = DBNull.Value;
            sqlCommand.Parameters.Add(_TrainFBAllScore, SqlDbType.Decimal).Value = 0;
            sqlCommand.Parameters.Add(_Suggestion, SqlDbType.Text).Value = DBNull.Value;
            sqlCommand.Parameters.Add(_TrainFBStatus, SqlDbType.Int).Value = 0;//未反馈
            sqlCommand.Parameters.Add(_CertificationName, SqlDbType.NVarChar, 50).Value = string.Empty;
            SqlHelper.ExecuteNonQueryReturnPKID("CourseTraineeInsert", sqlCommand, out pkid);
        }

        /// <summary>
        /// 新增课程反馈题目
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private static int InsertCourseFB(int courseId, FBPaperItem item)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommand.Parameters.Add(_FBQues, SqlDbType.NVarChar, 200).Value = item.FBQuestion;
            sqlCommand.Parameters.Add(_FBItems, SqlDbType.NVarChar, 2000).Value = item.FBQueItems;
            sqlCommand.Parameters.Add(_FBItemsScore, SqlDbType.NVarChar, 50).Value = item.Worths;
            SqlHelper.ExecuteNonQueryReturnPKID("CourseFBInsert", sqlCommand, out pkid);
            return pkid;
        }

        /// <summary>
        /// 新增课程培训人员反馈
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="item"></param>
        /// <param name="account"></param>
        private static void InsertCourseFBResult(int courseId, TraineeFBItem item, Account account)
        {
            int pkid;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommand.Parameters.Add(_CourseFBID, SqlDbType.Int).Value = item.FBPaperItemId;
            sqlCommand.Parameters.Add(_TraineeID, SqlDbType.Int).Value = account.Id;
            sqlCommand.Parameters.Add(_TraineeName, SqlDbType.NVarChar, 50).Value = account.Name;
            sqlCommand.Parameters.Add(_TraineeScore, SqlDbType.Int).Value = item.Grade;
            SqlHelper.ExecuteNonQueryReturnPKID("CourseFBResultInsert", sqlCommand, out pkid);
        }

        #endregion

        #region delete
        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="courseId"></param>
        private static void DeleteCourse(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = courseId;
            SqlHelper.ExecuteNonQuery("CourseDelete", cmd);
        }

        /// <summary>
        /// 删除课程反馈题目
        /// </summary>
        /// <param name="courseId"></param>
        private static void DeleteCourseFB(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            SqlHelper.ExecuteNonQuery("CourseFBDelete", cmd);
        }

        /// <summary>
        /// 删除课程反馈结果
        /// </summary>
        /// <param name="courseId"></param>
        private static void DeleteCourseFBResult(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            SqlHelper.ExecuteNonQuery("CourseFBResultDelete", cmd);
        }

        /// <summary>
        /// 删除课程技能
        /// </summary>
        /// <param name="courseId"></param>
        private static void DeleteCourseSkill(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            SqlHelper.ExecuteNonQuery("CourseSkillDelete", cmd);
        }

        /// <summary>
        /// 删除课程培训人员
        /// </summary>
        /// <param name="courseId"></param>
        private static void DeleteCourseTrainee(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            SqlHelper.ExecuteNonQuery("CourseTraineeDelete", cmd);
        }
        #endregion

        #region get

        private static List<FBPaperItem> GetFBPaperItem(int courseId)
        {
            List<FBPaperItem> items=new List<FBPaperItem>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseFBByCourseID", sqlCommmand))
            {
                while (sdr.Read())
                {
                    FBPaperItem item = new FBPaperItem();
                    item.FBPaperItemId = (Int32)sdr[_DBPKID];
                    item.FBQuestion = sdr[_DBFBQues].ToString();
                    item.FBQueItems = sdr[_DBFBItems].ToString();
                    item.Worths = sdr[_DBFBItemsScore].ToString();
                    items.Add(item);
                }
            }
            return items;
        }

        private static List<Skill> GetCourseSkill(int courseId)
        {
            List<Skill> skills = new List<Skill>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseSkillByCourseID", sqlCommmand))
            {
                while (sdr.Read())
                {
                    Skill skill = new Skill((Int32)sdr[_DBSkillID], sdr[_DBSkillName].ToString(),null);
                    skills.Add(skill);
                }
            }
            return skills;
        }

        private List<TrainEmployeeFB> GetCourseTrainnee(int courseId)
        {
            List<TrainEmployeeFB> trainees = new List<TrainEmployeeFB>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseTraineeByCourseID", sqlCommmand))
            {
                while (sdr.Read())
                {
                    TrainEmployeeFB employeeFB;
                    if (sdr[_DBFBTime] == DBNull.Value)
                    {
                        employeeFB = new TrainEmployeeFB(null, sdr[_DBSuggestion].ToString());
                    }
                    else
                    {
                        employeeFB = new TrainEmployeeFB(Convert.ToDateTime(sdr[_DBFBTime]),
                                                         sdr[_DBSuggestion].ToString());
                    }
                    employeeFB.TrainEmployeeFBID = Convert.ToInt32(sdr[_DBPKID]);
                    //employeeFB.Trainee = _EmployeeDal.GetEmployeeByAccountID(Convert.ToInt32(sdr[_DBTraineeID]));
                    employeeFB.Trainee = new Account();
                    employeeFB.Trainee.Id = Convert.ToInt32(sdr[_DBTraineeID]);
                    employeeFB.Trainee.Name = sdr[_DBTraineeName].ToString();
                    employeeFB.Score = Convert.ToDecimal(sdr[_DBTrainFBAllScore]);
                    if (sdr[_DBCertificationName] != DBNull.Value)
                    {
                        employeeFB.CertificationName = sdr[_DBCertificationName].ToString();
                    }

                    trainees.Add(employeeFB);
                }
            }
            return trainees;
        }

        private static List<TraineeFBItem> GetEmployeeFBItem(int trainneeId,int courseId)
        {
            List<TraineeFBItem> fbItems = new List<TraineeFBItem>();
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_CourseID, SqlDbType.Int).Value = courseId;
            sqlCommmand.Parameters.Add(_TraineeID, SqlDbType.Int).Value = trainneeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetCourseFBResultByCourseIDAndTraineeID", sqlCommmand))
            {
                while (sdr.Read())
                {
                    TraineeFBItem item = new TraineeFBItem();
                    item.Grade = Convert.ToInt32(sdr[_DBTraineeScore]);
                    item.FBPaperItemId = Convert.ToInt32(sdr[_DBCourseFBID]);
                    fbItems.Add(item);
                }
            }
            return fbItems;
        }

        public int GetTrainCourseBySkillID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SkillID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetTrainCourseBySkillID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        #endregion
    }
}
