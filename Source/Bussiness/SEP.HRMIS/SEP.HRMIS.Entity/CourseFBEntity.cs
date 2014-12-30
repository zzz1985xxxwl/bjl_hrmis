
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TCourseFBEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TCourseFB表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TCourseFB的实体类
	/// </summary>
	public class CourseFBEntity
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
		public string FBQues {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FBItems {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string FBItemsScore {get; set; }

	}
}
