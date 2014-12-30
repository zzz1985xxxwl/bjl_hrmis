
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TDutyClassEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TDutyClass表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TDutyClass的实体类
	/// </summary>
	public class DutyClassEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DutyClassName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime FirstStartFromTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime FirstStartToTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime FirstEndTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime SecondStartTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime SecondEndTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal AllLimitTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int LateTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EarlyLeaveTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AbsentLateTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AbsentEarlyLeaveTime {get; set; }

	}
}
