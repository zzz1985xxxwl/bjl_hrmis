//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainStatusEnum.cs
// ������: ����
// ��������: 2008-11-09
// ����: ��ѵ״̬
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ״̬
    ///</summary>
    public enum TrainStatusEnum
    {
        ///<summary>
        ///</summary>
        All=-1,//������ѵ
        /// <summary>
        /// �ƻ�
        /// </summary>
        Plan,
        ///<summary>
        /// ��ʼ����ѵ
        ///</summary>
        Start, //��ʼ����ѵ
        ///<summary>
        /// ��������ѵ
        ///</summary>
        End, //��������ѵ
        ///<summary>
        /// �ж�
        ///</summary>
        Interrupt
    }
}
