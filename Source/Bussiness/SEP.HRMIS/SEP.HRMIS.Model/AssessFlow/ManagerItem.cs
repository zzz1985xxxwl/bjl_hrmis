//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ManagerItem.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: ������д��
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ������д��
    /// </summary>
    [Serializable]
    public class ManagerItem : AssessActivityItem
    {
        /// <summary>
        /// ������д��
        /// </summary>
        /// <param name="question"></param>
        /// <param name="option"></param>
        /// <param name="classfication"></param>
        /// <param name="description"></param>
        public ManagerItem(string question, string option, ItemClassficationEmnu classfication,string description)
            : base(question, option, classfication, description)
        {
        }
    }
}
