//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AddCourseSendMailTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-07
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.TrainTest
{
    [TestFixture]
    public class AddCourseSendMailTest
    {
        [Test]
        public void AddCourseFeedBackSuccess()
        {
            MockRepository mocks = new MockRepository();
            IMailGateWay iMailGateWay = (IMailGateWay)mocks.CreateMock(typeof(IMailGateWay));
            IAccountBll iAccountBll = (IAccountBll)mocks.DynamicMock(typeof(IAccountBll));

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
            course.TrainFBResult = new TrainFBResult();
            course.TrainFBResult.TrainEmployeeFBs = new List<TrainEmployeeFB>();
            course.TrainFBResult.TrainEmployeeFBs.Add(fb);
            mocks.ReplayAll();
            AddCourseSendMail target = new AddCourseSendMail(employees,course,iMailGateWay,iAccountBll);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}