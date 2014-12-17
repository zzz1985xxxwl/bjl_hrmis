using System;
using System.Collections.Generic;
using Mail.Model;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.IBll;
using SEP.IBll.Mail;

namespace SEP.HRMIS.Bll.AutoRemindServer
{
    /// <summary>
    /// 月底自动提醒员工核对考勤数据
    /// </summary>
    public class AutoRemindEmployeeConfirmAttendance : Transaction
    {
        private GetEmployee _GetEmployee = new GetEmployee();
        private IPlanDutyDal _IPlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private static IMailGateWay _IMailGateWay = BllInstance.MailGateWayBllInstance;
        private DateTime _CurrDate;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currdate"></param>
        public AutoRemindEmployeeConfirmAttendance(DateTime currdate)
        {
            _CurrDate = currdate.Date.AddDays(-2);
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            DateTime endMonthDate = new HrmisUtility().EndMonthByYearMonth(_CurrDate);
            if (DateTime.Compare(_CurrDate.Date, endMonthDate.Date) == 0)
            {
                string employeeNameFailEmail = "";
                List<Employee> employees = _GetEmployee.GetAllEmployeeBasicInfo();
                foreach (Employee employee in employees)
                {
                    if (employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                    {
                        continue;
                    }
                    if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
                    {
                        employee.EmployeeDetails =
                            _GetEmployee.GetEmployeeByAccountID(employee.Account.Id).EmployeeDetails;
                        if (
                            DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate,
                                             _CurrDate.AddDays(1 - _CurrDate.Date.Day)) < 0)
                        {
                            continue;
                        }
                    }
                    //没有排版表的人不需要提醒
                    List<PlanDutyDetail> planDutyDetailList =
                        _IPlanDutyDal.GetPlanDutyDetailByAccount(employee.Account.Id, _CurrDate.AddDays(1).AddMonths(-1),
                                                                 _CurrDate);
                    if (planDutyDetailList.Count == 0)
                    {
                        continue;
                    }
                    try
                    {
                        SendEmailToEmployee(employee);
                    }
                    catch
                    {
                        if (string.IsNullOrEmpty(employeeNameFailEmail))
                        {
                            employeeNameFailEmail = employee.Account.Name;
                        }
                        else
                        {
                            employeeNameFailEmail += "," + employee.Account.Name;
                        }
                    }
                    employee.EmployeeDetails = null;
                }
                if (!string.IsNullOrEmpty(employeeNameFailEmail))
                {
                    throw new Exception("发送邮件失败。以下" + employeeNameFailEmail.Split(',').Length + "位员工没有获得系统提醒：" +
                                        employeeNameFailEmail);
                }
            }
        }

        private void SendEmailToEmployee(Employee employee)
        {
            MailBody mailBody = new MailBody();
            List<string> mailTo = new List<string>();
            mailTo.Add(employee.Account.Email1);
            mailTo.Add(employee.Account.Email2);
            mailBody.MailTo = mailTo;

            mailBody.Subject = _CurrDate.Month + "月已经结束，" +
                                    BllUtility.GetResourceMessage(
                                        BllExceptionConst._Email_To_Employee_For_Confirming_Attendance);
            mailBody.Body = mailBody.Subject;

            GetAttendanceInfo(employee, mailBody);
            _IMailGateWay.Send(mailBody, true);

        }

        private void GetAttendanceInfo(Employee employee, MailBody mailBody)
        {
            try
            {
                string resultmonth = string.Empty;
                DateTime startdate = new HrmisUtility().StartMonthByYearMonth(_CurrDate);
                DateTime enddate = new HrmisUtility().EndMonthByYearMonth(_CurrDate);
                Employee emp =
                    new GetEmployeeAttendanceStatistics().GetAllEmployeeAttendanceByCondition(employee.Account.Id,
                                                                                           startdate,
                                                                                           enddate);
                string color;
                for (int i = 0; startdate.Date.AddDays(i) <= enddate.Date; i++)
                {
                    string retstring =
                        emp.EmployeeAttendance.SetDefaultWeek(emp, "", startdate.Date.AddDays(i), "#000000", out color);
                    if (retstring.Contains("数据有误"))
                    {
                        resultmonth += "<br />" + startdate.Date.AddDays(i) + "考勤异常：" + retstring;
                    }
                }
                mailBody.Body += resultmonth;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 用于测试
        /// </summary>
        public IPlanDutyDal MockIPlanDutyDal
        {
            set
            {
                _IPlanDutyDal = value;
            }
        }
        /// <summary>
        /// 仅仅用于测试邮件关口
        /// </summary>
        public IMailGateWay SetMailGateWay
        {
            set
            {
                _IMailGateWay = value;
            }
        }
        /// <summary>
        /// 测试
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
    }
}
