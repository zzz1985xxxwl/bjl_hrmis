using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SmsDataContract;

namespace SmsClientServices
{
    public class SmsClientProcessCenter
    {
        //当前系统的服务编号，每个发布的系统应该保持唯一性
        public const string _HrmisId = "nihaoIsPermitted";

        private static readonly string _SmsConfig = ConfigurationManager.AppSettings["SmsConfig"];
        private static readonly string _ClientListenAddress = ConfigurationManager.AppSettings["ClientListenAddress"];

        private static SmsServiceEnableDescription _SmsServiceEnable;

        /// <summary>
        /// 重新激活状态
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

        private static SmsServiceEnableDescription ActiveTheService()
        {
            //客户端配置验证
            if(string.IsNullOrEmpty(_SmsConfig))
            {
                return new SmsServiceEnableDescription(false,"客户端webConfig中没有配置激活的节点，请在webConfig中加入" + "  <add key=\"SmsService\" value=\"true\">  节点");
            }
            bool smsService;
            if (!bool.TryParse(_SmsConfig, out smsService))
            {
                return new SmsServiceEnableDescription(false,"客户端webConfig中没有激活的节点无法解析，SmsService的配置信息应当为 true或者false");
            }
            if (!smsService)
            {
                return new SmsServiceEnableDescription(false, "客户端关闭了短信服务，如需开启，将SmsService的配置信息设置为 true",SmsFailedType.ClientDefined);
            }
            ////客户端打开信道
            //ServiceHost _SmsClientTypeHost;
            //try
            //{
            //    _SmsClientTypeHost = new ServiceHost(typeof(SmsClientServicesType));
            //    _SmsClientTypeHost.Open();
            //}
            //catch
            //{
            //    return new SmsServiceEnableDescription(false, "客户端建立监听信道失败，请检查WebConfig配置文件，并确保客户端需要使用的端口没有被其他程序占用");
            //}

            if(string.IsNullOrEmpty(_ClientListenAddress))
            {
                return new SmsServiceEnableDescription(false, @"未配置客户端建立监听信道，请检查WebConfig配置文件，并确保有以下节点:ClientListenAddress,地址设置为本机监听信道地址");
            }

            //服务器端验证
            //string registerMine;
            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.RegisterSmsClient(_ClientListenAddress, _HrmisId);
                ((IChannel) proxy).Close();
                return new SmsServiceEnableDescription(true, "");
            }
            catch(Exception e)
            {
                return new SmsServiceEnableDescription(false, e.Message);
            }

            //switch(registerMine)
            //{
            //    case "Pass":
            //        return new SmsServiceEnableDescription(true,"");
            //    case "Deny":
            //        return new SmsServiceEnableDescription(false, "当前系统未开通服务验证，如需开通请联系销售人员");
            //    case "Failed":
            //        return new SmsServiceEnableDescription(false, "当前系统监听的端口服务器无法访问，请联系网络管理员，并保证以下端口可以被外部访问" + _ClientListenAddress);
            //    default:
            //        return new SmsServiceEnableDescription(false, "当前客户端不支持服务器答复，可能是由于服务升级了而系统未同步，请联系销售人员升级系统");
            //}
        }
    }
}