//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CourseDataBinder.cs
// ������: ZZ
// ��������: 2008-11-13
// ����:��ѵ�γ��������ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface ICourseView
    {
        string Message { set; get;}

        string CourseNameMsg { set; get;}
        string PlaceMsg { set; get;}
        string CoordinatorMsg { set; get;}
        string TrainersMsg { set; get;}
        string EmployeeMsg { set; get;}
        string SkillsMsg { set; get;}
        string ExpectHourMsg { set; get;}
        string ExpectCostMsg { set; get;}

        string ExpectSTMsg { set; get;}
        string ExpectETMsg { set; get;}
        string ActualSTMsg { set; get;}
        string ActualETMsg { set; get;}
        string ActualHourMsg { set; get;}
        string ActualCostMsg { set; get;}

        string CourseName { set; get;}
        string Place { set; get;}
        string Coordinator { set; get;}
        string Trainer { get; set;}

        List<TrainScopeType> ScopeSource { get; set;}
        List<TrainStatusType> StatusSource { get; set;}

        //�����ʾ�
        List<FeedBackPaper> FeedBackPaperSource { set;}
        int PaperId { get; set;}

        string TrainScope { set; get;}
        string TrainStatus { set; get;}

        List<Account> EmployeeList { get; set;}
        List<Skill> SkillList { get; set;}
        string ChoosedEmployees { get; set;}
        string ChoosedSkills { get; set;}

        string ExpectST { set; get;}
        string ExpectET { set; get;}
        string ActualST { set; get;}
        string ActualET { set; get;}
        string ExpectHour { set; get;}
        string ActualHour { set; get;}
        string ExpectCost { set; get;}
        string ActualCost { set; get;}

        bool HasCertifaction { get; set;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        ///// <summary>
        ///// ȡ����ť�¼�
        ///// </summary>
        //event DelegateNoParameter CancelButtonEvent;

        bool ActionSuccess { get; set;}
        string OperationTitle { set; get;}
        string OperationType { set; get;}
        bool SetBtnhiden { set; get;}

        IChooseSkillView ChooseSkillView { get; set;}
        IChoseEmployeeView ChoseEmployeeView { get; set;}

        string SkillDisplay { set;}
    }
}
