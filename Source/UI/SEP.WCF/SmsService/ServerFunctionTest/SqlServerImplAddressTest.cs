using System;
using System.Collections.Generic;
using NUnit.Framework;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ServerFunctionTest
{
    [TestFixture]
    public class SqlServerImplAddressTest
    {
        private IClientInformationDal _TheTarget;
        private int _TheNewPkid;

        [SetUp]
        public void SetUp()
        {
            _TheTarget = new SqlServerImplClientInformation();
        }

        [TearDown]
        public void TearDown()
        {
            new SqlServerImplClientInformation().DeleteClientInfomationModelById(_TheNewPkid);
        }

        [Test,Description("���Գ־�ClientInformationModel����")]
        public void Test1()
        {
            //�־�һ���µĶ���
            ClientInformationModel aNewObject = new ClientInformationModel("hrmisId","companyDescription",true);
            aNewObject.TheAddressModelCollcetion.Add(new ListenAddressModel("listenAddress",true,true,DateTime.Today));
            _TheTarget.InsertClientInfomationModel(aNewObject);
            _TheNewPkid = aNewObject.Pkid;
            //����װ�ظö���,ʹ��GetAll��ʽ
            List<ClientInformationModel> rechieveObjects = _TheTarget.GetAllClientInfomationModel();
            Assert.AreEqual(1, rechieveObjects.Count);
            Assert.IsTrue(aNewObject.Equals(rechieveObjects[0]));
            //����װ�ض���ʹ��GetById��ʽ
            ClientInformationModel rechieveObjectById = _TheTarget.GetClientInformationById(_TheNewPkid);
            Assert.IsTrue(aNewObject.Equals(rechieveObjectById));
            //�޸Ķ���
            ClientInformationModel theRechieveObject = rechieveObjects[0];
            theRechieveObject.HrmisId = "hrmisId1";
            theRechieveObject.CompanyDescription = "capcom";
            theRechieveObject.IsPermitted = false;
            theRechieveObject.TheAddressModelCollcetion[0].IsActivited = false;
            theRechieveObject.TheAddressModelCollcetion[0].IsPermitted = false;
            theRechieveObject.TheAddressModelCollcetion[0].LastTryActivitedTime = new DateTime(1999,1,1);
            theRechieveObject.TheAddressModelCollcetion[0].ListenAddress = "http://localhost";
            theRechieveObject.TheAddressModelCollcetion.Add(new ListenAddressModel("123123",false,true,new DateTime(1998,1,1)));
            _TheTarget.UpdateClientInfomationModel(theRechieveObject);
            //�ٴμ��ض���
            List<ClientInformationModel> secondRechieveObjectsSecond = _TheTarget.GetAllClientInfomationModel();
            Assert.AreEqual(1, secondRechieveObjectsSecond.Count);
            Assert.IsTrue(theRechieveObject.Equals(secondRechieveObjectsSecond[0]));
        }
    }
}