//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateSystemErrorStatusTest.cs
// Creater:  Xue.wenlong
// Date:  2009-10-22
// Resume:
// ----------------------------------------------------------------

using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.SystemErrors;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.SystemError;

namespace SEP.HRMIS.BllUnitTest.SystemErrorTest
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class UpdateSystemErrorStatusTest
    {
        [Test]
        public void Test1()
        {
            SystemError error = new SystemError("123", ErrorType.DiyHRPrincipalError, 2);

            MockRepository mocks = new MockRepository();
            ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
            Expect.Call(_SystemErrorDal.GetSystemErrorByTypeAndMarkID(error.ErrorType, error.MarkID)).Return(null);
            Expect.Call(_SystemErrorDal.SystemErrorInsert(null)).IgnoreArguments().Do(
                new SystemErrorInsert(SystemErrorInsertd));
            mocks.ReplayAll();

            UpdateSystemErrorStatus target = new UpdateSystemErrorStatus(error, _SystemErrorDal);
            target.Excute();
            Assert.AreEqual(ErrorStatus.Ignore, _SystemError.ErrorStatus);
            mocks.VerifyAll();
        }

        [Test]
        public void Test2()
        {
            SystemError error = new SystemError("123", ErrorType.DiyHRPrincipalError, 2);

            MockRepository mocks = new MockRepository();
            ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
            Expect.Call(_SystemErrorDal.GetSystemErrorByTypeAndMarkID(error.ErrorType, error.MarkID)).Return(error);
            Expect.Call(_SystemErrorDal.DeleteSystemErrorByTypeAndMarkID(error.ErrorType, error.MarkID)).Return(1);
            mocks.ReplayAll();

            UpdateSystemErrorStatus target = new UpdateSystemErrorStatus(error, _SystemErrorDal);
            target.Excute();
            mocks.VerifyAll();
        }

        private delegate int SystemErrorInsert(SystemError error);

        private SystemError _SystemError;

        private int SystemErrorInsertd(SystemError error)
        {
            _SystemError = error;
            return 1;
        }
    }
}