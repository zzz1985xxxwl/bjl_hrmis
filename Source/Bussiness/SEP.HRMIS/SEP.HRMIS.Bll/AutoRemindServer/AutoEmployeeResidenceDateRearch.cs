using System;
using System.Collections.Generic;
using System.IO;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// 自动提醒员工居住证到期，在该居住证到期前_Days天，可以发Email提醒人事部门和员 工本人居住证即将到期
    /// </summary>
    public class AutoEmployeeResidenceDateRearch : Transaction
    {
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private GetEmployee _GetEmployee = new GetEmployee();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private List<MailBody> _MailBodyListToHR;
        private DateTime _CurrDate;
        private readonly int _Days;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoEmployeeResidenceDateRearch(DateTime currDate, int days)
        {
            _CurrDate = currDate;
            _Days = days;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            string employeeNameFailEmail = "";
            string hrFailEmail = "";
            _MailBodyListToHR = new List<MailBody>();
            List<Employee> allEmployees = _GetEmployee.GetAllEmployeeBasicInfo();
            if (allEmployees != null)
            {
                foreach (Employee employee in allEmployees)
                {
                    if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                        || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                    {
                        continue;
                    }
                    employee.EmployeeDetails =
                        _GetEmployee.GetEmployeeByAccountID(employee.Account.Id).EmployeeDetails;
                    if (employee.EmployeeDetails.ResidencePermits != null)
                    {
                        if (DateTime.Compare(employee.EmployeeDetails.ResidencePermits.DueDate, _CurrDate.AddDays(_Days)) == 0)
                        {
                            //到期前2个月提醒个人
                            try
                            {
                                SendEmailToEmployee(employee);
                            }
                            catch
                            {
                                if (string.IsNullOrEmpty(employeeNameFailEmail))
                                {
                                    employeeNameFailEmail = employee.Account.Name;
                                }
                                else
                                {
                                    employeeNameFailEmail += "," + employee.Account.Name;
                                }
                            }                   
                            //年假到期2个月提醒人事
                            new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id, _MailBodyListToHR,
                                                                  employee.Account.Name, "，");
                        }
                    }
                    employee.EmployeeDetails = null;
                }
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
                    hrFailEmail = "人力资源部邮件提醒发送失败；";
                }
            }
            string throwmessage = "";
            if (!string.IsNullOrEmpty(hrFailEmail))
            {
                throwmessage += hrFailEmail;
            }
            if (!string.IsNullOrEmpty(employeeNameFailEmail))
            {
                throwmessage += "发送邮件失败。以下" + employeeNameFailEmail.Split(',').Length + "位员工没有获得系统提醒：" +
                                employeeNameFailEmail;
            }
            if (!string.IsNullOrEmpty(throwmessage))
            {
                throw new Exception(throwmessage);
            }
        }


        private void SendEmailToHR(List<MailBody> mailBodyListToHR)
        {
            foreach (MailBody mail in mailBodyListToHR)
            {
                mail.Subject = "员工居住证即将到期";
                mail.Body = "以下员工居住证将在" + _Days + "天后到期" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
            }
        }

        private void SendEmailToEmployee(Employee employee)
        {
            MailBody mail = new MailBody();
            mail.Subject = "系统提醒：居住证有效期即将到期";
            mail.Body = "你的居住证将在" + _Days + "天后到期。";
            List<string> mailAddress = new List<string>();
            mailAddress.Add(employee.Account.Email1);
            mailAddress.Add(employee.Account.Email2);
            mail.MailTo = mailAddress;
            TryAddAttachment(mail);
            _IMailGateWay.Send(mail);
        }
        private void TryAddAttachment(MailBody mail)
        {
            if (File.Exists("jzzjn.rar"))
            {
                try
                {
                    //todo wsl
                    const string ContentType = null;
                    //MailAttachment temp = new MailAttachment("jzzjn.rar", ContentType);
                    //temp.Name = "上海市居住证申领表.rar";
                    //mail.MailAttachments.Add(temp);
                }
                catch
                {
                }
            }
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
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
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