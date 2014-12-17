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
    /// 自动发起考评
    /// </summary>
    public class AutoAssess : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static ManualAssess _ManualAssess;
        private static IContract _IContract = DalFactory.DataAccess.CreateContract();
        private List<MailBody> _MailBodyListToHR;
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private GetDiyProcess _GetDiyProcess = new GetDiyProcess();
        private GetEmployee _GetEmployee = new GetEmployee();

        private DateTime _CurrDate = DateTime.Now.Date;

        /// <summary>
        /// SystemAssess的构造函数
        /// </summary>
        /// <param name="currDate">当前的时间日期</param>
        public AutoAssess(DateTime currDate)
        {
            _CurrDate = currDate;
        }

        /// <summary>
        /// AutoAssess的构造函数，专为测试提供
        /// </summary>
        /// <param name="mockContract">测试中的Contractmock对象</param>
        /// <param name="currDate">当前的时间日期</param>
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
                assessActivityItem.AssessProposerName = "系统自动发起";
                assessActivityItem.Reason = WriteEmailContent(assessActivityItem, contract);
                //新增考核活动
                _ManualAssess = new ManualAssess(assessActivityItem);
                try
                {
                    _ManualAssess.Excute();
                }
                catch (Exception ex)
                {
                    new AutoRemindServerUtility(_GetDiyProcess).CreateHREmail(employee.Account.Id,
                                                                              _MailBodyListToHR,
                                                                              "系统自动发起的" + employee.Account.Name +
                                                                              "绩效考核失败，失败原因：" + ex.Message + "（相关参考信息：" +
                                                                              assessActivityItem.Reason + "）",
                                                                              Environment.NewLine);
                }
                employee.EmployeeDetails = null;
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
                    throw new Exception("人力资源部邮件提醒发送失败");
                }
            }
        }

        private void SendEmailToHR(List<MailBody> mailBodyListToHR)
        {
            foreach (MailBody mail in mailBodyListToHR)
            {
                mail.Subject = "部分员工已到达考核时期，详情请看邮件内容";
                _IMailGateWay.Send(mail);
            }
        }

        private static string WriteEmailContent(Model.AssessActivity assessActivityItem, Contract contract)
        {
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append("根据");
            emailContentBuilder.Append("第");
            emailContentBuilder.Append(contract.ContractID);
            emailContentBuilder.Append("号合同——");
            emailContentBuilder.Append(contract.ContractType.ContractTypeName);
            emailContentBuilder.Append(contract.StartDate.ToShortDateString());
            emailContentBuilder.Append("---");
            emailContentBuilder.Append(contract.EndDate.ToShortDateString());
            emailContentBuilder.Append("，系统自动为 ");
            emailContentBuilder.Append(assessActivityItem.ItsEmployee.Account.Name);
            emailContentBuilder.Append(" 发起一次");
            emailContentBuilder.Append(AssessActivityUtility.GetCharacterNameByType(assessActivityItem.AssessCharacterType));
            emailContentBuilder.Append("; ");
            return emailContentBuilder.ToString();
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
        public List<MailBody> MailBodyListToHR
        {
            get { return _MailBodyListToHR; }
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
    }
}
