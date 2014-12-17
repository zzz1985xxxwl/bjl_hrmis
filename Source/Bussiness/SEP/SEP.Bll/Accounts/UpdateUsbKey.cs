//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateUsbKey.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 更新UsbKey业务实现
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Accounts;
using SEP.IDal;
using ShiXin.Security;

namespace SEP.Bll.Accounts
{
    internal class UpdateUsbKey : Transaction
    {
        private string _LoginName;
        private string _UsbKey;
        private Account _LoginUser;

        public UpdateUsbKey(string loginName, string usbKey, Account loginUser)
        {
            _LoginName = loginName;
            _UsbKey = usbKey;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            //权限验证
            if(_LoginName == _LoginUser.LoginName)
                return;

            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A101))
                throw MessageKeys.AppException(MessageKeys._NoAuth);
        }

        protected override void ExcuteSelf()
        {
            DalInstance.AccountDalInstance.SetUsbKey(_LoginName,
                                                     SecurityUtil.SymmetricEncrypt(_UsbKey, _LoginName));
        }
    }
}
