using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// �Զ�����ҵ��
    /// </summary>
    public class AutoRemindServerFacade : IAutoRemindServerFacade
    {
        /// <summary>
        /// �Զ�����Ա��n��������ڵ���,��������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindProbationDateRearch(DateTime currDate, int days)
        {
            new AutoRemindProbationDateRearch(currDate, days).Excute();
        }

        /// <summary>
        /// �Զ�����Ա����ס֤���ڣ��ڸþ�ס֤����ǰdays�죬���Է�Email�������²��ź�Ա �����˾�ס֤��������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoEmployeeResidenceDateRearchFacade(DateTime currDate, int days)
        {
            new AutoEmployeeResidenceDateRearch(currDate, days).Excute();
        }
        /// <summary>
        /// Ա����ͬ����ǰdays����������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindContractFacade(DateTime currDate, int days)
        {
            new AutoRemindContract(currDate, days).Excute();
        }
        /// <summary>
        /// �µ��Զ�����Ա���˶Կ�������
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoRemindEmployeeConfirmAttendanceFacade(DateTime currDate)
        {
            new AutoRemindEmployeeConfirmAttendance(currDate).Excute();
        }
        /// <summary>
        /// ��ٵ���ǰdays�����Ѹ��ˣ���������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        public void AutoRemindVacationFacade(DateTime currDate, int days)
        {
            new AutoRemindVacation(currDate, days).Excute();
        }
        /// <summary>
        /// �Զ�������
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoAssessFacade(DateTime currDate)
        {
            new AutoAssess(currDate).Excute();
        }


        /// <summary>
        /// ���ݵ�ǰʱ���Զ��������
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
        /// �����趨��ʱ���Զ�����Ա�����
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
        /// �Զ���������ף����
        /// </summary>
        /// <param name="currDate"></param>
        public void AutoSendBirthdayMailFacade(DateTime currDate)
        {
            new AutoSendBirthdayMail(currDate).Excute();
        }
    }
}
