using System.Collections.Generic;
using SEP.HRMIS.Bll.CompanyInvolve;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 根据公司获取相关信息接口
    /// </summary>
    public class CompanyInvolveFacade : ICompanyInvolveFacade
    {
        public List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID)
        {
            return new GetCompanyInvolve().GetEmployeeBasicInfoByCompanyID(companyID);
        }

        public List<Position> GetPositionByCompanyID(int companyID)
        {
            return new GetCompanyInvolve().GetPositionByCompanyID(companyID);
        }

        public List<Department> GetDepartmentByCompanyID(int companyID)
        {
            return new GetCompanyInvolve().GetDepartmentByCompanyID(companyID);
        }

        public List<Department> GetAllCompanyHaveEmployee()
        {
            return new GetCompanyInvolve().GetAllCompanyHaveEmployee();
        }

        public List<Department> GetAllCompanyHaveEmployee(Account _operator, int powerID)
        {
            return new GetCompanyInvolve().GetAllCompanyHaveEmployee(_operator, powerID);
        }

        public List<Department> GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(int employeeID, int companyID)
        {
            return new GetCompanyInvolve().GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(employeeID, companyID);
        }

        public List<Department> GetDepartmentInCompanyByAuthAndEmployee(int companyID, Account _operator, int power)
        {
            return new GetCompanyInvolve().GetDepartmentInCompanyByAuthAndEmployee(companyID, _operator, power);
        }
    }
}
