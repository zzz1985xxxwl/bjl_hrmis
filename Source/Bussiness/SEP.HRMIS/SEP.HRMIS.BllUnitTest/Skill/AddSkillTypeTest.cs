//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddSkillType.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 测试新增技能类型
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Parameter
{
    [TestFixture]
    public class AddSkillTypeTest
    {
        [Test, Description("新增技能类型的基本信息")]
        public void AddSkillTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            SkillType skillType = new SkillType(1, "codeing");
            Expect.Call(iSkillType.CountSkillTypeByName("codeing")).Return(0);
            Expect.Call(iSkillType.InsertSkillType(skillType)).Return(1);
            mocks.ReplayAll();

            AddSkillType target = new AddSkillType(skillType, iSkillType);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("新增技能类型名字存在")]
        public void AddSkillTypeTestNameExist()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            SkillType skillType = new SkillType(1, "codeing");

            Expect.Call(iSkillType.CountSkillTypeByName("codeing")).Return(1);
            mocks.ReplayAll();

            AddSkillType target = new AddSkillType(skillType, iSkillType);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "技能类型名称不能重复");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
