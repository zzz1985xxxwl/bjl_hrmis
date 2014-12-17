//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IDepartmentBll.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ����ҵ��ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using System;

namespace SEP.IBll.Departments
{
    /// <summary>
    /// ����ҵ��ӿ�
    /// </summary>
    public interface IDepartmentBll
    {
        void CreateDept(Department dept, Account loginUser);
        int CreateDept(int parentId, Department dept, Account loginUser);

        void UpdateDept(Department dept, Account loginUser);
        void UpdateDept(int parentId, Department dept, Account loginUser);
        void DeleteDept(int deptId, Account loginUser);

        /// <summary>
        /// ��ȡ��ǰ������֯�ṹ
        /// </summary>
        List<Department> GetAllDepartment(Account loginUser);
        /// <summary>
        /// ��ȡ��ǰ������֯�ṹ
        /// </summary>
        List<Department> GetAllDepartmentTree(Account loginUser);

        /// <summary>
        /// ���ݲ���Id��ȡ������Ϣ
        /// </summary>
        Department GetDepartmentById(int id, Account loginUser);

        /// <summary>
        /// ���ݲ���LeaderId��ȡ���й���Ĳ���
        /// </summary>
        List<Department> GetManageDepts(int leaderId, Account loginUser);

        /// <summary>
        /// ����Ա��Id��ȡ���ڲ���
        /// </summary>
        Department GetDept(int accountId, Account loginUser);

        /// <summary>
        /// ���ݲ���Id��ȡ�ϼ�������Ϣ
        /// </summary>
        Department GetParentDept(int deptId, Account loginUser);
        /// <summary>
        /// ��ȡ���в���
        /// </summary>
        List<Department> GetAllDepartmentOrderName();

        /// <summary>
        /// ��ȡ���в���
        /// </summary>
        List<Department> GetAllDepartment();
        /// <summary>
        /// ��ȡ��ǰ������֯�ṹ
        /// </summary>
        List<Department> GetAllDepartmentTree();
        /// <summary>
        /// ���ݲ���LeaderId��ȡ���й���Ĳ���
        /// </summary>
        /// <param name="leaderId">����LeaderId</param>
        List<Department> GetManageDepts(int leaderId);
        /// <summary>
        /// ��ȡEmployeeID�����漰���Ĳ��ţ�����EmployeeID���ڲ��š�����Ĳ����Լ�����Ĳ����µ��Ӳ���
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentEmployeeInvolve(int employeeID);

        /// <summary>
        /// �ݹ��ȡ�����Ӳ���
        /// </summary>
        List<Department> GetChildDeptList(int deptId);

        /// <summary>
        /// ��ǰԱ���Ƿ���Department����������Ĳ��ŵ��Ӳ�����Department
        /// </summary>
        /// <param name="departmentid"></param>
        /// <param name="employeeid"></param>
        /// <returns>�ǣ�true����false</returns>
        bool IsDepartmentManagedByEmployee(int departmentid, int employeeid);
        
        /// <summary>
        /// ��ղ���������
        /// </summary>
        void ClearCache();
        /// <summary>
        /// ����ɢ��deptList�����Դ���С���ڵ��г�����������ṹ
        /// </summary>
        /// <param name="deptList"></param>
        /// <returns></returns>
        List<Department> GenerateDeptListWithLittleParentDept(List<Department> deptList);
        /// <summary>
        /// ��ȡlist����
        /// </summary>
        /// <param name="deptList1"></param>
        /// <param name="deptList2"></param>
        /// <returns></returns>
        List<Department> MixDepartmentList(List<Department> deptList1, List<Department> deptList2);
        /// <summary>
        /// ��ȡ��ǰԱ����������в��ţ���������Ĳ��ŵ�������������Ĳ���
        /// </summary>
        /// <param name="leaderID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentAndChildrenDeptByLeaderID(int leaderID);

        List<Department> GetDepartmentByNameString(string sendDepartment, out string errorname);
    }
}
