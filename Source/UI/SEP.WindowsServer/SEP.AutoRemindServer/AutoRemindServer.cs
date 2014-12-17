using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceProcess;
using Mail.Model;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.IBll.Mail;
using SEP.Model.Utility;

namespace SEP.AutoRemindServer
{
    partial class AutoRemindServer : ServiceBase
    {
        private static bool _IsExecute;//用于保证一天执行一次
        private static DateTime _Today = DateTime.Now;
        private static string strErrorMsg;
        private static readonly IAutoRemindServerFacade _IAutoRemindServerFacade = InstanceFactory.CreateAutoRemindServerFacade();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        public AutoRemindServer()
        {
            InitializeComponent();
        }


        private void tTrack_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tTrack.Stop();
            if (_Today.Date != DateTime.Now.Date && _IsExecute)
            {
                _IsExecute = false;
            }
            if (!_IsExecute)//用于保证一天执行一次
            {
                CompanyConfig.FileName = AppDomain.CurrentDomain.BaseDirectory;
                strErrorMsg = "";
                _Today = DateTime.Now;
                _IsExecute = true;
                try
                {
                    AutoAssess();
                    AutoEmployeeResidenceDateRearch();
                    AutoRemindEmployeeConfirmAttendance();
                    AutoRemindVacation();
                    AutoRemindContract();
                    AutoRemindProbationDateRearch();

                    AutoCreateVacation();
                    AutoRemindVacationSendEmail();

                    AutoRemindReimburse();

                    AutoSendBirthdayMail();

                    if (!String.IsNullOrEmpty(strErrorMsg))
                    {
                        throw new Exception(strErrorMsg);
                    }

                    TLineEventLog el = new TLineEventLog();
                    el.DoWriteEventLog(DateTime.Now.Date.ToShortDateString() + "执行完毕！", EventType.Information);
                    SendEmailAboutExecuteResult(DateTime.Now.Date.ToShortDateString() + "执行完毕！");
                }
                catch (Exception ex)
                {
                    // 错误信息
                    strErrorMsg = "异常：\n" + ex.Message;
                    //// 写日志
                    TLineEventLog el = new TLineEventLog();
                    el.DoWriteEventLog(strErrorMsg, EventType.Error);
                    SendEmailAboutExecuteResult("执行出错！" + strErrorMsg);
                }
            }
            tTrack.Start();
        }

        private static void SendEmailAboutExecuteResult(string mailbodystring)
        {
            try
            {
                MailBody mailBody = new MailBody();
                mailBody.Body = mailbodystring;
                mailBody.Subject = "自动提醒功能执行结果！";
                List<string> mailAddress = new List<string>();
                //mailAddress.Add("Luan.Tianlin@br-automation.com");
                mailAddress.Add("Br-hrmis.Cn@br-automation.com");
                mailBody.MailTo = mailAddress;
                _IMailGateWay.Send(mailBody);
            }
            catch
            {
            }
        }

