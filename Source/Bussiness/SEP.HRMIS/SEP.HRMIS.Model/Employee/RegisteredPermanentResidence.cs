//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: RegisteredPermanentResidence.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 户口
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 户口
    /// </summary>
    [Serializable]
    public class RegisteredPermanentResidence
    {
        private string _RPRAddress;
        private string _PRPPostCode;
        private string _PRPStreet;
        private string _PRPArea;
        /// <summary>
        /// 户口构造函数
        /// </summary>
        public RegisteredPermanentResidence()
        {
        }
        /// <summary>
        /// 户口构造函数
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
        /// 户口地址
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
        /// 户口所在地邮政编码
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
        /// 所属街道
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
        /// 所属区域
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

        #region 方法
        /// <summary>
        /// 重写Equals
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