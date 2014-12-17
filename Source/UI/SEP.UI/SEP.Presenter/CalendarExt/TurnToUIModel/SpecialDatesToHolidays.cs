using System.Collections.Generic;
using SEP.Model.SpecialDates;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class SpecialDatesToHolidays
    {
        public static List<Holiday> Turn(List<SpecialDate> originalDataList)
        {
            List<Holiday> HolidayList = new List<Holiday>();
            foreach (SpecialDate originalData in originalDataList)
            {
                if (originalData.IsWork == 2)
                {
                    Holiday holiday = new Holiday(originalData.SpecialDateTime, originalData.SpecialHeader);
                    HolidayList.Add(holiday);
                }
            }
            return HolidayList;
        }
    }
}