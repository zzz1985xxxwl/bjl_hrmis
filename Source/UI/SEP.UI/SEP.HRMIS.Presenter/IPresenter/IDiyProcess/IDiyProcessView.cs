using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IDiyProcess
{
    public interface IDiyProcessView
    {
        string ResultMessage{ get; set;}

        string NameMessage{ get; set;}

        string Name { get; set;}

        string Remark { get; set;}

        string OperationType { get; set;}

        string DiyProcessID { get; set;}

        ProcessType ProcessType { get; set;}

        Dictionary<string, string> ProcessTypeSource { get; set;}

        Dictionary<string, string> StatusSource { get; set;}

        Dictionary<string, string> SystemStatusSource { get; set;}

        Dictionary<string, string> OperatorSource { get; set;}

        List<Account> AccountList { get; set;}

        List<DiyStep> DiyStepList { get; set;}

        bool SetFormReadOnly { get; set;}

        event EventHandler ddlTypeSelected;

        event EventHandler btnOKClick;

        event EventHandler btnSubmitClick;

        event DelegateID ddlDiyStepChangedForDownEvent;

        event DelegateID ddlDiyStepChangedForUpEvent;

        event DelegateID DiyStepForDeleteAtEvent;

        event DelegateID DiyStepForAddAtEvent;
    }
}
