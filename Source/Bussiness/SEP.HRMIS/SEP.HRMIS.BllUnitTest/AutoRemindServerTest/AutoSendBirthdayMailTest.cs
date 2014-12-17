using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.IDal;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Mail;
using SEP.IBll.WelcomeMails;
using WelcomeMail = SEP.Model.Mail.WelcomeMail;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoSendBirthdayMailTest
    {
        private MockRepository _Mocks;
        private GetEmployee _GetEmployee;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private AutoSendBirthdayMail _Target;
        private IMailGateWay _IMailGateWay;
        private IAccountBll _IAccountBll;
        private IDepartmentBll _IDepartmentBll;
        private IWelcomeMailBll _IMail;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _IMail = _Mocks.CreateMock<IWelcomeMailBll>();
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
        }

        [Test, Description("员工生日,给员工,信件没有开启自动发送功能")]
        public void AutoSendBirthdayMailTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-19");
            _Target = new AutoSendBirthdayMail(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.SetWelComeMail = _IMail;
            WelcomeMail mail = new WelcomeMail("ss", false);
            Expect.Call(_IMail.GetLastestWelcomeMailByTypeID(1)).Return(mail);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();

        }

        [Test, Description("员工生日,给员工,信件不存在")]
        public void AutoSendBirthdayMailTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-19");
            _Target = new AutoSendBirthdayMail(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.SetWelComeMail = _IMail;
            Expect.Call(_IMail.GetLastestWelcomeMailByTypeID(1)).Return(null);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();

        }

    }
}
