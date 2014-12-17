//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddSkillType.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 测试删除技能类型
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Parameter
{
    [TestFixture]
    public class DeleteSkillTypeTest
    {
        [Test, Description("删除技能类型")]
        public void DeleteSkillTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));

            SkillType skillType = new SkillType(1, "codingtest");

            Expect.Call(iSkillType.GetSkillTypeByPkid(1)).Return(skillType);
            Expect.Call(iSkill.GetSkillByCondition("",skillType.ParameterID)).Return(new List<Skill>());

            Expect.Call(iSkillType.DeleteSkillType(skillType.ParameterID)).Return(1);
            mocks.ReplayAll();

            DeleteSkillType target = new DeleteSkillType(skillType.ParameterID, iSkillType, iSkill);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("删除的技能类型不存在")]
        public void DeleteSkillTypeTestSkillTypeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));

            SkillType skillType = new SkillType(1, "codingtest");

            //要删除的合同类型不存在
            Expect.Call(iSkillType.GetSkillTypeByPkid(1)).Return(null);
            mocks.ReplayAll();

            DeleteSkillType target = new DeleteSkillType(skillType.ParameterID, iSkillType, iSkill);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "不存在该技能类型");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("删除已使用的技能类型")]
        public void DeleteSkillTypeTestUsingSkillType()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));

            SkillType skillType = new SkillType(1, "codingtest");
            List<Skill> Skills = new List<Skill>();
            Skills.Add(new Skill(1, "c#", skillType));
            Skills.Add(new Skill(1, "java", skillType));

            Expect.Call(iSkillType.GetSkillTypeByPkid(1)).Return(skillType);
            Expect.Call(iSkill.GetSkillByCondition("",skillType.ParameterID)).Return(Skills);

            mocks.ReplayAll();

            DeleteSkillType target = new DeleteSkillType(skillType.ParameterID, iSkillType, iSkill);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "还有属于该类型的技能");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
