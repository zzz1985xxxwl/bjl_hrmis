//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddUpdateDimissionPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-09-26
// ����: �����޸���ְ��Ϣ���ܽ����Presenter�Ļ���
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.FileCargoInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation
{
    public class AddUpdateDimissionPresenterBase
    {
        protected readonly IDimissionInfoView _ItsView;

        public AddUpdateDimissionPresenterBase(IDimissionInfoView itsView)
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
            _ItsView.DimmissionBasicView.BtnAddFileCargoEvent += BtnAddFileCargoEvent;
            _ItsView.DimmissionBasicView.BtnDeleteFileCargoEvent += BtnDeleteFileCargoEvent;
            _ItsView.DimmissionBasicView.BtnUpdateFileCargoEvent += BtnUpdateFileCargoEvent;
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
                _ItsView.DimmissionBasicView.FileCargoDataSource = _ItsView.FileCargoView.FileCargoDataSource;
                _ItsView.DimmissionBasicView.FileCargoDataView = _ItsView.DimmissionBasicView.FileCargoDataSource;
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
            _ItsView.DimmissionBasicView.FileCargoDataSource = _ItsView.FileCargoView.FileCargoDataSource;
            _ItsView.DimmissionBasicView.FileCargoDataView = _ItsView.DimmissionBasicView.FileCargoDataSource;
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