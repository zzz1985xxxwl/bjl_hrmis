//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: WorkExperience.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��������
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public class WorkExperience : Experience
    {
        private string _ContactPerson;
        /// <summary>
        /// ���������б�
        /// </summary>
        /// <param name="company"></param>
        /// <param name="experiencePeriod"></param>
        /// <param name="content"></param>
        /// <param name="remark"></param>
        /// <param name="contactPerson"></param>
        public WorkExperience(string company, string experiencePeriod, string content, string remark,string contactPerson)
            : base(company, experiencePeriod, content, remark)
        {
            _ContactPerson = contactPerson;
        }

        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }
    }
}