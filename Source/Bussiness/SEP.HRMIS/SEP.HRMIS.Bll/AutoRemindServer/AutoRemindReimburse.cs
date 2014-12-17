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
                mailBody.Subject = "请尽快将以下提交的报销单送往财务处，谢谢。";
                StringBuilder emailContentBuilder = new StringBuilder();
                emailContentBuilder.Append(temp.Name + ",您好！");
                emailContentBuilder.Append("<br/>");
                emailContentBuilder.Append("您有一张报销单未送达财务处，请速将您的报销类型为：");
                emailContentBuilder.Append(reimburse.ReimburseCategoriesEnum.Name);
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
                emailContentBuilder.Append("的报销单送达财务处，谢谢。");
                emailContentBuilder.Append(Environment.NewLine);
                mailBody.Body = emailContentBuilder.ToString();
                try
                {
                    //发给员工邮件
                    _IMailGateWay.Send(mailBody);
                }
                catch
                {
                    throw new Exception("员工邮件提醒发送失败");
                }
                employee.EmployeeDetails = null;
            }
        }
    }
}
