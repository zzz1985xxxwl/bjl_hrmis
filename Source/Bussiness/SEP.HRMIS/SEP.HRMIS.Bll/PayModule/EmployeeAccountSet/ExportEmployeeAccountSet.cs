using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// ����Ա������
    /// </summary>
    public class ExportEmployeeAccountSet
    {
        private readonly Account _AccountOperator;
        private readonly string _EmployeeName;
        private readonly int _DepartmentID;
        private readonly int _PositionID;
        private readonly EmployeeTypeEnum _EmployeeTypeEnum;
        private readonly bool _IsRecursionDepartment;
        private readonly int _EmployeeStatus;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="positionID"></param>
        /// <param name="employeeType"></param>
        /// <param name="isRecursionDepartment"></param>
        /// <param name="accountOperator"></param>
        /// <param name="employeeStatus"></param>
        public ExportEmployeeAccountSet(string employeeName, int departmentID, int positionID, EmployeeTypeEnum employeeType,
            bool isRecursionDepartment, Account accountOperator, int employeeStatus)
        {
            _EmployeeName = employeeName;
            _DepartmentID = departmentID;
            _PositionID = positionID;
            _IsRecursionDepartment = isRecursionDepartment;
            _EmployeeTypeEnum = employeeType;
            _AccountOperator = accountOperator;
            _EmployeeStatus = employeeStatus;
        }
        /// <summary>
        /// ִ�е�������
        /// </summary>
        /// <returns></returns>
        public DataTable Excute()
        {
            List<EmployeeSalary> employeeSalarys =
                new GetEmployeeAccountSet().GetEmployeeAccountSetByCondition(_EmployeeName, _DepartmentID, _PositionID,
                                                                             _EmployeeTypeEnum, _IsRecursionDepartment,
                                                                             _AccountOperator, _EmployeeStatus);
            foreach (EmployeeSalary employeeSalary in employeeSalarys)
            {
                EmployeeSalary employeeSalaryInfo =
                    new GetEmployeeAccountSet().GetEmployeeAccountSetByEmployeeID(employeeSalary.Employee.Account.Id);
                if (employeeSalaryInfo != null)
                {
                    employeeSalary.AccountSet = employeeSalaryInfo.AccountSet;
                }
            }
            //������
            DataTable dt = new DataTable();
            dt.Columns.Add("Ա������");
            dt.Columns.Add("��������");
            dt.Columns.Add("ְλ");
            dt.Columns.Add("Ա������");
            dt.Columns.Add("��������");
            foreach (EmployeeSalary employeeSalary in employeeSalarys)
            {
                if (employeeSalary.AccountSet == null || employeeSalary.AccountSet.Items == null)
                {
                    continue;
                }
                foreach (AccountSetItem accountSetItem in employeeSalary.AccountSet.Items)
                {
                    if (accountSetItem.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.FixedField.Id
                        && !dt.Columns.Contains(accountSetItem.AccountSetPara.AccountSetParaName))
                    {
                        dt.Columns.Add(accountSetItem.AccountSetPara.AccountSetParaName);
                    }
                }
            }
            //��ֵtable
            foreach (EmployeeSalary employeeSalary in employeeSalarys)
            {
                DataRow dr = dt.NewRow();
                dr["Ա������"] = employeeSalary.Employee.Account.Name;
                dr["��������"] = employeeSalary.Employee.Account.Dept.Name;
                dr["ְλ"] = employeeSalary.Employee.Account.Position.Name;
                dr["Ա������"] = EmployeeTypeUtility.EmployeeTypeDisplay(employeeSalary.Employee.EmployeeType);
                dr["��������"] = employeeSalary.AccountSet.AccountSetName;
                if (employeeSalary.AccountSet != null && employeeSalary.AccountSet.Items != null)
                {
                    foreach (AccountSetItem accountSetItem in employeeSalary.AccountSet.Items)
                    {
                        if (accountSetItem.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.FixedField.Id
                            && dt.Columns.Contains(accountSetItem.AccountSetPara.AccountSetParaName))
                        {
                            dr[accountSetItem.AccountSetPara.AccountSetParaName] = accountSetItem.CalculateResult;
                        }
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
