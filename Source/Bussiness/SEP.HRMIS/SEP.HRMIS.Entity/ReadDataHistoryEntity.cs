
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TReadDataHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TReadDataHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TReadDataHistory的实体类
	/// </summary>
	public class ReadDataHistoryEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ReadTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ReadResult {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FailReason {get; set; }

	}
}
