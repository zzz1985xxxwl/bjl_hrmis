using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.PhoneMessage;

namespace SEP.Performance.Pages.HRMIS.SystemErrorPages
{
    public partial class PhoneMessageListIFramePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.AddRange(DDLSourse);
            ddlStatus.DataBind();
        }

        private static ListItem[] DDLSourse
        {
            get
            {
                ListItem[] ListItems = new ListItem[3]
                    {
                        new ListItem("������", Convert.ToInt32(PhoneMessageStatus.ToBeConfirm).ToString()),
                        new ListItem("������", Convert.ToInt32(PhoneMessageStatus.ToBeSent).ToString()),
                        new ListItem("���", Convert.ToInt32(PhoneMessageStatus.End).ToString())
                    };
                return ListItems;
            }
        }
    }
}