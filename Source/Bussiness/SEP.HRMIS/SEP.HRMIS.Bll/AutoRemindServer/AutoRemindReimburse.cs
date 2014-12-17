using System;
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    public class AutoRemindReimburse : Transaction
    {
        private static readonly IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IReimburse _IReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly static GetEmployee _GetEmployee = new GetEmployee();
 
        protected override void Validation()
        {

        }

        protected override void ExcuteSelf()
        {
            List<Model.Reimburse> reimburseList = _IReimburse.GetReimburseByDateTime();
            foreach (Model.Reimburse reimburse in reimburseList)
            {
                if (reimburse.ReimburseStatus != ReimburseStatusEnum.Reimbursing)
                {
                    continue;
                }
                Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(reimburse.ApplierID);
                if (employee == null)
                {
                    continue;
                }
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }
                Account temp = _AccountBll.GetAccountById(reimburse.ApplierID);
                MailBody mailBody = new MailBody();
                mailBody.MailTo = RequestUtility.GetMail(temp);
                mailBody.Subject = "�뾡�콫�����ύ�ı������������񴦣�лл��";
                StringBuilder emailContentBuilder = new StringBuilder();
                emailContentBuilder.Append(temp.Name + ",���ã�");
                emailContentBuilder.Append("<br/>");
                emailContentBuilder.Append("����һ�ű�����δ�ʹ���񴦣����ٽ����ı�������Ϊ��");
                emailContentBuilder.Append(reimburse.ReimburseCategoriesEnum.Name);
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
                emailContentBuilder.Append("�ı������ʹ���񴦣�лл��");
                emailContentBuilder.Append(Environment.NewLine);
                mailBody.Body = emailContentBuilder.ToString();
                try
                {
                    //����Ա���ʼ�
                    _IMailGateWay.Send(mailBody);
                }
                catch
                {
                    throw new Exception("Ա���ʼ����ѷ���ʧ��");
                }
                employee.EmployeeDetails = null;
            }
        }
    }
}
