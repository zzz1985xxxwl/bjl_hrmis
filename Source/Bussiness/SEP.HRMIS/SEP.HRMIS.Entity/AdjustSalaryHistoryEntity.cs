
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAdjustSalaryHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAdjustSalaryHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAdjustSalaryHistory的实体类
	/// </summary>
	public class AdjustSalaryHistoryEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EmployeeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AccountSetName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public byte[] EmployeeAccountSetItems {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Description {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ChangeDate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AccountsBackName {get; set; }

	}
}
