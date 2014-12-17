using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IApplyAssessConditionView
    {
        bool FormReadonly { set;}
        string Message { set; }
        string ScopeMsg { set; }
        string ApplyDateMsg { set; }
        string Title { set; }
        string ApplyDate { get;set;}
        string ScopeFrom { get; set;}
        string ScopeTo { get;set;}
        string ApplyAssessConditionID { set; get;}

        ApplyAssessCondition ApplyAssessCondition { get; set;  }
        Dictionary<string, string> AssessCharacterTypes { set;}

    }
}
