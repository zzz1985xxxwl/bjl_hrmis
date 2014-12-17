using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationConfirmListPresenter : PresenterCore.BasePresenter
    {
        private readonly ITrainApplicationConfirmListView _ItsView;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public TrainApplicationConfirmListPresenter(ITrainApplicationConfirmListView view, Account loginUser)
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
            _ItsView.ApplicationSource = _ITrainFacade.GetEmployeeReimbursingByLeadID(LoginUser.Id);
        }

        private void AttachViewEvent()
        {
            _ItsView.ApplicationDataBind += ApplicationDataBind;
        }

    }
}
