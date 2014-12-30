
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAccountSetItemEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAccountSetItem表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAccountSetItem的实体类
	/// </summary>
	public class AccountSetItemEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AccountSetID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AccountSetParaID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CalculateFormula {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int FieldAttribute {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int BindItem {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int MantissaRound {get; set; }

	}
}
