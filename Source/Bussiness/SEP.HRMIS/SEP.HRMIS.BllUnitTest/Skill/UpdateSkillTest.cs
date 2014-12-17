//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkillTest.cs
// 创建者: 张珍
// 创建日期: 2008-11-07
// 概述: 测试更新技能
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
   public class UpdateSkillTest
    {

        [Test, Description("修改技能的基本信息")]
        public void UpdateSkillTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, ".net编程", null);
            skill.SkillType = new SkillType(1,"编码");
            Expect.Call(iSkill.GetSkillByPKID(skill.SkillID)).Return(skill);
            Expect.Call(iSkill.CountSkillByNameDiffPKID(skill.SkillID,skill.SkillName)).Return(0);
            Expect.Call(iSkill.UpdateSkill(skill)).Return(1);
            mocks.ReplayAll();

            UpdateSkill target = new UpdateSkill(skill, iSkill);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("修改技能不存在")]
        public void UpdateSkillSkillNotExist()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, "万能通",null);

            Expect.Call(iSkill.GetSkillByPKID(skill.SkillID)).Return(null);
            mocks.ReplayAll();

            UpdateSkill target = new UpdateSkill(skill, iSkill);
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

        [Test, Description("修改技能名字重复")]
        public void UpdateSkillSkillNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, ".net编程", null);
            skill.SkillType = new SkillType(1, "编码");

            Expect.Call(iSkill.GetSkillByPKID(skill.SkillID)).Return(skill);
            Expect.Call(iSkill.CountSkillByNameDiffPKID(skill.SkillID, skill.SkillName)).Return(1);
            mocks.ReplayAll();

            UpdateSkill target = new UpdateSkill(skill, iSkill);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "技能名称不能重复");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
