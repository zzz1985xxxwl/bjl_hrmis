//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ResidencePermit.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��ס֤
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ס֤��Ч��
    /// </summary>
    [Serializable]
    public class ResidencePermit
    {
        private string _Orgnaization;
        private DateTime _DueDate;

        public ResidencePermit()
        {
        }
        public ResidencePermit(string Orgnaization, DateTime DueDate)
        {
            _Orgnaization = Orgnaization;
            _DueDate = DueDate;
        }

        /// <summary>
        /// ��ס֤�������
        /// </summary>
        public string Orgnaization
        {
            get
            {
                return _Orgnaization;
            }
            set
            {
                _Orgnaization = value;
            }
        }

        /// <summary>
        /// ��ס֤������
        /// </summary>
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                _DueDate = value;
            }
        }

        #region ��дEquals

        public override bool Equals(object obj)
        {
            ResidencePermit anOtherObj = obj as ResidencePermit;
            if (anOtherObj == null)
            {
                return false;
            }
            return _Orgnaization.Equals(anOtherObj._Orgnaization) &&
                   _DueDate.Equals(anOtherObj._DueDate);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}