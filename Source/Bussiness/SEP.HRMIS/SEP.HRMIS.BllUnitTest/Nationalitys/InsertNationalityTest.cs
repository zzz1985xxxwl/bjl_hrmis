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
        [Test, Description("�ɹ���������")]
        public void InsertNationalityTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            Nationality _Nationality = new Nationality(0, "�л����񹲺͹�", "china");
            Expect.Call(iParameter.CountNationalityByName("�л����񹲺͹�")).Return(0);
            Expect.Call(iParameter.InsertNationality(_Nationality)).Return(1);
            mocks.ReplayAll();

            InsertNationality Target = new InsertNationality(_Nationality, iParameter);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�������������ظ�")]
        public void InsertNationalityTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            Nationality _Nationality = new Nationality(0, "�л����񹲺͹�", "china");
            Expect.Call(iParameter.CountNationalityByName("�л����񹲺͹�")).Return(1);
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
            Assert.AreEqual("���������ظ�", error);
            mocks.VerifyAll();
        }
    }
}
