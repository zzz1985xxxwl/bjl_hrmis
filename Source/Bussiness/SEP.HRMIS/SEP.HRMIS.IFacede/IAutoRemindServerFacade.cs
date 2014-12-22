using System;
using System.Collections.Generic;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// �Զ�����ҵ��
    /// </summary>
    public interface IAutoRemindServerFacade
    {
        /// <summary>
        /// �Զ�����Ա��n��������ڵ���,��������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindProbationDateRearch(DateTime currDate, int days);
        /// <summary>
        /// �Զ�����Ա����ס֤���ڣ��ڸþ�ס֤����ǰdays�죬���Է�Email�������²��ź�Ա �����˾�ס֤��������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoEmployeeResidenceDateRearchFacade(DateTime currDate, int days);
        /// <summary>
        /// Ա����ͬ����ǰdays��������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindContractFacade(DateTime currDate, int days);
        /// <summary>
        /// �µ��Զ�����Ա���˶Կ�������
        /// </summary>
        /// <param name="currDate"></param>
        void AutoRemindEmployeeConfirmAttendanceFacade(DateTime currDate);
        /// <summary>
        /// ��ٵ���ǰdays���Ѹ��ˣ���������
        /// </summary>
        /// <param name="currDate"></param>
        /// <param name="days"></param>
        void AutoRemindVacationFacade(DateTime currDate, int days);
        /// <summary>
        /// �Զ�������
        /// </summary>
        /// <param name="currDate"></param>
        void AutoAssessFacade(DateTime currDate);
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
        void AutoCreateVacation(DateTime date, int createAnnualHolidayMonth,
            int annualHolidayLow, int annualHolidayHigh, int deferredMonths,
            int inComanyMonth, int createAnnualHolidayDay);

        ///<summary>
        /// �����趨��ʱ���Զ�����Ա�����
        ///</summary>
        ///<param name="date"></param>
        ///<param name="dateList"></param>
        void AutoRemindVacationSendEmail(DateTime date, List<DateTime> dateList);

        /// <summary>
        /// ���ݵ�ǰʱ�����1��֮ǰδ��������˵ı�����
        /// </summary>
        void AutoRemindReimburse();

        /// <summary>
        /// �Զ���������ף����
        /// </summary>
        /// <param name="currDate"></param>
        void AutoSendBirthdayMailFacade(DateTime currDate);
    }
}
