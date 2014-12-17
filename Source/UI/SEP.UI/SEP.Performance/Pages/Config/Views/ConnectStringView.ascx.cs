using System;
using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class ConnectStringView : System.Web.UI.UserControl
    {
        private bool _IsWebPartStringShow = true;
        public bool IsWebPartStringShow
        {
            get { return _IsWebPartStringShow; }
            set
            {
                _IsWebPartStringShow = value;
                if (value)
                {
                    trWebPart.Style["display"] = "block";
                }
                else
                {
                    trWebPart.Style["display"] = "none";
                }
            }
        }
        public void GetConnectString(XmlDocument webconfigDoc)
        {
            txtConnectionString.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                             ConfigUtility.Const_KeyConnectionString);
            txtMyCMMIConnectionString.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                   ConfigUtility.
                                                                                       Const_KeyMyCMMIConnectionString);
            txtHRMISConnectionString.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                  ConfigUtility.
                                                                                      Const_KeyHRMISConnectionString);
            txtCrmConnectionString.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                ConfigUtility.
                                                                                    Const_KeyCrmConnectionString);

            if (IsWebPartStringShow)
            {
                string tempPath = "/configuration/connectionStrings";
                txtLocalSqlServer.Text = ConfigUtility.GetNodeValue(webconfigDoc, tempPath, "add",
                                                                    new XmlNodeAttributesModel("name",
                                                                                               ConfigUtility.
                                                                                                   Const_KeyLocalSqlServer),
                                                                    new XmlNodeAttributesModel("connectionString", ""));
            }
        }


        public void SetConnectString(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyConnectionString,
                                                  txtConnectionString.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyMyCMMIConnectionString,
                                                  txtMyCMMIConnectionString.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyHRMISConnectionString,
                                                  txtHRMISConnectionString.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyCrmConnectionString,
                                                  txtCrmConnectionString.Text.Trim());
            if (IsWebPartStringShow)
            {
                string tempPath = "/configuration/connectionStrings";
                ConfigUtility.SetNodeValue(webconfigDoc, tempPath, "add",
                                           new XmlNodeAttributesModel("name", ConfigUtility.Const_KeyLocalSqlServer),
                                           new XmlNodeAttributesModel("connectionString", txtLocalSqlServer.Text.Trim()));
            }
        }
        public bool CheckConnectionStringValid()
        {
            return ConfigUtility.CheckDbConnectValid(txtConnectionString, lbSEPMsg);
        }
        public bool CheckHRMISConnectionStringValid()
        {
            return ConfigUtility.CheckDbConnectValid(txtHRMISConnectionString, lbHRMISMsg);
        }
        public bool CheckCrmConnectionStringValid()
        {
            return ConfigUtility.CheckDbConnectValid(txtCrmConnectionString, lbCRMMsg);
        }
        public bool CheckMyCMMIConnectionStringValid()
        {
            return ConfigUtility.CheckDbConnectValid(txtMyCMMIConnectionString, lbMYCMMIMsg);
        }
        public bool CheckLocalSqlServerValid()
        {
            return ConfigUtility.CheckDbConnectValid(txtLocalSqlServer, lbWebPartMsg);
        }
        protected void btnSEPCheck_Click(object sender, EventArgs e)
        {
            CheckConnectionStringValid();
        }

        protected void btnHRMISCheck_Click(object sender, EventArgs e)
        {
            CheckHRMISConnectionStringValid();
        }

        protected void btnCRMCheck_Click(object sender, EventArgs e)
        {
            CheckCrmConnectionStringValid();
        }

        protected void btnMYCMMICheck_Click(object sender, EventArgs e)
        {
            CheckMyCMMIConnectionStringValid();
        }

        protected void btnWebPartCheck_Click(object sender, EventArgs e)
        {
            CheckLocalSqlServerValid();
        }
    }
}