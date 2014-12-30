
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TOutApplicationEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TOutApplication表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TOutApplication的实体类
	/// </summary>
	public class OutApplicationEntity
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
		public DateTime SubmitDate {get; set; }

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
		public decimal? CostTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Reason {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OutLocation {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OutType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DiyProcess {get; set; }

	}
}
