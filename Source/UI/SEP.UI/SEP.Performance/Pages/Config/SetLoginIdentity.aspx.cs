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
            //����web.config�ļ�
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
                lblAdminPWDMsg.Text = "����Ϊ��";
            }
            return ret;
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
            {
                return;
            }
            //����web.config�ļ�
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_WebConfigFilePath);
                
            SetAdminPWD(webconfigDoc);


            //��������
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
