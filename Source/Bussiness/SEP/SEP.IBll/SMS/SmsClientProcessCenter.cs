using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using SmsDataContract;
using SEP.Model.Utility;

namespace SEP.IBll.SMS
{
    public static class SmsClientProcessCenter
    {
        //当前系统的服务编号，每个发布的系统应该保持唯一性
        public static string _HrmisId = CompanyConfig.SYSTEMID;

        private static readonly string _SmsConfig = ConfigurationManager.AppSettings["SmsConfig"];
        private static readonly string _ClientListenAddress = ConfigurationManager.AppSettings["ClientListenAddress"];

        private static SmsServiceEnableDescription _SmsServiceEnable;

        /// <summary>
        /// 重新激活状态，具体状态的获取访问SmsClientProcessCenter.GetSmsServiceEnable.ToString()
        /// </summary>
        public static void ReActiveTheService()
        {
            _SmsServiceEnable = ActiveTheService();
        }

        /// <summary>
        /// 获取当前短信服务状态
        /// </summary>
        public static SmsServiceEnableDescription GetSmsServiceEnable
        {
            get
            {
                if (_SmsServiceEnable == null)
                {
                    _SmsServiceEnable = ActiveTheService();
                    return _SmsServiceEnable;
                }
                return _SmsServiceEnable;
            }
        }

        /// <summary>
        /// 获取当前客户端是否需要开启短信服务
        /// </summary>
        public static bool TheMessageServicesEnabled
        {
            get
            {
                //只有当短信服务开启失败，且失败的原因由于客户端自己关闭的，才将服务关闭
                if (!GetSmsServiceEnable.Enable && GetSmsServiceEnable.SmsFailedTypes == SmsFailedType.ClientDefined)
                {
                    return false;
                }
                return true;
            }
        }

        private static SmsServiceEnableDescription ActiveTheService()
        {
            //客户端配置验证
            if (string.IsNullOrEmpty(_SmsConfig))
            {
                return new SmsServiceEnableDescription(false, "客户端webConfig中没有配置激活的节点，请在webConfig中加入" + "  <add key=\"SmsService\" value=\"true\">  节点");
            }
            bool smsService;
            if (!bool.TryParse(_SmsConfig, out smsService))
            {
                return new SmsServiceEnableDescription(false, "客户端webConfig中没有激活的节点无法解析，SmsService的配置信息应当为 true或者false");
            }
            if (!smsService)
            {
                return new SmsServiceEnableDescription(false, "客户端关闭了短信服务，如需开启，将SmsService的配置信息设置为 true", SmsFailedType.ClientDefined);
            }
            if (string.IsNullOrEmpty(_ClientListenAddress))
            {
                return new SmsServiceEnableDescription(false, "未配置客户端建立监听信道，请检查WebConfig配置文件，并确保有以下节点:ClientListenAddress,地址设置为本机监听信道地址");
            }

            //服务器端验证
            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.RegisterSmsClient(_ClientListenAddress, _HrmisId);
                ((IChannel)proxy).Close();
                return new SmsServiceEnableDescription(true, "");
            }
            catch (Exception ae)
            {
                return new SmsServiceEnableDescription(false, ae.Message);
            }
        }
    }
}
