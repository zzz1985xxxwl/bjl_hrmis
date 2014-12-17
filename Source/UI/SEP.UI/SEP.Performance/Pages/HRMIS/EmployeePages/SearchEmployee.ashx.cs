using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Utility;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.EmployeePages
{
    /// <summary>
    /// SearchEmployee 的摘要说明
    /// </summary>
    public class SearchEmployee : IHttpHandler,IRequiresSessionState
    {
        private HttpContext _Context;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private string _ResponseString;
        private Account _Operator;
        private int? intAgeFrom = null, intAgeTo = null;

        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            context.Response.ContentType = "text/plain";
            _Operator = _Context.Session[SessionKeys.LOGININFO] as Account;

            if (context.Request.Params["type"] != null)
            {
                switch (context.Request.Params["type"])
                {
                    case "Search":
                        Search(context.Request.Params);
                        break;
                    case "Init":
                        Init();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();
        }
        private void Init()
        {
            List<ControlError> errors = new List<ControlError>();
            ParametersModel parametersModel = new ParametersModel();
            try
            {
                #region positon

                List<Position> positions = _IPositionBll.GetAllPosition();
                parametersModel.PossitionList = new List<ParameterModel>();
                parametersModel.PossitionList.Add(new ParameterModel() {PKID = "-1", Name = ""});
                parametersModel.PossitionList.AddRange(positions.Select(x => new ParameterModel
                                                                                 {
                                                                                     PKID = x.Id.ToString(),
                                                                                     Name = x.Name
                                                                                 }).ToList());

                #endregion

                #region department

                List<Department> deptList =
                    Tools.RemoteUnAuthDeparetment(_IDepartmentBll.GetAllDepartment(), AuthType.HRMIS, _Operator,
                                                  HrmisPowers.A401);
                if (!Tools.IsDeptListContainsDept(deptList, _Operator.Dept))
                {
                    deptList.Add(_Operator.Dept);
                }
                List<Department> departmentList = _IDepartmentBll.GenerateDeptListWithLittleParentDept(deptList);
                parametersModel.DepartmentList = new List<ParameterModel>();
                if (Powers.HasAuth(_Operator.Auths, AuthType.HRMIS, HrmisPowers.A401))
                {
                    parametersModel.DepartmentList.Add(new ParameterModel() { PKID = "-1", Name = "" });
                }
                parametersModel.DepartmentList.AddRange(departmentList.Select(x => new ParameterModel
                                                                                       {
                                                                                           PKID = x.Id.ToString(),
                                                                                           Name = x.Name
                                                                                       }).ToList());

                #endregion

                #region type
                Dictionary<string, string> employeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
                parametersModel.EmployeeTypeList = new List<ParameterModel>();
                parametersModel.EmployeeTypeList.Add(new ParameterModel() {PKID = "-1", Name = ""});
                parametersModel.EmployeeTypeList.AddRange(employeeTypeSource.Select(x => new ParameterModel
                                                                                             {
                                                                                                 PKID = x.Key,
                                                                                                 Name = x.Value
                                                                                             }).ToList());

                #endregion

                #region GradesType
                List<GradesType> gradesTypes = GradesType.GetAll();
                parametersModel.GradesTypeList = new List<ParameterModel>();
                parametersModel.GradesTypeList.Add(new ParameterModel() { PKID = "-1", Name = "" });
                parametersModel.GradesTypeList.AddRange(gradesTypes.Select(x => new ParameterModel
                {
                    PKID = x.ID.ToString(),
                    Name = x.Name
                }).ToList());

                #endregion
            }
            catch (Exception ex)
            {
                errors.Add(new ControlError("lblMessage", ex.Message));
            }
            _ResponseString = PageUtility.FomartItemString(parametersModel, errors);
        }
        private void Search(NameValueCollection parameters)
        {
            List<ControlError> errors = new List<ControlError>();
            List<EmployeeModel> EmployeeModelList = new List<EmployeeModel>();
            string EmployeeName = parameters["EmployeeName"];
            int employeeType = Convert.ToInt32(parameters["employeeType"]);
            int positionID = Convert.ToInt32(parameters["positionID"]);
            int departmentID = Convert.ToInt32(parameters["departmentID"]);
            int? gradesID  = Convert.ToInt32(parameters["gradesID"]);
            if (gradesID < 0)
            {
                gradesID = null;
            }
            int EmployeeStatusId = Convert.ToInt32(parameters["EmployeeStatusId"]);
            string recursionDepartment = parameters["recursionDepartment"];
            string ageFrom = parameters["ageFrom"];
            string ageTo = parameters["ageTo"];
            try
            {
                ValidateAge(ageFrom, ageTo);
                EmployeeTypeEnum _employeeType =
                           EmployeeTypeUtility.GetEmployeeTypeByID(employeeType); 
                List<Employee> _EmployeeList = _IEmployeeFacade.GetEmployeeBasicInfoByBasicConditionWithCompanyAge(
                    EmployeeName,
                    _employeeType, positionID, gradesID, departmentID, intAgeFrom, intAgeTo, recursionDepartment=="true",
                    EmployeeStatusId);
                _EmployeeList =
                    HrmisUtility.RemoteUnAuthEmployee(_EmployeeList, AuthType.HRMIS, _Operator, HrmisPowers.A401);
                List<Employee> employees = new List<Employee>();
                foreach (Employee emplyee in _EmployeeList)
                {
                    //根据所属公司id，得到所属公司名称
                    var temp = emplyee;
                    if (temp.EmployeeDetails == null || temp.EmployeeDetails.Work == null ||
                        temp.EmployeeDetails.Work.Company == null)
                    {
                    }
                    else
                    {
                        //todo noted by wsl transfer waiting for modify
                        temp.EmployeeDetails.Work.Company =
                            _IDepartmentBll.GetDepartmentById(
                                temp.EmployeeDetails.Work.Company.Id, new Account());
                    }
                    temp.EmployeeDetails = temp.EmployeeDetails ?? new EmployeeDetails();
                    temp.EmployeeDetails.Work = temp.EmployeeDetails.Work ?? new Work();
                    temp.EmployeeDetails.Work.Company = temp.EmployeeDetails.Work.Company ??
                                                        new Department();
                    employees.Add(temp);
                }
                //列表中没有查出当前员工的信息时，满足一下两个条件的任何一个，再次加载当前员工的信息
                //1.所选部门是当前员工的部门
                //2.所选部门包含当前员工的部门
                //如现实数据中王莎莉登录，无任何权限，只可看自己的信息
                if (_Operator.Name.Contains(EmployeeName)
                    && !HrmisUtility.IsEmployeeListContainEmployee(employees, _Operator.Id))
                {
                    if (departmentID == -1)
                    {
                        GetCurrEmployee(employees,employeeType, positionID, gradesID, departmentID);
                    }
                    else if (departmentID != _Operator.Dept.Id)
                    {
                        Department selectedDept =
                            _IDepartmentBll.GetDepartmentById(departmentID, null);
                        if (selectedDept.IsExistDept(_Operator.Dept.Id))
                        {
                            GetCurrEmployee(employees, employeeType, positionID, gradesID, departmentID);
                        }
                    }
                    else
                    {
                        GetCurrEmployee(employees, employeeType, positionID, gradesID, departmentID);
                    }
                }
                EmployeeModelList = employees.Select(x => new EmployeeModel
                                                              {
                                                                  PKID = x.Account.Id,
                                                                  EmployeeName = "<div class='info' pkid='" + SecurityUtil.DECEncrypt(x.Account.Id.ToString()) + "'>" + x.Account.Name + "</div>",
                                                                  EmployeeType = EmployeeTypeUtility.EmployeeTypeDisplay(x.EmployeeType),
                                                                  Department = x.Account.Dept.Name,
                                                                  Company = x.EmployeeDetails.Work.Company.Name,
                                                                  Position = x.Account.Position.Name,
                                                                  WorkTime =
                                                                      x.EmployeeDetails.Work.ComeDate.ToString("yyyy-MM-dd")

                                                              }).ToList();
            }
            catch (Exception ex)
            {
                errors.Add(new ControlError("lblMessage", ex.Message));
            }
            _ResponseString = PageUtility.FomartSearchString(EmployeeModelList, errors);
        }
        private void ValidateAge(string from ,string to)
        {
            int age;
            if (String.IsNullOrEmpty(from.Trim()))
            {
                intAgeFrom = null;
            }
            else if (!int.TryParse(from.Trim(), out age))
            {
                throw new Exception("司龄范围请输入正整数");
            }
            else
            {
                if (age < 0)
                {
                    throw new Exception("司龄范围请输入正整数");
                }
                intAgeFrom = 365 * age;
            }


            if (String.IsNullOrEmpty(to.Trim()))
            {
                intAgeTo = null;
            }
            else if (!int.TryParse(to.Trim(), out age))
            {
                throw new Exception("司龄范围请输入正整数");
            }
            else
            {
                if (age < 0)
                {
                    throw new Exception("司龄范围请输入正整数");
                }
                //转换年成天查询
                intAgeTo = 365 * age;
            }
            if (intAgeTo!=null && intAgeFrom!=null &&
                intAgeTo == intAgeFrom)//如果查询条件相同，则把结束的查询条件转成下一年，以便查一年以内的人员
            {
                intAgeTo = intAgeTo + 364;
            }
        }
        private void GetCurrEmployee(List<Employee> employees,int employeeType,int positionID,int? gradesID,int departmentID)
        {
            Employee currEmployee = _IEmployeeFacade.GetEmployeeByAccountID(_Operator.Id);
            if (currEmployee != null)
            {
                if ((employeeType == -1 || (int)currEmployee.EmployeeType == employeeType) &&
                    (positionID == -1 || (int)currEmployee.Account.Position.Id == positionID) &&
                    (departmentID == -1 || (int)currEmployee.Account.Dept.Id == departmentID) &&
                    (gradesID == null || currEmployee.Account.GradesID == gradesID) 
                    )
                {
                    employees.Add(currEmployee);
                }
            }
        }
        private class EmployeeModel
        {
            public int PKID;
            public string EmployeeName;
            public string EmployeeType;
            public string Department;
            public string Company;
            public string Position;
            public string WorkTime;
        }
        private class ParametersModel
        {
            public List<ParameterModel> PossitionList;
            public List<ParameterModel> EmployeeTypeList;
            public List<ParameterModel> DepartmentList;
            public List<ParameterModel> GradesTypeList;
        }
        private class ParameterModel
        {
            public string PKID;
            public string Name;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class PageUtility
    {
        public static string FomartSearchString<T>(List<T> itemList, List<ControlError> errorList)
        {
            return
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(itemList),
                              JsonConvert.SerializeObject(errorList));
        }

        public static string FomartItemString<T>(T item, List<ControlError> errorList)
        {
            return
                string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(item, new JavaScriptDateTimeConverter()),
                              JsonConvert.SerializeObject(errorList));
        }

    }
}