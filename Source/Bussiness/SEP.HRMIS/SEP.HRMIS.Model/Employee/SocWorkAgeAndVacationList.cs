//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SocWorkAgeAndVacationList.cs
// ������: ���h��
// ��������: 2008-12-15
// ����: ��Ṥ��������б�
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��Ṥ��������б�
    /// </summary>
    [Serializable]
    public class SocWorkAgeAndVacationList
    {
        private int _SocietyWorkAge;
        private List<Vacation> _EmployeeVacations;

        /// <summary>
        /// ��Ṥ��
        /// </summary>
        public int SocietyWorkAge
        {
            get { return _SocietyWorkAge; }
            set { _SocietyWorkAge = value; }
        }
        /// <summary>
        /// ����б�
        /// </summary>
        public List<Vacation> EmployeeVacations
        {
            get { return _EmployeeVacations; }
            set { _EmployeeVacations = value; }
        }
    }
}
