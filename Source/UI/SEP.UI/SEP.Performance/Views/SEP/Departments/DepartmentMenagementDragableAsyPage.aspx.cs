using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.Performance.Views.SEP.Departments
{
    public partial class DepartmentMenagementDragableAsyPage : Page
    {
        public IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private List<Department> DepartmentOrder;
        private Account _LoginUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            _LoginUser = Session[SessionKeys.LOGININFO] as Account;
            Response.ContentType = "text/plain";
            if (Request.Params["type"] != null)
            {
                switch (Request.Params["type"])
                {
                    case "search":
                        Serach();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "update":
                        Update();
                        break;
                    case "add":
                        Add();
                        break;
                    case "move":
                        Move();
                        break;
                    case "InitDepartment":
                        InitDepartment();
                        break;
                    case "GetDeptAndChildrenDeptByCurrAccount":
                        GetDeptAndChildrenDeptByAccountID(_LoginUser.Id);
                        break;
                    case "GetDeptAndChildrenDeptByAccountID":
                        int accountid = Convert.ToInt32(Request.Params["accountID"]);
                        GetDeptAndChildrenDeptByAccountID(accountid);
                        break;
                    case "GetAllDepartment":
                        GetAllDepartment();
                        break;
                    default:
                        break;
                }
            }
            Response.Write("");
            Response.End();
        }

        private void GetDeptAndChildrenDeptByAccountID(int accountid)
        {
            string result = String.Empty;


            IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
            List<Department> all = _IDepartmentBll.GetDepartmentAndChildrenDeptByLeaderID(accountid); 
            foreach (Department item in all)
            {
                result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
            }

            Response.Write(result);
            Response.End();
        }
        private void Serach()
        {
            string s = "";
            List<Error> errors = new List<Error>();
            try
            {
                DepartmentDataBind();
                s = JsonConvert.SerializeObject(DepartmentJson.TurnToDepartment(DepartmentOrder));
            }
            catch (Exception ex)
            {
                errors.Add(new Error("trMessage", ex.Message));
            }
            if (errors.Count > 0)
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }

        private void Delete()
        {
            try
            {
                if (CompanyConfig.HasHrmisSystem &&
                    InstanceFactory.CreateCompanyInvolveFacade().GetEmployeeBasicInfoByCompanyID(
                        Convert.ToInt32(Request.Params["DepartmentID"])).Count > 0)
                    throw new ApplicationException("该公司下存在员工，禁止删除！");
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DepartmentBll.DeleteDept(Convert.ToInt32(Request.Params["DepartmentID"]), _LoginUser);
                    IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                        InstanceFactory.CreateDepartmentHistoryFacade();
                    hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                    ts.Complete();
                }
                Response.Write("success");
            }
            catch (Exception ae)
            {
                Response.Write(ae.Message);
            }
            Response.End();
        }

        private void Update()
        {
            string s;
            List<Error> errors = new List<Error>();
            Valide(errors);
            if (errors.Count <= 0)
            {
                //数据收集过程
                Department theObject =
                    new Department(Convert.ToInt32(Request.Params["DepartmentID"]), Request.Params["DepartmentName"]);
                CompleteTheObject(theObject);
                //执行事务过程
                try
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        Department theOldObject =
                            _DepartmentBll.GetDepartmentById(Convert.ToInt32(Request.Params["DepartmentID"]), null);
                        _DepartmentBll.UpdateDept(theObject, _LoginUser);
                        if (CompanyConfig.HasHrmisSystem)
                        {
                            if (!theOldObject.IsEqual(theObject))
                            {
                                IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                                    InstanceFactory.CreateDepartmentHistoryFacade();
                                hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                            }
                            if (theOldObject.Name != theObject.Name)
                            {
                                IEmployeeHistoryFacade hrmisEmployeeHistoryFacade =
                                    InstanceFactory.CreateEmployeeHistoryFacade();
                                hrmisEmployeeHistoryFacade.AddEmployeeHistoryByDepartment(theObject, _LoginUser);
                            }
                        }
                        ts.Complete();
                    }
                    s = "[]";
                }
                catch (Exception ae)
                {
                    errors.Add(new Error("lblMessage", ae.Message));
                    s = JsonConvert.SerializeObject(errors);
                }
            }
            else
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }

        private void Add()
        {
            string s;
            List<Error> errors = new List<Error>();
            Valide(errors);
            if (errors.Count <= 0)
            {
                //数据收集过程
                Department theObject = new Department(0, "");
                CompleteTheObject(theObject);
                try
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        int departmentid =
                            _DepartmentBll.CreateDept(Convert.ToInt32(Request.Params["ParentDepartmentID"]), theObject,
                                                      _LoginUser);
                        if (CompanyConfig.HasHrmisSystem)
                        {
                            IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                                InstanceFactory.CreateDepartmentHistoryFacade();
                            hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                        }
                        ts.Complete();
                        s = "[{DepartmentID:" + departmentid + "}]";
                    }
                }
                catch (Exception e)
                {
                    errors.Add(new Error("lblMessage", e.Message));
                    s = JsonConvert.SerializeObject(errors);
                }
            }
            else
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }

        private void Move()
        {
            string s;
            List<Error> errors = new List<Error>();

            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    int parentDepid = Convert.ToInt32(Request.Params["ParentDepartmentID"]);
                    Department theOldObject =
                        _DepartmentBll.GetDepartmentById(Convert.ToInt32(Request.Params["DepartmentID"]), null);
                    if (parentDepid != theOldObject.Id)
                    {
                        _DepartmentBll.UpdateDept(parentDepid, theOldObject, _LoginUser);
                        if (CompanyConfig.HasHrmisSystem)
                        {
                            IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                                InstanceFactory.CreateDepartmentHistoryFacade();
                            hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);

                            IEmployeeHistoryFacade hrmisEmployeeHistoryFacade =
                                InstanceFactory.CreateEmployeeHistoryFacade();
                            hrmisEmployeeHistoryFacade.AddEmployeeHistoryByDepartment(theOldObject, _LoginUser);
                        }
                    }
                    ts.Complete();
                }
                s = "[]";
            }
            catch (Exception ae)
            {
                errors.Add(new Error("trMessage", ae.Message));
                s = JsonConvert.SerializeObject(errors);
            }

            Response.Write(s);
            Response.End();
        }

        private void DepartmentDataBind()
        {
            DepartmentOrder = new List<Department>();
            List<Department> itsSource =
                _DepartmentBll.GetAllDepartmentTree(_LoginUser);
            Order(itsSource, "node-");
            foreach (Department department in DepartmentOrder)
            {
                department.Members =
                    _AccountBll.GetAccountByCondition("", department.Id, null, null);
            }
            foreach (Department department in DepartmentOrder)
            {
                department.Leader = _AccountBll.GetAccountById(department.Leader.Id);
            }
        }

        private void Order(IEnumerable<Department> departmentList, string indexfromroot)
        {
            if (departmentList != null)
            {
                int i = 1;
                foreach (Department department in departmentList)
                {
                    department.IndexFromRoot = indexfromroot + "-" + i++;
                    DepartmentOrder.Add(department);
                    if (department.ChildDept.Count > 0)
                    {
                        Order(department.ChildDept, department.IndexFromRoot);
                    }
                }
            }
        }

        private void InitDepartment()
        {
            string s = "";
            List<Error> errors = new List<Error>();
            try
            {
                List<Department> departmentList = new List<Department>();
                departmentList.Add(
                    _DepartmentBll.GetDepartmentById(Convert.ToInt32(Request.Params["DepartmentID"]), _LoginUser));
                s = JsonConvert.SerializeObject(DepartmentJson.TurnToDepartment(departmentList));
            }
            catch (Exception ex)
            {
                errors.Add(new Error("trMessage", ex.Message));
            }
            if (errors.Count > 0)
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }

        private void Valide(ICollection<Error> errors)
        {
            DateTime temp;
            if (string.IsNullOrEmpty(Request.Params["DepartmentName"]))
            {
                errors.Add(new Error("lblDepNameMsg", "不能为空"));
            }
            if (string.IsNullOrEmpty(Request.Params["LeaderName"]))
            {
                errors.Add(new Error("lblLeaderNameMsg", "不能为空"));
            }
            if (!string.IsNullOrEmpty(Request.Params["FoundationTime"].Trim()) &&
                !DateTime.TryParse(Request.Params["FoundationTime"], out temp))
            {
                errors.Add(new Error("lblTimeError", "格式错误"));
            }
        }

        private void CompleteTheObject(Department theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                theObjectToComplete.Name = Request.Params["DepartmentName"];
                theObjectToComplete.Leader = new Account();
                theObjectToComplete.Leader.Name = Request.Params["LeaderName"];
                theObjectToComplete.Address = Request.Params["Address"];
                theObjectToComplete.Phone = Request.Params["Phone"];
                theObjectToComplete.Fax = Request.Params["Fax"];
                theObjectToComplete.Others = Request.Params["Others"];
                theObjectToComplete.Description = Request.Params["Description"];
                if (string.IsNullOrEmpty(Request.Params["FoundationTime"]))
                {
                    theObjectToComplete.FoundationTime = null;
                }
                else
                {
                    theObjectToComplete.FoundationTime = Convert.ToDateTime
                        (Request.Params["FoundationTime"]);
                }
            }
        }

        private void GetAllDepartment()
        {
            string result = String.Empty;


            IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
            List<Department> all = _IDepartmentBll.GetAllDepartmentOrderName();
            foreach (Department item in all)
            {
                result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
            }

            Response.Write(result);
            Response.End();
        }


        public class DepartmentJson
        {
            private readonly Department _Department;

            public DepartmentJson(Department department)
            {
                _Department = department;
            }


            public string Id
            {
                get { return _Department.IndexFromRoot; }
            }

            public string CssClass
            {
                get
                {
                    if(_Department.IndexFromRoot!=null)
                    {
                        string s = _Department.IndexFromRoot;
                        if (s.Substring(0, s.LastIndexOf('-')) == "node-")
                        {
                            return "";
                        }
                        else
                        {
                            return "child-of-" + s.Substring(0, s.LastIndexOf('-'));
                        }
                    }
                    return "";
                }
            }

            public string DepartmentName
            {
                get { return _Department.Name; }
            }

            public string CountEmployee
            {
                get { return _Department.CountEmployee.ToString(); }
            }

            public string DepartmentID
            {
                get { return _Department.Id.ToString(); }
            }

            public string DepartmentLeader
            {
                get { return _Department.Leader.Name; }
            }

            public string DepartmentMember
            {
                get
                {
                    if (_Department.Members == null)
                    {
                        return "";
                    }
                    string ret = "";
                    foreach (Account account in _Department.Members)
                    {
                        if (account.AccountType == VisibleType.None)
                        {
                            continue;
                        }
                        ret = ret + "<tr><td align='left' style='padding:0 0 0 8px;' width='30%'><span>" + account.Name +
                              "</span></td>" +
                              "<td align='left' style='padding:0;' width='70%'>" + account.Position.Name + "</td></tr>";
                    }
                    return ret;
                }
            }


            public string Address
            {
                get { return _Department.Address; }
            }

            public string Phone
            {
                get { return _Department.Phone; }
            }

            public string Fax
            {
                get { return _Department.Fax; }
            }

            public string Others
            {
                get { return _Department.Others; }
            }

            public string Description
            {
                get { return _Department.Description; }
            }

            public string FoundationTime
            {
                get
                {
                    if (_Department.FoundationTime != null)
                        return Convert.ToDateTime(_Department.FoundationTime).ToShortDateString();

                    return "";
                }
            }


            public static List<DepartmentJson> TurnToDepartment(List<Department> departmentlist)
            {
                List<DepartmentJson> list = new List<DepartmentJson>();
                foreach (Department t in departmentlist)
                {
                    list.Add(new DepartmentJson(t));
                }
                return list;
            }
        }
    }
}