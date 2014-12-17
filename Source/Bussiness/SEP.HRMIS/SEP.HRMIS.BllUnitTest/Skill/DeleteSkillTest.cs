//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteSkillTest.cs
// 创建者: 张珍
// 创建日期: 2008-11-07
// 概述: 测试删除技能
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
    public class DeleteSkillTest
    {
        [Test, Description("删除技能")]
        public void DeleteSkillTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Skill skill = new Skill(1, "javadevtest", null);

            Expect.Call(iSkill.GetSkillByPKID(skill.SkillID)).Return(skill);
            Expect.Call(iEmployeeSkill.CountEmployeeSkillBySkillID(skill.SkillID)).Return(0);
            Expect.Call(iSkill.DeleteSkillByPKID(skill.SkillID)).Return(1);
            mocks.ReplayAll();

            DeleteSkill target = new DeleteSkill(skill.SkillID, iEmployeeSkill, iSkill);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("删除的技能不存在")]
        public void DeleteSkillTestSkillNotExist()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Skill skill = new Skill(1, "codingtest", null);

            //要删除的合同类型不存在
            Expect.Call(iSkill.GetSkillByPKID(1)).Return(null);
            mocks.ReplayAll();

            DeleteSkill target = new DeleteSkill(skill.SkillID, iEmployeeSkill, iSkill);
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
        [Test, Description("删除已使用的技能,有相关技能的员工技能存在")]
        public void DeleteSkillTestUsingSkill1()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            SkillType skillType = new SkillType(1, "coding");
            Skill skill = new Skill(1, "codingtest", skillType);
            Expect.Call(iSkill.GetSkillByPKID(1)).Return(skill);
            Expect.Call(iEmployeeSkill.CountEmployeeSkillBySkillID(skill.SkillID)).Return(1);
            mocks.ReplayAll();

            DeleteSkill target = new DeleteSkill(skill.SkillID, iEmployeeSkill, iSkill);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "还有包含该技能的员工技能或者培训课程");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
