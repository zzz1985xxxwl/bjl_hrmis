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
        [Test, Description("�ɹ�ɾ������")]
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

        [Test, Description("�˹����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��")]
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
            Assert.AreEqual("�˹����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��", error);
            mocks.VerifyAll();
        }
    }
}
