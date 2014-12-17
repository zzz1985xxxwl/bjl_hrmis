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
        [Test, Description("�ɹ��޸Ĺ���")]
        public void UpdateNationalityTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "�л����񹲺͹�", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "�л����񹲺͹�")).Return(0);
            Expect.Call(iEmployee.CountEmployeeByNationalityID(1)).Return(0);
            Expect.Call(iParameter.UpdateNationality(_Nationality)).Return(1);
            mocks.ReplayAll();

            UpdateNationality Target = new UpdateNationality(_Nationality, iParameter, iEmployee);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸Ĺ��������ظ�")]
        public void UpdateNationalityTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "�л����񹲺͹�", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "�л����񹲺͹�")).Return(1);
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
            Assert.AreEqual("���������ظ�", error);
            mocks.VerifyAll();
        }

        [Test, Description("�˹����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��")]
        public void UpdateNationalityTestHasBeenUsed()
        {
            MockRepository mocks = new MockRepository();
            IParameter iParameter = mocks.CreateMock<IParameter>();
            IEmployee iEmployee = mocks.CreateMock<IEmployee>();
            Nationality _Nationality = new Nationality(1, "�л����񹲺͹�", "china");
            Expect.Call(iParameter.CountNationalityByNameDiffPKID(1, "�л����񹲺͹�")).Return(0);
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
            Assert.AreEqual("�˹����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��", error);
            mocks.VerifyAll();
        }
    }
}
