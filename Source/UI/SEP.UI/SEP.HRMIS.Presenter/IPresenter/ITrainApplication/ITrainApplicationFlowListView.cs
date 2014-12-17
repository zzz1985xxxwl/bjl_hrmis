using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ITrainApplicationFlowListView
    {
        List<TraineeApplicationFlow> TraineeApplicationFlowListSource { set;}

        event EventHandler BindTraineeApplicationFlowListSource;
    }
}
