using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class AttendanceSettingView : System.Web.UI.UserControl
    {
        public void GetAttendanceSetting(XmlDocument webconfigDoc)
        {
            txtAttendanceStartDay.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                   ConfigUtility.Const_KeyAttendanceStartDay);
        }
        public void SetAttendanceSetting(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc, ConfigUtility.Const_KeyAttendanceStartDay,
                                                  txtAttendanceStartDay.Text.Trim());
        }
        public bool CheckValid()
        {
            bool bRet = true;
            int result;
            if (!int.TryParse(txtAttendanceStartDay.Text.Trim(), out result) || result > 28 || result < 1)
            {
                lbAttendanceStartDayMsg.Text = "请输入一个1-28的整数";
                bRet = false;
            }
            else
            {
                lbAttendanceStartDayMsg.Text = "";
            }

            return bRet;
        }

    }
}