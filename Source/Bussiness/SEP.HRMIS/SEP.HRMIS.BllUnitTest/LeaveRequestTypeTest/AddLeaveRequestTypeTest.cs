//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddLeaveRequestTypeTest.cs
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
    public class AddLeaveRequestTypeTest
    {
        

        [Test, Description("�ɹ������������")]
        public void AddLeaveTypeTestSuccessful()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveType = mocks.CreateMock<ILeaveRequestType>();
            LeaveRequestType _LeaveType = new LeaveRequestType("hungjia", "daixing", 
                 LegalHoliday.Include, RestDay.Include, 4);
            Expect.Call(iLeaveType.GetLeaveRequestTypeByName("hungjia")).Return(null);
            Expect.Call(iLeaveType.InsertLeaveRequestType(_LeaveType)).Return(1);
            mocks.ReplayAll();

            AddLeaveRequestType Target = new AddLeaveRequestType(_LeaveType, iLeaveType);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�����������ʱ�����ظ�")]
        public void AddLeaveTypeTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveType = mocks.CreateMock<ILeaveRequestType>();
            LeaveRequestType _LeaveType = new LeaveRequestType("hungjia", "daixing",
                 LegalHoliday.Include, RestDay.Include, 4);
            Expect.Call(iLeaveType.GetLeaveRequestTypeByName("hungjia")).Return(_LeaveType);
            mocks.ReplayAll();

            AddLeaveRequestType Target = new AddLeaveRequestType(_LeaveType, iLeaveType);
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