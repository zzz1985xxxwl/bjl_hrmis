using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.Model.Accounts;
namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationUpdatePresenter
    {
        private readonly ITrainApplicationView _ItsView;
        private readonly ITraineeApplicationFacade _ITraineeApplicationFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public TraineeApplication _ANewObject;
        private readonly Account _LoginUser;

        public TrainApplicationUpdatePresenter(ITrainApplicationView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += SubmitEvent;
            _ItsView.TempButtonEvent += UpdateEvent;
        }

        public void InitView(string id,bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = TrainApplicationUtilityPresenter.UpdatePageTitle;
            _ItsView.OperationType = TrainApplicationUtilityPresenter.UpdateOperationType;
            new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).Init(id, isPostBack);
        }

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).Vaildation())
            {
                return;
            }
            //数据收集过程
            _ANewObject = new TraineeApplication();
            new TrainApplicationDataCollecter(_ItsView, _LoginUser).CompleteTheObject(_ANewObject);
            try
            {
                _ANewObject.PKID =Convert.ToInt32(_ItsView.TrainApplicationID);
                _ANewObject.TraineeApplicationStatuss = TraineeApplicationStatus.New;
                _ITraineeApplicationFacade.UpdateTraineeApplication(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        public void SubmitEvent()
        {
            //数据验证过程
            if (!new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).Vaildation())
            {
                return;
            }
            //数据收集过程
            _ANewObject = new TraineeApplication();
            new TrainApplicationDataCollecter(_ItsView, _LoginUser).CompleteTheObject(_ANewObject);
            try
            {
                _ANewObject.PKID = Convert.ToInt32(_ItsView.TrainApplicationID);
                _ANewObject.TraineeApplicationStatuss = TraineeApplicationStatus.Submit;
                _ITraineeApplicationFacade.UpdateTraineeApplication(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        public ITraineeApplicationFacade SetITraineeApplicationFacade
        {
            get { return _ITraineeApplicationFacade; }
        }

    }
}
