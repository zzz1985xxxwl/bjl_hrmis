using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml;

namespace SEP.Performance.Pages.Config
{
    public class ConfigUtility
    {
        public const string Const_KeyReplaceSign = "?";
        public const char Const_NodeSplitSign = '/';
        public const string _AddKeyPath = "/configuration/appSettings";
        public const string _CompanyPath = "/configuration";
        public const string _SystemServiceModelPath = "/configuration/system.serviceModel/client";
        
        public const string Const_KeyHasHrmisSystem = "HasHrmisSystem";
        public const string Const_KeyHasCRMSystem = "HasCRMSystem";
        public const string Const_KeyHasMyCMMISystem = "HasMyCMMISystem";
        public const string Const_KeyHasEShoppingSystem = "HasEShoppingSystem";
        public const string Const_KeySEPDal = "SEPDal";
        public const string Const_KeyEmployeeExportLocation = "EmployeeExportLocation";
        public const string Const_KeyAttendanceStartDay = "AttendanceStartDay";
        
        public const string Const_KeySEPBll = "SEPBll";
        public const string Const_KeyCRMFacade = "CRMFacade";
        public const string Const_KeyMyCMMIFacade = "MyCMMIFacade";
        public const string Const_KeyMyCMMIWebDAL = "MyCMMIWebDAL";
        public const string Const_KeyHrmisDAL = "HrmisDAL";
        public const string Const_KeyHrmisFacade = "HrmisFacade";
        public const string Const_KeyConnectionString = "ConnectionString";
        public const string Const_KeyMyCMMIConnectionString = "MyCMMIConnectionString";
        public const string Const_KeyHRMISConnectionString = "HRMISConnectionString";
        public const string Const_KeyCrmConnectionString = "CrmConnectionString";
        public const string Const_KeyLocalSqlServer = "LocalSqlServer";

        public const string Const_KeyIsAutoAssess = "IsAutoAssess";
        public const string Const_KeyIsAutoEmployeeResidenceDateRearch = "IsAutoEmployeeResidenceDateRearch";
        public const string Const_KeyBeforeEmployeeResidenceDateRearchDays = "BeforeEmployeeResidenceDateRearchDays";
        public const string Const_KeyIsAutoRemindEmployeeConfirmAttendance = "IsAutoRemindEmployeeConfirmAttendance";
        public const string Const_KeyIsAutoRemindVacation = "IsAutoRemindVacation";
        public const string Const_KeyBeforeRemindVacationDays = "BeforeRemindVacationDays";
        public const string Const_KeyIsAutoRemindContract = "IsAutoRemindContract";
        public const string Const_KeyIsAutoRemindProbationDateRearch = "IsAutoRemindProbationDateRearch";
        public const string Const_KeyBeforeRemindContractDays = "BeforeRemindContractDays";
        public const string Const_KeyBeforeProbationDateRearchDays = "BeforeProbationDateRearchDays";
        public const string Const_KeyMSMQMail = "MSMQMail";
        public const string Const_KeySmsConfig = "SmsConfig";
        public const string Const_KeyReSendMessageTimeSpan = "ReSendMessageTimeSpan";

