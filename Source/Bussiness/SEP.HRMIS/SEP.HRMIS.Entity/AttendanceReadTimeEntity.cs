
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAttendanceReadTimeEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAttendanceReadTime表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAttendanceReadTime的实体类
	/// </summary>
	public class AttendanceReadTimeEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ReadDateTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IsSendEmail {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int SendEmailRull {get; set; }

	}
}
