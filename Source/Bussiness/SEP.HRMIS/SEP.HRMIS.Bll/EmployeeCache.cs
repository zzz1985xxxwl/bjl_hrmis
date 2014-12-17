//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeCache.cs
// 创建者: 倪豪
// 创建日期: 2008-11-20
// 概述: 使用单例方式构建的所有员工缓存，该缓存的数据精确保证到
//        private int _EmployeeID;
//        private string _Name;
//        private string _Email;
//        private string _Email2;
//        private EmployeeTypeEnum _EmployeeType;
//        private Position _Position;
//        private Department _Department;
//        private AccountsFront _AccountsFront;
//        private EmployeeDetails _EmployeeDetails;
//        以上的每一个字段，除此之外的信息并未加载，也并未保证
//        照片信息是否缓存可以设置
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public static class EmployeeCache
    {
        private static readonly IEmployee _EmployeeDal = DalFactory.DataAccess.CreateEmployee();
        private static List<Employee> _EmployeeCache;

        /// <summary>
        /// 所有员工的基本信息(包括二进制流信息，不包括其他需要再次加载的信息)
        /// 可以访问到员工的电话信息等二进制流的信息
        /// 但是却无法访问员工的合同信息/报销信息/考勤信息/邮件帐号/年假信息/等
        /// </summary>
        public static List<Employee> GetAllEmployeeBasicInfoFromCache
        {
            get
            {
                if(_EmployeeCache == null)
                {
                    _EmployeeCache = LoadAllEmployeeInfoWith(false);
                }
                return _EmployeeCache;
            }
        }

        public static void DisableEmployeeCache()
        {
            _EmployeeCache = null;
        }

        private static List<Employee> LoadAllEmployeeInfoWith(bool photoEnable)
        {
            List<Employee> allEmployees = _EmployeeDal.GetAllEmployeeBasicInfo();

            List<Employee> theDetailEmployees = new List<Employee>();
            foreach (Employee e in allEmployees)
            {
                Employee detailEmployee = _EmployeeDal.GetEmployeeByAccountID(e.Account.Id);
                //加入此字段防止对象加载出来被更新回去
                detailEmployee.ObjectStatus = false;
                //是否缓存照片信息
                if (!photoEnable)
                {
                    detailEmployee.EmployeeDetails.Photo = null;
                }
                theDetailEmployees.Add(detailEmployee);
            }

            return theDetailEmployees;
        }
    }
}