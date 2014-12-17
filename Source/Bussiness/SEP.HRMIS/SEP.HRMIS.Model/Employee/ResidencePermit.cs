//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResidencePermit.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 居住证
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 居住证有效期
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
        /// 居住证办理机构
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
        /// 居住证到期日
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

        #region 重写Equals

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