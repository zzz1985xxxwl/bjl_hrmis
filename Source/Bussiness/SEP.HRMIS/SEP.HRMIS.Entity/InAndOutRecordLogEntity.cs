
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TInAndOutRecordLogEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TInAndOutRecordLog表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TInAndOutRecordLog的实体类
	/// </summary>
	public class InAndOutRecordLogEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EmployeeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? OldIOTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? OldIOStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? NewIOTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? NewIOStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperateStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Operator {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperateTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OperateReason {get; set; }

	}
}
