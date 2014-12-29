using SEP.HRMIS.Facade;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationConfirmHistoryPresenter : PresenterCore.BasePresenter
    {
        private readonly ITrainApplicationConfirmHistoryView _ItsView;
        private readonly TraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public TrainApplicationConfirmHistoryPresenter(ITrainApplicationConfirmHistoryView view,Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();

            if (!isPostBack)
            {
                ApplicationDataBind();
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void ApplicationDataBind()
        {
            _ItsView.ApplicationSource = _ITrainFacade.GetMyAuditingTraineeApplications(LoginUser.Id).TraineeApplicationList;
        }

        private void AttachViewEvent()
        {
            _ItsView.ApplicationDataBind += ApplicationDataBind;
        }
    }
}
