
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TCourseTraineeEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TCourseTrainee表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TCourseTrainee的实体类
	/// </summary>
	public class CourseTraineeEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int CourseID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CourseName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int TraineeID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string TraineeName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? FBTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Status {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal Score {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Suggestion {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string CertificationName {get; set; }

	}
}
