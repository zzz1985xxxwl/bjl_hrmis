using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.AssessManagement
{
    public class TemplatePaperDeletePresenter : BasePresenter
    {
        private readonly int _TemplatePaperId;
        private readonly ITemplatePaperView _ITemplatePaperView;
        private readonly IAssessManagementFacade _IAssessManagementFacade;

        private void DeleteEvent()
        {
            //执行事务过程
            try
            {
                _IAssessManagementFacade.DeleteAssessTemplatePaper(_TemplatePaperId);
                _ITemplatePaperView.ActionSuccess = true;
                ToAccountSetListPage();
            }
            catch (ApplicationException ex)
            {
                _ITemplatePaperView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public TemplatePaperDeletePresenter(int paperId, ITemplatePaperView view, Account loginUser)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _TemplatePaperId = paperId;
            _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        }

        public TemplatePaperDeletePresenter(int paperId, ITemplatePaperView view, Account loginUser, IAssessManagementFacade iFacade)
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

            _ITemplatePaperView.ActionButtonEvent += DeleteEvent;
            _ITemplatePaperView.CancelButtonEvent += CancelEvent;

            TemplageItemEditor itemEditor = new TemplageItemEditor(_ITemplatePaperView);
            _ITemplatePaperView.btnCopyEvent += itemEditor.btnCopyEvent;

            if (!isPostBack)
            {
                _ITemplatePaperView.OperationInfo = "删除绩效考核表";
                _ITemplatePaperView.OperationType = "Delete";

                AssessTemplatePaper paper = _IAssessManagementFacade.GetTempletPaperAndItemById(_TemplatePaperId);
                _ITemplatePaperView.TemplatePaperName = paper.PaperName;
                _ITemplatePaperView.PositionList = paper.PositionList;
                _ITemplatePaperView.AssessItemList = paper.ItsAssessTemplateItems;
                _ITemplatePaperView.SetFormReadOnly = true;
            }
        }

        public event DelegateNoParameter CancelEvent;
        public event DelegateNoParameter ToAccountSetListPage;
    }
}
