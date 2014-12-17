//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateSkillTest.cs
// ������: ����
// ��������: 2008-11-07
// ����: ���Ը��¼���
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

        [Test, Description("�޸ļ��ܵĻ�����Ϣ")]
        public void UpdateSkillTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, ".net���", null);
            skill.SkillType = new SkillType(1,"����");
            Expect.Call(iSkill.GetSkillByPKID(skill.SkillID)).Return(skill);
            Expect.Call(iSkill.CountSkillByNameDiffPKID(skill.SkillID,skill.SkillName)).Return(0);
            Expect.Call(iSkill.UpdateSkill(skill)).Return(1);
            mocks.ReplayAll();

            UpdateSkill target = new UpdateSkill(skill, iSkill);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸ļ��ܲ�����")]
        public void UpdateSkillSkillNotExist()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, "����ͨ",null);

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
                Assert.AreEqual(ex.Message, "�����ڸü�������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

        [Test, Description("�޸ļ��������ظ�")]
        public void UpdateSkillSkillNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, ".net���", null);
            skill.SkillType = new SkillType(1, "����");

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
                Assert.AreEqual(ex.Message, "�������Ʋ����ظ�");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
