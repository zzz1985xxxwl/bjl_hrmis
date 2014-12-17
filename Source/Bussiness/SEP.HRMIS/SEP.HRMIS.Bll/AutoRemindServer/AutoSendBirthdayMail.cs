//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AutoSendBirthdayMail.cs
// ������: ����
// ��������: 2009-08-18
// ����: �Զ���������ף����
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Mail;
using SEP.IBll.WelcomeMails;
using SEP.Model.Mail;
using WelcomeMail = SEP.Model.Mail.WelcomeMail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// �Զ���������ף����
    /// </summary>
    public class AutoSendBirthdayMail:Transaction
    {
        private readonly DateTime _CurrDate;
        private static GetEmployee _GetEmployee = new GetEmployee();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private static IWelcomeMailBll _IMail = BllInstance.WelcomeMailBllInstance;
        private MailBody _MailBody;
        private WelcomeMail _Mail;
        private bool _VaildateSuccess;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="currDate"></param>
        public AutoSendBirthdayMail(DateTime currDate)
        {
            _CurrDate = currDate;
        }

        /// <summary>
        /// ����
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _Mail = _IMail.GetLastestWelcomeMailByTypeID(MailType.BirthdayMail.Id);
            if (_Mail == null)
            {
                _VaildateSuccess = false;
                return;
            }
            if (!_Mail.EnableAutoSend)
            {
                _VaildateSuccess = false;
                return;
            }
            _VaildateSuccess = true;
        }
        /// <summary>
        /// �������ڲ����ʼ��ؿ�
        /// </summary>
        public IWelcomeMailBll SetWelComeMail
        {
            set
            {
                _IMail = value;
            }
        }

        /// <summary>
        /// �������ڲ����ʼ��ؿ�
        /// </summary>
        public IMailGateWay SetMailGateWay
        {
            set
            {
                _IMailGateWay = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            if (!_VaildateSuccess)
            {
                return;
            }
            string employeeNameFailEmail = "";
            List<Employee> employeeList =
                _GetEmployee.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false);
            //_MailBody = new MailBody();
            //_MailBody.Body = _Mail.Content;
            foreach (Employee employee in employeeList)
            {
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                    continue;
                if (employee.EmployeeDetails == null)
                    continue;
                if (!employee.EmployeeDetails.Birthday.Month.Equals(_CurrDate.Month) ||
                    !employee.EmployeeDetails.Birthday.Day.Equals(_CurrDate.Day))
                {
                    continue;
                }
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
                employee.EmployeeDetails = null;
            }
            if (!string.IsNullOrEmpty(employeeNameFailEmail))
            {
                throw new Exception("�����ʼ�ʧ�ܡ�����" + employeeNameFailEmail.Split(',').Length + "λԱ��û�л��ϵͳ����ף�أ�" +
                                    employeeNameFailEmail);
            }
        }

        private void SendEmailToEmployee(Employee employee)
        {
            MailBody mailBody = new MailBody();
            List<string> mailTo = new List<string>();
            mailTo.Add(employee.Account.Email1);
            mailTo.Add(employee.Account.Email2);
            mailBody.MailTo = mailTo;

            mailBody.Subject = "ף�����տ���";
            mailBody.Body = _Mail.Content;
            _IMailGateWay.Send(mailBody, true);
            _MailBody = mailBody;
        }

        /// <summary>
        /// ����
        /// </summary>
        public MailBody MailBody
        {
            get { return _MailBody; }
        }
    }
}
