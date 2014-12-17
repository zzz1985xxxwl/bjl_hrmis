//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IVacationUsedDetailsView.cs
// ������: xue.wenlong
// ��������: 2008-11-04
// ����: ���ʹ�����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter
{
    public interface IVacationUsedDetailsView
    {
        Employee Employee { get; set;}
        List<LeaveRequestItem> LeaveRequestItemList { get;set;}
    }
}
