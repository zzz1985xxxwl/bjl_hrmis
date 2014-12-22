using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter;
using SEP.IBll;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.PositionPages
{
    public partial class PositionApplicationConfirmByMail : System.Web.UI.Page
    {
        private readonly IPositionApplicationFacade _Facade = InstanceFactory.CreatePositionApplicationFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int AccountID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["accountId"]));
            Account account = BllInstance.AccountBllInstance.GetAccountById(AccountID);
            int PositionAppID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["Id"]));
            
            bool allover = false;
            PositionApplication pa = _Facade.GetPositionApplicationByPKID(PositionAppID);
            if (RequestStatus.CanApproveStatus(pa.Status))
            {
                RequestStatus rs = RequestStatus.ApprovePass;
                if (pa.Status.Id == RequestStatus.Cancelled.Id)
                {
                    rs = RequestStatus.ApproveCancelPass;
                }
                _Facade.ApprovePositionApplication(pa, AccountID, rs,
                                                   (account != null && account.Name != null ? account.Name : "") +
                                                   "邮件通过");
            }
            else
            {
                lblMessage.Text = "该申请已经审核完毕，无法再次审核";
            }
        }
    }
}