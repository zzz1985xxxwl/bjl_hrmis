//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyMember.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 家庭成员
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
        /// 家庭成员构造函数
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
        /// 姓名
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
        /// 称谓
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
        /// 年龄
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
        /// 工作单位
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
        /// 备注
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
        /// 生日
        /// </summary>
        public DateTime? Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        #region 方法
        /// <summary>
        /// 重写Equals
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