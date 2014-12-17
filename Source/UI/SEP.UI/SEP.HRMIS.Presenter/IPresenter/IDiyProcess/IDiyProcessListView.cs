using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IDiyProcess
{
    public interface IDiyProcessListView
    {
        string Name{ get;}

        ProcessType ProcessType { get;}

        Dictionary<string, string> ProcessTypeSource{ set;}

        string Message{ get; set;}

        List<DiyProcess> DiyProcesss { get; set;}

        event DelegateNoParameter btnAddEvent;

        event DelegateNoParameter btnSearchEvent;

        event DelegateID BtnUpdateEvent;

        event DelegateID BtnDeleteEvent;

        event DelegateID BtnDetailEvent;
    }
}
