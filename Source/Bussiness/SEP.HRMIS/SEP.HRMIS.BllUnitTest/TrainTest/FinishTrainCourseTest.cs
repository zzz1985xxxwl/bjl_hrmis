//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddCourseFeedBackTest.cs
// 创建者: 刘丹
// 创建日期: 2008-11-19
// 概述: 测试结束培训课程
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class FinishTrainCourseTest
    {
        [Test, Description("结束课程测试")]
        public void FinishTrainCourseSuccess()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Account account = new Account(1, "condinator", "condinator");
            Employee condinator = new Employee(account.Id, EmployeeTypeEnum.NormalEmployee);
            //condinator.Account.Name = "condinator";
            condinator.EmployeeSkills=new List<EmployeeSkill>();
            Course course = new Course("course", account, TrainScopeEnum.InnerTrain, TrainStatusEnum.Start, "trainer");
            course.CourseID = 2;

            Skill skill = new Skill(1, "C#", null);
            course.Skill=new List<Skill>();
            course.Skill.Add(skill);

            TrainFBItem item = new TrainFBItem(1, "item1", 1);
            TrainFBItem item2 = new TrainFBItem(1, "item2", 2);
            List<TrainFBItem> items = new List<TrainFBItem>();
            items.Add(item);
            items.Add(item2);
            TrainFBQuestion ques = new TrainFBQuestion(1, "ques", null, items);
            List<TrainFBQuestion> questtions = new List<TrainFBQuestion>();
            questtions.Add(ques);

            List<Account> employees = new List<Account>();
            employees.Add(account);

            TrainEmployeeFB fb = new TrainEmployeeFB(Convert.ToDateTime("2008-01-01"), string.Empty);
            fb.Trainee = account;
            fb.Score = 3;
            course.TrainFBResult = new TrainFBResult();
            course.TrainFBResult.TrainEmployeeFBs = new List<TrainEmployeeFB>();
            course.TrainFBResult.TrainEmployeeFBs.Add(fb);

            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course);

            Expect.Call(iEmployeeSkill.GetEmployeeSkillByAccountID(condinator.Account.Id, string.Empty, -1, SkillLevelEnum.All)).Return(condinator);

            Expect.Call(delegate { iEmployeeSkill.UpdateEmployeeSkill(condinator); });

            Expect.Call(delegate { iTrain.UpdateTrainCourse(course); });
            mocks.ReplayAll();

            FinishTrainCourse target = new FinishTrainCourse(course.CourseID, iTrain,iEmployeeSkill);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(course.Status,TrainStatusEnum.End);

        }

        [Test, Description("结束的课程不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCourseTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Account account = new Account(1, "condinator", "condinator");
            Course course = new Course("course", account, TrainScopeEnum.InnerTrain, TrainStatusEnum.Start, "trainer");
            course.CourseID = 2;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill(1, "C#", null);
            skills.Add(skill);

            TrainFBItem item = new TrainFBItem(1, "item1", 1);
            TrainFBItem item2 = new TrainFBItem(1, "item2", 2);
            List<TrainFBItem> items = new List<TrainFBItem>();
            items.Add(item);
            items.Add(item2);
            TrainFBQuestion ques = new TrainFBQuestion(1, "ques", null, items);
            List<TrainFBQuestion> questtions = new List<TrainFBQuestion>();
            questtions.Add(ques);
            List<Account> employees = new List<Account>();
            employees.Add(account);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(null);
            mocks.ReplayAll();

            FinishTrainCourse target = new FinishTrainCourse(course.CourseID, iTrain, iEmployeeSkill);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("结束课程已结束")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCourseAlreadyEndTest()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Account account = new Account(1, "condinator", "condinator");
            Course course = new Course("course", account, TrainScopeEnum.InnerTrain, TrainStatusEnum.End, "trainer");
            course.CourseID = 2;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill(1, "C#", null);
            skills.Add(skill);

            TrainFBItem item = new TrainFBItem(1, "item1", 1);
            TrainFBItem item2 = new TrainFBItem(1, "item2", 2);
            List<TrainFBItem> items = new List<TrainFBItem>();
            items.Add(item);
            items.Add(item2);
            TrainFBQuestion ques = new TrainFBQuestion(1, "ques", null, items);
            List<TrainFBQuestion> questtions = new List<TrainFBQuestion>();
            questtions.Add(ques);
            List<Account> employees = new List<Account>();
            employees.Add(account);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course);
            mocks.ReplayAll();

            FinishTrainCourse target = new FinishTrainCourse(course.CourseID, iTrain, iEmployeeSkill);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
