
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TCourseSkillEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TCourseSkill表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TCourseSkill的实体类
	/// </summary>
	public class CourseSkillEntity
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
		public int SkillID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SkillName {get; set; }

	}
}
