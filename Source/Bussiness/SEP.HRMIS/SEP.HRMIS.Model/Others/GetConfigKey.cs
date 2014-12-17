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
        /// 考勤统计时，判断数据是否错误时，是否要加判断进出时间是否为空
        /// </summary>
        public static string ATTENDANCEISNORMALISINCLUDEOUTINTIME
        {
            get
            {
                return _attendanceIsNormalIsIncludeOutInTime;
            }
        }
        // 系统的标识符
        public static string SYSTEMID
        {
            get
            {
                return _systemId;
            }
        }
        // 默认的系统发信源Mail地址
        public static string SYSTEMMAILADDRESS
        {
            get
            {
                return _systemMailAddress;
            }
        }
        // 默认的系统发信源解释
        public static string SYSTEMMAILCOMMAND
        {
            get
            {
                return _systemMailCommand;
            }
        }
        // smtp服务器
        public static string SMTPHOST
        {
            get
            {
                return _smtpHost;
            }
        }
        // 用户名凭证Mail地址
        public static string USERNAMEMAILADDRESS
        {
            get
            {
                return _userNameMailAddress;
            }
        }
        // 用户名凭证密码
        public static string USERNAMEPASSWORD
        {
            get
            {
                return _userNamePassword;
            }
        }
        // 返回首页地址
        public static string LOCALHOSTADDRESS
        {
            get
            {
                return _localHostAdress;
            }
            set { _localHostAdress = value; }
        }
        // 联系公司的电话
        public static string COMPANYTEL
        {
            get
            {
                return _companyTel;
            }
        }
        // 联系公司的传真
        public static string COMPANYFAX
        {
            get
            {
                return _companyFax;
            }
        }
        // 联系公司的Title
        public static string COMPANYTITLE
        {
            get
            {
                return _companyTitle;
            }
        }
        /// <summary>
        /// 帮助的URL
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
