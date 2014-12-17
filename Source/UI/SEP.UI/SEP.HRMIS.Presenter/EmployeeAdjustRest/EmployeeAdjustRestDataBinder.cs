using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest;

namespace SEP.HRMIS.Presenter.EmployeeAdjustRest
{
    public class EmployeeAdjustRestDataBinder
    {
        private readonly IEmployeeAttendanceFacade _IEmployeeAttendanceFacade =
            InstanceFactory.CreateEmployeeAttendanceFacade();
        private readonly IEmployeeAdjustRestView _ItsView;

        public EmployeeAdjustRestDataBinder(IEmployeeAdjustRestView itsView)
        {
            _ItsView = itsView;
        }

        public void DataBind(string accountID)
        {
            AdjustRest theDataToBind = _IEmployeeAttendanceFacade.GetAdjustRestByAccountID(Convert.ToInt32(accountID));
            if (theDataToBind != null)
            {
                _ItsView.SurplusHours = theDataToBind.SurplusHours.ToString();
                _ItsView.EmployeeName = theDataToBind.Employee.Account.Name;
                _ItsView.AdjustRestHistorySource = theDataToBind.AdjustRestHistoryList;
                _ItsView.AccountID = theDataToBind.Employee.Account.Id;
            }
        }
    }
}
