using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ITrainApplicationConfirmHistoryView
    {
        int ListCount { get;}

        List<TraineeApplication> ApplicationSource { set;}

        event DelegateNoParameter ApplicationDataBind;
    }
}
