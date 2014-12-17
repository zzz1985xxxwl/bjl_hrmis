//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IInAndOutStatisticsBuildView.cs
// ������: ���h��
// ��������: 2008-10-17
// ����: �ӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics
{
    public interface IInAndOutStatisticsBuildView
    {
        /// <summary>
        /// �����
        /// </summary>
        IInAndOutStatisticsView InAndOutStatisticsView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        IReadAttendanceRuleView ReadAttendanceRuleView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        IReadHistoryListView ReadHistoryListView { get;set;}
        ///// <summary>
        ///// С����
        ///// </summary>
        //ICreateAttendanceForOperator CreateAttendanceForOperatorView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool ReadAttendanceRuleViewVisible { get;set;}
        bool ReadHistoryListViewVisible { get;set;}
        bool CreateAttendanceForOperatorViewVisible { get;set;}


        #region for ICreateAttendanceForOperator
        Account LoginUser { get; set;}
        string Message { set;}
        string SearchFrom { get;}
        string SearchTo { get;}
        /// <summary>
        /// ��XSL��ȡ�¼�
        /// </summary>
        event DelegateID BtnReadFromXLSEvent;
        /// <summary>
        /// ȡ��
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;

        event DelegateNoParameter ShowCreateAttendanceForOperator;

        /// <summary>
        /// С����
        /// </summary>
        IChoseEmployeeView ChoseEmployeeView { get; set;}
        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool IChoseEmployeeViewVisible { get; set;}
        List<Account> EmployeeList { get; set;}
        #endregion
    }
}
