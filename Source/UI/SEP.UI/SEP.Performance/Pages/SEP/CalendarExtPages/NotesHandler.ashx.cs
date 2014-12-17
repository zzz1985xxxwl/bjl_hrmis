using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Newtonsoft.Json;
using SEP.Model.Accounts;
using SEP.Model.Utility;
using SEP.Notes;
using SEP.Notes.RepeatTypes;
using SEP.Presenter.NotesUIFacade;

namespace SEP.Performance.Pages.SEP.CalendarExtPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class NotesHandler : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _ResponseString;
        private NotesUIF _Facade;

        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            _Facade = new NotesUIF();
            context.Response.ContentType = "text/plain";
            if (_Context.Request.Params["type"] != null)
            {
                switch (_Context.Request.Params["type"])
                {
                    case "addNotes":
                        AddNotes();
                        break;
                    case "updateNotes":
                        UpdateNotes();
                        break;
                    case "searchShareAccount":
                        SearchShareAccount();
                        break;
                    case "quite":
                        QuiteShare();
                        break;
                    case "delete":
                        DeleteNotes();
                        break;
                    case "getNoteByID":
                        GetNoteByID();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void SearchShareAccount()
        {
            List<AccountViewModel> accountviewmodel=new List<AccountViewModel>();
            List<ControlError> cr=new List<ControlError>();
            try
            {
                List<Account> accountList = _Facade.GetAccountByCondition(_Context.Request.Params["accountName"], _Context.Request.Params["Department"]);
                foreach (Account account in accountList)
                {
                    accountviewmodel.Add(new AccountViewModel(account));
                }
            }
            catch(Exception ex)
            {
                cr.Add(new ControlError("lblNotesMessage", ex.Message));
            }
            _ResponseString = string.Format("{{itemList:{0},error:{1}}}", JsonConvert.SerializeObject(accountviewmodel),
                              JsonConvert.SerializeObject(cr));
        }
       
        private void AddNotes()
        {
            try
            {
                if (_Context.Request.Params["repeatType"] == "1")
                {
                    _Facade.AddNoRepeatNotes(_Context.Request.Params["startDate"], _Context.Request.Params["startHour"],
                                             _Context.Request.Params["startMinutes"], _Context.Request.Params["endDate"],
                                             _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                             _Context.Request.Params["content"], _Context.Request.Params["shares"]);
                }
                else if (_Context.Request.Params["repeatType"] == "2")
                {
                    _Facade.AddDayRepeatNotes(_Context.Request.Params["startHour"],
                                              _Context.Request.Params["startMinutes"],
                                              _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                              _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                              _Context.Request.Params["chosetype"], _Context.Request.Params["everyday"],
                                              _Context.Request.Params["content"], _Context.Request.Params["shares"]);
                }
                else if (_Context.Request.Params["repeatType"] == "3")
                {
                    _Facade.AddWeekRepeatNotes(_Context.Request.Params["startHour"],
                                               _Context.Request.Params["startMinutes"],
                                               _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                               _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                               _Context.Request.Params["everyweek"], _Context.Request.Params["weeks"],
                                               _Context.Request.Params["content"], _Context.Request.Params["shares"]);
                }
                else if (_Context.Request.Params["repeatType"] == "4")
                {
                    _Facade.AddMonthRepeatNotes(_Context.Request.Params["startHour"],
                                               _Context.Request.Params["startMinutes"],
                                               _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                               _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                               _Context.Request.Params["nmonth"], _Context.Request.Params["ndayMonthEnum"], _Context.Request.Params["monthDayTypeEnum"],
                                               _Context.Request.Params["content"], _Context.Request.Params["shares"]);
                }
            }
            catch (Exception e)
            {
                List<ControlError> errorList=new List<ControlError>();
                errorList.Add(new ControlError("lblNotesMessage",e.Message));
               _ResponseString= string.Format("{{error:{0}}}", JsonConvert.SerializeObject(errorList));
            }

        }
        private void UpdateNotes()
        {
            try
            {
                if (_Context.Request.Params["repeatType"] == "1")
                {
                    _Facade.UpdateNoRepeatNotes(_Context.Request.Params["startDate"], _Context.Request.Params["startHour"],
                                             _Context.Request.Params["startMinutes"], _Context.Request.Params["endDate"],
                                             _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                             _Context.Request.Params["content"], _Context.Request.Params["shares"], _Context.Request.Params["pkid"]);
                }
                else if (_Context.Request.Params["repeatType"] == "2")
                {
                    _Facade.UpdateDayRepeatNotes(_Context.Request.Params["startHour"],
                                              _Context.Request.Params["startMinutes"],
                                              _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                              _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                              _Context.Request.Params["chosetype"], _Context.Request.Params["everyday"],
                                              _Context.Request.Params["content"], _Context.Request.Params["shares"], _Context.Request.Params["pkid"]);
                }
                else if (_Context.Request.Params["repeatType"] == "3")
                {
                    _Facade.UpdateWeekRepeatNotes(_Context.Request.Params["startHour"],
                                               _Context.Request.Params["startMinutes"],
                                               _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                               _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                               _Context.Request.Params["everyweek"], _Context.Request.Params["weeks"],
                                               _Context.Request.Params["content"], _Context.Request.Params["shares"], _Context.Request.Params["pkid"]);
                }
                else if (_Context.Request.Params["repeatType"] == "4")
                {
                    _Facade.UpdateMonthRepeatNotes(_Context.Request.Params["startHour"],
                                               _Context.Request.Params["startMinutes"],
                                               _Context.Request.Params["endHour"], _Context.Request.Params["endMinutes"],
                                               _Context.Request.Params["startDate"], _Context.Request.Params["endDate"],
                                               _Context.Request.Params["nmonth"], _Context.Request.Params["ndayMonthEnum"], _Context.Request.Params["monthDayTypeEnum"],
                                               _Context.Request.Params["content"], _Context.Request.Params["shares"], _Context.Request.Params["pkid"]);
                }
            }
            catch (Exception e)
            {
                List<ControlError> errorList = new List<ControlError>();
                errorList.Add(new ControlError("lblNotesMessage", e.Message));
                _ResponseString = string.Format("{{error:{0}}}", JsonConvert.SerializeObject(errorList));
            }
        }
        
        private void QuiteShare()
        {
            try
            {
                _Facade.QuiteShare(_Context.Request.Params["pkid"]);
            }
            catch(Exception e)
            {
                List<ControlError> errorList = new List<ControlError>();
                errorList.Add(new ControlError("lblShowDetailMessage", e.Message));
                _ResponseString = string.Format("{{error:{0}}}", JsonConvert.SerializeObject(errorList));
            }
        }
        private void DeleteNotes()
        {
            try
            {
                _Facade.DeleteNotes(_Context.Request.Params["pkid"]);
            }
            catch (Exception e)
            {
                List<ControlError> errorList = new List<ControlError>();
                errorList.Add(new ControlError("lblShowDetailMessage", e.Message));
                _ResponseString = string.Format("{{error:{0}}}", JsonConvert.SerializeObject(errorList));
            }
        }

        private void GetNoteByID()
        {
            List<ControlError> errorList = new List<ControlError>();
            Notes.Notes note=new Notes.Notes();
            try
            {
               note= _Facade.GetNoteByID(_Context.Request.Params["pkid"]);
            }
            catch (Exception e)
            {
                
                errorList.Add(new ControlError("lblShowDetailMessage", e.Message));
               
            }

            _ResponseString = string.Format("{{item:{0},error:{1}}}", JsonConvert.SerializeObject(new NotesViewModel(note)),
                             JsonConvert.SerializeObject(errorList));
        }

        public bool IsReusable
        {
            get { return false; }
        }

        internal class AccountViewModel
        {
            private readonly Account _M;
            public AccountViewModel(Account t)
            {
                _M = t;
            }
            public string PKID
            {
                get { return _M.Id.ToString(); }
            }

            /// <summary>
            /// 帐户姓名
            /// </summary>
            public string Name
            {
                get { return _M.Name; }
            }

            /// <summary>
            /// 部门名称
            /// </summary>
            public string DeptmentName
            {
                get { return _M.Dept.Name; }
            }

            /// <summary>
            /// 职位名称
            /// </summary>
            public string PositionName
            {
                get { return _M.Position.Name; }
            }

            /// <summary>
            /// 手机
            /// </summary>
            public string MobileNum
            {
                get { return _M.MobileNum; }
            }
        }

        internal class NotesViewModel
        {
            private readonly Notes.Notes _Note;
            private readonly DayRepeat _DayRepeat;
            private readonly WeekRepeat _WeekRepeat;
            private readonly NoRepeat _NoRepeat;
            private readonly MonthRepeat _MonthRepeat;
            public  NotesViewModel(Notes.Notes note)
            {
                _Note = note;
                if(_Note.RepeatType is NoRepeat)
                {
                    _NoRepeat = (NoRepeat)_Note.RepeatType;
                }
                else if (_Note.RepeatType is DayRepeat)
                {
                    _DayRepeat = (DayRepeat)_Note.RepeatType;
                }
                else if (_Note.RepeatType is WeekRepeat)
                {
                    _WeekRepeat = (WeekRepeat)_Note.RepeatType;
                }
                else if(_Note.RepeatType is MonthRepeat)
                {
                    _MonthRepeat = (MonthRepeat) _Note.RepeatType;
                }
            }

            public string Share
            {
                get { return _Note.ShareSet.toAccountString(); }
            }
            public int Type
            {
                get { return RepeatUtility.GetTypeIndex(_Note.RepeatType); }
            }
            public string Content
            {
                get { return _Note.Content; }
            }
            public string NoStartDate
            {
                get
                {
                    if(_NoRepeat!=null)
                    {
                        return _Note.Start.ToShortDateString();
                    }
                    return DateTime.Now.ToShortDateString();
                }
            }
            public int NoStartHour
            {
                get
                {
                    if (_NoRepeat != null)
                    {
                        return _Note.Start.Hour;
                    }
                    return 0;
                }
            }
            public int NoStartMinutes
            {
                get
                {
                    if (_NoRepeat != null)
                    {
                        return _Note.Start.Minute;
                    }
                    return 0;
                }
            }
            public string NoEndDate
            {
                get
                {
                    if (_NoRepeat != null)
                    {
                        return _Note.End.ToShortDateString();
                    }
                    return DateTime.Now.ToShortDateString();
                }
            }
            public int NoEndHour
            {
                get
                {
                    if (_NoRepeat != null)
                    {
                        return _Note.End.Hour;
                    }
                    return 0;
                }
            }
            public int NoEndMinutes
            {
                get
                {
                    if (_NoRepeat != null)
                    {
                        return _Note.End.Minute;
                    }
                    return 0;
                }
            }

            public string DayStartDate
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        return _DayRepeat.RangeStart.ToShortDateString();
                    }
                    return DateTime.Now.ToShortDateString();
                }
            }
            public int DayStartHour
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        return _Note.Start.Hour;
                    }
                    return 0;
                }
            }
            public int DayStartMinutes
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        return _Note.Start.Minute;
                    }
                    return 0;
                }
            }
            public string DayEndDate
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        if (_DayRepeat.RangeEnd == null)
                        {
                            return "";
                        }
                        else
                        {
                            return ((DateTime)_DayRepeat.RangeEnd).ToShortDateString();
                        }
                    }
                    return "";
                }
            }
            public int DayEndHour
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        return _Note.End.Hour;
                    }
                    return 0;
                }
            }
            public int DayEndMinutes
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        return _Note.End.Minute;
                    }
                    return 0;
                }
            }

            public int DayType
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                        if (_DayRepeat.EveryWork)
                        {
                            return 2;
                        }
                        if (_DayRepeat.EveryWeek)
                        {
                            return 3;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    return -1;
                }
            }

            public string NDayOnce
            {
                get
                {
                    if (_DayRepeat != null)
                    {
                       if(_DayRepeat.NDayOnce>0)
                       {
                           return _DayRepeat.NDayOnce.ToString();
                       }
                    }
                    return "";
                }
            }

            public string WeekStartDate
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _WeekRepeat.RangeStart.ToShortDateString();
                    }
                    return DateTime.Now.ToShortDateString();
                }
            }
            public int WeekStartHour
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _Note.Start.Hour;
                    }
                    return 0;
                }
            }
            public int WeekStartMinutes
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _Note.Start.Minute;
                    }
                    return 0;
                }
            }
            public string WeekEndDate
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        if (_WeekRepeat.RangeEnd == null)
                        {
                            return "";
                        }
                        else
                        {
                            return ((DateTime)_WeekRepeat.RangeEnd).ToShortDateString();
                        }
                    }
                    return "";
                }
            }
            public int WeekEndHour
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _Note.End.Hour;
                    }
                    return 0;
                }
            }
            public int WeekEndMinutes
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _Note.End.Minute;
                    }
                    return 0;
                }
            }  

            public string NWeek
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _WeekRepeat.NWeek.ToString();
                    }
                    return "";
                }
            }

            public Array Weeks
            {
                get
                {
                    if (_WeekRepeat != null)
                    {
                        return _WeekRepeat.WeekList.ToArray();
                    }
                    return null;
                }
            }

            public string MonthStartDate
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _MonthRepeat.RangeStart.ToShortDateString();
                    }
                    return DateTime.Now.ToShortDateString();
                }
            }
            public int MonthStartHour
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _Note.Start.Hour;
                    }
                    return 0;
                }
            }
            public int MonthStartMinutes
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _Note.Start.Minute;
                    }
                    return 0;
                }
            }
            public string MonthEndDate
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        if (_MonthRepeat.RangeEnd == null)
                        {
                            return "";
                        }
                        else
                        {
                            return ((DateTime)_MonthRepeat.RangeEnd).ToShortDateString();
                        }
                    }
                    return "";
                }
            }
            public int MonthEndHour
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _Note.End.Hour;
                    }
                    return 0;
                }
            }
            public int MonthEndMinutes
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _Note.End.Minute;
                    }
                    return 0;
                }
            }

            public string NMonth
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _MonthRepeat.NMonth.ToString();
                    }
                    return "";
                }
            }

            public int NDayMonthEnum
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _MonthRepeat.NDayMonthEnum.Value;
                    }
                    return 1;
                }
            }

            public int MonthDayTypeEnum
            {
                get
                {
                    if (_MonthRepeat != null)
                    {
                        return _MonthRepeat.MonthDayTypeEnum.Value;
                    }
                    return 1;
                }
            }
        }
    }
}