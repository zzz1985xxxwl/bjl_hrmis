//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VacationDal.cs
// 创建者: 薛文龙
// 创建日期: 2008-05-22
// 概述: 实现IVacation接口中的方法
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class VacationDal : IVacation
    {
        private const string _DbCount = "Counts";
        private const string _VacationID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _EmployeeName = "@EmployeeName";
        private const string _VacationDayNum = "@VacationDayNum";
        private const string _VacationStartDate = "@VacationStartDate";
        private const string _VacationEndDate = "@VacationEndDate";
        private const string _UsedDayNum = "@UsedDayNum";
        private const string _SurplusDayNum = "@SurplusDayNum";
        private const string _Remark = "@Remark";
        private const string _VacationDayNumStart = "@VacationDayNumStart";
        private const string _VacationDayNumEnd = "@VacationDayNumEnd";
        private const string _VacationEndDateStart = "@VacationEndDateStart";
        private const string _VacationEndDateEnd = "@VacationEndDateEnd";
        private const string _SurplusDayNumStart = "@SurplusDayNumStart";
        private const string _SurplusDayNumEnd = "@SurplusDayNumEnd";
        private const string _DbVacationID = "PKID";
        private const string _DbAccountID = "AccountID";
        private const string _DbEmployeeName = "EmployeeName";
        private const string _DbVacationDayNum = "VacationDayNum";
        private const string _DbVacationStartDate = "VacationStartDate";
        private const string _DbVacationEndDate = "VacationEndDate";
        private const string _DbUsedDayNum = "UsedDayNum";
        private const string _DbSurplusDayNum = "SurplusDayNum";
        private const string _DbRemark = "Remark";


        /// <summary>
        /// 插入年假信息
        /// </summary>
        /// <param name="vacation"></param>
        /// <returns>PKID</returns>
        public int Insert(Vacation vacation)
        {

            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_VacationID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = vacation.Employee.Account.Id;
            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = vacation.Employee.Account.Name;
            cmd.Parameters.Add(_VacationDayNum, SqlDbType.Decimal).Value = vacation.VacationDayNum;
            cmd.Parameters.Add(_VacationStartDate, SqlDbType.DateTime).Value = vacation.VacationStartDate;
            cmd.Parameters.Add(_VacationEndDate, SqlDbType.DateTime).Value = vacation.VacationEndDate;
            cmd.Parameters.Add(_UsedDayNum, SqlDbType.Decimal).Value = vacation.UsedDayNum;
            cmd.Parameters.Add(_SurplusDayNum, SqlDbType.Decimal).Value = vacation.SurplusDayNum;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = vacation.Remark;
            SqlHelper.ExecuteNonQueryReturnPKID("VacationInsert", cmd, out pkid);
            return pkid;

        }
        /// <summary>
        /// 更新年假
        /// </summary>
        /// <param name="vacation"></param>
        /// <returns></returns>
        public int Update(Vacation vacation)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_VacationID, SqlDbType.Int).Value = vacation.VacationID;
            //cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = vacation.Employee.accountID;
            //cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = vacation.Employee.Name;
            cmd.Parameters.Add(_VacationDayNum, SqlDbType.Decimal).Value = vacation.VacationDayNum;
            cmd.Parameters.Add(_VacationStartDate, SqlDbType.DateTime).Value = vacation.VacationStartDate;
            cmd.Parameters.Add(_VacationEndDate, SqlDbType.DateTime).Value = vacation.VacationEndDate;
            cmd.Parameters.Add(_UsedDayNum, SqlDbType.Decimal).Value = vacation.UsedDayNum;
            cmd.Parameters.Add(_SurplusDayNum, SqlDbType.Decimal).Value = vacation.SurplusDayNum;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = vacation.Remark;
            return SqlHelper.ExecuteNonQuery("VacationUpdate", cmd);

        }
        /// <summary>
        /// 通过员工ID查找年假数量
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int CountVacationByAccountID(int accountID)
        {
            int _retVal = -1;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountVacationByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    _retVal = Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 通过员工ID删除年假
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int DeleteVacationByAccountID(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            return SqlHelper.ExecuteNonQuery("DeleteVacationByAccountID", cmd);
        }

        /// <summary>
        /// 通过年假ID删除年假
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        public int DeleteVacationByVacationID(int vacationID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_VacationID, SqlDbType.Int).Value = vacationID;
            return SqlHelper.ExecuteNonQuery("DeleteVacationByVacationID", cmd);
        }

        /// <summary>
        /// 查找所有年假
        /// </summary>
        /// <returns></returns>
        public List<Vacation> GetAllVacation()
        {
            List<Vacation> vacationList = new List<Vacation>();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetAllVacation", cmd))
            {
                while (sdrItem.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdrItem[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdrItem[_DbEmployeeName].ToString();
                    Vacation vacation = new Vacation(Convert.ToInt32(sdrItem[_DbVacationID]), employee, Convert.ToDecimal(sdrItem[_DbVacationDayNum]),
                                                     Convert.ToDateTime(sdrItem[_DbVacationStartDate]), Convert.ToDateTime(sdrItem[_DbVacationEndDate]),
                                                     Convert.ToDecimal(sdrItem[_DbUsedDayNum]), Convert.ToDecimal(sdrItem[_DbSurplusDayNum]),
                                                     sdrItem[_DbRemark].ToString());
                    vacationList.Add(vacation);
                }
            }
            return vacationList;
        }


        /// <summary>
        /// 通过条件查询年假
        /// </summary>
        /// <param name="employeeName">员工姓名</param>
        /// <param name="vacationDayNumStart">年假总天数上限范围</param>
        /// <param name="vacationDayNumEnd">年假总天数下限范围</param>
        /// <param name="vacationEndDateStart">年假到期时间上限范围</param>
        /// <param name="vacationEndDateEnd">年假到期时间下限范围</param>
        /// <param name="surplusDayNumStart">年假剩余时间上限范围</param>
        /// <param name="surplusDayNumEnd">年假剩余时间下限范围<</param>
        /// <returns></returns>
        public List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart, decimal vacationDayNumEnd,
                                                     DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                                    decimal surplusDayNumStart, decimal surplusDayNumEnd)
        {
            List<Vacation> vacationList = new List<Vacation>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = employeeName;
            cmd.Parameters.Add(_VacationDayNumStart, SqlDbType.Decimal).Value = vacationDayNumStart;
            cmd.Parameters.Add(_VacationDayNumEnd, SqlDbType.Decimal).Value = vacationDayNumEnd;
            cmd.Parameters.Add(_VacationEndDateStart, SqlDbType.DateTime).Value = vacationEndDateStart;
            cmd.Parameters.Add(_VacationEndDateEnd, SqlDbType.DateTime).Value = vacationEndDateEnd;
            cmd.Parameters.Add(_SurplusDayNumStart, SqlDbType.Decimal).Value = surplusDayNumStart;
            cmd.Parameters.Add(_SurplusDayNumEnd, SqlDbType.Decimal).Value = surplusDayNumEnd;

            using (SqlDataReader sdrItem = SqlHelper.ExecuteReader("GetVacationByCondition", cmd))
            {
                while (sdrItem.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdrItem[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdrItem[_DbEmployeeName].ToString();

                    Vacation vacation = new Vacation(Convert.ToInt32(sdrItem[_DbVacationID]), employee, Convert.ToDecimal(sdrItem[_DbVacationDayNum]),
                                                     Convert.ToDateTime(sdrItem[_DbVacationStartDate]), Convert.ToDateTime(sdrItem[_DbVacationEndDate]),
                                                     Convert.ToDecimal(sdrItem[_DbUsedDayNum]), Convert.ToDecimal(sdrItem[_DbSurplusDayNum]),
                                                     sdrItem[_DbRemark].ToString());
                    vacationList.Add(vacation);
                }
            }
            return vacationList;
        }
        /// <summary>
        /// 通过员工ID查找年假
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<Vacation> GetVacationByAccountID(int accountID)
        {
            List<Vacation> vacationList = new List<Vacation>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetVacationByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdr[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdr[_DbEmployeeName].ToString();

                    vacationList.Add(new Vacation(Convert.ToInt32(sdr[_DbVacationID]), employee, Convert.ToDecimal(sdr[_DbVacationDayNum]),
                        Convert.ToDateTime(sdr[_DbVacationStartDate]), Convert.ToDateTime(sdr[_DbVacationEndDate]),
                        Convert.ToDecimal(sdr[_DbUsedDayNum]), Convert.ToDecimal(sdr[_DbSurplusDayNum]), sdr[_DbRemark].ToString()));
                }
            }
            return vacationList;

        }
        /// <summary>
        /// 获得员工最新的年假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Vacation GetLastVacationByAccountID(int accountID)
        {
            Vacation vacation = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastVacationByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdr[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdr[_DbEmployeeName].ToString();

                    vacation = new Vacation(Convert.ToInt32(sdr[_DbVacationID]), employee, Convert.ToDecimal(sdr[_DbVacationDayNum]),
                        Convert.ToDateTime(sdr[_DbVacationStartDate]), Convert.ToDateTime(sdr[_DbVacationEndDate]),
                        Convert.ToDecimal(sdr[_DbUsedDayNum]), Convert.ToDecimal(sdr[_DbSurplusDayNum]), sdr[_DbRemark].ToString());
                }
            }
            return vacation;

        }
        /// <summary>
        /// 通过年假ID查找年假
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        public Vacation GetVacationByVacationID(int vacationID)
        {
            Vacation vacation = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_VacationID, SqlDbType.Int).Value = vacationID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetVacationByVacationID", cmd))
            {
                while (sdr.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdr[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdr[_DbEmployeeName].ToString();
                    vacation =
                        new Vacation(Convert.ToInt32(sdr[_DbVacationID]), employee,
                                     Convert.ToDecimal(sdr[_DbVacationDayNum]),
                                     Convert.ToDateTime(sdr[_DbVacationStartDate]),
                                     Convert.ToDateTime(sdr[_DbVacationEndDate]),
                                     Convert.ToDecimal(sdr[_DbUsedDayNum]), Convert.ToDecimal(sdr[_DbSurplusDayNum]),
                                     sdr[_DbRemark].ToString());
                }
            }
            return vacation;
        }


        ///<summary>
        /// 获得某个员工，某个时间点以后的最近的一条年假信息
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="time"></param>
        ///<returns></returns>
        public Vacation GetNearVacationByAccountIDAndTime(int accountID, DateTime time)
        {
            Vacation vacation = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_VacationEndDate, SqlDbType.DateTime).Value = time;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNearVacationByAccountIDAndTime", cmd))
            {
                while (sdr.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdr[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdr[_DbEmployeeName].ToString();
                    vacation =
                        new Vacation(Convert.ToInt32(sdr[_DbVacationID]), employee,
                                     Convert.ToDecimal(sdr[_DbVacationDayNum]),
                                     Convert.ToDateTime(sdr[_DbVacationStartDate]),
                                     Convert.ToDateTime(sdr[_DbVacationEndDate]),
                                     Convert.ToDecimal(sdr[_DbUsedDayNum]), Convert.ToDecimal(sdr[_DbSurplusDayNum]),
                                     sdr[_DbRemark].ToString());
                }
            }
            return vacation;
        }

        /// <summary>
        /// 获得某个员工在一段时期内相关的年假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        public List<Vacation> GetVacationByAccountIDAndTimeSpan(int accountID, DateTime startDt, DateTime endDt)
        {
            List<Vacation> vacationList = new List<Vacation>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_VacationStartDate, SqlDbType.DateTime).Value = startDt;
            cmd.Parameters.Add(_VacationEndDate, SqlDbType.DateTime).Value = endDt;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetVacationByAccountIDAndTimeSpan", cmd))
            {
                while (sdr.Read())
                {
                    Employee employee =
                        new Employee(Convert.ToInt32(sdr[_DbAccountID]), new EmployeeTypeEnum());
                    employee.Account.Name = sdr[_DbEmployeeName].ToString();

                    vacationList.Add(new Vacation(Convert.ToInt32(sdr[_DbVacationID]), employee, Convert.ToDecimal(sdr[_DbVacationDayNum]),
                        Convert.ToDateTime(sdr[_DbVacationStartDate]), Convert.ToDateTime(sdr[_DbVacationEndDate]),
                        Convert.ToDecimal(sdr[_DbUsedDayNum]), Convert.ToDecimal(sdr[_DbSurplusDayNum]), sdr[_DbRemark].ToString()));
                }
            }
            return vacationList;

        }
    }
}
