
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TDiyStepEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TDiyStep表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TDiyStep的实体类
	/// </summary>
	public class DiyStepEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperatorType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperatorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int DiyProcessID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MailAccount {get; set; }

	}
}
