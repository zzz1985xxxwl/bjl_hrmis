using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获得员工历史
    /// </summary>
    public class GetEmployeeHistory
    {
        private readonly IEmployeeHistory _dalEmployeeHistory = new EmployeeHistoryDal();
        private GetDepartmentHistory _GetDepartmentHistory = new GetDepartmentHistory();
        private IPositionHistory _IPositionHistory = new PositionHistoryDal();
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetEmployeeHistory()
        {
        }
        /// <summary>
        /// 构造函数，测试
        /// </summary>
        /// <param name="iEmployeeHistory"></param>
        public GetEmployeeHistory(IEmployeeHistory iEmployeeHistory)
        {
            _dalEmployeeHistory = iEmployeeHistory;
        }
        /// <summary>
        /// 测试
        /// </summary>
        public GetDepartmentHistory MockGetDepartmentHistory
        {
            set { _GetDepartmentHistory = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public IPositionHistory MockPositionHistroy
        {
            set { _IPositionHistory = value; }
        }

        /// <summary>
        /// 通过员工历史表ID得到员工所有信息
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        public EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID)
        {
            EmployeeHistory history = _dalEmployeeHistory.GetEmployeeHistoryByEmployeeHistoryID(employeeHistoryID);
            if (history != null)
            {
                history.Employee.Account.Position = _IPositionHistory.GetPositionByPositionIDAndDateTime(history.Employee.Account.Position.Id,
                                                       history.OperationTime);
            }
            return history;
        }

        /// <summary>
        /// 通过员工历史表ID得到员工所有基本信息
        /// </summary>
        /// <param name="employeeHistoryID"></param>
        /// <returns></returns>
        public EmployeeHistory GetEmployeeHistoryBasicInfoByEmployeeHistoryID(int employeeHistoryID)
        {
            return _dalEmployeeHistory.GetEmployeeHistoryBasicInfoByEmployeeHistoryID(employeeHistoryID);
        }

        /// <summary>
        /// 根据员工帐号ID获得所有员工的历史信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID)
        {
            return _dalEmployeeHistory.GetEmployeeHistoryByAccountID(accountID);
        }

        /// <summary>
        /// 通过员工ID得到员工所有的历史基本信息记录
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID)
        {
            return _dalEmployeeHistory.GetEmployeeHistoryBasicInfoByAccountID(accountID);
        }

        /// <summary>
        /// 查找某一时间下的所有在职员工
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Employee> GetOnDutyEmployeeBasicInfoByDateTime(DateTime dt)
        {
            List<Employee> returnEmployeeList = new List<Employee>();
            List<EmployeeHistory> employeeHistoryList = _dalEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt);
            foreach (EmployeeHistory employeeHistory in employeeHistoryList)
            {
                if (employeeHistory.Employee.IsOnDutyByDateTime(dt))
                {
                    returnEmployeeList.Add(employeeHistory.Employee);
                }
            }
            return returnEmployeeList;
        }
        /// <summary>
        /// 查找某一时间某公司下的所有在职员工
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        public List<Employee> GetOnDutyEmployeeBasicInfoByDateTimeAndCompany(DateTime dt, int companyID)
        {
            List<Employee> returnEmployeeList = new List<Employee>();
            List<Employee> employeeList = GetOnDutyEmployeeBasicInfoByDateTime(dt);
            foreach (Employee employee in employeeList)
            {
                if (companyID == -1 || employee.EmployeeDetails.Work.Company.Id == companyID)
                {
                    returnEmployeeList.Add(employee);
                }
            }
            return returnEmployeeList;
        }

        /// <summary>
        /// 查找某一时间下，某一部门下的所有直属员工
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByDepartmentAndDateTime(int departmentID, DateTime dt)
        {
            List<EmployeeHistory> employeeHistoryList = _dalEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(departmentID, dt);
            List<Employee> iRet = Employee.ConvertEmployeeHistorysToEmployee(employeeHistoryList);
            return iRet;
        }

        /// <summary>
        /// 查找某一时间下，某一部门及其子部门下的所有员工
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeByDepartmentAndDateTime(int departmentID, DateTime dt, bool onlyBasicInfo)
        {
            List<Employee> returnEmployeeList = new List<Employee>();
            List<Department> departmentList =
                _GetDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID, dt);

            List<EmployeeHistory> dtEmployeeHistoryList = onlyBasicInfo
                                                              ? _dalEmployeeHistory.
                                                                    GetEmployeeHistoryBasicInfoByDateTimeAndDept(dt, departmentList)
                                                              : _dalEmployeeHistory.GetEmployeeHistoryByDateTimeAndDept(dt, departmentList);
            foreach (EmployeeHistory eh in dtEmployeeHistoryList)
            {
                //if (eh != null && eh.Employee != null && eh.Employee.Account != null && eh.Employee.Account.Dept != null
                //    && Department.FindDepartmentInTreeStruct(departmentList, eh.Employee.Account.Dept.Id) != null)
                //{
                    eh.Employee.EmployeeDetails.StatisticsTime = dt;
                    eh.Employee.EmployeeDetails.Work.StatisticsTime = dt;
                    returnEmployeeList.Add(eh.Employee);
                //}
            }
            return returnEmployeeList;
        }

        /// <summary>
        /// 获取再dt时刻的在职员工
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeeOnDutyByDepartmentAndDateTime(int departmentID, DateTime dt, bool onlyBasicInfo,
            Account loginUser, int powersID, List<Employee> allEmployeeSource)
        {
            GetEmployeeByDateTime getEmployeeByDateTime = new GetEmployeeByDateTime();
            List<Employee> OnDutyEmployeeList =
                getEmployeeByDateTime.OnDutyEmployees(dt, departmentID, onlyBasicInfo, true, allEmployeeSource);
            return HrmisUtility.RemoteUnAuthEmployee(OnDutyEmployeeList, AuthType.HRMIS, loginUser,
                                                     HrmisPowers.A405);
        }
        /// <summary>
        /// 获得员工离职时刻的信息
        /// </summary>
        public Employee GetEmployeeAtLeaveDate(int accountID, bool onlyBasicInfo)
        {
            EmployeeHistory eh=
                onlyBasicInfo
                    ? _dalEmployeeHistory.GetEmployeeHistoryBasicInfoAtLeaveDate(accountID)
                    : _dalEmployeeHistory.GetEmployeeHistoryAtLeaveDate(accountID);
            if(eh!=null)
            {
                return eh.Employee;
            }
            return null;
        }
        /// <summary>
        /// 获得员工某一时刻的最新信息
        /// </summary>
        public Employee GetEmployeeByDate(int accountID, bool onlyBasicInfo, DateTime date)
        {
            EmployeeHistory eh =
                onlyBasicInfo
                    ? _dalEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(accountID, date)
                    : _dalEmployeeHistory.GetEmployeeHistoryByDateTime(accountID, date);
            if (eh != null)
            {
                return eh.Employee;
            }
            return null;
        }
    }
}
