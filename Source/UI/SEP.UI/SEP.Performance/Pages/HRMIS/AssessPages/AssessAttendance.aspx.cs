using System;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class AssessAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Type"] == "ibHour")
            {
                GetEmployeeAttendanceByHour();
            }
            else
            {
                GetEmployeeAttendanceByDay();
            }

            Response.Write("");
            Response.End();
        }

        private Employee GetEmployeeAttendance()
        {
            int EmployeeID = Convert.ToInt32(Request.Params["EmployeeID"]);
            DateTime dtFromDate = Convert.ToDateTime(Request.Params["FromDate"]);
            DateTime dtToDate = Convert.ToDateTime(Request.Params["ToDate"]);
            return InstanceFactory.CreateEmployeeAttendanceStatisticsFacade().GetMonthAttendanceStatisticsFacade(EmployeeID, dtFromDate, dtToDate);

        }
        private void GetEmployeeAttendanceByHour()
        {
            Employee theEmployee = GetEmployeeAttendance();
            StringBuilder sb = new StringBuilder();
            sb.Append(
             "<table id='tbHour' cellspacing='0' border='0' style='width: 100%; border-collapse: collapse;' >");
            sb.Append("<tbody><tr align='center' style='height: 28px;' class='green1'>");
            sb.Append("<th  class='kqfont02'>Ա������</th> ");
            sb.Append("<th  class='kqfont02'>Ӧ������</th> ");
            sb.Append("<th  class='kqfont02'>������</th> ");
            sb.Append("<th  class='kqfont02'>���(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>�¼�(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>�ٵ�</th> ");
            sb.Append("<th  class='kqfont02'>����</th> ");
            sb.Append("<th  class='kqfont02'>�Ӱ�(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>��ͨ�Ӱ�(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>˫���ռӰ�(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>�����Ӱ�(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>ʣ�����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>ʣ�����(ʱ)</th> ");
            sb.Append("<th  class='kqfont02'>������</th> </tr>");
            sb.Append("<tr style='height: 28px;background-color:#ffffff;'> <td style='width: 8%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.Account.Name);
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(theEmployee.EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(theEmployee.EmployeeAttendance.MonthAttendance.ActualOnDutyDays));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofLunarPeriodLeave), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofPersonalReasonLeave), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofSickLeave), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestLeave), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofOtherLeave), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofNoReasonLeave), 2)));
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.EmployeeAttendance.MonthAttendance.LateToString());
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.EmployeeAttendance.MonthAttendance.EarlyLeaveToString());
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofOvertime), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofCommonOvertime), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofWeekendOvertime), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofHolidayOvertime), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained), 2)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.Vacation.SurplusDayNum) * 8, 2)));
            sb.Append(" </td><td style='width: 6%;' class='kqfont02'>");
            sb.Append(Convert.ToSingle(decimal.Round(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.RateofOnDuty) * 100, 2)));
            sb.Append("%</td></tr></tbody></table>");
            Response.Write(sb);
            Response.End();


        }
        private void GetEmployeeAttendanceByDay()
        {
            Employee theEmployee = GetEmployeeAttendance();
            StringBuilder sb = new StringBuilder();

            sb.Append(
                 "<table id='tbday' cellspacing='0' border='0' style='width: 100%; border-collapse: collapse;' >");
            sb.Append("<tbody><tr align='center' style='height: 28px;' class='green1'>");
            sb.Append("<th  class='kqfont02'>Ա������</th> ");
            sb.Append("<th  class='kqfont02'>Ӧ������</th> ");
            sb.Append("<th  class='kqfont02'>������</th> ");
            sb.Append("<th  class='kqfont02'>���(��)</th> ");
            sb.Append("<th  class='kqfont02'>�¼�(��)</th> ");
            sb.Append("<th  class='kqfont02'>����(��)</th> ");
            sb.Append("<th  class='kqfont02'>����(��)</th> ");
            sb.Append("<th  class='kqfont02'>����(��)</th> ");
            sb.Append("<th  class='kqfont02'>����(��)</th> ");
            sb.Append("<th  class='kqfont02'>�ٵ�</th> ");
            sb.Append("<th  class='kqfont02'>����</th> ");
            sb.Append("<th  class='kqfont02'>�Ӱ�(��)</th> ");
            sb.Append("<th  class='kqfont02'>��ͨ�Ӱ�(��)</th> ");
            sb.Append("<th  class='kqfont02'>˫���ռӰ�(��)</th> ");
            sb.Append("<th  class='kqfont02'>�����Ӱ�(��)</th> ");
            sb.Append("<th  class='kqfont02'>ʣ�����(��)</th> ");
            sb.Append("<th  class='kqfont02'>ʣ�����(��)</th> ");
            sb.Append("<th  class='kqfont02'>������</th> </tr>");
            sb.Append(
                "<tr style='height: 28px;background-color:#ffffff;'> <td style='width: 8%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.Account.Name);
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(theEmployee.EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(theEmployee.EmployeeAttendance.MonthAttendance.ActualOnDutyDays));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofLunarPeriodLeave)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofPersonalReasonLeave)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofSickLeave)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestLeave)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofOtherLeave)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave)));
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.EmployeeAttendance.MonthAttendance.LateToString());
            sb.Append(" </td><td style='width: 7%;' class='kqfont02' align='center'>");
            sb.Append(theEmployee.EmployeeAttendance.MonthAttendance.EarlyLeaveToString());
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofOvertime)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofCommonOvertime)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(
                Convert.ToSingle(
                    Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained)));
            sb.Append(" </td><td style='width: 5%;' class='kqfont02' align='center'>");
            sb.Append(Convert.ToSingle(Convert.ToDecimal(theEmployee.EmployeeAttendance.Vacation.SurplusDayNum)));
            sb.Append(" </td><td style='width: 6%;' class='kqfont02'>");
            sb.Append(
                Convert.ToSingle(
                    decimal.Round(
                        Convert.ToDecimal(theEmployee.EmployeeAttendance.MonthAttendance.RateofOnDuty) * 100, 2)));
            sb.Append("%</td></tr></tbody></table>");
            Response.Write(sb);
            Response.End();
        }


    }
}

