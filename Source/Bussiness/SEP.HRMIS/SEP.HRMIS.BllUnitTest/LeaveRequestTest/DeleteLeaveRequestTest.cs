using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class DeleteLeaveRequestTest
    {
        [Test, Description("³É¹¦É¾³ýÇë¼Ùµ¥")]
        public void DeleteLeaveRequestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestDal iLeaveRequestDal = mocks.CreateMock<ILeaveRequestDal>();

            Expect.Call(iLeaveRequestDal.DeleteLeaveRequest(1)).Return(1);
            
            mocks.ReplayAll();

            DeleteLeaveRequest Target = new DeleteLeaveRequest(1, iLeaveRequestDal);
            Target.Excute();
            mocks.VerifyAll();
        }
    }
}
