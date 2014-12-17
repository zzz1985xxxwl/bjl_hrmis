using System;
using System.Web;
using System.Xml;

namespace SEP.Performance.Pages.Config
{
    public partial class SetAutoRemindConfig : System.Web.UI.Page
    {
        private readonly string _WebConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\web.config";
        private string _FilePath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_WebConfigFilePath);
                SubSystemSetView1.GetSubSystemSet(webconfigDoc);
            }
            if (!string.IsNullOrEmpty(fAppAddress.Value))
            {
                ViewState["SetAutoRemindConfig_FilePath"] = fAppAddress.Value;
            }
            else
            {
                ViewState["SetAutoRemindConfig_FilePath"] = ViewState["SetAutoRemindConfig_FilePath"] ?? string.Empty;
            }
            _FilePath = Convert.ToString(ViewState["SetAutoRemindConfig_FilePath"]);
            ConnectStringView1.IsWebPartStringShow = false;
            SubSystemSetView1.ReadOnly = true;
            Message = "";
        }

        private string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    lbMessage.Style["display"] = "none";
                }
                else
                {
                    lbMessage.Text = value;
                    lbMessage.Style["display"] = "block";
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation())
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_FilePath);
                ConnectStringView1.SetConnectString(webconfigDoc);
                ClassFactoryView1.SetClassFactory(webconfigDoc);
                AutoRemindFunctionSetView1.SetFunctionSetting(webconfigDoc);
                MailSettingView1.SetMailSetting(webconfigDoc);
                AttendanceSettingView1.SetAttendanceSetting(webconfigDoc);

                //保存设置
                webconfigDoc.Save(_FilePath);
                Message = "保存成功";
                NextPage();
            }
            else
            {
                Message = "保存失败";
            }
        }

        private bool CheckValidation()
        {
            bool iRet = true;

            if (string.IsNullOrEmpty(_FilePath))
            {
                lbLoadMessage.Text = "请选择一个App.Config";
                iRet = false;
            }
            else
            {
                lbLoadMessage.Text = "";
            }

            #region 数据库链接
            iRet = iRet && ConnectStringView1.CheckConnectionStringValid();
            if (SubSystemSetView1.HasHrmisSystem)
            {
                iRet = iRet && ConnectStringView1.CheckHRMISConnectionStringValid();
            }
            if (SubSystemSetView1.HasCRMSystem)
            {
                iRet = iRet && ConnectStringView1.CheckCrmConnectionStringValid();
            }

            if (SubSystemSetView1.HasMyCMMISystem)
            {
                iRet = iRet && ConnectStringView1.CheckMyCMMIConnectionStringValid();
            }

            #endregion

            iRet = iRet && AutoRemindFunctionSetView1.CheckValid();
            iRet = iRet && AttendanceSettingView1.CheckValid();

            return iRet;
        }

        protected void btnLoadInfo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_FilePath))
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_FilePath);

                ConnectStringView1.GetConnectString(webconfigDoc);
                ClassFactoryView1.GetClassFactory(webconfigDoc);
                AutoRemindFunctionSetView1.GetFunctionSetting(webconfigDoc);
                MailSettingView1.GetMailSetting(webconfigDoc);
                AttendanceSettingView1.GetAttendanceSetting(webconfigDoc);

            }
            else
            {
                lbLoadMessage.Text = "请选择一个App.Config";
            }
        }

        protected void lbDBConnectionCopy_Click(object sender, EventArgs e)
        {
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_WebConfigFilePath);

            ConnectStringView1.GetConnectString(webconfigDoc);
        }

        protected void lbClassFactoryCopy_Click(object sender, EventArgs e)
        {
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_WebConfigFilePath);

            ClassFactoryView1.GetClassFactory(webconfigDoc);
        }

        protected void lbMSMQMailCopy_Click(object sender, EventArgs e)
        {
            XmlDocument webconfigDoc = new XmlDocument();
            webconfigDoc.Load(_WebConfigFilePath);

            MailSettingView1.GetMailSetting(webconfigDoc);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SetCompanyInfoConfig.aspx");
        }
        private void NextPage()
        {
            Response.Redirect("SetOtherCompanyInfoConfig.aspx");
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            NextPage();
        }
    }
}
