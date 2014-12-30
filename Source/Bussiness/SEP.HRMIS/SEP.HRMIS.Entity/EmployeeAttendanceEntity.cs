
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TEmployeeAttendanceEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TEmployeeAttendance表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TEmployeeAttendance的实体类
	/// </summary>
	public class EmployeeAttendanceEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EmployeeId {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Name {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal Days {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal AddDutyDays {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EarlyAndLateMunite {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime TheDay {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AttendanceType {get; set; }

	}
}
