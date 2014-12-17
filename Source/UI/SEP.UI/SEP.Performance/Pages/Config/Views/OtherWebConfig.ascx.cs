using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class OtherWebConfig : System.Web.UI.UserControl
    {
        public void GetOtherWebConfig(XmlDocument webconfigDoc)
        {
            txtEmployeeExportLocation.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                   ConfigUtility.Const_KeyEmployeeExportLocation);
        }
        public void SetOtherWebConfig(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyEmployeeExportLocation,
                                                  txtEmployeeExportLocation.Text.Trim());
        }
    }
}