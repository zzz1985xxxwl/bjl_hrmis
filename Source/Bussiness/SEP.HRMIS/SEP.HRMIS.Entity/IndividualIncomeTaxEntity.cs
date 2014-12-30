
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TIndividualIncomeTaxEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TIndividualIncomeTax表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TIndividualIncomeTax的实体类
	/// </summary>
	public class IndividualIncomeTaxEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal BandMin {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal TaxRate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Type {get; set; }

	}
}
