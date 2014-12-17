//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeListView.cs
// ������: ����
// ��������: 2008-06-17
// ����: ��ѯԱ������
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeListView
    {
        string ResultMessage { set;}
        string EmployeeName { get;}
        string ErrorMessage { set;}
        EmployeeTypeEnum EmployeeType { get;set;}

        Dictionary<string, string> EmployeeTypeSource { set;}
        List<Position> PositionSource { set;}
        List<GradesType> GradesSource { set; }
        List<Department> DepartmentSource { set;}

        int PositionId { get;}
        int? GradesId { get; }
        int DepartmentId { get;}

        bool RecursionDepartment { get; }

        string CompanyAgeFrom { get;}
        string CompanyAgeTo { get;}
        string CompanyAgeError { set;}
        string EmployeeStatusId { get;}
    }
}
