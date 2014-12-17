//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FamilyMember.cs
// ������: �����
// ��������: 2008-08-26
// ����: ��ͥ��Ա
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class FamilyMember
    {
        private string _Name;
        private string _Relationship;
        private DateTime? _Birthday;
        private int _Age;
        private string _Company;
        private string _Remark;
        private int _MemberID;
        /// <summary>
        /// ��ͥ��Ա���캯��
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthday"></param>
        /// <param name="relationShip"></param>
        /// <param name="age"></param>
        /// <param name="company"></param>
        /// <param name="remark"></param>
        public FamilyMember(string name, DateTime? birthday, string relationShip, int age, string company, string remark)
        {
            _MemberID = GetHashCode();
            _Name = name;
            _Birthday = birthday;
            _Relationship = relationShip;
            _Age = age;
            _Company = company;
            _Remark = remark;
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// ��ν
        /// </summary>
        public string Relationship
        {
            get
            {
                return _Relationship;
            }
            set
            {
                _Relationship = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int Age
        {
            get
            {
                _Age = 0;
                if (_Birthday != null)
                {
                    _Age = DateTime.Now.Subtract(_Birthday.GetValueOrDefault()).Days / 365;
                }
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        /// <summary>
        /// ������λ
        /// </summary>
        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                _Company = value;
            }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public DateTime? Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        #region ����
        /// <summary>
        /// ��дEquals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            FamilyMember anOtherObj = obj as FamilyMember;
            if (anOtherObj == null)
            {
                return false;
            }
            return _Name.Equals(anOtherObj._Name) &&
                   _Birthday.Equals(anOtherObj._Birthday) &&
                   _Relationship.Equals(anOtherObj._Relationship) &&
                   _Age.Equals(anOtherObj._Age) &&
                   _Company.Equals(anOtherObj._Company) &&
                   _Remark.Equals(anOtherObj._Remark);
        }
        /// <summary>
        /// HashCode = _MemberID
        /// </summary>
        public int HashCode
        {
            get
            {
                return _MemberID;
            }

            set
            {
                _MemberID = value;
            }
        }

        #endregion
    }
}