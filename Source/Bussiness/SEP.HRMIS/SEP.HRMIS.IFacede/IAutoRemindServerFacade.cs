using System;
using System.Collections.Generic;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 自动提醒业务
    /// </summary>
    public interface IAutoRemindServerFacade
    {
        /// <summary>
        /// 自动提醒员工n天后试用期到期,提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindProbationDateRearch(DateTime currDate, int days);
        /// <summary>
        /// 自动提醒员工居住证到期，在该居住证到期前days天，可以发Email提醒人事部门和员 工本人居住证即将到期
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoEmployeeResidenceDateRearchFacade(DateTime currDate, int days);
        /// <summary>
        /// 员工合同到期前days提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindContractFacade(DateTime currDate, int days);
        /// <summary>
        /// 月底自动提醒员工核对考勤数据
        /// </summary>
        /// <param name="currDate"></param>
        void AutoRemindEmployeeConfirmAttendanceFacade(DateTime currDate);
        /// <summary>
        /// 年假到期前days提醒个人，提醒人事
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindVacationFacade(DateTime currDate, int days);
        /// <summary>
        /// 自动发起考评
        /// </summary>
        /// <param name="currDate"></param>
        void AutoAssessFacade(DateTime currDate);
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
        void AutoCreateVacation(DateTime date, int createAnnualHolidayMonth,
            int annualHolidayLow, int annualHolidayHigh, int deferredMonths,
            int inComanyMonth, int createAnnualHolidayDay);

        ///<summary>
        /// 根据设定个时间自动提醒员工年假
        ///</summary>
        ///<param name="date"></param>
        ///<param name="dateList"></param>
        void AutoRemindVacationSendEmail(DateTime date, List<DateTime> dateList);

        /// <summary>
        /// 根据当前时间查找1天之前未给财务审核的报销单
        /// </summary>
        void AutoRemindReimburse();

        /// <summary>
        /// 自动发送生日祝贺信
        /// </summary>
        /// <param name="currDate"></param>
        void AutoSendBirthdayMailFacade(DateTime currDate);
    }
}
