using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Nationalitys
{
    [TestFixture]
    public class InsertNationalityTest
    {
        [Test, Description("成功新增国籍")]
        public void InsertNationalityTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            Nationality _Nationality = new Nationality(0, "中华人民共和国", "china");
            Expect.Call(iParameter.CountNationalityByName("中华人民共和国")).Return(0);
            Expect.Call(iParameter.InsertNationality(_Nationality)).Return(1);
            mocks.ReplayAll();

            InsertNationality Target = new InsertNationality(_Nationality, iParameter);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("新增国籍名字重复")]
        public void InsertNationalityTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            Nationality _Nationality = new Nationality(0, "中华人民共和国", "china");
            Expect.Call(iParameter.CountNationalityByName("中华人民共和国")).Return(1);
            mocks.ReplayAll();

            InsertNationality Target = new InsertNationality(_Nationality, iParameter);
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
    }
}
