using System.Reflection;
using System.Xml;

namespace SEP.HRMIS.Model.Others
{
    public static class GetConfigKey
    {
        private static string _fileName;
        public static string FileName
        {
            set
            {
                if (value != null)
                    
                _fileName = value;
                _fileName = _fileName + "\\ShiXinHrmis.config";
                GetAllConfigKey();
            }
        }

        private static XmlNodeList nodeList;
        private static string _systemId;
        private static string _systemMailAddress;
        private static string _systemMailCommand;
        private static string _smtpHost;
        private static string _userNameMailAddress;
        private static string _userNamePassword;
        private static string _localHostAdress;
        private static string _attendanceIsNormalIsIncludeOutInTime;
        private static string _companyTel;
        private static string _companyFax;
        private static string _companyTitle;
        private static string _helpURL;

        private static void GetAllConfigKey()
        {
            nodeList = GetConfigFile();
            _systemId = GetKey("SYSTEMID");
            _systemMailAddress = GetKey("SYSTEMMAILADDRESS");
            _systemMailCommand = GetKey("SYSTEMMAILCOMMAND");
            _smtpHost = GetKey("SMTPHOST");
            _userNameMailAddress = GetKey("USERNAMEMAILADDRESS");
            _userNamePassword = GetKey("USERNAMEPASSWORD");
            _localHostAdress = GetKey("LOCALHOSTADDRESS");
            _attendanceIsNormalIsIncludeOutInTime = GetKey("ATTENDANCEISNORMALISINCLUDEOUTINTIME");
            _companyTel = GetKey("COMPANYTEL");
            _companyFax = GetKey("COMPANYFAX");
            _companyTitle = GetKey("COMPANYTITLE");
            _helpURL = GetKey("HELPURL");
        }

        private static XmlNodeList GetConfigFile()
        {
            //string fileName = Assembly.GetExecutingAssembly().Location;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(_fileName);
            //xmldoc.Load(_fileName);
            if (xmldoc.DocumentElement != null)
            {
                XmlNodeList xmlNodeList = xmldoc.DocumentElement.ChildNodes;

                return xmlNodeList;
            }
            return null;
        }

        private static string GetKey(string configKey)
        {
            string key = string.Empty;
            foreach (XmlNode xmlNode in nodeList)
            {
                if (xmlNode.Name == configKey)
                {
                    key = xmlNode.InnerXml;
                    break;
                }
            }
            return key;
        }
        /// <summary>
        /// ����ͳ��ʱ���ж������Ƿ����ʱ���Ƿ�Ҫ���жϽ���ʱ���Ƿ�Ϊ��
        /// </summary>
        public static string ATTENDANCEISNORMALISINCLUDEOUTINTIME
        {
            get
            {
                return _attendanceIsNormalIsIncludeOutInTime;
            }
        }
        // ϵͳ�ı�ʶ��
        public static string SYSTEMID
        {
            get
            {
                return _systemId;
            }
        }
        // Ĭ�ϵ�ϵͳ����ԴMail��ַ
        public static string SYSTEMMAILADDRESS
        {
            get
            {
                return _systemMailAddress;
            }
        }
        // Ĭ�ϵ�ϵͳ����Դ����
        public static string SYSTEMMAILCOMMAND
        {
            get
            {
                return _systemMailCommand;
            }
        }
        // smtp������
        public static string SMTPHOST
        {
            get
            {
                return _smtpHost;
            }
        }
        // �û���ƾ֤Mail��ַ
        public static string USERNAMEMAILADDRESS
        {
            get
            {
                return _userNameMailAddress;
            }
        }
        // �û���ƾ֤����
        public static string USERNAMEPASSWORD
        {
            get
            {
                return _userNamePassword;
            }
        }
        // ������ҳ��ַ
        public static string LOCALHOSTADDRESS
        {
            get
            {
                return _localHostAdress;
            }
            set { _localHostAdress = value; }
        }
        // ��ϵ��˾�ĵ绰
        public static string COMPANYTEL
        {
            get
            {
                return _companyTel;
            }
        }
        // ��ϵ��˾�Ĵ���
        public static string COMPANYFAX
        {
            get
            {
                return _companyFax;
            }
        }
        // ��ϵ��˾��Title
        public static string COMPANYTITLE
        {
            get
            {
                return _companyTitle;
            }
        }
        /// <summary>
        /// ������URL
        /// </summary>
        public static string HELPURL
        {
            get
            {
                return _helpURL;
            }
        }
    }
}
