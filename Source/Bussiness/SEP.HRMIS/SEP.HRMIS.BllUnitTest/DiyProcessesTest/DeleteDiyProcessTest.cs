using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.BllUnitTest.DiyProcessesTest
{
    [TestFixture]
    public class DeleteDiyProcessTest
    {
        private MockRepository _Mocks;
        private IDiyProcessDal iDiyProcessDal;
        private IEmployeeDiyProcessDal iEmployeeDiyProcessDal;

        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            iDiyProcessDal = _Mocks.CreateMock<IDiyProcessDal>();
            iEmployeeDiyProcessDal = _Mocks.CreateMock<IEmployeeDiyProcessDal>();
        }

        [Test, Description("成功新增自定义流程")]
        public void DeleteDiyProcessTestSuccessfull()
        {
            Expect.Call(
                iEmployeeDiyProcessDal.CountAccountByDiyProcessID(1)).Return(0);
            Expect.Call(
                iDiyProcessDal.DeleteDiyProcess(1)).Return(1);
            _Mocks.ReplayAll();

            DeleteDiyProcess Target = new DeleteDiyProcess(1, iDiyProcessDal, iEmployeeDiyProcessDal);
            Target.Excute();
            _Mocks.VerifyAll();
        }

        [Test, Description("该流程正在使用中，不能被删除")]
        public void DeleteDiyProcessTestCountDiyProcessByName()
        {
            Expect.Call(
                iEmployeeDiyProcessDal.CountAccountByDiyProcessID(1)).Return(1);
            _Mocks.ReplayAll();

            DeleteDiyProcess Target = new DeleteDiyProcess(1, iDiyProcessDal, iEmployeeDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "该流程正在使用中，不能被删除");
            }
            _Mocks.VerifyAll();
        }
    }
}
