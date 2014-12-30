
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TPositionHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TPositionHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TPositionHistory的实体类
	/// </summary>
	public class PositionHistoryEntity
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
		public string PositionName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PositionGradeName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PositionGradeSequence {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OperatorName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime OperationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PositionDescription {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Number {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? ReviewerID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ReviewerName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PositionStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Version {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? Commencement {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Summary {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MainDuties {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ReportScope {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ControlScope {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Coordination {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Authority {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Education {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ProfessionalBackground {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string WorkExperience {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Qualification {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Competence {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OtherRequirements {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string KnowledgeAndSkills {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string RelatedProcesses {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ManagementSkills {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AuxiliarySkills {get; set; }

	}
}
