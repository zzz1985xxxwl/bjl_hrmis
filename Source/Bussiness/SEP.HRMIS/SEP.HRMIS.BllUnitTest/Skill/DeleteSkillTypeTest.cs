//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ����ɾ����������
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
        [Test, Description("ɾ����������")]
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

        [Test, Description("ɾ���ļ������Ͳ�����")]
        public void DeleteSkillTypeTestSkillTypeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IParameter iSkillType = (IParameter)mocks.CreateMock(typeof(IParameter));
            ISkill iSkill = (ISkill)mocks.CreateMock(typeof(ISkill));

            SkillType skillType = new SkillType(1, "codingtest");

            //Ҫɾ���ĺ�ͬ���Ͳ�����
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
                Assert.AreEqual(ex.Message, "�����ڸü�������");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("ɾ����ʹ�õļ�������")]
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
                Assert.AreEqual(ex.Message, "�������ڸ����͵ļ���");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
