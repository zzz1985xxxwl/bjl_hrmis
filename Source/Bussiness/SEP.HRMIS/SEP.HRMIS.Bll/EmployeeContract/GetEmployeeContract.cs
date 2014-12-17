using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.EmployeeContract
{
    /// <summary>
    /// ��ȡԱ����ͬ��Ϣ
    /// </summary>
    public class GetEmployeeContract
    {
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static IEmployee _dalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IContract _dalContract = DalFactory.DataAccess.CreateContract();
        private static IContractBookMark _dalContractBookMark = DalFactory.DataAccess.CreateContractBookMark();
        private static IEmployeeContractBookMark _dalEmployeeContractBookMark = DalFactory.DataAccess.CreateEmployeeContractBookMark();

        private static IEmployeeSkill _dalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        private static IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private static IEmployeeAdjustRule _EmployeeAdjustRuleDal = DalFactory.DataAccess.CreateEmployeeAdjustRule();

        /// <summary>
        /// ��ȡԱ����ͬ��Ϣ���캯��
        /// </summary>
        public GetEmployeeContract()
        {
        }
        /// <summary>
        /// ��ȡԱ����ͬ��Ϣ���캯��
        /// </summary>
        public GetEmployeeContract(IEmployee mockIEmployee, IAccountBll mockIAccountBll, IContract mockIContract,
            IContractBookMark mockIContractBookMark, IEmployeeContractBookMark mockIEmployeeContractBookMark,
            IEmployeeSkill mockIEmployeeSkill, IDepartmentBll mockIDepartmentBll, IEmployeeAdjustRule mockIEmployeeAdjustRule)
        {
            _dalEmployee = mockIEmployee;
            _IAccountBll = mockIAccountBll;
            _dalContract = mockIContract;
            _dalContractBookMark = mockIContractBookMark;
            _dalEmployeeContractBookMark = mockIEmployeeContractBookMark;
            _dalEmployeeSkill = mockIEmployeeSkill;
            _IDepartmentBll = mockIDepartmentBll;
            _EmployeeAdjustRuleDal = mockIEmployeeAdjustRule;
        }

        /// <summary>
        /// ��ȡԱ�����µĺ�ͬ
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public Contract GetCurrentContractByAccountID(int accountId, DateTime currentDate)
        {
            Contract contract = _dalContract.GetCurrentContractByAccountID(accountId, currentDate);
            if (contract != null)
            {
                contract.EmployeeContractBookMark =
                    _dalEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(contract.ContractID);
            }
            return contract;
        }

        /// <summary>
        /// ���ݺ�ͬ���Ͳ�ѯ��ͬ
        /// </summary>
        /// <param name="contractTypeId"></param>
        /// <returns></returns>
        public List<Contract> GetEmployeeContractByContractTypeId(int contractTypeId)
        {
            return _dalContract.GetEmployeeContractByContractTypeId(contractTypeId);
        }
        /// <summary>
        /// ����PKID��ѯ��ͬ
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public Contract GetEmployeeContractByContractId(int contractId)
        {
            Contract contract = _dalContract.GetEmployeeContractByContractId(contractId);
            if (contract == null)
            {
                return contract;
            }
            contract.EmployeeContractBookMark =
                _dalEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(contractId);
            return contract;
        }

        /// <summary>
        /// �õ�ĳ��Ա�������к�ͬ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<Contract> GetEmployeeContractByAccountID(int employeeID)
        {
            return _dalContract.GetEmployeeContractByAccountID(employeeID);
        }

        /// <summary>
        /// �õ�Ա�����µĺ�ͬ��������ʾ���ں�ͬ
        /// </summary>
        public List<Contract> GetLastContractByAccountID(int employeeID)
        {
            List<Contract> contractListForReturn = new List<Contract>();
            List<Contract> contractList = _dalContract.GetEmployeeContractByAccountID(employeeID);
            foreach (Contract contract in contractList)
            {
                if (contract.EndDate.Date >= DateTime.Now.Date)
                {
                    contractListForReturn.Add(contract);
                }
            }
            return contractListForReturn;
        }
        /// <summary>
        /// ����������ȡԱ����ͬ
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="StratTimeFrom"></param>
        /// <param name="StratTimeTo"></param>
        /// <param name="EndTimeFrom"></param>
        /// <param name="EndTimeTo"></param>
        /// <param name="ContractTypeId"></param>
        /// <returns></returns>
        /// <param name="Operator"></param>
        public List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo, DateTime EndTimeFrom,
            DateTime EndTimeTo, int ContractTypeId, Account Operator)
        {
            List<Contract> contractList = new List<Contract>();
            List<Account> accountList = _IAccountBll.GetAccountByCondition(employeeName, null, null, null);
            accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, Operator, HrmisPowers.A402);
            foreach (Account account in accountList)
            {
                List<Contract> accountcontractList =
                    _dalContract.GetEmployeeContractByCondition(account.Id, StratTimeFrom, StratTimeTo, EndTimeFrom,
                                                                EndTimeTo, ContractTypeId);
                foreach (Contract contract in accountcontractList)
                {
                    contract.EmployeeID = account.Id;
                    contract.EmployeeName = account.Name;
                    contract.CompanyName =
                        new GetEmployee().GetEmployeeByAccountID(account.Id).EmployeeDetails.Work.Company.Name;
                }
                contractList.AddRange(accountcontractList);
            }
            return contractList;
        }
        /// <summary>
        /// ����Ա����ͬID��ȡ���������б�
        /// </summary>
        /// <param name="employeeContractID"></param>
        /// <returns></returns>
        public List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int employeeContractID)
        {
            return _dalContract.GetApplyAssessConditionByEmployeeContractID(employeeContractID);
        }
        /// <summary>
        /// ����PKID��ȡ��������
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public ApplyAssessCondition GetApplyAssessConditionByPKID(int pkid)
        {
            return _dalContract.GetApplyAssessConditionByPKID(pkid);
        }

        /// <summary>
        /// Ϊ��ͬ�������洴��List<EmployeeContractBookMark>
        /// </summary>
        public List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractTypeID(int ContractTypeId, int employeeID)
        {
            List<ContractBookMark> contractBookMark = _dalContractBookMark.GetContractBookMarkByContractTypeID(ContractTypeId);
            Employee employee =
                new GetEmployee(_dalEmployee, _IAccountBll, _dalEmployeeSkill, _IDepartmentBll, _EmployeeAdjustRuleDal).
                    GetEmployeeByAccountID(employeeID);
            if (contractBookMark != null && contractBookMark.Count > 0)
            {
                List<EmployeeContractBookMark> employeeContractBookMark = new List<EmployeeContractBookMark>();
                foreach (ContractBookMark mark in contractBookMark)
                {
                    employeeContractBookMark.Add(new EmployeeContractBookMark(0, 0, mark.BookMarkName, EmployeeContractBookMark.InitBookMarkValue(mark.BookMarkName, employee)));
                }
                return employeeContractBookMark;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ����Ա����ͬ���Ҷ�ӦԱ������ǩ����ǩֵ,Ȼ�����ʵ��ģ����ϣ���List<EmployeeContractBookMark>���س�����
        /// ��Ҫ��Ϊ��ֹģ��ĸ��£���������ʧ��
        /// </summary>
        public List<EmployeeContractBookMark> GetRealEmployeeContractBookMarkByContractID(int contractID)
        {
            Contract ct = _dalContract.GetEmployeeContractByContractId(contractID);
            if (ct == null)
            {
                return new List<EmployeeContractBookMark>();
            }
            List<ContractBookMark> contractBookMark = _dalContractBookMark.GetContractBookMarkByContractTypeID
            (ct.ContractType.ContractTypeID);

            List<EmployeeContractBookMark> employeeContractBookMarkList =
                _dalEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(contractID);

            if (contractBookMark != null && contractBookMark.Count > 0)
            {
                List<EmployeeContractBookMark> employeeContractBookMark = new List<EmployeeContractBookMark>();
                foreach (ContractBookMark mark in contractBookMark)
                {
                    employeeContractBookMark.Add(
                        new EmployeeContractBookMark(0, contractID, mark.BookMarkName,
                                                    GetBookMarkValue(mark.BookMarkName,
                                                                                        employeeContractBookMarkList)));
                }
                return employeeContractBookMark;
            }
            return null;
        }
        private static string GetBookMarkValue(string name, IEnumerable<EmployeeContractBookMark> employeeContractBookMarkList)
        {
            foreach (EmployeeContractBookMark mark in employeeContractBookMarkList)
            {
                if (mark.BookMarkName == name)
                {
                    return mark.BookMarkValue;
                }
            }
            return "";
        }

        /// <summary>
        /// ����������ȡԱ����ͬ
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="StratTimeFrom"></param>
        /// <param name="StratTimeTo"></param>
        /// <param name="EndTimeFrom"></param>
        /// <param name="EndTimeTo"></param>
        /// <param name="ContractTypeId"></param>
        /// <returns></returns>
        /// <param name="Operator"></param>
        /// <param name="employeeStatus">-1,ȫ����0����ְ��1����ְ</param>
        public List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo, DateTime EndTimeFrom,
            DateTime EndTimeTo, int ContractTypeId, Account Operator, int employeeStatus)
        {
            List<Contract> contractList = new List<Contract>();
            //List<Account> accountList = _IAccountBll.GetAccountByCondition(employeeName, null, null, null);
            //accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, Operator, HrmisPowers.A402);
            //List<Employee> employeeList = new GetEmployee().GetEmployeeAttendenceInfoByAccountList(accountList, EmployeeTypeEnum.All, employeeStatus);

            //foreach (Employee employee in employeeList)
            //{
            //    List<Contract> accountcontractList =
            //        _dalContract.GetEmployeeContractByCondition(employee.Account.Id, StratTimeFrom, StratTimeTo, EndTimeFrom,
            //                                                    EndTimeTo, ContractTypeId);
            //    foreach (Contract contract in accountcontractList)
            //    {
            //        contract.EmployeeID = employee.Account.Id;
            //        contract.EmployeeName = employee.Account.Name;
            //        contract.CompanyName = employee.EmployeeDetails.Work.Company.Name;
            //    }
            //    contractList.AddRange(accountcontractList);
            //}
            var list=EmployeeContractLogic.GetEmployeeContractByCondition(employeeName, StratTimeFrom, StratTimeTo, EndTimeFrom,
                                                                 EndTimeTo, ContractTypeId, Operator, employeeStatus);
            foreach (var e in list)
            {
                Contract contract=new Contract
                                      {
                                          ContractID = e.PKID,
                                          ContractType = new ContractType(e.ContractTypeID, e.ContractTypeName),
                                          EndDate = e.EndDate,
                                          StartDate = e.StartDate,
                                          EmployeeName = e.EmployeeName,
                                          EmployeeID = e.AccountID,
                                          CompanyName = e.CompanyName,
                                          Remark = e.Remark
                                      };
                contractList.Add(contract);
            }
            return contractList;
        }
    }
}
