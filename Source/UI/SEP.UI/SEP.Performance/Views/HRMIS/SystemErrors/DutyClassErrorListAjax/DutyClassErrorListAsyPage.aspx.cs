using System;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.DutyClassErrorListAjax
{
    public partial class DutyClassErrorListAsyPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["type"] != null)
            {
                switch (Request.Params["type"])
                {
                    case "search":
                        Serach();
                        break;
                    case "ignoreDutyClassError":
                        IgnoreDutyClassError();
                        break;
                    default:
                        break;
                }
            }
            Response.Write("");
            Response.End();
        }

        private void IgnoreDutyClassError()
        {
            string s = "[]";
            try
            {
                int markID = Convert.ToInt32(Request.Params["MarkID"]);
                int ErrorTypeID = Convert.ToInt32(Request.Params["ErrorTypeID"]);
                InstanceFactory.CreateSystemErrorFacade().UpdateErrorStatus(
                    new SystemError("", ErrorType.GetErrorTypeByID(ErrorTypeID), markID));
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("DutyClassErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }

        private void Serach()
        {
            string s;
            try
            {
                bool showIgnore = Convert.ToBoolean(Request.Params["ShowIgnore"]);
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<SystemError> type =
                    InstanceFactory.CreateSystemErrorFacade().GetDutyCalssError(showIgnore, account);
                s = JsonConvert.SerializeObject(DutyClassSystemError.Turn(type));
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("DutyClassErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }
    }


    public class DutyClassSystemError
    {
        private readonly SystemError _SystemError;

        public DutyClassSystemError(SystemError systemerror)
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
            get { return _SystemError.ErrorEmployee.EmployeeDetails.Work.Company.Name; }
        }

        public string DepartmentName
        {
            get { return _SystemError.ErrorEmployee.Account.Dept.Name; }
        }

        public string EditUrl
        {
            get { return _SystemError.EditUrl; }
        }

        public string ErrorStatus
        {
            get { return _SystemError.ErrorStatus == global::SEP.HRMIS.Model.SystemError.ErrorStatus.ToHandle ? "∫ˆ¬‘" : "œ‘ æ"; }
        }

        public string MarkID
        {
            get { return _SystemError.MarkID.ToString(); }
        }

        public string ErrorTypeID
        {
            get { return _SystemError.ErrorType.ID.ToString(); }
        }

        public static List<DutyClassSystemError> Turn(List<SystemError> types)
        {
            List<DutyClassSystemError> list = new List<DutyClassSystemError>();
            foreach (SystemError t in types)
            {
                list.Add(new DutyClassSystemError(t));
            }
            return list;
        }
    }
}