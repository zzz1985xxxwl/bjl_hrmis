using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class DetailTrainFBQuesAndItemPresenter
    {
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly ITrainFBQuestionAndItemView _View;
        private TrainFBQuestion _TrainFBQuestion;
        private int _FBQuestionID;
        public DetailTrainFBQuesAndItemPresenter(ITrainFBQuestionAndItemView view, int questionID)
        {
            _View = view;
            _FBQuestionID = questionID;
        }

        public void InitPresenter(bool isPostBack)
        {
            AttachViewEvent();
            _View.ResultMessage = string.Empty;
            _View.OperationType = TrainFBQuesAndItemUtility._DetailOperationTitle;
            _View.SetFormReadOnly = true;
            if (!isPostBack)
            {
                _View.FBQuestionMessage = string.Empty;
                _View.FBQuesTypeMessage = string.Empty;
                _View.TrainFBQuesTypeSource = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, string.Empty);
                _TrainFBQuestion = _ITrainFacade.GetFBQuestionByID(_FBQuestionID);
                _View.FBQuestion = _TrainFBQuestion.Description;
                _View.TrainFBQuesType = Convert.ToString(_TrainFBQuestion.TrainFBQuesType.ParameterID);
                _View.FBItemList = _TrainFBQuestion.FBItems;
            }
        }

        public void AttachViewEvent()
        {
            _View.btnOKClick += OKEvent;
            _View.btnSubmitClick += CancelEvent;
        }

        public void OKEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }
    }
}
