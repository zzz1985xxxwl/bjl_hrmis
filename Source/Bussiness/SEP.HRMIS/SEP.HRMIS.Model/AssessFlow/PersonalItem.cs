//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalItem.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: Ա����д��
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա����д��
    /// </summary>
    [Serializable]
    public class PersonalItem : AssessActivityItem
    {
        /// <summary>
        /// Ա����д��
        /// </summary>
        /// <param name="question"></param>
        /// <param name="option"></param>
        /// <param name="classfication"></param>
        /// <param name="description"></param>
        public PersonalItem(string question, string option, ItemClassficationEmnu classfication, string description)
            : base(question, option, classfication, description)
        {
        }
    }
}
