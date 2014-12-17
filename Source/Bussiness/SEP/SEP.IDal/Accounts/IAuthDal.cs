//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IAuthDal.cs
// ������: colbert
// ��������: 2009-02-02
// ����: Ȩ�޳־ò�ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.IDal.Accounts
{
    /// <summary>
    /// Ȩ�޳־ò�ӿ�
    /// </summary>
    public interface IAuthDal
    {
        /// <summary>
        /// ��ȡ����Ȩ��
        /// </summary>
        /// <returns></returns>
        List<Auth> GetAllAuthTree();

        /// <summary>
        /// ��ȡ�û�Ȩ��
        /// </summary>
        /// <param name="accountId">�û�Id</param>
        List<Auth> GetAccountAuthTree(int accountId);

        /// <summary>
        /// ��ȡ�û�Ȩ��
        /// </summary>
        /// <param name="accountId">�û�Id</param>
        List<Auth> GetAccountAuthList(int accountId);

        /// <summary>
        /// �����û�Ȩ��
        /// </summary>
        /// <param name="accountId">�û�Id</param>
        /// <param name="authId">Ȩ��Id</param>
        /// <param name="departmentID"></param>
        void SetAccountAuth(int accountId, int authId, int departmentID);

        /// <summary>
        /// ɾ���û�����Ȩ��
        /// </summary>
        /// <param name="accountId">�û�Id</param>
        void CancelAccountAllAuth(int accountId);

        /// <summary>
        /// ����Ȩ�ޡ��ʺŲ��Ҹ��ʺŸ�Ȩ���µķ�Χ
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="authID"></param>
        /// <returns></returns>
        List<Department> GetDepartmentByBackAccontsID(int accountId, int authID);

        /// <summary>
        /// ��ȡ��ĳ������ĳȨ�޵��˺�
        /// </summary>
        List<Account> GetAccountsByAuthIdAndDeptId(int authId, int? deptId);
    }
}
