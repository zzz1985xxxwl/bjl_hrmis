using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 自动提醒业务
    /// </summary>
    public class AutoRemindServerFacade : IAutoRemindServerFacade
    {
        /// <summary>
        /// 自动提醒员工n天后试用期到期,提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindProbationDateRearch(DateTime currDate, int days)
        {
            new AutoRemindProbationDateRearch(currDate, days).Excute();
        }

        /// <summary>
        /// 自动提醒员工居住证到期，在该居住证到期前days天，可以发Email提醒人事部门和员 工本人居住证即将到期
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoEmployeeResidenceDateRearchFacade(DateTime currDate, int days)
        {
            new AutoEmployeeResidenceDateRearch(currDate, days).Excute();
        }
        /// <summary>
        /// 员工合同到期前days天提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindContractFacade(DateTime currDate, int days)
        {
            new AutoRemindContract(currDate, days).Excute();
        }
        /// <summary>
        /// 月底自动提醒员工核对考勤数据
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoRemindEmployeeConfirmAttendanceFacade(DateTime currDate)
        {
            new AutoRemindEmployeeConfirmAttendance(currDate).Excute();
        }
        /// <summary>
        /// 年假到期前days天提醒个人，提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindVacationFacade(DateTime currDate, int days)
        {
            new AutoRemindVacation(currDate, days).Excute();
        }
        /// <summary>
        /// 自动发起考评
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoAssessFacade(DateTime currDate)
        {
            new AutoAssess(currDate).Excute();
        }


        /// <summary>
        /// 根据当前时间自动生成年假
        /// </summary>
        ///<param name="date"></param>
        ///<param name="inComanyMonth"></param>
        ///<param name="createAnnualHolidayDay"></param>
        ///<param name="createAnnualHolidayMonth"></param>
        ///<param name="annualHolidayLow"></param>
        ///<param name="annualHolidayHigh"></param>
        ///<param name="deferredMonths"></param>
        public void AutoCreateVacation(DateTime date, int createAnnualHolidayMonth,
            int annualHolidayLow, int annualHolidayHigh, int deferredMonths,
            int inComanyMonth, int createAnnualHolidayDay)
        {
            AutoCreateVacation autoCreateVacation = new AutoCreateVacation(date, createAnnualHolidayMonth,
             annualHolidayLow, annualHolidayHigh, deferredMonths,
             inComanyMonth, createAnnualHolidayDay);
            autoCreateVacation.Excute();
        }

        ///<summary>
        /// 根据设定个时间自动提醒员工年假
        ///</summary>
        ///<param name="date"></param>
        ///<param name="dateList"></param>
        public void AutoRemindVacationSendEmail(DateTime date, List<DateTime> dateList)
        {
            
        }
        public void AutoRemindReimburse()
        {
            AutoRemindReimburse autoRemindReimburse = new AutoRemindReimburse();
            autoRemindReimburse.Excute();
        }

        /// <summary>
        /// 自动发送生日祝贺信
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoSendBirthdayMailFacade(DateTime currDate)
        {
            new AutoSendBirthdayMail(currDate).Excute();
        }
    }
}
