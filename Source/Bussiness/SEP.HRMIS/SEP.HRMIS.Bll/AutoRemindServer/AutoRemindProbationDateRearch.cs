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
    /// �����ڵ���ǰn����������
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
        /// ���캯��
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoRemindProbationDateRearch(DateTime currDate, int days)
        {
            _Days = days;
            _CurrDate = currDate;
        }

        /// <summary>
        /// ����
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        protected override void Validation()
        {

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
                        //�����ڵ���n����������
                        new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id, _MailBodyListToHR,
                                                                                  employee.Account.Name, "��");
                    }
                }
                employee.EmployeeDetails = null;
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
                    throw new Exception("������Դ���ʼ����ѷ���ʧ��");
                }
            }
        }

        private void SendEmailToHR(List<MailBody> mailBodyListToHR)
        {
            foreach (MailBody mail in mailBodyListToHR)
            {
                mail.Subject = "Ա�������ڼ�������";
                mail.Body = "����Ա�������ڽ���" + _Days + "�����" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
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
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
        }

    }
}
