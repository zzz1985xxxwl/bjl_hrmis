
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TLeaveRequestTypeEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TLeaveRequestType表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TLeaveRequestType的实体类
	/// </summary>
	public class LeaveRequestTypeEntity
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
		public string Description {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IncludeNationalHolidays {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IncludeRestDay {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal LeastHour {get; set; }

	}
}
