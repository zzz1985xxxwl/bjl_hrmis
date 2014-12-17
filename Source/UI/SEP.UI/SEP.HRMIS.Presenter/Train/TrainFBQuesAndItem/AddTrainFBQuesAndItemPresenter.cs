using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class AddTrainFBQuesAndItemPresenter
    {
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly ITrainFBQuestionAndItemView _View;

        public AddTrainFBQuesAndItemPresenter(ITrainFBQuestionAndItemView view)
        {
            _View = view;
        }

        public void InitPresenter(bool isPostBack)
        {
            AttachViewEvent();
            _View.ResultMessage = string.Empty;
            _View.OperationType = TrainFBQuesAndItemUtility._AddOperationTitle;
            _View.SetFormReadOnly = false;
            if (!isPostBack)
            {
                _View.FBQuestionMessage = string.Empty;
                _View.FBQuesTypeMessage = string.Empty;
                _View.FBQuestion = string.Empty;
                _View.FBQuestionID = string.Empty;
                _View.TrainFBQuesTypeSource = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, string.Empty);
                _View.FBItemList = TrainFBQuesAndItemUtility.AddNullItem(new List<TrainFBItem>());
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

                    TrainFBQuestion fBQuestion = new TrainFBQuestion(1, _View.FBQuestion, fBQuesType,
                                                                     _View.FBItemList);
                    _ITrainFacade.AddTrainFBQuestion(fBQuestion);

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
