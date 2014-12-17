using System;
using System.Collections.Generic;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.SystemError;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.SystemErrors.PhoneMessageErrorListAjax
{
    public partial class PhoneMessageErrorListAsyPage : Page
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
                    case "finishPhoneMessageByPKID":
                        FinishPhoneMessageByPKID();
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
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<SystemError> SystemErrors =
                    InstanceFactory.CreateSystemErrorFacade().GetPhoneMessageByCondition(
                        Request.Params["EmployeeName"], (PhoneMessageStatus) Convert.ToInt32(Request.Params["Status"]),account);
                List<PhoneMessageSystemError> PhoneMessagelist =
                    PhoneMessageSystemError.Turn(SystemErrors,
                                                 (PhoneMessageStatus) Convert.ToInt32(Request.Params["Status"]));
                s = JsonConvert.SerializeObject(PhoneMessagelist);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("PhoneMessageErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }

        private void FinishPhoneMessageByPKID()
        {
            string s = "[]";
            try
            {
                int PKID = Convert.ToInt32(Request.Params["PKID"]);
                InstanceFactory.CreatePhoneMessageFacade().FinishPhoneMessageByPKID(PKID);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                error.Add(new Error("PhoneMessageErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }
    }


    public class PhoneMessageSystemError
    {
        private readonly SystemError _SystemError;
        private readonly PhoneMessageStatus _Status;

        public PhoneMessageSystemError(SystemError systemerror, PhoneMessageStatus status)
        {
            _SystemError = systemerror;
            _Status = status;
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

        public string EmployeeName
        {
            get { return _SystemError.ErrorEmployee.Account.Name; }
        }

        public string Finish
        {
            get
            {
                if (_Status != PhoneMessageStatus.End && _Status != PhoneMessageStatus.All)
                {
                    return "<a href=\"#\"  onclick='FinishPhoneMessageByPKID(" + PKID + ")' >È¡Ïû·¢ËÍ</a>";
                }
                else
                {
                    return "";
                }
            }
        }

        public static List<PhoneMessageSystemError> Turn(List<SystemError> types, PhoneMessageStatus status)
        {
            List<PhoneMessageSystemError> list = new List<PhoneMessageSystemError>();
            foreach (SystemError t in types)
            {
                list.Add(new PhoneMessageSystemError(t, status));
            }
            return list;
        }
    }
}