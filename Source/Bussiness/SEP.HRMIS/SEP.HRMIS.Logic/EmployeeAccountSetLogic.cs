using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Logic
{
    public class EmployeeAccountSetLogic
    {
        public static List<EmployeeAccountSetEntity> GetEmployeeAccountSetByCondition(string employeeName, int departmentID,
            int positionID, EmployeeTypeEnum employeeTypeEnum, bool recursionDepartment, Account loginUser, int employeeStatus)
        {
            var departmentids = new List<int>();
            if (departmentID > 0)
            {
                departmentids.Add(departmentID);
                if (recursionDepartment)
                {
                    departmentids.AddRange(DepartmentLogic.GetChildDepartment(departmentID).Select(x => x.PKID));
                }
            }
            var list =
                EmployeeAccountSetDA.GetEmployeeAccountSetByCondition(employeeName, departmentids, positionID,
                                                                      (int)employeeTypeEnum,
                                                                      AccountAuthDA.GetAccountAuthDepartment(
                                                                          loginUser.Id, HrmisPowers.A604),
                                                                      employeeStatus);
            return list;
        }
    }
}
