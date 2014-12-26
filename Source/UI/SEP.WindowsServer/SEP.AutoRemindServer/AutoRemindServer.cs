using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Text;
using Mail.Model;
using SEP.HRMIS.Facade;
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
        private static DateTime _LastRunTime;
        private static DateTime _RunDate;
        private static string strErrorMsg;
        private static readonly IAutoRemindServerFacade _IAutoRemindServerFacade = new AutoRemindServerFacade();
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
                _LastRunTime = GetLastDateTime();
                _RunDate = _LastRunTime.AddDays(1).Date;

                CompanyConfig.FileName = AppDomain.CurrentDomain.BaseDirectory;
                _Today = DateTime.Now;
                strErrorMsg = _Today+ "执行\n";
                _IsExecute = true;
                try
                {
                    while (_RunDate <= _Today.Date)
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

                        SendEmailAboutExecuteResult(strErrorMsg);
                        _RunDate = _RunDate.AddDays(1).Date;
                    }
                }
                catch (Exception ex)
                {
                    // 错误信息
                    strErrorMsg += "\n异常：\n" + ex.Message;
                }

                Log(strErrorMsg);
            }
            tTrack.Start();
        }

        #region log
        private static DateTime GetLastDateTime()
        {
            var filepath = Environment.CurrentDirectory + "\\log\\time.log";
            if (File.Exists(filepath))
            {
                StreamReader sr = new StreamReader(filepath, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    return Convert.ToDateTime(line);
                }
            }
            return DateTime.Now.AddDays(-1);
        }

        private static void Log(string message)
        {
            string logFilePath = Environment.CurrentDirectory + "\\log";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            WriteFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Path.Combine(logFilePath, "time.log"), false);

            // 将错误记录到日志中
            WriteFile(message, Path.Combine(logFilePath, DateTime.Now.ToString("yyyyMMdd") + ".log"));
        }

        private static void WriteFile(string message, string file, bool append = true)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(file, append);
                writer.WriteLine(message);
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        #endregion

        private static void SendEmailAboutExecuteResult(string mailbodystring)
        {
            try
            {
                MailBody mailBody = new MailBody();
                mailBody.Body = mailbodystring;
                mailBody.Subject = "自动提醒功能执行结果！";
                List<string> mailAddress = new List<string>();
                //mailAddress.Add("Luan.Tianlin@br-automation.com");
                mailAddress.Add("316048597@qq.com");
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
                    _IAutoRemindServerFacade.AutoAssessFacade(_RunDate);
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
                    _IAutoRemindServerFacade.AutoRemindProbationDateRearch(_RunDate,
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
                    _IAutoRemindServerFacade.AutoEmployeeResidenceDateRearchFacade(_RunDate,
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
                    _IAutoRemindServerFacade.AutoRemindEmployeeConfirmAttendanceFacade(_RunDate);
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
                    _IAutoRemindServerFacade.AutoRemindVacationFacade(_RunDate,
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
                    _IAutoRemindServerFacade.AutoRemindContractFacade(_RunDate,
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
                    _IAutoRemindServerFacade.AutoCreateVacation(_RunDate, createAnnualHolidayMonth,
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
                    _IAutoRemindServerFacade.AutoRemindVacationSendEmail(_RunDate, dateTimeList);
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
                _IAutoRemindServerFacade.AutoSendBirthdayMailFacade(_RunDate);
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute AutoSendBirthdayMail Error: " + ex.Message + "\n";
            }
        }
    }
}
