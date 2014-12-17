using System;
using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// 试用期到期前n天提醒人事
    /// </summary>
    public class AutoRemindProbationDateRearch : Transaction
    {
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private DateTime _CurrDate;
        private static GetEmployee _GetEmployee = new GetEmployee();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private List<MailBody> _MailBodyListToHR;
        private readonly int _Days;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoRemindProbationDateRearch(DateTime currDate, int days)
        {
            _Days = days;
            _CurrDate = currDate;
        }

        /// <summary>
        /// 测试
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        protected override void Validation()
        {

        }
        /// <summary>
        /// 仅仅用于测试邮件关口
        /// </summary>
        public IMailGateWay SetMailGateWay
        {
            set
            {
                _IMailGateWay = value;
            }
        }
        protected override void ExcuteSelf()
        {
            List<Employee> employeeList =
                _GetEmployee.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false);
            _MailBodyListToHR = new List<MailBody>();
            foreach (Employee employee in employeeList)
            {
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }
                if (employee.EmployeeDetails != null)
                {
                    if (DateTime.Compare(employee.EmployeeDetails.ProbationTime, _CurrDate.AddDays(_Days)) == 0)
                    {
                        //试用期到期n天提醒人事
                        new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id, _MailBodyListToHR,
                                                                                  employee.Account.Name, "，");
                    }
                }
                employee.EmployeeDetails = null;
            }
            if (_MailBodyListToHR.Count > 0)
            {
                try
                {
                    //发给人事邮件
                    SendEmailToHR(_MailBodyListToHR);
                }
                catch
                {
                    throw new Exception("人力资源部邮件提醒发送失败");
                }
            }
        }

        private void SendEmailToHR(List<MailBody> mailBodyListToHR)
        {
            foreach (MailBody mail in mailBodyListToHR)
            {
                mail.Subject = "员工试用期即将到期";
                mail.Body = "以下员工试用期将在" + _Days + "天后到期" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
            }
        }
        /// <summary>
        /// 测试
        /// </summary>
        public GetDiyProcess MockGetDiyProcess
        {
            set { _GetDiyProcess = value; }
        }
        /// <summary>
        /// 测试
        /// </summary>
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
        }

    }
}
