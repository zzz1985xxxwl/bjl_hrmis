//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: Login.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ��¼
// ----------------------------------------------------------------

using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Bll.Accounts
{
    internal class Login : Transaction
    {
        private string _LoginName;
        private string _Password;
        private string _UsbKey;
        private int _UsbKeyCount;

        private Account _LoginAccount;

        //public string LoginName
        //{
        //    get
        //    {
        //        return _LoginName;
        //    }
        //    set
        //    {
        //        _LoginName = value;
        //    }
        //}

        //public string Password
        //{
        //    get
        //    {
        //        return _Password;
        //    }
        //    set
        //    {
        //        _Password = value;
        //    }
        //}

        //public string UsbKey
        //{
        //    get
        //    {
        //        return _UsbKey;
        //    }
        //    set
        //    {
        //        _UsbKey = value;
        //    }
        //}

        public Account LoginAccount
        {
            get
            {
                return _LoginAccount;
            }
        }

        public Login(string loginName, string password)
        {
            _LoginName = loginName;
            _Password = password;
            _LoginAccount = null;
        }

        public Login(string loginName, string password, string usbKey, int usbKeyCount)
            : this(loginName, password)
        {
            _UsbKeyCount = usbKeyCount;
            _UsbKey = usbKey;
        }

        protected override void Validation()
        {
            //���ܵ�¼����
            string encryptPassword = SecurityUtil.SymmetricEncrypt(_Password, _LoginName);

            //��ȡ��¼����Ϣ
            Account accountInfo = DalInstance.AccountDalInstance.GetAccountInfo(_LoginName);

            //�˺��Ƿ����
            if (accountInfo == null)
            {
                throw MessageKeys.AppException(MessageKeys._Account_Not_Exist);
            }

            //�˺��Ƿ���Ч
            if (accountInfo.AccountType == VisibleType.None)
            {
                throw MessageKeys.AppException(MessageKeys._Account_Invalid);
            }

            //�����Ƿ���ȷ
            if (encryptPassword != accountInfo.Password)
            {
                throw MessageKeys.AppException(MessageKeys._Account_Password_Wrong);
            }

            if(accountInfo.IsValidateUsbKey)
            {
                if (_UsbKeyCount < 1)
                {
                    throw MessageKeys.AppException(MessageKeys._UsbKey_Not_Exist);
                }
                if (_UsbKeyCount > 1)
                {
                    throw MessageKeys.AppException(MessageKeys._UsbKey_Not_Repeat);
                }

                string encryptUsbKey = SecurityUtil.SymmetricEncrypt(_UsbKey, _LoginName);
                if(encryptUsbKey != accountInfo.UsbKey)
                {
                    throw MessageKeys.AppException(MessageKeys._Account_UsbKey_Wrong);
                }
            }

            _LoginAccount = accountInfo;
        }

        protected override void ExcuteSelf()
        {
            if (_LoginAccount == null) return;

            //��ȡȨ��
            _LoginAccount.Auths = DalInstance.AuthDalInstance.GetAccountAuthTree(_LoginAccount.Id);


            if(_LoginAccount.Dept == null) return;
            //��ȡ����
            _LoginAccount.Dept = DalInstance.DeptDalInstance.GetDepartmentById(_LoginAccount.Dept.Id);

            if(_LoginAccount.Position == null) return;
            //��ȡְλ
            _LoginAccount.Position = DalInstance.PositionDalInstance.GetPositionById(_LoginAccount.Position.Id);
        }
    }
}
