using System.Text;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments; 
using SEP.IBll;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.DiyProcesses
{
    ///<summary>
    /// ����Զ������̷���
    ///</summary>
    public class GetDiyProcess
    {
        private static IDiyProcessDal _DiyProcessDal = DalFactory.DataAccess.CreateDiyProcessDal();
     
        private static IEmployeeDiyProcessDal _DiyEmployeeProcessDal =
            DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetDiyProcess()
        {
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetDiyProcess(IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal)
        {
            _DiyEmployeeProcessDal = mockIEmployeeDiyProcessDal;
        }
        /// <summary>
        /// ���캯�� Ϊ����
        /// </summary>
        /// <param name="mockIDiyProcessDal"></param>
        /// <param name="mockIEmployeeDiyProcessDal"></param>
        /// <param name="mockIAccountBll"></param>
        /// <param name="mockIDepartmentBll"></param>
        public GetDiyProcess(IDiyProcessDal mockIDiyProcessDal, IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal,
            IAccountBll mockIAccountBll, IDepartmentBll mockIDepartmentBll)
        {
            _DiyProcessDal = mockIDiyProcessDal;
            _DiyEmployeeProcessDal = mockIEmployeeDiyProcessDal;
            _IAccountBll = mockIAccountBll;
            _IDepartmentBll = mockIDepartmentBll;
        }

        /// <summary>
        /// �����Զ����������ͻ�ȡ�Զ�������
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <returns></returns>
        public List<DiyProcess> GetDiyProcessByProcessType(int processTypeId)
        {
           return  _DiyProcessDal.GetDiyProcessByProcessType(processTypeId);
        }
        
        /// <summary>
        /// ��ȡԱ�����Զ�������
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<DiyProcess> GetEmployeeDiyProcesses(int accountId)
        {
            List<DiyProcess> processes=new List<DiyProcess>();
            DiyProcess leaveRequst = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, accountId);
            if (leaveRequst!=null)
                processes.Add(leaveRequst);
            DiyProcess outProcess= _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.ApplicationTypeOut, accountId);
            if (outProcess != null)
                processes.Add(outProcess);
            DiyProcess overProcess = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.ApplicationTypeOverTime, accountId);
            if (overProcess != null)
                processes.Add(overProcess);
            DiyProcess assess = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.Assess, accountId);
            if (assess != null)
                processes.Add(assess);
            DiyProcess hrPrincipal = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, accountId);
            if (hrPrincipal != null)
                processes.Add(hrPrincipal);
            //DiyProcess reimburse = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.Reimburse, accountId);
            //if (reimburse != null)
            //    processes.Add(reimburse);
            DiyProcess traineeApplication = _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.TraineeApplication, accountId);
            if (traineeApplication != null)
                processes.Add(traineeApplication);

            return processes;
        }

        /// <summary>
        /// ��ȡĳ�������е���ϸ����
        /// </summary>
        /// <param name="accountId">Ա��id</param>
        /// <param name="DiyprocessId">diy����id</param>
        /// <returns></returns>
        public string GetDiyProcessStepString(int accountId, int DiyprocessId)
        {
            DiyProcess process = _DiyProcessDal.GetDiyProcessByPKID(DiyprocessId);
            Account account = _IAccountBll.GetAccountById(accountId);
            StringBuilder steps = new StringBuilder();

            if (process != null)
            {
                if (process.DiySteps != null)
                {
                    if (process.Type.Id.Equals(ProcessType.ApplicationTypeOut.Id) ||
                        process.Type.Id.Equals(ProcessType.ApplicationTypeOverTime.Id))
                    {
                        return steps.Append(GetOutAndOverWorkOperator(process, account)).ToString();
                    }
                    if (process.Type.Id.Equals(ProcessType.HRPrincipal.Id))
                    {
                        foreach (DiyStep step in process.DiySteps)
                        {
                            steps.Append(GetHRPrincipalProcessString(step));
                            steps.Append(";");
                        }
                        return steps.ToString();
                    }

                    foreach (DiyStep step in process.DiySteps)
                    {
                        steps.Append(GetStepOperator(account, step));
                        steps.Append(";");
                    }
                    return steps.ToString();
                }
            }
            return steps.ToString();
        }

        /// <summary>
        /// ��ȡhr�����������ַ���
        /// </summary>
        /// <param name="diyStep"></param>
        /// <returns></returns>
        private string GetHRPrincipalProcessString(DiyStep diyStep)
        {
            StringBuilder operate = new StringBuilder();
            try
            {
                if (diyStep.MailAccount != null)
                {
                    foreach(Account account in diyStep.MailAccount)
                    {
                        operate.Append(_IAccountBll.GetAccountById(account.Id).Name);
                        operate.Append(" ");
                    }
                }

            }
            catch
            {}
            return operate.ToString();
        }

        /// <summary>
        /// ��ȡ��٣����������������ַ���
        /// </summary>
        /// <param name="account"></param>
        /// <param name="diyStep"></param>
        /// <returns></returns>
        private string GetStepOperator(Account account, DiyStep diyStep)
        {
            StringBuilder operate = new StringBuilder();
            try
            {
                switch (diyStep.OperatorType.Id)
                {
                        //"����"
                    case 0:
                        operate.Append(account.Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"��������"
                    case 1:
                        int leaderId = _IAccountBll.GetLeaderByAccountId(account.Id).Id;
                        operate.Append(_IAccountBll.GetAccountById(leaderId).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"�ϼ���������";
                    case 2:
                        int id = _IDepartmentBll.GetParentDept(account.Dept.Id, null).Leader.Id;
                        operate.Append(_IAccountBll.GetAccountById(id).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"���ϼ���������"
                    case 3:
                        Department department3 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                        id = _IDepartmentBll.GetParentDept(department3.Id, null).Leader.Id;
                        operate.Append(_IAccountBll.GetAccountById(id).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"�����ϼ���������"
                    case 4:
                        Department department4 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                        department4 = _IDepartmentBll.GetParentDept(department4.Id, null);
                        id = _IDepartmentBll.GetParentDept(department4.Id, null).Leader.Id;
                        operate.Append(_IAccountBll.GetAccountById(id).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"�������ϼ���������"
                    case 5:
                        Department department5 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        id = _IDepartmentBll.GetParentDept(department5.Id, null).Leader.Id;
                        operate.Append(_IAccountBll.GetAccountById(id).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                        //"����"
                    case 6:
                        operate.Append(_IAccountBll.GetAccountById(diyStep.OperatorID).Name);
                        operate.Append(" ");
                        operate.Append(diyStep.Status);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                operate.Append("����");
                operate.Append(diyStep.Status);
            }

            return operate.ToString();
        }

         /// <summary>
        /// ��ȡ�Ӱ࣬��������ַ���
        /// </summary>
        /// <param name="process"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private string GetOutAndOverWorkOperator(DiyProcess process, Account account)
         {
             StringBuilder operate = new StringBuilder();
             int nextStep = 0;
             int operatorId = 0;
             for (int i = 0; i < process.DiySteps.Count; i++)
             {
                 DiyStep diyStep = process.DiySteps[i];
                 try
                 {
                     switch (nextStep)
                     {
                             //"����"
                         case 0:
                             operate.Append(account.Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"��������"
                         case 1:
                             int leaderId = _IAccountBll.GetLeaderByAccountId(account.Id).Id;
                             operate.Append(_IAccountBll.GetAccountById(leaderId).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"�ϼ���������";
                         case 2:
                             int id = _IDepartmentBll.GetParentDept(account.Dept.Id, null).Leader.Id;
                             operate.Append(_IAccountBll.GetAccountById(id).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"���ϼ���������"
                         case 3:
                             Department department3 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                             id = _IDepartmentBll.GetParentDept(department3.Id, null).Leader.Id;
                             operate.Append(_IAccountBll.GetAccountById(id).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"�����ϼ���������"
                         case 4:
                             Department department4 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                             department4 = _IDepartmentBll.GetParentDept(department4.Id, null);
                             id = _IDepartmentBll.GetParentDept(department4.Id, null).Leader.Id;
                             operate.Append(_IAccountBll.GetAccountById(id).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"�������ϼ���������"
                         case 5:
                             Department department5 = _IDepartmentBll.GetParentDept(account.Dept.Id, null);
                             department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                             id = _IDepartmentBll.GetParentDept(department5.Id, null).Leader.Id;
                             operate.Append(_IAccountBll.GetAccountById(id).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                             //"����"
                         case 6:
                             operate.Append(_IAccountBll.GetAccountById(operatorId).Name);
                             operate.Append(" ");
                             operate.Append(diyStep.Status);
                             nextStep = diyStep.OperatorType.Id;
                             operatorId = diyStep.OperatorID;
                             break;
                         default:
                             break;
                     }
                 }
                 catch
                 {
                     operate.Append("����");
                     operate.Append(diyStep.Status);
                 }
                 operate.Append(";");
             }
             return operate.ToString();
         }

        /// <summary>
        /// ���Ա��AccountID�����¸�����
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Account> GetHRPrincipalByAccountID(int accountId)
        {
            List<Account> retList = new List<Account>();
            DiyProcess processHRPrincipal =
                _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, accountId);
            if (processHRPrincipal == null || processHRPrincipal.DiySteps == null)
            {
                return retList;
            }
            foreach (DiyStep diystep in processHRPrincipal.DiySteps)
            {
                if (diystep.MailAccount == null)
                {
                    continue;
                }
                foreach (Account account in diystep.MailAccount)
                {
                    Account accounttemp = _IAccountBll.GetAccountById(account.Id);
                    if (accounttemp == null)
                    {
                        continue;
                    }
                    retList.Add(accounttemp);
                }
            }
            return retList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<DiyProcess> GetDiyProcessByCondition(int processTypeId, string name)
        {
            return _DiyProcessDal.GetDiyProcessByCondition(processTypeId, name);
        }

        /// <summary>
        /// ����PKID��ȡ�Զ�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DiyProcess GetDiyProcessByPKID(int id)
        {
            DiyProcess iRet = _DiyProcessDal.GetDiyProcessByPKID(id);
            if (iRet != null && iRet.DiySteps != null)
            {
                for (int i = 0; i < iRet.DiySteps.Count; i++)
                {
                    for (int j = 0; j < iRet.DiySteps[i].MailAccount.Count; j++)
                    {
                        iRet.DiySteps[i].MailAccount[j] =
                            _IAccountBll.GetAccountById(iRet.DiySteps[i].MailAccount[j].Id);
                    }
                }
            }
            return iRet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<string> GetAccountMailListByDiyProcessIDAccountID(DiyStep step, int accountID)
        {
            List<string> mailToList = new List<string>();
            List<Account> accounts = step.MailAccount;
            for (int i = 0; i < step.MailRole.Count; i++)
            {
                DiyProcess hrProcess =
                    _DiyEmployeeProcessDal.GetDiyProcessByProcessTypeAndAccountID(step.MailRole[i], accountID);
                accounts.AddRange(hrProcess.DiySteps[0].MailAccount);
            }

            foreach (Account account in accounts)
            {
                Account innaccount = _IAccountBll.GetAccountById(account.Id);
                mailToList.AddRange(HrmisUtility.GetMail(innaccount));
            }
            RequestUtility.CleanMailAddress(mailToList);
            return mailToList;
        }
    }
}
