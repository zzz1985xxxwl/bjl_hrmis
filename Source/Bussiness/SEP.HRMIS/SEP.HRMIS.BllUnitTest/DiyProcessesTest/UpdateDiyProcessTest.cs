using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.BllUnitTest.DiyProcessesTest
{
    [TestFixture]
    public class UpdateDiyProcessTest
    {
        private MockRepository _Mocks;
        private IDiyProcessDal iDiyProcessDal;

        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            iDiyProcessDal = _Mocks.CreateMock<IDiyProcessDal>();
        }

        [Test, Description("成功新增自定义流程")]
        public void AddDiyProcessTestSuccessfull()
        {
            DiyProcess diyProcess = new DiyProcess(1, "diyProcess", "diyProcess", ProcessType.LeaveRequest);

            Expect.Call(
                iDiyProcessDal.CountDiyProcessByNameDiffPKID(1, "diyProcess")).Return(0);
            Expect.Call(
                iDiyProcessDal.UpdateDiyProcess(diyProcess)).Return(1);
            _Mocks.ReplayAll();

            UpdateDiyProcess Target = new UpdateDiyProcess(diyProcess, iDiyProcessDal);
            Target.Excute();
            _Mocks.VerifyAll();
        }

        [Test, Description("自定义流程重名")]
        public void AddDiyProcessTestCountDiyProcessByName()
        {
            DiyProcess diyProcess = new DiyProcess(1, "diyProcess", "diyProcess", ProcessType.LeaveRequest);

            Expect.Call(
                iDiyProcessDal.CountDiyProcessByNameDiffPKID(1, "diyProcess")).Return(1);
            _Mocks.ReplayAll();

            UpdateDiyProcess Target = new UpdateDiyProcess(diyProcess, iDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "自定义流程的名称不能重复");
            }
            _Mocks.VerifyAll();
        }
    }
}
