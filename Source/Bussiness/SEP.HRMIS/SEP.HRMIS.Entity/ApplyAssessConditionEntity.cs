
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TApplyAssessConditionEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TApplyAssessCondition表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TApplyAssessCondition的实体类
	/// </summary>
	public class ApplyAssessConditionEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EmployeeContractID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ApplyDate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime AssessScopeFrom {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime AssessScopeTo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ApplyAssessCharacterType {get; set; }

	}
}
