using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Nationalitys
{
    [TestFixture]
    public class UpdateNationalityTest
    {
        [Test, Description("成功修改国籍")]
        public void UpdateNationalityTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "中华人民共和国", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "中华人民共和国")).Return(0);
            Expect.Call(iEmployee.CountEmployeeByNationalityID(1)).Return(0);
            Expect.Call(iParameter.UpdateNationality(_Nationality)).Return(1);
            mocks.ReplayAll();

            UpdateNationality Target = new UpdateNationality(_Nationality, iParameter, iEmployee);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("修改国籍名字重复")]
        public void UpdateNationalityTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "中华人民共和国", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "中华人民共和国")).Return(1);
            mocks.ReplayAll();

            UpdateNationality Target = new UpdateNationality(_Nationality, iParameter, iEmployee);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("国籍名称重复", error);
            mocks.VerifyAll();
        }

        [Test, Description("此国籍已经被使用，不可被修改或删除")]
        public void UpdateNationalityTestHasBeenUsed()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "中华人民共和国", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "中华人民共和国")).Return(0);
            Expect.Call(iEmployee.CountEmployeeByNationalityID(1)).Return(1);
            mocks.ReplayAll();

            UpdateNationality Target = new UpdateNationality(_Nationality, iParameter, iEmployee);
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
