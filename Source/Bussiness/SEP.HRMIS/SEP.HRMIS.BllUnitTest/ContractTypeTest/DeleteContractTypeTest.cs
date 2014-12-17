using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.Parameter
{
    [TestFixture]
    public class DeleteContractTypeTest
    {
        [Test, Description("ɾ����ͬ����")]
        public void DeleteContractTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            IContractBookMark iContractBookMark = (IContractBookMark)mocks.CreateMock(typeof(IContractBookMark));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));

            ContractType contractType = new ContractType(1, "contracttypetesst");

            Expect.Call(iContractType.GetContractTypeByPkid(1)).Return(contractType);
            Expect.Call(iContract.GetEmployeeContractByContractTypeId(contractType.ContractTypeID)).Return(new List<Contract>());

            Expect.Call(iContractType.DeleteContractType(contractType.ContractTypeID)).Return(1);
            Expect.Call(iContractBookMark.DeleteContractBookMarkByContractTypeID(contractType.ContractTypeID)).Return(1);
            mocks.ReplayAll();

            DeleteContractType target = new DeleteContractType(contractType.ContractTypeID, iContractType, iContract, iContractBookMark);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("ɾ���ĺ�ͬ���Ͳ�����")]
        public void DeleteContractTypeTestContractTypeNotExist()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));
            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));

            ContractType contractType = new ContractType(1, "contracttypetesst");

            //Ҫɾ���ĺ�ͬ���Ͳ�����
            Expect.Call(iContractType.GetContractTypeByPkid(1)).Return(null);
            mocks.ReplayAll();

            DeleteContractType target =
                new DeleteContractType(contractType.ContractTypeID, iContractType, iContract, null);
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

        [Test, Description("ɾ���ĺ�ͬ���ʹ��ں�ͬ")]
        public void DeleteContractTypeTestContractExist()
        {
            MockRepository mocks = new MockRepository();
            IContractType iContractType = (IContractType)mocks.CreateMock(typeof(IContractType));

            IContract iContract = (IContract)mocks.CreateMock(typeof(IContract));

            ContractType contractType = new ContractType(1, "contracttypetesst");
            Contract contract = new Contract(1, contractType, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-12-12"));
            List<Contract> listContract = new List<Contract>();
            listContract.Add(contract);

            Expect.Call(iContractType.GetContractTypeByPkid(1)).Return(contractType);

            //ɾ���ĺ�ͬ�����ѱ�ʹ��
            Expect.Call(iContract.GetEmployeeContractByContractTypeId(contractType.ContractTypeID)).Return(listContract);
            mocks.ReplayAll();

            DeleteContractType target = new DeleteContractType(contractType.ContractTypeID, iContractType, iContract, null);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "���к�ͬ���ڸ�����");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }
}

   

