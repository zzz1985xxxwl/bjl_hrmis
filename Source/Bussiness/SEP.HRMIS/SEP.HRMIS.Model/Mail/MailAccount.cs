//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: MailAccount.cs
// ������: �ߺ�
// ��������: 2008-11-07
// ����: ������ٵ�
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
                throw new ApplicationException("�û��������벻��Ϊ��");
            }
            if(_TheMailConfiguration == null)
            {
                throw new ApplicationException("����ѡ��һ�������ļ�");
            }
            if(!MailConfiguration.IsVaildId(_TheMailConfiguration.Id))
            {
                throw new ApplicationException("��Ч�������ļ�������ϵ����Ա���");
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