//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IDCard.cs
// ������: �����
// ��������: 2008-08-26
// ����: ���֤
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ���֤
    /// </summary>
    [Serializable]
    public class IDCard
    {
        private string _No;
        private DateTime _DueDate;
        /// <summary>
        /// ���֤���캯��
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dueDate"></param>
        public IDCard(string no, DateTime dueDate)
        {
            _No = no;
            _DueDate = dueDate;
        }

        /// <summary>
        /// ���֤����
        /// </summary>
        public string IDCardNo
        {
            get
            {
                return _No;
            }
            set
            {
                _No = value;
            }
        }

        /// <summary>
        /// ���֤��Ч��
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

        #region ����
        /// <summary>
        /// ��дEquals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            IDCard anOtherObj = obj as IDCard;
            if (anOtherObj == null)
            {
                return false;
            }

            return _No.Equals(anOtherObj._No) &&
                   _DueDate.Equals(anOtherObj._DueDate);
        }
        /// <summary>
        /// ��֤���֤��Ч��
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public static bool CheckNo(string no)
        {
            if (!(no.Length == 15 || no.Length == 18))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ����Ĭ��ֵ
        /// </summary>
        public void SetDefault()
        {
            _No = ModelUtility.MakeDefaultString();
            _DueDate = ModelUtility.MakeDefaultTime();
        }
        #endregion
    }
}