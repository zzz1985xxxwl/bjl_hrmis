using System;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.DoorCardErrorListAjax
{
    public partial class DoorCardErrorListAsyPage : Page
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
                    case "ignoreDoorCardError":
                        IgnoreDoorCardError();
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
            string s;
            try
            {
                bool showIgnore = Convert.ToBoolean(Request.Params["ShowIgnore"]);
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<SystemError> type = InstanceFactory.CreateSystemErrorFacade().GetDoorCardError(showIgnore, account);
                s = JsonConvert.SerializeObject(DoorCardSystemError.Turn(type));
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("doorcardErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }

        private void IgnoreDoorCardError()
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
                error.Add(new Error("doorcardErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }
    }


    public class DoorCardSystemError
    {
        private readonly SystemError _SystemError;

        public DoorCardSystemError(SystemError systemerror)
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

        public static List<DoorCardSystemError> Turn(List<SystemError> types)
        {
            List<DoorCardSystemError> list = new List<DoorCardSystemError>();
            foreach (SystemError t in types)
            {
                list.Add(new DoorCardSystemError(t));
            }
            return list;
        }
    }
}