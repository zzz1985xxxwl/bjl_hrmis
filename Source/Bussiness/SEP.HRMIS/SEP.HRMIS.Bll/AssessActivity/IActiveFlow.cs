//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IActiveFlow.cs
// ������: �ߺ�
// ��������: 2008-05-23
// ����: �������̵Ľӿڣ�������Ϊstub����
// ----------------------------------------------------------------

using SEP.HRMIS.Model;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public interface IActiveFlow
    {
        hrmisModel.AssessActivity AssessActivity { get; set;}
        AssessStatus AssessStatus { get; set;}
        void ExcuteFlow();
        bool IsSubmit { get; set;}
    }
}
