using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class ContactSettingView : System.Web.UI.UserControl
    {
        private readonly string _SystemServiceModelPath = ConfigUtility._SystemServiceModelPath;
        public void SetContactSetting(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress,
                                                                  ABCClientSetView1.ServerAddress));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding,
                                                                  ABCClientSetView1.ServerBinding));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract,
                                                                  ABCClientSetView1.ServerContract));
            ConfigUtility.SetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname,
                                                                  ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration,
                                                                  ABCClientSetView1.ServerBindingConfiguration));
        }

        public void GetContactSetting(XmlDocument webconfigDoc)
        {
            ABCClientSetView1.IsOpenFunctionVisible = false;
            ABCClientSetView1.ServerName = ConfigUtility.Const_KeyServiceContactName;
            ABCClientSetView1.ServerAddress = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointaddress, ""));
            ABCClientSetView1.ServerBinding = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbinding, ""));
            ABCClientSetView1.ServerContract = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointcontract, ""));
            ABCClientSetView1.ServerBindingConfiguration = ConfigUtility.GetNodeValue(webconfigDoc, _SystemServiceModelPath, "endpoint",
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointname, ConfigUtility.Const_KeyServiceContactName),
                                       new XmlNodeAttributesModel(ConfigUtility.Const_endpointbindingConfiguration, ""));
        }

    }
}