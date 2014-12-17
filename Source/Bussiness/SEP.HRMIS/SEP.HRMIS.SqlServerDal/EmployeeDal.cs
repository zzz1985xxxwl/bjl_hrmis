//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeDal.cs
// 创建者: 张燕
// 创建日期: 2008-05-23
// 概述:  实现IEmployee接口中的方法
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using ShiXin.Security;

namespace SEP.HRMIS.SqlServerDal
{
    using SEP.Model.Positions;

    /// <summary>
    /// 员工数据交互
    /// </summary>
    public class EmployeeDal : IEmployee
    {
        #region 私有常量

        private const string _ParmPKID = "@PKID";
        private const string _ParmAccountID = "@AccountID";
        private const string _ParmCompanyID = "@CompanyID";
        private const string _ParmComeDate = "@ComeDate";
        private const string _ParmLeaveDate = "@LeaveDate";
        private const string _ParmBirthday = "@Birthday";
        private const string _ParmResidencePermit = "@ResidencePermit";
        private const string _ParmEmployeeType = "@EmployeeType";
        private const string _ParmEnglishName = "@EnglishName";
        private const string _ParmGender = "@Gender";
        private const string _ParmPoliticalAffiliation = "@PoliticalAffiliation";
        private const string _ParmMaritalStatus = "@MaritalStatus";
        private const string _ParmEducationalBackground = "@EducationalBackground";
        private const string _ParmWorkType = "@WorkType";
        private const string _ParmHasChild = "@HasChild";
        private const string _ParmEmployeeDetails = "@EmployeeDetails";
        private const string _ParmCertificates = "@Certificates";
        private const string _ParmPRPArea = "@PRPArea";
        private const string _ParmProbationTime = "@ProbationTime";
        private const string _ParmProbationStartTime = "@ProbationStartTime";
        private const string _ParmPhoto = "@Photo";
        private const string _ParmDoorCardNo = "@DoorCardNo";
        private const string _ParmSocietyWorkAge = "@SocietyWorkAge";
        private const string _ParmCountryNationalityID = "@CountryNationalityID";
        private const string _ParmWorkPlace = "@WorkPlace";
        private const string _ParmPositionGradeID = "@PositionGradeID";
        private const string _ParmPrincipalShipID = "@PrincipalShipID";
        private const string _ParmSalaryCardNo = "@SalaryCardNo";
        private const string _ParmSalaryCardBank = "@SalaryCardBank";

        private const string _DbCount = "counts";
        private const string _DBPositionGradeID = "PositionGradeID";
        private const string _DBProbationStartTime = "ProbationStartTime";
        private const string _DBAccountID = "AccountID";
        private const string _DBCompanyID = "CompanyID";
        private const string _DBComeDate = "ComeDate";
        private const string _DBLeaveDate = "LeaveDate";
        private const string _DBBirthday = "Birthday";
        private const string _DBResidencePermit = "ResidencePermit";
        private const string _DBEmployeeType = "EmployeeType";
        private const string _DBEnglishName = "EnglishName";
        private const string _DBGender = "Gender";
        private const string _DBPoliticalAffiliation = "PoliticalAffiliation";
        private const string _DBMaritalStatus = "MaritalStatus";
        private const string _DBEducationalBackground = "EducationalBackground";
        private const string _DBWorkType = "WorkType";
        private const string _DBHasChild = "HasChild";
        private const string _DBEmployeeDetails = "EmployeeDetails";
        private const string _DBCertificates = "Certificates";
        private const string _DBPRPArea = "PRPArea";
        private const string _DBProbationTime = "ProbationTime";
        private const string _DBPhoto = "Photo";
        private const string _DBDoorCardNo = "DoorCardNo";
        private const string _DBCountryNationalityID = "CountryNationalityID";
        private const string _DBSocietyWorkAge = "SocietyWorkAge";
        private const string _DBWorkPlace = "WorkPlace";
        private const string _DBPrincipalShipID = "PrincipalShipID";
        private const string _DBSalaryCardNo = "SalaryCardNo";
        private const string _DBSalaryCardBank = "SalaryCardBank";

        //非Employee表字段
        private const string _ErrorObject = "不可更新对象";
        public const string _DBError = "数据库访问错误!";

