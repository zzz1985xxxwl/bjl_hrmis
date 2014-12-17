//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ImportFromXLS.cs
// 创建者:WYQ
// 创建日期: 2009-2-9
// 概述: 实现ImportFromXLS接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class ImportFromXLS
    {
        private readonly string _FilePath;
        private const string _NameColumn = "职工姓名";
        private const string _InOutColumn = "进0出1";
        private const string _DateColumn = "进入日期";
        private const string _TimeColumn = "进入时间";
        private string _Name;
        private int count;

        private readonly GetEmployee getEmployee = new GetEmployee();
        private readonly IAttendanceInAndOutRecord attendanceInAndOutRecordDal = DalFactory.DataAccess.CreateAttendanceInAndOutRecord();
        private IAccountBll _IAccountBll = BllInstance.AccountBllInstance;

        ///<summary>
        ///</summary>
        public ImportFromXLS(string filePath)
        {
            _FilePath = filePath;
        }

        ///<summary>
        ///</summary>
        public void Excute(out int employeeCount, out int Count, Account loginUser)
        {
            if (!File.Exists(_FilePath))
            {
                BllUtility.ThrowException(BllExceptionConst._Upload_Failed);
            }
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                             + _FilePath
                             + ";Extended Properties=\"Excel 8.0;IMEX=1;\"";
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                string sheetName = FirstSheetName(conn);
                OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + sheetName + "]", strConn);
                DataSet ds = new DataSet();
                oada.Fill(ds);
                employeeCount = ImportDate(ds.Tables[0]);
            }
            Count = count;
        }

        private int ImportDate(DataTable dt)
        {
            List<Employee> employeeList = new List<Employee>();
            DateTime dt_Now = DateTime.Now;
            //Employee employee
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _Name = GetItem(dt, i, _NameColumn);
                if (string.IsNullOrEmpty(_Name))
                    continue;
                Employee employee = employeeList.Find(FindEmployee);
                if (employee == null)
                {
                    Account account = _IAccountBll.GetAccountByName(_Name);
                    //如果系统里没有该员工或者该员工在系统中没有门禁卡卡号
                    if (account == null)
                    {
                        continue;
                    }
                    employee = getEmployee.GetEmployeeAttendenceInfoByAccountID(account.Id);
                    if (employee == null)
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(employee.EmployeeAttendance.DoorCardNo))
                    {
                        continue;
                    }
                    employee.EmployeeAttendance.AttendanceInAndOutRecordList = new List<AttendanceInAndOutRecord>();
                    employeeList.Add(employee);
                }
                AttendanceInAndOutRecord attendanceInAndOutRecord = new AttendanceInAndOutRecord();
                attendanceInAndOutRecord.IOStatus = GetInOutStatusByInOutName(GetItem(dt, i, _InOutColumn));
                try
                {
                    var date = Convert.ToDateTime(GetItem(dt, i, _DateColumn));
                    DateTime time;
                    if (DateTime.TryParse(GetItem(dt, i, _TimeColumn), out time))
                    {
                        attendanceInAndOutRecord.IOTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                    }
                    else
                    {
                        attendanceInAndOutRecord.IOTime = Convert.ToDateTime(date.ToString("yyyy-MM-dd") + " " + GetItem(dt, i, _TimeColumn));
                    }
                }
                catch
                {
                    continue;
                }
                attendanceInAndOutRecord.OperateStatus = OutInRecordOperateStatusEnum.ImportByOperator;
                attendanceInAndOutRecord.OperateTime = dt_Now;
                //判断读取中是否有重复记录 add by liudan 2009-09-19
                List<AttendanceInAndOutRecord> sqlRecords =
                    attendanceInAndOutRecordDal.GetAttendanceInAndOutRecordByCondition(employee.Account.Id,
                                                                                       employee.EmployeeAttendance.
                                                                                           DoorCardNo,
                                                                                       Convert.ToDateTime("1900-12-31"),
                                                                                       Convert.ToDateTime("2999-12-31"),
                                                                                       InOutStatusEnum.All,
                                                                                       OutInRecordOperateStatusEnum.All,
                                                                                       Convert.ToDateTime("1900-12-31"),
                                                                                       Convert.ToDateTime("2999-12-31"));
                bool isFind = false;
                foreach (AttendanceInAndOutRecord records in sqlRecords)
                {
                    if (attendanceInAndOutRecord.IOStatus.Equals(records.IOStatus) &&
                        attendanceInAndOutRecord.IOTime.Equals(records.IOTime))
                    {
                        isFind = true;
                    }
                }
                if (!isFind)
                {
                    employee.EmployeeAttendance.AttendanceInAndOutRecordList.Add(attendanceInAndOutRecord);
                    count = count + 1;
                }

            }
            attendanceInAndOutRecordDal.InsertAttendanceInAndOutRecordList(employeeList);
            return employeeList.Count;
        }

        private bool FindEmployee(Employee employee)
        {
            _Name = _Name.Replace(" ", "");
            return employee.Account.Name.Trim() == _Name.Trim();
        }

        ///<summary>
        ///</summary>
        public static InOutStatusEnum GetInOutStatusByInOutName(string name)
        {
            switch (name)
            {
                case "0":
                    return InOutStatusEnum.In;
                case "1":
                    return InOutStatusEnum.Out;
                default:
                    return InOutStatusEnum.All;
            }
        }

        /// <summary>
        /// 得到某列的一个元素
        /// </summary>
        /// <param name="dt">要在哪个表中找</param>
        /// <param name="rowID">第几行找，从0开始</param>
        /// <param name="columnName">列名</param>
        /// <returns>返回该表的指定列名，指定行的数据，无则返回EmptyNull</returns>
        private static string GetItem(DataTable dt, int rowID, string columnName)
        {
            int j = GetColumnIndex(dt, columnName);
            if (j != -1)
            {
                return dt.Rows[rowID][j].ToString();
            }
            return "EmptyNull";
        }

        /// <summary>
        /// 得到列号
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>没有则返回-1</returns>
        /// <param name="columnName">列名</param>
        private static int GetColumnIndex(DataTable dt, string columnName)
        {
            int j = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == columnName)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        /// <summary>
        /// 得到第一个工作表，如果工作表个数不是1则抛错
        /// </summary>
        private static string FirstSheetName(OleDbConnection conn)
        {
            DataTable sheetNames = conn.GetOleDbSchemaTable
                (OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            if (sheetNames.Rows.Count < 1)
            {
                throw new ApplicationException("确保至少有一个工作表！");
            }
            return sheetNames.Rows[0][2].ToString();
        }
    }
}
