//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: OperateType.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: ��������
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model
{
    [Flags]
    public enum OperateType
    {
        ALL = -1,
        HR,
        NotHR
    }
}
