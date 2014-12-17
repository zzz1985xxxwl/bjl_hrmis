using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AdvanceSearch
{
    /// <summary>
    /// 高级查询合同
    /// </summary>
    public class AdvanceSearchContract
    {
        private static readonly IContract _dalContract = DalFactory.DataAccess.CreateContract();
        private static readonly GetEmployee _GetEmployee = new GetEmployee();
        private readonly Account _OperationAccount;

        private readonly List<SearchField> _SearchFieldList;
        private List<SearchField> _ContractBasicInfoSearchFieldList;
        private List<SearchField> _EmployeeBasicInfoSearchFieldList;
        private List<SearchField> _VacationSearchFieldList;
        private List<SearchField> _AdjustSearchFieldList;
        ContractDoSearch _ContractDoSearch;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <param name="operatorAccount"></param>
        public AdvanceSearchContract(List<SearchField> searchFieldList, Account operatorAccount)
        {
            _OperationAccount = operatorAccount;
            _SearchFieldList = searchFieldList;
            CheckSearchFieldListValid();
            Init_PartSearchFieldList();
            ContractFieldPara.DepartmentTreeDataSource = null;
        }

        private void CheckSearchFieldListValid()
        {
            //验证表达式是否正确
            _ContractDoSearch = new ContractDoSearch(new List<Contract>(), _SearchFieldList);
            _ContractDoSearch.DoSearchExecute();
        }

        private void Init_PartSearchFieldList()
        {
            _ContractBasicInfoSearchFieldList =
                ContractFieldPara.GetPartSearchFieldList(_SearchFieldList, ContractFieldPara.ContractBasicInfoPart);
            _EmployeeBasicInfoSearchFieldList =
                ContractFieldPara.GetPartSearchFieldList(_SearchFieldList, ContractFieldPara.EmployeeBasicInfoPart);
            _VacationSearchFieldList =
                ContractFieldPara.GetPartSearchFieldList(_SearchFieldList, ContractFieldPara.VacationPart);
            _AdjustSearchFieldList =
                ContractFieldPara.GetPartSearchFieldList(_SearchFieldList, ContractFieldPara.AdjustPart);
        }
        /// <summary>
        /// 进行查询
        /// </summary>
        /// <returns></returns>
        public List<Contract> DoAdvanceSearchContract()
        {
            //正式开始查询筛选
            //加载基本数据
            List<Contract> contractList = _dalContract.GetAllEmployeeContract();
            if (contractList == null)
            {
                return new List<Contract>();
            }
            //筛选比较ContractBasicInfoPart的数据
            contractList = LoadAndCompareAllContractInfo(contractList, _ContractBasicInfoSearchFieldList, false,
                                                         ContractFieldPara.ContractBasicInfoPart);
            for (int i = 0; i < contractList.Count; i++)
            {
                contractList[i].Employee = _GetEmployee.GetEmployeeByAccountID(contractList[i].EmployeeID);
                if (contractList[i].Employee == null)
                {
                    contractList.RemoveAt(i);
                    i--;
                }
                if (contractList[i].Employee != null && contractList[i].Employee.EmployeeDetails != null)
                {
                    contractList[i].Employee.EmployeeDetails.Photo = null;
                }
            }
            contractList =
                HrmisUtility.RemoteUnAuthContract(contractList, AuthType.HRMIS, _OperationAccount,
                                                  HrmisPowers.A402);
            //筛选比较EmployeeBasicInfoPart数据
            contractList = LoadAndCompareAllContractInfo(contractList, _EmployeeBasicInfoSearchFieldList, false,
                                                         ContractFieldPara.EmployeeBasicInfoPart);

            //加载需要比较的数据
            contractList = LoadAndCompareAllContractInfo(contractList, _VacationSearchFieldList, false,
                                                         ContractFieldPara.VacationPart);
            contractList = LoadAndCompareAllContractInfo(contractList, _AdjustSearchFieldList, false,
                                                         ContractFieldPara.AdjustPart);
            //筛选之后，加载剩余未加载的数据
            contractList = LoadAndCompareAllContractInfo(contractList, _VacationSearchFieldList, true,
                                                         ContractFieldPara.VacationPart);
            contractList = LoadAndCompareAllContractInfo(contractList, _AdjustSearchFieldList, true,
                                                         ContractFieldPara.AdjustPart);
            return contractList;
        }

        private List<Contract> LoadAndCompareAllContractInfo(List<Contract> contractList,
            List<SearchField> otherSearchFieldList, bool isSearched, string partConst)
        {
            if ((otherSearchFieldList.Count > 0 && !isSearched)
                || (otherSearchFieldList.Count == 0 && isSearched))
            {
                switch (partConst)
                {
                    //加载员工年假信息
                    case ContractFieldPara.VacationPart:
                        foreach (Contract Contract in contractList)
                        {
                            if (Contract.Employee == null)
                            {
                                continue;
                            }
                            Contract.Employee.EmployeeAttendance = Contract.Employee.EmployeeAttendance ??
                                                                   new EmployeeAttendance();
                            Contract.Employee.EmployeeAttendance.Vacation =
                                new GetVacation().GetLastVacationByAccountID(Contract.Employee.Account.Id);
                        }
                        break;
                    //加载员工调休信息
                    case ContractFieldPara.AdjustPart:
                        foreach (Contract Contract in contractList)
                        {
                            if (Contract.Employee == null)
                            {
                                continue;
                            }
                            Contract.Employee.EmployeeAttendance = Contract.Employee.EmployeeAttendance ?? new EmployeeAttendance();
                            Contract.Employee.EmployeeAttendance.MonthAttendance =
                                Contract.Employee.EmployeeAttendance.MonthAttendance ?? new MonthAttendance();
                            Contract.Employee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained =
                                 new GetAdjustRest().GetNowAdjustRestByAccountID(Contract.Employee.Account.Id).SurplusHours;
                        }
                        break;
                    default:
                        break;
                }
                if (!isSearched)
                {
                    _ContractDoSearch = new ContractDoSearch(contractList, otherSearchFieldList);
                    _ContractDoSearch.DoSearchExecute();
                    contractList = _ContractDoSearch.ContractList;
                }
            }
            return contractList;
        }
    }

}
