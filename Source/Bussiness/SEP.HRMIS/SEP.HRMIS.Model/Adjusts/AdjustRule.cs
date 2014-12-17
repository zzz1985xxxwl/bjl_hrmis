//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AdjustRule.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model.Adjusts
{
    /// <summary>
    /// 调休规则
    /// </summary>
    [Serializable]
    public class AdjustRule
    {
        private int _AdjustRuleID;
        private string _AdjustRuleName;
        private decimal _OverWorkPuTongRate;
        private decimal _OverWorkJieRiRate;
        private decimal _OverWorkShuangXiuRate;
        private decimal _OutCityPuTongRate;
        private decimal _OutCityJieRiRate;
        private decimal _OutCityShuangXiuRate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public AdjustRule(int id, string name)
        {
            _AdjustRuleID = id;
            _AdjustRuleName = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public AdjustRule(int id, string name, decimal overWorkPuTongRate, decimal overWorkJieRiRate,
                          decimal overWorkShuangXiuRate, decimal outCityPuTongRate
                          , decimal outCityJieRiRate, decimal outCityShuangXiuRate)
        {
            _AdjustRuleID = id;
            _AdjustRuleName = name;
            _OutCityJieRiRate = outCityJieRiRate;
            _OutCityPuTongRate = outCityPuTongRate;
            _OutCityShuangXiuRate = outCityShuangXiuRate;
            _OverWorkPuTongRate = overWorkPuTongRate;
            _OverWorkShuangXiuRate = overWorkShuangXiuRate;
            _OverWorkJieRiRate = overWorkJieRiRate;
        }

        /// <summary>
        /// id
        /// </summary>
        public int AdjustRuleID
        {
            get { return _AdjustRuleID; }
            set { _AdjustRuleID = value; }
        }

        /// <summary>
        /// name
        /// </summary>
        public string AdjustRuleName
        {
            get { return _AdjustRuleName; }
            set { _AdjustRuleName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OverWorkPuTongRate
        {
            get { return _OverWorkPuTongRate; }
            set { _OverWorkPuTongRate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OverWorkJieRiRate
        {
            get { return _OverWorkJieRiRate; }
            set { _OverWorkJieRiRate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OverWorkShuangXiuRate
        {
            get { return _OverWorkShuangXiuRate; }
            set { _OverWorkShuangXiuRate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OutCityPuTongRate
        {
            get { return _OutCityPuTongRate; }
            set { _OutCityPuTongRate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OutCityJieRiRate
        {
            get { return _OutCityJieRiRate; }
            set { _OutCityJieRiRate = value; }
        }
        /// <summary>
        /// 出差 双休
        /// </summary>
        public decimal OutCityShuangXiuRate
        {
            get { return _OutCityShuangXiuRate; }
            set { _OutCityShuangXiuRate = value; }
        }
    }
}