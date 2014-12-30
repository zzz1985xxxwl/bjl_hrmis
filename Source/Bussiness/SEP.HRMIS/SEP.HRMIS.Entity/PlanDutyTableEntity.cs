
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TPlanDutyTableEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TPlanDutyTable表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TPlanDutyTable的实体类
	/// </summary>
	public class PlanDutyTableEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PlanDutyTableName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? Period {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime FromTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ToTime {get; set; }

	}
}
