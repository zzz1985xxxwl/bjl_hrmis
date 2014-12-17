//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: SavePersonalConfig.cs
// 创建者: wangshali
// 创建日期: 2009-9-20
// 概述: 个人设置
// ----------------------------------------------------------------

using System;
using System.Transactions;
using SEP.IDal;
using SEP.IDal.Accounts;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Bll.Accounts
{
    public class SavePersonalConfig : Transaction
    {
        private readonly Account _Account;
        private Account _CurrentAccount;
        private byte[] _ElectronIdiograph;
        private readonly IAccountDal _IAccountDal= DalInstance.AccountDalInstance;
        public SavePersonalConfig(Account account, byte[] electronIdiograph)
        {
            _Account = account;
            _ElectronIdiograph = electronIdiograph;
        }
        public SavePersonalConfig(IAccountDal iAccountDal,Account account, byte[] electronIdiograph)
        {
            _IAccountDal = iAccountDal;
            _Account = account;
            _ElectronIdiograph = electronIdiograph;
        }

        protected override void Validation()
        {
            _CurrentAccount = _IAccountDal.GetAccountById(_Account.Id);
            if (_CurrentAccount == null)
                throw MessageKeys.AppException(MessageKeys._Account_IsNot_Exist);
            if (_Account.IsValidateUsbKey && _CurrentAccount.UsbKey == null)
                throw MessageKeys.AppException(MessageKeys._Account_IsValidateUsbKey_NoUsbKey);

            if (_ElectronIdiograph != null && _ElectronIdiograph.Length > 0 && _CurrentAccount.UsbKey == null)
                throw MessageKeys.AppException(MessageKeys._Account_ElectronIdiograph_NoUsbKey);

            _ElectronIdiograph = SymmetricEncryptStream(_ElectronIdiograph, _CurrentAccount.UsbKey);
        }

        protected static byte[] SymmetricEncryptStream(byte[] photo, string usbkey)
        {
            try
            {
                return SecurityUtil.SymmetricEncryptStream(photo, usbkey);
            }
            catch (Exception)
            {
                return null;
            }
        }
        protected override void ExcuteSelf()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                _CurrentAccount.IsAcceptEmail = _Account.IsAcceptEmail;
                _CurrentAccount.IsAcceptSMS = _Account.IsAcceptSMS;
                _CurrentAccount.IsValidateUsbKey = _Account.IsValidateUsbKey;

                _IAccountDal.UpdateAccount(_CurrentAccount);
                if (_ElectronIdiograph != null && _ElectronIdiograph.Length > 0)
                {
                    ////更新电子签名
                    _IAccountDal.DeleteElectronIdiographByAccountID(_Account.Id);
                    _IAccountDal.InsertElectronIdiograph(_Account.Id, _ElectronIdiograph);
                }
                ts.Complete();
            }
        }
    }
}
