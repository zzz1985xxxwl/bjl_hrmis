using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class TraineeApplicationConfirmByMail :Page
    {
        private readonly ITraineeApplicationFacade _ITraineeApplicationFacade = InstanceFactory.CreateTraineeApplicationFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            int AccountID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["accountId"]));
            int TraineeApplicationID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["Id"]));
            TraineeApplication traineeApplication =_ITraineeApplicationFacade.GetTraineeApplicationByPkid(TraineeApplicationID);
            if (TraineeApplicationStatus.CanApproveStatus(traineeApplication.TraineeApplicationStatuss))
            {
                _ITraineeApplicationFacade.ApproveTraineeApplicationWhole
                    (new Account(AccountID,"",""), TraineeApplicationID, TraineeApplicationStatus.ApprovePass, "邮件通过");
            }
            else
            {
                lblMessage.Text = "该申请已经审核完毕，无法再次审核";
            }

        }
    }
}
