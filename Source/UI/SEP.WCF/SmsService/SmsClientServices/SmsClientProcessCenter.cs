using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SmsDataContract;

namespace SmsClientServices
{
    public class SmsClientProcessCenter
    {
        //��ǰϵͳ�ķ����ţ�ÿ��������ϵͳӦ�ñ���Ψһ��
        public const string _HrmisId = "nihaoIsPermitted";

        private static readonly string _SmsConfig = ConfigurationManager.AppSettings["SmsConfig"];
        private static readonly string _ClientListenAddress = ConfigurationManager.AppSettings["ClientListenAddress"];

        private static SmsServiceEnableDescription _SmsServiceEnable;

        /// <summary>
        /// ���¼���״̬
        /// </summary>
        public static void ReActiveTheService()
        {
            _SmsServiceEnable = ActiveTheService();
        }

        /// <summary>
        /// ��ȡ��ǰ���ŷ���״̬
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
            //�ͻ���������֤
            if(string.IsNullOrEmpty(_SmsConfig))
            {
                return new SmsServiceEnableDescription(false,"�ͻ���webConfig��û�����ü���Ľڵ㣬����webConfig�м���" + "  <add key=\"SmsService\" value=\"true\">  �ڵ�");
            }
            bool smsService;
            if (!bool.TryParse(_SmsConfig, out smsService))
            {
                return new SmsServiceEnableDescription(false,"�ͻ���webConfig��û�м���Ľڵ��޷�������SmsService��������ϢӦ��Ϊ true����false");
            }
            if (!smsService)
            {
                return new SmsServiceEnableDescription(false, "�ͻ��˹ر��˶��ŷ������迪������SmsService��������Ϣ����Ϊ true",SmsFailedType.ClientDefined);
            }
            ////�ͻ��˴��ŵ�
            //ServiceHost _SmsClientTypeHost;
            //try
            //{
            //    _SmsClientTypeHost = new ServiceHost(typeof(SmsClientServicesType));
            //    _SmsClientTypeHost.Open();
            //}
            //catch
            //{
            //    return new SmsServiceEnableDescription(false, "�ͻ��˽��������ŵ�ʧ�ܣ�����WebConfig�����ļ�����ȷ���ͻ�����Ҫʹ�õĶ˿�û�б���������ռ��");
            //}

            if(string.IsNullOrEmpty(_ClientListenAddress))
            {
                return new SmsServiceEnableDescription(false, @"δ���ÿͻ��˽��������ŵ�������WebConfig�����ļ�����ȷ�������½ڵ�:ClientListenAddress,��ַ����Ϊ���������ŵ���ַ");
            }

            //����������֤
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
            //        return new SmsServiceEnableDescription(false, "��ǰϵͳδ��ͨ������֤�����迪ͨ����ϵ������Ա");
            //    case "Failed":
            //        return new SmsServiceEnableDescription(false, "��ǰϵͳ�����Ķ˿ڷ������޷����ʣ�����ϵ�������Ա������֤���¶˿ڿ��Ա��ⲿ����" + _ClientListenAddress);
            //    default:
            //        return new SmsServiceEnableDescription(false, "��ǰ�ͻ��˲�֧�ַ������𸴣����������ڷ��������˶�ϵͳδͬ��������ϵ������Ա����ϵͳ");
            //}
        }
    }
}