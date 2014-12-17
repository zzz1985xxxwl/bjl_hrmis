using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class SMSSettingView : System.Web.UI.UserControl
    {
        private readonly string _SystemServiceModelPath = ConfigUtility._SystemServiceModelPath;
        public void SetSMSSetting(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyClientListenAddress,
                                                  txtClientListenAddress.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeySmsConfig,
                                                  ABCClientSetView1.IsOpenFunction ? "true" : "false");
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress,
                                                                  ABCClientSetView1.ServerAddress));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding,
                                                                  ABCClientSetView1.ServerBinding));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract,
                                                                  ABCClientSetView1.ServerContract));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration,
                                                                  ABCClientSetView1.ServerBindingConfiguration));

            
        }
        public bool CheckValid()
        {
            bool ret = true;
            int intParse;
            if (!int.TryParse(txtTimeSpan.Text.Trim(),out intParse))
            {
                ret = false;
                lblTimeSpanMsg.Text = "∏Ò Ω¥ÌŒÛ";
            }
            return ret;
        }

        public void GetSMSSetting(XmlDocument webconfigDoc)
        {
            txtClientListenAddress.Text =
                ConfigUtility.GetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyClientListenAddress);
            txtTimeSpan.Text =
                ConfigUtility.GetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyReSendMessageTimeSpan);
            ABCClientSetView1.IsOpenFunction = ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc, ConfigUtility.Const_KeySmsConfig);
            ABCClientSetView1.ServerName = ConfigUtility.Const_KeyServiceSmsName;
            ABCClientSetView1.ServerAddress = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress, ""));
            ABCClientSetView1.ServerBinding = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding, ""));
            ABCClientSetView1.ServerContract = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceSmsName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract, ""));
            ABCClientSetView1.ServerBindingConfiguration = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceSmsName),
                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration, ""));
        }

    }
}