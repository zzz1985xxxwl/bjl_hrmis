using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.BllUnitTest.EmployeeAdjustRestTest
{
    [TestFixture]
    public class UpdateAdjustRestByOperatorTest
    {
        private MockRepository Mocks;
        private IAdjustRest _IAdjustRest;
        private IAdjustRestHistory _IAdjustRestHistory;
        private AdjustRest _AdjustRest;
        private AdjustRestHistory _AdjustRestHistory;

        [SetUp]
        public void SetUp()
        {
            Mocks = new MockRepository();
            _IAdjustRest = (IAdjustRest) Mocks.CreateMock(typeof (IAdjustRest));
            _IAdjustRestHistory = (IAdjustRestHistory) Mocks.CreateMock(typeof (IAdjustRestHistory));
        }

        [Test]
        public void Test()
        {
            UpdateAdjustRestByOperator target =
                new UpdateAdjustRestByOperator(1, 5, "dsf", 3, _IAdjustRest, _IAdjustRestHistory);
            Expect.Call(_IAdjustRest.GetAdjustRestByPKID(1)).Return(
                new AdjustRest(1, 2, new Employee(1, EmployeeTypeEnum.All), Convert.ToDateTime("2009-1-1")));
            Expect.Call(_IAdjustRest.UpdateAdjustRest(null)).IgnoreArguments().Do(
                new UpdateAdjustRestDelegate(MockUpdateAdjustRest));
            Expect.Call(_IAdjustRestHistory.InsertAdjustRestHistory(1, null)).IgnoreArguments().Do(
                new InsertAdjustRestHistoryDelegate(MockInsertAdjustRestHistory));
            Mocks.ReplayAll();
            target.Excute();
            Mocks.VerifyAll();
            Assert.AreEqual(5, _AdjustRest.SurplusHours);
            Assert.AreEqual("dsf", _AdjustRestHistory.Remark);
            Assert.AreEqual(3, _AdjustRestHistory.ChangeHours);
        }

        [Test]
        public void Test2()
        {
            UpdateAdjustRestByOperator target =
                new UpdateAdjustRestByOperator(1, 2, "", 3, _IAdjustRest, _IAdjustRestHistory);
            Expect.Call(_IAdjustRest.GetAdjustRestByPKID(1)).Return(
                new AdjustRest(1, 2, new Employee(1, EmployeeTypeEnum.All), Convert.ToDateTime("2009-1-1")));
            Mocks.ReplayAll();
            target.Excute();
            Mocks.VerifyAll();
        }

        private delegate int UpdateAdjustRestDelegate(AdjustRest adjustrest);

        private delegate int InsertAdjustRestHistoryDelegate(int accountid, AdjustRestHistory adjustRestHistory);

        private int MockUpdateAdjustRest(AdjustRest adjustrest)
        {
            _AdjustRest = adjustrest;
            return 2;
        }

        private int MockInsertAdjustRestHistory(int accountid, AdjustRestHistory adjustRestHistory)
        {
            _AdjustRestHistory = adjustRestHistory;
            return 1;
        }
    }
}