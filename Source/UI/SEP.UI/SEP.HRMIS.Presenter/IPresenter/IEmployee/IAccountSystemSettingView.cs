using System;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployee
{
    public interface IAccountSystemSettingView
    {
        int IfReceiveMessage { get; set;}

        int EmployeeID { get; set;}

        string Message { set;}

        event EventHandler btnOKClick;
    }
}
