using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface IMyTrainApplicationView
    {
        int ListCount { get;}

        int EmployeeID { get; set;}

        string ResultMessage { get; set;}
        List<TraineeApplication> ApplicationSource { set;}

        event DelegateNoParameter ApplicationDataBind;
        event DelegateID DeleteCommand;

    }
}
