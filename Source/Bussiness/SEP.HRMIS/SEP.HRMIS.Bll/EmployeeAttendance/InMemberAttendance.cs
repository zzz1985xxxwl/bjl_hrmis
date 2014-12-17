//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteBadAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-08
// 概述: 内存持久对象，用于测试，请不要删除它，它的作用等于mock
//       我还没有找到合适的存放他们的位置，一旦找到，立马搬家
// ----------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    public class InMemberAttendance
    {
        #region 内存持久对象

        public class MockEmployees : IEmployee
        {
            private static Hashtable _EmployeeTable = new Hashtable();
            private static int _EmployeeId = 1;

            #region IEmployee 成员

            public int Insert(Employee obj)
            {
                _EmployeeTable.Add(_EmployeeId, obj);
                obj.Account.Id = _EmployeeId;
                return _EmployeeId++;
            }

            public List<Employee> GetEmployeeByCondition(string employeeName, DateTime birthdayStart, DateTime birthdayEnd, DateTime comeDateStart, DateTime comeDateEnd, string email, DateTime residencePermitStart, DateTime residencePermitEnd, EmployeeTypeEnum type, int positionId, int departmentId)
            {
                throw new Exception("The method or operation is not implemented.");
            }
            public List<Employee> GetEmployeeBasicInfoByBasicConditionAndFirstLetter(string employeeName,
                                                           EmployeeTypeEnum type, int positionId,
                                                           int departmentId, string loginNameLike)
            {
                throw new Exception("The method or operation is not implemented.");
            }
            
            #region 新的接口

            
            public int CreateEmployee(Employee aNewEmployee)
            {
                _EmployeeTable.Add(_EmployeeId, aNewEmployee);
                aNewEmployee.Account.Id = _EmployeeId;
                return _EmployeeId++;
            }

            public void UpdateEmployee(Employee theEmployee)
            {
                _EmployeeTable[theEmployee.Account.Id] = theEmployee;
            }

            public List<Employee> GetEmployeeBasicInfoByCompanyID(int companyID)
            {
                throw new NotImplementedException();
            }

            public List<Department> GetAllCompanyHaveEmployee()
            {
                throw new NotImplementedException();
            }

            public byte[] GetEmployeePhotoByAccountID(int accountID)
            {
                throw new NotImplementedException();
            }

            public int CountEmployeeByNationalityID(int nationalityID)
            {
                throw new NotImplementedException();
            }

            public List<Employee> GetAllEmployeeInfo()
            {
                throw new NotImplementedException();
            }

            public Employee GetEmployeeBasicInfoByAccountID(int accountID)
            {
                throw new NotImplementedException();
            }

            public bool GetCanReceiveMessageByEmployeeID(int employeeID)
            {
                throw new NotImplementedException();
            }


            public int DeleteEmployeeByAccountID(int accountID)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public Employee GetEmployeeByAccountID(int accountID)
            {
                return _EmployeeTable[accountID] as Employee;
            }

            public Employee GetEmployeeByName(string Name)
            {
                  foreach (DictionaryEntry entry in _EmployeeTable)
                  {
                      Employee employee = entry.Value as Employee;
                      if (employee != null && employee.Account.Name.Equals(Name))
                          return employee;
                  }

                  return null;
            }

            public Employee GetEmployeeByAccountsName(string name)
            {
                foreach (DictionaryEntry entry in _EmployeeTable)
                {
                    Employee employee = entry.Value as Employee;
                    if (employee != null && employee.Account.Name.Equals(name))
                        return employee;
                }

                return null;
            }

            public Employee GetDepartmentLeaderByDepartmentID(int departmentID)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public List<Employee> GetAllEmployeeBasicInfo()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName, EmployeeTypeEnum type, int positionId, int departmentId, bool recursionDepartment)
            {
                List<Employee> retVal = new List<Employee>();

                foreach (DictionaryEntry entry in _EmployeeTable)
                {
                    Employee employee = entry.Value as Employee;
                    if (employee == null)
                        continue;

                    if(!string.IsNullOrEmpty(employeeName))
                    {
                        if(employee.Account.Name.Equals(employeeName))
                        {
                            retVal.Add(employee);
                        }
                    }
                    else
                    {
                        retVal.Add(employee);
                    }
                    if(type != EmployeeTypeEnum.All)
                    {
                        foreach(Employee e in retVal)
                        {
                            if(!e.EmployeeType.Equals(type))
                            {
                                retVal.Remove(e);
                            }
                        }
                    }
                    if(positionId != -1)
                    {
                        foreach (Employee e in retVal)
                        {
                            if (!e.Account.Position.ParameterID.Equals(positionId))
                            {
                                retVal.Remove(e);
                            }
                        }
                    }
                    if(departmentId != -1)
                    {
                        foreach (Employee e in retVal)
                        {
                            if (!e.Account.Dept.Id.Equals(departmentId))
                            {
                                retVal.Remove(e);
                            }
                        }
                    }
                    if(recursionDepartment)
                    {
                        throw new Exception("方法未实现");
                    }

                    return retVal;
                }
                return null;
            }

            public List<Employee> GetEmployeeLikeLoginName(string loginNameLike)
            {
                throw new Exception("The method or operation is not implemented.");
            }


            #endregion

            public void ClearData()
            {
                _EmployeeTable = new Hashtable();
                _EmployeeId = 1;
            }

            public int CreateEmployeeHistory(EmployeeHistory aNewEmployeeHistory)
            {
                return 1;
            }


            public void UpdateEmployeeHistory(EmployeeHistory theEmployeeHistory)
            {
                throw new Exception("The method or operation is not implemented.");
            }


            public int DeleteEmployeeHistoryByPKID(int EmployeeHistoryID)
            {
                throw new Exception("The method or operation is not implemented.");
            }


            public int SetReceiveMessage(int employeeID, int ifReceiveMessage)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            public int DeleteReceiveMessageByEmployeeID(int employeeID)
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion
        }

        //todo noted by wsl ,I want to delete the file
        public class MockBadAttendance : IBadAttendance
        {
            private static readonly Hashtable _BadAttendanceTable = new Hashtable();
            private static int _BadAttendanceId = 1;

            #region IBadAttendance 成员

            public int Insert(AttendanceBase attendance)
            {
                attendance.AttendanceId = _BadAttendanceId;
                _BadAttendanceTable.Add(_BadAttendanceId, attendance);
                return _BadAttendanceId++;
            }

            public AttendanceBase GetAttendanceById(int attendanceId)
            {
                return _BadAttendanceTable[attendanceId] as AttendanceBase;
            }

            public List<AttendanceBase> GetAttendanceByEmpId(int EmpId)
            {
                List<AttendanceBase> allAttendances = new List<AttendanceBase>();

                foreach (DictionaryEntry entry in _BadAttendanceTable)
                {
                    AttendanceBase attendance = entry.Value as AttendanceBase;
                    if (attendance != null && attendance.EmployeeId.Equals(EmpId))
                        allAttendances.Add(attendance);
                }

                return allAttendances;
            }

            public List<AttendanceBase> GetAttendanceByCondition(int employeeId, DateTime theDayFrom,
                                                                 DateTime theDayTo, AttendanceTypeEmnu AttendaceType)
            {
                throw new NotImplementedException();
            }

            public List<AttendanceBase> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo,
                                                              AttendanceTypeEmnu AttendaceType)
            {
                throw new NotImplementedException();
            }

            public void DeleteEmployeeAttendanceByEmpAndTime(int EmpId, DateTime theDay)
            {
                foreach (DictionaryEntry entry in _BadAttendanceTable)
                {
                    AttendanceBase attendance = entry.Value as AttendanceBase;
                    if (attendance != null &&
                        attendance.EmployeeId.Equals(EmpId) &&
                        attendance.TheDay.Equals(theDay))
                    {
                        _BadAttendanceTable.Remove(entry.Key);
                        break;
                    }
                }
            }


            public void Delete(int _AttendanceId)
            {
                foreach (DictionaryEntry entry in _BadAttendanceTable)
                {
                    AttendanceBase attendance = entry.Value as AttendanceBase;
                    if (attendance != null && attendance.AttendanceId.Equals(_AttendanceId))
                    {
                        _BadAttendanceTable.Remove(entry.Key);
                        break;
                    }
                }
            }

            public void TurnToDayAttendanceList(Employee employee)
            {
                
            }
            #endregion
        }

       
        #endregion
    }
}