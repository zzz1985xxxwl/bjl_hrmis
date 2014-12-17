//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentHistoryPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 增加DepartmentHistoryPresenter
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter;

namespace SEP.HRMIS.Presenter
{
    public class DepartmentHistoryPresenter
    {
        private readonly IDepartmentHistoryInfoView _ItsView;
        private readonly DepartmentHistoryListPresenter _TheBasicPresenter;

        public DepartmentHistoryPresenter(IDepartmentHistoryInfoView itsView)
        {
            _ItsView = itsView;
            _ItsView.DepartmentHistoryListView.Title = "组织架构管理";
            _ItsView.DepartmentHistoryListView.IsShowSearchTime = true;
            _TheBasicPresenter = new DepartmentHistoryListPresenter(itsView.DepartmentHistoryListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            //new DetailDepartmentPresenter(_ItsView.DepartmentView);
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.DepartmentHistoryListView.BtnDetailEvent += ShowDetailView;
            _ItsView.DepartmentHistoryListView.BtnSearchEvent += ShowSearchView;
            //小界面按钮
            //_ItsView.DepartmentView.ActionButtonEvent += ActionEvent;
            //_ItsView.DepartmentView.CancelButtonEvent += CancelEvent;
        }

       private void ShowDetailView(string id)
       {
           //new DetailDepartmentPresenter(_ItsView.DepartmentView).InitView(id);
           _ItsView.DepartmentViewVisible = true;
       }
       private void ShowSearchView()
       {
           new DepartmentHistoryListPresenter(_ItsView.DepartmentHistoryListView).DepartmentDataBind();
           _ItsView.DepartmentViewVisible = false;
       }
       
        public void ActionEvent()
        {
            //if (_ItsView.DepartmentView.ActionSuccess)
            //{
            //    _TheBasicPresenter.DepartmentDataBind();
            //    _ItsView.DepartmentViewVisible = false;
            //}
            //else
            //{
            //    _ItsView.DepartmentViewVisible = true;
            //}
        }

        public void CancelEvent()
        {
            _ItsView.DepartmentViewVisible = false;
        }
        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }
    }
}

