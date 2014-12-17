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
    /// ��Ա��ĳ�¹��ʷ����ʼ���Ա��
    /// </summary>
    public class SendEmployeeSalaryToEmployee : Transaction
    {
        private const string _subjuct ="�����Ѿ���������鿴���ʵ�";
        private readonly int _AccountID;
        private readonly DateTime _SalaryDate;
        //private readonly int accountID;
        private readonly EmployeeSalaryHistory _EmployeeSalaryHistory;
        private readonly IEmployeeSalary _DalEmployeeSalary; 
        private readonly GetEmployee _GetEmployee=new GetEmployee();

        private readonly IMailGateWay _TheMailGateWay = BllInstance.MailGateWayBllInstance;

        /// <summary>
        /// ���캯��,֪��Ա���ʺ�ID�ͷ�нʱ�䣬���з��ʼ�
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
        /// ���캯����֪��Ա��������Ϣ�����з��ʼ�
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
        /// ������Ϣ
        ///</summary>
        public string MailFailName
        {
            get { return _MailFailName; }
            set { _MailFailName = value; }
        }

        protected override void Validation()
        {
            //���_EmployeeSalaryHistoryΪnull���״�
        }

        protected override void ExcuteSelf()
        {
            Employee employee = _GetEmployee.GetEmployeeByAccountID(_AccountID);
            //�������Ա��û������USBKEY��USBKEYΪnull��_EmployeeSalaryHistoryΪnull���򲻷���н���ʼ�
            if (employee.Account.UsbKey == null || _EmployeeSalaryHistory==null)
            {
                _MailFailName = employee.Account.Name;
                 return;   
            }
            try
            {

                //������ϢEmployeeAccountSet��USBKEY���ж����������ܣ������ʼ�
                string salary = EncryptSalary(_EmployeeSalaryHistory);
                //usbKey�빤����Ϣһ�����
                string mailBody = SecurityUtil.SymmetricEncrypt(salary, employee.Account.UsbKey);
                //���Ÿ�ʽ ���⣺4�¹����Ѿ���������鿴���ʵ�
                //�����ʼ�
                sendMail(employee, mailBody);
            }
            catch
            {
                _MailFailName = employee.Account.Name;
            }
        }

        /// <summary>
        /// ��װ�ʼ����ݣ������ʼ�
        /// </summary>
        /// <param name="employee">������Ա</param>
        /// <param name="body">��������</param>
        private void sendMail(Employee employee, string body)
        {
            MailBody mail = new MailBody();
            mail.Subject = new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Year + "��" +
                           new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Month + "��" + _subjuct;
            mail.Body = body;
            List<string> mailAddress = new List<string>();
            mailAddress.Add(employee.Account.Email1);
            mail.MailTo = mailAddress;
            _TheMailGateWay.Send(mail);
        }

        /// <summary>
        /// ��װ������Ϣ
        /// </summary>
        /// <param name="employeeSalaryHistory"></param>
        /// <returns></returns>
        private string EncryptSalary(EmployeeSalaryHistory employeeSalaryHistory)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("��������");
            sb.Append("|");
            sb.Append(new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Year + "��" +
                      new HrmisUtility().EndMonthByYearMonth(_SalaryDate).Month + "��");
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
            sb.Append("��ע");
            sb.Append("|");
            sb.Append(string.IsNullOrEmpty(employeeSalaryHistory.Description)
                          ? string.Empty
                          : employeeSalaryHistory.Description);

            return sb.ToString();
        }
    }
}
