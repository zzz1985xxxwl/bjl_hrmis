using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.CompanyInvolve
{
    /// <summary>
    /// 根据公司获取相关信息
    /// </summary>
    public class GetCompanyInvolve
    {
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static IEmployee _dalEmployee = new EmployeeDal();
        private static IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetCompanyInvolve()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetCompanyInvolve(IEmployee mockIEmployee, IAccountBll mockIAccountBll,
            IDepartmentBll mockIDepartmentBll)
        {
            _dalEmployee = mockIEmployee;
            _IAccountBll = mockIAccountBll;
            _IDepartmentBll = mockIDepartmentBll;
        }

        /// <summary>
        /// 获得公司CompanyID下所有的员工的基本信息
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID)
        {
            List<Employee> employeeList = _dalEmployee.GetEmployeeBasicInfoByCompanyID(companyID);
            if (employeeList == null)
            {
                return new List<Employee>();
            }
            foreach (Employee employee in employeeList)
            {
                LoadSEPInfo.SetEmployeeAccountInfo(employee.Account.Id, employee, _IAccountBll, _IDepartmentBll);
            }
            return employeeList;
        }
        /// <summary>
        /// 获得公司CompanyID下所有的部门
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentByCompanyID(int companyID)
        {
            return DepartmentLogic.GetDepartmentByCompanyID(companyID);
            //List<Department> departmentList = new List<Department>();
            //List<Employee> employeeList = GetEmployeeBasicInfoByCompanyID(companyID);
            //foreach (Employee employee in employeeList)
            //{
            //    bool isContain = false;
            //    foreach (Department department in departmentList)
            //    {
            //        if (department.Id == employee.Account.Dept.Id)
            //        {
            //            isContain = true;
            //            break;
            //        }
            //    }
            //    if (!isContain)
            //    {
            //        departmentList.Add(employee.Account.Dept);
            //    }
            //}
            //return departmentList;
        }
        /// <summary>
        /// 获得公司CompanyID下所有的职位
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<Position> GetPositionByCompanyID(int companyID)
        {
            //List<Position> positionList = new List<Position>();
            //List<Employee> employeeList = GetEmployeeBasicInfoByCompanyID(companyID);
            //foreach (Employee employee in employeeList)
            //{
            //    bool isContain = false;
            //    foreach (Position position in positionList)
            //    {
            //        if (position.Id == employee.Account.Position.Id)
            //        {
            //            isContain = true;
            //            break;
            //        }
            //    }
            //    if (!isContain)
            //    {
            //        positionList.Add(employee.Account.Position);
            //    }
            //}
            //return positionList;
            return PositionLogic.GetPositionByCompanyID(companyID);
        }
        /// <summary>
        /// 获得系统中所有公司
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllCompanyHaveEmployee()
        {
            List<Department> deptRet = new List<Department>();
            List<Department> departmentList = _dalEmployee.GetAllCompanyHaveEmployee();
            for (int i = 0; i < departmentList.Count; i++)
            {
                Department dept = _IDepartmentBll.GetDepartmentById(departmentList[i].Id, null);
                if (dept != null)
                {
                    deptRet.Add(dept);
                }
            }
            return deptRet;
        }

        /// <summary>
        /// 根据操作人的权限，获得系统中所有公司
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllCompanyHaveEmployee(Account _operator, int powerID)
        {
            //List<Employee> employeeList = new GetEmployee().GetAllEmployeeBasicInfo();
            //employeeList = HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, _operator, powerID);
            //List<Department> deptRet = new List<Department>();
            //foreach (Employee employee in employeeList)
            //{
            //    if (!Tools.IsDeptListContainsDept(deptRet, employee.EmployeeDetails.Work.Company))
            //    {
            //        Department dept = _IDepartmentBll.GetDepartmentById(employee.EmployeeDetails.Work.Company.Id, null);
            //        if (dept != null)
            //        {
            //            deptRet.Add(dept);
            //        }
            //    }
            //}
            return DepartmentLogic.GetCompanyByAccountAuth(_operator.Id,powerID);
        }
        /// <summary>
        /// 获得在companyID公司内employeeID所管辖的部门
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(int employeeID, int companyID)
        {
            List<Department> dept1 = _IDepartmentBll.GetDepartmentAndChildrenDeptByLeaderID(employeeID);
            List<Department> dept2 = GetDepartmentByCompanyID(companyID);
            //dept1与dept2取交集
            return _IDepartmentBll.MixDepartmentList(dept1, dept2);
        }
        /// <summary>
        /// 获得employeeID在companyID中所管辖的部门以及拥有权限的部门
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="_operator"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentInCompanyByAuthAndEmployee(int companyID, Account _operator, int power)
        {
            List<Department> deptList1 =
                Tools.RemoteUnAuthDeparetment(GetDepartmentByCompanyID(companyID), AuthType.HRMIS, _operator, power);
            List<Department> deptList2 = GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(_operator.Id, companyID);
            List<Department> mixedDeptList = _IDepartmentBll.MixDepartmentList(deptList1, deptList2);
            return mixedDeptList;
        }
    }
}
