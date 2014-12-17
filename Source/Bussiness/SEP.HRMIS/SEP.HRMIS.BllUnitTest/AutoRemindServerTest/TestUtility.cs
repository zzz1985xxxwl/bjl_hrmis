using System.Collections.Generic;
using Rhino.Mocks;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    public class TestUtility
    {
        /// <summary>
        /// GetHRPrincipalByAccountID正常路径的ExpectCall
        /// </summary>
        /// <param name="accountid"></param>
        /// <param name="iEmployeeDiyProcessDal"></param>
        /// <param name="iAccountBll"></param>
        public static void ExpectCallsGetHRPrincipalByAccountID(int accountid, IEmployeeDiyProcessDal iEmployeeDiyProcessDal, IAccountBll iAccountBll)
        {
            List<Account> expectedAccountList = new List<Account>();
            expectedAccountList.Add(new Account(1, "", ""));
            expectedAccountList.Add(new Account(2, "", ""));
            expectedAccountList.Add(new Account(3, "", ""));
            expectedAccountList.Add(new Account(4, "", ""));
            expectedAccountList[0].Email1 = "wang1@shixintech.com";
            expectedAccountList[0].Email2 = "wang11@shixintech.com";
            expectedAccountList[1].Email1 = "wang2@shixintech.com";
            expectedAccountList[1].Email2 = "wang2@shixintech.com";
            expectedAccountList[2].Email1 = "wang3@shixintech.com";
            expectedAccountList[2].Email2 = "";
            expectedAccountList[3].Email1 = "wang4@shixintech.com";
            expectedAccountList[3].Email2 = "wang44@shixintech.com";
            DiyProcess diyProcess;
            DiyStep diyStep;
            diyProcess = new DiyProcess(1, "松江人事负责人", "", ProcessType.HRPrincipal);
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
            Expect.Call(iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, accountid)).Return(diyProcess);
            Expect.Call(iAccountBll.GetAccountById(expectedAccountList[0].Id)).Return(expectedAccountList[0]);
            Expect.Call(iAccountBll.GetAccountById(expectedAccountList[1].Id)).Return(expectedAccountList[1]);
            Expect.Call(iAccountBll.GetAccountById(expectedAccountList[2].Id)).Return(expectedAccountList[2]);
            Expect.Call(iAccountBll.GetAccountById(expectedAccountList[3].Id)).Return(expectedAccountList[3]);
        }

    }
}
