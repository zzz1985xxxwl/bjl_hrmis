using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.DiyProcessErrorListAjax
{
    public partial class DiyProcessErrorListAsyPage : Page
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
                    case "ignoreDiyProcessError":
                        IgnoreDiyProcessError();
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
                ErrorType errorType = ErrorType.GetErrorTypeByID(Convert.ToInt32(Request.Params["ErrorType"]));
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<SystemError> type = InstanceFactory.CreateSystemErrorFacade().GetDiyProcessError(showIgnore, errorType, account);
                StringBuilder builder = new StringBuilder();
                List<DiyProcessSystemError> DiyProcesslist = DiyProcessSystemError.Turn(type);
                foreach (DiyProcessSystemError error in DiyProcesslist)
                {
                    builder.AppendFormat("<tr><td></td><td>{0}</td><td>{1}</td><td>{2}</td><td><a  href=\"#\" onclick='window.open(\"{3}\")' >¸üÕý</a></td><td><a href=\"#\"  onclick='IgnoreDiyProcessError({4},{5},this)' >{6}</a></td></tr>", error.Description, error.CompanyName, error.DepartmentName, error.EditUrl,error.MarkID,error.ErrorTypeID,error.ErrorStatus);
                }
                List<HtmlModal> htmlmodal = new List<HtmlModal>();
                htmlmodal.Add(new HtmlModal(builder.ToString()));
                s = JsonConvert.SerializeObject(htmlmodal);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("DiyProcessErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }

        private void IgnoreDiyProcessError()
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
                error.Add(new Error("DiyProcessErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }
    }


    public class DiyProcessSystemError
    {
        private readonly SystemError _SystemError;

        public DiyProcessSystemError(SystemError systemerror)
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
            get { return _SystemError.ErrorStatus == global::SEP.HRMIS.Model.SystemError.ErrorStatus.ToHandle ? "ºöÂÔ" : "ÏÔÊ¾"; }
        }

        public string MarkID
        {
            get { return _SystemError.MarkID.ToString(); }
        }

        public string ErrorTypeID
        {
            get { return _SystemError.ErrorType.ID.ToString(); }
        }

        public static List<DiyProcessSystemError> Turn(List<SystemError> types)
        {
            List<DiyProcessSystemError> list = new List<DiyProcessSystemError>();
            foreach (SystemError t in types)
            {
                list.Add(new DiyProcessSystemError(t));
            }
            return list;
        }
    }
}