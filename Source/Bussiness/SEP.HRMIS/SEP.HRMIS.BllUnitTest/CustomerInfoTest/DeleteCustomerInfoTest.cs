//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateCustomerInfoTest.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 删除客户信息测试
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
   public  class DeleteCustomerInfoTest
    {
        private DeleteCustomerInfo _TheTarget;
        private MockRepository _Mock;
        private ICustomerInfoDal _ICustomerInfoDal;
       private IReimburse _iReimburse;

        [SetUp]
        public void SetUp()
        {
            _Mock = new MockRepository();
            _ICustomerInfoDal = (ICustomerInfoDal)_Mock.CreateMock(typeof(ICustomerInfoDal));
            _iReimburse = (IReimburse)_Mock.CreateMock(typeof(IReimburse));
        }

        [Test, Description("新增,成功")]
        public void Test1()
        {
            CustomerInfo info = new CustomerInfo(1, "123");
            Expect.Call(_ICustomerInfoDal.GetCustomerInfoByCustomerInfoID(1)).Return(info);
            Expect.Call(_iReimburse.GetReiburseByCustomerID(1)).Return(false);
            Expect.Call(_ICustomerInfoDal.DeleteCustomerInfo(1)).Return(1);
            _Mock.ReplayAll();
            _TheTarget = new DeleteCustomerInfo(1, _ICustomerInfoDal, _iReimburse);
            _TheTarget.Excute();
            _Mock.VerifyAll();
        }

        [Test]
        public void Test3()
        {
            //CustomerInfo info = new CustomerInfo(1, "123");
            Expect.Call(_ICustomerInfoDal.GetCustomerInfoByCustomerInfoID(1)).Return(null);
            _Mock.ReplayAll();
            _TheTarget = new DeleteCustomerInfo(1, _ICustomerInfoDal,_iReimburse);
            string expection = string.Empty;
            try
            {
                _TheTarget.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("客户信息不存在", expection);
            _Mock.VerifyAll();

        }

       [Test]
       public void Test2()
       {
           CustomerInfo info = new CustomerInfo(1, "123");
           Expect.Call(_ICustomerInfoDal.GetCustomerInfoByCustomerInfoID(1)).Return(info);
           Expect.Call(_iReimburse.GetReiburseByCustomerID(1)).Return(true);
           _Mock.ReplayAll();
           _TheTarget = new DeleteCustomerInfo(1, _ICustomerInfoDal, _iReimburse);
           string expection = string.Empty;
           try
           {
               _TheTarget.Excute();
           }
           catch (ApplicationException e)
           {
               expection = e.Message;
           }
           Assert.AreEqual("客户信息正被使用，无法删除", expection);
           _Mock.VerifyAll();

       }
    }
}
