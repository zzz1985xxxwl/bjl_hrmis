
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TEmployeeWelfareHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TEmployeeWelfareHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TEmployeeWelfareHistory的实体类
	/// </summary>
	public class EmployeeWelfareHistoryEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AccountID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? SocialSecurityType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? SocialSecurityBase {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? SocialSecurityEffectiveYearMonth {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AccumulationFundAccount {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AccumulationFundSupplyAccount {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? AccumulationFundBase {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? AccumulationFundEffectiveMonthYear {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AccountsBackName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? AccumulationFundSupplyBase {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? YangLaoBase {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? ShiYeBase {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? YiLiaoBase {get; set; }

	}
}
