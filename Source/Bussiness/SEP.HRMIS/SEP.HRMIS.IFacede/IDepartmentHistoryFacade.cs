using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 部门历史
    /// </summary>
    public interface IDepartmentHistoryFacade
    {
        /// <summary>
        /// 新增部门历史，拍下整个公司历史信息
        /// </summary>
        /// <param name="operatorAccount"></param>
        void AddDepartmentHistory(Account operatorAccount);
        /// <summary>
        /// 获得dt时间点的组织架构,无结构
        /// </summary>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        List<Department> GetDepartmentNoStructByDateTime(DateTime searchTime);
        /// <summary>
        /// 获得dt时间点deparmentID的树形结构，以列表形式返回
        /// </summary>
        /// <param name="deparmentID"></param>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        List<Department> GetDepartmentListStructByDepartmentIDAndDateTime(int deparmentID, DateTime searchTime);
        /// <summary>
        /// 获得dt时间点的组织架构,有树型结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentTreeStructByDateTime(DateTime dt);
    }
}
