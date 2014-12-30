
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TCourseEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TCourse表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TCourse的实体类
	/// </summary>
	public class CourseEntity
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
		public int CoordinatorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CoordinatorName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Scope {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Trainer {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ExpectST {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ExpectET {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ActualST {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime ActualET {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ExpectHour {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ActualHour {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ExpectCost {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ActualCost {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string TrianPlace {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int FBCount {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal Score {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int FeedBackPaperId {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int HasCertification {get; set; }

	}
}
