using System;
using System.Web.UI;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class OverWorkConfirmByMail : Page
    {
        private readonly IOverWorkFacade _OverWorkFacade = InstanceFactory.CreateOverWorkFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int AccountID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["accountId"]));
            int overWorkID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["Id"]));
            bool allover = false;
            foreach (OverWorkItem item in _OverWorkFacade.GetOverWorkByOverWorkID(overWorkID).Item)
            {
                allover |= RequestStatus.CanApproveStatus(item.Status);
            }
            if (allover)
            {
                _OverWorkFacade.ApproveWholeOverWork(overWorkID, AccountID, true, "邮件通过");
            }
            else
            {
                lblMessage.Text = "该申请已经审核完毕，无法再次审核";
            }
        }
    }
}