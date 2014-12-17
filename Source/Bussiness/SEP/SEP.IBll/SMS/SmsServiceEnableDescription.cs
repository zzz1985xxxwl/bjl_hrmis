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
        /// 默认为其他失败原因
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
        /// 是否可用
        /// </summary>
        public bool Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 失败类型，现主要判断是否是客户端自己在webconfig中关闭了短信发送
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
                return "成功开启服务";
            }
            return "开启服务失败，原因是：" + Description;
        }
    }

    public enum SmsFailedType
    {
        /// <summary>
        /// 客户自己要求不开启短信业务
        /// </summary>
        ClientDefined,
        /// <summary>
        /// 其他原因
        /// </summary>
        Others,
    }
}
