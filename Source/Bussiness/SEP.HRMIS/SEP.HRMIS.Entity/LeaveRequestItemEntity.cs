
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TLeaveRequestItemEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TLeaveRequestItem表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TLeaveRequestItem的实体类
	/// </summary>
	public class LeaveRequestItemEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int LeaveRequestID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime AbsentFrom {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime AbsentTo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal AbsentHours {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int NextProcessID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string UseList {get; set; }

	}
}
