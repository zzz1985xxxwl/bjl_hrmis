
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TParameterEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TParameter表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TParameter的实体类
	/// </summary>
	public class ParameterEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Name {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Type {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Description {get; set; }

	}
}
