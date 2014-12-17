//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// 文件名: IReadData.cs
// 创建者: 刘丹
// 创建日期: 2008-12-01
// 概述: 从ACCESS读数据接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ReadDataAccessModel;

namespace ReadDataFromAccessService
{
    [ServiceContract]
    public interface IReadData
    {
        [OperationContract]
        List<DataFromAccess> ReadRecords(DateTime lastReadTime);

        [OperationContract]
        List<DataFromAccess> ReadRecordsWithReadTime(DateTime readFromTime, DateTime readToTime); 
    }
}
