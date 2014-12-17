using System;
using System.Web;
using System.Xml;

namespace SEP.Performance.Pages.Config
{
    public partial class SetLoginIdentity : System.Web.UI.Page
    {
        private readonly string _WebConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\web.config";
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载web.config文件
            if (!Page.IsPostBack)
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_WebConfigFilePath);
            }
        }

        private bool CheckValid()
        {
            bool ret = true;
            if(string.IsNullOrEmpty(txtAdminPWD.Text.Trim()))
            {
                ret = false;
                lblAdminPWDMsg.Text = "不可为空";
            }
            return ret;
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
            {
                return;
            }
            //加载web.config文件
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_WebConfigFilePath);
                
            SetAdminPWD(webconfigDoc);


            //保存设置
            webconfigDoc.Save(_WebConfigFilePath);
            Response.Redirect("SetWebConfig.aspx");

        }

        private void SetAdminPWD(XmlDocument webconfigDoc)
        {
            string tempPath = "/configuration/system.web";
            ConfigUtility.SetNodeValue(webconfigDoc, tempPath, "identity",
                                       new XmlNodeAttributesModel("impersonate", "true"),
                                       new XmlNodeAttributesModel("userName", "administrator"));
            ConfigUtility.SetNodeValue(webconfigDoc, tempPath, "identity",
                                       new XmlNodeAttributesModel("impersonate", "true"),
                                       new XmlNodeAttributesModel("password", txtAdminPWD.Text.Trim()));
        }
    }
}
