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
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using ShiXin.Security;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 员工历史数据交互
    /// </summary>
    public class EmployeeHistoryDal : IEmployeeHistory
    {
        #region 私有常量
        private const string _ParmEmployeeHistoryID = "@EmployeeHistoryID";
        private const string _ParmPKID = "@PKID";
        private const string _ParmAccountID = "@AccountID";
        private const string _ParmCompanyID = "@CompanyID";
        private const string _ParmAccountType = "@AccountType";
        private const string _ParmMobileNum = "@MobileNum";
        private const string _ParmIsAcceptEmail = "@IsAcceptEmail";
        private const string _ParmIsAcceptSMS = "@IsAcceptSMS";
        private const string _ParmIsValidateUsbKey = "@IsValidateUsbKey";
        private const string _ParmLeaveDate = "@LeaveDate";
        private const string _ParmName = "@Name";
        private const string _ParmLoginName = "@LoginName";
        private const string _ParmPassword = "@Password";
        private const string _ParmEmail1 = "@Email1";
        private const string _ParmEmail2 = "@Email2";
        private const string _ParmDepartmentID = "@DepartmentID";
        private const string _ParmPositionID = "@PositionID";
        private const string _ParmComeDate = "@ComeDate";
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
        private const string _ParmUsbKey = "@UsbKey";
        private const string _ParmPhoto = "@Photo";
        private const string _ParmDoorCardNo = "@DoorCardNo";
        private const string _ParmSocietyWorkAge = "@SocietyWorkAge";
        private const string _ParmOperatorID = "@OperatorID";
        private const string _ParmOperationTime = "@OperationTime";
        private const string _ParmRemark = "@Remark";
        private const string _ParmDepartmentName = "@DepartmentName";
        private const string _ParmPositionName = "@PositionName";
        private const string _ParmOperatorName = "@OperatorName";
        private const string _ParmLeaderName = "@LeaderName";
        private const string _ParmPositionGradeID = "PositionGradeID";
        private const string _ParmPrincipalShipID = "@PrincipalShipID";
        private const string _ParmSalaryCardNo = "@SalaryCardNo";
        private const string _ParmSalaryCardBank = "@SalaryCardBank";

        private const string _DBSalaryCardNo = "SalaryCardNo";
        private const string _DBSalaryCardBank = "SalaryCardBank";
        private const string _DBPKID = "PKID";
        private const string _DBCompanyID = "CompanyID";
        private const string _DBAccountID = "AccountID";
        private const string _DBAccountType = "AccountType";
        private const string _DBMobileNum = "MobileNum";
        private const string _DBIsAcceptEmail = "IsAcceptEmail";
        private const string _DBIsAcceptSMS = "IsAcceptSMS";
        private const string _DBIsValidateUsbKey = "IsValidateUsbKey";
        private const string _DBLeaveDate = "LeaveDate";
        private const string _DBName = "Name";
        private const string _DBLoginName = "LoginName";
        private const string _DBPassword = "Password";
        private const string _DBEmail1 = "Email1";
        private const string _DBEmail2 = "Email2";
        private const string _DBDepartmentID = "DepartmentID";
        private const string _DBPositionID = "PositionID";
        private const string _DBComeDate = "ComeDate";
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
        private const string _DBProbationStartTime = "ProbationStartTime";
        private const string _DBUsbKey = "UsbKey";
        private const string _DBPhoto = "Photo";
        private const string _DBDoorCardNo = "DoorCardNo";
        private const string _DBSocietyWorkAge = "SocietyWorkAge";
        private const string _DBOperatorID = "OperatorID";
        private const string _DBOperationTime = "OperationTime";
        private const string _DBRemark = "Remark";
        private const string _DBDepartmentName = "DepartmentName";
        private const string _DBPositionName = "PositionName";
        private const string _DBOperatorName = "OperatorName";
        private const string _DBLeaderName = "LeaderName";
        private const string _DBPositionGradeID = "PositionGradeID";
        private const string _Dt = "@dt";
        public const string _DBError = "数据库访问错误!";
        private const string _DBPrincipalShipID = "PrincipalShipID";
        #endregion

        public int CreateEmployeeHistory(EmployeeHistory employeeHistory)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SetParmNeededValues(cmd, employeeHistory.Employee);
                SetParmNullableValues(cmd, employeeHistory.Employee);
                cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = employeeHistory.Operator.Id;
                cmd.Parameters.Add(_ParmOperatorName, SqlDbType.NVarChar, 50).Value = employeeHistory.Operator.Name;
                cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = employeeHistory.OperationTime;
                cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 255).Value = employeeHistory.Remark;

                SqlHelper.ExecuteNonQueryReturnPKID("EmployeeHistoryInsert", cmd, out pkid);
                employeeHistory.EmployeeHistoryPKID = pkid;
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return pkid;
        }

        public int UpdateEmployeeHistory(EmployeeHistory employeeHistory)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = employeeHistory.EmployeeHistoryPKID;
                SetParmNeededValues(cmd, employeeHistory.Employee);
                SetParmNullableValues(cmd, employeeHistory.Employee);
                cmd.Parameters.Add(_ParmOperatorID, SqlDbType.Int).Value = employeeHistory.Operator.Id;
                cmd.Parameters.Add(_ParmOperatorName, SqlDbType.NVarChar, 50).Value = employeeHistory.Operator.Name;
                cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = employeeHistory.OperationTime;
                cmd.Parameters.Add(_ParmRemark, SqlDbType.NVarChar, 255).Value = employeeHistory.Remark;

                SqlHelper.ExecuteNonQueryReturnPKID("EmployeeHistoryUpdate", cmd, out pkid);
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return pkid;
        }

        public int DeleteEmployeeHistoryByPKID(int EmployeeHistoryID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeHistoryID, SqlDbType.Int).Value = EmployeeHistoryID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeHistoryByPKID", cmd);
        }

        public EmployeeHistory GetEmployeeHistoryByEmployeeHistoryID(int employeeHistoryID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_ParmEmployeeHistoryID, SqlDbType.Int).Value = employeeHistoryID;
                using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryByEmployeeHistoryID", cmd))
                {
                    while (sdr.Read())
                    {
                        Employee theEmployee = new Employee();
                        EmployeeHistory theEmployeeHistory =
                            new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                                new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                                sdr[_DBRemark].ToString());
                        theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                        GetEmployeeImageFieldFromParm(sdr, theEmployee);
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                        return theEmployeeHistory;
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DBError);
            }
            return null;
        }

        public EmployeeHistory GetEmployeeHistoryBasicInfoByEmployeeHistoryID(int employeeHistoryID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeHistoryID, SqlDbType.Int).Value = employeeHistoryID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryBasicInfoByEmployeeHistoryID", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    return theEmployeeHistory;
                }
            }
            return null;
        }

        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByAccountID(int accountID)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryBasicInfoByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public List<EmployeeHistory> GetEmployeeHistoryByAccountID(int accountID)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTime(DateTime dt)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Dt, SqlDbType.DateTime).Value = dt;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeBasicInfoByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public EmployeeHistory GetEmployeeHistoryBasicInfoByDateTime(int accountID, DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = date;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryBasicInfoByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    return theEmployeeHistory;
                }
            }
            return null;
        }

        public EmployeeHistory GetEmployeeHistoryByDateTime(int accountID, DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = date;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryByDateTimeAndAccount", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    return theEmployeeHistory;
                }
            }
            return null;
        }

        public List<EmployeeHistory> GetEmployeeHistoryByDateTime(DateTime date)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = date;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(int departmentID, DateTime dt)
        {
            DateTime temp = Convert.ToDateTime(dt.ToShortDateString()).AddDays(1);
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = departmentID;
            cmd.Parameters.Add(_Dt, SqlDbType.DateTime).Value = temp;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeBasicInfoByDepartmentIDAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public List<EmployeeHistory> GetEmployeeHistoryByDepartmentIDAndDateTime(int departmentID, DateTime dt)
        {
            DateTime temp = Convert.ToDateTime(dt.ToShortDateString()).AddDays(1);
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = departmentID;
            cmd.Parameters.Add(_Dt, SqlDbType.DateTime).Value = temp;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeByDepartmentIDAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    iRet.Add(theEmployeeHistory);
                }
            }
            return iRet;
        }

        public EmployeeHistory GetEmployeeHistoryAtLeaveDate(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryAtLeaveDate", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    return theEmployeeHistory;
                }
            }
            return null;
        }

        public EmployeeHistory GetEmployeeHistoryBasicInfoAtLeaveDate(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryBasicInfoAtLeaveDate", cmd))
            {
                while (sdr.Read())
                {
                    Employee theEmployee = new Employee();
                    EmployeeHistory theEmployeeHistory =
                        new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                            new Account(Convert.ToInt32(sdr[_DBOperatorID]), "", sdr[_DBOperatorName].ToString()),
                                            sdr[_DBRemark].ToString());
                    theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                    GetEmployeeImageFieldFromParm(sdr, theEmployee);
                    GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                    return theEmployeeHistory;
                }
            }
            return null;
        }

        public List<EmployeeHistory> GetEmployeeHistoryBasicInfoByDateTimeAndDept(DateTime dt, List<Department> depttree)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Dt, SqlDbType.DateTime).Value = dt;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeBasicInfoByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    int deptID;
                    if (sdr[_DBDepartmentID] != null &&
                        int.TryParse(sdr[_DBDepartmentID].ToString(), out deptID)
                        && Department.FindDepartmentInTreeStruct(depttree, deptID) != null)
                    {
                        Employee theEmployee = new Employee();
                        EmployeeHistory theEmployeeHistory =
                            new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                                new Account(Convert.ToInt32(sdr[_DBOperatorID]), "",
                                                            sdr[_DBOperatorName].ToString()),
                                                sdr[_DBRemark].ToString());
                        theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                        GetEmployeeImageFieldFromParm(sdr, theEmployee);
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                        iRet.Add(theEmployeeHistory);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return iRet;
        }

        public List<EmployeeHistory> GetEmployeeHistoryByDateTimeAndDept(DateTime dt, List<Department> depttree)
        {
            List<EmployeeHistory> iRet = new List<EmployeeHistory>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmOperationTime, SqlDbType.DateTime).Value = dt;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeHistoryByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    int deptID;
                    if (sdr[_DBDepartmentID] != null &&
                        int.TryParse(sdr[_DBDepartmentID].ToString(), out deptID)
                        && Department.FindDepartmentInTreeStruct(depttree, deptID) != null)
                    {
                        Employee theEmployee = new Employee();
                        EmployeeHistory theEmployeeHistory =
                            new EmployeeHistory(theEmployee, Convert.ToDateTime(sdr[_DBOperationTime]),
                                                new Account(Convert.ToInt32(sdr[_DBOperatorID]), "",
                                                            sdr[_DBOperatorName].ToString()),
                                                sdr[_DBRemark].ToString());
                        theEmployeeHistory.EmployeeHistoryPKID = Convert.ToInt32(sdr[_DBPKID]);
                        GetEmployeeImageFieldFromParm(sdr, theEmployee);
                        GetEmployeeNotImageFieldFromParm(sdr, theEmployee);

                        iRet.Add(theEmployeeHistory);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return iRet;
        }

        #region private method
        /// <summary>
        /// 除image以外的数据赋值
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="aNewEmployee"></param>
        private static void SetParmNeededValues(SqlCommand cmd, Employee aNewEmployee)
        {
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
            //account对象
            cmd.Parameters.Add(_ParmAccountID, SqlDbType.Int).Value = aNewEmployee.Account.Id;

            cmd.Parameters.Add(_ParmLoginName, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.LoginName;
            cmd.Parameters.Add(_ParmPassword, SqlDbType.NVarChar, 2000).Value = aNewEmployee.Account.Password ?? "";
            if (aNewEmployee.Account.UsbKey == null)
            {
                cmd.Parameters.Add(_ParmUsbKey, SqlDbType.NVarChar, 2000).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_ParmUsbKey, SqlDbType.NVarChar, 2000).Value = aNewEmployee.Account.UsbKey;
            }
            cmd.Parameters.Add(_ParmAccountType, SqlDbType.Int).Value = aNewEmployee.Account.AccountType;
            cmd.Parameters.Add(_ParmName, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.Name;
            cmd.Parameters.Add(_ParmEmail1, SqlDbType.NVarChar, 255).Value = aNewEmployee.Account.Email1;
            cmd.Parameters.Add(_ParmEmail2, SqlDbType.NVarChar, 255).Value = aNewEmployee.Account.Email2 ??
                                                                             (object)DBNull.Value;
            cmd.Parameters.Add(_ParmMobileNum, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.MobileNum ?? "";
            cmd.Parameters.Add(_ParmIsAcceptEmail, SqlDbType.Int).Value = aNewEmployee.Account.IsAcceptEmail;
            cmd.Parameters.Add(_ParmIsAcceptSMS, SqlDbType.Int).Value = aNewEmployee.Account.IsAcceptSMS;
            cmd.Parameters.Add(_ParmIsValidateUsbKey, SqlDbType.Int).Value = aNewEmployee.Account.IsValidateUsbKey;

            cmd.Parameters.Add(_ParmDepartmentID, SqlDbType.Int).Value = aNewEmployee.Account.Dept.Id;
            cmd.Parameters.Add(_ParmDepartmentName, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.Dept.Name;
            cmd.Parameters.Add(_ParmLeaderName, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.Dept.Leader.Name;

            cmd.Parameters.Add(_ParmPositionID, SqlDbType.Int).Value = aNewEmployee.Account.Position.Id;
            cmd.Parameters.Add(_ParmPositionName, SqlDbType.NVarChar, 50).Value = aNewEmployee.Account.Position.Name;

            //职位等级
            if (aNewEmployee.Account.Position != null && aNewEmployee.Account.Position.Grade != null)
            {
                cmd.Parameters.Add(_ParmPositionGradeID, SqlDbType.Int).Value = aNewEmployee.Account.Position.Grade.Id;
            }
            else
            {
                cmd.Parameters.Add(_ParmPositionGradeID, SqlDbType.Int).Value = -1;
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
                if (DateTime.Compare(aNewEmployee.EmployeeDetails.ProbationTime, new DateTime(1900, 1, 1)) > 0)
                {
                    cmd.Parameters.Add(_ParmProbationTime, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.ProbationTime;
                }
                else
                {
                    cmd.Parameters.Add(_ParmProbationTime, SqlDbType.DateTime).Value = DBNull.Value;
                }
                if (DateTime.Compare(aNewEmployee.EmployeeDetails.ProbationStartTime, new DateTime(1900, 1, 1)) > 0)
                {
                    cmd.Parameters.Add(_ParmProbationStartTime, SqlDbType.DateTime).Value =
                        aNewEmployee.EmployeeDetails.ProbationStartTime;
                }
                else
                {
                    cmd.Parameters.Add(_ParmProbationStartTime, SqlDbType.DateTime).Value = DBNull.Value;
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
                    cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = DBNull.Value;
                    //cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = aNewEmployee.EmployeeDetails.Photo;
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
                    cmd.Parameters.Add(_ParmSalaryCardNo, SqlDbType.NVarChar, 255).Value =
                        aNewEmployee.EmployeeDetails.Work.SalaryCardNo ?? string.Empty;
                    cmd.Parameters.Add(_ParmSalaryCardBank, SqlDbType.NVarChar, 255).Value =
                       aNewEmployee.EmployeeDetails.Work.SalaryCardBank ?? string.Empty;

                }
                else
                {
                    cmd.Parameters.Add(_ParmComeDate, SqlDbType.DateTime).Value = DBNull.Value;
                    cmd.Parameters.Add(_ParmWorkType, SqlDbType.Int).Value = DBNull.Value;
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
                cmd.Parameters.Add(_ParmPhoto, SqlDbType.Image).Value = DBNull.Value;
                cmd.Parameters.Add(_ParmPrincipalShipID, SqlDbType.Int).Value = DBNull.Value;
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
        private static void GetEmployeeImageFieldFromParm(SqlDataReader sdr, Employee employee)
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
                int tryIntParse;
                DateTime tryDateTimeParse;
                bool tryBoolParse;
                switch (sdr.GetName(i))
                {
                    case _DBCompanyID:
                        if (sdr[_DBCompanyID] != null && int.TryParse(sdr[_DBCompanyID].ToString(), out tryIntParse))
                        {
                            employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                            employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                            employee.EmployeeDetails.Work.Company =
                                employee.EmployeeDetails.Work.Company ?? new Department();
                            employee.EmployeeDetails.Work.Company.DepartmentID = (int) sdr[_DBCompanyID];
                        }
                        break;
                    case _DBAccountID:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBAccountID] != null && int.TryParse(sdr[_DBAccountID].ToString(), out tryIntParse))
                            employee.Account.Id = (int) sdr[_DBAccountID];
                        employee.Account.Position = new Position();
                        employee.Account.Position.Grade = new PositionGrade();
                        employee.Account.Position.Grade.Id = (int) sdr[_DBPositionGradeID];
                        break;
                    case _DBEmployeeType:
                        if (sdr[_DBEmployeeType] != null &&
                            int.TryParse(sdr[_DBEmployeeType].ToString(), out tryIntParse))
                            employee.EmployeeType = (EmployeeTypeEnum) sdr[_DBEmployeeType];
                        break;
                    case _DBComeDate:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        if (sdr[_DBComeDate] != null &&
                            DateTime.TryParse(sdr[_DBComeDate].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.Work.ComeDate = (DateTime) sdr[_DBComeDate];
                        break;
                    case _DBLeaveDate:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        employee.EmployeeDetails.Work.DimissionInfo = employee.EmployeeDetails.Work.DimissionInfo ??
                                                                      new DimissionInfo();
                        if (sdr[_DBLeaveDate] != null &&
                            DateTime.TryParse(sdr[_DBLeaveDate].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = (DateTime) sdr[_DBLeaveDate];
                        break;
                    case _DBBirthday:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBBirthday] != null &&
                            DateTime.TryParse(sdr[_DBBirthday].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.Birthday = (DateTime) sdr[_DBBirthday];
                        break;
                    case _DBResidencePermit:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.ResidencePermits = employee.EmployeeDetails.ResidencePermits ??
                                                                    new ResidencePermit();
                        if (sdr[_DBResidencePermit] != null &&
                            DateTime.TryParse(sdr[_DBResidencePermit].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.ResidencePermits.DueDate = (DateTime) sdr[_DBResidencePermit];
                        break;
                    case _DBEnglishName:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBEnglishName] != null)
                            employee.EmployeeDetails.EnglishName = sdr[_DBEnglishName].ToString();
                        break;
                    case _DBGender:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBGender] != null && int.TryParse(sdr[_DBGender].ToString(), out tryIntParse))
                            employee.EmployeeDetails.Gender = Gender.GetById((int) sdr[_DBGender]);
                        break;
                    case _DBPoliticalAffiliation:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBPoliticalAffiliation] != null &&
                            int.TryParse(sdr[_DBPoliticalAffiliation].ToString(), out tryIntParse))
                            employee.EmployeeDetails.PoliticalAffiliation =
                                PoliticalAffiliation.GetById((int) sdr[_DBPoliticalAffiliation]);
                        break;
                    case _DBMaritalStatus:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBMaritalStatus] != null &&
                            int.TryParse(sdr[_DBMaritalStatus].ToString(), out tryIntParse))
                            employee.EmployeeDetails.MaritalStatus = MaritalStatus.GetById((int) sdr[_DBMaritalStatus]);
                        break;
                    case _DBEducationalBackground:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Education = employee.EmployeeDetails.Education ?? new Education();
                        if (sdr[_DBEducationalBackground] != null &&
                            int.TryParse(sdr[_DBEducationalBackground].ToString(), out tryIntParse))
                            employee.EmployeeDetails.Education.EducationalBackground =
                                EducationalBackground.GetById((int) sdr[_DBEducationalBackground]);
                        break;
                    case _DBWorkType:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Work = employee.EmployeeDetails.Work ?? new Work();
                        if (sdr[_DBWorkType] != null && int.TryParse(sdr[_DBWorkType].ToString(), out tryIntParse))
                            employee.EmployeeDetails.Work.WorkType = WorkType.GetById((int) sdr[_DBWorkType]);
                        break;
                    case _DBHasChild:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Family = employee.EmployeeDetails.Family ?? new Family();
                        if (sdr[_DBHasChild] != null && bool.TryParse(sdr[_DBHasChild].ToString(), out tryBoolParse))
                            employee.EmployeeDetails.Family.HasChild = (bool) sdr[_DBHasChild];
                        break;
                    case _DBCertificates:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.Education = employee.EmployeeDetails.Education ?? new Education();
                        if (sdr[_DBCertificates] != null)
                            employee.EmployeeDetails.Education.Certificates = sdr[_DBCertificates].ToString();
                        break;
                    case _DBPRPArea:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        employee.EmployeeDetails.RegisteredPermanentResidence =
                            employee.EmployeeDetails.RegisteredPermanentResidence ?? new RegisteredPermanentResidence();
                        if (sdr[_DBPRPArea] != null)
                            employee.EmployeeDetails.RegisteredPermanentResidence.PRPArea = sdr[_DBPRPArea].ToString();
                        break;
                    case _DBProbationTime:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBProbationTime] != null &&
                            DateTime.TryParse(sdr[_DBProbationTime].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.ProbationTime = (DateTime) sdr[_DBProbationTime];
                        break;
                    case _DBProbationStartTime:
                        employee.EmployeeDetails = employee.EmployeeDetails ?? new EmployeeDetails();
                        if (sdr[_DBProbationStartTime] != null &&
                            DateTime.TryParse(sdr[_DBProbationStartTime].ToString(), out tryDateTimeParse))
                            employee.EmployeeDetails.ProbationStartTime = (DateTime) sdr[_DBProbationStartTime];
                        break;
                    case _DBDoorCardNo:
                        employee.EmployeeAttendance = employee.EmployeeAttendance ?? new EmployeeAttendance();
                        if (sdr[_DBDoorCardNo] != null)
                            employee.EmployeeAttendance.DoorCardNo = sdr[_DBDoorCardNo].ToString();
                        break;
                    case _DBSocietyWorkAge:
                        employee.SocWorkAgeAndVacationList = employee.SocWorkAgeAndVacationList ??
                                                             new SocWorkAgeAndVacationList();
                        if (sdr[_DBSocietyWorkAge] != null &&
                            int.TryParse(sdr[_DBSocietyWorkAge].ToString(), out tryIntParse))
                            employee.SocWorkAgeAndVacationList.SocietyWorkAge = (int) sdr[_DBSocietyWorkAge];
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

                        #region accountHistory

                    case _DBAccountType:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBAccountType] != null && int.TryParse(sdr[_DBAccountType].ToString(), out tryIntParse))
                            employee.Account.AccountType = (VisibleType) sdr[_DBAccountType];
                        break;

                    case _DBName:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBName] != null)
                            employee.Account.Name = sdr[_DBName].ToString();
                        break;

                    case _DBLoginName:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBLoginName] != null)
                            employee.Account.LoginName = sdr[_DBLoginName].ToString();
                        break;

                    case _DBEmail1:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBEmail1] != null)
                            employee.Account.Email1 = sdr[_DBEmail1].ToString();
                        break;

                    case _DBEmail2:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBEmail2] != null)
                            employee.Account.Email2 = sdr[_DBEmail2].ToString();
                        break;

                    case _DBMobileNum:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBMobileNum] != null)
                            employee.Account.MobileNum = sdr[_DBMobileNum].ToString();
                        break;

                    case _DBIsAcceptEmail:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBIsAcceptEmail] != null &&
                            bool.TryParse(sdr[_DBHasChild].ToString(), out tryBoolParse))
                            employee.Account.IsAcceptEmail = (bool) sdr[_DBIsAcceptEmail];
                        break;

                    case _DBIsAcceptSMS:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBIsAcceptSMS] != null && bool.TryParse(sdr[_DBHasChild].ToString(), out tryBoolParse))
                            employee.Account.IsAcceptSMS = (bool) sdr[_DBIsAcceptSMS];
                        break;

                    case _DBIsValidateUsbKey:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBIsValidateUsbKey] != null &&
                            bool.TryParse(sdr[_DBHasChild].ToString(), out tryBoolParse))
                            employee.Account.IsValidateUsbKey = (bool) sdr[_DBIsValidateUsbKey];
                        break;

                    case _DBDepartmentID:
                        employee.Account = employee.Account ?? new Account();
                        employee.Account.Dept = employee.Account.Dept ?? new Department();
                        if (sdr[_DBDepartmentID] != null &&
                            int.TryParse(sdr[_DBDepartmentID].ToString(), out tryIntParse))
                            employee.Account.Dept.Id = (int) sdr[_DBDepartmentID];
                        break;

                    case _DBDepartmentName:
                        employee.Account = employee.Account ?? new Account();
                        employee.Account.Dept = employee.Account.Dept ?? new Department();
                        if (sdr[_DBDepartmentName] != null)
                            employee.Account.Dept.Name = sdr[_DBDepartmentName].ToString();
                        break;

                    case _DBLeaderName:
                        employee.Account = employee.Account ?? new Account();
                        employee.Account.Dept = employee.Account.Dept ?? new Department();
                        employee.Account.Dept.Leader = employee.Account.Dept.Leader ?? new Account();
                        if (sdr[_DBLeaderName] != null)
                            employee.Account.Dept.Leader.Name = sdr[_DBLeaderName].ToString();
                        break;

                    case _DBPositionID:
                        employee.Account = employee.Account ?? new Account();
                        employee.Account.Position = employee.Account.Position ?? new Position();
                        if (sdr[_DBPositionID] != null && int.TryParse(sdr[_DBPositionID].ToString(), out tryIntParse))
                            employee.Account.Position.Id = (int) sdr[_DBPositionID];
                        break;

                    case _DBPositionName:
                        employee.Account = employee.Account ?? new Account();
                        employee.Account.Position = employee.Account.Position ?? new Position();
                        if (sdr[_DBPositionName] != null)
                            employee.Account.Position.Name = sdr[_DBPositionName].ToString();
                        break;

                    case _DBPassword:
                        employee.Account = employee.Account ?? new Account();
                        if (sdr[_DBPassword] != null)
                            employee.Account.Password = sdr[_DBPassword].ToString();
                        break;

                        //case _DBUsbKey:
                        //    employee.Account = employee.Account ?? new Account();
                        //    if (sdr[_DBUsbKey] != null)
                        //        employee.Account.UsbKey =
                        //            DalUtility.DecryptPassword(sdr[_DBUsbKey].ToString(), sdr[_DBLoginName].ToString());
                        //    break;

                        #endregion

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
            return formatter.Deserialize(SecurityUtil.SymmetricDecryptStream(theEmployeeDetailsBytes)) as EmployeeDetails;
        }

        #endregion
    }
}