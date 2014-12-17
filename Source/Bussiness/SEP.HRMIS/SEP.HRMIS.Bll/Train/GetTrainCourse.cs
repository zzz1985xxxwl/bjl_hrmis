//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetTrainCourse.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 查询课程
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll
{
    public class GetTrainCourse
    {
        private static readonly ITrain _dalTrain = DalFactory.DataAccess.CreateTrain();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private int _EmployeeId;

        public Course GetTrainCourseByPKID(int pkid)
        {
            // GetEmployeeNameInCourse(_dalTrain.GetTrainCourseByPKID(pkid));
            return _dalTrain.GetTrainCourseByPKID(pkid);
        }

        public List<Course> GetCourseByConditon(string courseName, string coordinator, int scope, int status, string trainer, string trainee,
            string skillName, DateTime expectedTimeFrom, DateTime expectedTimeTo, DateTime actualTimeFrom, DateTime actualTimeTo,
            decimal expctedCostFrom, decimal expectedCostTo, decimal actaulCostFrom, decimal actualCostTo, Account loginUser)
        {
            List<Course> returnCourse=new List<Course>();
            //协调员账号
            List<Account> coordinatorList = _IAccountBll.GetAccountByBaseCondition(coordinator, -1, -1,null, false, null);
            coordinatorList = Tools.RemoteUnAuthAccount(coordinatorList, AuthType.HRMIS, loginUser, HrmisPowers.A801);
            if (coordinatorList.Count == 0)
            {
                return returnCourse;
            }
            //培训人员查询

            List<Account> traineeList = _IAccountBll.GetAccountByBaseCondition(trainee, -1, -1, null, false, null);
            traineeList = Tools.RemoteUnAuthAccount(traineeList, AuthType.HRMIS, loginUser, HrmisPowers.A801);
            if(traineeList.Count==0)
            {
                return returnCourse;
            }
            List<Course> courses = _dalTrain.GetCourseByConditon(courseName, coordinator, scope, status, trainer, trainee,
                                                 skillName, expectedTimeFrom, expectedTimeTo, actualTimeFrom,
                                                 actualTimeTo,
                                                 expctedCostFrom, expectedCostTo, actaulCostFrom, actualCostTo);
            foreach (Course course in courses)
            {
                //查找课程中是否包含不被管理的协调员
                Course newcourse = GetTrainCourseByPKID(course.CourseID);
                List<int> coordinatorListid = new List<int>();
                foreach (Account account in coordinatorList)
                {
                    coordinatorListid.Add(account.Id);
                }
                if (!coordinatorListid.Contains(course.Coordinator.Id))
                {
                    break;
                }
                //查找课程中是否包含不被管理的培训人员
                List<int> traineeListid = new List<int>();
                foreach (Account account in traineeList)
                {
                    traineeListid.Add(account.Id);
                }
                bool isFind = true;
                for (int i = 0; i < newcourse.TrainFBResult.TrainEmployeeFBs.Count; i++)
                {
                    if (traineeListid.Contains(newcourse.TrainFBResult.TrainEmployeeFBs[i].Trainee.Id))
                    {
                        isFind = false;
                        break;
                    }

                }
                if (!isFind)
                    course.TrainFBResult = newcourse.TrainFBResult;
                    returnCourse.Add(course);
            }


            return returnCourse;
        }

        public List<Course> GetCourseTrainneeByCondition(int traineeID,int courseId, string courseName, string traineeName,
                                               int status, DateTime? startTime, DateTime? endTime)
        {
             return _dalTrain.GetCourseTrainneeByCondition(traineeID, courseId, courseName, traineeName,
                                                status,  startTime,  endTime);
            
        }

        public List<TrainEmployeeFB>  GetTrainEmployeeFB(int traineeID,int courseId, string courseName, string traineeName,
                                               int status, DateTime? startTime, DateTime? endTime, Account loginUser,bool isMyFB)
        {
            List<Course> courses = GetCourseTrainneeByCondition(traineeID, courseId, courseName, traineeName, status,
                                                  startTime, endTime);

            List<TrainEmployeeFB> fbs = new List<TrainEmployeeFB>();
            List<Account> traineeList = _IAccountBll.GetAccountByBaseCondition(traineeName, -1, -1, null, false, null);
            if (!isMyFB)
            {
                traineeList = Tools.RemoteUnAuthAccount(traineeList, AuthType.HRMIS, loginUser, HrmisPowers.A802);
            }
            
            if (traineeList.Count == 0)
            {
                return fbs;
            }
            foreach (Course course in courses)
            {
                course.TrainFBResult.TrainEmployeeFBs[0].CourseId = course.CourseID;
                course.TrainFBResult.TrainEmployeeFBs[0].CourseName = course.CourseName;
                //course.TrainFBResult.TrainEmployeeFBs[0].Trainee.Name =
                //        _IAccountBll.GetAccountById(course.TrainFBResult.TrainEmployeeFBs[0].Trainee.Id).Name;
                course.TrainFBResult.TrainEmployeeFBs[0].CourseExpectST = course.ExpectST;
                course.TrainFBResult.TrainEmployeeFBs[0].CourseExpectET = course.ExpectET;
                List<int> traineeListid = new List<int>();
                foreach (Account account in traineeList)
                {
                    traineeListid.Add(account.Id);
                }

                if (traineeListid.Contains(course.TrainFBResult.TrainEmployeeFBs[0].Trainee.Id))
                {

                    fbs.Add(course.TrainFBResult.TrainEmployeeFBs[0]);
                }
            }
            return fbs;
        }
        
        /// <summary>
        /// 显示某个员工反馈项
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public List<TraineeFBItem> GetTraineeFBItems(int courseId,int employeeId)
        {
            _EmployeeId = employeeId;
            Course temp = GetTrainCourseByPKID(courseId);
            TrainEmployeeFB employeeFb = temp.TrainFBResult.TrainEmployeeFBs.Find(FindEmployeeFB);
            if (employeeFb.FBItem.Count == 0 || employeeFb.FBItem == null)
            {
                foreach (FBPaperItem item in temp.TrainFBResult.FBPaperItem)
                {
                    TraineeFBItem traineeItem = new TraineeFBItem();
                    traineeItem.FBPaperItemId = item.FBPaperItemId;
                    traineeItem.FBQuestion = item.FBQuestion;
                    traineeItem.FBQueItems = item.FBQueItems;
                    traineeItem.Worths = item.Worths;
                    employeeFb.FBItem.Add(traineeItem);
                }
            }
            else
            {
                foreach (FBPaperItem item in temp.TrainFBResult.FBPaperItem)
                {
                    foreach (TraineeFBItem traineeItem in employeeFb.FBItem)
                    {
                        if (traineeItem.FBPaperItemId == item.FBPaperItemId)
                        {
                            traineeItem.FBQuestion = item.FBQuestion;
                            traineeItem.FBQueItems = item.FBQueItems;
                            traineeItem.Worths = item.Worths;
                        }
                    }
                }
            }
            return employeeFb.FBItem;
        }

        private bool FindEmployeeFB(TrainEmployeeFB fb)
        {
            return fb.Trainee.Id.Equals(_EmployeeId);
        }

        private Course GetEmployeeNameInCourse(Course course)
        {
            course.Coordinator.Name = _IAccountBll.GetAccountById(course.Coordinator.Id).Name;
            if (course.TrainFBResult.TrainEmployeeFBs != null)
            {
                for (int i = 0; i < course.TrainFBResult.TrainEmployeeFBs.Count; i++)
                {
                    course.TrainFBResult.TrainEmployeeFBs[i].Trainee.Name =
                        _IAccountBll.GetAccountById(course.TrainFBResult.TrainEmployeeFBs[i].Trainee.Id).Name;
                }
            }
            return course;
        }

    }
}
