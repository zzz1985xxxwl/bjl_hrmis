
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TDepartmentHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TDepartmentHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TDepartmentHistory的实体类
	/// </summary>
	public class DepartmentHistoryEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int LeaderID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LeaderName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ParentID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OperatorName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Address {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Phone {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Fax {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Others {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Description {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? FoundationTime {get; set; }

	}
}
