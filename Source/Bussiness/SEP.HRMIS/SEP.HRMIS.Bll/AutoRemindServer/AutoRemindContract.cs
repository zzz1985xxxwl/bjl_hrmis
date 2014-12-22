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
    /// 员工合同到期前_Days天提醒人事
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
        /// 构造函数
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public AutoRemindContract(DateTime currDate, int days)
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
        /// 仅仅用于测试邮件关口
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
                emailContentBuilder.Append("的");
                emailContentBuilder.Append(contract.ContractType.ContractTypeName);
                emailContentBuilder.Append(contract.StartDate.ToShortDateString());
                emailContentBuilder.Append("---");
                emailContentBuilder.Append(contract.EndDate.ToShortDateString());
                emailContentBuilder.Append("还有" + _Days + "天即将到期；");
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
                mail.Subject = BllUtility.GetResourceMessage(BllExceptionConst._Email_To_HR_For_Contract);
                mail.Body = "以下员工合同即将到期" + Environment.NewLine + mail.Body;
                _IMailGateWay.Send(mail);
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
