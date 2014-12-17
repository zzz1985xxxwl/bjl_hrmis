//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReadDataHistory.cs
// 创建者:刘丹
// 创建日期: 2008-10-15
// 概述: IReadDataHistory接口
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
