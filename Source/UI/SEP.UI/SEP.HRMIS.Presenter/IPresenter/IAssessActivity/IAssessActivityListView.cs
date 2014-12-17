//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAssessActivityListView.cs
// ������: ���޾�
// ��������: 2008-06-23
// ����: ��ѯ�����
// ----------------------------------------------------------------
using System.Collections.Generic;
using Framework.Common.DataAccess;
using SEP.Model.Departments;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IAssessActivityListView
    {
        bool btnExportAnnualAssessVisible{ set;}
        string Message { set;}
        string EmployeeName { get;}
        string CharacterType { get;}
        string StatusType { get;}
        string HRSubmitTimeMsg { set; }
        string HRSubmitTimeFrom { get;}
        string HRSubmitTimeTo { get;}
        object AssessActivityId { get;}

        hrmisModel.Employee Employee { set; }
        Dictionary<string, string> CharacterTypeSource { set;}
        Dictionary<string, string> StatusTypeSource { set;}

        List<hrmisModel.AssessActivity> AssessActivitysToList { get; set;}

        string ScopeTimeFrom { get; }
        string ScopeTimeTo { get; }

        string ScopeTimeMsg { set; }

        int FinishStatus { get; }

        int DepartmentID { get; }

        PagerEntity pagerEntity { get; }
        List<Department> DepartmentSource { set; }
    }

}
