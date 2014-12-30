
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TFileCargoEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TFileCargo表的实体类。
// ---------------------------------------------------------------

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TFileCargo的实体类
	/// </summary>
	public class FileCargoEntity
	{
		/// <summary>
		/// 
		/// </summary>
		public int PKID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AccountID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int FileCargoName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Remark {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string File {get; set; }

	}
}
