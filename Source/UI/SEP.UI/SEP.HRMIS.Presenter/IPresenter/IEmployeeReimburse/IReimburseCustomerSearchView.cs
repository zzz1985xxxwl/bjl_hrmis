//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReimburseCustomerSearchView.cs
// ������: ����
// ��������: 2009-09-07
// ����: ��ӳ���ͻ���ѯ����
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using Framework.Common.DataAccess;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseCustomerSearchView
    {
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        string ReimburseCategoriesEnumID { set; get;}

        Dictionary<string, string> ReimburseStatus { get; set; }
        string SelectedReimburseStatus { get; }
        string Message { get; set; }

        string ApplyDateMsg { get; set; }


        string ApplyDateFrom { get; set; }

        string ApplyDateTo { get;set; }

        string TotalCostFrom { get; set;}

        string TotalCostTo { get; set;}

        string TotalCostMsg { get; set; }

        List<Department> DepartmentSource { get; set; }

        List<Reimburse> ReimburseListSource { get; set;}

        string EmployeeName { get; set;}

        string DepartmentID { get; }

        int SelectedFinishStatus { get; }

        event EventHandler btnSearchClick;

        int SelectedIsCustomerFilled { get;}

        PagerEntity PagerEntity { get; }

    }
}
