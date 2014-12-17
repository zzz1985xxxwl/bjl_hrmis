//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateEmployeeAccountSetTest.cs
// ������: yyb
// ��������: 2008-12-25
// ����: ������ٵ��ĵ�Ԫ����
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    [TestFixture]
    public class UpdateEmployeeAccountSetTest
    {
        [Test, Description("��н���޸Ĺ̶������֤�����Ƿ���Ϊ��")]
        public void UpdateEmployeeAccountSetNoAccountSet()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = mocks.Stub<IEmployeeAccountSet>();
            mocks.ReplayAll();
            UpdateEmployeeAccountSet target =
                new UpdateEmployeeAccountSet(1, null, "", Convert.ToDateTime("2008-10-10"), "", iAccountSet,
                                             iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            mocks.VerifyAll();
            Assert.AreEqual("Ա�����ײ���Ϊ��", exception);
        }

        [Test, Description("��н���޸Ĺ̶������֤�����Ƿ�����Ǵ��ڵ�")]
        public void UpdateEmployeeAccountSetAccountSetNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = mocks.Stub<IEmployeeAccountSet>();

            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(null);
            mocks.ReplayAll();
            UpdateEmployeeAccountSet target =
                new UpdateEmployeeAccountSet(1, new Model.PayModule.AccountSet(1, ""), "", Convert.ToDateTime("2008-10-10"), "", iAccountSet,
                                             iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            mocks.VerifyAll();
            Assert.AreEqual("�����ײ�����", exception);
        }

        [Test, Description("��н���޸Ĺ̶������֤Ա�������Ƿ�����Ǵ��ڵ�")]
        public void UpdateEmployeeAccountSetEmployeeAccountSetNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = mocks.Stub<IEmployeeAccountSet>();

            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(null);
            mocks.ReplayAll();
            UpdateEmployeeAccountSet target =
                new UpdateEmployeeAccountSet(1, new Model.PayModule.AccountSet(1, ""), "", Convert.ToDateTime("2008-10-10"), "", iAccountSet,
                                             iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            mocks.VerifyAll();
            Assert.AreEqual("��Ա������������", exception);
        }

        [Test, Description("��н���޸Ĺ̶�������ݿ���ʴ���")]
        public void UpdateEmployeeAccountSetDBError()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));

            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(new EmployeeSalary(1));
            Expect.Call(iEmployeeAccountSet.UpdateEmployeeAccountSet(1, accountSet)).Return(1);
            mocks.ReplayAll();
            UpdateEmployeeAccountSet target =
                new UpdateEmployeeAccountSet(1, accountSet, "", Convert.ToDateTime("2008-10-10"), "", iAccountSet,
                                             iEmployeeAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            Assert.AreEqual("���ݿ���ʴ���", exception);
        }

        [Test, Description("��н���޸Ĺ̶���������ɹ�")]
        public void UpdateEmployeeAccountSetSuccess()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeAccountSet iEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));

            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");

            AdjustSalaryHistory adjustSalaryHistory = new AdjustSalaryHistory();
            adjustSalaryHistory.AccountsBackName = "";
            adjustSalaryHistory.AccountSet = accountSet;
            adjustSalaryHistory.ChangeDate = Convert.ToDateTime("2008-10-10");
            adjustSalaryHistory.Description = "";

            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(new EmployeeSalary(1));
            Expect.Call(iEmployeeAccountSet.UpdateEmployeeAccountSet(1, accountSet)).Return(1);
            Expect.Call(delegate { iEmployeeAccountSet.InsertAdjustSalaryHistory(1, adjustSalaryHistory); }).IgnoreArguments();
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            mocks.ReplayAll();

            UpdateEmployeeAccountSet target =
                new UpdateEmployeeAccountSet(1, accountSet, "", Convert.ToDateTime("2008-10-10"), "", iAccountSet,
                                             iEmployeeAccountSet);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
