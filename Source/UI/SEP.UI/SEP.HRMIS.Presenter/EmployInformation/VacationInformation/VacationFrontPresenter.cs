
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class VacationFrontPresenter
    {
        private readonly IEmployeeInfoView _ItsView;

        public VacationFrontPresenter(IEmployeeInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheVacation(Employee employee)
        {
            _ItsView.VocationView.Employee = employee;
            _ItsView.VocationView.IsBack = false;
            if (employee.SocWorkAgeAndVacationList == null)
            {
                _ItsView.VocationView.SocietyWorkAge = "0";
            }
            else
            {
                _ItsView.VocationView.SocietyWorkAge = employee.SocWorkAgeAndVacationList.SocietyWorkAge.ToString();
            }

        }
    }
}
