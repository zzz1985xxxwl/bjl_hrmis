//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddUpdateDimissionPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �����޸���ְ��Ϣ���ܽ����Presenter�Ļ���
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations
{
    using FileCargoInfo;

    public class AddFileCargosPresenterBase
    {
        protected readonly IFileCargoInfoView _ItsView;
        private readonly IFileCargoFacade _IFileCargoFacade = InstanceFactory.CreateFileCargoFacade();
        public AddFileCargosPresenterBase(IFileCargoInfoView itsView)
        {
            _ItsView = itsView;
            SwitchFileCargoPresenter();
            AttachViewEvent();
        }
        /// <summary>
        /// ͨ���Ƿ���ID�����������޸�
        /// </summary>
        private void SwitchFileCargoPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.FileCargoView.Id))
            {
                new AddFileCargoPresenter(_ItsView.FileCargoView);
            }
            else
            {
                new UpdateFileCargoPresenter(_ItsView.FileCargoView, _ItsView.FileCargoView.Id);
            }
        }
        /// <summary>
        /// Ϊ������¼�
        /// </summary>
        private void AttachViewEvent()
        {
            //��ְ��Ϣ(�����)
            _ItsView.FileCargoListView.BtnAddFileCargoEvent += BtnAddFileCargoEvent;
            _ItsView.FileCargoListView.BtnDeleteFileCargoEvent += BtnDeleteFileCargoEvent;
            _ItsView.FileCargoListView.BtnUpdateFileCargoEvent += BtnUpdateFileCargoEvent;
            //��ְ��Ϣ(С����)
            _ItsView.FileCargoView.BtnActionEvent += BtnActionEvent;
            _ItsView.FileCargoView.BtnCancelEvent += BtnCancelEvent;
        }
        /// <summary>
        /// ȡ����С���治�ɼ�
        /// </summary>
        private void BtnCancelEvent()
        {
            _ItsView.FileCargoViewVisible = false;
        }
        /// <summary>
        /// ���ȷ������������ɹ���������б����°󶨣�С���治�ɼ����������ɹ���С������Ȼ�ɼ�
        /// </summary>
        private void BtnActionEvent()
        {
            if (_ItsView.FileCargoView.ActionSuccess)
            {
                _ItsView.FileCargoListView.FileCargoDataView = _IFileCargoFacade.GetFileCargoByAccountID(_ItsView.AccountID);
                _ItsView.FileCargoViewVisible = false;
            }
            else
            {
                _ItsView.FileCargoViewVisible = true;
            }
        }
        /// <summary>
        /// ����޸İ�ť
        /// </summary>
        /// <param name="id"></param>
        private void BtnUpdateFileCargoEvent(string id)
        {
            new UpdateFileCargoPresenter(_ItsView.FileCargoView, id).InitView();
            _ItsView.FileCargoViewVisible = true;
        }
        /// <summary>
        /// ���ɾ����ť
        /// </summary>
        /// <param name="id"></param>
        private void BtnDeleteFileCargoEvent(string id)
        {
            new DeleteFileCargoPresenter(_ItsView.FileCargoView).Delete(id);
            _ItsView.FileCargoListView.FileCargoDataView = _IFileCargoFacade.GetFileCargoByAccountID(_ItsView.AccountID) ;
        }
        /// <summary>
        /// ���������ť
        /// </summary>
        public void BtnAddFileCargoEvent()
        {
            new AddFileCargoPresenter(_ItsView.FileCargoView).InitView();
            _ItsView.FileCargoViewVisible = true;
        }
    }
}