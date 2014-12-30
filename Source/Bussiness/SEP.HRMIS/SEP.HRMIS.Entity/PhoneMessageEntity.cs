
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TPhoneMessageEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TPhoneMessage表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TPhoneMessage的实体类
	/// </summary>
	public class PhoneMessageEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int RequesterID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string RequesterName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AssessorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AssessorName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int TypeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Type {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Message {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Answer {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? InsertTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? SendTime {get; set; }

	}
}
