using System.Collections.Generic;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IManualAssessView
    {
        bool txtEmployeeNameReadOnly { set; }
        bool ddlCharacterEnabled { set;}
        bool FormReadonly { set;}
        string Message { set; }
        string ScopeMsg { set; }
        string ReasonMsg { set; }
        string ScopeFrom { get;}
        string ScopeTo { get;}
        string Reason { get;}

        hrmisModel.AssessActivity AssessActivityToManual { get; set;  }
        hrmisModel.Employee Employee { get; set; }
        Dictionary<string, string> AssessCharacterTypes { set;}
    }
}