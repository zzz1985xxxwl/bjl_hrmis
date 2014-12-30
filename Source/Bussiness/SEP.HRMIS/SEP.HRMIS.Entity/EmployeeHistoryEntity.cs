
//----------------------------------------------------------------
// Copyright (C) 2000-2015 XueWenlong Corporation
// All rights reserved.
// 文件名: TEmployeeHistoryEntity.cs
// 创建者: XueWenlong
// 创建日期: 2014-12-30 09:13:30
// 概述: TEmployeeHistory表的实体类。
// ---------------------------------------------------------------

using System;

namespace SEP.HRMIS.Entity
{
	/// <summary>
	/// TEmployeeHistory的实体类
	/// </summary>
	public class EmployeeHistoryEntity
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
		public int CompanyID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int AccountType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MobileNum {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IsAcceptEmail {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IsAcceptSMS {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int IsValidateUsbKey {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? LeaveDate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Name {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LoginName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Password {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Email1 {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Email2 {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? PositionID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ComeDate {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ResidencePermit {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int EmployeeType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string EnglishName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? Gender {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? PoliticalAffiliation {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? MaritalStatus {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? EducationalBackground {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? WorkType {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? HasChild {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public byte[] EmployeeDetails {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Certificates {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PRPArea {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProbationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string UsbKey {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public byte[] Photo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DoorCardNo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? SocietyWorkAge {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? OperatorID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? OperationTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Remark {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string LeaderName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string PositionName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string OperatorName {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PositionGradeId {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProbationStartTime {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int? PrincipalShipID {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SalaryCardNo {get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SalaryCardBank {get; set; }

	}
}
