
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TAssessTemplatePIShipEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TAssessTemplatePIShip表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TAssessTemplatePIShip的实体类
	/// </summary>
	public class AssessTemplatePIShipEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AssessTemplatePaperID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AssessTemplateItemID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal Weight {get; set; }

	}
}
