using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// IAuthDal接口
    /// </summary>
    public interface IAuthDal
    {
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="accountId">用户Id</param>
        List<Auth> GetAccountAuth(int accountId);

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="accountId">用户Id</param>
        List<Auth> GetAccountAuthList(int accountId);

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="accountId">用户Id</param>
        /// <param name="authId">权限Id</param>
        /// <param name="departmentID">部门Id</param>
        void SetAccountAuth(int accountId, int authId, int departmentID);

        /// <summary>
        /// 删除用户所有权限
        /// </summary>
        /// <param name="accountId">用户Id</param>
        void CancelAccountAllAuth(int accountId);

        /// <summary>
        /// 根据权限、帐号查找该帐号该权限下的范围
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="authID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentByBackAccontsID(int accountId, int authID);

        /// <summary>
        /// 获取对某部门有某权限的账号
        /// </summary>
        List<Account> GetAccountsByAuthIdAndDeptId(int authId, int? deptId);
    }
}
