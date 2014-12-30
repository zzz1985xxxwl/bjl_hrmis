
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAdjustRuleEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAdjustRule表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAdjustRule的实体类
	/// </summary>
	public class AdjustRuleEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Name {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OverWorkPuTongRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OverWorkJieRiRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OverWorkShuangXiuRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OutCityPuTongRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OutCityJieRiRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal OutCityShuangXiuRate {get; set; }

	}
}
