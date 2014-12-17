using System.Collections.Generic;
using SEP.HRMIS.Model.SystemError;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ISystemError
{
    public interface ISystemErrorListPresenter
    {
        List<SystemError> SystemErrors { get; set; }
        bool ShowIgnore{ get; set;}
        event DelegateNoParameter SearchEvent;
        event Delegate2Parameter UpdateStatusEvent;
    }
}