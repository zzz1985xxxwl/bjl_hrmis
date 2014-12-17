//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: MailAccount.cs
// 创建者: 倪豪
// 创建日期: 2008-11-07
// 概述: 增加请假单
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class MailAccount
    {
        private int _Id;
        private string _LoginName;
        private string _Password;
        private MailConfiguration _TheMailConfiguration;

        public MailAccount(string loginName,string password,MailConfiguration config)
        {
            _LoginName = loginName;
            _Password = password;
            TheMailConfiguration = config;
        }

        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public MailConfiguration TheMailConfiguration
        {
            get { return _TheMailConfiguration; }
            set { _TheMailConfiguration = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public void VaildTheObject()
        {
            if(string.IsNullOrEmpty(_LoginName) ||string.IsNullOrEmpty(_Password))
            {
                throw new ApplicationException("用户名与密码不可为空");
            }
            if(_TheMailConfiguration == null)
            {
                throw new ApplicationException("必须选择一个配置文件");
            }
            if(!MailConfiguration.IsVaildId(_TheMailConfiguration.Id))
            {
                throw new ApplicationException("无效的配置文件，请联系管理员检查");
            }
        }

        public override bool Equals(object obj)
        {
            MailAccount _anOtherObj = obj as MailAccount;
            if (_anOtherObj == null)
            {
                return false;
            }
            return _Id.Equals(_anOtherObj.Id) &&
                   _LoginName.Equals(_anOtherObj.LoginName) &&
                   _Password.Equals(_anOtherObj.Password) &&
                   _TheMailConfiguration.Equals(_anOtherObj.TheMailConfiguration);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}