//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeContractListView.cs
// ������: ����
// ��������: 2008-06-20
// ����: Ա����ͬlist����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeContractListView
    {
        string ResultMessage { set;}
        List<Contract> EmployeeContract { set;}
        bool ButtonEnable { set;}
        string EmployeeName { set;}
        bool setGirdViewConlumn { set;}
    }
}
