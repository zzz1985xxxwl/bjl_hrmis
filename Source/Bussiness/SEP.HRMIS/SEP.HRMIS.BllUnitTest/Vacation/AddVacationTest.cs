//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddVacationTest.cs
// Creater:  Xue.wenlong
// Date:  2009-01-13
// Resume:
// ---------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class AddVacationTest
    {
        [Test]
        public void Test1()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation) mocks.CreateMock(typeof (IVacation));
            Expect.Call(iVacation.Insert(null)).IgnoreArguments().Return(1);
            AddVacation target = new AddVacation(null, iVacation);
            mocks.ReplayAll();
            target.Excute();
            mocks.VerifyAll();
        }

        [Test]
        public void Test2()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation)mocks.CreateMock(typeof(IVacation));
            Expect.Call(iVacation.Insert(null)).IgnoreArguments().Throw(new Exception(""));
            AddVacation target = new AddVacation(null, iVacation);
            mocks.ReplayAll();
            string expection=string.Empty;
            try
            {
                target.Excute();
            }
            catch (ApplicationException e)
            {
                expection=e.Message;
            }
            Assert.AreEqual("Êý¾Ý¿â·ÃÎÊ´íÎó", expection);
            mocks.VerifyAll();
        }

    }
}