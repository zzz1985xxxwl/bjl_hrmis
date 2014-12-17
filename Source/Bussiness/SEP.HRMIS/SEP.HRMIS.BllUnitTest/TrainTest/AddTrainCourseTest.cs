//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddTrainCourseTest.cs
// 创建者: 刘丹
// 创建日期: 2008-11-13
// 概述: 测试新增培训课程
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
    public class AddTrainCourseTest
    {
        private Account _LoginUser;
        [SetUp]
        public void SetUp()
        {
            _LoginUser = new Account(2, "loginUser", "loginUser");
            Auth trainAuth = new Auth(801, "培训课程管理");
            trainAuth.Type = AuthType.HRMIS;
            _LoginUser.Auths = new List<Auth>();
            _LoginUser.Auths.Add(trainAuth);
        }

        [Test, Description("新增培训课程的基本信息")]
        public void AddTrainCourseTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IFeedBackPaper ipaper = (IFeedBackPaper)mocks.CreateMock(typeof(IFeedBackPaper));
                    //IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));
                    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
                    IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();

            Account condinator = new Account(1, "condinator", "condinator");
            Course course=new Course("course",condinator,TrainScopeEnum.InnerTrain,TrainStatusEnum.Start,"trainer");
            course.CourseFeedBackPaper=new FeedBackPaper();
            FeedBackPaper paper = new FeedBackPaper();
            List<Skill> skills=new List<Skill>();
            Skill skill = new Skill(1, "C#", null);
            skills.Add(skill);

            TrainFBItem item=new TrainFBItem(1,"item1",1);
                        TrainFBItem item2=new TrainFBItem(1,"item2",2);
            List<TrainFBItem> items=new List<TrainFBItem>();
            items.Add(item);
                     items.Add(item2);
            TrainFBQuestion ques=new TrainFBQuestion(1,"ques",null,items);
            List<TrainFBQuestion>  questtions=new List<TrainFBQuestion>();
            questtions.Add(ques);

            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            paper.FBQuestions = questtions;
            course.CourseFeedBackPaper = paper;
            List<Account> employees=new List<Account>();
            employees.Add(condinator);
            Expect.Call(dalAccountBll.GetAccountByName("condinator")).Return(condinator);
            Expect.Call(ipaper.GetFeedBackPaperById(1)).Return(paper);
            Expect.Call(delegate { iTrain.InsertTrainCourse(course); });
            mocks.ReplayAll();

            AddTrainCourse target = new AddTrainCourse(course, skills, employees, iTrain, ipaper, iEmployee, dalAccountBll, _LoginUser);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("协调员不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void AddTrainCondinatorNotExist()
        {
            MockRepository mocks = new MockRepository();
            ITrain iTrain = (ITrain)mocks.CreateMock(typeof(ITrain));
            IFeedBackPaper ipaper = (IFeedBackPaper)mocks.CreateMock(typeof(IFeedBackPaper));
            //IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();
            Account condinator = new Account(1, "condinator", "condinator");
            Course course = new Course("course", condinator, TrainScopeEnum.InnerTrain, TrainStatusEnum.Start, "trainer");
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
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            paper.FBQuestions = questtions;
            List<Account> employees = new List<Account>();
            employees.Add(condinator);
            Expect.Call(dalAccountBll.GetAccountByName("condinator")).Return(null);
            //Expect.Call(iFBQuestion.GetFBQuestionByConditon(string.Empty, -1)).Return(questtions);
            Expect.Call(ipaper.GetFeedBackPaperById(1)).Return(paper);
            Expect.Call(delegate { iTrain.InsertTrainCourse(course); });
            mocks.ReplayAll();

            AddTrainCourse target = new AddTrainCourse(course, skills, employees, iTrain, ipaper, iEmployee, dalAccountBll, _LoginUser);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
