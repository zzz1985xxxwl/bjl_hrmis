using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationFlowListPresenter
    {
        private readonly ITraineeApplicationFacade _ITraineeApplicationFacade = InstanceFactory.CreateTraineeApplicationFacade();

        private readonly ITrainApplicationFlowListView _View;
        public TrainApplicationFlowListPresenter(ITrainApplicationFlowListView view, int traineeApplicationID)
        {
            _View = view;
            _TraineeApplicationID = traineeApplicationID;
            AttachViewEvent();
        }

        private readonly int _TraineeApplicationID;

        public void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                BindTraineeApplicationFlowListSource(null, null);
            }
        }

        /// <summary>
        /// 数据源绑定
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void BindTraineeApplicationFlowListSource(object source, EventArgs e)
        {
            _View.TraineeApplicationFlowListSource = _ITraineeApplicationFacade.GetTraineeApplicationFlowByTraineeApplicationID(_TraineeApplicationID);
        }

        private void AttachViewEvent()
        {
            _View.BindTraineeApplicationFlowListSource += BindTraineeApplicationFlowListSource;
        }

    }
}
