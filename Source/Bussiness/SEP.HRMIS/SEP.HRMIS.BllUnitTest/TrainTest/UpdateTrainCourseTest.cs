//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateTrainCourseTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: ���Ը�����ѵ�γ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class UpdateTrainCourseTest
    {
        private Account _LoginUser;
        [SetUp]
        public void SetUp()
        {
            _LoginUser = new Account(2, "loginUser", "loginUser");
            Auth trainAuth = new Auth(801, "��ѵ�γ̹���");
            trainAuth.Type = AuthType.HRMIS;
            _LoginUser.Auths = new List<Auth>();
            _LoginUser.Auths.Add(trainAuth);
        }

        [Test,Description("�޸Ŀγ̵Ļ�����Ϣ")]
        public void UpdateCourseTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();
            
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
            course.CourseFeedBackPaper = new FeedBackPaper();
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            paper.FBQuestions = questtions;
            course.CourseFeedBackPaper = paper;
            List<Account> employees = new List<Account>();
            employees.Add(account);
            Expect.Call(dalAccountBll.GetAccountByName("condinator")).Return(account);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course).Repeat.Twice();

            Expect.Call(delegate { iTrain.UpdateTrainCourse(course); });
            mocks.ReplayAll();

            UpdateTrainCourse target = new UpdateTrainCourse(course, skills, employees, iTrain, iEmployee, dalAccountBll, _LoginUser);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�޸ĵĿγ̲�����")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCourseTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();
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

            UpdateTrainCourse target = new UpdateTrainCourse(course, skills, employees, iTrain, iEmployee, dalAccountBll, _LoginUser);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸ĵĿγ��ѽ���")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCourseAlreadyEndTest()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();
            Account account = new Account(1, "condinator", "condinator");
            Course course = new Course("course", account, TrainScopeEnum.InnerTrain, TrainStatusEnum.End, "trainer");
            course.CourseID = 2;
            FeedBackPaper paper=new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            course.CourseFeedBackPaper = paper;
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

            UpdateTrainCourse target = new UpdateTrainCourse(course, skills, employees, iTrain, iEmployee, dalAccountBll,
                                                             _LoginUser);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�޸ĵĿγ��ѽ���")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateCourseCondinatorNullTest()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();
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

            course.CourseFeedBackPaper = new FeedBackPaper();
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            paper.FBQuestions = questtions;
            course.CourseFeedBackPaper = paper;
            List<Account> employees = new List<Account>();
            employees.Add(account);
            Expect.Call(dalAccountBll.GetAccountByName("condinator")).Return(null);
            Expect.Call(iTrain.GetTrainCourseByPKID(course.CourseID)).Return(course);

            Expect.Call(delegate { iTrain.UpdateTrainCourse(course); });
            mocks.ReplayAll();

            UpdateTrainCourse target = new UpdateTrainCourse(course, skills, employees, iTrain, iEmployee, dalAccountBll, _LoginUser);
            target.Excute();
            mocks.VerifyAll();

        }
        
    }
}
