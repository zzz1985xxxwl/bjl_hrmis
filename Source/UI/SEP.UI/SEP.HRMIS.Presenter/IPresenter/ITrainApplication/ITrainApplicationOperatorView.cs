using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ITrainApplicationOperatorView
    {
        int EmployeeID { get; set;}

        string EmployeeName { get; set;}

        string ApplicationFlowID { get; set;}

        int TrainApplicationID { get; set;}

        string Remark { get; set;}

        string OperationType { get; set;}

        string Status { get; set;}

        Dictionary<string, string> StatusSource { set;}

        string ResultMessage { get; set;}

        string RemarkMessage { get; set;}

        event EventHandler btnOKClick;

        event EventHandler btnCancelClick;

        bool SetFormReadOnly { get; set;}

        bool SetStatusReadOnly { get; set;}

        string btnCancelOnClientClick { set;}
    }
}
