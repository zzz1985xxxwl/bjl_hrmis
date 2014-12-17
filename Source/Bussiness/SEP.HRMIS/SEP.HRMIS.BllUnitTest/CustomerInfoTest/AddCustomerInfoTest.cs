//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddCustomerInfo.cs
// ������: ����
// ��������: 2009-08-14
// ����: �����ͻ���Ϣ����
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Bll.CustomerInfos;
using Rhino.Mocks;
using NUnit.Framework;

namespace SEP.HRMIS.BllUnitTest.CustomerInfoTest
{
    [TestFixture]
    public  class AddCustomerInfoTest
    {
       private AddCustomerInfo _TheTarget;
        private MockRepository _Mock;
        private ICustomerInfoDal _ICustomerInfoDal;

        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ICustomerInfoDal = (ICustomerInfoDal)_Mock.CreateMock(typeof(ICustomerInfoDal));
        }

        [Test, Description("����,�ɹ�")]
        public void Test1()
        {
            CustomerInfo info = new CustomerInfo(1, "123");
            Expect.Call(_ICustomerInfoDal.CountCustomerInfoByNameDiffPKID("123", 0)).Return(0);
            Expect.Call(_ICustomerInfoDal.InsertCustomerInfo(info)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new AddCustomerInfo(info, _ICustomerInfoDal);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test]
        public void Test2()
        {
            CustomerInfo info = new CustomerInfo(1, "123");
            Expect.Call(_ICustomerInfoDal.CountCustomerInfoByNameDiffPKID("123", 0)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new AddCustomerInfo(info, _ICustomerInfoDal);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("�ͻ������ظ�", expection);
            _Mock.VerifyAll();

        }
    }
}
