using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class MailSettingView : System.Web.UI.UserControl
    {
        public void SetMailSetting(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyMSMQMail,
                                                 IsOpenFunction ? "true" : "false");
            //ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
            //                                                      ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress,
            //                                                      ABCClientSetView1.ServerAddress));
            //ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
            //                                                      ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding,
            //                                                      ABCClientSetView1.ServerBinding));
            //ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
            //                                                      ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract,
            //                                                      ABCClientSetView1.ServerContract));
            //ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
            //                                                      ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration,
            //                                                      ABCClientSetView1.ServerBindingConfiguration));
        }
        private bool IsOpenFunction
        {
            get { return cbOpenFunction.Checked; }
            set { cbOpenFunction.Checked = value; }
        }
        public void GetMailSetting(XmlDocument webconfigDoc)
        {
            IsOpenFunction = ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc, ConfigUtility.Const_KeyMSMQMail);
            //ABCClientSetView1.ServerName = ConfigUtility.Const_KeyServiceMailName;
            //ABCClientSetView1.ServerAddress = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress, ""));
            //ABCClientSetView1.ServerBinding = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding, ""));
            //ABCClientSetView1.ServerContract = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceMailName),
            //                           new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract, ""));
            //ABCClientSetView1.ServerBindingConfiguration = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
            //                      new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceMailName),
            //                      new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration, ""));
        }
    }
}