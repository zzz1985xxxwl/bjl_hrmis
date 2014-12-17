//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AddAdjustRuleTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-06
// Resume: 
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AdjustRules;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.BllUnitTest.AdjustRuleTest
{
    [TestFixture]
    public class AddAdjustRuleTest
    {
        private AddAdjustRule _TheTarget;
        private MockRepository _Mock;
        private IAdjustRule _IAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _IAdjustRule = (IAdjustRule)_Mock.CreateMock(typeof(IAdjustRule));
        }

        [Test, Description("新增,成功")]
        public void Test1()
        {
            AdjustRule adjustRule = new AdjustRule(1, "123", 1, 2, 3, 4, 5, 6);
            Expect.Call(_IAdjustRule.CountAdjustRuleByNameDiffPKID("123",0)).Return(0);
            Expect.Call(_IAdjustRule.InsertAdjustRule(adjustRule)).Return(1);
            _Mock.ReplayAll();
           _TheTarget=new AddAdjustRule(adjustRule,_IAdjustRule);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test]
        public void Test2()
        {
            AdjustRule adjustRule = new AdjustRule(1, "123", 1, 2, 3, 4, 5, 6);
            Expect.Call(_IAdjustRule.CountAdjustRuleByNameDiffPKID("123", 0)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new AddAdjustRule(adjustRule,_IAdjustRule);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("调休规则名称重复", expection);
            _Mock.VerifyAll();
           
        }

    }
}