        private static void AutoAssess()
        {
            try
            {
                string _IsAutoAssess = ConfigurationManager.AppSettings["IsAutoAssess"];
                if (_IsAutoAssess == "true")
                {
                    _IAutoRemindServerFacade.AutoAssessFacade(DateTime.Now.Date);
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoAssess Error: " + ex.Message + "\n";
            }
        }

        private static void AutoRemindReimburse()
        {
            try
            {
                string _IsAutoRemindReimburse = ConfigurationManager.AppSettings["IsAutoRemindReimburse"];
                if (_IsAutoRemindReimburse == "true")
                {
                    _IAutoRemindServerFacade.AutoRemindReimburse();
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoRemindReimburse Error: " + ex.Message + "\n";
            }
        }

        private static void AutoRemindProbationDateRearch()
        {
            try
            {
                string _IsAutoRemindProbationDateRearch =
                    ConfigurationManager.AppSettings["IsAutoRemindProbationDateRearch"];
                string _BeforeProbationDateRearchDays =
                    ConfigurationManager.AppSettings["BeforeProbationDateRearchDays"];
                if (_IsAutoRemindProbationDateRearch == "true")
                {
                    _IAutoRemindServerFacade.AutoRemindProbationDateRearch(DateTime.Now.Date,
                                                                                   Convert.ToInt32(
                                                                                       _BeforeProbationDateRearchDays));
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute ProbationDateRearch Error: " + ex.Message + "\n";
            }
        }

        private static void AutoEmployeeResidenceDateRearch()
        {
            try
            {
                string _IsAutoEmployeeResidenceDateRearch =
                    ConfigurationManager.AppSettings["IsAutoEmployeeResidenceDateRearch"];
                string _BeforeEmployeeResidenceDateRearchDays =
                    ConfigurationManager.AppSettings["BeforeEmployeeResidenceDateRearchDays"];
                if (_IsAutoEmployeeResidenceDateRearch == "true")
                {
                    _IAutoRemindServerFacade.AutoEmployeeResidenceDateRearchFacade(DateTime.Now.Date,
                                                                                   Convert.ToInt32(
                                                                                       _BeforeEmployeeResidenceDateRearchDays));
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute EmployeeResidenceDateRearch Error: " + ex.Message + "\n";
            }
        }

        private static void AutoRemindEmployeeConfirmAttendance()
        {
            try
            {
                string _IsAutoRemindEmployeeConfirmAttendance =
                    ConfigurationManager.AppSettings["IsAutoRemindEmployeeConfirmAttendance"];
                if (_IsAutoRemindEmployeeConfirmAttendance == "true")
                {
                    _IAutoRemindServerFacade.AutoRemindEmployeeConfirmAttendanceFacade(DateTime.Now.Date);
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoRemindEmployeeConfirm Error: " + ex.Message + "\n";
            }
        }

        private static void AutoRemindVacation()
        {
            try
            {
                string _IsAutoRemindVacation = ConfigurationManager.AppSettings["IsAutoRemindVacation"];
                string _BeforeRemindVacationDays = ConfigurationManager.AppSettings["BeforeRemindVacationDays"];
                if (_IsAutoRemindVacation == "true")
                {
                    _IAutoRemindServerFacade.AutoRemindVacationFacade(DateTime.Now.Date,
                                                                      Convert.ToInt32(_BeforeRemindVacationDays));
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoRemindVacation Error: " + ex.Message + "\n";
            }
        }

        private static void AutoRemindContract()
        {
            try
            {
                string _IsAutoRemindVacation = ConfigurationManager.AppSettings["IsAutoRemindContract"];
                string _BeforeRemindContractDays = ConfigurationManager.AppSettings["BeforeRemindContractDays"];
                if (_IsAutoRemindVacation == "true")
                {
                    _IAutoRemindServerFacade.AutoRemindContractFacade(DateTime.Now.Date,
                                                                      Convert.ToInt32(_BeforeRemindContractDays));
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoRemindContract Error: " + ex.Message + "\n";
            }
        }

        /// <summary>
        /// 读取App.config中的设置
        /// </summary>
        public static string _InComanyMonth = ConfigurationManager.AppSettings["InComanyMonth"];
        public static string _CreateAnnualHolidayDay = ConfigurationManager.AppSettings["CreateAnnualHolidayDay"];
        public static string _AnnualHolidayLow = ConfigurationManager.AppSettings["AnnualHolidayLow"];
        public static string _AnnualHolidayHigh = ConfigurationManager.AppSettings["AnnualHolidayHigh"];
        public static string _DeferredMonths = ConfigurationManager.AppSettings["DeferredMonths"];
        private static int inComanyMonth;
        private static int createAnnualHolidayDay;
        private static int createAnnualHolidayMonth;
        private static int annualHolidayLow;
        private static int annualHolidayHigh;
        private static int deferredMonths;
        private static void AutoCreateVacation()
        {
            try
            {
                string validation = Validation();
                if (validation != "")
                {
                    strErrorMsg += "Execute AutoCreateVacation Error:" + validation + "\n";
                    return;
                }
                string _IsAutoCreateAnnualHoliday = ConfigurationManager.AppSettings["IsAutoCreateAnnualHoliday"];
                if (_IsAutoCreateAnnualHoliday == "true")
                {
                    _IAutoRemindServerFacade.AutoCreateVacation(DateTime.Now.Date, createAnnualHolidayMonth,
                                                                annualHolidayLow, annualHolidayHigh, deferredMonths,
                                                                inComanyMonth, createAnnualHolidayDay);
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoCreateVacation Error:" + ex.Message + "\n";
            }
        }
        private static string Validation()
        {
            if (!int.TryParse(_InComanyMonth, out inComanyMonth) || inComanyMonth < 0)
            {
                return "进入公司第几个月自动生成一条年假记录InComanyMonth设置格式不正确！填写范围为大于0的整数！";
            }
            string[] temp = _CreateAnnualHolidayDay.Split('-');
            if (temp.Length < 2 ||
                !int.TryParse(temp[0], out createAnnualHolidayMonth) ||
                !int.TryParse(temp[1], out createAnnualHolidayDay) ||
                createAnnualHolidayMonth < 0 ||
                createAnnualHolidayDay < 0)
            {
                return "设置每年自动生成一条年假记录的时间格式不正确！填写格式为'月-日'！";
            }
            if (!int.TryParse(_AnnualHolidayLow, out annualHolidayLow) ||
                annualHolidayLow < 0)
            {
                return "年假的最少天数设置格式不正确！填写格式为大于等于0的整数！";
            }
            if (!int.TryParse(_AnnualHolidayHigh, out annualHolidayHigh) ||
                annualHolidayHigh < 0)
            {
                return "年假的最多天数设置格式不正确！填写格式为大于等于0的整数！";
            }
            if (!int.TryParse(_DeferredMonths, out deferredMonths) ||
                deferredMonths < 0)
            {
                return "员工年假可延期月数设置格式不正确！填写格式为大于等于0的整数！";
            }
            return "";
        }

        private static void AutoRemindVacationSendEmail()
        {
            try
            {
                string _IsAutoRemindVacationSendEmail =
                    ConfigurationManager.AppSettings["IsAutoRemindVacationSendEmail"];
                if (_IsAutoRemindVacationSendEmail == "true")
                {
                    string _RemindEmployeeTime = ConfigurationManager.AppSettings["RemindEmployeeTime"];
                    string[] dateList = _RemindEmployeeTime.Split(';');
                    List<DateTime> dateTimeList = new List<DateTime>();
                    try
                    {
                        foreach (string date in dateList)
                        {
                            string[] temp = date.Split('-');

                            DateTime dt = new DateTime(2009, Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]));
                            dateTimeList.Add(dt);
                        }
                    }
                    catch
                    {
                        strErrorMsg += "Execute AutoRemindVacationSendEmail Error: 提醒员工年假到期的时间格式设置不正确！" + "\n";
                        return;
                    }
                    _IAutoRemindServerFacade.AutoRemindVacationSendEmail(DateTime.Now.Date, dateTimeList);
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoRemindVacationSendEmail Error:" + ex.Message + "\n";
            }
        }

        private static void AutoSendBirthdayMail()
        {
            try
            {
                _IAutoRemindServerFacade.AutoSendBirthdayMailFacade(DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoSendBirthdayMail Error: " + ex.Message + "\n";
            }
        }
    }
}
