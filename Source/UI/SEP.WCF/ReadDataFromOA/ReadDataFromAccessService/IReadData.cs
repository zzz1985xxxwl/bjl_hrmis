//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// �ļ���: IReadData.cs
// ������: ����
// ��������: 2008-12-01
// ����: ��ACCESS�����ݽӿ�
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
