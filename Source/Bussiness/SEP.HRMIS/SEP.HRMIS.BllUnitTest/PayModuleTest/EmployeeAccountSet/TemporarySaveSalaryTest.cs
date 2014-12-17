//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TemporarySaveSalaryTest.cs
// ������: ����
// ��������: 2008-12-25
// ����: �ݴ�Ա�����ʵ�Ԫ����
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
    public class TemporarySaveSalaryTest
    {
        [Test, Description("ΪԱ���������ף���֤Ա�������Ƿ�����Ǵ��ڵ�")]
        public void TSaveSalaryAccountSetNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(null);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(0, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""), "", "", 1,
                                             iEmployeeSalary, iAccountSet);
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

        [Test, Description("����н�ʵ�id������")]
        public void CreateEmployeeAccountSetDBError()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(null);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""), "", "", 1,
                                             iEmployeeSalary, iAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            Assert.AreEqual("��нˮ��¼������", exception);
        }

        [Test, Description("����н�ʵ�id������")]
        public void CreateEmployeeAccountClosed()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.HistoryId = 1;
            history.EmployeeAccountSet = accountSet;
            history.VersionNumber = 1;
            history.SalaryDateTime = Convert.ToDateTime("2008-10-10");
            history.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.AccountClosed;
            history.AccountsBackName = "";
            history.Description = "";
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(history);
            Expect.Call(iEmployeeSalary.UpdateEmployeeSalaryHistory(1, history)).Return(1);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""),
                                                    "", "", 1,
                                                    iEmployeeSalary, iAccountSet);
            string exception = "";
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            Assert.AreEqual("��нˮ��¼�ѷ���", exception);
        }

        [Test, Description("����н�ʣ������ɹ�")]
        public void UpdateSalarySuccess()
        {
            MockRepository mocks = new MockRepository();
            IAccountSet iAccountSet = (IAccountSet)mocks.CreateMock(typeof(IAccountSet));
            IEmployeeSalary iEmployeeSalary = mocks.Stub<IEmployeeSalary>();
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory history = new EmployeeSalaryHistory();
            history.HistoryId = 1;
            history.EmployeeAccountSet = accountSet;
            history.VersionNumber = 1;
            history.SalaryDateTime = Convert.ToDateTime("2008-10-10");
            history.EmployeeSalaryStatus = EmployeeSalaryStatusEnum.TemporarySave;
            history.AccountsBackName = "";
            history.Description = "";
            Expect.Call(iAccountSet.GetWholeAccountSetByPKID(1)).Return(accountSet);
            Expect.Call(iEmployeeSalary.GetEmployeeSalaryHistoryByPKID(2)).Return(history);
            Expect.Call(iEmployeeSalary.UpdateEmployeeSalaryHistory(1, history)).Return(1);
            mocks.ReplayAll();

            TemporarySaveEmployeeAccountSet target =
                new TemporarySaveEmployeeAccountSet(2, 1, Convert.ToDateTime("2008-10-10"), new Model.PayModule.AccountSet(1, ""),
                                                    "", "", 1,
                                                    iEmployeeSalary, iAccountSet);

            target.Excute();
            mocks.ReplayAll();
        }
    }
}
