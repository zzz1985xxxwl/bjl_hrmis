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
        //��ǰϵͳ�ķ����ţ�ÿ��������ϵͳӦ�ñ���Ψһ��
        public static string _HrmisId = CompanyConfig.SYSTEMID;

        private static readonly string _SmsConfig = ConfigurationManager.AppSettings["SmsConfig"];
        private static readonly string _ClientListenAddress = ConfigurationManager.AppSettings["ClientListenAddress"];

        private static SmsServiceEnableDescription _SmsServiceEnable;

        /// <summary>
        /// ���¼���״̬������״̬�Ļ�ȡ����SmsClientProcessCenter.GetSmsServiceEnable.ToString()
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

        /// <summary>
        /// ��ȡ��ǰ�ͻ����Ƿ���Ҫ�������ŷ���
        /// </summary>
        public static bool TheMessageServicesEnabled
        {
            get
            {
                //ֻ�е����ŷ�����ʧ�ܣ���ʧ�ܵ�ԭ�����ڿͻ����Լ��رյģ��Ž�����ر�
                if (!GetSmsServiceEnable.Enable && GetSmsServiceEnable.SmsFailedTypes == SmsFailedType.ClientDefined)
                {
                    return false;
                }
                return true;
            }
        }

        private static SmsServiceEnableDescription ActiveTheService()
        {
            //�ͻ���������֤
            if (string.IsNullOrEmpty(_SmsConfig))
            {
                return new SmsServiceEnableDescription(false, "�ͻ���webConfig��û�����ü���Ľڵ㣬����webConfig�м���" + "  <add key=\"SmsService\" value=\"true\">  �ڵ�");
            }
            bool smsService;
            if (!bool.TryParse(_SmsConfig, out smsService))
            {
                return new SmsServiceEnableDescription(false, "�ͻ���webConfig��û�м���Ľڵ��޷�������SmsService��������ϢӦ��Ϊ true����false");
            }
            if (!smsService)
            {
                return new SmsServiceEnableDescription(false, "�ͻ��˹ر��˶��ŷ������迪������SmsService��������Ϣ����Ϊ true", SmsFailedType.ClientDefined);
            }
            if (string.IsNullOrEmpty(_ClientListenAddress))
            {
                return new SmsServiceEnableDescription(false, "δ���ÿͻ��˽��������ŵ�������WebConfig�����ļ�����ȷ�������½ڵ�:ClientListenAddress,��ַ����Ϊ���������ŵ���ַ");
            }

            //����������֤
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
