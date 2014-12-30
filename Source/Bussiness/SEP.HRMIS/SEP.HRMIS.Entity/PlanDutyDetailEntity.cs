
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TPlanDutyDetailEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TPlanDutyDetail表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TPlanDutyDetail的实体类
	/// </summary>
	public class PlanDutyDetailEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PlanDutyTableID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime Date {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int DutyClassID {get; set; }

	}
}
