using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.EmployeeContractErrorListAjax
{
    public partial class EmployeeContractErrorListAsyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            if (Request.Params["type"] != null)
            {
                switch (Request.Params["type"])
                {
                    case "search":
                        Serach();
                        break;
                    default:
                        break;
                }
            }
            Response.Write("");
            Response.End();
        }

        private void Serach()
        {
            string s = "";
            List<Error> errors = new List<Error>();
            try
            {
                Account account = Session[SessionKeys.LOGININFO] as Account;
                int DepartmentID = Convert.ToInt32(Request.Params["DepartmentID"]);
                string EmployeeName = Request.Params["EmployeeName"];

                List<SystemError> type =
                    InstanceFactory.CreateSystemErrorFacade().GetEmployeeContractError(EmployeeName, DepartmentID,
                                                                                       DateTime.Now.Date, account,
                                                                                       HrmisPowers.A402);


                List<EmployeeContractError> employeeContractErrorList = EmployeeContractError.Turn(type);
                s = JsonConvert.SerializeObject(employeeContractErrorList);
            }
            catch (Exception ex)
            {
                errors.Add(new Error("EmployeeContractErrorMessage", ex.Message));
            }
            if (errors.Count > 0)
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }
    }


    public class EmployeeContractError
    {
        private readonly SystemError _SystemError;

        public EmployeeContractError(SystemError systemerror)
        {
            _SystemError = systemerror;
        }

        public string PKID
        {
            get { return _SystemError.PKID.ToString(); }
        }

        public string Description
        {
            get { return _SystemError.Description; }
        }

        public string CompanyName
        {
            get {
                return
                    _SystemError.ErrorEmployee != null && _SystemError.ErrorEmployee.EmployeeDetails != null &&
                    _SystemError.ErrorEmployee.EmployeeDetails.Work != null &&
                    _SystemError.ErrorEmployee.EmployeeDetails.Work.Company != null &&
                    _SystemError.ErrorEmployee.EmployeeDetails.Work != null &&
                    _SystemError.ErrorEmployee.EmployeeDetails.Work.Company.Name != null
                        ? _SystemError.ErrorEmployee.EmployeeDetails.Work.Company.Name
                        : ""; }
        }

        public string DepartmentName
        {
            get { return _SystemError.ErrorEmployee.Account.Dept.Name; }
        }

        public string EditUrl
        {
            get { return _SystemError.EditUrl; }
        }
        public static List<EmployeeContractError> Turn(List<SystemError> types)
        {
            List<EmployeeContractError> list = new List<EmployeeContractError>();
            foreach (SystemError t in types)
            {
                list.Add(new EmployeeContractError(t));
            }
            return list;
        }
    }
}