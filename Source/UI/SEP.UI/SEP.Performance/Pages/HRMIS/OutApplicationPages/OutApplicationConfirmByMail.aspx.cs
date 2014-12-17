using System;
using System.Web.UI;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class OutApplicationConfirmByMail : Page
    {
        private readonly IOutApplicationFacade _OutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int AccountID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["accountId"]));
            int OutApplicationId = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["Id"]));
            bool allover = false;
            foreach (
                OutApplicationItem item in
                    _OutApplicationFacade.GetOutApplicationByOutApplicationID(OutApplicationId).Item)
            {
                allover |= RequestStatus.CanApproveStatus(item.Status);
            }
            if (allover)
            {
                _OutApplicationFacade.ApproveWholeOutApplication(OutApplicationId, AccountID, true, "邮件通过");
            }
            else
            {
                lblMessage.Text = "该申请已经审核完毕，无法再次审核";
            }
        }
    }
}