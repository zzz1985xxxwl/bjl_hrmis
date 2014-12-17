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
            mailBody.Subject = "���ı������Ѿ�ͨ����ˣ���ȥ������ȡ�����ѣ�лл��";
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(temp.Name + ",���ã�");
            emailContentBuilder.Append("<br/>");
            emailContentBuilder.Append("���ı�������Ϊ��");
            emailContentBuilder.Append(reimburse.ReimburseCategoriesEnum.Name);
            emailContentBuilder.Append("��");
            emailContentBuilder.Append("����ʱ�䣺");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.ToShortDateString());
            emailContentBuilder.Append("��");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.Hour.ToString());
            emailContentBuilder.Append("ʱ");
            emailContentBuilder.Append(reimburse.ConsumeDateFrom.Minute.ToString());
            emailContentBuilder.Append("��");
            emailContentBuilder.Append("---");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.ToShortDateString());
            emailContentBuilder.Append("��");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.Hour.ToString());
            emailContentBuilder.Append("ʱ");
            emailContentBuilder.Append(reimburse.ConsumeDateTo.Minute.ToString());
            emailContentBuilder.Append("��");
            emailContentBuilder.Append("��");
            emailContentBuilder.Append("�ܶ");
            emailContentBuilder.Append(reimburse.TotalCost);
            emailContentBuilder.Append("Ԫ");
            emailContentBuilder.Append("�ı������Ѿ�ͨ����ˣ���ȥ������ȡ�����ѣ�лл��");
            emailContentBuilder.Append(Environment.NewLine);
            mailBody.Body = emailContentBuilder.ToString();
            try
            {
                //����Ա���ʼ�
                _MailGateWay.Send(mailBody);
            }
            catch
            {
                throw new Exception("Ա����ȡ�������ѷ���ʧ��");
            }

        }
    }
}
