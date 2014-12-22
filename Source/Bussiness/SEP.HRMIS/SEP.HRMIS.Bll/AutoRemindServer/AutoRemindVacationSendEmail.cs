using System;
using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Mail;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    ///<summary>
    ///</summary>
    public class AutoRemindVacationSendEmail
    {
        private static IVacation _Dal = new VacationDal();
        private static GetEmployee _GetEmployee = new GetEmployee();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private DateTime _CurrDate;
        private readonly List<DateTime> _DateList;
        ///<summary>
        ///</summary>
        ///<param name="date"></param>
        ///<param name="dateList"></param>
        public AutoRemindVacationSendEmail(DateTime date,List<DateTime> dateList)
        {
            _CurrDate = date;
            _DateList = dateList;
            _MailBodyList = new List<MailBody>();
        }

        /// <summary>
        /// 测试
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
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
        /// 构造函数，为测试
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateList"></param>
        /// <param name="iVacationmock"></param>
        public AutoRemindVacationSendEmail(DateTime date, List<DateTime> dateList, 
            IVacation iVacationmock)
        {
            _CurrDate = date;
            _DateList = dateList;
            _Dal = iVacationmock;
            _MailBodyList=new List<MailBody>();
        }

        ///<summary>
        ///</summary>
        ///<exception cref="Exception"></exception>
        public void Excute()
        {
            string employeeNameFailEmail = "";
            foreach (DateTime date in _DateList)
            {
                if (date.Month == _CurrDate.Month && date.Day == _CurrDate.Day)
                {
                    List<Employee> allEmployeeList = _GetEmployee.GetAllEmployeeBasicInfo();
                    foreach (Employee employee in allEmployeeList)
                    {
                        if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                            || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                        {
                            continue;
                        }
                        Vacation vacation = _Dal.GetNearVacationByAccountIDAndTime(employee.Account.Id, _CurrDate);

                        if (vacation == null || vacation.SurplusDayNum==0)
                        {
                            continue;
                        }
                        try
                        {
                            vacation.Employee.Account = employee.Account;
                            SendEmailToEmployee(vacation);
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
                        employee.EmployeeDetails = null;
                    }
                    break;
                }
            }

            string throwmessage = "";
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
        private static void SendEmailToEmployee(Vacation vacation)
        {
            Account account = vacation.Employee.Account;
            MailBody mail = new MailBody();
            mail.Subject = "系统提醒：年假即将到期";
            mail.Body = "你的年假还有"+vacation.SurplusDayNum+"天，将在" + vacation.VacationEndDate + "到期。";
            _MailBodyList.Add(mail);
            List<string> mailAddress = new List<string>();
            mailAddress.Add(account.Email1);
            mailAddress.Add(account.Email2);
            mail.MailTo = mailAddress;
            _IMailGateWay.Send(mail);
        }
        private static List<MailBody> _MailBodyList;

        /// <summary>
        /// 测试
        /// </summary>
        public List<MailBody> MailBodyList
        {
            get { return _MailBodyList; }
        }
    }
}
