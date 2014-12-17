//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IDCard.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 身份证
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 身份证
    /// </summary>
    [Serializable]
    public class IDCard
    {
        private string _No;
        private DateTime _DueDate;
        /// <summary>
        /// 身份证构造函数
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dueDate"></param>
        public IDCard(string no, DateTime dueDate)
        {
            _No = no;
            _DueDate = dueDate;
        }

        /// <summary>
        /// 身份证号码
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
        /// 身份证有效期
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

        #region 方法
        /// <summary>
        /// 重写Equals
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
        /// 验证身份证有效性
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
        /// 设置默认值
        /// </summary>
        public void SetDefault()
        {
            _No = ModelUtility.MakeDefaultString();
            _DueDate = ModelUtility.MakeDefaultTime();
        }
        #endregion
    }
}