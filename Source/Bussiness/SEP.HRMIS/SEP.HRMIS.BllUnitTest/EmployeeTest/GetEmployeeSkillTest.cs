//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetEmployeeSkillTest.cs
// ������: Emma
// ��������: 2008-12-01
// ����: ��ȡԱ�����ܲ���
// ----------------------------------------------------------------
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class GetEmployeeSkillTest
    {
        [Test, Description("��ȡԱ�����ܳɹ�")]
        public void GetAllChildDepartmentPKIDAndNameByDepartmentID()
        {
            MockRepository mocks = new MockRepository();
            IEmployeeSkill iEmpSkill = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));

            Employee emp1 =
                new Employee(new Account(1, "", "emp1"), "Email1", string.Empty, EmployeeTypeEnum.NormalEmployee, null,
                             null);
           
            List<EmployeeSkill> allEmpSkill = new List<EmployeeSkill>();
            allEmpSkill.Add(new EmployeeSkill(new Skill(1,"emma",new SkillType(1,"test")), SkillLevelEnum.Trained));

            Expect.Call(iEmpSkill.GetEmployeeSkillByAccountID(emp1.Account.Id, "", -1, SkillLevelEnum.All)).Return(new Employee());
            mocks.ReplayAll();

            GetEmployeeSkill target = new GetEmployeeSkill(iEmpSkill);
            target.GetEmployeeSkillByAccountID(emp1.Account.Id, "", -1, SkillLevelEnum.All);
            mocks.VerifyAll();

        }


    }
}
