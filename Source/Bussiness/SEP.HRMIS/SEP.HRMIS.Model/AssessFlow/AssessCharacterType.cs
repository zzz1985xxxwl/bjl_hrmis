//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: CheckRule.cs
// ������:tang.manli
// ��������: 2008-05-20
// ����: ����������д��ö����
// ----------------------------------------------------------------
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������
    /// </summary>
    public enum AssessCharacterType
    {
        /// <summary>
        /// �������
        /// </summary>
        All = -1,
        /// <summary>
        /// ��ͬ��������
        /// </summary>
        NormalForContract,
        /// <summary>
        /// ��ͬ�����꿼��
        /// </summary>
        Normal,
        /// <summary>
        /// ������I
        /// </summary>
        ProbationI,
        /// <summary>
        /// ������II
        /// </summary>
        ProbationII,
        /// <summary>
        /// ʵϰ��I
        /// </summary>
        PracticeI,
        /// <summary>
        /// ʵϰ��II
        /// </summary>
        PracticeII,
        /// <summary>
        /// �ǳ��濼��
        /// </summary>
        Abnormal,
        /// <summary>
        /// ��
        /// </summary>
        None,
        /// <summary>
        /// ���տ���
        /// </summary>
        Annual,
    }
}
