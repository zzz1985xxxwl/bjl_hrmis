//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetSystemErrorTest.cs
// Creater:  Xue.wenlong
// Date:  2009-10-22
// Resume:
// ----------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.SystemErrors;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.SystemError;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.SystemErrorTest
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class GetSystemErrorTest
    {
    //    [Test]
    //    public void Test1()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDiyProcessError(true);
    //        Assert.AreEqual(6, errors.Count);
    //        foreach (SystemError error in errors)
    //        {
    //            Assert.AreEqual(ErrorStatus.Ignore, error.ErrorStatus);
    //        }
    //        mocks.VerifyAll();
    //    }

    //    [Test]
    //    public void Test2()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(null);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDiyProcessError(true);
    //        Assert.AreEqual(6, errors.Count);
    //        foreach (SystemError error in errors)
    //        {
    //            Assert.AreEqual(ErrorStatus.ToHandle, error.ErrorStatus);
    //        }
    //        mocks.VerifyAll();
    //    }

    //    [Test]
    //    public void Test3()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(errorList);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDiyProcessError(true);
    //        Assert.AreEqual(6, errors.Count);
    //        foreach (SystemError error in errors)
    //        {
    //            if (error.ErrorType == ErrorType.DiyAssessError)
    //            {
    //                Assert.AreEqual(ErrorStatus.Ignore, error.ErrorStatus);
    //            }
    //            else
    //            {
    //                Assert.AreEqual(ErrorStatus.ToHandle, error.ErrorStatus);
    //            }
    //        }
    //        mocks.VerifyAll();
    //    }

    //    [Test]
    //    public void Test4()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(errorList);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDiyProcessError(false);
    //        Assert.AreEqual(5, errors.Count);
    //        foreach (SystemError error in errors)
    //        {
    //            Assert.AreEqual(ErrorStatus.ToHandle, error.ErrorStatus);
    //        }
    //        mocks.VerifyAll();
    //    }
    //    [Test]
    //    public void Test5()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(errorList);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDoorCardError(false);
    //        Assert.AreEqual(1, errors.Count);
    //        foreach (SystemError error in errors)
    //        {
    //            Assert.AreEqual(ErrorStatus.ToHandle, error.ErrorStatus);
    //        }
    //        mocks.VerifyAll();
    //    }

    //    [Test]
    //    public void Test6()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(errorList);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A401, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDutyCalssErrorError(false);
    //        Assert.AreEqual(0, errors.Count);
    //        mocks.VerifyAll();
    //    }

    //    [Test]
    //    public void Test7()
    //    {
    //        MockRepository mocks = new MockRepository();
    //        ISystemError _SystemErrorDal = mocks.CreateMock<ISystemError>();
    //        IAccountBll _IAccountBll = mocks.CreateMock<IAccountBll>();
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));

    //        Expect.Call(_SystemErrorDal.GetAllIgnoreSystemError()).Return(errorList);
    //        Expect.Call(_SystemErrorDal.GetAcBaseSystemError()).Return(GetSystemErrorList());
    //        Expect.Call(_IAccountBll.GetAccountById(1)).Return(new Account(1, "sdf", "wahaha")).Repeat.Any();
    //        mocks.ReplayAll();
    //        Account userAccount = new Account();
    //        userAccount.Auths = new List<Auth>();
    //        Auth userAuth = new Auth(HrmisPowers.A502, "");
    //        userAuth.Type = AuthType.HRMIS;
    //        userAccount.Auths.Add(userAuth);
    //        GetSystemError target = new GetSystemError(userAccount, _SystemErrorDal, _IAccountBll);
    //        List<SystemError> errors = target.GetDutyCalssErrorError(false);
    //        Assert.AreEqual(1, errors.Count);
    //        mocks.VerifyAll();
    //    }
    //    private List<SystemError> GetSystemErrorList()
    //    {
    //        List<SystemError> errorList = new List<SystemError>();
    //        AddItem(errorList, new SystemError("sf", ErrorType.AttendanceError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyAssessError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyHRPrincipalError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyLeaveRequestError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyOutError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyOverWorkError, 1));
    //        //AddItem(errorList, new SystemError("sf", ErrorType.DiyReimburseError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DiyTraineeApplicationError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DoorCardNoError, 1));
    //        AddItem(errorList, new SystemError("sf", ErrorType.DutyCalssError, 1));
    //        return errorList;
    //    }

    //    private static void AddItem(ICollection<SystemError> errorList, SystemError error)
    //    {
    //        errorList.Add(error);
    //    }
    }
}