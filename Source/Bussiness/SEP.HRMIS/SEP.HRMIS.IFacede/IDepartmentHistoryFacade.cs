using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ������ʷ
    /// </summary>
    public interface IDepartmentHistoryFacade
    {
        /// <summary>
        /// ����������ʷ������������˾��ʷ��Ϣ
        /// </summary>
        /// <param name="operatorAccount"></param>
        void AddDepartmentHistory(Account operatorAccount);
        /// <summary>
        /// ���dtʱ������֯�ܹ�,�޽ṹ
        /// </summary>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        List<Department> GetDepartmentNoStructByDateTime(DateTime searchTime);
        /// <summary>
        /// ���dtʱ���deparmentID�����νṹ�����б���ʽ����
        /// </summary>
        /// <param name="deparmentID"></param>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        List<Department> GetDepartmentListStructByDepartmentIDAndDateTime(int deparmentID, DateTime searchTime);
        /// <summary>
        /// ���dtʱ������֯�ܹ�,�����ͽṹ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentTreeStructByDateTime(DateTime dt);
    }
}
