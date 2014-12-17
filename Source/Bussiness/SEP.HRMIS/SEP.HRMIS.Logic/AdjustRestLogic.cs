using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Logic
{
    public class AdjustRestLogic
    {
        public static List<AdjustRestEntity> GetAdjustRestByCondition(string employeeName, int departmentID,
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
            DateTime dt = DateTime.Now;
            //判断是不是12月21号以后
            if (dt.Month == AdjustRestUtility.StartTime.Month &&
                dt.Day >= AdjustRestUtility.StartTime.Day)
            {
                dt = dt.AddYears(1);
            }
            var list =
                AdjustRestDA.GetAdjustRestByCondition(employeeName, departmentids, positionID,
                                                                      (int)employeeTypeEnum,
                                                                      AccountAuthDA.GetAccountAuthDepartment(
                                                                          loginUser.Id, HrmisPowers.A405),
                                                                      employeeStatus, dt.Year - 1);
            return list;
        }
    }
}
