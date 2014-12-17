//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseDataBinder.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述:培训课程绑定数据
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseDataBinder
    {
        private readonly ICourseView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();

        public CourseDataBinder(ICourseView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(string courseId)
        {
            int _courseId;
            if (!int.TryParse(courseId, out _courseId))
            {
                _ItsView.Message = CourseUtility._InitError;
                return false;
            }

            Course course = _ITrainFacade.GetTrainCourseByPKID(_courseId);
            if (course != null)
            {
                _ItsView.CourseName = course.CourseName;
                _ItsView.Place = course.TrainPlace; 
                _ItsView.Coordinator = course.Coordinator.Name;
                _ItsView.Trainer = course.Trainer;

                _ItsView.TrainScope = Convert.ToInt32(course.Scope).ToString();
                _ItsView.TrainStatus = Convert.ToInt32(course.Status).ToString();

                List<Account> employeeList = new List<Account>();
                foreach (TrainEmployeeFB employee in course.TrainFBResult.TrainEmployeeFBs)
                {
                    employeeList.Add(employee.Trainee);
                }
                _ItsView.EmployeeList = employeeList;
                _ItsView.ChoosedEmployees = RequestUtility.GetEmployeeNames(_ItsView.EmployeeList);
                List<Skill> skilllist = new List<Skill>();
                foreach (Skill skill in course.Skill)
                {
                    skilllist.Add(skill);
                }
                _ItsView.SkillList = skilllist;
                _ItsView.ChoosedSkills = GetSkillNames(_ItsView.SkillList);

                _ItsView.ExpectST = course.ExpectST.ToShortDateString();
                _ItsView.ExpectET = course.ExpectET.ToShortDateString();
                _ItsView.ExpectCost = course.ExpectCost.ToString();
                _ItsView.ExpectHour = course.ExpectHour.ToString();
                _ItsView.ActualST = course.ActualST.ToShortDateString();
                _ItsView.ActualET = course.ActualET.ToShortDateString();
                _ItsView.ActualCost = course.ActualCost.ToString();
                _ItsView.ActualHour = course.ActualHour.ToString();
                _ItsView.PaperId = course.CourseFeedBackPaper.FeedBackPaperId;
                _ItsView.HasCertifaction = course.HasCertification.Equals(1);
                return true;
            }
            _ItsView.Message = CourseUtility._InitError;
            return false;
        }

        private static string GetSkillNames(List<Skill> skillList)
        {
            StringBuilder skills = new StringBuilder();
            if (skillList != null)
            {
                int count = skillList.Count;
                for (int i = 0; i < count; i++)
                {
                    skills.Append(skillList[i].SkillName);
                    if (i < count - 1) skills.Append("，");
                }
            }
            return skills.ToString();
        }

        ///// <summary>
        ///// use for test
        ///// </summary>
        //public IGetTrainCourse GetTrainCouse
        //{
        //    set { _GetTrainCourse = value; }
        //}

    }
}
