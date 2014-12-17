//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteAdjustRuleTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-06
// Resume: 
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AdjustRules;
using SEP.HRMIS.IDal;
namespace SEP.HRMIS.BllUnitTest.AdjustRuleTest
{
    [TestFixture]
    public class DeleteAdjustRuleTest
    {
        private DeleteAdjustRule _TheTarget;
        private MockRepository _Mock;
        private IAdjustRule _IAdjustRule;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _IAdjustRule = (IAdjustRule)_Mock.CreateMock(typeof(IAdjustRule));
            _IEmployeeAdjustRule = (IEmployeeAdjustRule)_Mock.CreateMock(typeof(IEmployeeAdjustRule));
        }

        [Test, Description("新增,成功")]
        public void Test1()
        {
            Expect.Call(_IEmployeeAdjustRule.CountAdjustRuleUsedByAdjustRuleID(1)).Return(0);
            Expect.Call(_IAdjustRule.DeleteAdjustRule(1)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new DeleteAdjustRule(1, _IEmployeeAdjustRule, _IAdjustRule);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test]
        public void Test2()
        {
            Expect.Call(_IEmployeeAdjustRule.CountAdjustRuleUsedByAdjustRuleID(1)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new DeleteAdjustRule(1, _IEmployeeAdjustRule, _IAdjustRule);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("调休规则正被使用，无法删除", expection);
            _Mock.VerifyAll();

        }
    }
}