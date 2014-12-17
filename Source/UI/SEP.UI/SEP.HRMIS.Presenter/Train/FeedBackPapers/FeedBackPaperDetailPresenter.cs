using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train
{
    public class FeedBackPaperDetailPresenter : BasePresenter
    {
        private readonly int _PaperId;
        private readonly IFeedBackPaperView _ITemplatePaperView;
        private readonly ITrainFacade _ITrainFacade;
        private readonly IFeedBackPaperFacade _IPaperFacade;


        public FeedBackPaperDetailPresenter(int paperId, IFeedBackPaperView view, Account loginUser)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _PaperId = paperId;
            _ITrainFacade = InstanceFactory.CreateTrainFacade();
            _IPaperFacade = InstanceFactory.CreateFeedBackPaperFacade();
        }

        public FeedBackPaperDetailPresenter(int paperId, IFeedBackPaperView view, Account loginUser, ITrainFacade iFacade)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _PaperId = paperId;
            _ITrainFacade = iFacade;
        }

        public override void Initialize(bool isPostBack)
        {
            _ITemplatePaperView.ResultMessage = string.Empty;
            _ITemplatePaperView.ValidatePaperName = string.Empty;
            _ITemplatePaperView.QuestionItems = _ITrainFacade.GetFBQuestionByConditon(string.Empty, -1);

            _ITemplatePaperView.ActionButtonEvent += CancelEvent;
            _ITemplatePaperView.CancelButtonEvent += CancelEvent;

            FeedBackQuestionEditor itemEditor = new FeedBackQuestionEditor(_ITemplatePaperView);
            _ITemplatePaperView.btnCopyEvent += itemEditor.btnCopyEvent;

            if (!isPostBack)
            {
                _ITemplatePaperView.OperationInfo = "查看反馈问卷";
                _ITemplatePaperView.OperationType = "Detail";

                Model.FeedBackPaper paper = _IPaperFacade.GetFeedBackPaperById(_PaperId);
                _ITemplatePaperView.TemplatePaperName = paper.FeedBackPaperName;
                _ITemplatePaperView.QuestionList = paper.FBQuestions;
                _ITemplatePaperView.SetFormReadOnly = true;
            }
        }
        public event DelegateNoParameter CancelEvent;
    }
}

