
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TEmployeeInAndOutRecordEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TEmployeeInAndOutRecord表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TEmployeeInAndOutRecord的实体类
	/// </summary>
	public class EmployeeInAndOutRecordEntity
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
		public string DoorCardNo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime IOTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IOStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperateStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperateTime {get; set; }

	}
}
