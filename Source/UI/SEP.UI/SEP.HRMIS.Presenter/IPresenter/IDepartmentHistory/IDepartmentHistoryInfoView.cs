//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IDepartmentHistoryInfoView.cs
// ������: ���h��
// ��������: 2008-11-13
// ����: ����IDepartmentHistoryInfoView
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentHistoryInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IDepartmentHistoryListView DepartmentHistoryListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        //IDepartmentView DepartmentView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool DepartmentViewVisible { get;set;}
    }
}

