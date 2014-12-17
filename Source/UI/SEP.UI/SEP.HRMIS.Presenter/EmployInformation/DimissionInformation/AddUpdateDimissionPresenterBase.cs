//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddUpdateDimissionPresenterBase.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增修改离职信息的总界面的Presenter的基类
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
        /// 通过是否有ID区分新增，修改
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
        /// 为界面绑定事件
        /// </summary>
        private void AttachViewEvent()
        {
            //离职信息(大界面)
            _ItsView.DimmissionBasicView.BtnAddFileCargoEvent += BtnAddFileCargoEvent;
            _ItsView.DimmissionBasicView.BtnDeleteFileCargoEvent += BtnDeleteFileCargoEvent;
            _ItsView.DimmissionBasicView.BtnUpdateFileCargoEvent += BtnUpdateFileCargoEvent;
            //离职信息(小界面)
            _ItsView.FileCargoView.BtnActionEvent += BtnActionEvent;
            _ItsView.FileCargoView.BtnCancelEvent += BtnCancelEvent;
        }
        /// <summary>
        /// 取消，小界面不可见
        /// </summary>
        private void BtnCancelEvent()
        {
            _ItsView.FileCargoViewVisible = false;
        }
        /// <summary>
        /// 点击确定后，如果操作成功，大界面列表重新绑定，小界面不可见；操作不成功，小界面仍然可见
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
        /// 点击修改按钮
        /// </summary>
        /// <param name="id"></param>
        private void BtnUpdateFileCargoEvent(string id)
        {
            new UpdateFileCargoPresenter(_ItsView.FileCargoView, id).InitView();
            _ItsView.FileCargoViewVisible = true;
        }
        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="id"></param>
        private void BtnDeleteFileCargoEvent(string id)
        {
            new DeleteFileCargoPresenter(_ItsView.FileCargoView).Delete(id);
            _ItsView.DimmissionBasicView.FileCargoDataSource = _ItsView.FileCargoView.FileCargoDataSource;
            _ItsView.DimmissionBasicView.FileCargoDataView = _ItsView.DimmissionBasicView.FileCargoDataSource;
        }
        /// <summary>
        /// 点击新增按钮
        /// </summary>
        public void BtnAddFileCargoEvent()
        {
            new AddFileCargoPresenter(_ItsView.FileCargoView).InitView();
            _ItsView.FileCargoViewVisible = true;
        }
    }
}