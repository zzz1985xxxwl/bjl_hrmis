//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReadDataHistory.cs
// ������:����
// ��������: 2008-10-15
// ����: IReadDataHistory�ӿ�
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;

namespace SEP.HRMIS.IDal
{
    public interface IReadDataHistory
    {
        int InsertReadDataHistory(ReadDataHistory history);
        int UpdateReadDataHistory(ReadDataHistory history);
        //for test
        int DeleteReadDataHistory(int pkid);
        List<ReadDataHistory> GetAllReadDataHistory();
        ReadDataHistory GetReadDataHistoryByPkid(int pkid);
        ReadDataHistory GetLastSuccessReadDataHistory();
        ReadDataHistory GetLastReadDataHistory();
    }
}
