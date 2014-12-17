using System;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using ShiXin.Security;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.IBll.Mail;
using SEP.IBll;
using Mail.Model;
using System.Text;
using SEP.HRMIS.DalFactory;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// 将员工某月工资发送邮件给员工
    /// </summary>
    public class SendEmployeeSalaryToEmployee : Transaction
    {
        private const string _subjuct ="工资已经发出，请查看工资单";
        private readonly int _AccountID;
        private readonly DateTime _SalaryDate;
        //private readonly int accountID;
        private readonly EmployeeSalaryHistory _EmployeeSalaryHistory;
        private readonly IEmployeeSalary _DalEmployeeSalary; 
        private readonly GetEmployee _GetEmployee=new GetEmployee();

        private readonly IMailGateWay _TheMailGateWay = BllInstance.MailGateWayBllInstance;

        /// <summary>
        /// 构造函数,知道员工帐号ID和发薪时间，进行发邮件
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="salaryDate"></param>
        public SendEmployeeSalaryToEmployee(int accountID, DateTime salaryDate)
        {
            _AccountID = accountID;
            _DalEmployeeSalary = PayModuleDataAccess.CreateEmployeeSarary();
            _SalaryDate = salaryDate;
            _EmployeeSalaryHistory = _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(_AccountID, _SalaryDate);
        }

        /// <summary>
        /// 构造函数，知道员工工资信息，进行发邮件
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="employeeSalaryHistory"></param>
        /// <param name="_DalEmployeeSalary"></param>
        public SendEmployeeSalaryToEmployee(int accountID,EmployeeSalaryHistory employeeSalaryHistory, IEmployeeSalary _DalEmployeeSalary)
        {
            _AccountID = accountID;
            _SalaryDate = employeeSalaryHistory.SalaryDateTime;
            _EmployeeSalaryHistory = employeeSalaryHistory;
            this._DalEmployeeSalary = _DalEmployeeSalary;
        }

        private string _MailFailName;
        ///<summary>
        /// 错误消息
        ///</summary>
        public string MailFailName
        {
            get { return _MailFailName; }
            set { _MailFailName = value; }
        }

        protected override void Validation()
        {
            //如果_EmployeeSalaryHistory为null，抛错
        }

        protected override void ExcuteSelf()
        {
            Employee employee = _GetEmployee.GetEmployeeByAccountID(_AccountID);
            //如果发现员工没有生成USBKEY，USBKEY为null，_EmployeeSalaryHistory为null，则不发送薪资邮件
            if (employee.Account.UsbKey == null || _EmployeeSalaryHistory==null)
            {
                _MailFailName = employee.Account.Name;
                 return;   
            }
            try
            {

                //工资信息EmployeeAccountSet与USBKEY进行二进制流加密，发送邮件
                string salary = EncryptSalary(_EmployeeSalaryHistory);
                //usbKey与工资信息一起加密
                string mailBody = SecurityUtil.SymmetricEncrypt(salary, employee.Account.UsbKey);
                //发信格式 标题：4月工资已经发出，请查看工资单
                //发送邮件
                sendMail(employee, mailBody);
            }
            catch
            {
                _MailFailName = employee.Account.Name;
            }
        }

        /// <summary>
        /// 组装邮件内容，发送邮件
        /// </summary>
        /// <param name="employee">发送人员</param>
        /// <param name="body">发送内容</param>
        private void sendMail(Employee employee, string body)
        {
            MailBody mail = new MailBody();
            mail.Subject = new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Year + "年" +
                           new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Month + "月" + _subjuct;
            mail.Body = body;
            List<string> mailAddress = new List<string>();
            mailAddress.Add(employee.Account.Email1);
            mail.MailTo = mailAddress;
            _TheMailGateWay.Send(mail);
        }

        /// <summary>
        /// 组装工资信息
        /// </summary>
        /// <param name="employeeSalaryHistory"></param>
        /// <returns></returns>
        private string EncryptSalary(EmployeeSalaryHistory employeeSalaryHistory)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("工资年月");
            sb.Append("|");
            sb.Append(new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Year + "年" +
                      new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Month + "月");
            foreach (AccountSetItem item in employeeSalaryHistory.EmployeeAccountSet.Items)
            {
                if (!item.AccountSetPara.IsVisibleToEmployee)
                {
                    continue;
                }
                if (!item.AccountSetPara.IsVisibleWhenZero && item.CalculateResult == 0)
                {
                    continue;
                }
                sb.Append("|");
                sb.Append(item.AccountSetPara.AccountSetParaName);
                sb.Append("|");
                sb.Append(item.CalculateResult);
            }
            sb.Append("|");
            sb.Append("备注");
            sb.Append("|");
            sb.Append(string.IsNullOrEmpty(employeeSalaryHistory.Description)
                          ? string.Empty
                          : employeeSalaryHistory.Description);

            return sb.ToString();
        }
    }
}
