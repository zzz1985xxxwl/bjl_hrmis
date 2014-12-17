using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.BllUnitTest.Nationalitys
{
    [TestFixture]
    public class DeleteNationalityTest
    {
        [Test, Description("成功删除国籍")]
        public void DeleteNationalityTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Expect.Call(iEmployee.CountEmployeeByNationalityID(1)).Return(0);
            Expect.Call(iParameter.DeleteNationality(1)).Return(1);
            mocks.ReplayAll();

            DeleteNationality Target = new DeleteNationality(1, iParameter, iEmployee);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("此国籍已经被使用，不可被修改或删除")]
        public void DeleteNationalityTestHasUsed()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Expect.Call(iEmployee.CountEmployeeByNationalityID(1)).Return(1);
            mocks.ReplayAll();

            DeleteNationality Target = new DeleteNationality(1, iParameter, iEmployee);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("此国籍已经被使用，不可被修改或删除", error);
            mocks.VerifyAll();
        }
    }
}
