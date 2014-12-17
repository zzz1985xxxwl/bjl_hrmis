//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IAccountBll.cs
// ������: colbert
// ��������: 2009-02-02
// ����: �˺�ҵ��ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using System;

namespace SEP.IBll.Accounts
{
    public interface IAccountBll
    {
        #region �û���¼

        /// <summary>
        /// ��¼��֤
        /// </summary>
        Account LoginVerify(string loginName, string password);

        /// <summary>
        /// ��¼��֤
        /// </summary>
        Account LoginVerify(string loginName, string password, string usbKey, int usbKeyCount);

        #endregion

        #region �����û�

        /// <summary>
        /// �����˺�
        /// </summary>
        void CreateAccount(Account account, Account loginUser);

        #endregion

        #region �޸��û�

        /// <summary>
        /// �����˺�
        /// </summary>
        void UpdateAccount(Account account, Account loginUser);

        #endregion

        #region ɾ���û�

        /// <summary>
        /// ɾ���˺�
        /// </summary>
        void DeleteAccount(int accountId);
        /// <summary>
        /// ɾ���˺ţ���Ȩ����֤
        /// </summary>
        void DeleteAccount(int accountId, Account loginUser);

        /// <summary>
        /// �����˺�����
        /// </summary>
        void SetAccountType(int accountId, VisibleType visibleType, Account loginUser);

        /// <summary>
        /// �Ƴ��˺�����
        /// </summary>
        void RemoveAccountType(int accountId, VisibleType visibleType, Account loginUser);

        #endregion

        #region ���룬UsbKey����

        /// <summary>
        /// �޸�����
        /// </summary>
        void ChangePassword(string loginName, string oldPassword, string newPassword, Account loginUser);
        /// <summary>
        /// ��������
        /// </summary>
        void SetDefaultPassword(string loginName, Account loginUser);
        /// <summary>
        /// ����UsbKey
        /// </summary>
        void SetUsbKey(string loginName, string usbKey, Account loginUser);

        //void SetAcceptEmail(int accountId, bool isAcceptEmail);
        //void SetAcceptSMS(int accountId, bool isAcceptSMS);
        //void SetValidateUsbKey(int accountId, bool isValidateUsbKey);
        /// <summary>
        /// �������ñ���
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="electronIdiograph"></param>
        void SavePersonalConfig(Account loginUser, byte[] electronIdiograph);
        #endregion

        #region ��ȡ�û���Ϣ
        List<Account> GetChargeAccountByNameAndDeptString(string name, string dept, Account Leader);
        List<Account> GetAccountByNameString(string sendAccount, out string errorname);
        Account GetAccountByName(string name);
        /// <summary>
        /// �����û�Id��ȡ�û���Ϣ
        /// </summary>
        Account GetAccountById(int accountId);
        /// <summary>
        /// ��ȡ�����û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllAccount();
        /// <summary>
        /// ��ȡ�����û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllAccount(Account loginUser);
        /// <summary>
        /// ��ȡ������Ч�û�
        ///     ��Ϊ�ܵ�¼���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllValidAccount();
        /// <summary>
        /// ��ȡ������Ч�û�
        ///     ��Ϊ�ܵ�¼���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllValidAccount(Account loginUser);
        /// <summary>
        /// ��ȡ����HRMis��Ч�û�
        ///     ��Ϊ�ܵ�¼HRMis���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllHRMisAccount();
        /// <summary>
        /// ��ȡ����CRM��Ч�û�
        ///     ��Ϊ�ܵ�¼CRM���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllCRMAccount();
        /// <summary>
        /// ��ȡ����MyCMMI��Ч�û�
        ///     ��Ϊ�ܵ�¼MyCMMI���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllMyCMMIAccount();

        /// <summary>
        /// ��ȡ����MyCMMI��Ч�û�
        ///     ��Ϊ�ܵ�¼MyCMMI���û�
        ///     Admin����
        /// </summary>
        List<Account> GetAllEShoppingAccount();

        /// <summary>
        /// ���ݵ绰�����ѯ�û�
        /// </summary>
        Account GetAccountByMobileNum(string mobileNum);
        /// <summary>
        /// �����û�
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, bool? visible);

        /// <summary>
        /// �����û�
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, VisibleType visibleType);

        /// <summary>
        /// ��������ģ����ѯ��������ID(-1��ʾȫ��)��ְλID��-1��ʾȫ���������û���
        /// ���recursionDepartment=true,��Ҫ���ز����������Ӳ��ŵ�Ա����������Ҫ
        /// </summary>
        List<Account> GetAccountByBaseCondition(string nameLike, int deptId, int positionId,int? gradesId, bool recursionDepartment, bool? visible);

        /// <summary>
        /// �����쵼��Id��ȡ����������
        /// </summary>
        List<Account> GetSubordinates(int leaderId);
        //List<Account> GetManageDeptStaffs(int leaderId);

        /// <summary>
        /// �����쵼��Id��ȡ��ֱ������
        /// </summary>
        List<Account> GetDirectSubordinates(int leaderId);

        /// <summary>
        /// ��ȡԱ������
        /// </summary>
        List<String> GetAllEmployeeName();

        List<Account> GetEmployeeByBasicConditionAndFirstLetter(string employeeName, int positionId, int departmentId,
                                                                bool recursionDepartment, string firstLetter);
        /// <summary>
        /// ͨ���û�Id��ȡ������Ϣ(��������Id)
        /// </summary>
        Account GetLeaderByAccountId(int accountId);
        #endregion

        #region ����ǩ��

        /// <summary>
        /// ��ȡ����ǩ��
        /// </summary>
        byte[] GetElectronIdiographByAccountID(Account loginUser);

        /// <summary>
        /// ���ӵ���ǩ��
        /// </summary>
        void InsertElectronIdiograph(Account loginUser, byte[] photo);

        /// <summary>
        /// ���µ���ǩ��
        /// </summary>
        void UpdateElectronIdiograph(Account loginUser, byte[] photo);

        /// <summary>
        /// ���µ���ǩ��
        /// </summary>
        void DeleteElectronIdiograph(Account loginUser);


        #endregion
    }
}
