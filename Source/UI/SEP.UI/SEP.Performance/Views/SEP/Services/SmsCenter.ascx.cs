using System;
using SEP.IBll.SMS;
namespace SEP.Performance.Views.SEP.Services
{
    public partial class SmsCenter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowTheSmsStatus();
        }

        protected void btnReActiveSms_Click(object sender, EventArgs e)
        {
            SmsClientProcessCenter.ReActiveTheService();
            ShowTheSmsStatus();
        }

        private void ShowTheSmsStatus()
        {
            lblSmsStatus.Text = SmsClientProcessCenter.GetSmsServiceEnable.Enable ? "¼¤»î" : "¹Ø±Õ";
            lblSmsDetails.Text = SmsClientProcessCenter.GetSmsServiceEnable.ToString();
        }
    }
}