//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ITrainApplicationView.cs
// ������: LIUDAN
// ��������: 2009-07-16
// ����:��ѵ����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ITrainApplicationView
    {
        bool SetEnable { set; get; }
        bool SetApprove{ set; get; }
        string Message { set; get; }
        string TrainApplicationID { set; get; }
        string CourseNameMsg { set; get; }
        string PlaceMsg { set; get; }
        string TrainersMsg { set; get; }
        string EmployeeMsg { set; get; }
        string SkillsMsg { set; get; }
        string STMsg { set; get; }
        string ETMsg { set; get; }
        string HourMsg { set; get; }
        string CostMsg { set; get; }
        string OrgnationMsg { set; get; }

        string CourseName { set; get; }
        string Place { set; get; }
        string Trainer { get; set; }
        string Orgnation { get; set; }
        string Skills { get; set; }
        List<TrainScopeType> ScopeSource { get; set; }

        string TrainScope { set; get; }

        List<Account> EmployeeList { get; set; }
        string ChoosedEmployees { get; set; }

        string StartTime { set; get; }
        string EndTime { set; get; }
        string Hour { set; get; }
        string Cost { set; get; }
        string EduSpuCost { get; set; }
        string EduSpuCostMsg { get; set; }

        bool HasCertifaction { get; set; }

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// �ݴ��¼�
        /// </summary>
        event DelegateNoParameter TempButtonEvent;

        /// <summary>
        /// ͨ����ť�¼�
        /// </summary>
        event DelegateNoParameter PassButtonEvent;

        /// <summary>
        /// �ܾ���ť�¼�
        /// </summary>
        event DelegateNoParameter FailButtonEvent;

        string ApproveRemark { get; set; }

        bool ActionSuccess { get; set; }
        string OperationTitle { set; get; }
        string OperationType { set; get; }

        IChoseEmployeeView ChoseEmployeeView { get; set; }

        string ApplierInfo { set; }
    }
}