using System;
//using System.Collections.Generic;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class AddDiyProcessPresenter : DiyProcessBasePresenter
    {
        private readonly IDiyProcessFacade _IDiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();

        protected readonly IDiyProcessView _View;
        public AddDiyProcessPresenter(IDiyProcessView view):base(view)
        {
            _View = view;
        }

        protected override void InitPresenter()
        {
            _ItsView.OperationType = "新增自定义流程";
            _ItsView.DiyStepList = DiyProcessUtility.AddNullItem(_View.ProcessType.Id, new List<DiyStep>());
        }

        protected override void AttachViewEvent()
        {
            _ItsView.btnOKClick += OKEvent;
            _ItsView.btnSubmitClick += CancelEvent;
            DiyProcessEditor itemEditor = new DiyProcessEditor(_ItsView);
            _ItsView.DiyStepForAddAtEvent += itemEditor.DiyStepForAddAtEvent;
            _ItsView.DiyStepForDeleteAtEvent += itemEditor.DiyStepForDeleteAtEvent;
            _ItsView.ddlDiyStepChangedForUpEvent += itemEditor.DiyStepChangedForUpEvent;
            _ItsView.ddlDiyStepChangedForDownEvent += itemEditor.DiyStepChangedForDownEvent;
        }

        public event DelegateNoParameter GoToListPage;
        public void CancelEvent(object source, EventArgs e)
        {
            GoToListPage();
        }

        public void OKEvent(object source, EventArgs e)
        {
            DiyProcessValidater diyProcessValidater = new DiyProcessValidater(_ItsView);
            if (diyProcessValidater.Vaildate())
            {
                try
                {
                    _ItsView.ResultMessage = string.Empty;
                    DiyProcessDataCollector dataCollector = new DiyProcessDataCollector(_ItsView);
                    DiyProcess diyProcess = new DiyProcess();
                    dataCollector.CompleteTheObject(ref diyProcess);

                    _IDiyProcessFacade.AddDiyProcess(diyProcess);

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
}
