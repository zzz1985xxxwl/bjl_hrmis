using System;

namespace SEP.HRMIS.Presenter
{
    public class VacationBasePresenter
    {
        public static bool Validation(IVacationBaseView vacationBaseView)
        {
            bool validation = true;
            if (!vacationBaseView.ViewValidation)
            {
                validation = false;
            }
            if (String.IsNullOrEmpty(vacationBaseView.VacationDayNum))
            {
                vacationBaseView.ValidateDayNum = "年假天数不能为空！";
                validation = false;
            }
            if (String.IsNullOrEmpty(vacationBaseView.UsedDayNum))
            {
                vacationBaseView.ValidateUsedDayNum = "年假已用天数不能为空！";
                validation = false;
            }
            if (String.IsNullOrEmpty(vacationBaseView.VacationStartDate))
            {
                vacationBaseView.ValidateStartDate = "年假开始时间不能为空！";
                validation = false;
            }
            return validation;
        }
    }
}
