//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Family.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 家庭
// ----------------------------------------------------------------

using System.Collections.Generic;
using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 家庭
    /// </summary>
    [Serializable]
    public class Family
    {
        //构造函数
        private string _FamilyAddress;
        private string _FamilyPhone;
        private string _PostCode;
        private string _ChildName;
        private DateTime? _ChildBirthday;
        private string _ChildName2;
        private DateTime? _ChildBirthday2;
        //非构造函数
        private bool _HasChild;
        private int _ChildAge;
        private int _ChildAge2;

        private List<FamilyMember> _FamilyMembers = new List<FamilyMember>();
        /// <summary>
        /// 家庭构造函数
        /// </summary>
        public Family()
        {
        }
        /// <summary>
        /// 家庭构造函数
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


        #region 属性

        /// <summary>
        /// 家庭住址
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
        /// 家庭电话
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
        /// 邮政编码
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
        /// 子女姓名
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
        /// 子女出生年月
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
        /// 家庭成员
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
        /// 是否有孩子
        /// </summary>
        public bool HasChild
        {
            get { return _HasChild; }
            set { _HasChild = value; }
        }

        /// <summary>
        /// 孩子年龄
        /// </summary>
        public int ChildAge
        {
            get { return _ChildAge; }
            set { _ChildAge = value; }
        }

        /// <summary>
        /// 第二个孩子的姓名
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
        /// 第二个孩子的生日
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
        /// 第二个孩子的年龄
        /// </summary>
        public int ChildAge2
        {
            get { return _ChildAge2; }
            set { _ChildAge2 = value; }
        }

        #endregion

        #region 私有方法

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
        /// 重写Equals
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