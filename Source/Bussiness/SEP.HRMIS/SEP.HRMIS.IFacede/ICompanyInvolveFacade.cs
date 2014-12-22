using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ���ݹ�˾��ȡ�����Ϣ�ӿ�
    /// </summary>
    public interface ICompanyInvolveFacade
    {
        /// <summary>
        /// ���ĳ����˾������Ա��
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID);
        /// <summary>
        /// ���ĳ����˾������ְλ
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Position> GetPositionByCompanyID(int companyID);
        /// <summary>
        /// ���ĳ����˾�����в���
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentByCompanyID(int companyID);
        /// <summary>
        /// ���ϵͳ�����й�˾
        /// </summary>
        /// <returns></returns>
        List<Department> GetAllCompanyHaveEmployee();
        /// <summary>
        /// �����ʺţ����ϵͳ�����й�˾
        /// </summary>
        /// <param name="_operator"></param>
        /// <param name="powerID"></param>
        /// <returns></returns>
        List<Department> GetAllCompanyHaveEmployee(Account _operator, int powerID);
        /// <summary>
        /// �����companyID��˾��employeeID����Ͻ�Ĳ���
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="companyID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentAndChildrenDeptByEmployeeIDAndCompanyID(int employeeID, int companyID);
        /// <summary>
        /// ���employeeID��companyID������Ͻ�Ĳ����Լ�ӵ��Ȩ�޵Ĳ���
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="_operator"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        List<Department> GetDepartmentInCompanyByAuthAndEmployee(int companyID, Account _operator, int power);
    }
}
