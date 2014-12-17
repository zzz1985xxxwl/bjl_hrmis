//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ����������������
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
        [Test, Description("�����������͵Ļ�����Ϣ")]
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

        [Test, Description("���������������ִ���")]
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
                Assert.AreEqual(ex.Message, "�����������Ʋ����ظ�");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}
