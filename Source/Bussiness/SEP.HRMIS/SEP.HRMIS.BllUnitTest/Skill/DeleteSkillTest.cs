//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteSkillTest.cs
// ������: ����
// ��������: 2008-11-07
// ����: ����ɾ������
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
        [Test, Description("ɾ������")]
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
        [Test, Description("ɾ���ļ��ܲ�����")]
        public void DeleteSkillTestSkillNotExist()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            IEmployeeSkill iEmployeeSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            Skill skill = new Skill(1, "codingtest", null);

            //Ҫɾ���ĺ�ͬ���Ͳ�����
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
                Assert.AreEqual(ex.Message, "�����ڸü�������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("ɾ����ʹ�õļ���,����ؼ��ܵ�Ա�����ܴ���")]
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
                Assert.AreEqual(ex.Message, "���а����ü��ܵ�Ա�����ܻ�����ѵ�γ�");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
