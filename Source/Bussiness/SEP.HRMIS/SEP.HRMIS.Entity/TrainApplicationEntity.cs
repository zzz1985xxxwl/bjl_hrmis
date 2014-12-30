
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TTrainApplicationEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TTrainApplication表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TTrainApplication的实体类
	/// </summary>
	public class TrainApplicationEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CourseName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ApplicationId {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int TrainType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Trainer {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Skills {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime StratTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string TrianPlace {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string TrainOrgnatiaon {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal TrainHour {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal TrainCost {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int HasCertification {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int NextStepIndex {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int ApplicationStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DiyProcess {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal? EduSpuCost {get; set; }

	}
}
