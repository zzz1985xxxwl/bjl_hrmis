//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddCourseFeedBackTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: ����������ѵ����
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
    public class AddCourseFeedBackTest
    {
        [Test, Description("��������")]
        public void AddCourseFeedBackSuccess()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            //Employee condinator = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            ////condinator.Account.Name = "condinator";
            Account condinator = new Account(1, "condinator", "condinator");
            Course course = new Course("course", condinator, TrainScopeEnum.InnerTrain, TrainStatusEnum.Start, "trainer");
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
            employees.Add(condinator);

            TrainEmployeeFB fb = new TrainEmployeeFB(Convert.ToDateTime("2008-01-01"), string.Empty);
            fb.Trainee = condinator;
            fb.Score = 3;
            course.TrainFBResult =new TrainFBResult();
            course.TrainFBResult.TrainEmployeeFBs=new List<TrainEmployeeFB>();
            course.TrainFBResult.TrainEmployeeFBs.Add(fb);
           
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course);

            Expect.Call(delegate { iTrain.UpdateTrainCourse(course); });
            mocks.ReplayAll();

            AddCourseFeedBack target = new AddCourseFeedBack(course.CourseID,fb, iTrain);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�����Ŀγ̲�����")]
        [ExpectedException(typeof(ApplicationException))]
        public void FeedBackCourseTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            //Employee condinator = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            //condinator.Account.Name = "condinator";
            Account condinator = new Account(1, "condinator", "condinator");
            Course course = new Course("course", condinator, TrainScopeEnum.InnerTrain, TrainStatusEnum.Start, "trainer");
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
            employees.Add(condinator);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(null);
            mocks.ReplayAll();
            TrainEmployeeFB fb = new TrainEmployeeFB(Convert.ToDateTime("2008-01-01"), string.Empty);
            fb.Trainee = condinator;
            fb.Score = 3;
            AddCourseFeedBack target = new AddCourseFeedBack(course.CourseID, fb, iTrain);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�����Ŀγ��ѽ���")]
        [ExpectedException(typeof(ApplicationException))]
        public void FeedBackCourseAlreadyEndTest()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            //Employee condinator = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            //condinator.Account.Name = "condinator";
            Account condinator = new Account(1, "condinator", "condinator");
            Course course = new Course("course", condinator, TrainScopeEnum.InnerTrain, TrainStatusEnum.End, "trainer");
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
            employees.Add(condinator);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course);
            mocks.ReplayAll();
            TrainEmployeeFB fb = new TrainEmployeeFB(Convert.ToDateTime("2008-01-01"), string.Empty);
            fb.Trainee = condinator;
            fb.Score = 3;
            AddCourseFeedBack target = new AddCourseFeedBack(course.CourseID, fb, iTrain);
            target.Excute();
            mocks.VerifyAll();

        }

    }
}
