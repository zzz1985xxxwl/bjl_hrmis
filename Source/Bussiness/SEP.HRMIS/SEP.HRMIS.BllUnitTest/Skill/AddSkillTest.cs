//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillTest.cs
// ������: ����
// ��������: 2008-11-07
// ����: ������������
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
    public class AddSkillTest
    {
        [Test, Description("�������ܵĻ�����Ϣ")]
        public void AddSkillTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, "C#", null);
            Expect.Call(iSkill.CountSkillByName("C#")).Return(0);
            Expect.Call(iSkill.InsertSkill(skill)).Return(1);
            mocks.ReplayAll();

            AddSkill target = new AddSkill(skill, iSkill);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�����������ִ���")]
        public void AddSkillTestNameExist()
        {
            MockRepository mocks = new MockRepository();
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));
            Skill skill = new Skill(1, "JAVA", null);

            Expect.Call(iSkill.CountSkillByName("JAVA")).Return(1);
            mocks.ReplayAll();

            AddSkill target = new AddSkill(skill, iSkill);
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
