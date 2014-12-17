//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Family.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��ͥ
// ----------------------------------------------------------------

using System.Collections.Generic;
using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ͥ
    /// </summary>
    [Serializable]
    public class Family
    {
        //���캯��
        private string _FamilyAddress;
        private string _FamilyPhone;
        private string _PostCode;
        private string _ChildName;
        private DateTime? _ChildBirthday;
        private string _ChildName2;
        private DateTime? _ChildBirthday2;
        //�ǹ��캯��
        private bool _HasChild;
        private int _ChildAge;
        private int _ChildAge2;

        private List<FamilyMember> _FamilyMembers = new List<FamilyMember>();
        /// <summary>
        /// ��ͥ���캯��
        /// </summary>
        public Family()
        {
        }
        /// <summary>
        /// ��ͥ���캯��
        /// </summary>
        /// <param name="familyAddress"></param>
        /// <param name="familyPhone"></param>
        /// <param name="postCode"></param>
        /// <param name="childName"></param>
        /// <param name="childBirthday"></param>
        /// <param name="childName2"></param>
        /// <param name="childBirthday2"></param>
        public Family(string familyAddress, string familyPhone, string postCode, string childName, DateTime? childBirthday, string childName2, DateTime? childBirthday2)
        {
            _FamilyAddress = familyAddress;
            _FamilyPhone = familyPhone;
            _PostCode = postCode;
            _ChildName = childName;
            _ChildBirthday = childBirthday;
            _ChildName2 = childName2;
            _ChildBirthday2 = childBirthday2;

            CheckHasChild();
            CalculateChildAge();
        }


        #region ����

        /// <summary>
        /// ��ͥסַ
        /// </summary>
        public string FamilyAddress
        {
            get
            {
                return _FamilyAddress;
            }
            set
            {
                _FamilyAddress = value;
            }
        }

        /// <summary>
        /// ��ͥ�绰
        /// </summary>
        public string FamilyPhone
        {
            get
            {
                return _FamilyPhone;
            }
            set
            {
                _FamilyPhone = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
            }
        }

        /// <summary>
        /// ��Ů����
        /// </summary>
        public string ChildName
        {
            get
            {
                return _ChildName;
            }
            set
            {
                _ChildName = value;
                CheckHasChild();
            }
        }

        /// <summary>
        /// ��Ů��������
        /// </summary>
        public DateTime? ChildBirthday
        {
            get
            {
                return _ChildBirthday;
            }
            set
            {
                _ChildBirthday = value;
                CalculateChildAge();
            }
        }

        /// <summary>
        /// ��ͥ��Ա
        /// </summary>
        public List<FamilyMember> FamilyMembers
        {
            get
            {
                return _FamilyMembers;
            }
            set
            {
                _FamilyMembers = value;
            }
        }

        /// <summary>
        /// �Ƿ��к���
        /// </summary>
        public bool HasChild
        {
            get { return _HasChild; }
            set { _HasChild = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int ChildAge
        {
            get { return _ChildAge; }
            set { _ChildAge = value; }
        }

        /// <summary>
        /// �ڶ������ӵ�����
        /// </summary>
        public string ChildName2
        {
            get { return _ChildName2; }
            set
            {
                _ChildName2 = value;
                CheckHasChild();
            }
        }

        /// <summary>
        /// �ڶ������ӵ�����
        /// </summary>
        public DateTime? ChildBirthday2
        {
            get { return _ChildBirthday2; }
            set
            {
                _ChildBirthday2 = value;
                CalculateChildAge();
            }
        }

        /// <summary>
        /// �ڶ������ӵ�����
        /// </summary>
        public int ChildAge2
        {
            get { return _ChildAge2; }
            set { _ChildAge2 = value; }
        }

        #endregion

        #region ˽�з���

        private void CalculateChildAge()
        {
            _ChildAge = _ChildBirthday == null
                            ? 0
                            : ModelUtility.CalculateYearsBetween((DateTime)_ChildBirthday, DateTime.Today);
            _ChildAge2 = _ChildBirthday2 == null
                            ? 0
                            : ModelUtility.CalculateYearsBetween((DateTime)_ChildBirthday2, DateTime.Today);
        }

        private void CheckHasChild()
        {
            if (string.IsNullOrEmpty(_ChildName) && string.IsNullOrEmpty(_ChildName2))
            {
                _HasChild = false;
            }
            else
            {
                _HasChild = true;
            }
        }
        /// <summary>
        /// ��дEquals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Family anOtherObj = obj as Family;
            if (anOtherObj == null)
            {
                return false;
            }

            return _ChildBirthday.Equals(anOtherObj._ChildBirthday) && 
                   JudgeFamilyMembers(anOtherObj) &&
                   _FamilyAddress.Equals(anOtherObj._FamilyAddress) &&
                   _FamilyPhone.Equals(anOtherObj._FamilyPhone) &&
                   _PostCode.Equals(anOtherObj._PostCode) &&
                   _ChildName.Equals(anOtherObj._ChildName);
        }

        private bool JudgeFamilyMembers(Family anOtherObj)
        {
            bool retVal = true;
            if (_FamilyMembers.Count != anOtherObj._FamilyMembers.Count)
            {
                retVal = false;
            }
            else
            {
                for(int i =0;i<_FamilyMembers.Count;i++)
                {
                    if(!_FamilyMembers[i].Equals(anOtherObj.FamilyMembers[i]))
                    {
                        retVal = false;
                    }
                }
            }
            return retVal;
        }

        #endregion
    }
}