
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TOutApplicationItemEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TOutApplicationItem表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TOutApplicationItem的实体类
	/// </summary>
	public class OutApplicationItemEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OutApplicationID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime From {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime To {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal CostTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal AdjustHour {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Adjust {get; set; }

	}
}
