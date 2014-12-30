
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TReimburseFlowEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TReimburseFlow表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TReimburseFlow的实体类
	/// </summary>
	public class ReimburseFlowEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ReimburseID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperatorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ReimburseStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperationTime {get; set; }

	}
}
