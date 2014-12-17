using System;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SEP.Model.Accounts;
using SEP.Presenter.CalendarExt;

namespace SEP.Performance.Pages.SEP.CalendarExtPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CalendarExtHandler : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _ResponseString;
        private CalendarExtUIFacade _Facade;

        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            _Facade = new CalendarExtUIFacade();
            context.Response.ContentType = "text/plain";
            if (_Context.Request.Params["type"] != null)
            {
                switch (_Context.Request.Params["type"])
                {
                    case "GetCalendarADayList":
                        GetCalendarADayList();
                        break;
                    case "GetDayItems":
                        GetDayItems();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void GetCalendarADayList()
        {
            //Account account = HttpContext.Current.Session[SessionKeys.LOGININFO] as Account;
            //if (account == null)
            //{
            //    return;
            //}
            DateTime start = Convert.ToDateTime(_Context.Request.Params["start"]);
            DateTime end = Convert.ToDateTime(_Context.Request.Params["end"]);
            _ResponseString =
                string.Format("{{aDayList:{0},holidayList:{1}}}",
                              JsonConvert.SerializeObject(_Facade.GetCalendarADayList(_Context.Request.Params["name"], start, end, _Context.Request.Params["typeList"]),
                                                          new JavaScriptDateTimeConverter()),
                              JsonConvert.SerializeObject(_Facade.GetHolidayList(start, end),
                                                          new JavaScriptDateTimeConverter()));
        }

        private void GetDayItems()
        {
            Account account = HttpContext.Current.Session[SessionKeys.LOGININFO] as Account;
            if (account == null)
            {
                return;
            }
            DateTime start = Convert.ToDateTime(_Context.Request.Params["date"]);
            _ResponseString =
                string.Format("{{dayItems:{0}}}",
                              JsonConvert.SerializeObject(_Facade.GetDayItems(_Context.Request.Params["name"], start, _Context.Request.Params["typeList"]), new JavaScriptDateTimeConverter()));
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}