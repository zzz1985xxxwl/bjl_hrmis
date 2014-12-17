using System;
using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class SubSystemSetView : System.Web.UI.UserControl
    {
        public void GetSubSystemSet(XmlDocument webconfigDoc)
        {
            cbHasHrmisSystem.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc, ConfigUtility.Const_KeyHasHrmisSystem);
            cbHasCRMSystem.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyHasCRMSystem);
            cbHasMyCMMISystem.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyHasMyCMMISystem);
            cbHasEShoppingSystem.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyHasEShoppingSystem);
        }

        public void SetSubSystemSet(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyHasHrmisSystem,
                                                  cbHasHrmisSystem.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyHasCRMSystem,
                                                  cbHasCRMSystem.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyHasMyCMMISystem,
                                                  cbHasMyCMMISystem.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyHasEShoppingSystem,
                                                  cbHasEShoppingSystem.Checked ? "true" : "false");
        }
        public bool HasHrmisSystem
        {
            get { return cbHasHrmisSystem.Checked; }
        }
        public bool HasCRMSystem
        {
            get { return cbHasCRMSystem.Checked; }
        }
        public bool HasMyCMMISystem
        {
            get { return cbHasMyCMMISystem.Checked; }
        }
        public bool ReadOnly
        {
            set
            {
                cbHasCRMSystem.Enabled = !value;
                cbHasHrmisSystem.Enabled = !value;
                cbHasMyCMMISystem.Enabled = !value;
                cbHasEShoppingSystem.Enabled = !value;
            }
        }
    }
}