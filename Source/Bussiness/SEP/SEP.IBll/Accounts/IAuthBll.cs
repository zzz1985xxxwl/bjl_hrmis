//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IAuthBll.cs
// ������: colbert
// ��������: 2009-02-02
// ����: Ȩ��ҵ��ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.IBll.Accounts
{
    /// <summary>
    /// Ȩ��ҵ��ӿ�
    /// </summary>
    public interface IAuthBll
    {
        List<Auth> GetAllAuth();
        /// <summary>
        /// ��ȡ����Ȩ��
        /// </summary>
        List<Auth> GetAllAuth(Account loginUser);

        /// <summary>
        /// ��ȡ�û�����Ȩ��
        /// </summary>
        List<Auth> GetAccountAllAuth(int accountId, Account loginUser);

        /// <summary>
        /// ��ȡ�û�����Ȩ��
        /// </summary>
        List<Auth> GetAccountAllAuthList(int accountId, Account loginUser);

        /// <summary>
        /// �����û�Ȩ��
        /// </summary>
        void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser);
    }
}
