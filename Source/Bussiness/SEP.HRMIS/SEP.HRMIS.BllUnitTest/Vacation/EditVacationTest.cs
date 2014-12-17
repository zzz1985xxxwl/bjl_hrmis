using System;
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
    public class EditVacationTest
    {
        [Test ]
        public void EditVacationTest1()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation)mocks.CreateMock(typeof(IVacation));

            Employee employee1 =
                new Employee(new Account(1, "", "Õı…Ø¿Ú"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, null);
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(1, employee1, 2, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(1, employee1, 2, new DateTime(2007, 9, 1), new DateTime(2008, 9, 1), 9, 8, ""));
            Expect.Call(iVacation.DeleteVacationByAccountID(1)).Return(1);
            Expect.Call(iVacation.Insert(vacations[0])).Return(1);
            Expect.Call(iVacation.Insert(vacations[1])).Return(1);
            Expect.Call(iVacation.Insert(vacations[2])).Return(1);
            mocks.ReplayAll();
            EditVacation editVacation = new EditVacation(vacations, employee1, iVacation);
            editVacation.Excute();
            mocks.VerifyAll();
        }

        [Test]
        public void EditVacationTest2()
        {
            MockRepository mocks = new MockRepository();
            Employee employee1 =
                new Employee(new Account(1, "", "Õı…Ø¿Ú"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, null);
            IVacation iVacation = (IVacation)mocks.CreateMock(typeof(IVacation));
            Expect.Call(iVacation.DeleteVacationByAccountID(1)).Return(1);
            mocks.ReplayAll();
            EditVacation editVacation = new EditVacation(null, employee1, iVacation);
            editVacation.Excute();
            mocks.VerifyAll();
        }

        [Test]
        public void EditVacationTest3()
        {
            Employee employee1 =
                new Employee(new Account(1, "", "Õı…Ø¿Ú"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, null);
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation)mocks.CreateMock(typeof(IVacation));
            Expect.Call(iVacation.DeleteVacationByAccountID(1)).Return(1);
            mocks.ReplayAll();
            EditVacation editVacation = new EditVacation(new List<Model.Vacation>(), employee1, iVacation);
            editVacation.Excute();
            mocks.VerifyAll();
        }
    }
}
