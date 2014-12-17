//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkType.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// �Ӱ�����
    /// </summary>
    public enum OverWorkType
    {
        /// <summary>
        /// ����
        /// </summary>
        All = -1,

        /// <summary>
        /// ��ͨ�Ӱ�
        /// </summary>
        PuTong = 0,

        /// <summary>
        /// ��Ϣ�ռӰ�
        /// </summary>
        ShuangXiu = 1,

        /// <summary>
        /// ���ռӰ�
        /// </summary>
        JieRi = 2,

         /// <summary>
        /// ��ͨ�Ӱ��޵���
        /// </summary>
        PuTongNotAdjust = 50,

        /// <summary>
        /// ��Ϣ�ռӰ��޵���
        /// </summary>
        ShuangXiuNotAdjust = 51,

        /// <summary>
        /// ���ռӰ��޵���
        /// </summary>
        JieRiNotAdjust = 52

    }
}