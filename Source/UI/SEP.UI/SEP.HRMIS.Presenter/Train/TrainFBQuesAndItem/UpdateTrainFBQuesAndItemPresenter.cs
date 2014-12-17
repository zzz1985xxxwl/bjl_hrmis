using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.Presenter.Core;
namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class UpdateTrainFBQuesAndItemPresenter
    {
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly ITrainFBQuestionAndItemView _View;
        private int _FBQuestionID;

        public UpdateTrainFBQuesAndItemPresenter(ITrainFBQuestionAndItemView view, int questionID)
        {
            _View = view;
            _FBQuestionID = questionID;
        }

        public void InitPresenter(bool isPostBack)
        {
            AttachViewEvent();
            _View.ResultMessage = string.Empty;
            _View.OperationType = TrainFBQuesAndItemUtility._UpdateOperationTitle;
            _View.SetFormReadOnly = false;
            if (!isPostBack)
            {
                _View.FBQuestionMessage = string.Empty;
                _View.FBQuesTypeMessage = string.Empty;
                _View.TrainFBQuesTypeSource = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, string.Empty);
                TrainFBQuestion trainFBQuestion = _ITrainFacade.GetFBQuestionByID(_FBQuestionID);
                _View.FBQuestion = trainFBQuestion.Description;
                _View.TrainFBQuesType = Convert.ToString(trainFBQuestion.TrainFBQuesType.ParameterID);
                if (trainFBQuestion.FBItems.Count != 0)
                {
                    _View.FBItemList = trainFBQuestion.FBItems;
                }
                else
                {
                    _View.FBItemList = TrainFBQuesAndItemUtility.AddNullItem(new List<TrainFBItem>());
                }
            }
        }

        public void AttachViewEvent()
        {
            _View.btnOKClick += OKEvent;
            _View.btnSubmitClick += CancelEvent;
            TrainFBQuesAndItemEditor itemEditor = new TrainFBQuesAndItemEditor(_View);
            _View.TrainFBItemForAddAtEvent += itemEditor.TrainFBItemForAddAtEvent;
            _View.TrainFBItemForDeleteAtEvent += itemEditor.TrainFBItemForDeleteAtEvent;
            _View.ddlTrainFBItemChangedForUpEvent += itemEditor.TrainFBItemChangedForUpEvent;
            _View.ddlTrainFBItemChangedForDownEvent += itemEditor.TrainFBItemChangedForDownEvent;
        }
        
        public void OKEvent(object source, EventArgs e)
        {
            if (new TrainFBQuesAndItemValidater(_View).Vaildate())
            {
                try
                {
                    _View.ResultMessage = string.Empty;
                    TrainFBQuesType fBQuesType =
                        _ITrainFacade.GetTrainFBQuesTypeByPKID(Convert.ToInt32(_View.TrainFBQuesType));
                    TrainFBQuestion fBQuestion = new TrainFBQuestion(_FBQuestionID, _View.FBQuestion, fBQuesType,
                                                                     _View.FBItemList);
                    _ITrainFacade.UpdateTrainFBQuestion(fBQuestion);

                    GoToListPage();
                }
                catch (Exception ex)
                {
                    _View.ResultMessage =
                        //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                        ex.Message;// +"</span>";
                }
            }
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

    }
}
