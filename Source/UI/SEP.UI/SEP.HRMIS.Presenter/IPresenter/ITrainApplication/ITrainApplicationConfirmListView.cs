using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;
using System.Web.UI.WebControls;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ITrainApplicationConfirmListView
    {
        int ListCount { get;}

        List<TraineeApplication> ApplicationSource { set;}

        event DelegateNoParameter ApplicationDataBind;

        event CommandEventHandler QuickPassEvent;

        //event CommandEventHandler btnApproveClick;

        event DelegateID _ShowWindowForConfirmOperation;
    }
}
