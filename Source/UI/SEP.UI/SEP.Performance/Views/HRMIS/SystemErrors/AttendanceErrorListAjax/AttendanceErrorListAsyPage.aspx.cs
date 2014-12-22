using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.SystemErrors.AttendanceErrorListAjax
{
    public partial class AttendanceErrorListAsyPage : Page
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
                if (Valid(Request.Params["dtpScopeFrom"], Request.Params["dtpScopeTo"], errors))
                {
                    Account account = Session[SessionKeys.LOGININFO] as Account;
                    int DepartmentID = Convert.ToInt32(Request.Params["DepartmentID"]);
                    DateTime dtFromDate = Convert.ToDateTime(Request.Params["dtpScopeFrom"]);
                    DateTime dtToDate = Convert.ToDateTime(Request.Params["dtpScopeTo"]);
                    string EmployeeName = Request.Params["EmployeeName"];

                    List<SystemError> type =
                        InstanceFactory.CreateSystemErrorFacade().GetAttendanceError(EmployeeName, DepartmentID,
                                                                                     dtFromDate,
                                                                                     dtToDate, account,
                                                                                     HrmisPowers.A506);

                 
                    StringBuilder builder=new StringBuilder();
                    List<AttendanceSystemError> attendancelist=AttendanceSystemError.Turn(type);
                    foreach (AttendanceSystemError error in attendancelist)
                    {
                        string Tablehtml = string.IsNullOrEmpty(error.PlanDutyUrl) ? "" : "<a  href=\"#\" onclick='window.open(\"" + error.PlanDutyUrl + "\")' >排班表</a>";
                        builder.AppendFormat("<tr><td></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a  href=\"#\" onclick='window.open(\"{4}\")' >更正</a></td></tr>", error.Description, error.CompanyName, error.DepartmentName, Tablehtml, error.EditUrl);
                    }
                    List<HtmlModal> htmlmodal=new List<HtmlModal>();
                    htmlmodal.Add(new HtmlModal(builder.ToString()));
                    s = JsonConvert.SerializeObject(htmlmodal);
                }
            }
            catch (Exception ex)
            {
                errors.Add(new Error("AttendanceErrorMessage", ex.Message));
            }
            if (errors.Count > 0)
            {
                s = JsonConvert.SerializeObject(errors);
            }
            Response.Write(s);
            Response.End();
        }

        private static bool Valid(string fromdate, string todate, ICollection<Error> errors)
        {
            Error error = new Error("AttendancelblScopeMsg", "");
            bool ret = true;
            if (String.IsNullOrEmpty(fromdate) || String.IsNullOrEmpty(todate))
            {
                error.ErrorMessage = "时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtFromDate;
                DateTime dtToDate;
                if (
                    !(DateTime.TryParse(fromdate, out dtFromDate) && DateTime.TryParse(todate, out dtToDate)))
                {
                    error.ErrorMessage = "时间格式输入不正确";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtFromDate, dtToDate) > 0)
                    {
                        error.ErrorMessage = "开始时间不可晚于结束时间";
                        ret = false;
                    }
                }
            }
            if (!ret)
            {
                errors.Add(error);
            }
            return ret;
        }
    }


    public class AttendanceSystemError
    {
        private readonly SystemError _SystemError;

        public AttendanceSystemError(SystemError systemerror)
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
        public string PlanDutyUrl
        {
            get
            {
                string url = "";
                try
                {
                    url = " ../../HRMIS/AttendancePages/DetailPlanDuty.aspx?PlanDutyID=" + SecurityUtil.DECEncrypt(_SystemError.ErrorEmployee.EmployeeAttendance.PlanDutyTableList[0].PlanDutyTableID.ToString());
                }
                catch
                {
                }
                return url;
            }
        }
        public static List<AttendanceSystemError> Turn(List<SystemError> types)
        {
            List<AttendanceSystemError> list = new List<AttendanceSystemError>();
            foreach (SystemError t in types)
            {
                list.Add(new AttendanceSystemError(t));
            }
            return list;
        }
    }
}