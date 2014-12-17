//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateLeaveRequestTypeTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:
// ---------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTypeTest
{
    [TestFixture]
    public class UpdateLeaveRequestTypeTest
    {
        [Test, Description("�޸�������͵Ļ�����Ϣ")]
        public void UpdateContractTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType = new LeaveRequestType("hungjia", "daixing", 
                LegalHoliday.Include,RestDay.Include, 4);
            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(_LeaveRequestType);
            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("hungjia")).Return(null);
            Expect.Call(delegate { iLeaveRequestType.UpdateLeaveRequestType(_LeaveRequestType); });
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }


        [Test, Description("������Ͳ�����")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateContractTypeTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType = new LeaveRequestType("hungjia", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(null);
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�޸������������û���ظ�")]
        public void UpdateContractTypeTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType1 = new LeaveRequestType(1, "���", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);
            _LeaveRequestType1.Name = "���";

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType1.LeaveRequestTypeID)).Return(_LeaveRequestType1);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("���")).Return(_LeaveRequestType1);
            Expect.Call(delegate { iLeaveRequestType.UpdateLeaveRequestType(_LeaveRequestType1); });
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType1, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�޸�������������ظ�")]
        public void UpdateContractTypeTestNameRepeat2()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType1 = new LeaveRequestType(1, "���", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);
            LeaveRequestType _LeaveRequestType2 = new LeaveRequestType(2, "���", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType1.LeaveRequestTypeID)).Return(_LeaveRequestType1);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("���")).Return(_LeaveRequestType2);
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType1, iLeaveRequestType);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("��������ظ�", error);
            mocks.VerifyAll();

        }
    }
}