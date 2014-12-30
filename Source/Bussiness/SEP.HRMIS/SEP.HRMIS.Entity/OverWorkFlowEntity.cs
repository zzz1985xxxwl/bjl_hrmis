
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TOverWorkFlowEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TOverWorkFlow表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TOverWorkFlow的实体类
	/// </summary>
	public class OverWorkFlowEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OverWorkItemID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperatorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Operation {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Remark {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Step {get; set; }

	}
}
