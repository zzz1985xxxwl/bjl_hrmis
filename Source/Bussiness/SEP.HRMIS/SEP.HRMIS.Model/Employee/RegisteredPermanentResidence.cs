//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: RegisteredPermanentResidence.cs
// ������: �����
// ��������: 2008-08-26
// ����: ����
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ����
    /// </summary>
    [Serializable]
    public class RegisteredPermanentResidence
    {
        private string _RPRAddress;
        private string _PRPPostCode;
        private string _PRPStreet;
        private string _PRPArea;
        /// <summary>
        /// ���ڹ��캯��
        /// </summary>
        public RegisteredPermanentResidence()
        {
        }
        /// <summary>
        /// ���ڹ��캯��
        /// </summary>
        /// <param name="RPRAddress"></param>
        /// <param name="PRPPostCode"></param>
        /// <param name="PRPStreet"></param>
        /// <param name="PRPArea"></param>
        public RegisteredPermanentResidence(string RPRAddress, string PRPPostCode, string PRPStreet, string PRPArea)
        {
            _RPRAddress = RPRAddress;
            _PRPPostCode = PRPPostCode;
            _PRPStreet = PRPStreet;
            _PRPArea = PRPArea;
        }

        /// <summary>
        /// ���ڵ�ַ
        /// </summary>
        public string RPRAddress
        {
            get
            {
                return _RPRAddress;
            }
            set
            {
                _RPRAddress = value;
            }
        }

        /// <summary>
        /// �������ڵ���������
        /// </summary>
        public string PRPPostCode
        {
            get
            {
                return _PRPPostCode;
            }
            set
            {
                _PRPPostCode = value;
            }
        }

        /// <summary>
        /// �����ֵ�
        /// </summary>
        public string PRPStreet
        {
            get
            {
                return _PRPStreet;
            }
            set
            {
                _PRPStreet = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string PRPArea
        {
            get
            {
                return _PRPArea;
            }
            set
            {
                _PRPArea = value;
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
            RegisteredPermanentResidence anOtherObj = obj as RegisteredPermanentResidence;
            if (anOtherObj == null)
            {
                return false;
            }
            return _RPRAddress.Equals(anOtherObj._RPRAddress) &&
                _PRPPostCode.Equals(anOtherObj._PRPPostCode) &&
                _PRPStreet.Equals(anOtherObj._PRPStreet) &&
                   _PRPArea.Equals(anOtherObj._PRPArea);
        }

        #endregion
    }
}