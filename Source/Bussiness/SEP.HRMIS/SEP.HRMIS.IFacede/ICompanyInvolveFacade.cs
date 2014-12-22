using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 根据公司获取相关信息接口
    /// </summary>
    public interface ICompanyInvolveFacade
    {
        /// <summary>
        /// 获得某个公司的所有员工
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID);
        /// <summary>
        /// 获得某个公司的所有职位
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Position> GetPositionByCompanyID(int companyID);
        /// <summary>
        /// 获得某个公司的所有部门
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentByCompanyID(int companyID);
        /// <summary>
        /// 获得系统中所有公司
        /// </summary>
        /// <returns></returns>
        List<Department> GetAllCompanyHaveEmployee();
        /// <summary>
        /// 根据帐号，获得系统中所有公司
        /// </summary>
        /// <param name="_operator"></param>
        /// <param name="powerID"></param>
        /// <returns></returns>
        List<Department> GetAllCompanyHaveEmployee(Account _operator, int powerID);
        /// <summary>
        /// 获得在companyID公司内employeeID所管辖的部门
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(int employeeID, int companyID);
        /// <summary>
        /// 获得employeeID在companyID中所管辖的部门以及拥有权限的部门
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="_operator"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        List<Department> GetDepartmentInCompanyByAuthAndEmployee(int companyID, Account _operator, int power);
    }
}
