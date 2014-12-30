
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TOverWorkEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TOverWork表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TOverWork的实体类
	/// </summary>
	public class OverWorkEntity
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
		public string ProjectName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DiyProcess {get; set; }

	}
}