        #endregion

        /// <summary>
        /// 持久一个员工对象
        /// </summary>
        public int CreateEmployee(Employee aNewEmployee)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = aNewEmployee.Account.Id;
                SetParmNeededValues(cmd, aNewEmployee);
                SetParmNullableValues(cmd, aNewEmployee);

                SqlHelper.ExecuteNonQueryReturnPKID("EmployeeInsert", cmd, out pkid);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return pkid;
        }

        /// <summary>
        /// 更新员工对象，该对象必须工作在对象状态，不可以是查询器状态
        /// </summary>
        public void UpdateEmployee(Employee theEmployee)
        {
            //判断对象状态
            ObjectCanBeUpdated(theEmployee);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = theEmployee.Account.Id;
                SetParmNeededValues(cmd, theEmployee);
                SetParmNullableValues(cmd, theEmployee);

                SqlHelper.ExecuteNonQuery("EmployeeUpdate", cmd);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        /// <summary>
        /// 专为测试用，勿在其他地方调用
        /// </summary>
        public int DeleteEmployeeByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeByAccountID", cmd);
        }
        /// <summary>
        /// 获取Employee表的所有员工的信息
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeInfo()
        {
            var employeeList = new List<Employee>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllEmployeeInfo", cmd))
                {
                    while (sdr.Read())
                    {
                        Employee theEmployee = new Employee();
                        GetEmployeeImageFieldFromParm(sdr, theEmployee);
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);
                        employeeList.Add(theEmployee);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return employeeList;
        }

        /// <summary>
        /// 根据AccountID获得所有Employee信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeByAccountID(int accountID)
        {
            Employee theEmployee = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeByAccountID", cmd))
                {
                    while (sdr.Read())
                    {
                        theEmployee = new Employee();
                        GetEmployeeImageFieldFromParm(sdr, theEmployee);
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);
                        if (theEmployee.EmployeeDetails != null)
                        {
                            theEmployee.EmployeeDetails.FileCargo =
                                new FileCargoDal().GetFileCargoByAccountID(theEmployee.Account.Id);
                        }
                        //装载的对象是完全的，所以是可更新的
                        theEmployee.ObjectStatus = true;
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return theEmployee;
        }

        /// <summary>
        /// 根据AccountID获得Employee的基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeBasicInfoByAccountID(int accountID)
        {
            Employee theEmployee = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeBasicInfoByAccountID", cmd))
                {
                    while (sdr.Read())
                    {
                        theEmployee = new Employee();
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return theEmployee;
        }

        /// <summary>
        /// 获取Employee表的所有员工的基本信息
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeBasicInfo()
        {

            var employeeList = new List<Employee>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllEmployeeBasicInfo", cmd))
                {
                    while (sdr.Read())
                    {
                        Employee theEmployee = new Employee();
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);
                        employeeList.Add(theEmployee);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return employeeList;
        }

        /// <summary>
        /// 获得公司CompanyID下所有的员工的基本信息
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID)
        {
            var employeeList = new List<Employee>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmCompanyID, SqlDbType.Int).Value = companyID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeBasicInfoByCompanyID", cmd))
                {
                    while (sdr.Read())
                    {
                        Employee theEmployee = new Employee();
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);
                        employeeList.Add(theEmployee);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return employeeList;
        }

        /// <summary>
        /// 获得系统中所有公司
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllCompanyHaveEmployee()
        {
            List<Department> departmentList = new List<Department>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllCompanyHaveEmployee", cmd))
                {
                    while (sdr.Read())
                    {
                        Department theDepartment = new Department(Convert.ToInt32(sdr[_DBCompanyID]), "");
                        departmentList.Add(theDepartment);
                    }
                    return departmentList;
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        ///<summary>
        ///</summary>
        public byte[] GetEmployeePhotoByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            try
            {
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeePhotoByAccountID", cmd))
                {
                    while (sdr.Read())
                    {
                        return sdr[_DBPhoto] as byte[];
                    }
                    return null;
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationalityID"></param>
        /// <returns></returns>
        public int CountEmployeeByNationalityID(int nationalityID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmCountryNationalityID, SqlDbType.Int).Value = nationalityID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountEmployeeByNationalityID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return -1;
        }

        #region private method

        /// <summary>
        /// 除image以外的数据赋值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="aNewEmployee"></param>
        private static void SetParmNeededValues(SqlCommand cmd, Employee aNewEmployee)
        {
            if (aNewEmployee.Account.Position != null && aNewEmployee.Account.Position.Grade != null)
            {
                cmd.Parameters.Add(_ParmPositionGradeID, SqlDbType.Int).Value = aNewEmployee.Account.Position.Grade.Id;
            }
            else
            {
                cmd.Parameters.Add(_ParmPositionGradeID, SqlDbType.Int).Value = -1;
            }

            cmd.Parameters.Add(_ParmEmployeeType, SqlDbType.Int).Value = (Int32)aNewEmployee.EmployeeType;
            if (aNewEmployee.EmployeeDetails != null
                && aNewEmployee.EmployeeDetails.Work != null
                && aNewEmployee.EmployeeDetails.Work.Company != null)
            {
                cmd.Parameters.Add(_ParmCompanyID, SqlDbType.Int).Value =
                    aNewEmployee.EmployeeDetails.Work.Company.Id;
            }
            else
            {
                cmd.Parameters.Add(_ParmCompanyID, SqlDbType.Int).Value = 1;
            }
            if (aNewEmployee.EmployeeDetails != null
                && aNewEmployee.EmployeeDetails.CountryNationality != null)
            {
                cmd.Parameters.Add(_ParmCountryNationalityID, SqlDbType.Int).Value =
                    aNewEmployee.EmployeeDetails.CountryNationality.ParameterID;
            }
            else
            {
                cmd.Parameters.Add(_ParmCountryNationalityID, SqlDbType.Int).Value = -1;
            }
        }

        /// <summary>
        /// image数据赋值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="aNewEmployee"></param>
        private static void SetParmNullableValues(SqlCommand cmd, Employee aNewEmployee)
        {
            #region EmployeeDetails对象

            if (aNewEmployee.EmployeeDetails != null)
            {
                cmd.Parameters.Add(_ParmEmployeeDetails, SqlDbType.Image).Value =
                    EncryptEmployeeDetails(aNewEmployee.EmployeeDetails);

                cmd.Parameters.Add(_ParmEnglishName, SqlDbType.NVarChar, 50).Value =
                    aNewEmployee.EmployeeDetails.EnglishName ?? string.Empty;
                if (DateTime.Compare(aNewEmployee.EmployeeDetails.ProbationStartTime, new DateTime(1900, 1, 1)) > 0)
                {
                    cmd.Parameters.Add(_ParmProbationStartTime, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.ProbationStartTime;
                }
                else
                {
                    cmd.Parameters.Add(_ParmProbationStartTime, SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (DateTime.Compare(aNewEmployee.EmployeeDetails.ProbationTime, new DateTime(1900, 1, 1)) > 0)
                {
                    cmd.Parameters.Add(_ParmProbationTime, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.ProbationTime;
                }
                else
                {
                    cmd.Parameters.Add(_ParmProbationTime, SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.Gender != null)
                {
                    cmd.Parameters.Add(_ParmGender, SqlDbType.Int).Value =
                        aNewEmployee.EmployeeDetails.Gender.Id;
                }
                else
                {
                    cmd.Parameters.Add(_ParmGender, SqlDbType.Int).Value = DBNull.Value;
                }

                if (DateTime.Compare(aNewEmployee.EmployeeDetails.Birthday, new DateTime(1900, 1, 1)) > 0)
                {
                    cmd.Parameters.Add(_ParmBirthday, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.Birthday;
                }
                else
                {
                    cmd.Parameters.Add(_ParmBirthday, SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.PoliticalAffiliation != null)
                {
                    cmd.Parameters.Add(_ParmPoliticalAffiliation, SqlDbType.Int).Value =
                        aNewEmployee.EmployeeDetails.PoliticalAffiliation.Id;
                }
                else
                {
                    cmd.Parameters.Add(_ParmPoliticalAffiliation, SqlDbType.Int).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.MaritalStatus != null)
                {
                    cmd.Parameters.Add(_ParmMaritalStatus, SqlDbType.Int).Value =
                        aNewEmployee.EmployeeDetails.MaritalStatus.Id;
                }
                else
                {
                    cmd.Parameters.Add(_ParmMaritalStatus, SqlDbType.Int).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.Photo != null)
                {
                    cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = aNewEmployee.EmployeeDetails.Photo;
                }
                else
                {
                    cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.Family != null)
                {
                    cmd.Parameters.Add(_ParmHasChild, SqlDbType.Int).Value =
                        aNewEmployee.EmployeeDetails.Family.HasChild
                            ? 1
                            : 0;
                }
                else
                {
                    cmd.Parameters.Add(_ParmHasChild, SqlDbType.Int).Value = DBNull.Value;
                }

                if (aNewEmployee.EmployeeDetails.Education != null)
                {
                    cmd.Parameters.Add(_ParmCertificates, SqlDbType.NVarChar, 2000).Value =
                        aNewEmployee.EmployeeDetails.Education.Certificates ?? string.Empty;
                    if (aNewEmployee.EmployeeDetails.Education.EducationalBackground != null)
                    {
                        cmd.Parameters.Add(_ParmEducationalBackground, SqlDbType.Int).Value =
                            aNewEmployee.EmployeeDetails.Education.EducationalBackground.Id;
                    }
                    else
                    {
                        cmd.Parameters.Add(_ParmEducationalBackground, SqlDbType.Int).Value = DBNull.Value;
                    }
                }
                else
                {
                    cmd.Parameters.Add(_ParmCertificates, SqlDbType.NVarChar, 2000).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmEducationalBackground, SqlDbType.Int).Value = DBNull.Value;
                }

                if (aNewEmployee.EmployeeDetails.Work != null)
                {
                    if (DateTime.Compare(aNewEmployee.EmployeeDetails.Work.ComeDate, new DateTime(1900, 1, 1)) > 0)
                    {
                        cmd.Parameters.Add(_ParmComeDate, SqlDbType.DateTime).Value =
                            aNewEmployee.EmployeeDetails.Work.ComeDate;
                    }
                    else
                    {
                        cmd.Parameters.Add(_ParmComeDate, SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    if (aNewEmployee.EmployeeDetails.Work.WorkType != null)
                    {
                        cmd.Parameters.Add(_ParmWorkType, SqlDbType.Int).Value =
                            aNewEmployee.EmployeeDetails.Work.WorkType.Id;
                    }
                    else
                    {
                        cmd.Parameters.Add(_ParmWorkType, SqlDbType.Int).Value = DBNull.Value;
                    }
                    if (aNewEmployee.EmployeeDetails.Work.Principalship != null)
                    {
                        cmd.Parameters.Add(_ParmPrincipalShipID, SqlDbType.Int).Value =
                            aNewEmployee.EmployeeDetails.Work.Principalship.Id;
                    }
                    else
                    {
                        cmd.Parameters.Add(_ParmPrincipalShipID, SqlDbType.Int).Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(_ParmWorkPlace, SqlDbType.NVarChar, 50).Value =
                        aNewEmployee.EmployeeDetails.Work.WorkPlace ?? string.Empty;
                    cmd.Parameters.Add(_ParmSalaryCardNo, SqlDbType.NVarChar, 255).Value =
                        aNewEmployee.EmployeeDetails.Work.SalaryCardNo ?? string.Empty;
                    cmd.Parameters.Add(_ParmSalaryCardBank, SqlDbType.NVarChar, 255).Value =
                        aNewEmployee.EmployeeDetails.Work.SalaryCardBank ?? string.Empty;
                }
                else
                {
                    cmd.Parameters.Add(_ParmComeDate, SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmWorkType, SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmWorkPlace, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmPrincipalShipID, SqlDbType.Int).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmSalaryCardNo, SqlDbType.NVarChar, 255).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmSalaryCardBank, SqlDbType.NVarChar, 255).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.RegisteredPermanentResidence != null)
                {
                    cmd.Parameters.Add(_ParmPRPArea, SqlDbType.NVarChar, 255).Value =
                        aNewEmployee.EmployeeDetails.RegisteredPermanentResidence.PRPArea ?? string.Empty;
                }
                else
                {
                    cmd.Parameters.Add(_ParmPRPArea, SqlDbType.NVarChar, 255).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.ResidencePermits != null
                    &&
                    DateTime.Compare(aNewEmployee.EmployeeDetails.ResidencePermits.DueDate, new DateTime(1900, 1, 1)) >
                    0)
                {
                    cmd.Parameters.Add(_ParmResidencePermit, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.ResidencePermits.DueDate;
                }
                else
                {
                    cmd.Parameters.Add(_ParmResidencePermit, SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (aNewEmployee.EmployeeDetails.Work != null
                    && aNewEmployee.EmployeeDetails.Work.DimissionInfo != null
                    &&
                    DateTime.Compare(aNewEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate,
                                     new DateTime(1900, 1, 1)) >
                    0)
                {
                    cmd.Parameters.Add(_ParmLeaveDate, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate;
                }
                else
                {
                    cmd.Parameters.Add(_ParmLeaveDate, SqlDbType.DateTime).Value = DBNull.Value;
                }
            }
            else
            {
                cmd.Parameters.Add(_ParmBirthday, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmEmployeeDetails, SqlDbType.Image).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmEnglishName, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmGender, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmPoliticalAffiliation, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmMaritalStatus, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmHasChild, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmCertificates, SqlDbType.NVarChar, 2000).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmEducationalBackground, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmComeDate, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmLeaveDate, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmWorkType, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmPRPArea, SqlDbType.NVarChar, 255).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmResidencePermit, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmProbationTime, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmProbationStartTime, SqlDbType.DateTime).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmPrincipalShipID, SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmWorkPlace, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmSalaryCardNo, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmSalaryCardBank, SqlDbType.NVarChar, 50).Value = DBNull.Value;
            }

            #endregion

            #region SocWorkAgeAndVacationList对象

            if (aNewEmployee.SocWorkAgeAndVacationList != null)
            {
                cmd.Parameters.Add(_ParmSocietyWorkAge, SqlDbType.Int).Value =
                    aNewEmployee.SocWorkAgeAndVacationList.SocietyWorkAge;
            }
            else
            {
                cmd.Parameters.Add(_ParmSocietyWorkAge, SqlDbType.Int).Value = DBNull.Value;
            }

            #endregion

            #region EmployeeAttendance对象

            if (aNewEmployee.EmployeeAttendance != null)
            {
                cmd.Parameters.Add(_ParmDoorCardNo, SqlDbType.NVarChar, 50).Value =
                    aNewEmployee.EmployeeAttendance.DoorCardNo;
            }
            else
            {
                cmd.Parameters.Add(_ParmDoorCardNo, SqlDbType.NVarChar, 50).Value = DBNull.Value;
            }

            #endregion
        }

        /// <summary>
        /// image数据绑定
        /// </summary>
        /// <param name="sdr"></param>
        /// <param name="employee"></param>
        private static void GetEmployeeImageFieldFromParm(IDataRecord sdr, Employee employee)
        {
            byte[] theEmployeeDetailsBytes = null;
            byte[] photo = null;
            try
            {
                theEmployeeDetailsBytes = sdr[_DBEmployeeDetails] as byte[];
            }
            catch
            {
            }
            try
            {
                photo = sdr[_DBPhoto] as byte[];
            }
            catch
            {
            }
            if (theEmployeeDetailsBytes != null)
            {
                employee.EmployeeDetails = DecryptEmployeeDetails(theEmployeeDetailsBytes);
                if (photo != null)
                {
                    employee.EmployeeDetails.Photo = photo;
                }
            }
        }

        /// <summary>
        /// 除了image以外的所有数据绑定
        /// </summary>
        /// <param name="sdr"></param>
        /// <param name="employee"></param>
        private static void GetEmployeeNotImageFieldFromParm(SqlDataReader sdr, Employee employee)
        {
            for (int i = 0; i < sdr.FieldCount; i++)
            {
                DateTime tryDateTimeParse;
                int tryIntParse;
                bool tryBoolParse;
                switch (sdr.GetName(i))
                {
                    case _DBAccountID:
                        if (sdr[_DBAccountID] != null && int.TryParse(sdr[_DBAccountID].ToString(), out tryIntParse))
                        {
                            employee.Account = employee.Account ?? new Account();
                            employee.Account.Id = (int)sdr[_DBAccountID];
                            employee.Account.Position = new Position();
                            employee.Account.Position.Grade = new PositionGrade();
                            employee.Account.Position.Grade.Id = (int)sdr[_DBPositionGradeID];
                        }
                        break;
                    case _DBCompanyID:
                        if (sdr[_DBCompanyID] != null && int.TryParse(sdr[_DBCompanyID].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.Company =
                                employee.EmployeeDetails.Work.Company ?? new Department();
                            employee.EmployeeDetails.Work.Company.DepartmentID = (int)sdr[_DBCompanyID];
                        }
                        break;
                    case _DBEmployeeType:
                        if (sdr[_DBEmployeeType] != null &&
                            int.TryParse(sdr[_DBEmployeeType].ToString(), out tryIntParse))
                        {
                            employee.EmployeeType = (EmployeeTypeEnum)sdr[_DBEmployeeType];
                        }
                        break;
                    case _DBComeDate:
                        if (sdr[_DBComeDate] != null &&
                            DateTime.TryParse(sdr[_DBComeDate].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.ComeDate = (DateTime)sdr[_DBComeDate];
                        }
                        break;
                    case _DBLeaveDate:
                        if (sdr[_DBLeaveDate] != null &&
                            DateTime.TryParse(sdr[_DBLeaveDate].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.DimissionInfo = employee.EmployeeDetails.Work.DimissionInfo ??
                                                                          new DimissionInfo();
                            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = (DateTime)sdr[_DBLeaveDate];
                        }
                        break;
                    case _DBBirthday:
                        if (sdr[_DBBirthday] != null &&
                            DateTime.TryParse(sdr[_DBBirthday].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Birthday = (DateTime)sdr[_DBBirthday];
                        }
                        break;
                    case _DBResidencePermit:
                        if (sdr[_DBResidencePermit] != null &&
                            DateTime.TryParse(sdr[_DBResidencePermit].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.ResidencePermits = employee.EmployeeDetails.ResidencePermits ??
                                                                        new ResidencePermit();
                            employee.EmployeeDetails.ResidencePermits.DueDate = (DateTime)sdr[_DBResidencePermit];
                        }
                        break;
                    case _DBEnglishName:
                        if (sdr[_DBEnglishName] != null)
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();

                            employee.EmployeeDetails.EnglishName = sdr[_DBEnglishName].ToString();
                        }
                        break;
                    case _DBGender:
                        if (sdr[_DBGender] != null && int.TryParse(sdr[_DBGender].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Gender = Gender.GetById((int)sdr[_DBGender]);
                        }
                        break;
                    case _DBPoliticalAffiliation:
                        if (sdr[_DBPoliticalAffiliation] != null &&
                            int.TryParse(sdr[_DBPoliticalAffiliation].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.PoliticalAffiliation =
                                PoliticalAffiliation.GetById((int)sdr[_DBPoliticalAffiliation]);
                        }
                        break;
                    case _DBMaritalStatus:
                        if (sdr[_DBMaritalStatus] != null &&
                            int.TryParse(sdr[_DBMaritalStatus].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.MaritalStatus = MaritalStatus.GetById((int)sdr[_DBMaritalStatus]);
                        }
                        break;
                    case _DBEducationalBackground:
                        if (sdr[_DBEducationalBackground] != null &&
                            int.TryParse(sdr[_DBEducationalBackground].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Education = employee.EmployeeDetails.Education ?? new Education();
                            employee.EmployeeDetails.Education.EducationalBackground =
                                EducationalBackground.GetById((int)sdr[_DBEducationalBackground]);
                        }
                        break;
                    case _DBWorkType:
                        if (sdr[_DBWorkType] != null && int.TryParse(sdr[_DBWorkType].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.WorkType = WorkType.GetById((int)sdr[_DBWorkType]);
                        }
                        break;
                    case _DBHasChild:
                        if (sdr[_DBHasChild] != null && bool.TryParse(sdr[_DBHasChild].ToString(), out tryBoolParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Family = employee.EmployeeDetails.Family ?? new Family();
                            employee.EmployeeDetails.Family.HasChild = (bool)sdr[_DBHasChild];
                        }
                        break;
                    case _DBCertificates:
                        if (sdr[_DBCertificates] != null)
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Education = employee.EmployeeDetails.Education ?? new Education();
                            employee.EmployeeDetails.Education.Certificates = sdr[_DBCertificates].ToString();
                        }
                        break;
                    case _DBPRPArea:
                        if (sdr[_DBPRPArea] != null)
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.RegisteredPermanentResidence =
                                employee.EmployeeDetails.RegisteredPermanentResidence ??
                                new RegisteredPermanentResidence();
                            employee.EmployeeDetails.RegisteredPermanentResidence.PRPArea = sdr[_DBPRPArea].ToString();
                        }
                        break;
                    case _DBProbationTime:
                        if (sdr[_DBProbationTime] != null &&
                            DateTime.TryParse(sdr[_DBProbationTime].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.ProbationTime = (DateTime)sdr[_DBProbationTime];
                        }
                        break;
                    case _DBProbationStartTime:
                        if (sdr[_DBProbationStartTime] != null &&
                            DateTime.TryParse(sdr[_DBProbationStartTime].ToString(), out tryDateTimeParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.ProbationStartTime = (DateTime)sdr[_DBProbationStartTime];
                        }
                        break;
                    case _DBDoorCardNo:
                        if (sdr[_DBDoorCardNo] != null)
                        {
                            employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                            employee.EmployeeAttendance.DoorCardNo = sdr[_DBDoorCardNo].ToString();
                        }
                        break;
                    case _DBSocietyWorkAge:
                        if (sdr[_DBSocietyWorkAge] != null &&
                            int.TryParse(sdr[_DBSocietyWorkAge].ToString(), out tryIntParse))
                        {
                            employee.SocWorkAgeAndVacationList = employee.SocWorkAgeAndVacationList ??
                                                                 new SocWorkAgeAndVacationList();
                            employee.SocWorkAgeAndVacationList.SocietyWorkAge = (int)sdr[_DBSocietyWorkAge];
                        }
                        break;
                    case _DBCountryNationalityID:
                        if (sdr[_DBCountryNationalityID] != null &&
                            int.TryParse(sdr[_DBCountryNationalityID].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails.CountryNationality =
                                new Nationality((int)sdr[_DBCountryNationalityID], "", "");
                        }
                        break;
                    case _DBWorkPlace:
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        employee.EmployeeDetails.Work.WorkPlace = sdr[_DBWorkPlace].ToString();
                        break;
                    case _DBPrincipalShipID:
                        if (sdr[_DBPrincipalShipID] != null &&
                            int.TryParse(sdr[_DBPrincipalShipID].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.Principalship = PrincipalShip.GetById((
                                                                                                int)
                                                                                                sdr[_DBPrincipalShipID]);
                        }
                        break;
                    case _DBSalaryCardNo:
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        employee.EmployeeDetails.Work.SalaryCardNo = sdr[_DBSalaryCardNo].ToString();
                        break;
                    case _DBSalaryCardBank:
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        employee.EmployeeDetails.Work.SalaryCardBank = sdr[_DBSalaryCardBank].ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        private static byte[] EncryptEmployeeDetails(EmployeeDetails employeeDetails)
        {
            MemoryStream ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, employeeDetails);
            byte[] bt = SecurityUtil.SymmetricEncryptStream(ms);
            ms.Close();

            return bt;
        }

        private static EmployeeDetails DecryptEmployeeDetails(byte[] theEmployeeDetailsBytes)
        {
            IFormatter formatter = new BinaryFormatter();
            return
                formatter.Deserialize(SecurityUtil.SymmetricDecryptStream(theEmployeeDetailsBytes)) as EmployeeDetails;
        }

        private static void ObjectCanBeUpdated(Employee theEmployee)
        {
            if (!theEmployee.ObjectStatus)
            {
                throw new ApplicationException(_ErrorObject);
            }
        }

        #endregion
    }
}