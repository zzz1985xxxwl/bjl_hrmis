using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.ContractTypeTest
{
    [TestFixture]
    public class AddContractTypeTest
    {
        [Test, Description("������ͬ�Ļ�����Ϣ")]
        public void AddContractTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            ContractType contractType = new ContractType(1, "contracttypetesst");
            Expect.Call(iContractType.CountContractTypeByName("contracttypetesst")).Return(0);
            Expect.Call(iContractType.InsertContractType(contractType)).Return(1);
            mocks.ReplayAll();

            AddContractType target = new AddContractType(contractType, iContractType);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("������ͬ���ִ���")]
        public void AddContractTypeTestNameExist()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            ContractType contractType = new ContractType(1, "contracttypetesst");

            Expect.Call(iContractType.CountContractTypeByName("contracttypetesst")).Return(1);
            mocks.ReplayAll();

            AddContractType target = new AddContractType(contractType, iContractType);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "��ͬ�������Ʋ����ظ�");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}