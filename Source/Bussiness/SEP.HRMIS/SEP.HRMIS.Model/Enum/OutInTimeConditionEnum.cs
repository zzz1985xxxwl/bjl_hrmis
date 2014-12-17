//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: OutInTimeConditionEnum.cs
// ������: wangyueqi
// ��������: 2008-10-16
// ����: ����ʱ������
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    public enum OutInTimeConditionEnum
    {
        /// <summary>
        /// ȫ��
        /// </summary>
        All=-1,
        /// <summary>
        /// ����ʱ��Ϊ��
        /// </summary>
        InTimeIsNull = 0,
        /// <summary>
        /// �뿪ʱ��Ϊ��
        /// </summary>
        OutTimeIsNull = 1,
        /// <summary>
        /// ����ʱ��Ϊ�ղ����뿪ʱ��Ϊ��
        /// </summary>
        InAndOutTimeIsNull = 2,
        /// <summary>
        /// ����ʱ��Ϊ�ջ����뿪ʱ��Ϊ��
        /// </summary>
        InOrOutTimeIsNull = 3,
        /// <summary>
        /// ����ʱ��Ϊ�ջ����뿪ʱ��ֻ��һ��Ϊ��
        /// </summary>
        InOrOutTimeOnlyOneIsNull = 4,
    }
}

