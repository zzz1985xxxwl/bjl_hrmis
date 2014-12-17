using System;
using System.Configuration;
using System.IO;
using System.Xml;

namespace SEP.Model.Utility
{
    public static class CompanyConfig
    {
        private static bool _HasHrmisSystem;
        private static bool _HasCRMSystem;
        private static bool _HasMyCMMISystem;
        private static bool _HasEShoppingSystem;

        static CompanyConfig()
        {
            try
            {
                _HasHrmisSystem = Convert.ToBoolean(ConfigurationManager.AppSettings["HasHrmisSystem"]);
            }
            catch
            {
                _HasHrmisSystem = false;
            }

            try
            {
                _HasCRMSystem = Convert.ToBoolean(ConfigurationManager.AppSettings["HasCRMSystem"]);
            }
            catch
            {
                _HasCRMSystem = false;
            }

            try
            {
                _HasMyCMMISystem = Convert.ToBoolean(ConfigurationManager.AppSettings["HasMyCMMISystem"]);
            }
            catch
            {
                _HasMyCMMISystem = false;
            }

            try
            {
                _HasEShoppingSystem = Convert.ToBoolean(ConfigurationManager.AppSettings["HasEShoppingSystem"]);
            }
            catch
            {
                _HasEShoppingSystem = false;
            }
        }

        private static string _fileName;

        public static string FileName
        {
            set
            {
                _fileName = value + "\\Company.config";

                if (File.Exists(_fileName))
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
        private static string _defaultPassword;
        private static string _helpaddress;
        private static string _mailToHR;

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
            _defaultPassword = GetKey("DEFAULTPASSWORD");
            _helpaddress = GetKey("HELPADDRESS");
            _mailToHR = GetKey("MAILTOHR");
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
                GetAllConfigKey();
                return _attendanceIsNormalIsIncludeOutInTime;
            }
        }

        /// <summary>
        /// ϵͳ�ı�ʶ��
        /// </summary>
        public static string SYSTEMID
        {
            get
            {
                GetAllConfigKey();
                return _systemId;
            }
        }

        /// <summary>
        /// Ĭ�ϵ�ϵͳ����ԴMail��ַ
        /// </summary>
        public static string SYSTEMMAILADDRESS
        {
            get
            {
                GetAllConfigKey();
                return _systemMailAddress;
            }
        }

        /// <summary>
        /// Ĭ�ϵ�ϵͳ����Դ����
        /// </summary>
        public static string SYSTEMMAILCOMMAND
        {
            get
            {
                GetAllConfigKey();
                return _systemMailCommand;
            }
        }

        /// <summary>
        /// smtp������
        /// </summary>
        public static string SMTPHOST
        {
            get
            {
                GetAllConfigKey();
                return _smtpHost;
            }
        }

        /// <summary>
        /// �û���ƾ֤Mail��ַ
        /// </summary>
        public static string USERNAMEMAILADDRESS
        {
            get
            {
                GetAllConfigKey();
                return _userNameMailAddress;
            }
        }

        /// <summary>
        /// �û���ƾ֤����
        /// </summary>
        public static string USERNAMEPASSWORD
        {
            get
            {
                GetAllConfigKey();
                return _userNamePassword;
            }
        }

        /// <summary>
        /// ������ҳ��ַ
        /// </summary>
        public static string LOCALHOSTADDRESS
        {
            get
            {
                GetAllConfigKey();
                return _localHostAdress;
            }
        }

        /// <summary>
        /// ��ϵ��˾�ĵ绰
        /// </summary>
        public static string COMPANYTEL
        {
            get
            {
                GetAllConfigKey();
                return _companyTel;
            }
        }

        /// <summary>
        /// ��ϵ��˾�Ĵ���
        /// </summary>
        public static string COMPANYFAX
        {
            get
            {
                GetAllConfigKey();
                return _companyFax;
            }
        }

        /// <summary>
        /// ����ҳ��
        /// </summary>
        public static string HELPADDRESS
        {
            get
            {
                GetAllConfigKey();
                return _helpaddress;
            }
        }

        /// <summary>
        /// ��ϵ��˾��Title
        /// </summary>
        public static string COMPANYTITLE
        {
            get
            {
                GetAllConfigKey();
                return _companyTitle;
            }
        }

        public static string DEFAULTPASSWORD
        {
            get
            {
                GetAllConfigKey();
                return _defaultPassword;
            }
        }

        public static bool HasCRMSystem
        {
            get
            {
                GetAllConfigKey();
                return _HasCRMSystem;
            }
        }

        public static bool HasHrmisSystem
        {
            get
            {
                GetAllConfigKey();
                return _HasHrmisSystem;
            }
        }

        public static bool HasMyCMMISystem
        {
            get
            {
                GetAllConfigKey();
                return _HasMyCMMISystem;
            }
        }

        public static bool HasEShoppingSystem
        {
            get
            {
                GetAllConfigKey();
                return _HasEShoppingSystem;
            }
        }

        public static string MailToHR
        {
            get
            {
                GetAllConfigKey();
                return _mailToHR;
            }
        }
    }
}