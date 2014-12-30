
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TCourseFBResultEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TCourseFBResult表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TCourseFBResult的实体类
	/// </summary>
	public class CourseFBResultEntity
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
		public int CourseFBID {get; set; }

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
		public decimal Score {get; set; }

	}
}
