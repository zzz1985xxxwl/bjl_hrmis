using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train
{
    public class FeedBackPaperListPresenter : BasePresenter
    {
        private IFeedBackPaperFacade _IPaperFacade;
        private readonly IFeedBackPaperListView _ItsView;

          /// <summary>
        /// ¸´ÖÆÊÂ¼þ
        /// </summary>
        private void btnCopyClick(string strAssessPaperId)
        {
            int assessPaperId;
            if (!int.TryParse(strAssessPaperId, out assessPaperId))
            {
                return;
            }
            _ItsView.SessionCopyPaper = _IPaperFacade.GetFeedBackPaperById(assessPaperId);
        }

        private void TemplatePaperDataBind()
        {
            List<FeedBackPaper> itsSource = _IPaperFacade.GetFeedBackPaperByPaperName(_ItsView.TemplatePaperName);
            _ItsView.FeedBackPapers = itsSource;
        }

        public event DelegateNoParameter btnAddClick;
        public event DelegateID btnUpdateClick;
        public event DelegateID btnDeleteClick;
        public event DelegateID btnDetailClick;

        public FeedBackPaperListPresenter(IFeedBackPaperListView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public FeedBackPaperListPresenter(IFeedBackPaperListView itsView, Account loginUser, IFeedBackPaperFacade iFacade)
            : this(itsView, loginUser)
        {
            _IPaperFacade = iFacade;
        }

        public override void Initialize(bool isPostBack)
        {
            _ItsView.BtnAddEvent += btnAddClick;
            _ItsView.BtnUpdateEvent += btnUpdateClick;
            _ItsView.BtnDeleteEvent += btnDeleteClick;
            _ItsView.BtnDetailEvent += btnDetailClick;
            _ItsView.BtnCopyEvent += btnCopyClick;
            _ItsView.BtnSearchEvent += TemplatePaperDataBind;

            _IPaperFacade = InstanceFactory.CreateFeedBackPaperFacade();
            if (!isPostBack)
            {
                TemplatePaperDataBind();
            }
        }
    }
}
