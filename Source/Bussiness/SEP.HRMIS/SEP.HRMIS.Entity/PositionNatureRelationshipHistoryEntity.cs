
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TPositionNatureRelationshipHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TPositionNatureRelationshipHistory表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TPositionNatureRelationshipHistory的实体类
	/// </summary>
	public class PositionNatureRelationshipHistoryEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PositionID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PositionNatureID {get; set; }

	}
}
