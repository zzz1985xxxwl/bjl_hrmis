using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest
{
    public interface IEmployeeAdjustRestView
    {
        string Message { set;}
        string SurplusHours{ set;}
        string EmployeeName { set;}
        int AccountID { set;}
        List<AdjustRestHistory> AdjustRestHistorySource { set;}
    }
}
