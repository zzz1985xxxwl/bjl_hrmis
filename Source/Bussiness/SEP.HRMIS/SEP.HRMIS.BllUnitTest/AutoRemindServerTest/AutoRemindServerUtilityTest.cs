using System.Collections.Generic;
using Mail.Model;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoRemindServerUtilityTest
    {
        private MockRepository _Mocks;
        private AutoRemindServerUtility _Target;
        private IAccountBll _IAccountBll;
        private IEmployeeDiyProcessDal _IEmployeeDiyProcessDal;

        private IDepartmentBll _IDepartmentBll;
        private IDiyProcessDal _IDiyProcessDal;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeDiyProcessDal = (IEmployeeDiyProcessDal)_Mocks.CreateMock(typeof(IEmployeeDiyProcessDal));
            _IDiyProcessDal = (IDiyProcessDal)_Mocks.CreateMock(typeof(IDiyProcessDal));

            _Target =
                new AutoRemindServerUtility(
                    new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll));
        }

        #region CreateHREmail �������������ʼ�������email��Ϣ

        private static void AssertmailBodyListToHR(MailBody mailBody, string mailTo, string body)
        {
            Assert.AreEqual(mailBody.MailTo.Count, 1);
            Assert.AreEqual(mailBody.MailTo[0], mailTo);
            Assert.AreEqual(mailBody.Body, body);
        }

        [Test, Description("CreateHREmail���ԣ�����·��")]
        public void CreateHREmailTest1()
        {
            List<MailBody> mailBodyListToHR = new List<MailBody>();
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(1, _IEmployeeDiyProcessDal, _IAccountBll);
            _Mocks.ReplayAll();
            _Target.CreateHREmail(1, mailBodyListToHR, "���", "��");
            _Mocks.VerifyAll();
            Assert.AreEqual(mailBodyListToHR.Count, 6);
            AssertmailBodyListToHR(mailBodyListToHR[0], "wang1@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[1], "wang11@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[2], "wang2@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[3], "wang3@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[4], "wang4@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[5], "wang44@shixintech.com", "���");
        }

        [Test, Description("CreateHREmail���ԣ�mailBodyListToHR��������")]
        public void CreateHREmailTest2()
        {
            List<MailBody> mailBodyListToHR = new List<MailBody>();
            mailBodyListToHR.Add(new MailBody());
            mailBodyListToHR[0].MailTo = new List<string>();
            mailBodyListToHR[0].MailTo.Add("wang1@shixintech.com");
            mailBodyListToHR[0].Body = "��ɯ�����h��";
            mailBodyListToHR.Add(new MailBody());
            mailBodyListToHR[1].MailTo = new List<string>();
            mailBodyListToHR[1].MailTo.Add("wang4@shixintech.com");
            mailBodyListToHR[1].Body = "";
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(1, _IEmployeeDiyProcessDal, _IAccountBll);
            _Mocks.ReplayAll();
            _Target.CreateHREmail(1, mailBodyListToHR, "���", "��");
            _Mocks.VerifyAll();
            Assert.AreEqual(mailBodyListToHR.Count, 6);
            AssertmailBodyListToHR(mailBodyListToHR[0], "wang1@shixintech.com", "��ɯ�����h�������");
            AssertmailBodyListToHR(mailBodyListToHR[1], "wang4@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[2], "wang11@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[3], "wang2@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[4], "wang3@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[5], "wang44@shixintech.com", "���");
        }

        [Test, Description("CreateHREmail���ԣ�mailBodyListToHR��MailToΪnull")]
        public void CreateHREmailTest3()
        {
            List<MailBody> mailBodyListToHR = new List<MailBody>();
            mailBodyListToHR.Add(new MailBody());
            mailBodyListToHR[0].MailTo = null;
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(1, _IEmployeeDiyProcessDal, _IAccountBll);
            _Mocks.ReplayAll();
            _Target.CreateHREmail(1, mailBodyListToHR, "���", "��");
            _Mocks.VerifyAll();
            Assert.AreEqual(mailBodyListToHR.Count, 7);
            AssertmailBodyListToHR(mailBodyListToHR[1], "wang1@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[2], "wang11@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[3], "wang2@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[4], "wang3@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[5], "wang4@shixintech.com", "���");
            AssertmailBodyListToHR(mailBodyListToHR[6], "wang44@shixintech.com", "���");
        }

        #endregion

    }
}
