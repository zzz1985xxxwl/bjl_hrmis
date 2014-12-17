using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class DeleteTrainFBQuesAndItemPresenter
    {
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly ITrainFBQuestionAndItemView _View;
        private int _FBQuestionID;

        public DeleteTrainFBQuesAndItemPresenter(ITrainFBQuestionAndItemView view, int questionID)
        {
            _View = view;
            _FBQuestionID = questionID;
        }

        public void InitPresenter(bool isPostBack)
        {
            AttachViewEvent();
            _View.ResultMessage = string.Empty;
            _View.OperationType = TrainFBQuesAndItemUtility._DeleteOperationTitle;
            _View.SetFormReadOnly = true;
            if (!isPostBack)
            {
                _View.FBQuestionMessage = string.Empty;
                _View.FBQuesTypeMessage = string.Empty;
                _View.TrainFBQuesTypeSource = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, string.Empty);
                TrainFBQuestion trainFBQuestion = _ITrainFacade.GetFBQuestionByID(_FBQuestionID);
                _View.FBQuestion = trainFBQuestion.Description;
                _View.TrainFBQuesType = Convert.ToString(trainFBQuestion.TrainFBQuesType.ParameterID);
                _View.FBItemList = trainFBQuestion.FBItems;

            }
        }

        public void AttachViewEvent()
        {
            _View.btnOKClick += OKEvent;
            _View.btnSubmitClick += CancelEvent;

        }

        public void OKEvent(object source, EventArgs e)
        {
            TrainFBQuestion trainFBQuestion = _ITrainFacade.GetFBQuestionByID(Convert.ToInt32(_FBQuestionID));
            try
            {
                _ITrainFacade.DeleteTrainFBQuestion(trainFBQuestion);
                GoToListPage();

            }
            catch (ApplicationException ae)
            {
                _View.ResultMessage = ae.Message;
            }
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }
    }
}
