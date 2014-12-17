using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.HRMIS.Presenter.Parameter.FBQuesType.FBQuesTypeDetailPresenter
{
    public class AddFBQuesTypeDetailPresenter
    {
        private readonly IFBQuesTypeView _ItsView;
        //private AddFBQuesType _AddFBType;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private TrainFBQuesType _TrainFBQuesType;

        public AddFBQuesTypeDetailPresenter(IFBQuesTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        public void InitView(bool isPostBack)
        {
            _ItsView.ResultMessage = string.Empty;
            if (!isPostBack)
            {
                _ItsView.FBQuesTypeName = string.Empty;
                _ItsView.FBQuesTypeID = string.Empty;
                _ItsView.Title = "新增反馈问题类型";
                _ItsView.OperationType = "Add";
                _ItsView.SetIDReadonly = true;
                _ItsView.SetNameReadonly = false;

            }
        }

        private void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void AddEvent()
        {
            if (Validate())
            {
                _TrainFBQuesType = new TrainFBQuesType(1, _ItsView.FBQuesTypeName);

                try
                {
                    _ITrainFacade.AddFBQuesType(_TrainFBQuesType);
                    _ItsView.ActionSuccess = true;
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage = ex.Message;
                }
            }
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(_ItsView.FBQuesTypeName))
            {
                _ItsView.NameMessage = "不可为空";
                return false;

            }
            else
            {
                _ItsView.NameMessage = string.Empty;
                return true;
            }
        }
    }

}
