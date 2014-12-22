//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetDepartmentHistory.cs
// ������:wangyueqi
// ��������: 2008-11-13
// ����: ʵ��GetDepartmentHistory�ӿ�
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ��ȡ������ʷ
    /// </summary>
    public class GetDepartmentHistory
    {
        private readonly IDepartmentHistory _DalDepartmentHistory = new DepartmentHistoryDal();
        /// <summary>
        /// ��ȡ������ʷ���캯��
        /// </summary>
        public GetDepartmentHistory()
        {
        }
        /// <summary>
        /// ��ȡ������ʷ���캯��
        /// </summary>
        /// <param name="mockDalDepartmentHistory"></param>
        public GetDepartmentHistory(IDepartmentHistory mockDalDepartmentHistory)
        {
            _DalDepartmentHistory = mockDalDepartmentHistory;
        }
        /// <summary>
        /// ���dtʱ������֯�ܹ�,�޽ṹ
        /// </summary>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentNoStructByDateTime(DateTime searchTime)
        {
            return _DalDepartmentHistory.GetDepartmentNoStructByDateTime(searchTime);
        }
        /// <summary>
        /// ���dtʱ���deparmentID�����νṹ�����б���ʽ����
        /// </summary>
        /// <param name="deparmentID"></param>
        /// <param name="searchTime"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentListStructByDepartmentIDAndDateTime(int deparmentID, DateTime searchTime)
        {
            List<Department> departmentList = _DalDepartmentHistory.GetDepartmentNoStructByDateTime(searchTime);
            List<Department> newDepartment = new List<Department>();
            foreach (Department department in departmentList)
            {
                if (department.Id == deparmentID)
                {
                    newDepartment.Add(department);
                    GenerateTreeStruct(departmentList, newDepartment, department);
                    break;
                }
            }
            return newDepartment;
        }

        private static void GenerateTreeStruct(List<Department> oldDepartment,
            List<Department> newDepartment, Department parentDepartment)
        {
            if (oldDepartment == null)
            {
                oldDepartment = new List<Department>();
            }
            if (newDepartment == null)
            {
                newDepartment = new List<Department>();
            }
            foreach (Department department in oldDepartment)
            {
                if (department.ParentDepartment.DepartmentID == parentDepartment.DepartmentID)
                {
                    newDepartment.Add(department);
                    //�ݹ��Һ���
                    GenerateTreeStruct(oldDepartment, newDepartment, department);
                }
            }
        }

        /// <summary>
        /// ���dtʱ������֯�ܹ�,�����νṹ
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentTreeStructByDateTime(DateTime dt)
        {
            return _DalDepartmentHistory.GetDepartmentTreeStructByDateTime(dt);
        }
    }
}

