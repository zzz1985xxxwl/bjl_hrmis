//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeCardView.cs
// ������: ����
// ��������: 2008-08-06
// ����: Ա����Ƭ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeCardView
    {
        List<Employee> Employees { set;}
    }
}
