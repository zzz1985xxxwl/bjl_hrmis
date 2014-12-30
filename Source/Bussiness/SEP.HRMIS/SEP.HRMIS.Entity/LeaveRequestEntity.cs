
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TLeaveRequestEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TLeaveRequest表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TLeaveRequest的实体类
	/// </summary>
	public class LeaveRequestEntity
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
		public int LeaveRequestTypeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Reason {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime SubmitDate {get; set; }

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
		public string DiyProcess {get; set; }

	}
}
