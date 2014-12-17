using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.DiyProcessesTest
{
    [TestFixture]
    public class GetDiyProcessTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployeeDiyProcessDal _IEmployeeDiyProcessDal;
        private GetDiyProcess _Target;

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
                new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll);
        }

        #region GetHRPrincipalByAccountID ���Ա��AccountID�����¸�����

        [Test, Description("GetHRPrincipalByAccountID���ԣ�����·��")]
        public void GetHRPrincipalByAccountIDTest1()
        {
            List<Account> expectedAccountList = new List<Account>();
            expectedAccountList.Add(new Account(1, "", ""));
            expectedAccountList.Add(new Account(2, "", ""));
            expectedAccountList.Add(new Account(3, "", ""));
            expectedAccountList.Add(new Account(4, "", ""));
            DiyProcess diyProcess;
            DiyStep diyStep;
            diyProcess = new DiyProcess(1, "�ɽ����¸�����", "", ProcessType.HRPrincipal);
            diyProcess.DiySteps = new List<DiyStep>();
            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[0]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[1]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[2]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[3]);
            diyProcess.DiySteps.Add(diyStep);
            Expect.Call(_IEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(diyProcess);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[0].Id)).Return(expectedAccountList[0]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[1].Id)).Return(expectedAccountList[1]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[2].Id)).Return(expectedAccountList[2]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[3].Id)).Return(expectedAccountList[3]);
            _Mocks.ReplayAll();
            List<Account> actualAccountList = _Target.GetHRPrincipalByAccountID(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualAccountList.Count, expectedAccountList.Count);
        }

        [Test, Description("GetHRPrincipalByAccountID���ԣ�GetDiyProcessByProcessTypeAndAccountID����null")]
        public void GetHRPrincipalByAccountIDTest2()
        {
            Expect.Call(_IEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(null);
            _Mocks.ReplayAll();
            List<Account> actualAccountList = _Target.GetHRPrincipalByAccountID(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualAccountList.Count, 0);
        }

        [Test, Description("GetHRPrincipalByAccountID���ԣ�GetDiyProcessByProcessTypeAndAccountID����ֵDiyStepsΪnull")]
        public void GetHRPrincipalByAccountIDTest3()
        {
            DiyProcess diyProcess;
            diyProcess = new DiyProcess(1, "�ɽ����¸�����", "", ProcessType.HRPrincipal);
            Expect.Call(_IEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(diyProcess);
            _Mocks.ReplayAll();
            List<Account> actualAccountList = _Target.GetHRPrincipalByAccountID(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualAccountList.Count, 0);
        }

        [Test, Description("GetHRPrincipalByAccountID���ԣ�DiySteps������һ��MailAccountΪnull")]
        public void GetHRPrincipalByAccountIDTest4()
        {
            List<Account> expectedAccountList = new List<Account>();
            expectedAccountList.Add(new Account(1, "", ""));
            expectedAccountList.Add(new Account(2, "", ""));
            expectedAccountList.Add(new Account(3, "", ""));
            expectedAccountList.Add(new Account(4, "", ""));
            DiyProcess diyProcess;
            DiyStep diyStep;
            diyProcess = new DiyProcess(1, "�ɽ����¸�����", "", ProcessType.HRPrincipal);
            diyProcess.DiySteps = new List<DiyStep>();
            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[0]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount = null;
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[2]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[3]);
            diyProcess.DiySteps.Add(diyStep);
            Expect.Call(_IEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(diyProcess);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[0].Id)).Return(expectedAccountList[0]);
            //Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[1].Id)).Return(expectedAccountList[1]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[2].Id)).Return(expectedAccountList[2]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[3].Id)).Return(expectedAccountList[3]);
            _Mocks.ReplayAll();
            List<Account> actualAccountList = _Target.GetHRPrincipalByAccountID(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualAccountList.Count, expectedAccountList.Count - 1);
        }

        [Test, Description("GetHRPrincipalByAccountID���ԣ�GetAccountById����ֵΪnull")]
        public void GetHRPrincipalByAccountIDTest5()
        {
            List<Account> expectedAccountList = new List<Account>();
            expectedAccountList.Add(new Account(1, "", ""));
            expectedAccountList.Add(new Account(2, "", ""));
            expectedAccountList.Add(new Account(3, "", ""));
            expectedAccountList.Add(new Account(4, "", ""));
            DiyProcess diyProcess;
            DiyStep diyStep;
            diyProcess = new DiyProcess(1, "�ɽ����¸�����", "", ProcessType.HRPrincipal);
            diyProcess.DiySteps = new List<DiyStep>();
            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[0]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[1]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[2]);
            diyProcess.DiySteps.Add(diyStep);

            diyStep = new DiyStep(1, "", OperatorType.Others, 1);
            diyStep.MailAccount.Add(expectedAccountList[3]);
            diyProcess.DiySteps.Add(diyStep);
            Expect.Call(_IEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(diyProcess);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[0].Id)).Return(expectedAccountList[0]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[1].Id)).Return(null);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[2].Id)).Return(expectedAccountList[2]);
            Expect.Call(_IAccountBll.GetAccountById(expectedAccountList[3].Id)).Return(expectedAccountList[3]);
            _Mocks.ReplayAll();
            List<Account> actualAccountList = _Target.GetHRPrincipalByAccountID(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualAccountList.Count, expectedAccountList.Count - 1);
        }

        #endregion
    }
}
