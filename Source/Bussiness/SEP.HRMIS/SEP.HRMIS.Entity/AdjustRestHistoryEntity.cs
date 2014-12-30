
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAdjustRestHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAdjustRestHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAdjustRestHistory的实体类
	/// </summary>
	public class AdjustRestHistoryEntity
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
		public DateTime OccurTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperatorId {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ChangeHours {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AdjustRestHistoryType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int RelevantID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Remark {get; set; }

	}
}
