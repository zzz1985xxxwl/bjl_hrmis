using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.EmployeeAdjustRestTest
{
    [TestFixture]
    public class GetAdjustRestHistoryTest
    {
        private MockRepository _Mocks;
        private IAdjustRestHistory _IAdjustRestHistory;
        private GetAdjustRestHistory _Target;
        private readonly int _AccountID = 1;
        private IAccountBll _IAccountBll;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IAdjustRestHistory = (IAdjustRestHistory)_Mocks.CreateMock(typeof(IAdjustRestHistory));
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();

            //_DalILeaveRequest = _Mocks.CreateMock<ILeaveRequestDal>();
            _Target = new GetAdjustRestHistory();
            _Target.MockIAccountBll = _IAccountBll;
            _Target.MockIAdjustRestHistory = _IAdjustRestHistory;

        }
        [Test, Description("GetAdjustRestHistoryByAccountID")]
        public void GetAdjustRestHistoryByAccountIDTest()
        {
            List<AdjustRestHistory> AdjustRestHistoryList = new List<AdjustRestHistory>();
            AdjustRestHistory adjustRestHistory =
                new AdjustRestHistory(1, new DateTime(2009, 4, 5), 8,  AdjustRestHistoryTypeEnum.ModifyByOperator);
            adjustRestHistory.Operator = new Account(4, "", "");
            AdjustRestHistoryList.Add(adjustRestHistory);
            Expect.Call(_IAdjustRestHistory.GetAdjustRestHistoryByAccountID(_AccountID)).Return(AdjustRestHistoryList);
            Expect.Call(_IAccountBll.GetAccountById(adjustRestHistory.Operator.Id)).Return(adjustRestHistory.Operator);

            _Mocks.ReplayAll();
            _Target.GetAdjustRestHistoryByAccountID(_AccountID);
            _Mocks.VerifyAll();
        }

    }
}
