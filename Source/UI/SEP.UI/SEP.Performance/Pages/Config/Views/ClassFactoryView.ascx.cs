using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class ClassFactoryView1 : System.Web.UI.UserControl
    {
        public void GetClassFactory(XmlDocument webconfigDoc)
        {
            txtSEPDal.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                   ConfigUtility.Const_KeySEPDal);
            txtSEPBll.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                   ConfigUtility.Const_KeySEPBll);
            txtCRMFacade.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                      ConfigUtility.Const_KeyCRMFacade);
            txtMyCMMIFacade.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                         ConfigUtility.Const_KeyMyCMMIFacade);
            txtMyCMMIWebDAL.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                         ConfigUtility.Const_KeyMyCMMIWebDAL);
            txtHrmisDal.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                     ConfigUtility.Const_KeyHrmisDAL);
            txtHrmisFacade.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                        ConfigUtility.Const_KeyHrmisFacade);
        }
        public void SetClassFactory(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeySEPDal,
                                                  txtSEPDal.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeySEPBll,
                                                  txtSEPBll.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyCRMFacade,
                                                  txtCRMFacade.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyMyCMMIFacade,
                                                  txtMyCMMIFacade.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyMyCMMIWebDAL,
                                                  txtMyCMMIWebDAL.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyHrmisDAL,
                                                  txtHrmisDal.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyHrmisFacade,
                                                  txtHrmisFacade.Text.Trim());
        }

    }
}