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
    /// �߼���ѯ
    /// ԭ�������ȷ������ݿ���س����е���Ϣ�������EmployeeDoSearch���ڴ��бȶ�
    /// ���ִ����������ݿ������ʹ���˽϶�ʱ�䣬��θĶ�������
    /// �ȼ�����Ҫ�ȶԵ���Ϣ��������EmployeeDoSearch������ɸѡ�˴������ݣ��ٷ������ݿ����ʣ����Ϣ
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
        /// ���캯��
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
            //��֤���ʽ�Ƿ���ȷ
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
        /// ���в�ѯ
        /// </summary>
        /// <returns></returns>
        public List<Employee> DoAdvanceSearchEmployee()
        {
            //��ʽ��ʼ��ѯɸѡ
            //���ػ�������
            List<Employee> employeeList = _dalEmployee.GetAllEmployeeInfo();
            if (employeeList == null)
            {
                return new List<Employee>();
            }

            //������Ҫ�Ƚϵ�����
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
            //ɸѡ֮�󣬼���ʣ��δ���ص�����
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
                    //����Ա��������Ϣ���ʺ���Ϣ
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
                    //����Ա��������Ϣ
                    case EmployeeFieldPara.EmployeeWelfarePart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeWelfare =
                                new GetEmployeeWelfare(_IEmployeeWelfareHistory, _IEmployeeWelfare).
                                    GetEmployeeWelfareByAccountID(
                                    employee.Account.Id);
                        }
                        break;
                    //����Ա��������Ϣ
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
                    //����Ա���Զ���������Ϣ
                    case EmployeeFieldPara.DiyProcessPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.DiyProcessList =
                                new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll).
                                    GetEmployeeDiyProcesses(employee.Account.Id);
                        }
                        break;
                    //����Ա�������Ϣ
                    case EmployeeFieldPara.VacationPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                            employee.EmployeeAttendance.Vacation =
                                new GetVacation().GetLastVacationByAccountID(employee.Account.Id);
                        }
                        break;
                    //����Ա��������Ϣ
                    case EmployeeFieldPara.AdjustPart:
                        foreach (Employee employee in employeeList)
                        {
                            employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                            employee.EmployeeAttendance.MonthAttendance = employee.EmployeeAttendance.MonthAttendance ?? new MonthAttendance();
                            employee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained =
                                 new GetAdjustRest().GetNowAdjustRestByAccountID(employee.Account.Id).SurplusHours;
                        }
                        break;
                    //����Ա��������Ϣ
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