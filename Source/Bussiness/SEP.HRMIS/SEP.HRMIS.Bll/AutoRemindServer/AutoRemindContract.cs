using System;
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// Ա����ͬ����ǰ_Days����������
    /// </summary>
    public class AutoRemindContract : Transaction
    {
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private DateTime _CurrDate;
        private readonly IContract _IContract = new ContractDal();
        private static GetEmployee _GetEmployee = new GetEmployee();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private List<MailBody> _MailBodyListToHR;
        private readonly int _Days;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoRemindContract(DateTime currDate, int days)
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
        /// <summary>
        /// ���캯����Ϊ����
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        /// <param name="mockContract"></param>
        public AutoRemindContract(DateTime currDate, int days, IContract mockContract)
        {
            _Days = days;
            _CurrDate = currDate;
            _IContract = mockContract;
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
            List<Contract> contractList =
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          _CurrDate.AddDays(_Days), _CurrDate.AddDays(_Days), -1);
            _MailBodyListToHR = new List<MailBody>();
            foreach (Contract contract in contractList)
            {
                Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(contract.EmployeeID);
                if (employee == null)
                {
                    continue;
                }
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }

                StringBuilder emailContentBuilder = new StringBuilder();
                emailContentBuilder.Append(employee.Account.Name);
                emailContentBuilder.Append("��");
                emailContentBuilder.Append(contract.ContractType.ContractTypeName);
                emailContentBuilder.Append(contract.StartDate.ToShortDateString());
                emailContentBuilder.Append("---");
                emailContentBuilder.Append(contract.EndDate.ToShortDateString());
                emailContentBuilder.Append("����" + _Days + "�켴�����ڣ�");
                emailContentBuilder.Append(Environment.NewLine);
                new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(contract.EmployeeID, _MailBodyListToHR,
                                                                          emailContentBuilder.ToString(),
                                                                          Environment.NewLine);
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
                mail.Subject = BllUtility.GetResourceMessage(BllExceptionConst._Email_To_HR_For_Contract);
                mail.Body = "����Ա����ͬ��������" + Environment.NewLine + mail.Body;
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
