//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SystemErrorFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-10-09
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.SystemErrors;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// </summary>
    public class SystemErrorFacade : ISystemErrorFacade
    {
        /// <summary>
        /// 
        /// </summary>
        public List<SystemError> GetDiyProcessError(bool showIgnore, ErrorType type, Account loginUser)
        {
            return new GetSystemError(loginUser).GetDiyProcessError(showIgnore,type);
        }

        public List<SystemError> GetDoorCardError(bool showIgnore, Account loginUser)
        {
            return new GetSystemError(loginUser).GetDoorCardError(showIgnore);
        }

        public List<SystemError> GetAttendanceError(string EmployeeName, int DepartmentID, DateTime Form, DateTime To,
                                                    Account account, int powers)
        {
            GetAttendanceError getAttendanceError =
                new GetAttendanceError(EmployeeName, DepartmentID, Form, To, account, powers);
            getAttendanceError.Excute();
            return getAttendanceError.SystemErrorList;
        }

        public List<SystemError> GetPhoneMessageByCondition(string name, PhoneMessageStatus status,Account loginUser)
        {
            GetPhoneMessageError getphonemessageerror = new GetPhoneMessageError(name, status, loginUser);
            getphonemessageerror.Excute();
            return getphonemessageerror.SystemErrorList;
        }

        public List<SystemError> GetDutyCalssError(bool showIgnore, Account loginUser)
        {
            return new GetSystemError(loginUser).GetDutyCalssErrorError(showIgnore);
        }
        public List<SystemError> GetEmployeeContractError(string employeeName, int departmentID,
                                                     DateTime currentDate, Account account, int powers)
        {
            GetEmployeeContractError getEmployeeContractError =
                new GetEmployeeContractError(employeeName, departmentID, currentDate, account, powers);
            getEmployeeContractError.Excute();
            return getEmployeeContractError.SystemErrorList;
        }

        public void UpdateErrorStatus(SystemError error)
        {
            new UpdateSystemErrorStatus(error).Excute();
        }
    }
}