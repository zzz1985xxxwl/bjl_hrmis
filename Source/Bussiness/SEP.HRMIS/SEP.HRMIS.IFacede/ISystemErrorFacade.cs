using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISystemErrorFacade
    {
        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetDiyProcessError(bool showIgnore, ErrorType type, Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetDoorCardError(bool showIgnore, Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetDutyCalssError(bool showIgnore, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetAttendanceError(string EmployeeName, int DepartmentID,
                                             DateTime Form, DateTime To, Account account, int powers);

        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetPhoneMessageByCondition(string name, PhoneMessageStatus status,Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        List<SystemError> GetEmployeeContractError(string employeeName, int departmentID,
                                                   DateTime currentDate, Account account, int powers);
        
        /// <summary>
        /// </summary>
        void UpdateErrorStatus(SystemError error);
    }
}