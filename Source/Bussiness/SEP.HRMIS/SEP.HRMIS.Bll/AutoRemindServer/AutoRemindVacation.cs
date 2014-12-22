using System;
using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// 年假到期前_Days天提醒个人，提醒人事
    /// </summary>
    public class AutoRemindVacation : Transaction
    {
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private static IVacation _Dal = new VacationDal();
        private static GetEmployee _GetEmployee = new GetEmployee();
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private List<MailBody> _MailBodyListToHR;
        private DateTime _CurrDate;
        private readonly int _Days;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoRemindVacation(DateTime currDate, int days)
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
        /// <summary>
        /// 构造函数，为测试
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        /// <param name="iAccountBll"></param>
        /// <param name="iVacationmock"></param>
        public AutoRemindVacation(DateTime currDate, int days, IAccountBll iAccountBll, IVacation iVacationmock)
        {
            _Days = days;
            _CurrDate = currDate;
            _IAccountBll = iAccountBll;
            _Dal = iVacationmock;
        }

        protected override void Validation()
        {
        }


        protected override void ExcuteSelf()
        {
            List<Model.Vacation> vacations = _Dal.GetAllVacation();
            string employeeNameFailEmail = "";
            string hrFailEmail = "";
            _MailBodyListToHR = new List<MailBody>();
            foreach (Model.Vacation vacation in vacations)
            {
                if (DateTime.Compare(vacation.VacationEndDate, _CurrDate.AddDays(_Days)) == 0)
                {
                    Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(vacation.Employee.Account.Id);
                    if (employee == null)
                    {
                        continue;
                    }
                    if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                        || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                    {
                        continue;
                    }
                    //年假到期前_Days提醒个人
                    try
                    {
                        SendEmailToEmployee(vacation.Employee.Account.Id);
                    }
                    catch
                    {
                        //拼接邮件发送失败人员姓名
                        if (string.IsNullOrEmpty(employeeNameFailEmail))
                        {
                            employeeNameFailEmail = vacation.Employee.Account.Name;
                        }
                        else
                        {
                            employeeNameFailEmail += "," + vacation.Employee.Account.Name;
                        }
                    }
                    //年假到期_Days提醒人事
                    new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(vacation.Employee.Account.Id,
                                                                              _MailBodyListToHR,
                                                                              vacation.Employee.Account.Name, "，");
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
                mail.Subject = BllUtility.GetResourceMessage(BllExceptionConst._Email_To_HR_For_Vacation);
                mail.Body = "以下员工年假将在" + _Days + "天后到期" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
            }
        }

        private void SendEmailToEmployee(int employeeID)
        {
            Account account = _IAccountBll.GetAccountById(employeeID);
            MailBody mail = new MailBody();
            mail.Subject = "系统提醒：年假即将到期";
            mail.Body = "你的年假将在" + _Days + "天后到期。";
            List<string> mailAddress = new List<string>();
            mailAddress.Add(account.Email1);
            mailAddress.Add(account.Email2);
            mail.MailTo = mailAddress;
            _IMailGateWay.Send(mail);
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
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
        }
    }

}
