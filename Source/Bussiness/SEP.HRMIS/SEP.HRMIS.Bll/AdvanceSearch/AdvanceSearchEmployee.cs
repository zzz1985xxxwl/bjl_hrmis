using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AdvanceSearch
{
    /// <summary>
    /// 高级查询
    /// 原本做法先访问数据库加载出所有的信息，后调用EmployeeDoSearch在内存中比对
    /// 发现此做法在数据库访问中使用了较多时间，因次改动方法，
    /// 先加载需要比对的信息，而后在EmployeeDoSearch结束后筛选了大量数据，再访问数据库加载剩余信息
    /// </summary>
    public class AdvanceSearchEmployee
    {
        private static readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static readonly IDiyProcessDal _IDiyProcessDal = new DiyProcessDal();
        private static readonly IEmployeeDiyProcessDal _IEmployeeDiyProcessDal = new EmployeeDiyProcessDal();
        private static readonly IEmployee _dalEmployee = new EmployeeDal();
        private static readonly IEmployeeSkill _dalEmployeeSkill = new EmployeeSkillDal();
        private static readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private static readonly IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private static readonly IEmployeeWelfare _IEmployeeWelfare = new EmployeeWelfareDal();
        private static readonly IEmployeeWelfareHistory _IEmployeeWelfareHistory = new EmployeeWelfareHistoryDal();
        private readonly Account _OperationAccount;
        private readonly List<SearchField> _SearchFieldList;
        private List<SearchField> _EmployeeBasicInfoSearchFieldList;
        private List<SearchField> _VacationSearchFieldList;
        private List<SearchField> _AdjustSearchFieldList;
        private List<SearchField> _EmployeeWelfareSearchFieldList;
        private List<SearchField> _CountryNationalitySearchFieldList;
        private List<SearchField> _DiyProcessSearchFieldList;
        private List<SearchField> _SkillFieldList;
        EmployeeDoSearch _EmployeeDoSearch;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <param name="operatorAccount"></param>
        public AdvanceSearchEmployee(List<SearchField> searchFieldList, Account operatorAccount)
        {
            _OperationAccount = operatorAccount;
            _SearchFieldList = searchFieldList;
            CheckSearchFieldListValid();
            Init_PartSearchFieldList();
            EmployeeFieldPara.DepartmentTreeDataSource = null;
        }

        private void CheckSearchFieldListValid()
        {
            //验证表达式是否正确
            _EmployeeDoSearch = new EmployeeDoSearch(new List<Employee>(), _SearchFieldList);
            _EmployeeDoSearch.DoSearchExecute();
        }

        private void Init_PartSearchFieldList()
        {
            _EmployeeBasicInfoSearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.EmployeeBasicInfoPart);
            _EmployeeWelfareSearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.EmployeeWelfarePart);
            _CountryNationalitySearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.CountryNationalityPart);
            _DiyProcessSearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.DiyProcessPart);
            _VacationSearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.VacationPart);
            _AdjustSearchFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.AdjustPart);
            _SkillFieldList =
                EmployeeFieldPara.GetPartSearchFieldList(_SearchFieldList, EmployeeFieldPara.SkillPart);
        }
        /// <summary>
        /// 进行查询
        /// </summary>
        /// <returns></returns>
        public List<Employee> DoAdvanceSearchEmployee()
        {
            //正式开始查询筛选
            //加载基本数据
            List<Employee> employeeList = _dalEmployee.GetAllEmployeeInfo();
            if (employeeList == null)
            {
                return new List<Employee>();
            }

            //加载需要比较的数据
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _EmployeeBasicInfoSearchFieldList, false,
                                                         EmployeeFieldPara.EmployeeBasicInfoPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _EmployeeWelfareSearchFieldList, false,
                                                         EmployeeFieldPara.EmployeeWelfarePart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _CountryNationalitySearchFieldList, false,
                                                         EmployeeFieldPara.CountryNationalityPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _VacationSearchFieldList, false,
                                                         EmployeeFieldPara.VacationPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _AdjustSearchFieldList, false,
                                                         EmployeeFieldPara.AdjustPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _SkillFieldList, false,
                                                         EmployeeFieldPara.SkillPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _DiyProcessSearchFieldList, false,
                                                         EmployeeFieldPara.DiyProcessPart);
            //筛选之后，加载剩余未加载的数据
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _EmployeeBasicInfoSearchFieldList, true,
                                                         EmployeeFieldPara.EmployeeBasicInfoPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _EmployeeWelfareSearchFieldList, true,
                                                         EmployeeFieldPara.EmployeeWelfarePart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _CountryNationalitySearchFieldList, true,
                                                         EmployeeFieldPara.CountryNationalityPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _VacationSearchFieldList, true,
                                                         EmployeeFieldPara.VacationPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _AdjustSearchFieldList, true,
                                                         EmployeeFieldPara.AdjustPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _SkillFieldList, true,
                                                         EmployeeFieldPara.SkillPart);
            employeeList = LoadAndCompareAllEmployeeInfo(employeeList, _DiyProcessSearchFieldList, true,
                                                         EmployeeFieldPara.DiyProcessPart);
            return employeeList;
        }

        private List<Employee> LoadAndCompareAllEmployeeInfo(List<Employee> employeeList, 
            List<SearchField> otherSearchFieldList, bool isSearched, string partConst)
        {
            if ((otherSearchFieldList.Count > 0 && !isSearched)
                || (otherSearchFieldList.Count == 0 && isSearched))
            {
                switch (partConst)
                {
                    //加载员工基本信息，帐号信息
                    case EmployeeFieldPara.EmployeeBasicInfoPart:
                        foreach (Employee employee in employeeList)
                        {
                            if (employee.EmployeeDetails != null)
                            {
                                employee.EmployeeDetails.Photo = null;
                            }
                            LoadSEPInfo.SetEmployeeAccountInfo(employee.Account.Id, employee, _IAccountBll,
                                                               _IDepartmentBll, _IPositionBll);
                            if (employee.EmployeeDetails != null
                                && employee.EmployeeDetails.Work != null
                                && employee.EmployeeDetails.Work.Company != null
                                && employee.EmployeeDetails.Work.Company.Name != null
                                && employee.EmployeeDetails.Work.Company.Name == "")
                            {
                                employee.EmployeeDetails.Work.Company =
                                    _IDepartmentBll.GetDepartmentById(employee.EmployeeDetails.Work.Company.Id, null);
                            }
                        }
                        employeeList =
                            HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, _OperationAccount,
                                                              HrmisPowers.A401);
                        break;
                    //加载员工福利信息
                    case EmployeeFieldPara.EmployeeWelfarePart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeWelfare =
                                new GetEmployeeWelfare(_IEmployeeWelfareHistory, _IEmployeeWelfare).
                                    GetEmployeeWelfareByAccountID(
                                    employee.Account.Id);
                        }
                        break;
                    //加载员工国籍信息
                    case EmployeeFieldPara.CountryNationalityPart:
                        foreach (Employee employee in employeeList)
                        {
                            if (employee.EmployeeDetails != null && employee.EmployeeDetails.CountryNationality != null)
                            {
                                employee.EmployeeDetails.CountryNationality =
                                    new GetNationality().GetNationalityByPkid(
                                        employee.EmployeeDetails.CountryNationality.ParameterID);
                            }
                        }
                        break;
                    //加载员工自定义流程信息
                    case EmployeeFieldPara.DiyProcessPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.DiyProcessList =
                                new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll).
                                    GetEmployeeDiyProcesses(employee.Account.Id);
                        }
                        break;
                    //加载员工年假信息
                    case EmployeeFieldPara.VacationPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                            employee.EmployeeAttendance.Vacation =
                                new GetVacation().GetLastVacationByAccountID(employee.Account.Id);
                        }
                        break;
                    //加载员工调休信息
                    case EmployeeFieldPara.AdjustPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                            employee.EmployeeAttendance.MonthAttendance = employee.EmployeeAttendance.MonthAttendance ?? new MonthAttendance();
                            employee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained =
                                 new GetAdjustRest().GetNowAdjustRestByAccountID(employee.Account.Id).SurplusHours;
                        }
                        break;
                    //加载员工技能信息
                    case EmployeeFieldPara.SkillPart:
                        foreach (Employee employee in employeeList)
                        {
                            try
                            {
                                employee.EmployeeSkills =
                                    _dalEmployeeSkill.GetEmployeeSkillByAccountID(employee.Account.Id
                                                                                  , "", -1,
                                                                                  SkillLevelEnum.All).EmployeeSkills;
                            }
                            catch
                            {
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (!isSearched)
                {
                    _EmployeeDoSearch = new EmployeeDoSearch(employeeList, otherSearchFieldList);
                    _EmployeeDoSearch.DoSearchExecute();
                    employeeList = _EmployeeDoSearch.EmployeeList;
                }
            }
            return employeeList;
        }
    }
}