using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա������������
    /// </summary>
    public class EmployeeUtility
    {
        /// <summary>
        /// ���ID�ظ������Ƴ�Ա��
        /// </summary>
        /// <param name="employeeList"></param>
        public static void RemoveRepeatEmployeeByID(IList<Employee> employeeList)
        {
            if (employeeList != null && employeeList.Count > 0)
            {
                for (int i = 0; i < employeeList.Count - 1; i++)
                {
                    int employeeID = employeeList[i].Account.Id;
                    bool NotOne = false;
                    for (int j = i + 1; j < employeeList.Count; j++)
                    {
                        if (employeeID == employeeList[j].Account.Id)
                            NotOne = true;
                    }
                    if (NotOne)
                    {
                        employeeList.RemoveAt(i);
                        i--;
                    }
                }
            }

        }
        /// <summary>
        /// ��Ա��������б����Ƴ�
        /// </summary>
        public static void RemoveEmployeeSelf(List<Employee> itsEmployees, int currentDirectId)
        {
            if (itsEmployees == null)
                return;

            for (int i = 0; i < itsEmployees.Count; i++)
            {
                if (itsEmployees[i].Account.Id == currentDirectId)
                {
                    itsEmployees.RemoveAt(i);
                    i--;
                }
            }
        }
        /// <summary>
        /// ��Ա���б��з�����ʺ��б�
        /// </summary>
        /// <param name="employeeList"></param>
        /// <returns></returns>
        public static List<Account> GetAccountListFromEmployeeList(List<Employee> employeeList)
        {
            List<Account> accountList =new List<Account>();
            foreach (Employee employee in employeeList)
            {
                accountList.Add(employee.Account);
            }
            return accountList;
        }
    }
}
