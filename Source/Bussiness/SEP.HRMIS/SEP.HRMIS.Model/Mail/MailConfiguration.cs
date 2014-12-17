//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: MailConfiguration.cs
// ������: �ߺ�
// ��������: 2008-11-07
// ����: �������������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class MailConfiguration
    {
        private int _Id;
        private string _Description;
        //������ַ
        private string _Host;
        //�˿ں�
        private int _Port;
        //�Ƿ���SSL����
        private bool _EnableSsl;
        //�Ƿ����Apop��֤
        private bool _ApopAuthenticate;

        public MailConfiguration(int id,string host, int port, bool enableSsl, bool apopAuthenticate,string description)
        {
            Id = id;
            Host = host;
            Port = port;
            EnableSsl = enableSsl;
            ApopAuthenticate = apopAuthenticate;
            Description = description;
        }

        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }

        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        public bool EnableSsl
        {
            get { return _EnableSsl; }
            set { _EnableSsl = value; }
        }

        public bool ApopAuthenticate
        {
            get { return _ApopAuthenticate; }
            set { _ApopAuthenticate = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public static MailConfiguration ShiXinTechConfiguration = new MailConfiguration(1,"mail.shixintech.com",110,false,false,"shixintech���ʼ�����");

        #region pubic Mehtod

        public static MailConfiguration GetMailConfigurationById(int id)
        {
            switch(id)
            {
                case 1:
                    return ShiXinTechConfiguration;
                default:
                    return null;
            }
        }

        public static List<MailConfiguration> GetAllConfigurations()
        {
            List<MailConfiguration> theConfigurations = new List<MailConfiguration>();
            theConfigurations.Add(ShiXinTechConfiguration);

            return theConfigurations;
        }

        public static bool IsVaildId(int id)
        {
            foreach(MailConfiguration anObject in GetAllConfigurations())
            {
                if(id.Equals(anObject._Id))
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (MailConfiguration)) return false;
            return Equals((MailConfiguration) obj);
        }

        #endregion

        public bool Equals(MailConfiguration obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._Id == _Id && Equals(obj._Description, _Description) && Equals(obj._Host, _Host) && obj._Port == _Port && obj._EnableSsl.Equals(_EnableSsl) && obj._ApopAuthenticate.Equals(_ApopAuthenticate);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Id;
                result = (result*397) ^ (_Description != null ? _Description.GetHashCode() : 0);
                result = (result*397) ^ (_Host != null ? _Host.GetHashCode() : 0);
                result = (result*397) ^ _Port;
                result = (result*397) ^ _EnableSsl.GetHashCode();
                result = (result*397) ^ _ApopAuthenticate.GetHashCode();
                return result;
            }
        }
    }
}