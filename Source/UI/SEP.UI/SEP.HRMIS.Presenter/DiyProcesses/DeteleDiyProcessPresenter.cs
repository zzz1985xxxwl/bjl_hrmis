using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DeteleDiyProcessPresenter : DiyProcessBasePresenter
    {
        private readonly IDiyProcessFacade _IDiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();

        protected readonly IDiyProcessView _View;
        public DeteleDiyProcessPresenter(IDiyProcessView view)
            : base(view)
        {
            _View = view;
        }

        protected override void InitPresenter()
        {
            _ItsView.OperationType = "删除自定义流程";
            new DiyProcessDataBinder(_ItsView).DataBind(DiyProcessID);
            ddlTypeSelected(null, null);
            new DiyProcessDataBinder(_ItsView).DataBindDiyStepList(DiyProcessID);
            _ItsView.SetFormReadOnly = true;
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += OKEvent;
            _ItsView.btnSubmitClick += CancelEvent;
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

        public void OKEvent(object source, EventArgs e)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                _IDiyProcessFacade.DeleteDiyProcess(DiyProcessID);
                GoToListPage();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                    ex.Message;// +"</span>";
            }
        }
    }
}
