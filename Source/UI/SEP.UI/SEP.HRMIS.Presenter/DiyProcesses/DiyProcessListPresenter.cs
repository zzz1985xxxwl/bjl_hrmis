using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessListPresenter
    {
        private readonly IDiyProcessFacade _IDiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();

        private readonly IDiyProcessListView _ItsView;
        public DiyProcessListPresenter(IDiyProcessListView view)
        {
            _ItsView = view;
        }

        public void InitView(bool isPagePostBack)
        {
            AttachViewEvent();

            if (!isPagePostBack)
            {
                GetDataSourceFromBll();
                _ItsView.DiyProcesss = _IDiyProcessFacade.GetDiyProcessByCondition(-1, "");
            }
        }

        private void GetDataSourceFromBll()
        {
            _ItsView.ProcessTypeSource = DiyProcessUtility.GetAllProcessType();
        }

        private void AttachViewEvent()
        {
            _ItsView.btnAddEvent += AddEvent;
            _ItsView.BtnDeleteEvent += DeleteEvent;
            _ItsView.BtnDetailEvent += DetailEvent;
            _ItsView.btnSearchEvent += SearchEvent;
            _ItsView.BtnUpdateEvent += UpdateEvent;
        }

        public event DelegateNoParameter GoToAddPage;
        public void AddEvent()
        {
            GoToAddPage();
        }

        public event DelegateID GoToDeletePage;
        public void DeleteEvent(string id)
        {
            GoToDeletePage(id);
        }

        public event DelegateID GoToDetailPage;
        public void DetailEvent(string id)
        {
            GoToDetailPage(id);
        }

        public event DelegateID GoToUpdatePage;
        public void UpdateEvent(string id)
        {
            GoToUpdatePage(id);
        }

        public void SearchEvent()
        {
            try
            {
                _ItsView.DiyProcesss = _IDiyProcessFacade.GetDiyProcessByCondition(_ItsView.ProcessType.Id,_ItsView.Name);
                _ItsView.Message = _ItsView.DiyProcesss.Count.ToString();
            }
            catch (Exception ex)
            {
                _ItsView.Message =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                    ex.Message;// +"</span>";
            }
        }
    }
}
