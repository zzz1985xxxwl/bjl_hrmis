
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAssessTemplateItemEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAssessTemplateItem表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAssessTemplateItem的实体类
	/// </summary>
	public class AssessTemplateItemEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Question {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int OperateType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AssessTemplateItemType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ItemClassfication {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ItemOption {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ItemDescription {get; set; }

	}
}
