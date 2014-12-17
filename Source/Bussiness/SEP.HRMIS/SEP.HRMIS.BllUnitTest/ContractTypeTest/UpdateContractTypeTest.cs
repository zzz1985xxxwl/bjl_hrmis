using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Parameter
{
    [TestFixture]
    public class UpdateContractTypeTest
    {
        [Test, Description("�޸ĺ�ͬ�Ļ�����Ϣ")]
        public void UpdateContractTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            ContractType contractType = new ContractType(1, "contracttypetesst");

            Expect.Call(iContractType.GetContractTypeByPkid(contractType.ContractTypeID)).Return(contractType);
            Expect.Call(iContractType.CountContractTypeByNameDiffPKID(contractType.ContractTypeID, contractType.ContractTypeName)).Return(0);
            Expect.Call(iContractType.UpdateContractType(contractType)).Return(1);
            mocks.ReplayAll();

            UpdateContractType target = new UpdateContractType(contractType, iContractType);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸ĺ�ͬ���Ͳ�����")]
        public void UpdateContractTypeTestContractTypeNameExist()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            ContractType contractType = new ContractType(1, "contracttypetesst");

            Expect.Call(iContractType.GetContractTypeByPkid(contractType.ContractTypeID)).Return(null);
            mocks.ReplayAll();

            UpdateContractType target = new UpdateContractType(contractType, iContractType);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "�����ڸú�ͬ����");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }

        [Test, Description("�޸ĺ�ͬ���������ظ�")]
        public void UpdateContractTypeTestContractTypeNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            ContractType contractType = new ContractType(1, "contracttypetesst");

            Expect.Call(iContractType.GetContractTypeByPkid(contractType.ContractTypeID)).Return(contractType);
            Expect.Call(iContractType.CountContractTypeByNameDiffPKID(contractType.ContractTypeID, contractType.ContractTypeName)).Return(1);
            mocks.ReplayAll();

            UpdateContractType target = new UpdateContractType(contractType, iContractType);
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


    


