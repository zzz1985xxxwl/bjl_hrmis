using System.Text;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class PositionApplicationOverMail
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();
        private readonly PositionApplication _PositionApplication;
        private readonly DiyStep _CurrentStep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="currentStep"></param>
        public PositionApplicationOverMail(int positionApplicationID, DiyStep currentStep)
        {
            _PositionApplication = new GetPositionApplication().GetPositionApplicationByPKID(positionApplicationID);
            _PositionApplication.Account = _AccountBll.GetAccountById(_PositionApplication.Account.Id);
            _CurrentStep = currentStep;
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void ConfirmOverMail()
        {
            bool over = true;
            over &= _PositionApplication.Status.Id == RequestStatus.ApproveCancelFail.Id ||
                    _PositionApplication.Status.Id == RequestStatus.ApproveCancelPass.Id ||
                    _PositionApplication.Status.Id == RequestStatus.ApproveFail.Id ||
                    _PositionApplication.Status.Id == RequestStatus.ApprovePass.Id;
            if (over)
            {
                MailBody mailBody = new MailBody();
                mailBody.Subject =
                    string.Format("审核完毕{0}的职位申请", _PositionApplication.Account.Name);
                StringBuilder body = new StringBuilder();
                body.AppendFormat(PositionApplicationMail.BuildBody(_PositionApplication));
                mailBody.Body = body.ToString();
                mailBody.IsHtmlBody = true;
                mailBody.MailTo = HrmisUtility.GetMail(_PositionApplication.Account);
                mailBody.MailCc = new GetDiyProcess(_DalEmployeeDiyProcess).GetAccountMailListByDiyProcessIDAccountID(
                        _CurrentStep, _PositionApplication.Account.Id);
                _MailGateWay.Send(mailBody);
            }
        }
    }
}