using System;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactDetailView
    {
        string Message { get; set;}
        string NameMsg { get; set;}

        string EmployeeID { get; set;}
        string LinkManName { get; set;}
        string MobileNo { get; set;}
        string HomeNo { get; set;}
        string OfficeNo { get; set;}
        string EmailAddr { get; set;}
        string OperationType { get; set;}
        bool ActionSuccess { get; set;}

        event EventHandler ActionButtonEvent;
        event EventHandler CancelButtonEvent;
    }
}