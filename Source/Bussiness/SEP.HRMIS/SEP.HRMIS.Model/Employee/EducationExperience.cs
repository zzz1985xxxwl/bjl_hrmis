//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EducationExperience.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��������ѵ���� 
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������ѵ����
    /// </summary>
    [Serializable]
    public class EducationExperience : Experience
    {
        /// <summary>
        /// ��������ѵ�������캯��
        /// </summary>
        /// <param name="school"></param>
        /// <param name="experiencePeriod"></param>
        /// <param name="contect"></param>
        /// <param name="remark"></param>
        public EducationExperience(string school, string experiencePeriod, string contect, string remark)
            : base(school, experiencePeriod, contect, remark)
        {
        }
    }
}
