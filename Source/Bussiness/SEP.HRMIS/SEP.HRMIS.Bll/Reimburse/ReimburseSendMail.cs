using System;
using System.Text;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public class ReimburseSendMail : Transaction
    {
        private readonly Model.Reimburse _Reimburse;
        private readonly IReimburse _IReimburse = DalFactory.DataAccess.CreateReimburse();
        private delegate void DelSendMail(Model.Reimburse reimburse);
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private static readonly IMailGateWay _MailGateWay = BllInstance.MailGateWayBllInstance;
        /// <summary>
        /// 
        /// </summary>
        public ReimburseSendMail(int reimburseID)
        {
            _Reimburse = _IReimburse.GetReimburseByReimburseID(reimburseID);
        }

        protected override void Validation()
        {
        }
        protected override void ExcuteSelf()
        {
            SendMailAnsy(_Reimburse);
        }

        private static void SendMailAnsy(Model.Reimburse reimburse)
        {
            DelSendMail sendMailDelegate = SendMail;
            sendMailDelegate.BeginInvoke(reimburse, null, null);
        }

        private static void SendMail(Model.Reimburse reimburse)
        {
            Account temp = _AccountBll.GetAccountById(reimburse.ApplierID);
            MailBody mailBody = new MailBody();
            mailBody.MailTo = RequestUtility.GetMail(temp);
            mailBody.Subject = "您的报销单已经通过审核，请去财务处领取报销费，谢谢。";
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(temp.Name + ",您好！");
            emailContentBuilder.Append("<br/>");
            emailContentBuilder.Append("您的报销类型为：");
            emailContentBuilder.Append(reimburse.ReimburseCategoriesEnum.Name);
            emailContentBuilder.Append("、");
            emailContentBuilder.Append("消费时间：");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.ToShortDateString());
            emailContentBuilder.Append("日");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.Hour.ToString());
            emailContentBuilder.Append("时");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.Minute.ToString());
            emailContentBuilder.Append("分");
            emailContentBuilder.Append("---");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.ToShortDateString());
            emailContentBuilder.Append("日");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.Hour.ToString());
            emailContentBuilder.Append("时");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.Minute.ToString());
            emailContentBuilder.Append("分");
            emailContentBuilder.Append("、");
            emailContentBuilder.Append("总额：");
            emailContentBuilder.Append(reimburse.TotalCost);
            emailContentBuilder.Append("元");
            emailContentBuilder.Append("的报销单已经通过审核，请去财务处领取报销费，谢谢。");
            emailContentBuilder.Append(Environment.NewLine);
            mailBody.Body = emailContentBuilder.ToString();
            try
            {
                //发给员工邮件
                _MailGateWay.Send(mailBody);
            }
            catch
            {
                throw new Exception("员工领取报销提醒发送失败");
            }

        }
    }
}
