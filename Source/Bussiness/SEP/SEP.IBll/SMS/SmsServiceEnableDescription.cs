using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.IBll.SMS
{
    public class SmsServiceEnableDescription
    {
        private bool _Enable;
        private string _Description;
        private SmsFailedType _SmsFailedTypes;

        /// <summary>
        /// Ĭ��Ϊ����ʧ��ԭ��
        /// </summary>
        public SmsServiceEnableDescription(bool enable, string description)
            : this(enable, description, SmsFailedType.Others)
        {
            Enable = enable;
            Description = description;
        }

        public SmsServiceEnableDescription(bool enable, string description, SmsFailedType failedType)
        {
            _Enable = enable;
            _Description = description;
            SmsFailedTypes = failedType;
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// ʧ�����ͣ�����Ҫ�ж��Ƿ��ǿͻ����Լ���webconfig�йر��˶��ŷ���
        /// </summary>
        public SmsFailedType SmsFailedTypes
        {
            get { return _SmsFailedTypes; }
            set { _SmsFailedTypes = value; }
        }

        public override string ToString()
        {
            if (_Enable)
            {
                return "�ɹ���������";
            }
            return "��������ʧ�ܣ�ԭ���ǣ�" + Description;
        }
    }

    public enum SmsFailedType
    {
        /// <summary>
        /// �ͻ��Լ�Ҫ�󲻿�������ҵ��
        /// </summary>
        ClientDefined,
        /// <summary>
        /// ����ԭ��
        /// </summary>
        Others,
    }
}
