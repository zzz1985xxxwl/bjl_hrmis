//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ICalculateScore.cs
// ������: �ߺ�
// ��������: 2008-05-23
// ����: ���ڼ���AssessActivity�ķ�ֵ
// ----------------------------------------------------------------

namespace SEP.HRMIS.Bll.AssessActivity
{
    public interface ICalculateScore
    {
        decimal CalculateScores(Model.AssessActivity assessActivity);
    }
}
