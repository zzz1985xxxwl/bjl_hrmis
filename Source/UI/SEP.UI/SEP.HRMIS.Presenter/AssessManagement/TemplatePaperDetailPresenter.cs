using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.AssessManagement
{
    public class TemplatePaperDetailPresenter : BasePresenter
    {
        private readonly int _TemplatePaperId;
        private readonly ITemplatePaperView _ITemplatePaperView;
        private readonly IAssessManagementFacade _IAssessManagementFacade;


        public TemplatePaperDetailPresenter(int paperId, ITemplatePaperView view, Account loginUser)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _TemplatePaperId = paperId;
            _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        }

        public TemplatePaperDetailPresenter(int paperId, ITemplatePaperView view, Account loginUser, IAssessManagementFacade iFacade)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _TemplatePaperId = paperId;
            _IAssessManagementFacade = iFacade;
        }

        public override void Initialize(bool isPostBack)
        {
            _ITemplatePaperView.ResultMessage = string.Empty;
            _ITemplatePaperView.ValidatePaperName = string.Empty;
            _ITemplatePaperView.AssessItems = _IAssessManagementFacade.GetAllTemplateItems();

            _ITemplatePaperView.ActionButtonEvent += CancelEvent;
            _ITemplatePaperView.CancelButtonEvent += CancelEvent;

            TemplageItemEditor itemEditor = new TemplageItemEditor(_ITemplatePaperView);
            _ITemplatePaperView.btnCopyEvent += itemEditor.btnCopyEvent;

            if (!isPostBack)
            {
                _ITemplatePaperView.OperationInfo = "查看绩效考核表";
                _ITemplatePaperView.OperationType = "Detail";

                AssessTemplatePaper paper = _IAssessManagementFacade.GetTempletPaperAndItemById(_TemplatePaperId);
                _ITemplatePaperView.TemplatePaperName = paper.PaperName;
                _ITemplatePaperView.PositionList = paper.PositionList;
                _ITemplatePaperView.AssessItemList = paper.ItsAssessTemplateItems;
                _ITemplatePaperView.SetFormReadOnly = true;
            }
        }
        public event DelegateNoParameter CancelEvent;
    }
}
