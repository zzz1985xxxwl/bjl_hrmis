//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IFeedBackDetailView.cs
// ������: ����
// ��������: 2008-11-12
// ����: ������Ϣ�ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IFeedBackDetailView
    {

        bool Filled{ set;get; }
        List<TraineeFBItem> FBItem { get; set; }
        string CourseId { get; set;}
        string EmployeeId { get; set;}
        string ErrorMessage { set;}

        string CourseName { get;set;}
        string Trainee { get;set;}
        string Score { get;set;}
        string FBTime { get; set;}
        string Comment { get; set;}

        string PageTitle { set;}

        bool returnLastPage { set;}

        bool IsFrontPage { set;}

        /// <summary>
        ///ȷ����ť�¼�
        /// </summary>
        event DelegateNoParameter BtnOKEvent;

        bool IsCertificationDisplay { set;}

        string CertificationName { get; set;}

    }
}
