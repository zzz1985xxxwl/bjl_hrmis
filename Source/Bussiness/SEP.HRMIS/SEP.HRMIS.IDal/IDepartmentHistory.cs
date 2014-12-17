//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IDepartmentHistory.cs
// ������: ���h��
// ��������: 2008-11-11
// ����: DepartmentHistory �ӿ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ������ʷ���ݽ���
    /// </summary>
    public interface IDepartmentHistory
    {
        /// <summary>
        /// ���²�����ʷ
        /// </summary>
        /// <param name="departmentHistoryList"></param>
        /// <returns></returns>
        int InsertDepartmentHistory(List<DepartmentHistory> departmentHistoryList);
        /// <summary>
        /// ���dtʱ��㲿�ŵ���Ϣ
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        DepartmentHistory GetDepartmentByDepartmentIDAndDateTime(int departmentID, DateTime dt);
        /// <summary>
        /// ���dtʱ������֯�ܹ�,�޽ṹ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentNoStructByDateTime(DateTime dt);
        /// <summary>
        /// ���dtʱ������֯�ܹ�,�����νṹ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        List<Department> GetDepartmentTreeStructByDateTime(DateTime dt);
    }
}
