using System;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace SEP.Performance.Pages.Config
{
    public partial class SetWebConfig : Page
    {
        private readonly string _WebConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath +
                                                     @"\web.config";

        protected void Page_Load(object sender, EventArgs e)
        {
            //加载web.config文件
            if (!Page.IsPostBack)
            {
                XmlDocument webconfigDoc = new XmlDocument();
                webconfigDoc.Load(_WebConfigFilePath);

                ConnectStringView1.GetConnectString(webconfigDoc);
                ClassFactoryView1.GetClassFactory(webconfigDoc);
                SubSystemSetView1.GetSubSystemSet(webconfigDoc);
                MailSettingView1.GetMailSetting(webconfigDoc);
                SMSSettingView1.GetSMSSetting(webconfigDoc);
                ContactSettingView1.GetContactSetting(webconfigDoc);
                OtherWebConfig1.GetOtherWebConfig(webconfigDoc);
                AttendanceSettingView1.GetAttendanceSetting(webconfigDoc);
                Message = "";
            }
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

        private void SaveWebConfig(string nextPath)
        {
            try
            {
                if (CheckValidation())
                {
                    //加载web.config文件
                    XmlDocument webconfigDoc = new XmlDocument();
                    webconfigDoc.Load(_WebConfigFilePath);

                    ConnectStringView1.SetConnectString(webconfigDoc);
                    ClassFactoryView1.SetClassFactory(webconfigDoc);
                    SubSystemSetView1.SetSubSystemSet(webconfigDoc);
                    MailSettingView1.SetMailSetting(webconfigDoc);
                    SMSSettingView1.SetSMSSetting(webconfigDoc);
                    ContactSettingView1.SetContactSetting(webconfigDoc);
                    OtherWebConfig1.SetOtherWebConfig(webconfigDoc);
                    AttendanceSettingView1.SetAttendanceSetting(webconfigDoc);
                    //保存设置
                    webconfigDoc.Save(_WebConfigFilePath);
                    Message = "保存成功";

                    Response.Redirect(nextPath);
                }
                else
                {
                    Message = "保存失败";
                }
            }
            catch
            {
                Message = "保存失败";
            }
        }

        private bool CheckValidation()
        {
            bool iRet = ConnectStringView1.CheckConnectionStringValid();
            iRet = iRet && ConnectStringView1.CheckLocalSqlServerValid();
            iRet = iRet && AttendanceSettingView1.CheckValid();
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
            iRet = iRet && SMSSettingView1.CheckValid();
            return iRet;
        }

        protected void btnCompanyInfoConfig_Click(object sender, EventArgs e)
        {
            SaveWebConfig("SetCompanyInfoConfig.aspx");
        }
    }
}