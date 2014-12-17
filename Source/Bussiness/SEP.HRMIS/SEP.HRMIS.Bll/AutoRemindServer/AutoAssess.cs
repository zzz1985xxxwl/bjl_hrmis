using System;
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// �Զ�������
    /// </summary>
    public class AutoAssess : Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static ManualAssess _ManualAssess;
        private static IContract _IContract = DalFactory.DataAccess.CreateContract();
        private List<MailBody> _MailBodyListToHR;
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private GetEmployee _GetEmployee = new GetEmployee();

        private DateTime _CurrDate = DateTime.Now.Date;

        /// <summary>
        /// SystemAssess�Ĺ��캯��
        /// </summary>
        /// <param name="currDate">��ǰ��ʱ������</param>
        public AutoAssess(DateTime currDate)
        {
            _CurrDate = currDate;
        }

        /// <summary>
        /// AutoAssess�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        /// <param name="mockContract">�����е�Contractmock����</param>
        /// <param name="currDate">��ǰ��ʱ������</param>
        public AutoAssess(IContract mockContract, DateTime currDate)
        {
            _IContract = mockContract;
            _CurrDate = currDate;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            _MailBodyListToHR = new List<MailBody>();
            List<ApplyAssessCondition> applyAssessConditions = _IContract.GetApplyAssessConditionByCurrDate(_CurrDate);
            if (_CurrDate.Month == 12 && _CurrDate.Day == 1)
            {
                applyAssessConditions = applyAssessConditions ?? new List<ApplyAssessCondition>();
                var contracts = _IContract.GetEmployeeContractByContractTypeId(5);
                if (contracts != null)
                {
                    foreach (var contract in contracts)
                    {
                        applyAssessConditions.Add(new ApplyAssessCondition(0) { EmployeeContractID = contract.ContractID, ApplyAssessCharacterType = AssessCharacterType.Annual, AssessScopeFrom = new DateTime(_CurrDate.Year, 1, 1), AssessScopeTo = new DateTime(_CurrDate.Year, 12, 31) });
                    }
                }
            }


            foreach (ApplyAssessCondition conditionItem in applyAssessConditions)
            {
                Contract contract = _IContract.GetEmployeeContractByContractId(conditionItem.EmployeeContractID);
                Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(contract.EmployeeID);
                if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    || employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }
                Model.AssessActivity assessActivityItem = new Model.AssessActivity();
                assessActivityItem.AssessCharacterType = conditionItem.ApplyAssessCharacterType;
                assessActivityItem.ScopeFrom = conditionItem.AssessScopeFrom;
                assessActivityItem.ScopeTo = conditionItem.AssessScopeTo;
                assessActivityItem.ItsEmployee = employee;
                assessActivityItem.EmployeeDept = employee.Account.Dept.DepartmentName;
                assessActivityItem.AssessProposerName = "ϵͳ�Զ�����";
                assessActivityItem.Reason = WriteEmailContent(assessActivityItem, contract);
                //�������˻
                _ManualAssess = new ManualAssess(assessActivityItem);
                try
                {
                    _ManualAssess.Excute();
                }
                catch (Exception ex)
                {
                    new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id,
                                                                              _MailBodyListToHR,
                                                                              "ϵͳ�Զ������" + employee.Account.Name +
                                                                              "��Ч����ʧ�ܣ�ʧ��ԭ��" + ex.Message + "����زο���Ϣ��" +
                                                                              assessActivityItem.Reason + "��",
                                                                              Environment.NewLine);
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
                mail.Subject = "����Ա���ѵ��￼��ʱ�ڣ������뿴�ʼ�����";
                _IMailGateWay.Send(mail);
            }
        }

        private static string WriteEmailContent(Model.AssessActivity assessActivityItem, Contract contract)
        {
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append("����");
            emailContentBuilder.Append("��");
            emailContentBuilder.Append(contract.ContractID);
            emailContentBuilder.Append("�ź�ͬ����");
            emailContentBuilder.Append(contract.ContractType.ContractTypeName);
            emailContentBuilder.Append(contract.StartDate.ToShortDateString());
            emailContentBuilder.Append("---");
            emailContentBuilder.Append(contract.EndDate.ToShortDateString());
            emailContentBuilder.Append("��ϵͳ�Զ�Ϊ ");
            emailContentBuilder.Append(assessActivityItem.ItsEmployee.Account.Name);
            emailContentBuilder.Append(" ����һ��");
            emailContentBuilder.Append(AssessActivityUtility.GetCharacterNameByType(assessActivityItem.AssessCharacterType));
            emailContentBuilder.Append("; ");
            return emailContentBuilder.ToString();
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
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
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
    }
}
