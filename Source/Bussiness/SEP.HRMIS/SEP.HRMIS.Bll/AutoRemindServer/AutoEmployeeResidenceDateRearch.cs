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
    /// �Զ�����Ա����ס֤���ڣ��ڸþ�ס֤����ǰ_Days�죬���Է�Email�������²��ź�Ա �����˾�ס֤��������
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
        /// ���캯��
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
                            //����ǰ2�������Ѹ���
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
                            //��ٵ���2������������
                            new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id, _MailBodyListToHR,
                                                                  employee.Account.Name, "��");
                        }
                    }
                    employee.EmployeeDetails = null;
                }
            }
            if (_MailBodyListToHR.Count > 0)
            {
                try
                {
                    //���������ʼ�
                    SendEmailToHR(_MailBodyListToHR);
                }
                catch
                {
                    hrFailEmail = "������Դ���ʼ����ѷ���ʧ�ܣ�";
                }
            }
            string throwmessage = "";
            if (!string.IsNullOrEmpty(hrFailEmail))
            {
                throwmessage += hrFailEmail;
            }
            if (!string.IsNullOrEmpty(employeeNameFailEmail))
            {
                throwmessage += "�����ʼ�ʧ�ܡ�����" + employeeNameFailEmail.Split(',').Length + "λԱ��û�л��ϵͳ���ѣ�" +
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
                mail.Subject = "Ա����ס֤��������";
                mail.Body = "����Ա����ס֤����" + _Days + "�����" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
            }
        }

        private void SendEmailToEmployee(Employee employee)
        {
            MailBody mail = new MailBody();
            mail.Subject = "ϵͳ���ѣ���ס֤��Ч�ڼ�������";
            mail.Body = "��ľ�ס֤����" + _Days + "����ڡ�";
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
                    //temp.Name = "�Ϻ��о�ס֤�����.rar";
                    //mail.MailAttachments.Add(temp);
                }
                catch
                {
                }
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
        /// ����
        /// </summary>
        public GetDiyProcess MockGetDiyProcess
        {
            set { _GetDiyProcess = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
        }
        
    }
}