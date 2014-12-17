using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Logic
{
    public class EmployeeSalaryHistoryLogic
    {
        public static List<EmployeeSalaryHistoryEntity> GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID,
                                                                                                        DateTime? dtFrom,
                                                                                                        DateTime? dtTo)
        {
            var employeeSalaryHistory =
                EmployeeSalaryHistoryDA.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employeeID, dtFrom, dtTo);
            foreach (var employeeSalaryHistoryEntity in employeeSalaryHistory)
            {
                IFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(employeeSalaryHistoryEntity.EmployeeAccountSetItems, 0,
                                                   employeeSalaryHistoryEntity.EmployeeAccountSetItems.Length);
                employeeSalaryHistoryEntity.AccountSetItem = formatter.Deserialize(ms) as List<AccountSetItem>;
            }
            return employeeSalaryHistory;
        }
    }
}