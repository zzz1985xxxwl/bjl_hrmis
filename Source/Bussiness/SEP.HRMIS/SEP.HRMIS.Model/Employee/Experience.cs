//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Experience.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 经历
// ----------------------------------------------------------------

using System;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 经历，被教育背景，工作背景继承
    /// </summary>
    [Serializable]
    public class Experience
    {
        private string _Place;
        private string _Contect;
        private string _ExperiencePeriod;
        private string _Remark;
        private int _ExperienceId;
        /// <summary>
        /// 经历构造函数
        /// </summary>
        /// <param name="place"></param>
        /// <param name="experiencePeriod"></param>
        /// <param name="contect"></param>
        /// <param name="remark"></param>
        public Experience(string place, string experiencePeriod, string contect, string remark)
        {
            //modifiy by colbert
            _ExperienceId = GetHashCode();
            _Place = place;
            _ExperiencePeriod = experiencePeriod;
            _Contect = contect;
            _Remark = remark;
        }

        /// <summary>
        /// 地点
        /// </summary>
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                _Place = value;
            }
        }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string Contect
        {
            get
            {
                return _Contect;
            }
            set
            {
                _Contect = value;
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
        /// 经历的时间段，比如1999.11-2008.1
        /// </summary>
        public string ExperiencePeriod
        {
            get { return _ExperiencePeriod; }
            set { _ExperiencePeriod = value; }
        }

        #region 方法
        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Experience anOtherObj = obj as Experience;
            if (anOtherObj == null)
            {
                return false;
            }
            return _Place.Equals(anOtherObj._Place) &&
                   _ExperiencePeriod.Equals(anOtherObj._ExperiencePeriod) &&
                   _Contect.Equals(anOtherObj._Contect) &&
                   _Remark.Equals(anOtherObj._Remark);
        }
        /// <summary>
        /// HashCode=_ExperienceId
        /// </summary>
        public int HashCode
        {
            get
            {
                return _ExperienceId;
            }
            set
            {
                _ExperienceId = value;
            }
        }

        #endregion
    }
}