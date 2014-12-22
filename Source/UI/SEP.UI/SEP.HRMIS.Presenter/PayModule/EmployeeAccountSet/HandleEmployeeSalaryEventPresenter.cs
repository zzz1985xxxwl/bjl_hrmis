//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: HandleEmployeeSalaryEventPresenter.cs
// 创建者: liu.dan
// 创建日期: 2008-12-27
// 概述: 处理界面事件presenter
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class HandleEmployeeSalaryEventPresenter
    {
        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            InstanceFactory.CreateEmployeeAccountSetFacade();
        //private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        private readonly IAccountSetFacade _IAccountSetFacade =
            InstanceFactory.CreateAccountSetFacade();

        public EmployeeSalaryHistory GetEmployeeSalary(int pkid)
        {
            return _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(pkid);
        }

        public void TemporarySaveEvent(int salaryId, int employeeID, DateTime dt, Model.PayModule.AccountSet accountSet, string backAcountsName, string description, int versionNum)
        {
            _IEmployeeAccountSetFacade.TemporarySaveEmployeeAccountSetFacadeFacade(salaryId, employeeID, dt, accountSet,
                                                                                   backAcountsName, description,
                                                                                   versionNum);
        }

        public EmployeeSalary GetEmployeeAccountSet(int employeeId, Account loginUser)
        {
            return _IEmployeeAccountSetFacade.GetEmployeeAccountSetByEmployeeID(employeeId);
        }

        public Model.PayModule.AccountSet GetAccountSet(string name)
        {
            Model.PayModule.AccountSet accountSet = _IAccountSetFacade.GetAccountSetByName(name);

            if (accountSet != null)
            {
                return _IAccountSetFacade.GetWholeAccountSetByPKID(accountSet.AccountSetID);
            }
            return null;
        }

        public string SendEmployeeMail(int accountId, string salaryDate)
        {
            DateTime _SalaryTime;
            if (string.IsNullOrEmpty(salaryDate))
            {
                return EmployeeAccountSetUtility._SalaryTimeNotRight;
            }
            else if (!DateTime.TryParse(salaryDate, out _SalaryTime))
            {
                return EmployeeAccountSetUtility._SalaryTimeNotRight;
            }
            return _IEmployeeAccountSetFacade.SendEmployeeEmail(accountId, _SalaryTime);
        }


    }
}
