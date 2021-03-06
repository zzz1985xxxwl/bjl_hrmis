using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train
{
    public class FeedBackPaperUpdatePresenter : BasePresenter
    {
         private readonly int _PaperId;
        //private readonly ITemplatePaperView _ITemplatePaperView;
        //private readonly IAssessManagementFacade _IAssessManagementFacade;
                private readonly IFeedBackPaperView _ITemplatePaperView;
        private readonly ITrainFacade _ITrainFacade;
        private readonly IFeedBackPaperFacade _IPaperFacade;

        public bool Validation()
        {
            _ITemplatePaperView.ValidatePaperName = "";

            if (string.IsNullOrEmpty(_ITemplatePaperView.TemplatePaperName))
            {
                _ITemplatePaperView.ValidatePaperName = "反馈问卷的名称不能为空";
                return false;
            }
            if (_ITemplatePaperView.TemplatePaperName.Length > 50)
            {
                _ITemplatePaperView.ValidatePaperName = "反馈问卷名称不能超过50个字符";
                return false;
            }
            return true;
        }

        private void UpdateEvent()
        {
            if (!Validation())
                return;

            try
            {
                List<TrainFBQuestion> items = new List<TrainFBQuestion>();
                for (int i = 0; i < _ITemplatePaperView.QuestionList.Count; i++)
                {
                    if (_ITemplatePaperView.QuestionList[i].FBQuestioniD != -1)
                    {
                        items.Add(_ITemplatePaperView.QuestionList[i]);
                    }
                }
                Model.FeedBackPaper paper = new Model.FeedBackPaper();
                paper.FeedBackPaperId = _PaperId;
                paper.FeedBackPaperName = _ITemplatePaperView.TemplatePaperName;
                paper.FBQuestions = items;
                _IPaperFacade.UpdateFeedBackPaper(paper);
                _ITemplatePaperView.ActionSuccess = true;
                ToAccountSetListPage();
            }
            catch (Exception ex)
            {
                _ITemplatePaperView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }


        public FeedBackPaperUpdatePresenter(int paperId, IFeedBackPaperView view, Account loginUser)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _PaperId = paperId;
            _ITrainFacade = InstanceFactory.CreateTrainFacade();
            _IPaperFacade = InstanceFactory.CreateFeedBackPaperFacade();
        }

        public FeedBackPaperUpdatePresenter(int paperId, IFeedBackPaperView view, Account loginUser, ITrainFacade iFacade)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _PaperId = paperId;
            _ITrainFacade = iFacade;
        }

        public event DelegateNoParameter CancelEvent;
        public event DelegateNoParameter ToAccountSetListPage;

        public override void Initialize(bool isPostBack)
        {
            _ITemplatePaperView.ResultMessage = string.Empty;
            _ITemplatePaperView.ValidatePaperName = string.Empty;
            _ITemplatePaperView.QuestionItems = _ITrainFacade.GetFBQuestionByConditon(string.Empty, -1);

            _ITemplatePaperView.ActionButtonEvent += UpdateEvent;

            FeedBackQuestionEditor itemEditor = new FeedBackQuestionEditor(_ITemplatePaperView);
            _ITemplatePaperView.btnCopyEvent += itemEditor.btnCopyEvent;
            _ITemplatePaperView.btnPasteEvent += itemEditor.btnPasteEvent;
            _ITemplatePaperView.CancelButtonEvent += CancelEvent;
            _ITemplatePaperView.ddlAssessItemChangedForAddEvent += itemEditor.ddlChangedForAddEvent;
            _ITemplatePaperView.ddlAssessItemChangedForUpdateEvent += itemEditor.ddlChangedForUpdateEvent;
            _ITemplatePaperView.ddlAssessItemChangedForDeleteEvent += itemEditor.ddlChangedForDeleteEvent;
            _ITemplatePaperView.ddlAssessItemChangedForAddAtEvent += itemEditor.ddlAssessItemChangedForAddAtEvent;
            _ITemplatePaperView.ddlAssessItemChangedForUpEvent += itemEditor.ddlAssessItemChangedForUpEvent;
            _ITemplatePaperView.ddlAssessItemChangedForDownEvent += itemEditor.ddlAssessItemChangedForDownEvent;

            if (!isPostBack)
            {
                _ITemplatePaperView.OperationInfo = "修改反馈问卷";
                _ITemplatePaperView.OperationType = "Update";

                Model.FeedBackPaper paper = _IPaperFacade.GetFeedBackPaperById(_PaperId);
                _ITemplatePaperView.TemplatePaperName = paper.FeedBackPaperName;
                paper.FBQuestions.Add(new TrainFBQuestion(-1, string.Empty, new TrainFBQuesType(-1, string.Empty), new List<TrainFBItem>()));
                _ITemplatePaperView.QuestionList = paper.FBQuestions;
            }

            _ITemplatePaperView.SetbtnPasteVisible = _ITemplatePaperView.SessionCopyPaper != null;
        }
    }
}
