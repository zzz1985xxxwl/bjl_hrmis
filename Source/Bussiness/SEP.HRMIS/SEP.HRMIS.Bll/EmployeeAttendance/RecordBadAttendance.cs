//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: RecordAbsentAttendance.cs
// 创建者: 倪豪
// 创建日期: 2008-08-08
// 概述: 所有不好的考勤记录的业务基类，这里我把不好的描述成了Bad
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll
{
    public abstract class RecordBadAttendance : Transaction
    {
        protected readonly string _EmpName;
        protected readonly DateTime _TheDay;
        //protected Employee _ItsEmployee;
        protected Account _ItsAccount;
        protected Account _LoginAccount;

        protected int _CurrentAttendanceId;

        public IAccountBll _IAccountBll;

        protected static IEmployee _EmployeeDal = new EmployeeDal();
        protected static IBadAttendance _AttendanceDal = new BadAttendanceDal();

        //protected abstract void ValidationSelf();
        //需要应用模板的类去判断，这个类型是否是与自己的实体类相同的类型
        protected abstract bool IsTheSameAttendanceType(AttendanceBase attendance);
        //每个应用模板自定义的重复错误的Id
        protected abstract string RepetExceptions();

        public RecordBadAttendance(string empName, DateTime theDay,Account user)
        {
            _LoginAccount = user;
            _ItsAccount = user;
            _EmpName = empName;
            _TheDay = theDay;
        }

        protected override void Validation()
        {
            if (_IAccountBll == null)
            {
                _IAccountBll = BllInstance.AccountBllInstance;
            }
            _ItsAccount = _IAccountBll.GetAccountByName(_EmpName);
           // _ItsEmployee = _EmployeeDal.GetEmployeeByAccountID(account.Id);
            
            //_ItsEmployee = _EmployeeDal.GetEmployeeByAccountID(_EmpName);
            if (_EmpName == null || _ItsAccount==null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Not_Found);
            }
            if(!IsLoginUserManage(_ItsAccount,_LoginAccount))
            {
                throw new ApplicationException("没有权限访问");
            }
            List<AttendanceBase> allAttendances = _AttendanceDal.GetAttendanceByEmpId(_ItsAccount.Id);
            foreach (AttendanceBase attendance in allAttendances)
            {
                if (IsTheSameAttendanceType(attendance) && AlreadyHaveTheSameDay(attendance))
                {
                    BllUtility.ThrowException(RepetExceptions());
                }
            }
        }

        protected bool AlreadyHaveTheSameDay(AttendanceBase attendance)
        {
            return attendance.TheDay.ToShortDateString().Equals(_TheDay.ToShortDateString());
        }

        public IEmployee EmployeeDal
        {
            set { _EmployeeDal = value; }
        }

        public IBadAttendance AttendanceDal
        {
            set { _AttendanceDal = value; }
        }

        public IAccountBll AccountBll
        {
            set { _IAccountBll = value; }
        }
        public int CurrentAttendanceId
        {
            get { return _CurrentAttendanceId; }
        }

        /// <summary>
        /// 判断登陆用户是否可以为员工添加考评纪录
        /// </summary>
        private bool IsLoginUserManage(Account addAccont, Account loginUser)
        {
            Auth myAuth = loginUser.FindAuth(AuthType.HRMIS,HrmisPowers.A505);

            if (myAuth == null)
            {
                throw new ApplicationException("您没有管理该员工的权限");
            }

            if (myAuth.Departments.Count == 0)
                return true;

            if (Tools.IsDeptListContainsDept(myAuth.Departments, _IAccountBll.GetAccountById(addAccont.Id).Dept))
                return true;

            return false;
        }
    }
}
