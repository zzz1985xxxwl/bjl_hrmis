//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IDepartmentHistoryListView.cs
// ������: ���h��
// ��������: 2008-11-13
// ����: ����IDepartmentHistoryListView
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.IDepartments
{
    public interface IDepartmentHistoryListView
    {
        string Message { set; get;}
        string SearchTime { set; get;}
        bool IsShowSearchTime { set; }
        string Title { set; }
        List<Department> Departments { set; get;}
         /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
