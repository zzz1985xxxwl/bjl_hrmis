
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TContractBookMarkEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TContractBookMark表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TContractBookMark的实体类
	/// </summary>
	public class ContractBookMarkEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ContractTypeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string BookMarkName {get; set; }

	}
}
