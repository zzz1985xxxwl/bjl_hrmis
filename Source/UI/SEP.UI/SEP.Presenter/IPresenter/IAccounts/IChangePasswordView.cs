using System;

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface IEmployeeUpdatePasswordView
    {
        string Message { set;}
        string OldPasswordMsg { set;}
        string ValidatPasswordMsg { set;}
        string ConfirmPasswordMsg { set;}

        string EmployeeName { get; set;}
        string EmployeeOldPassword { get; set;}
        string EmployeeNewPassword { get; set;}
        string EmployeeConfirmPassword { get; set;}

        event EventHandler btnOKClick;
    }
}
