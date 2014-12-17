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
                vacationBaseView.ValidateDayNum = "�����������Ϊ�գ�";
                validation = false;
            }
            if (String.IsNullOrEmpty(vacationBaseView.UsedDayNum))
            {
                vacationBaseView.ValidateUsedDayNum = "���������������Ϊ�գ�";
                validation = false;
            }
            if (String.IsNullOrEmpty(vacationBaseView.VacationStartDate))
            {
                vacationBaseView.ValidateStartDate = "��ٿ�ʼʱ�䲻��Ϊ�գ�";
                validation = false;
            }
            return validation;
        }
    }
}