        public const string Const_KeyClientListenAddress = "ClientListenAddress";
        public const string Const_endpointaddress = "address";
        public const string Const_endpointbinding = "binding";
        public const string Const_endpointcontract = "contract";
        public const string Const_endpointbindingConfiguration = "bindingConfiguration";
        public const string Const_endpointname = "name";
        public const string Const_KeyServiceMailName = "ISendMail";
        public const string Const_KeyServiceSmsName = "ISmsServiceContractService";
        public const string Const_KeyServiceContactName = "BasicHttpBinding_ContactServices";

        
        /// <summary>
        /// 得到AppSettings结构的value值，如<add key="SEPDal" value="SEP.SqlServerDal" />，返回SEP.SqlServerDal
        /// </summary>
        /// <param name="webconfigDoc"></param>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public static string GetAppSettingsNodeValue(XmlDocument webconfigDoc, string keyname)
        {
            return GetNodeValue(webconfigDoc, _AddKeyPath, "add",
                           new XmlNodeAttributesModel("key", keyname),
                           new XmlNodeAttributesModel("value", ""));
        }
        /// <summary>
        /// 得到AppSettings结构的value值，如<add key="SEPDal" value="SEP.SqlServerDal" />，返回SEP.SqlServerDal
        /// 并将结果转换为bool型
        /// </summary>
        /// <param name="webconfigDoc"></param>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public static bool GetAppSettingsNodeBoolValue(XmlDocument webconfigDoc, string keyname)
        {
            string ischecked = GetAppSettingsNodeValue(webconfigDoc, keyname);
            bool ret;
            if (bool.TryParse(ischecked, out ret))
            {
                return ret;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置AppSettings结构的value值，如<add key="SEPDal" value="" />，value设置为SEP.SqlServerDal
        /// </summary>
        /// <param name="webconfigDoc"></param>
        /// <param name="keyname"></param>
        /// <param name="valueresult"></param>
        public static void SetAppSettingsNodeValue(XmlDocument webconfigDoc, string keyname, string valueresult)
        {
            SetNodeValue(webconfigDoc, _AddKeyPath, "add", new XmlNodeAttributesModel("key", keyname),
                                        new XmlNodeAttributesModel("value", valueresult));
        }

        public static string GetNodeInnerTextValue(XmlDocument webconfigDoc, string parentPath, string nodeName)
        {
            XmlNode passkey;
            string getNodeString = parentPath + Const_NodeSplitSign + nodeName;
            passkey = webconfigDoc.SelectSingleNode(getNodeString);
            if (passkey == null)
            {
                return string.Empty;
            }
            return passkey.InnerText;
        }

        public static string GetNodeValue(XmlDocument webconfigDoc, string parentPath, string nodeName,
            XmlNodeAttributesModel keyAttribute, XmlNodeAttributesModel getAttribute)
        {
            XmlNode passkey;
            string getNodeString = parentPath + Const_NodeSplitSign + nodeName + "[@" + keyAttribute.Key + "='" +
                       keyAttribute.Value + "']";
            passkey = webconfigDoc.SelectSingleNode(getNodeString);
            if (passkey == null || passkey.Attributes[getAttribute.Key] == null)
            {
                return string.Empty;
            }
            return passkey.Attributes[getAttribute.Key].InnerText;
        }

        public static void SetNodeInnerTextValue(XmlDocument webconfigDoc, string parentPath, string nodeName,
            string valueresult)
        {
            valueresult = valueresult.Trim();
            XmlNode passkey;
            string getNodeString = parentPath + Const_NodeSplitSign + nodeName;
            passkey = webconfigDoc.SelectSingleNode(getNodeString);

            if (passkey == null)
            {
                passkey = webconfigDoc.CreateElement(nodeName);
                XmlNode parentNode = webconfigDoc.SelectSingleNode(parentPath);
                parentNode.AppendChild(passkey);
            }
            passkey.InnerText = valueresult;
        }

        public static void SetNodeValue(XmlDocument webconfigDoc, string parentPath, string nodeName,
            XmlNodeAttributesModel keyAttribute, XmlNodeAttributesModel setAttribute)
        {
            keyAttribute.Value = keyAttribute.Value.Trim();
            setAttribute.Value = setAttribute.Value.Trim();

            XmlNode passkey;
            string getNodeString = parentPath + Const_NodeSplitSign + nodeName + "[@" + keyAttribute.Key + "='" +
                                   keyAttribute.Value + "']";
            passkey = webconfigDoc.SelectSingleNode(getNodeString);

            if (passkey == null)
            {
                passkey = webconfigDoc.CreateElement(nodeName);
                XmlNode parentNode = webconfigDoc.SelectSingleNode(parentPath);
                parentNode.AppendChild(passkey);
            }
            if (passkey.Attributes[keyAttribute.Key] == null)
            {
                CreateNodeAttribute(passkey, webconfigDoc, keyAttribute);
            }
            if (passkey.Attributes[setAttribute.Key] == null)
            {
                CreateNodeAttribute(passkey, webconfigDoc, setAttribute);
            }
            passkey.Attributes[keyAttribute.Key].InnerText = keyAttribute.Value;
            passkey.Attributes[setAttribute.Key].InnerText = setAttribute.Value;
        }

        private static void CreateNodeAttribute(XmlNode passkey, XmlDocument webconfigDoc, XmlNodeAttributesModel attribute)
        {
            XmlAttribute newkeyAttribute = webconfigDoc.CreateAttribute(attribute.Key);
            passkey.Attributes.Append(newkeyAttribute);
        }

        public static bool TestDbConnect(string connstring)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                conn.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool CheckDbConnectValid(TextBox tb, Label lbl)
        {
            bool bRet = TestDbConnect(tb.Text.Trim());
            lbl.Text = bRet ? "测试成功" : "测试失败";
            return bRet;
        }

    }
}
