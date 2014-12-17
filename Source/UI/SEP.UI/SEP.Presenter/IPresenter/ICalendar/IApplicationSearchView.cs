//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IApplicationSearchView.cs
// ������: ���h��
// ��������: 2008-11-14
// ����: �ӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.Model.Departments;

namespace SEP.Presenter.IPresenter.ICalendar
{
    public interface IApplicationSearchView
    {
        string EmployeeName { get; set;}

        string DepartmentID { get; set;}

        string SearchFrom { get; set;}

        string SearchTo { get; set;}

        string Status { get; set;}

        string ApplicationType { get; set;}

        string Message { set; get;}

        string ErrorMessage { set; get;}

        string ErrorValidateTime { set; get;}

        List<Request> RequestList { set; get;}

        List<Department> DepartmentList { set; get;}

        List<ApplicationTypeEnum> ApplicationTypeEnumSourse { set; get;}

        List<RequestStatus> RequestStatusSourse { set; get;}

        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
